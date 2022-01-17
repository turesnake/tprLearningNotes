/*

    目标: 去掉 sdf, 实现一个 单纯球体;

着色器输入
uniform vec3      iResolution;           // viewport resolution (in pixels) 画布尺寸, wh, 像素值;
uniform float     iTime;                 // shader playback time (in seconds) 时间
uniform float     iTimeDelta;            // render time (in seconds)
uniform int       iFrame;                // shader playback frame
uniform float     iChannelTime[4];       // channel playback time (in seconds) 四个贴图通道 各自的 播放时间
uniform vec3      iChannelResolution[4]; // channel resolution (in pixels)     四个贴图通道 各自的 分辨率
uniform vec4      iMouse;                // mouse pixel coords. xy: current (if 鼠标左键 down), zw: click
uniform samplerXX iChannel0..3;          // input channel. XX = 2D/Cube         四个贴图通道
uniform vec4      iDate;                 // (year, month, day, time in seconds)
uniform float     iSampleRate;           // sound sample rate (i.e., 44100)     声音采样率

*/

/*
	Fast Thin-Film Interference

	This is a performance-optimized version of my previous 
	thin-film interference shader here: https://www.shadertoy.com/view/XddXRj
	This version also fixes a platform-specific bug and has
	a few other tweaks as well.

	Thin-film interference and chromatic dispersion are simulated at
	six different wavelengths and then downsampled to RGB.
*/

// To see just the reflection (no refraction/transmission) uncomment this next line:
//#define REFLECTANCE_ONLY

// performance and raymarching options
#define INTERSECTION_PRECISION 0.01  // raymarcher intersection precision
#define ITERATIONS 20				 // max number of iterations

#define BOUND 6.0					 // cube bounds check
#define DIST_SCALE 0.9   			 // scaling factor for raymarching position update

// optical properties
#define DISPERSION 0.05				 // dispersion amount  分散量
#define IOR 0.9     				 // base IOR value specified as a ratio  猜测: Index of Refraction, 折射率
#define THICKNESS_SCALE 32.0		 // film thickness scaling factor
#define THICKNESS_CUBEMAP_SCALE 0.02  // film thickness cubemap scaling factor
#define REFLECTANCE_SCALE 3.0        // reflectance scaling factor
#define REFLECTANCE_GAMMA_SCALE 2.0  // reflectance gamma scaling factor
#define FRESNEL_RATIO 0.7			 // fresnel weight for reflectance
#define SIGMOID_CONTRAST 8.0         // contrast enhancement

#define TWO_PI 6.28318530718
#define WAVELENGTHS 6				 // number of wavelengths, not a free parameter


// iq's cubemap function
vec3 fancyCube( 
                sampler2D sam, // 一张 噪声图
                in vec3  d, // frag 法线
                in float s, // film thickness cubemap scaling factor; 0.02
                in float b  // 0.0, 猜测是 miplvl
){

    vec3 colx = textureLod( sam, 0.5 + s*d.yz/d.x, b ).xyz;
    vec3 coly = textureLod( sam, 0.5 + s*d.zx/d.y, b ).xyz;
    vec3 colz = textureLod( sam, 0.5 + s*d.xy/d.z, b ).xyz;
    
    vec3 n = d*d;
    
    return (colx*n.x + coly*n.y + colz*n.z) / (n.x+n.y+n.z);
}


// iq's 3D noise function
float hash( float n ){
    return fract(sin(n)*43758.5453);
}

float noise( in vec3 x ) {
    vec3 p = floor(x);
    vec3 f = fract(x);

    f = f*f*(3.0-2.0*f);
    float n = p.x + p.y*57.0 + 113.0*p.z;
    return mix(mix(mix( hash(n+  0.0), hash(n+  1.0),f.x),
                   mix( hash(n+ 57.0), hash(n+ 58.0),f.x),f.y),
               mix(mix( hash(n+113.0), hash(n+114.0),f.x),
                   mix( hash(n+170.0), hash(n+171.0),f.x),f.y),f.z);
}

vec3 noise3(vec3 x) {
	return vec3( noise(x+vec3(123.456,.567,.37)),
				 noise(x+vec3(.11,47.43,19.17)),
				 noise(x) );
}


