# ================================================================//
#               14 Fog
# ================================================================//


fog 的参数在 inspector: Lighting - Environment - Other Settings - Fog 区域被设置;

    共有三种类型: Linear, Exp, Exp2;
    Exp 最逼真,
    Exp2 前景更亮, 且收敛更快 (更快变成烟雾色)


当我们配置了这个区域的参数后, unity 会自动将其写入 shader 端, 我们只需提取特定数据, 然后计算衰减值就行;



# ++++++++++++++++++++++++++++++++++++++++++++++ #
#          各种零碎的 源码值, 宏 的分析   (11.0 版)
# ---------------------------------------------- #


# ------------------------------:
# 宏函数: UNITY_CALC_FOG_FACTOR_RAW(coord);
    存在 liner, exp, exp2 三种版本;

    此宏会新建并计算一个变量: float unityFogFactor;
    三个版本的原理:
        factor = (end-z)/(end-start) = z * (-1/(end-start)) + (end/(end-start))
        factor = exp(-density*z)
        factor = exp(-(density*z)^2)

    此返回值边界未受限, 需人为clamp为:[0,1], 仍表示衰减值, 1表示光线全通过, 无烟雾

# ------------------------------:
# float4 unity_FogParams;
    // x = density / sqrt(ln(2)),   useful for Exp2 mode
    // y = density / ln(2),         useful for Exp mode
    // z = -1/(end-start),          useful for Linear mode
    // w = end/(end-start),         useful for Linear mode


...

# ------------------------------:
# clip-space depth:
    特指在 clip-space 中, 从 frag 到 camera所在平面的距离;
    也就是 z值 差值;
    而不是 frag 到 camera 的距离;


# ------------------------------:
# Graphics.Blit(...)
    复制数据,

void Graphics.Blit( Texture source, RenderTexture dest );
void Blit(Texture source, RenderTexture dest, Material mat);
... 更多版本 ...




# ------------------------------:
# Camera.CalculateFrustumCorners(...);

void CalculateFrustumCorners(
    Rect viewport,  // 选择视窗中的哪一块, 选择整个视窗就写入: x=0,y=0,w=1,h=1
    float z,        // 射线射到的那个平面, 距离camera 的深度值, 比如 far plane 深度值;
    Camera.MonoOrStereoscopicEye eye, //
    Vector3[] outCorners    // out rays
);

此函数自动计算出 4个 rays 方向向量, 从 camera 射向目标平面(比如 far plane) 的四个角落;
平截头体张开的角度则由第一参数: viewport 来控制;

4个 rays 顺序为: bottom-left, top-left, top-right, bottom-right;

# 计算出的 rays, 位于 camera-space;
    假设 viewport 为 (0,0,1,1) 的话( full screen)
    则计算出的 rays 会是类似于:
    
    {
        { -1026.4, -577.4, 1000 },
        { -1026.4,  577.4, 1000 },
        {  1026.4,  577.4, 1000 },
        {  1026.4, -577.4, 1000 }
    }
    FOV = 60度, far depth = 1000; 

    可手工验证上述值;
    ----

    所以, 必须要类加上 camera 的 posWS 和 朝向,
    才能进一步计算出这四个 ray 的 world-space 空间中的表达;

此函数被用于 fog 计算;






