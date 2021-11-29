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

上述函数存在重载版;

为了创建资源, 每个 API 函数都需要一个 descriptor structure 作为参数;
这些结构中的 proerties, 类似于它们所代表的资源中的 properties;
然而有一些 properties 专门用于 render graph textures;

以下是最重要的两个属性:

-- clearBuffer:
    本属性告诉 graph, 当创建资源时, 是否 clear buffer; 主要是创建 texture 时; 因为 render graph 用池子管理资源, 这些资源被回收利用, 里面包含的数据是未定义的;

-- clearColor: 
    存储一个颜色值, 如果需要 clear buffer, 就用这个颜色去覆写;


还有两个特定于 "TextureDesc" 的构造函数 对外公开的 配置参数:
-- xrReady:
    指示本 texture 是否被用于 XR 渲染; 如果是, render graph 系统会将这个资源
    新建为一个 texture array, 以供每只眼睛使用;

-- dynamicResolution: 
    当程序使用 动态分辨率 功能时, 是否也动态 resize 本texture 的尺寸;


你可以在 render passes 之外创建资源, 在一个 render pass 得 setup 代码中, 但不在 渲染代码中;

你可以在所有 render passes 开始之前创建资源, 一个例子就是创建一个 color buffer, 既可用于 deferred lighting pass, 也能被用于 forward lighting pass;
这两种pass 都可写入 color buffer, 不过 unity 只会根据当前 camera 的模式, 选择其中一种;

在 render pass 体内创建资源 常用于 render pass 自己产生的 资源; 比如, 一个 blur pass 需要一个已经存在的 input texture, 但是此 pass 自己会创建一个 output 资源, 并在本 pass 结束时返回这个 output 资源;

注意:
创建这样的资源不需要 gpu 每帧都分配内存, render graph 系统会复用 池中的内存; 
在 render graph 的上下文中，更多地根据 render pass 上下文中的 data flow,而不是实际分配来考虑资源创建。


# ---------------------------------- #
#     Writing a render pass
# ---------------------------------- #
在 unity 能执行 render graph 之前, 你必须声明所有的 render passes;
你要实现 render pass 的两个部分: setup 和 rendering;

# -------------------- #
#  Setup:
在这个阶段, 你声明 render pass, 以及它需要的所有数据; 

声明 render pass 需要的数据:
# ==:
    class MyRenderPassData
    {
        public float parameter;
        public TextureHandle inputTexture;
        public TextureHandle outputTexture;
    }
# -- code-end
只需声明这个 class 即可, 不需要为它创建实例, 它的实例由下方的 render pass 创建好后, 返回给我们;


然后, 声明 render pass 本身:
# ==:
    using (var builder = renderGraph.AddRenderPass<MyRenderPassData>("My Render Pass", out var passData))
    {
        passData.parameter = 2.5f;
        passData.inputTexture = builder.ReadTexture(inputTexture);

        TextureHandle output = renderGraph.CreateTexture(new TextureDesc(Vector2.one, true, true){ 
            colorFormat = GraphicsFormat.R8G8B8A8_UNorm, 
            clearBuffer = true, 
            clearColor = Color.black, 
            name = "Output" 
        });
        passData.outputTexture = builder.WriteTexture(output);

        builder.SetRenderFunc(myFunc); // details below.
    }
# -- code-end

你在 using 代码块的 "renderGraph.AddRenderPass()" 中定义 render pass, 
在这个代码块的结尾, render graph 将这个 render pass 添加到自己的内部结构中, 以供后续处理。

文档中关于 变量 builder, 类型 RenderGraphBuilder 的描述, 被直接写到了这个 class 的翻译笔记中; (11.0)


代码中的 passData 是 系统为你创建的实例, 你需要向其写入数据,以便 渲染代码可以访问这些数据; 注意, render graph 不会立即使用 passData 中的数据, 而是随后在 帧内, 在 graph 注册了所有的 passes, 完成了编译, 开始执行之后, 才会访问这些数据;

这意味着, passData 中存储的所有引用, 在整个帧中都必须保持不变; 否则，如果您在render pass 执行之前更改内容，则在 render pass 执行过程中 它不会包含正确的内容。 所有, 最好只存入 值类型的值 (value types), 要么你能保持传入的 引用 肯定不会被改动;


# -------------------- #
# Rendering Code
在完成 setup 后, 可以声明那个被用于 "SetRenderFunc()" 的 渲染函数;
这个函数必须符合如下签名:
# ==:
    delegate void RenderFunc<PassData>(
        PassData data, 
        RenderGraphContext renderGraphContext
    ) 
    where PassData : class, new();

# -- code-end

这个渲染函数 可以是个 static 函数, 也可以是个 lambda;

如果你选择了 lambda, 注意不要从函数的 main scope 中捕获任何参数,
因为这样做会产生垃圾,  unity 会在随后的 GC 阶段定位和释放这些垃圾;

