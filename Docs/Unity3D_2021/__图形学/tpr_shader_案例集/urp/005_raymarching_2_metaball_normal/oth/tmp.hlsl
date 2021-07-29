// Metaball
// 教程解读:
// https://medium.com/@avseoul/ray-marching-metaball-in-unity3d-fc6f83766c5d



// ------------------------------------ //
// bounding sphere: "边界范围球" 纯粹的球，用 pos 和 半径定义
// metaball: 一个不定形的有机体，具备多变的表面
//     通常，metaball 的边界，会小于单纯的 bounding sphere 的边界



// f(x) = 6*X^5 - 15*X^4 + 10*X^3
// 
// 一个得到广泛应用的 差值平滑曲线函数
// 最早是由 Ken Perlin 提出的，用来在生成 Simplex Noise 时，获得更平滑的曲线
// 这个函数有个特点：f(0)=0; f(1)=1; f'(0)=0, f'(1)=0
// 这意味着，当 x 位于 0 和 1 处时，f(x)的 导数是0，它趋于一条水平线
// 这使得它能 平缓地将 节点的左右侧曲线段 连接起来
// 它比原来的曲线 3*X^2-2*X^3; 在 0，1 位置更加平滑
// --
// 而且这个函数是对称的（对称点位于 f(0.5) 处）
// f'(0.5) = 15/8





vec4 blobs[numballs];

// 最重要的函数 !!!!
// param: pos: frag pos
float sdMetaBalls( vec3 pos )
{
    // 表示 ray point 在几个 bounding sphere 体内
    float m = 0.0;
    float p = 0.0;// 累计所有 metaball 的衰减值

    // frag 到 所有 bounding sphere 的边界的 最近距离
    float dmin = 1e20; // init with inf+

    // track Lipschitz constant
    // The h is the weight for metaball’s falloff: metaball 衰减的权重值
    // and it also scales normalized distance back to world coordinates
    // [1, inf+]
    float h = 1.0; 

 
    for( int i=0; i<numballs; i++ ){

        // bounding sphere for ball
        float db = length( blobs[i].xyz - pos );// 绝对距离值 pix
        if( db < blobs[i].w ){
            // frag 在某个 bounding sphere 体内
            // do metaball field calculation

            // 以半径为单位的 距离值 [0,1]
            float x = db/blobs[i].w;

            // inverted polynomial equation
            // f(x) = 6*X^5 - 15*X^4 + 10*X^3; (见文件首注释)
            p += 1.0 - x*x*x*(x*(x*6.0-15.0)+10.0);
            m += 1.0;

            // 0.5333 是什么？
            // 平滑函数 f(x) = 6*X^5 - 15*X^4 + 10*X^3; [0,1] 在 x=0.5 处的 导数是 15/8
            // 将这个值 取反: 1/(15/8) = 8/15 = 0.5333;
            // Therefore the minimum distance to a metaball (in metaball canonical coordinates) 
            // is at least 8/15 = 0.533333
            // 所以，在 metaball 正则坐标系中，8/15 就是 到 metaball 的最小距离
            // 不明白其用途
            h = max( h, 0.5333*blobs[i].w );


        }else{
            // frag 在某个 bounding sphere 体外

            // bouncing sphere distance
            dmin = min( dmin, db-blobs[i].w );
        }
    }

    // add just big enough to push the ray into the blob 
    // when the ray hit the bounding sphere.
    // ---
    // 如果不加这个额外值，ray point 很可能在数次 marching 后，停留在 
    // bounding sphere 的边界上，这不是我们想要的
    // 我们想让 ray point 彻底进入 圆球 的体内
    // ---
    // 如果没有这一步，就不可能有上方 "db < blobs[i].w" 这个情况的出现
    // ---
    // 此行代码 仅对 没有进入任何 bounding spheres 的 ray point 有效
    // 如果它已经在体内里，则 变量 d 会在下面代码中被复写（使此行失效）
    float d = dmin + 0.1;
 
    // 只要 ray point 在至少一个 bounding sphere 体内，此段被触发
    if( m>0.5 ){ 
        // threshold，会将 metaball 的视觉边界，收缩为 (bounding sphere raius - th) 这个值
        float th = 0.2; 

        // 计算 frag 到 metaball 表面 的距离值
        // 当 p>0.2, 将算出 负数，即：frag 已经位于 metaball 体内（此负数 会被层层返回上去）
        // 当 p<0.2, 就意味着 ray point 已经离 metaball 表面 越来越近了
        // ---
        // h 用来修正这个值（只能放大）: scales normalized distance back to world coordinates
        d = h*(th-p);
    }
 
    // return the updated distance for the next marching step 
    return d;
}





// Distance Field function. it's also called Distance Map or Distance Transform 
float map( in vec3 p )
{
    return sdMetaBalls( p );
}



// A small number that you want to use to 
// decide if the ray is close enough to surface.
const float precis = 0.01;
// ro - ray_origin
// rd - ray_direction
vec2 intersect( in vec3 ro, in vec3 rd )
{
    // Maximum distance
    // - if the ray go further than this, we'll assume there's nothing
    float maxd = 10.0;

    // Marching step size from the distance field
    // - the closest distance between the current ray position and surface    
    float h = precis * 2.0;

    // Total travel distance of the ray 
    // - the distance between ray origin and surface
    float t = 0.0;

    // This is a bit mysterious to me.. based on the code it only tells whether the ray 
    // is out of the max or not. Maybe there's other usages in specific case but not in this example?
    float m = 1.0;
    
    // How many steps of marching - the more you iterate, 
    // the more precision you will have. But also the more computation cost.   
    for( int i = 0; i < 75; i++ )
    {
        // When the ray is close enough to the surface or the total travel distance 
        // is bigger than maximum distance then break the loop
        if( h < precis || t > maxd ) break;

        // Update the total travel distance with the updated marching distance from previous loop
        t += h;

        // Update the marching distance from the distance field 
        // ro + rd * t - current position of your ray 
        // map(ray) - return the closest distance between the ray and the the scene
        // h 值有可能是负值，表示 此时 frag 就在 metaball 体内
        // 且此时的 负h，并不会被累加到 t 上，这意味着，t还是会保持那个 让 frag 进入metaball 体内 的位置（是否会影响法线的计算???）
        h = map( ro + rd * t );
    }

    // update m if the ray travels further than the maximum distance. 
    // This value will be used to decide whether we render background or metaball in this example 
    if( t > maxd ) 
        m = -1.0;
       
    return vec2( t, m );
}







