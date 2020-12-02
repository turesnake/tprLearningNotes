// Fireball Base 0.1
// --------------------------
// 将所有不相干代码精简后的 最最基础版
// --------------------------
// 核心技术:
//    raymarching
//    sdf
//    noise 3D
// 
// --------------------------
// =1= 
//    为什么 火球表面的火焰，存在体积感
//    ---
//    这种体积感是假的，代码只实现了 "一部分" 体积感觉。
//    这使得 火焰的体积感忽隐忽现，且随着位移其形状也发生变化，适合表现火焰，但不太适合表现其它物质
// =2=
//    为什么 火球边界处，存在细碎的 扰动
//    ---
//    通过一个简单的 threshold 实现，当此功能关闭，将渲染一个 几乎完整的火球
// ----------
// 实现步骤:
// -1- 从 camera 出发，沿着 rd 发生一根射线，
//     检测它与 火球外壳球 是否相交，剔除掉不相交的部分 
// 
// -2- 以 ray 与 外壳球 的交点，作为新的 ro，继续沿着 rd 方向，做 raymarching
//     在 raymarching 每一回合:
//        计算 当前点 P，与 innsphere 的 最短距离 len; (由于 P 一定在 innsphere 体外，此值必[0,+inf])
//        计算 当前点 P 采样的 noise3d 值，（此值被约束到区间 [0，1]）
//        distance = len - noise;
//     ---
//     这个值 其实很玄学，它代表的只是一种近似的，含糊的 距离值。
//     以此值作为 raymarching 的退出关键：当 distance 足够接近 0 时退出
//     ---
//     同时保留最后一次采样的 noise 值，用它来计算 frag 的最终颜色   
// ---------
// 整个程序 最核心的就是 distance 和 noise 两个值
// 用这种方式 marching 出来的 mesh表面 具备琢磨不透的形状，它随着 viewDir, 自身运动 而发生改变
// ----------
//  Clip 
//  观察图: imgs/fireball_isClip.jpg
//  假设 raymarch() 的最后不执行 clip 操作，而是无脑根据 noise 生成 color
//  最终会以 outsphere 为mesh，渲染一个大球
//  它上面的每个 frag，代表的并不是 sphere 表面的 颜色值，而是一个 深入 outsphere 内部的点的 值
//  使用 clip 则可以切割出一个 更有说服力的边界，变成一个立体感足够强的 ball
//  尽管这种 立体感也是 不定形的。
 


const static float Radius_inn = 1.0;
const static float fireHeight = 1.0;

// 和传统的 raymarching 不同，此程序中的 marching 次数，将直接影响 火球的最终形状
// 所以不是越多次就越好
static const int MaxRaymarchingTimes = 4; //4


// 火球的 4级 颜色 
static const float3 Color1 = float3( 1, 1, 1 );
static const float3 Color2 = float3( 1.0, 0.8, 0.2 );
static const float3 Color3 = float3( 1.0, 0.03, 0.0 );
static const float3 Color4 = float3( 0.4, 0.02, 0.02 );



// 上色
float3 Shade( float noise ){

	float c1 = saturate(noise*5.0 + 0.5);
	float c2 = saturate(noise*5.0);
	float c3 = saturate(noise*3.4 - 0.5);
	
	float3 a = lerp(Color1,Color2, c1);
	float3 b = lerp(a,     Color3, c2);
	return 	   lerp(b,     Color4, c3);
}



// 计算 pos 与 innSphere 的 sdf 值
float InnSphereDist( float3 hitPos_to_center )
{
	return length(hitPos_to_center) - Radius_inn;
}


// ret: is hit sphere
bool IntersectSphere(   float3  ro, 
                        float3  rd, 
                        float3  pos, // 火球 pos 被设为 (0,0,0)
                        //float   radius_out, // 火球外层球 的半径
                        out float3 intersectPoint // 
){

    float radius_out = Radius_inn + fireHeight;

    // 解 二元一次方程, 精简版
    // b = 2h; 用 h 替代 b，从而精简掉数个 有关数字 2,4 的计算
    float3 CtoA = (ro - pos); //

    float a = dot(rd,rd); // rd^2
    float h = dot(rd,CtoA);
    float c = dot(CtoA,CtoA) - radius_out * radius_out;

    float discriminant2 = h*h - a*c;

    float t = (-h - sqrt(discriminant2)) / a;
    intersectPoint = ro + rd*t;

    return discriminant2 >= 0.0;
}


// ret.x: noise
// ret.y: distance
float2 RenderScene( float3 pos_ ){

    float3 pos = pos_;

    // 让 火焰动起来
    // 这个实现并不完善，当 参数 值非常大时，由于精度有限，小数部分会丢失精度
    // 最终会导致 pos 变成一个彻底的 整数
    // 进而导致 这个动画 不可能无限播放下去
    pos += float3(0.1, -2.7, 0.1)*_Time.y; 

    float noise = gradientNoise3D(pos * 0.9);
	noise = saturate(abs(noise)); // [0,1]

    // 这是造成 火焰存在 立体结构的 关键
    // 注意，此处 sdf 计算的是 pos 与 火球内球 的距离，所以大部分是 正数
	float dist = InnSphereDist(pos_ - _QuadBasePosWS.xyz) - noise; // 最关键的一句 !!!!
		
	return float2( noise, dist );
}



// param:rd: normalize
float4 raymarch( float3 ro, float3 rd ){

    float3 pos = ro;
    float noise;
	float dist;
	
    for( int i=0; i<MaxRaymarchingTimes; i++ ){

		float2 ret = RenderScene( pos );
        noise = ret.x;
        dist = ret.y;

		if(dist < 0.05) break;
		pos += rd * dist;
	}

    // threshold
    // 不影响图形，只影响 sphere 边界的 clip 程度
    // 若小，边界更容易出现碎裂的火焰
    // 若大，边界更完整，更接近球形
    const float th = 0.5; //[0.2, 0.9]
	
	return lerp(
        float4(Shade(noise), 1),    // dist <  th: 绘制真正的颜色 只和 最后一次采样的 noise 值相关
        float4(0.0, 0.0, 0.0, 0.0), // dist >= th: 未命中，clip 
        float(dist >= th) // 二选一开关
    );

}



// ret: final fire color
float4 fireball_main(float3 ro, float3 rd, float3 ballCenter ){

    float3 hitPos;
    float4 color = float4( 0.0, 0.1, 0.3, -1.0 );
    
    if( IntersectSphere(ro, rd, ballCenter, hitPos) ){
        // 获得 ray 与 火球外壳 的 hitpos
        // 从此点出发，再做 raymarching
        color = raymarch( hitPos, rd );
    }

    clip( color.a-0.01 );
    return color;

}




