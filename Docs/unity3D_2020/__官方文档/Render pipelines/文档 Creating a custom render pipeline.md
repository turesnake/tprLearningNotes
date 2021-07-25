
# ================================================================ #
#   Creating a custom render pipeline based on the Scriptable Render Pipeline
# ================================================================ #
略

# ================================================================ #
#   Creating a Render Pipeline Asset 
#   and Render Pipeline Instance in a custom render pipeline
# ================================================================ #

按照大部分教程上的方法，新建 CustomRenderPipelineAsset, CustomRenderPipeline 两类，
各自实现 CreatePipeline()， Render() 两个函数。

最后在 unity 编辑界面，生成 asset 实例，并绑定到当前项目上去 （具体细节略）

# Creating a configurable Render Pipeline Asset and Render Pipeline Instance

可以创建很多份 rp asset 实例，每个实例实现不同的配置，甚至针对不同的平台。

# RP Asset 公共字段信息
如 文档案例所示，可以在 CustomRenderPipelineAsset 类内实现 public 字段，这些字段会暴露在 asset 面板中，
供用户在 unity 界面中调节。然后，为 CustomRenderPipeline 构造函数准备一个 RP Asset 类的 引用 参数，
在调用此构造函数时，传入 RP Asset 的 this 引用。 从而让底层代码可以访问这些 asset 公共字段 信息


略过一些 实现 CreatePipeline()， Render() 的介绍...


# ================================================================ #
#   Creating a simple render loop in a custom render pipeline
# ================================================================ #
一个 render loop 就是在一帧内 所有渲染操作 的总和。

# Preparing your project
略...
(可选项）可以安装 SRP Core package。它包含 SRP Core shader library，（可用它来让你的 shaders 兼容 SRP Batcher）
也包含 常规操作的的各种常用函数。

# Creating an SRP-compatible shader
srp 依靠 LightMode pass tag 来确认 如何渲染几何体。
这个 LightMode tag，必须和 管线代码中，ScriptableRenderContext.DrawRenderers()
的参数 ShaderTagId 相一致。然后管线才能识别出这类 shader 文件。

略...

# Creating the render loop
在单个 render loop 中，最基础的操作有：

-1- Clearing the render target
-2- Culling
-3- Drawing

# Clearing the render target
render target 可以是屏幕，也可以是一张 texture。
依靠 commandbuffer 来 “调度” clear 任务：

    var cmd = new CommandBuffer();
    cmd.ClearRenderTarget(true, true, Color.black);
    context.ExecuteCommandBuffer(cmd); // 只“调度”，不是立刻实施
    cmd.Release();
    ...
    context.Submit(); // 真正的实施

# Culling
将当前相机看不到的 几何体 剔除掉:
    
    CullingResults cullingResults; // cull 操作后的 可见对象: 物体,光源,反射探针
    ...
    if( this.camera.TryGetCullingParameters( out ScriptableCullingParameters p ) ){
        // 执行真正的 cull 操作,并返回 可见对象: 物体,光源,反射探针
        // 因为 p 是一个 struct, 直接传入可能引发复制,用 ref 来强制传入一个 引用
        this.cullingResults = this.context.Cull( ref p );
    }

可以看到，Culling 操作并不涉及 commandbuffer，不需要延迟实现，而是立即执行的。
（这样才能在第一时间知道 culling 是否成功，cullingResults 也必须在第一时间被存储 可见对象的数据，以便后续使用） 

# Drawing
-1- 执行上述 Culling 工作，得到 cullingResults 数据
-2- 创建并配置 FilteringSettings 数据， 描述了如何过滤 cullingResults
-3- 创建并配置 DrawingSettings 数据， 它定义了哪些 物体可被绘制，如何绘制
    
-4-（可选）
    默认情况下，unity 基于 shader obj 来设置 渲染状态。若想复写 部分/全部 物体的状态，
    可使用  RenderStateBlock 来实现

-5- (文档漏了) 创建并配置 SortingSettings 数据

-5- 调用 ScriptableRenderContext.DrawRenderers(), 
    将上述 三种 setting 数据 传进去
    ---
    这个 draw 指令会被 “调度” 下来，直达未来的 submit() 才会被统一执行。