如果你正在使用 VS, 悬停在 => 符号上会告诉你 lambda 是否捕获任何数据;

避免不要再这个 渲染函数内访问任何 实例成员 或 方法, 因为访问它们都会捕获 this;

这个 渲染函数需要两个参数:
-- PassData data:
    这是你在声明 render pass 时使用的那个类型;
    通过此参数, 你可以访问 setup 阶段初始化的数据,
    以便在 渲染阶段使用它们;

-- RenderGraphContext renderGraphContext:
    存储了 context 和 commandbuffer 的引用, 它们提供了一组使用的方法, 以便你可以实现各种 渲染代码;

# Accessing resources in the render pass
通过参数 passData, 你可以在 渲染函数体内访问到 这个参数携带的所有 render graph 资源; 

你只要将目标资源的 handles 放入 passData, 然后传递给 渲染函数, unity 会自动将这些 handle 转换成实际的资源 (在需要的时候);

注意, 在 渲染函数之外执行这种 隐式转换 会导致抛出异常; 因为此时, render graph可能没有给这个 handle 分配实际的资源;

# Using the RenderGraphContext
RenderGraphContext 参数包含了各种功能, 其中最重要的是 ScriptableRenderContext 和 CommandBuffer, 

RenderGraphContext 还包含了 RenderGraphObjectPool, 它帮助你管理 渲染代码可能需要用到的 临时对象;

# Get temp functions
在 render pass 执行期间, 有两个函数尤其有用:
--
    T[] GetTempArray<T>(int size);
--
    MaterialPropertyBlock GetTempMaterialPropertyBlock();

以上两个猜测都是 "RenderGraphObjectPool" 中的;
具体细节写到对应函数的注释中了 (11.0)

在 render pass 执行完毕后, 系统会自动将上面两个函数返回的 资源回收和复用; 
你不需要操心它们的生命周期;


# ---------------------------------- #
#    Example render pass
# ---------------------------------- #
下面代码 包含了 setup 和 渲染函数 两部分:
# ==:
    TextureHandle MyRenderPass( RenderGraph renderGraph, 
                                TextureHandle inputTexture, 
                                float parameter, 
                                Material material
    ){
        
        using (var builder = renderGraph.AddRenderPass<MyRenderPassData>("My Render Pass", out var passData))
        {
            passData.parameter = parameter;
            passData.material = material;

            passData.inputTexture = builder.ReadTexture(inputTexture);

            TextureHandle output = renderGraph.CreateTexture(new TextureDesc(Vector2.one, true, true){ 
                colorFormat = GraphicsFormat.R8G8B8A8_UNorm, 
                clearBuffer = true, 
                clearColor = Color.black, 
                name = "Output" 
            });

            
            // 将上面获得的 output 设置为 color buffer: render target 0
            passData.outputTexture = builder.UseColorBuffer(output, 0);

            // 用一个 lambda 来实现 渲染函数 函数体:
            builder.SetRenderFunc(
                (MyRenderPassData data, RenderGraphContext ctx) =>
                {
                    // Render Target is already set via the use of UseColorBuffer above.
                    // If builder.WriteTexture was used, you'd need to do something like that:
                    // CoreUtils.SetRenderTarget(ctx.cmd, data.output);

                    // Setup material for rendering
                    var materialPropertyBlock = ctx.renderGraphPool.GetTempMaterialPropertyBlock();
                    materialPropertyBlock.SetTexture("_MainTexture", data.input);
                    materialPropertyBlock.SetFloat("_FloatParam", data.parameter);

                    CoreUtils.DrawFullScreen(ctx.cmd, data.material, materialPropertyBlock);
                }
            );

            return output;
        }
    }
# -- code-end


# ---------------------------------- #
#   Execution of the Render Graph
# ---------------------------------- #
在你声明好所有的 render passes 之后, 你需要 "执行" render graph;
调用:
# ==:
    m_RenderGraph.Execute();
# -- code-end

这将触发 编译 和 执行 render graph 的过程;


# ---------------------------------- #
#    Ending the frame
# ---------------------------------- #
在整个程序运行过程中，render graph 需要分配各种资源。 有些资源被使用一阵子之后就不再被使用了; 想要让 graph 释放这些资源, 请每帧调用一次:

    renderGraph.EndFrame();

这会释放 render graph 自上一帧以来未使用的任何资源。
这也会在帧结束时, 执行 render graph 所需的所有内部处理。

注意:
本函数只能被调用一次, 且必须在 最后一个 camera 完成渲染之后, 再调用;

这是因为, 不同的 camera 可能执行不用的 rendering path( 比如 前向渲染 和 延迟渲染), 每个 camera 需要不同的资源;

过早调用本函数会导致 后方本来需要使用资源的 camera 找不到资源;















    








