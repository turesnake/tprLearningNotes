# ================================================================ #
#         The render graph system   (11.0)
# ================================================================ #

render graph 系统位于 srp 之上; 它允许您以可维护和模块化的方式编辑 custom srp; HDRP 使用了此系统;

你可使用 "RenderGraph" API 新建一个 render graph; 它是 custom SRP's render passes 的一种高级表达, 明确说明 render passes 是如何使用资源的;

它由两大优势:
--
    它简化了渲染管线配置，
--
    render graph 系统 能高效地管理渲染管线的各个部分，从而提高运行时性能; 下一个网页就会详述这个 性能优势;


想要使用 render graph, 你的代码必须异于 常规的 custom srp 代码;
后面的网页会介绍如何写它;

注意:
render graph 系统还在试验阶段, 可能会修改 api;


# ================================================================ #
#         Benefits of the render graph system   (11.0)
# ================================================================ #


# ---------------------------------- #
# Efficient memory management

当你手动管理资源分配时, 您必须考虑每个 rendering feature 同时处于 active 状态的情况，从而为最坏的情况进行分配。当某个 rendering feature 未激活时, 它的资源会存在与那儿, 尽管渲染管线并没有使用它们;

与之相对, render graph 只分配 帧当前需要用到的资源; 这减少了管线的内存占用, 同时意味着 无需创建复杂的资源逻辑来处理资源分配; 
高效内存管理的另一个好处是，由于 render graph 可以有效地重用资源，因此有更多资源可用于为渲染管道创建 features。

# ---------------------------------- #
# Automatic synchronization point generation

异步计算队列 可以与 常规图形工作 并行运行，因此可以减少处理渲染管道所需的整体 GPU 时间。

然而，手动定义和维护 异步计算队列 和 常规图形队列 之间的同步点可能很困难。
render graph 能自动执行此功能, 并使用管线 的高级声明 在计算和图形队列之间 生成正确的同步点。


# ---------------------------------- #
# Maintainability

渲染管线维护 中最复杂的问题之一是 资源管理。因为 render graph 自动管理资源, 因此可以更轻松地维护 管线; 

使用 RenderGraph API，您可以编写高效的自包含渲染模块，这些模块显式声明其输入和输出，并且能够插入渲染管道中的任何位置。


# ================================================================ #
#         Render graph fundamentals   (11.0)
# ================================================================ #
本文档描述了 render graph 的主要原理, 以及 Unity 如何执行它的。

# ---------------------------------- #
# Main principles
几个基本原则:
--
    你不再需要手动管理资源, 相对, 你使用 render graph system-specific handles;
    所有的 RenderGraph API 都是用这些 handles 来管理资源;
    render graph 管理的资源类型为:
        -- RTHandles,       (后续文档里有)
        -- ComputeBuffers, 
        -- RendererLists.   

--
    只有在一个 render pass 的 执行代码内部, 才能访问 "真正的的资源的引用";

--
    该框架需要一个显式的 render passes 的声明;
    每个 render pass 必须说明它 读取/写入 的资源;

--
    render graph 的每次执行之间 不存在 持久性;
    这意味着, 你在 render graph 的上一次执行期间创建的资源, 不能延续到 下一次执行;

--
    对于那些需要持久性的资源(比如, 能跨帧)
    你可以向处理常规资源一样,在 render graph 之外创建它们, 然后导入它们;

    它们的 依赖关系和追踪特性上类似其它的 render graph 资源, 只不过 render graph 并不处理它们的 生命周期;

--
    render graph 最常用 "RTHandles" 当作 texture 资源;
    这对如何编写 shader, 以及如何设置它们有很多影响。


# ---------------------------------- #
# Resource Management

render graph 系统使用整个帧的高级表示 来计算每个资源的生命周;
这意味着, 当你通过 RenderGraph API 创建一个资源, render graph 系统不会在那一刻立即创建资源; 相反, API 返回一个 表达资源的 handle, 你可以在随后的 API 中使用它; 此时, 这个资源还是不存在的, 只有在 "第一个需要写入它的pass" 被执行前, 这个资源才被真的创建; 在这种情况下, "creating" 并不意味着 render graph 系统 分配了资源; 相反, 它只会在此刻创建 资源引用 (hanlde);

以相同的方式, 在 "最后一个读取该资源的pass" 执行完毕后, 这个资源就被释放了;

这样，render graph系统 可以根据您在 pass 中声明的内容, 以最有效的方式重用内存。

如果某个pass 需要一个资源(只有此pass需要它), 而这个pass 又没有被 render graph 系统执行到, 那么 render graph 系统是不会为这个资源 分配内存的;


# ---------------------------------- #
# Render graph execution overview
# ---------------------------------- #
本系统的执行, 是一个 三步过程, render graph 系统从头开始完成每一帧;
这是因为帧于帧之间 graph 都在动态地变化; 比如依赖于用户的操作;

