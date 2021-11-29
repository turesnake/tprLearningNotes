# ================================================================ #
#         The RTHandle system   (11.0)
# ================================================================ #

对于任何管线来说, 管理 render target 都是一项重要的任务; 

在一个复杂的管线中，其中有许多相互依赖的 render pass, 使用许多不同的 render textures; 因此拥有一个可维护和可扩展的系统很重要，以便轻松管理内存。

当渲染管线使用许多不同的相机，每个相机都有自己的分辨率时，一个最严重的问题就会出现:
比如, off-screen Cameras 或 实时反射探针, 在这种情况下，如果系统为每个 Camera 独立分配 render texture，则内存总量将增加到无法管理的水平。
这对于许多使用 中间 redner texture 的管线来说尤其不利;

unity 可以选择使用 temporary render textures, 但不幸的是，它们不适合这种情况，因为只有到新的 render texture 使用完全相同的 properties 和分辨率 时，之前分配的那个 temp render texture 才能被新的复用;

为了解决这个问题, unity srp 引入了 RTHandle 系统;
这个系统时 unity 已有的 RenderTexture API 的一层抽象, 它能自动处理 render texture 的生命周期;

# ================================================================ #
#     RTHandle system fundamentals   (11.0)
# ================================================================ #
本文介绍 RTHandle 的主要原理;

RTHandle 使得在 "不同分辨率的 camera" 之间复用 render texture 这一事变得简单;

以下介绍了它是怎么工作的:
--
    你不再需要用 固定的分辨率 去手动分配 render textures; 相反, 你可以使用一个 scale 值来分配 render texture, 这个 scale 和给定分辨率的 full screen 相关; 

    对整个 管线, RTHandle 只分配一次 texture, 然后能在不同的 camera 之间复用它;
--
    现在有了参考尺寸的概念。(reference size)
    这是程序用来渲染的 分辨率; 你需要在管线以特定的分辨率渲染每个camera 之前, 手动声明这个值; 
--
    在内部，RTHandle 系统会跟踪您声明的最大的那个 reference size;
    这个值将影响 你每次申请的 render texture 的尺寸 (下文有详述) 

--
    每次你声明一个新的 reference size, RTHandle 都会检查这个新值是不是比之前的都大, 如果它确实是最大的, RTHandle 系统会在内部 重分配所有 render textures, 以适应这个新的最大值,  同时更新记录在册的 最大值记录;

--------------------
如下是一个案例:
当你分配一个 main color buffer 时, 它的 scale 值为 1; 毕竟这是一个 全屏texture; 

如果一个 buffer 只有屏幕的 1/4 大, 那么这个 buffer 的 x,y 尺寸都将是 全屏尺寸的 1/2; 所以此时, scale 值为 0.5;

在系统内部, 系统使用当前最大值的 reference size, 乘以每次分配的 scale 值, 得到本次 render texture 的实际尺寸;

在此之后,以及每次 camera 渲染之前, 你都告诉系统 当前的 reference size 是多少;
基于这个值, 以及每个 render texture 的 scale 值, RTHandle 系统可以得知自己是否需要为 render texture 重分配内存; 就像上面提到的, 如果新的 reference size 值最大, 那么所有的 render texture 都需要被重分配; 

通过这样做，RTHandle 系统 最终会为所有 render textures 提供稳定的最大分辨率，这很可能是您的 main Camera 的分辨率;

这样做的关键是 render texture 的实际分辨率不一定与当前 viewport 相同：它可以更大。当你使用 RTHandle 编写 renderer 时, 这会产生影响, 具体见下个网页的介绍;

RTHandle 系统还允许你分配固定尺寸的 texture; 此时, 系统再也不会对这个 texture 做重分配; 

这允许你灵活使用 上述两种 分配方式;



# ================================================================ #
#     Using the RTHandle system   (11.0)
# ================================================================ #



# ---------------------------------- #
# Initializing the RTHandle System
# ---------------------------------- #
所有与 "RTHandles" 相关的操作, 都需要一个 "RTHandleSystem" 类的实例;

此类包含: 分配 RTHandles、释放 RTHandles 和设置帧的reference size 所需的所有 API。

这意味着您必须在管线中 创建和维护 "RTHandleSystem" 的实例，或者使用本节后面提到的静态 "RTHandles" 类。

使用如下代码来创建你自己的 "RTHandleSystem" 实例:
# ==:
    RTHandleSystem m_RTHandleSystem = new RTHandleSystem();
    m_RTHandleSystem.Initialize(
        Screen.width, 
        Screen.height, 
        scaledRTsupportsMSAA: true, 
        scaledRTMSAASamples: MSAASamples.MSAA4x
    );
# --code-end

关于 "RTHandleSystem" 的初始化信息, 已经写入 对应文件 (11.0)

除了自己新建+初始化一个 "RTHandleSystem" 实例, 你还可以使用 系统提供的一个 default global instance, 它在 "RTHandles" class 体内; 而且你还不需要操心它的 生命周期; 使用这个 static instance, 上面的初始化代码变成:
# ==:
    RTHandles.Initialize(
        Screen.width, 
        Screen.height, 
        scaledRTsupportsMSAA: true, 
        scaledRTMSAASamples: MSAASamples.MSAA4x
    );
# --code-end

下文都将使用这个 static instance 来做示范;

# ---------------------------------- #
#   Updating the RTHandle System
# ---------------------------------- #





































