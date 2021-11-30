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

在渲染一个 camera 之前, 需要先设置 RTHandle 系统的 reference size:

    RTHandles.SetReferenceSize(width, hight, msaaSamples);

调用此函数拥有两个功能:
-1-:
    如果新提供的 reference size 大于现有值, 系统会将现有的所有 render texture 都做重分配(扩容);
-2-:
    之后, 当系统使用 RTHandles 作为 active render texture 时, RTHandle 系统会更新 "set viewport 和 render texture scales" 的内部属性;

# ------------------------------------- #
#   Allocating and releasing RTHandles
# ------------------------------------- #

在你新建了一个 RTHandleSystem 实例之后, (或直接使用那个 default instance), 你可以使用它来 分配 RTHandles;

有三种主要方法来分配一个 RTHandle, 它们都是在 RTHandleSystem instance 身上使用 Alloc 方法的不同重载版本, 以下分析几个参数:

-- Vector2 scaleFactor:
    就是上文提到的 scale 值, 详解略

-- ScaleFunc scaleFunc:
    用函数来计算目标 render texture 的 像素分辨率; 详解略

-- int width, int height:
    fixed-size textures; 不参与 动态调整尺寸;

还存在几个重载, 从 RenderTargetIdentifier. RenderTextures, or Textures. 中创建 RTHanldes;

# ---------------

当你不再需要一个 RTHanlde 时, 可以释放它:

    myRTHandle.Release();


# ------------------------------------- #
#   Using RTHandles
# ------------------------------------- #

在你分配到一个 RTHanlde 之后, 你可以把他当一个 常规的 render texture 来使用;

因为存在从 RTHandle 到 RenderTargetIdentifier, RenderTexture, Texture 的隐式转换, 所有你可以把它当作这些对象来使用, 来调用它们的 API 函数;


However, when you use the RTHandle system," the actual resolution of the RTHandle" might be different from the "current resolution".
--
# 然而, 当你使用 RTHandle 系统时, 要注意, "被使用的那个 RTHandle 实例的分辨率" 和 "当前要被渲染的分辨率", 是两个概念 !!!!!

-- 前者是一个 render texture 的尺寸, 它可以任意大或任意小;
-- 后者是 camera viewport 尺寸, 它受限于当前 camera 的尺寸;
    (不可能比 camera 还要大对吧)

比方说, main camera viewport 为 1920x1080, 第二个 camera viewport 为 512x512; 在这种情况下, 所有的 RTHandle 的分辨率, 都是基于 1920x1080 计算出来的, (基于这个 max reference size); 哪怕最终写入的 camra 是个只有 512x512 的 camera;

因此,  当你把一个 RTHandle 绑定为 render target 时, 需要分外小心;
"CoreUtils" class 中存在一组 "SetRenderTarget()" 函数, 它们可以帮你解决此问题;
其中一个 函数重载为:
# ==:
    public static void SetRenderTarget(
        CommandBuffer   cmd, 
        RTHandle        buffer, 
        ClearFlag       clearFlag, 
        Color           clearColor, 
        int             miplevel = 0, 
        CubemapFace     cubemapFace = CubemapFace.Unknown, 
        int             depthSlice = -1
    );
# --code-end
此函数做了三件事:
-1-:
    将参数 RTHandle 设置为 active render target;

-2-:
    设置 viewport;
    基于 目标RTHandle 的 "当前帧 reference size" * "scale";
    (而不是基于 max reference size)

-3-:
    clear render target;
# --------

比如: 如果 "当前帧的 reference size" 为 512x512, 而 "max reference size" 为 1920x1080, 如果一个 RTHandle 的 "scale" 为 (1,1), 那么 viewport 最终会被设置为 512x512; 具体数据可能为 (0, 0, 512, 512)

猜测:
    此时, RTHandle 的尺寸是不变的, 还是原来的尺寸, 但是因为设置了 viewport, 最终 camera 只会在 RTHandle texture 上的一个小区域内绘制内容;


# ------------------------------------- #
#   Using RTHandles in shaders
# ------------------------------------- #







