// a sphere 
// 由于 目标球位于 坐标系原点, 所以, 只要计算 检测点 p 到球面的距离就行了;
float sdf( 
        vec3 p // 检测点
){
	// 3.5 是球体半径;
  
	return length(p) - 3.5;
}




vec3 fresnel( vec3 rd, vec3 norm, vec3 n2 ) {
   vec3 r0 = pow((1.0-n2)/(1.0+n2), vec3(2));
   return r0 + (1. - r0)*pow(clamp(1. + dot(rd, norm), 0.0, 1.0), 5.);
}


// 计算球面点 pos 处的法线;
// 可以无视内容,
vec3 calcNormal( in vec3 pos ){
    const float eps = INTERSECTION_PRECISION; // raymarcher intersection precision, 0.01

    // [-1,1]立方体的 4个顶点, 构成一个 对称四面体;
    const vec3 v1 = vec3( 1.0,-1.0,-1.0);
    const vec3 v2 = vec3(-1.0,-1.0, 1.0);
    const vec3 v3 = vec3(-1.0, 1.0,-1.0);
    const vec3 v4 = vec3( 1.0, 1.0, 1.0);

	return normalize( v1*sdf( pos + v1*eps ) + 
					  v2*sdf( pos + v2*eps ) + 
					  v3*sdf( pos + v3*eps ) + 
					  v4*sdf( pos + v4*eps ) );
}



#define GAMMA_CURVE 50.0
#define GAMMA_SCALE 4.5


vec3 filmic_gamma(vec3 x) {
	return log(GAMMA_CURVE * x + 1.0) / GAMMA_SCALE;    
}


vec3 filmic_gamma_inverse(vec3 y) {
	return (1.0 / GAMMA_CURVE) * (exp(GAMMA_SCALE * y) - 1.0); 
}


// sample weights for the cubemap given a wavelength i
// room for improvement in this function
#define GREEN_WEIGHT 2.8
vec3 texCubeSampleWeights(float i) {
	vec3 w = vec3((1.0 - i) * (1.0 - i), GREEN_WEIGHT * i * (1.0 - i), i * i);
    return w / dot(w, vec3(1.0));
}


vec3 sampleCubeMap(vec3 i, vec3 rd) {
	vec3 col = textureLod(iChannel0, rd * vec3(1.0,-1.0,1.0), 0.0).xyz; 
    return vec3(
        dot(texCubeSampleWeights(i.x), col),
        dot(texCubeSampleWeights(i.y), col),
        dot(texCubeSampleWeights(i.z), col)
    );
}


vec3 sampleCubeMap(vec3 i, vec3 rd0, vec3 rd1, vec3 rd2) {
	vec3 col0 = textureLod(iChannel0, rd0 * vec3(1.0,-1.0,1.0), 0.0).xyz;
    vec3 col1 = textureLod(iChannel0, rd1 * vec3(1.0,-1.0,1.0), 0.0).xyz; 
    vec3 col2 = textureLod(iChannel0, rd2 * vec3(1.0,-1.0,1.0), 0.0).xyz; 
    return vec3(
        dot(texCubeSampleWeights(i.x), col0),
        dot(texCubeSampleWeights(i.y), col1),
        dot(texCubeSampleWeights(i.z), col2)
    );
}



vec3 sampleWeights(float i) {
	return vec3((1.0 - i) * (1.0 - i), GREEN_WEIGHT * i * (1.0 - i), i * i);
}



vec3 resample(
                vec3 wl0, 
                vec3 wl1, 
                vec3 i0, 
                vec3 i1
){
	vec3 w0 = sampleWeights(wl0.x);
    vec3 w1 = sampleWeights(wl0.y);
    vec3 w2 = sampleWeights(wl0.z);
    vec3 w3 = sampleWeights(wl1.x);
    vec3 w4 = sampleWeights(wl1.y);
    vec3 w5 = sampleWeights(wl1.z);
    
    return i0.x * w0 + i0.y * w1 + i0.z * w2
         + i1.x * w3 + i1.y * w4 + i1.z * w5;
}



