# ================================================================//
#               18 Realtime GI, Probe Volumes, LOD Groups
# ================================================================//



# ------------------------------:
# enlighten 需要 Realtime 模式的光;
虽然也需要预先烘焙, 但是光源类型不能选错;

# ------------------------------:
# light probe 可以自动适配 enlighten


# ------------------------------:
# enlighten 专门针对 平行光
偶尔也能用于 "不开启阴影" 的 point光 和 spot光;
但是如果这两种光开启了 阴影, 你会发现一些错误的现象;
比如光线穿透了物体



# ++++++++++++++++++++++++++++++++++++++++++++++ #
#          各种零碎的 源码值, 宏 的分析   (11.0 版)
# ---------------------------------------------- #


# ------------------------------:
# 宏: DYNAMICLIGHTMAP_ON
表示启用了 enlighten


# ------------------------------:
# unity_DynamicLightmapST


# ------------------------------:
# UnityMetaVertexPosition(...)

float4 UnityMetaVertexPosition( float4 vertex, 
                                float2 uv1,         // for lightmap
                                float2 uv2,         // for enlighten
                                float4 lightmapST, 
                                float4 dynlightmapST // enlighten
                                );

此函数用来计算 meta pass 中的 vertex shader 需要返回的 posCS;
他能同时支持 lightmap 和 enlighten;



# ------------------------------:
# 宏:DIRLIGHTMAP_COMBINED
意味着 ligtmap 启用了 第二张贴图, 专门存储 主光分量方向向量的;

注意, enlighten 也需要写入一张 lightmap, 他也可以启用 第二张贴图





















