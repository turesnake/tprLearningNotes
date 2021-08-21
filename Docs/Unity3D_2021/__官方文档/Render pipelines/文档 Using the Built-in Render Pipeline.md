# ================================================================ #
#        Using the Built-in Render Pipeline
# ================================================================ #

通过选择不同的 rendering paths，可以配置此管线。
可通过 command buffers 和 callbacks 拓展此管线。

# Rendering （callbacks）
== OnPreCull: 
    在 相机 cull 场景之前调用。

== OnBecameVisible/OnBecameInvisible:
    当个物体，对任何相机 变得 “可见”/“不可见”（即：进入/离开 视野）时调用

== OnWillRenderObject:
    如果一个物体可见，每个相机都会调用此函数一次 ？？？

== OnPreRender:
    在相机开始渲染场景之前

== OnRenderObject: 
    在所有 “regular 场景渲染” 都完成后被调用。
    可在这个时间点调用 GL 类，或 Graphics.DrawMeshNow 来绘制 自定义几何体

== OnPostRender: 
    在相机结束场景渲染后 调用

== OnRenderImage: 
    在场景渲染完成后调用，以允许 针对图像的 post-processing

== OnGUI:
    每一帧调用数次 以响应 GUI 事件。先是 Layout，Repaint 事件。
    然后针对每一个 input event 执行 Layout 和 鼠标/键盘 事件。

== OnDrawGizmos:
    绘制 scene 视窗内的 gizmos（图标）时


# ================================================================ #
#     Rendering paths in the Built-in Render Pipeline
# ================================================================ #
built-in 管线支持数种 rendering paths。
一个 rendering path 是数个 光照和着色操作的 集合。
不同的 rendering path 拥有不同的 能力 和 性能特征。
根据 项目类型，目标平台 来选择适合的 rendering pah

-- 可在 graphic 窗口修改 rendering path：
    - Tier Settings - Low/Mid/High - Rendering Path

-- 也可在每个 camera 中单独设置

如果你选的 rendering path 不被平台支持，unity 会自动选择一个 保真度更低的 rendering path。
比如，如果不支持 Deferred shading，将自动该用 forward rendering


# Forward Rendering
是 built-in 管线 的默认 rendering path。它是一条通用 rendering path。

forward rendering 中的 “实时光源” 是很昂贵的。你可以控制在一个时间点上，多少光源是支持 逐像素渲染的。
剩余的光源 将改用 低保真度：逐顶点，逐物体。

如果你的项目不需要大量的 实时光源，或，如果你对光照的质量不敏感，那么 forward rendering 比较适合你。


# Deferred Shading
它能维持最大程度的 光照和着色 保真度。

它需要 GPU 的支持，并存在一些限制：
-- 它不支持 半透明物体（需要改用 forward rendering），
-- 不支持 正交投影，
-- 不支持 硬件 抗锯齿 （猜测是 MSAA）（当然 可用 post-process 抗锯齿 技术）
-- 对 culling mask 的支持有限
-- 所有物体的 Renderer.receiveShadows 都将被认为是 true
    （receiveShadows：此物体是否 接收阴影 ）

如果你的项目拥有大量 实时光源，需要高质量的光照保真度，目标平台支持 deferred shading，
可选用此 path。


# Legacy Deferred
也叫 light prepass。
和 deferred shading 很相似。不过 legacy deferred 基于不同的权衡，使用了不同的技术。

它不支持 unity 5： pbs shader


# Legacy Vertex Lit
拥有最低 光照保真度，不支持 实时阴影。
它是 forward rendering path 的一个 子集。


# ================================================================ #
#     Forward rendering path
# ================================================================ #
基于 一个物体相关联的 灯光数量，通过 一到多次 pass 渲染这个物体。
基于每个光源的设置和强度，它们被 forward rendering 对待的方式也不一样。

# Implementation Details
一些最亮的 光源 会 逐像素渲染。然后，每个"顶点"(不是像素)最多计算 4个 点光源。剩余的光源被计算为 球谐。
基于以下规则来 调度不同光源：

-- Render Mode 设置为 Not Important 的光源，总是 逐顶点 或 球谐。
-- 最亮的 直射光 总是 逐像素
-- Render Mode 设置为 Important 的光源，总是 逐像素。
-- 按照上述规则，如果获得的 逐像素 光源数量，仍然少于：
    Project Setting - Quality - Rendering - Pixel Light Count 所标记的数量（通常为4）
    那就针对剩余光源，按照亮度高低，将更多光源 选择为 逐像素。