// downsample to RGB
vec3 resampleColor(
                    vec3[WAVELENGTHS] rds, // 6个值
                    vec3 refl0, // 
                    vec3 refl1, // 
                    vec3 wl0,   // 波长0, 猜测是个颜色值
                    vec3 wl1    // 波长1, 猜测是个颜色值
){

    
    #ifdef REFLECTANCE_ONLY
    	vec3 intensity0 = refl0;
    	vec3 intensity1 = refl1;
    #else
        vec3 cube0 = sampleCubeMap(wl0, rds[0], rds[1], rds[2]);
    	vec3 cube1 = sampleCubeMap(wl1, rds[3], rds[4], rds[5]);
    
        vec3 intensity0 = filmic_gamma_inverse(cube0) + refl0;
    	vec3 intensity1 = filmic_gamma_inverse(cube1) + refl1;
    #endif

    vec3 col = resample(wl0, wl1, intensity0, intensity1);

    return 1.4 * filmic_gamma(col / float(WAVELENGTHS));
}





vec3 resampleColorSimple(vec3 rd, vec3 wl0, vec3 wl1) {
    vec3 cube0 = sampleCubeMap(wl0, rd);
    vec3 cube1 = sampleCubeMap(wl1, rd);
    
    vec3 intensity0 = filmic_gamma_inverse(cube0);
    vec3 intensity1 = filmic_gamma_inverse(cube1);
    vec3 col = resample(wl0, wl1, intensity0, intensity1);

    return 1.4 * filmic_gamma(col / float(WAVELENGTHS));
}


// compute the wavelength/IOR curve values.
vec3 iorCurve(vec3 x) { // 读完
	return x;
}



vec3 attenuation(
            float filmThickness, // 薄膜厚度
            vec3 wavelengths,    // 波长, 猜测为一种颜色
            vec3 normal,         // frag 法线
            vec3 rd              // 射线方向
){
	return 
        0.5 + 
        0.5 * cos(((THICKNESS_SCALE * filmThickness)/(wavelengths + 1.0)) * dot(normal, rd));    
}



vec3 contrast(vec3 x) {
	return 1.0 / (1.0 + exp(-SIGMOID_CONTRAST * (x - 0.5)));    
}



void doCamera(  //  读完
                out vec3 camPos, 
                out vec3 camTar, 
                in float time, 
                in vec4 m // 鼠标信息 xy: 悬空坐标, zw:点击坐标
){
    camTar = vec3(0.0,0.0,0.0); 
    if (max(m.z, m.w) <= 0.0) {
        // 鼠标未点击, 自动生成 camera pos
    	float an = 1.5 + sin(time * 0.05) * 4.0;
		camPos = vec3(6.5*sin(an), 0.0 ,6.5*cos(an));   
    } else {
        // 鼠标点击了, 用鼠标来控制 camera pos
    	float an = 10.0 * m.x - 5.0;
		camPos = vec3(6.5*sin(an),10.0 * m.y - 5.0,6.5*cos(an)); 
    }
}


// 生成 camera 矩阵, z轴+方向 朝向 camera 观察方向;
mat3 calcLookAtMatrix( 
                        in vec3 ro,     // cam Pos
                        in vec3 ta,     // cam Target (0,0,0)
                        in float roll   // 0
){
    vec3 ww = normalize( ta - ro ); // camera->target
    vec3 uu = normalize( cross(ww,vec3(sin(roll),cos(roll),0.0) ) );
    vec3 vv = normalize( cross(uu,ww));
    return mat3( uu, vv, ww );
}



// ======================================== 主函数 ======================================== //


