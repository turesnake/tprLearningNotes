# ================================================================//
#               15 Deferred Lights
# ================================================================//


# ================================ #
# Light Cookie
    就是给 光源 遮罩上一层 蒙版, 让光产生图案;


# ++++++++++++++++++++++++++++++++++++++++++++++ #
#          各种零碎的 源码值, 宏 的分析   (11.0 版)
# ---------------------------------------------- #

# ------------------------------:
# 宏集合: multi_compile_lightpass
    包含:
    POINT DIRECTIONAL SPOT POINT_COOKIE DIRECTIONAL_COOKIE 
    SHADOWS_DEPTH SHADOWS_SCREEN SHADOWS_CUBE SHADOWS_SOFT SHADOWS_SHADOWMASK 
    LIGHTMAP_SHADOW_MIXING. 

    包含了实时光照和阴影的 各种 keywords, 但没包含 light probes
    

# ------------------------------:
# unity_WorldToLight

    这是个 float4x4 矩阵, 能将 posWS 转换到 posLightSpace;

    注意, 平行光的 light-space 是正交投影空间, 使用此函数没啥特殊要求;

    spot光的 light-space 却不是正交投影空间, 因为需要在 spot light-space 
    中绘制一个 金字塔形的 3d模型, 且这个 模型 是要位于透视空间中的
    (和 ws 中的其它模型一样的 透视空间)
    
    此时需如下操作:    

        float4 uvCookie = mul(unity_WorldToLight, float4(posWS, 1));
		uvCookie.xy /= uvCookie.w;

    第一步结束时, uvCookie 还只是一个 "齐次 pos Light-Space";
    需要执行 除w 操作后, xy分量才变成可用的 uv值;
    (然后去采样 light cookie 之类的...)

    
















