每个对象的渲染如下所示：
-- base pass 实现 一个 逐像素直射光, 以及所有的 逐顶点/球谐光
-- 剩余的 逐像素 光源 在 additional passes 中被实现, 一次 pass 实现一个光源


[参见文档原图: 一组光源:ABCDEFGH 由近及远 围绕在一个物体周围]
假设这些光源属性都相同, render mode 都设为 auto (还有:Important 之类的选项)

此时,最亮的灯会被设置为 逐像素 (A~D)
然后最多 4 个灯设置为 逐顶点 (D~G)
剩余的灯设置为 球谐 (G~H)

注意,上述三个集合间存在覆盖关系(比如 D 同时存在于 第一组和第二组)
这样一来,当物体或光源 发生移动时,不会出现 "light popping"(光的震荡)

# Base Pass
base pass 用一个 逐像素直射光 和 所有的 逐顶点/球谐光 渲染物体.
这个 pass 也处理任何 lightmaps, 源自 shader 的 遮蔽 和 自发光.
此 pass 处理的 直射光 允许投射阴影.
注意, 使用 lightmap 的物体,无法从 球谐光源 中获得照明.

注意,当在 shader 中使用 "OnlyDirectional" pass flag 时, forward base
pass 只渲染 主直射光,遮蔽/lightprobe, lightmaps
( 球谐 和 逐顶点光 不被包含进 pass data 中 )

# Additional Passes
每个 Additional Pass 实现一个 逐像素 光源. 默认时,这些光源不产生阴影.
(所以, forward rendering 只支持一个 直射光阴影) 
除非使用了 "multi_compile_fwdadd_fullshadows" variant shortcut


# Performance Considerations 性能注意事项

球谐光 渲染速度很快. 它们的 cpu 成本很低, 对于 GPU 来说也近乎是免费的
(bass pass 总是计算 球谐光, 但鉴于球谐光的工作方式, 不管存在多少个球谐光, 此计算的成本 都是相同的)

球谐光的缺点:
-- 它们在物体的 顶点上进行计算,而不是像素. 这意味着它们不支持 light cookies
    或 法线贴图.
-- 球谐光 很低频. 只支持 漫反射光照.
-- 球谐光不是 局部的, 靠近某些平面的 点光源,spot光源 如果被表达成 球谐,
    它们的效果看起来会 "不正确".

总之, 对于 动态物体来说, 球谐光足够用了.


# ================================================================ #
#     Deferred Shading rendering path
# ================================================================ #

# Overview
当使用 deferred shading, 将不限制光源数量.
所有光源都被实现为 逐像素,这意味着,它们都能正确处理 法线贴图.
额外的,所有的光源 都能有 cookies 和 阴影.

deferred shading 的优点是: 照明的开销 和 "光源影响的像素"的数量 成正比.
而这由场景中的 light volume 的数量而定, 而无关于 "光源照亮的物体的数量".
因此,只要保证光源的影响范围较小(在屏幕空间中的范围),那么总体的 开销就比较小.
deferred shading 还拥有 高一致性 和 可预测的行为.
每个光源的效果被 逐像素 计算, 所以光照效果 不会出现 三角面效果 (顶点着色)

它的缺点是: deferred shading 无法真正支持 AA(抗锯齿,猜测是 MSAA), 而且它
无法处理 半透明物体(这些物体需要在 forward rendering 中被渲染).
它也无法支持 Mesh renderer 的 Receive Shadows flag, 且, 只在有限范围内
支持 culling masks. 最多只能使用 4 个 culling masks. 

(个人理解: 能被 culling 的layer 数量不能超过 4 个, 也就是, inspector culling mask 面板中,
最多只能有 4个 layers 是不被勾选的)

也就是, 你的 culling layer mask 必须至少包含所有层(减去 4 个任意层),所以必须勾选 32 层中的 28 个层. 否则你将得到 图像伪影.



# Requirements
它需要 支持 Multiple Render Targets (MRT) 的显卡, Shader model 3.0(或更高),并且支持 Depth render texture. 通常,2006年后的大部分显卡 都支持 deferred shading.

在移动端,只要显卡支持 OpenGL ES 3.0, 就支持 deferred shading.

注意: 正交投影不支持 deferred shading. 

# Performance considerations 性能注意事项
如果一个物体携带的 shader 它不支持 deferred shading, 这个物体将在 deferred
shading 之后被 额外使用 forward rendering 来渲染.

下方列举了 4个默认的, 位于 G-buffer 中的 render targets (RT0 - RT4).
数据类型 放置在各个 render target 的 各个通道中.  被使用的通道记录在 小括号中:

