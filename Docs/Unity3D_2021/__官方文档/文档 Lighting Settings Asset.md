# ================================================================ #
#   Lighting Settings Asset
# ================================================================ #


... 未翻译...


# ---------------------------------- #
# Realtime Lighting

此部分和 Enlighten 相关,已废弃


# ---------------------------------- #
# Mixed Lighting

此部分包含的设置, 和 Baked Lights 和 Mixed Lights 相关. 

# -- Baked Global Illumination
    若被启用, unity 开始使用 烘焙的GI系统.
    此时, 被设为 Baked 的光源, 将把自己的 直射光,间接光 全部写入 lightmap 中.
    被设为 Mixed 的光源, 其具体行为受到下方 Lighting Mode 设置的影响. 

    若被关闭, 则被设置为 Baked, Mixed 的光源, 统统被强制看作 Realtime 光源. 

# -- Lighting Mode
    影响所有被设置为 Mixed 的光源 的行为.
    (每次修改此值, 都要重新烘培)

    可选项:

    == Baked Indirect:
        对所有 Mixed 光源, 启用: Baked Indirect Lighting Mode 

    == Subtractive:
        对所有 Mixed 光源, 启用: Subtractive Lighting Mode 
        (此模式在 HDRP 中不被支持)

    == Shadowmask:
        对所有 Mixed 光源, 启用: Shadowmask Lighting Mode 
        (此模式在 URP 中不被支持)


# ---------------------------------- #
# Lightmapping Settings
略

...未完...


# ================================================================ #
#   Lighting Mode
# ================================================================ #




# ================================================================ #
#   Lighting Mode: Baked Indirect
# ================================================================ #
只对场景中的 Mixed 光源起作用.

# Render pipeline support
全支持

# Mixed Light behavior

== 动态物体 (被 Mixed 光照到)
    -- 
        直接光照 被实时生成
    -- 
        间接光照 被烘焙进 LightProbe
    -- 
        动态物体投射出的阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达
    -- 
        静态物体投射出的实时阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达

== 静态物体 (被 Mixed 光照到)
    -- 
        直接光照 被实时生成
    --
        间接光照 被烘焙进 Lightmap  
    --
        静态物体投射出的实时阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达
    -- 
        动态物体投射出的实时阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达


# Setting your Scene’s Lighting Mode to Baked Indirect 
略

# Shadows and runtime performance
在 Baked Indirect Lighting Mode 中, 所有源自 Mixed 光源的 阴影, 统统为 实时阴影. 

这会影响性能.  可通过适当缩小 Shadow Distance 值, 来让 cascade shadow 的实现范围变小, 来提高性能.

# Changing Light properties at runtime
在 Baked Indirect Lighting Mode 中, 你可以轻微的在运行时 修改 Mixed 光源的配置.  对于直接光照部分, 这些细微的改变会体现出来. 对于间接光照部分, 这些细微的改变不会体现(因为被烘焙死了) 

这允许你同时享受 "稍微有点动态性" 的直接光照 和 烘焙提供的间接光照.
毕竟, Baked Indirect Lighting Mode 中的阴影 统统是 实时生成的. 

但是, 这种改动必须是细微的.  比如:
-- 不推荐在运行时, 把光源的颜色 从红色改成绿色. 
-- 不要在运行时, 移动 mixed 光源. (毕竟间接光信息已经被写死了)



# ================================================================ #
#   Lighting Mode: Shadowmask
# ================================================================ #
只对场景中的 Mixed 光源起作用.


在阴影部分 和 Baked Indirect Lighting Mode 存在差异:
Shadowmask Lighting Mode 允许 unity 在运行时结合使用: 烘焙阴影 和 实时阴影.
也支持在远超 Shaodw Distance 的距离上表现出阴影. 

它是通过:
    -- 一张额外的 lightmap texture (被命名为 shadow mask)
    -- 一份额外的 Light Probe (存储了 occlusion 信息)
    -- 额外的 LPPVs (存储了 occlusion 信息)
来实现额.

在所有的 Lighting Modes 中, Shadowmask Lighting Mode 提供了保真度最高的 阴影效果. 但同时 它的 性能成本 和 存储要求 也是最高的. 

它适用于以下场合: 开放世界, 可看到远处的物体(进而需要它们的阴影), 运行在 高端中端设备上. 