void mainImage( out vec4 fragColor, in vec2 fragCoord )
{

    // 将像素坐标,从原本的 [0,w],[0,h] 先转换为 [-w,w][-h,h] 区间, 然后除以 h
    // 得到 [-w/h, w/h],[-1, 1] 
    vec2 p = (-iResolution.xy + 2.0*fragCoord.xy)/iResolution.y;

    // 鼠标信息, xy: 悬空坐标, zw:点击坐标
    vec4 m = vec4(iMouse.xy/iResolution.xy, iMouse.zw);


    // camera movement
    vec3 ro; // cam Pos
    vec  ta; // cam Target (0,0,0)  世界坐标中心位置;
    doCamera( ro, ta, iTime, m );

    mat3 camMat = calcLookAtMatrix( ro, ta, 0.0 );
    

    float dh = (0.666 / iResolution.y);
    const float rads = TWO_PI;
    
    vec3 col = vec3(0.0);
    
    vec3 wavelengths0 = vec3(1.0, 0.8, 0.6);
    vec3 wavelengths1 = vec3(0.4, 0.2, 0.0);

    // ior: 折射率
    // DISPERSION: 分散量
    vec3 iors0 = IOR + iorCurve(wavelengths0) * DISPERSION;
    vec3 iors1 = IOR + iorCurve(wavelengths1) * DISPERSION;
    

    vec3 rds[WAVELENGTHS]; // 6个

    // ------------------------ 执行主运算 ----------------------------:
    

        vec2 dxy = dh * vec2(cos(float(samp) * rads), sin(float(samp) * rads));

        vec3 rd = normalize(camMat * vec3(p.xy + dxy, 1.5)); // 1.5 is the lens length

		vec3 pos = ro; // 从 camera pos 开始出发
        bool hit = false;


        for (int j = 0; j < ITERATIONS; j++) {// 步进很多次

            float t = DIST_SCALE * sdf(pos);
            pos += t * rd;
            hit = t < INTERSECTION_PRECISION;
            if ( clamp(pos, -BOUND, BOUND) != pos || hit ) {
                break;    
            }
        }

        // 现在, pos 位于 目标球球面;
        // hit 表示是否命中;
        
        if (hit) {


            vec3 normal = calcNormal(pos);// 计算 pos 位置的 法线;

            // 计算 薄膜厚度值;
            float filmThickness = fancyCube(
                iChannel1,  // 一张 噪声图
                normal,     // frag 法线
                THICKNESS_CUBEMAP_SCALE, // film thickness cubemap scaling factor; 0.02
                0.0         //
            ).x + 0.1;


            vec3 att0 = attenuation(filmThickness, wavelengths0, normal, rd);
            vec3 att1 = attenuation(filmThickness, wavelengths1, normal, rd);
            //vec3 att0 = vec3( 0.0, 0.0, 0.0 );
            //vec3 att1 = vec3( 0.0, 0.0, 0.0 );


            vec3 f0 = (1.0 - FRESNEL_RATIO) + FRESNEL_RATIO * fresnel(rd, normal, 1.0 / iors0);
            vec3 f1 = (1.0 - FRESNEL_RATIO) + FRESNEL_RATIO * fresnel(rd, normal, 1.0 / iors1);


            vec3 rrd = reflect(rd, normal); // 观察射线打在球面上, 获得的 反射向量


            vec3 cube0 = REFLECTANCE_GAMMA_SCALE * att0 * sampleCubeMap(wavelengths0, rrd);
            vec3 cube1 = REFLECTANCE_GAMMA_SCALE * att1 * sampleCubeMap(wavelengths1, rrd);
            //vec3 cube0 = vec3( 0.0, 0.0, 0.0 );
            //vec3 cube1 = vec3( 0.0, 0.0, 0.0 );


            vec3 refl0 = REFLECTANCE_SCALE * filmic_gamma_inverse(mix(vec3(0), cube0, f0));
            vec3 refl1 = REFLECTANCE_SCALE * filmic_gamma_inverse(mix(vec3(0), cube1, f1));


            rds[0] = refract(rd, normal, iors0.x);
            rds[1] = refract(rd, normal, iors0.y);
            rds[2] = refract(rd, normal, iors0.z);
            rds[3] = refract(rd, normal, iors1.x);
            rds[4] = refract(rd, normal, iors1.y);
            rds[5] = refract(rd, normal, iors1.z);


            col += resampleColor(rds, refl0, refl1, wavelengths0, wavelengths1);


        } else {
        	col += resampleColorSimple(rd, wavelengths0, wavelengths1);    
        }


	   
    fragColor = vec4( contrast(col), 1.0 );
}
