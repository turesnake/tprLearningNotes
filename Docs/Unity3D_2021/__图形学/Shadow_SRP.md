# ================================================================//
#                  Shadow SRP
# ================================================================//

其实还残留了部分 built-in 内容, 待整理...

主要内容为 catlike SRP




# ----------------------------------------------#
#          支持几个 shadow ？？？  (Real-Time)  
# ----------------------------------------------#

# in Built-in
    猜测和 具体设置有关:
    -- 主平行光 支持阴影
    -- Pixel Light Count 个次要光支持阴影 (平行,spot,点光源, 都可以)
    -- 剩余的被实现为 逐顶点光(仅点光源) 无阴影
    -- 最后剩余的所有光,被整合为一个球谐光, 无阴影


# in SRP(catlike)
    最多支持 4 个 dirLight shadow

# in URP
    仅支持 一个 dirLight shadow
    -----
    但是支持 额外的 Spot light shadow


# in HDRP
    仅支持 一个 dirLight cascade shadow
    如果 准备两盏 dirLights, 会得到报错：
Cascade Shadow atlasing has failed, only one directional light can cast shadows at a time
    -----
    但是支持 额外的 Spot/Point/Area light shadow
    




# ----------------------------------------------#
#            Shadow Mapping   [更快]
# ----------------------------------------------#
Shadow Mapping 是一种技术，unity 用它来实现 光照投影。

它使用的 texture，叫做 Shadow Map, 有点类似 depty texture.
每一盏灯，生成自己的 Shadow Map，就好比每一个 camera，生成自己的 depty texture。

所以，Shadow Map，是围绕着一盏灯光，而存在的：
Shadow Map 上的每个像素，记载了：沿着这个方向，本光能照射到的第一个 surface 的 距离值

-1- 从 light 出发，生成一张 Shadow Map，记录每个像素的 z-deep 值
-2- 从 camera 出发，针对将要渲染的每个 像素点，转换计算出 它所对应的 light-space pos
    然后拿着这个 pos，去 -1- 中生成的 Shadow Map 中进行查找，
    看是不是 “visible”
    以此来确定，这个 待渲染的像素，是不是在 阴影区

# 精度
Shadow Mapping 的精度受到 Shadow Map 分辨率的限制。
而且，在部分角度，它的精度一定会收到影响


# ----------------------------------------------#
#            Shadow volume     [更精确]
# ----------------------------------------------#
比 Shadow Mapping 更精确的 投影技术，它能精确到 pix。

-1- 从 light 出发，找到 mesh 的整个 轮廓边集合
-2- 沿着 light->vertex 的方向，将轮廓边，朝远方无限延伸
    这将形成一个 类似管道的形状
-3- 给这个形状，人为添加 前截面，和后截面，
    将其封闭成一个类似 平截头体 的三维立体mesh
    （是否要加 前后截面，由实现而定）


# stencil buffer 实现
stencil buffer 为每个像素 提供一个 uinteger 值，具体含义由程序自定义。


# 限制
Shadow volume 需要在 cpu 端生成 shadow geometry，




# ----------------------------------------------#
#        如何收缩 shadow map 的 覆盖区间    
# ----------------------------------------------#
在一些情况下，地面这种不会发出 cast 的obj，应该主动关闭其 shadow cast 设置
    这样，在 shadow map 上，这些直接照射到地面的 像素，就是 全黑的
    （表示在 shadow map 平截头体内，光线未碰撞到任何表面）
    （目前的 unity catlike 实现似乎处理好了这个现象，地面上成功获得了 投影

 
对 shadow 平截头体 far-plane 的收缩处理：
    收集 camera 视野内的所有 shadow receivers，在 sts空间（Shadow-Tile-Space）中
    任何比这些 receivers 更远的 casters，都不可能再影响到它们。
    所以，这些 sts空间内，远处的 caster（它们可能仍在 camera 视野内）也是可以被 cull 掉的

类似的还有对 shadow 平截头体 near-plane 的收缩处理
    ...

- 尽可能地压缩 near-plane 和 far-plane 之间的间距，就能让 z-depth 值本身更精确




