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


# 宏函数: UNITY_CALC_FOG_FACTOR_RAW(coord);
    存在 liner, exp, exp2 三种版本;

    此宏会新建并计算一个变量: float unityFogFactor;
    三个版本的原理:
        factor = (end-z)/(end-start) = z * (-1/(end-start)) + (end/(end-start))
        factor = exp(-density*z)
        factor = exp(-(density*z)^2)

    此返回值边界未受限, 需人为clamp为:[0,1], 仍表示衰减值, 1表示光线全通过, 无烟雾

# float4 unity_FogParams;
    // x = density / sqrt(ln(2)),   useful for Exp2 mode
    // y = density / ln(2),         useful for Exp mode
    // z = -1/(end-start),          useful for Linear mode
    // w = end/(end-start),         useful for Linear mode


...

