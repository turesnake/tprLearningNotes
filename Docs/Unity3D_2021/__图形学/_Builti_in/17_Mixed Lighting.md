# ================================================================//
#               17 Mixed Lighting
# ================================================================//



# ++++++++++++++++++++++++++++++++++++++++++++++ #
#          各种零碎的 源码值, 宏 的分析   (11.0 版)
# ---------------------------------------------- #




# ------------------------------:
#  UnitySampleBakedOcclusion(...)
fixed UnitySampleBakedOcclusion (float2 lightmapUV, float3 worldPos);

用于 前向渲染;
采样本frag 所对应的 shadowmask 遮蔽值, 或者 LPPV 遮蔽值;
源码注释说:
    light probe occlusion is done on the CPU by attenuating the light color.
    ---
    已经在 cpu代码中, 通过直接衰减 light color, 来实现 light probe 的遮蔽影响;
    (毕竟, 一个物体只接收一个统一的 light probe 值, )
    (但一个物体的每个 frag, 都可以接收不同的 LPPV 值)




# ------------------------------:
#  UnityGetRawBakedOcclusions(...)

用于 延迟渲染:
生成本 frag 的 遮蔽信息 (shadowmask, 或 LPPV)
以便写入 GBuffer 中;


# ------------------------------:
# fixed4 unity_OcclusionMaskSelector;
是个选择器;
其中只有一个通道有值1, 剩余通道为0, 以此来指示: 本 pass 处理的 光源, 它的 遮蔽信息存储在哪个通道中;


# ------------------------------:
#  UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
如其名字:
如果某个平台的 frag shader 不需要 全尺寸浮点数, 那个这个宏就会被 unity 脚本端 自动启动



# ------------------------------:
#  UnityMixRealtimeAndBakedShadows(...)
half UnityMixRealtimeAndBakedShadows(
    half realtimeShadowAttenuation, // 实时阴影衰减值
    half bakedShadowAttenuation,    // 烘焙阴影衰减值
    half fade                       // shadow fade 
);

    此函数同时支持 前向渲染, 延迟渲染:
    用来混合 实时阴影信息(包含 shadow fade) 和 烘焙阴影信息:

# +++++++++++++++++++++++++++++++++:
# 不同物体再不同模式下, 会开启的宏:

#   // --- Static objects ---:
    // FWD BASE PASS: ( 其实也被用于 延迟渲染的 base pass )
    // ShadowMask mode          = LIGHTMAP_ON + SHADOWS_SHADOWMASK + LIGHTMAP_SHADOW_MIXING
    // Distance shadowmask mode = LIGHTMAP_ON + SHADOWS_SHADOWMASK
    // Subtractive mode         = LIGHTMAP_ON + LIGHTMAP_SHADOW_MIXING
    // Pure realtime direct lit = LIGHTMAP_ON

    // FWD ADD PASS:
    // ShadowMask mode          = SHADOWS_SHADOWMASK + LIGHTMAP_SHADOW_MIXING
    // Distance shadowmask mode = SHADOWS_SHADOWMASK
    // Pure realtime direct lit = LIGHTMAP_ON

    // DEFERRED LIGHTING PASS:
    // ShadowMask mode          = LIGHTMAP_ON + SHADOWS_SHADOWMASK + LIGHTMAP_SHADOW_MIXING
    // Distance shadowmask mode = LIGHTMAP_ON + SHADOWS_SHADOWMASK
    // Pure realtime direct lit = LIGHTMAP_ON


#   // --- Dynamic objects ---:
    // FWD BASE PASS + FWD ADD ASS:
    // ShadowMask mode          = LIGHTMAP_SHADOW_MIXING
    // Distance shadowmask mode = N/A
    // Subtractive mode         = LIGHTMAP_SHADOW_MIXING (only matter for LPPV. Light probes occlusion being done on CPU)
    // Pure realtime direct lit = N/A

    // 之所以没标注 动态物体的 延迟渲染 base pass
    // 也许是因为 动态物体不需要 烘焙数据

    // DEFERRED LIGHTING PASS:
    // ShadowMask mode          = SHADOWS_SHADOWMASK + LIGHTMAP_SHADOW_MIXING
    // Distance shadowmask mode = SHADOWS_SHADOWMASK
    // Pure realtime direct lit = N/A


# ------------------------------:
# 宏: LIGHTMAP_ON
在本 pass 中需要用到 lightmap;
一般出现在:
    前向渲染: 静态物体的 base pass
    延迟渲染: light pass 中

不会出现在 动态物体的 pass 中, 毕竟动态物体无法读取 lightmap 信息;

不会出现在 前向渲染的 add pass 中;


# ------------------------------:
# 宏: SHADOWS_SHADOWMASK
当 Lighting - Lighting Mode 设置为 Shadowmask;
而且本pass 渲染的物体 确实需要用到 shadowmask 数据时;

此时 不管是 ShadowMask mode, 还是 Distance shadowmask mode, 此宏都启动;