# -1- Setup:
第一步, set up all the render passes;
你在这里 声明需要被执行的所有 render passes, 以及每个 render pass 需要使用的 资源;

# -2- Compilation:
第二步, 编译 graph; 
在这一步中, 如果一个 render pass 的输出值, 不被别的 render pass 使用, 那么这个 render pass 就会被 系统 cull 掉 (剔除);

这样, 就不需要再 Setup 阶段操太多心;

比如: debug render pass:
    如果你声明的 render pass 将产生 debug 输出, 而这个输出没有被画到 back buffer 上, 那么 系统会把这个 render pass 自动 剔除掉;

本 step 还计算 资源的生命周期; 这允许系统高效的 分配和释放资源; 并在 "异步计算管线" 上执行 passes 时能计算适当的 同步点;

# -3- Execution:
最后一步, 执行 graph;
系统会以声明中的顺序, 执行所有 "没有被剔除的 render passes";
在每个 render pass 被执行之前, 系统会新建适当的资源, 在每个 redner pass 执行完毕后, 有些不再被访问的资源会被 释放掉;


# ================================================================ #
#         Writing a render pipeline   (11.0)
# ================================================================ #


# ---------------------------------- #
# Initialization and cleanup of Render Graph
# ---------------------------------- #

首先，您的渲染管线需要维护至少一个 RenderGraph 实例。这是 API 的主要入口; 你可是使用多个 RenderGraph 的实例; 但请注意, unity 无法在多个 RenderGraph 实例之间分享资源, 所以, 为优化内存的使用, 只需使用一个 实例即可;

# ==:
    using UnityEngine.Experimental.Rendering.RenderGraphModule;

    public class MyRenderPipeline : RenderPipeline
    {
        RenderGraph m_RenderGraph;

        void InitializeRenderGraph()
        {
            m_RenderGraph = new RenderGraph(“MyRenderGraph”);
        }

        void CleanupRenderGraph()
        {
            m_RenderGraph.Cleanup();
            m_RenderGraph = null;
        }
    }
# -- code-end

想要新建 RenderGraph 实例时:
调用它的构造函数, 伴随一个 name string 参数; 
这还会在 SRP Debug 窗口上分配了一个 "render graph-specific panel", 可用来 debug 这个 实例;

当你要销毁这个 RenderGraph 实例时:
调用 rendergraph 的 "Cleanup()" 函数, 它能正确地释放 本实例分配的所有资源;

# ---------------------------------- #
# Starting a render graph
# ---------------------------------- #
在你添加任何 render passes 到 render graph 之前, 你需要先初始化 render graph; 调用 "RenderGraph.Begin()" 函数;

# ==:
    var renderGraphParams = new RenderGraphParameters()
    {
        scriptableRenderContext = renderContext,
        commandBuffer = cmd,
        currentFrameIndex = frameIndex
    };

    m_RenderGraph.Begin(renderGraphParams);
# -- code-end:


# ---------------------------------- #
# Creating resources for the render graph
# ---------------------------------- #

使用 render graph 意味着你不需要自己手动管理资源;
你需要使用 Rendergraph API 指定的函数来获得资源的 handle;

render graph 需要的资源主要有两大类:

# -1- Internal resources:
    这些资源位于 一次"render graph 执行" 的内部，你无法在 RenderGraph 实例 之外访问它们。 你也无法在 两次 "render graph 执行" 之间传递这些资源; render graph 系统 处理这些资源的 生命周期;

# -2- Imported resources:
    这些资源通常来源于 一次"render graph 执行" 的外部; 
    比如 back buffer (由 camera 提供), 或者那些你希望在数帧之间持续存在的 buffer, 比如被 TAA 使用的 buffer;
    这些资源的生命周期 需要你手动维护;

在你 create/import 一个资源后, render graph 系统 用一种 handle 表达它:
    TextureHandle
    ComputeBufferHandle
    RendererListHandle

通过这些 handle, 不管是 Internal 还是 Imported 资源, 都能在 render graph API 以相同的方式被使用;

# ==:
    public TextureHandle RenderGraph.CreateTexture(in TextureDesc desc);
    public ComputeBufferHandle RenderGraph.CreateComputeBuffer(in ComputeBufferDesc desc)
    public RendererListHandle RenderGraph.CreateRendererList(in RendererListDesc desc);

    public TextureHandle RenderGraph.ImportTexture(RTHandle rt);
    public TextureHandle RenderGraph.ImportBackbuffer(RenderTargetIdentifier rt);
    public ComputeBufferHandle RenderGraph.ImportComputeBuffer(ComputeBuffer computeBuffer);
# -- code-end
其实为一组 函数:
# CreateTexture()
# CreateComputeBuffer()
# CreateRendererList()

# ImportTexture()
# ImportBackbuffer()
# ImportComputeBuffer()

















    








