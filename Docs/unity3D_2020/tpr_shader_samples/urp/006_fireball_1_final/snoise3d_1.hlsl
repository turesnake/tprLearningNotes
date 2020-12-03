// 
// 计算各种 perlin noise
// 并不是性能最好的 实现，只是比较好理解
// 


// ----------------------------------- // 
//     手动计算 随机值，暂用版本
// ----------------------------------- // 

// 通过此函数，可以获得 正确的 snoise
// 可以简单理解为，为任意一个点p，生成一组随机值 float3 [-1,1]
// 应该没有 normalized
float3 hash_0( float3 p ) // replace this by something better. really. do
{
	p = float3( dot(p,float3(127.1,311.7, 74.7)),
			    dot(p,float3(269.5,183.3,246.1)),
			    dot(p,float3(113.5,271.9,124.6)));

	return -1.0 + 2.0*frac(sin(p)*43758.5453123); // [-1,1]
}


// gradient noise
// ret [-1, 1] 仅检测得知，不完全保证
float gradientNoise3D( float3 pos_ ){

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



// gradient noise
// ret.x:    noise value [-1, 1] 仅检测得知，不完全保证
// ret.yzw:  normal dir
float4 gradientNoise3D_with_normal( float3 pos_ ){

    float3 p = floor( pos_ );
    float3 w = frac(  pos_ ); // 就算参数是负数，也运行正常

    float3 u = w*w*w*(w*(w*6.0-15.0)+10.0);
    float3 du = 30.0*w*w*(w*(w-2.0)+1.0);

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
    float v = va + 
           u.x*(vb-va) + 
           u.y*(vc-va) + 
           u.z*(ve-va) + 
           u.x*u.y*(va-vb-vc+vd) + 
           u.y*u.z*(va-vc-ve+vg) + 
           u.z*u.x*(va-vb-ve+vf) + 
           u.x*u.y*u.z*(-va+vb+vc-vd+ve-vf-vg+vh);

    float3 d = ga + 
            u.x*(gb-ga) + 
            u.y*(gc-ga) + 
            u.z*(ge-ga) + 
            u.x*u.y*(ga-gb-gc+gd) + 
            u.y*u.z*(ga-gc-ge+gg) + 
            u.z*u.x*(ga-gb-ge+gf) + 
            u.x*u.y*u.z*(-ga+gb+gc-gd+ge-gf-gg+gh) +   
             
            du * (float3(vb-va,vc-va,ve-va) + 
                u.yzx*float3(va-vb-vc+vd,va-vc-ve+vg,va-vb-ve+vf) + 
                u.zxy*float3(va-vb-ve+vf,va-vb-vc+vd,va-vc-ve+vg) + 
                u.yzx*u.zxy*(-va+vb+vc-vd+ve-vf-vg+vh) );

    return float4( v, d.xyz ); 
}