-- RT0, ARGB32 format: Diffuse color (RGB), occlusion (A).
-- RT1, ARGB32 format: Specular color (RGB), roughness (A).
-- RT2, ARGB2101010 format: World space normal (RGB), unused (A).
-- RT3, ARGB2101010 (non-HDR) or ARGBHalf (HDR) 
    format: Emission + lighting + lightmaps + reflection probes buffer.
-- Depth + Stencil buffer

所以,默认情况下,G-buffer 的体积为:
 160 bits/pixel (non-HDR) or 192 bits/pixel (HDR).



若为 Mixed lighting 使用 Shadowmask or Distance Shadowmask,
第五个 target 会被用到:

-- RT4, ARGB32 format: Light occlusion values (RGBA).

此时,g-buffer 的体积为: 192 bits/pixel (non-HDR) or 224 bits/pixel (HDR).

万一硬件不支持 5 个 render targets, 那么使用 shadowmask 的 物体将被 跌回
forward rendering 模式. 
Emission+lighting buffer (RT3) 使用 对数编码 以提供 足够大的动态范围.
(比常规的 ARGB32 texture 大, 此时, 相机不使用 HDR)

注意,当相机使用 HDR 渲染, 此时没有为 Emission+lighting buffer (RT3) 
创建独立的 render target. 而是将 "相机渲染进去的那个 render target" 当作
RT3.

# G-Buffer pass
此pass 将每个物体渲染一次, 将它们的一些属性渲染进 g-buffer textures 中:
(Diffuse and specular colors, surface smoothness, world space normal, and emission+ambient+reflections+lightmaps)

g-buffer textures 被设置为 全局 shader properties, 以便后续的 shader 可以访问它们.
(CameraGBufferTexture0 .. CameraGBufferTexture3 names)

# Lighting pass
此pass 基于 g-buffer 和 depth 计算光照着色. 计算在屏幕空间中进行, 所以此计算
的成本 和 场景的复杂度无关. 光照被添加到 emission buffer 中.

和相机的 近平面不相交的 点光源/spot灯 以3D形状 来渲染, 并启用针对场景的 z-buffer测试. 这使得 被 部分/全部遮挡的 点光源/spot灯 的渲染计算非常廉价.

至于和相机近平面相交的 点光源/spot灯,以及平行光, 则在 全屏矩形中 被渲染.

如果灯光启用了 阴影,则在本pass 中也会渲染阴影. 注意,阴影的实现存在成本:
需要渲染 shadow casters, 然后必须使用更复杂的 light shader

唯一可用的 lighting mode 就是 Standard. 若想用不同的mode,可以修改 lighting pass shader, 通过将 "源自 Built-in shaders" 的 Internal-DeferredShading.shader 文件 复制到 Assets - Resources 目录中,并改写此文件.

然后打开 Project Settings - Graphics, 将 Deferred 选项修改为 "Custom Shader", 然后绑定上你自定义的 shader.


# ================================================================ #
#     Legacy Deferred rendering path
# ================================================================ #
略


# ================================================================ #
#     Vertex Lit Rendering Path
# ================================================================ #
只在 顶点上 计算着色

略


# ================================================================ #
#     Extending the Built-in Render Pipeline with CommandBuffers
# ================================================================ #

一个 cb 持有一组 rendering commands(比如 如何设置 render target,如何绘制给定的 mesh). 你可以指示unity "调度" 和 "执行" 这些 commands,在 built-in 渲染管线 的数个时间点上. 以此来 客制/拓展 unity 渲染功能.

可以使用  Graphics.ExecuteCommandBuffer API 立即执行 cb. 
或"调度"它们,最后在想要的时间点 一股脑执行. "调度"可通过 Camera.AddCommandBuffer API, 它依赖  CameraEvent enum. 或通过  Light.AddCommandBuffer API, 它依赖 LightEvent enum.

注意, cb API 中的部分功能, 只在特定显卡上运行. 比如,和 光追相关的功能, 依赖于 DX12.


# Command Buffer examples
可阅读此文:
https://blog.unity.com/technology/extending-unity-5-rendering-pipeline-command-buffers

它原针对旧版本的 unity, 不过其中描述的原则 也可用于后续版本.

# CameraEvent and LightEvent event order of execution
略

参见原网页:
https://docs.unity.cn/2021.1/Documentation/Manual/GraphicsCommandBuffers.html


# ================================================================ #
#   Hardware requirements for the Built-in Render Pipeline
# ================================================================ #
略