# ================================================== #
# Render pipeline support
-- built-in 支持. 
    在只支持 4 个 render targets 的设备上(移动平台), Shadowmask Lighting Mode 会强制 unity 使用 forward rendering. 

-- URP 10.1 以及之后的版本 支持.

-- HDRP 支持. 还对 per-light basis 提供了额外的功能.
    查看:
    https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest/index.html?subfolder=/manual/Shadows-in-HDRP.html%23shadowmasks


# ================================================== #
# Mixed Light behavior

# ------------------------------ #
# -- With the Distance Shadowmask quality setting
若将 Project Settings - Quality - shadowmask Mode 
设置为: Distance Shadowmask

Mixed 光源的行为如下:

# == 动态物体 (被 Mixed 光源照亮)
    -- 
        直接光照 被实时生成
    --
        间接光照 被烘焙进 LightProbe
    -- 
        动态物体投射出的实时阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达
#   -- 
        静态物体投射出的实时阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达
#   -- 
        静态物体投射的 烘焙阴影, 
        在 shadow distance 范围之外, 
        使用 light Probe(occlusion) 来实现

    === 总结: ===
    只在 有限范围内接收 由动态物体 投射的阴影
    可在 全局范围内接收 由静态物体 投射的阴影 
        ( shadowmap + light Probe(occlusion) )


# == 静态物体 (被 Mixed 光源照亮)
    -- 
        直接光照 被实时生成
    --
        间接光照 被烘焙进 Lightmap
    -- 
        动态物体投射出的实时阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达 
#   --
        静态物体投射出的实时阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达
#   -- 
        静态物体投射的 烘焙阴影, 
        在 shadow distance 范围之外, 
        使用 lightmap( shadowMask ) 来实现

    === 总结: ===
    只在 有限范围内接收 由动态物体 投射的阴影
    可在 全局范围内接收 由静态物体 投射的阴影 
        ( shadowmap + lightmap( shadowMask ) )


# ------------------------------ #
# With the Shadowmask quality setting
若将 Project Settings - Quality - shadowmask Mode 
设置为: Shadowmask

Mixed 光源的行为如下:

# == 动态物体 (被 Mixed 光源照亮)
    -- 
        直接光照 被实时生成
    --
        间接光照 被烘焙进 LightProbe
    -- 
        动态物体投射出的 实时阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达
#   -- 
        静态物体投射的 烘焙阴影, 
        在任意范围内  (shadow distance 范围以内和以外) 
        全由 light Probe(occlusion) 来实现

    === 总结: ===
    只在 有限范围内接收 由动态物体 投射的阴影
    可在 全局范围内接收 由静态物体 投射的阴影 
        ( 仅使用 light Probe(occlusion) )


# == 静态物体 (被 Mixed 光源照亮)
    -- 
        直接光照 被实时生成
    --
        间接光照 被烘焙进 Lightmap  
    -- 
        动态物体投射出的实时阴影, 
        在 shadow distance 范围内, 使用 shadowmap 来表达
#   -- 
        静态物体投射的 烘焙阴影, 
        在任意范围内  (shadow distance 范围以内和以外) 
        全由 lightmap( shadowMask ) 来实现

    === 总结: ===
    只在 有限范围内接收 由动态物体 投射的阴影
    可在 全局范围内接收 由静态物体 投射的阴影 
        ( 仅使用 lightmap( shadowMask ) )


# catlike注:
相比于 "Distance Shadowmask",  "Shadowmask" 模式 选择尽可能的用 烘焙阴影 取代 实时阴影.
有效提高了性能. 

相应的代价就是, 近处的 静态物体投射的阴影, 质量比较差. (毕竟 lightmap(shadowmask) 分辨率有限)

问题: 在后者模式中, 静态物体还会被写入 shadowmap 吗 ? 





# ================================================== #
# Setting your Scene’s Lighting Mode to Shadowmask
略

# ================================================== #
# Shadows and runtime performance
Shadow Distance 以内的阴影 都是实时生成的, 以外的则是 烘焙生产的.
可调节此值 来节省运算开销.

tpr注:
不过 shadow distance 以外的区域, 也只支持 静态物体投射的阴影. 
替代能力还是很有限的. 


