#ifndef TPR_NOISE3D_INCLUDE
#define TPR_NOISE3D_INCLUDE


// ----------------------------------------------------------------------- // 
//  Value Noise 3D 
//  https://www.shadertoy.com/view/4sfGzS
// ----------------------------------------------------------------------- // 
// procedural 版;
// 比下方的 gradientNoise3D() 快了5倍;
// 尽管生成的 噪声质量 很不好, 但在 SoapBubble 一例中够用了;


float hash_1(float3 p)  // replace this by something better
{
    p  = frac( p*0.3183099+.1 );
	p *= 17.0;
    return frac( p.x*p.y*p.z*(p.x+p.y+p.z) );
}

float ValueNoise3D( float3 x )
{
    float3 i = floor(x);
    float3 f = frac(x);
    f = f*f*(3.0-2.0*f);
	
    return lerp(lerp(lerp(  hash_1(i+float3(0,0,0)), 
                            hash_1(i+float3(1,0,0)),f.x),
                   lerp(    hash_1(i+float3(0,1,0)), 
                            hash_1(i+float3(1,1,0)),f.x),f.y),
               lerp(lerp(   hash_1(i+float3(0,0,1)), 
                            hash_1(i+float3(1,0,1)),f.x),
                   lerp(    hash_1(i+float3(0,1,1)), 
                            hash_1(i+float3(1,1,1)),f.x),f.y),f.z);
}




// ----------------------------------------------------------------------- // 
//  Gradient Noise 3D, Derivatives
//  https://www.shadertoy.com/view/4dffRH
// ----------------------------------------------------------------------- // 
// 质量更好的 3d perlin noise, 但是计算成本更高;


// 为任意一个点p，生成一组随机值 float3 [-1,1]
float3 hash_0( float3 p ) // replace this by something better. really. do
{
	p = float3( dot(p,float3(127.1,311.7, 74.7)),
			    dot(p,float3(269.5,183.3,246.1)),
			    dot(p,float3(113.5,271.9,124.6)));
	return -1.0 + 2.0*frac(sin(p)*43758.5453123); // [-1,1]
}


// gradient noise
// ret [-1, 1]
float gradientNoise3D( float3 pos_ ) // return value noise (in x) and its derivatives (in yzw)
{

    float3 p = floor( pos_ );
    float3 w = frac(  pos_ ); // 就算参数是负数，也运行正常

    float3 u = w*w*w*(w*(w*6.0-15.0)+10.0);

    // gradients
    float3 ga = hash_0( p+float3(0.0,0.0,0.0) );
    float3 gb = hash_0( p+float3(1.0,0.0,0.0) );
    float3 gc = hash_0( p+float3(0.0,1.0,0.0) );
    float3 gd = hash_0( p+float3(1.0,1.0,0.0) );
    float3 ge = hash_0( p+float3(0.0,0.0,1.0) );
    float3 gf = hash_0( p+float3(1.0,0.0,1.0) );
    float3 gg = hash_0( p+float3(0.0,1.0,1.0) );
    float3 gh = hash_0( p+float3(1.0,1.0,1.0) );


    // projections
    float va = dot( ga, w-float3(0.0,0.0,0.0) );
    float vb = dot( gb, w-float3(1.0,0.0,0.0) );
    float vc = dot( gc, w-float3(0.0,1.0,0.0) );
    float vd = dot( gd, w-float3(1.0,1.0,0.0) );
    float ve = dot( ge, w-float3(0.0,0.0,1.0) );
    float vf = dot( gf, w-float3(1.0,0.0,1.0) );
    float vg = dot( gg, w-float3(0.0,1.0,1.0) );
    float vh = dot( gh, w-float3(1.0,1.0,1.0) );

    // interpolation
    return va + 
           u.x*(vb-va) + 
           u.y*(vc-va) + 
           u.z*(ve-va) + 
           u.x*u.y*(va-vb-vc+vd) + 
           u.y*u.z*(va-vc-ve+vg) + 
           u.z*u.x*(va-vb-ve+vf) + 
           u.x*u.y*u.z*(-va+vb+vc-vd+ve-vf-vg+vh);
}




#endif 