# ----------------------------------------------#
#               Cascade
# ----------------------------------------------#
Cascade 是一项主要针对 directional light 的技术。

在 unity 中，如果 某一级的 区间里没有mesh，那么这一级对应的 
shadow map tile 压根就不会被渲染，而是保持原来的 纯黑色。

unity 自动实现了 Cascade 功能，我们只要向:
    ComputeDirectionalShadowMatricesAndCullingPrimitives()
函数中输入 合适的参数，就能获得需要的 数据。


unity 使用数个围绕 camera 的 culling spheres 来实现 Cascade 功能。
这些 culling spheres 和 directional light 是无关的，
所以，不管 directional light 的方向朝向何处，这些 culling spheres 都不会为此而发生变化。


# Cascade Ratio
通过三个 ratio 值，来控制 4个 cascade 区间的大小（第四个永远覆盖全局）
以第一个 ratio 举例，它覆盖最靠近camera 的区间
当此 ratio 变小时，cascade 区间面积变小了，但 shadow map 的采样精度却提高了！！！

这意味着，通过缩小 ratio，尽可能地缩小 前三个 cascade 区间的大小，

另一方面，通过调节 shadow Max Distance 来缩小 投影总范围，
也能提高每片 shadow map 的采样精度



# ----------------------------------------------#
#          constant depth bias
#          normal bias     
# ----------------------------------------------#
在 urp 中，这两个值被定义在： _ShadowBias  中：
    x: depth bias, 
    y: normal bias

它们被函数 ApplyShadowBias() 处理，
这个处理过程是发生在 shadow caster pass 阶段的




# ----------------------------------------------#
#         Shadows.hlsl  分析 
# ----------------------------------------------#


# GetMainLightShadowSamplingData() -> ShadowSamplingData
# GetAdditionalLightShadowSamplingData()s -> ShadowSamplingData
    根据全局变量 _XXX，装配一个 ShadowSamplingData 实例


# GetMainLightShadowParams() -> half4
# GetAdditionalLightShadowParams() -> half4
    获取一个 全局变量值 _XXX
    

# SampleScreenSpaceShadowmap() -> half
    未见 此函数被使用 ...

# SampleShadowmapFiltered() -> real


# SampleShadowmap() -> real
    计算 shadow attenuation 的核心函数

# ComputeCascadeIndex() -> half
    计算 positionWS 当前所在的 culling sphere 的 idx

# TransformWorldToShadowCoord() -> float4
    转换函数

# MainLightRealtimeShadow() -> half
# AdditionalLightRealtimeShadow() -> half
    实时shadow 主函数

# GetShadowCoord() -> float4
    转换函数

# ApplyShadowBias() -> float3
    将 constant bias/ normal bias 作用于一个 positionWS




# ----------------------------------------------#
#       ShadowSamplingTent.hlsl  分析
# ----------------------------------------------#

# SampleShadow_GetTriangleTexelArea

# SampleShadow_GetTexelAreas_Tent_3x3

# SampleShadow_GetTexelWeights_Tent_3x3
# SampleShadow_GetTexelWeights_Tent_5x5
# SampleShadow_GetTexelWeights_Tent_7x7

# SampleShadow_ComputeSamples_Tent_3x3
# SampleShadow_ComputeSamples_Tent_5x5
# SampleShadow_ComputeSamples_Tent_7x7





# ----------------------------------------------#
#              positionSTS  [float4]
#           Shadow-Tile-Space
# ----------------------------------------------#
当 frag 在某个 culling sphere 体内时：
    posSTS.xyz, 推断取值范围在 [0,1]
    posSTS.w = 1f
当 frag 不再任何 culling sphere 体内时：
    posSTS.xyz = (0, 0, posWS.z)
    posSTS.w = 0f

它需要符合 uv坐标系的 规则


float4 posSTS = TransformWorldToShadowCoord( positionWS );
在这个函数中，依赖一个从 cpu 端传来的 矩阵
这个矩阵是由 ComputeDirectionalShadowMatricesAndCullingPrimitives() 自动生成的
(需要做一定程度的 改装)



# ----------------------------------------------#
#              
# ----------------------------------------------#

