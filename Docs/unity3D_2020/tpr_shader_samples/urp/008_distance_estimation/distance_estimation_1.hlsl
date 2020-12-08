// 
// 学习如何 让 sdf 边界线 宽度均匀
// 


// An example on how to compute a distance estimation for an ellipse (which provides
// constant thickness to its boundary). This is achieved by dividing the implicit 
// description by the "modulus of its gradient" (梯度的模，即梯度的长度). 
// The same process can be applied to any
// shape defined by an implicity formula (ellipses, metaballs, fractals, mandelbulbs).
//
// top    left : f(x,y)
// top    right: f(x,y) divided by analytical gradient
// bottom left : f(x,y) divided by numerical GPU gradient
// bottom right: f(x,y) divided by numerical gradient
//
// More info here:
//
// http://www.iquilezles.org/www/articles/distance/distance.htm





// =============== 解释：=============== // 
// 核心原理:
//    对 sdf 函数的返回值 进行修正，从而让最终绘制出来的 等势线 的宽度更加均匀。
//    修正公式:
//               | sdf(pos) |
//    reture  ------------------
//              | 梯度sdf(pos) |
// 
//    鉴于 sdf() 本身返回的就是个 标量，而梯度则是一个向量，此公式等同于:
//               abs( sdf(pos) )
//    reture  -----------------------
//              length( 梯度sdf(pos) )
//
// ---------------
// 针对本示例中，椭圆 的实现
// ===============
// 椭圆的 sdf 方程:
//    sdf(x,y) = sqrt((a*x)^2 + (b*y)^2) - r;
//    
// 此方程的 梯度向量：
//             a^2 * x                      b^2 * y
//   ---------------------------,  ---------------------------
//    sqrt( (a*x)^2 + (b*y)^2 )     sqrt( (a*x)^2 + (b*y)^2 )
//  
// 然后计算 梯度向量的 长度:
//              sqrt( a^4*x^2 + b^4+y^2 )
//  length = ----------------------------------
//              sqrt( (a*x)^2 + (b*y)^2 )
// 
// 最后用上段的 核心公式 计算即可；




// 椭圆固定数据，长短轴
static const float a = 1.0;
static const float b = 3.0;

// set at runtime
float r; // 椭圆半径， [0.8, 1.0]
float e; // eps = 2.0/iResolution.y; 两个pix 的 uv 尺寸



// 最原始直接的 椭圆公式: 
//     f(x,y) = sqrt((a*x)^2 + (b*y)^2) - r;
// inn sdf 值被 abs 为正数了
// 使用这个公式，将获得 不均匀宽度 的线条
// ---
// f(x,y) (top left)
float ellipse1(float2 p)
{
    float f = length( p*float2(a,b) );
    return abs(f-r);
}


// 如果条件允许，解析梯度 当然是最棒的
// f(x,y) divided by analytical gradient (top right)
float ellipse2(float2 p)
{
    // 具体推导 见头部描述
    float f = length( p*float2(a,b) );
    float g = length( p*float2(a*a,b*b) );
    return abs(f-r)*f/g;
    //return f/g;
}



// 依靠 ddx,ddy 实现的不够精确，但足够快的 梯度
// f(x,y) divided by numerical GPU gradient (bottom left)
float ellipse3(float2 p)
{
    float f = ellipse1(p);
    float g = length( float2(ddx(f),ddy(f))/e );
    // 使用 fwidth 的版本似乎更加不精确, 已经无法使用了
    //float g = fwidth(f)/e;
	return f/g;
}


// central differences method，最传统的方法求梯度
// f(x,y) divided by numerical gradient (bottom right)
float ellipse4(float2 p)
{
    float f = ellipse1(p);
    float g = length( float2(ellipse1(p+float2(e,0.0))-ellipse1(p-float2(e,0.0)),
                             ellipse1(p+float2(0.0,e))-ellipse1(p-float2(0.0,e))) )/(2.0*e);
    return f/g;
}





// uvSS 
float4 distance_estimation_main( float2 uvSS ){

    // -------- //
    // 在 [0.8,1.0] 之间震荡
    //r = 0.9 + 0.1*sin(3.1415927*_Time.y);
    r = 0.7;

    // 在下方的 uv 坐标系中， 两个pix 的 uv 尺寸
    e = 2.0 / _ScreenParams.y;


    // 不是非常严格的 [-1,1]区间
    // x: [ - x/y, x/y ]
    // y: [    -1,   1 ]
    float2 uv = uvSS * 2.0 - 1.0;
    uv.x *= ( _ScreenParams.x / _ScreenParams.y );

    
	float f1 = ellipse1(uv);
	float f2 = ellipse2(uv);
	float f3 = ellipse3(uv);
	float f4 = ellipse4(uv);
	

	float3 col = float3(0.2, 0.2, 0.2 );

    // 分别得到 四个区间的 椭圆 sdf 值
    // ellipse  
    float f = lerp( lerp(f1,f2,step(0.0,uv.x)), 
                   lerp(f3,f4,step(0.0,uv.x)), 
                   step(uv.y,0.0) );


    // 仅表示 线的宽度，线的位置是不变的：sdf=0 处
    float thickness = 0.02;
    float thicknessThreshold = 0.01;// 0.01; 值越小，边界越清晰，甚至会出现像素锯齿
    
    
	col = lerp(  float3(1.0,0.8,0.2),  // 黄色
                col,                // 灰色
                smoothstep( thickness, thickness+thicknessThreshold, f ) 
    );
        
    // lines    
	col *= smoothstep( e, 2.0*e, abs(uv.x) );
	col *= smoothstep( e, 2.0*e, abs(uv.y) );

    return float4( col, 1 );

}

