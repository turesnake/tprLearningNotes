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
一些最亮的 光源 会 逐像素渲染。然后，每个顶点最多计算 4个 点光源。剩余的光源被计算为 球谐。
基于以下规则来 安排不同光源：

-- Render Mode 设置为 Not Important 的光源，总是 逐顶点 或 球谐。
-- 最亮的 直射光 总是 逐像素
-- Render Mode 设置为 Important 的光源，总是 逐像素。
-- 按照上述规则，如果获得的 逐像素 光源数量，仍然少于：
    Project Setting - Quality - Rendering - Pixel Light Count 所标记的数量（通常为4）
    那就针对剩余光源，按照亮度高低，将更多光源 选择为 逐像素。