# ================================================== #
# Shadowmask implementation details
在运行时, unity 使用 shadow mask 来确认, 一个 pix/frag 是否在阴影中. 
shadow mask texture 包含了 遮蔽信息.
它的 UV布局, 它的分辨率, 和姊妹 texture: lightmap 是一样的. 

针对单个 texel, shadow mask 最多能存储 4个 光的信息, 分别存储在 RGBA 4个通道中. (我们通常只存储一个光源的, 所以只写入了 R 通道)

如果要记录的光源数量超过了 4 个, 多出来的光源会从 Mixed 模式被修改为 Baked 模式 !!!! 
    (也就是说, 它的光照信息(直接+间接), 阴影信息 都会被完全烘焙)

light Probe(occlusion) 在这方面 和 lightmap(shadowmask) 保持一致.

# tpr注: !!!!!!!!!
    但这里要注意, 按照文档描述:
    如果场景中存在 无数个 mixed光源, 且每个光源的 影响范围是相互不重叠的(不 overlap), 那么这所有 mixed 光源的 阴影信息, 可以被写入 单独一张 lightmap(shadowmask) 中 !
    ---
    就算存在少量重叠(overlap), 也是允许的, 比如 lightmap(shadowmask) 中的一个 texel, 最多能允许 4个 mixed 光源 照射到它. 然后把这 4个光的 阴影信息,按照 RGBA 记录到 texel 中. (如果重叠的更多, 多出来的 光源会被强行修改为 Baked 模式)
    ---
    所以理论上, 只要保证 mixed 光源之间尽可能不重叠, 一个 GameObj 上是能受到 10 栈不同的 mixed 光源的 阴影影响的. 
    ===
    以上同理于 light Probe(occlusion)


# ================================================================ #
#   Lighting Mode: Subtractive
# ================================================================ #
只对场景中的 Mixed 光源起作用.

在 Subtractive Lighting Mode 中, 所有 mixed 光源 对 直接光照 和 间接光照 都做了烘焙. 
unity 将 静态物体投射的阴影 全部烘焙进了 lightmap. (不管在什么距离)
然后, 使用 一个 主平行光, 向场景中的动态物体 提供 实时阴影. 

# tpr注:
    在这里, 静态物体投射的阴影, 不是烘焙进 shadowMask 中, 而是烘焙进了
    lightmap. 这些阴影信息, 已经和 间接光,直接光 信息混合到一起了.

由于 阴影被混入了 lightmap, 此模式中, unity 无法精确德混合 烘焙阴影 和 实时阴影. 相反, 在这个混合过程中, unity 提供一种 Realtime Shadow Color, 以降低 lightmap 的贡献, 从而因造成 看似正确的 混合假象. 

你甚至可以认为调整这个值, 来实现一些特殊效果

Subtractive Lighting Mode 可用于低性能平台. 此时, 你只需要一个能投射阴影的 实时光(平行光).  它无法提供非常真实的光照效果, 但很适用于 非真实渲染, 比如: cel shading.

# ========================================= #
# Render pipeline support
其它平台支持, HDRP 不支持


# ========================================= #
# Mixed Light behavior

Mixed 光源的行为如下:

# == 动态物体 (被 Mixed 光源照亮)
    -- 
        直接光照 被实时生成
    --
        间接光照 被烘焙进 LightProbe
    -- 
        动态物体投射出的 实时阴影, (主平行光 照出来的)
        在 shadow distance 范围内, 使用 shadowmap 来表达
   -- 
        静态物体投射的 阴影, 
        在任意范围内  (shadow distance 范围以内和以外) 
        全由 light Probe(occlusion) 来实现

    === 总结: ===
    


# == 静态物体 (被 Mixed 光源照亮)
    -- 
        直接光照 被烘焙进 lightmap
    --
        间接光照 被烘焙进 lightmap 
    -- 
        静态物体投射的阴影, 被烘焙进 lightmap 
    -- 
        动态物体投射出的 实时阴影, (主平行光 照出来的)
        在 shadow distance 范围内, 使用 shadowmap 来表达

    === 总结: ===
    

# ========================================= #
# Setting your Scene’s Lighting Mode to Subtractive
略


# ========================================= #
# Changing the shadow color
在 Lighting 窗口中, 修改 Realtime Shadow Color 属性. 


# ========================================= #
# The Main Directional Light
unity 自动将场景中, intensity 值最高的 平行光, 设置为 主平行光. 





