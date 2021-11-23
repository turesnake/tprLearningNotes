# ================================================================ #
#                   Color space
# ================================================================ #
略

# ---------------------------------- #
# Linear and gamma color space



人眼对 颜色明暗的感知 是 "非线性的", 一个 "正确的线性明暗图" 中的大部分区域, 在人眼看到都是明亮的;
(即, 正确的线性明暗图, 人类看来就是 过曝的, 亮部占了大多数的)


# --- 显示器 ---:
由于历史原因, 旧的显示屏也有相似的特性; 发送一张 "正确线性明暗图" 给这种旧的显示器, 它显示出来的效果,
和人眼看到的一样, 也是 "过曝" 的;
(这个好像和 人眼那个, 是两个各自独立的因素)

为了克服 旧显示屏固有的显示缺陷, 为了让人类能在 旧显示屏上看到 "看起来正确" 的线性明暗图,
厂商在显示输出端做了一次 gamma-校正: 
(gamma校正有 正向和反向两种, 在此先不区分)

    newVal = color ^ 2.2;   (压暗)


注意:
    -1-:
        旧显示器自己就有显示问题 (过曝)
    -2-:
        显示器端的 gamma校正, 是一种 "压暗" 画面的运算; (压暗)
    
    一个正确的画面传递给旧显示器, 会先后执行 -2-压暗 和 -1-过曝 两次变化, 最后返回正常值(接近)
    
对于这些旧显示器, 只要直接输入 线性的画面, 最终就能呈现出 线性的画面;


后来, 随着发展, 显示屏变成了现代电子款; 这些液晶屏不再存在固有缺陷, 它们的画面不再会过曝,
但出于行业惯性, 厂商仍然为液晶屏设置了 gamma校正(压暗) 环节;
此时, 正确的线性数据 被传递给液晶屏, 最终显示出来的画面就是 压暗的;

为了克服这个问题, 传递给 显示器的 数据需要存储在 gamma 空间; (一个看起来比正常值更亮的空间)

也就是说, 原本从程序中计算出来的 正确的线性数据,需要:
    -1- 执行 gamma encode (提亮):
            newVal = color ^ (1/2.2);   (提亮)
        获得的提亮的数据, 此时就位于 gamma 空间(sRGB), 将它存储到硬盘上; (gamma-encoded value)

        实际上, 就算不存入硬盘, 就算存入内存, 也需要在 gamma 空间才行(sRGB),
        因为 显示器 需要 gamma 空间的数据;
    
    -2- 将上述值传递给 液晶屏, 液晶屏内自动执行 gamma校正(压暗)
            newVal = color ^ 2.2;   (压暗)
        最终呈现出 正确的画面;


------------------

gamma 和 linear 两种格式共存的原因在于:
光照计算需要在 linear 空间中进行, 以获得正确的结果;
而计算出的数据需要存储在 gamma 空间中, 以便最终适配 显示器的这个特征;

在老显卡上, framebuffer color 的每个通道只有 8-bits 存储空间,
使用 gamma curve 来存储颜色信息, 可以在人眼敏感的区域 分布更多数值, 最终获得符合人眼特性的数值分布;


Linear rendering:
    是一个渲染场景的流程, 在这个流程中, 所有 input 值都是 线性空间的,
    也就是说, 中间不存在 gamma 校正, 不需要被人看到, 不需要输出到 显示器上
    (在这个过程中)


# ================================================================ #
#               Linear or gamma workflow
# ================================================================ #
unity 同时提供这两种工作流;

linear workflow 具有 color space crossover (颜色空间交叉能力):
它的 texture 仍然可以是 gamma 空间的 (通常是别的软件制作,且存储在硬盘中的),
工作流 可以正确和精确地将这种 texture 渲染到 线性颜色空间中去;

texture 往往倾向于存储在 gamma 空间, 而 shader 总希望在 linear 空间中执行计算;
因此, 当在 shader 中对 texture 进行采样后, 获得的原始值(gamma空间) 往往会导致错误的计算结果;
为了克服此问题, 你可以设置 unity 去使用一个 "sRGB sampler", 来跨越 gamma-linear 空间;
这能保证 一个 linear workflow 的 shader 的所有 input 和 output 都在正确的颜色空间,
同时保证计算结果是正确的;


# ---------------------------------- #
# Gamma color space workflow
在 gamma 流中, 渲染管线使用的 颜色 和 texture 都位于 gamma 颜色空间,

textures "do not have gamma correction removed from them" when they are used in a Shader.
当 teture 被 shader 使用时, "它们的 gamma校正 不会被移除";
猜测:
    这句话讲得很不好, 猜测意思是: "这些 texture 的gamma校正 这个效果, 不会被移除".
#   即, 这些 texture 是保持着 gamma 空间的状态, 去被 shader 使用的;

注意:
你可以在 texture inspector 设置中绕靠 "sRGB sampling";

注意:
就算这些数据都在 gamma 空间, unity editor 中的所有 shader 计算, 依然认为这些输入值是 线性的;
(也就是说, 此时计算结果是错误的, 因为 计算公式不变(linear), 参与的数据也不变(gamma), 最终的结果就是错的)

为了得到一个可接受的结果, 当 shader 的输出值被写入到 framebuffer 时, unity editor 会对数据执行调整
以处理不匹配的格式;
同时, 针对最终的结果, unity 不会执行 gamma校正;
( 猜测是不会把最终输出值 "提亮", 因为这些数据已经是 gamma 数据了 )


# ---------------------------------- #
# Linear color space workflow
linear 流的 光照计算结果 要更加精确些;

不管你的 texture 是 gamma 的还是 linear 的, 都能被用于 linear流;

Gamma color space Texture inputs to the linear color space Shader program are 
supplied to the Shader with gamma correction removed from them.
--
"gamma 空间的 texture", 在被传入 "linear 空间的 shader 计算" 时, 会先执行 "sRGB->linear" 转换,
以去掉 gamma 影响;
(确定是这么翻译的, 原文写得很不好)


Note: 
"The Texture preview window in Texture Import Settings" displays Textures using gamma blending 
even if you are working in linear color space.



# Linear Textures
当选择 linear 颜色空间时, unity 会假设你的 texture 仍然是 gamma 颜色空间的;

unity 默认使用你的 gpu 中的 "sRGB sampler", 来跨越 gamma 空间 和 linear 空间;

如果你的 texture 是在 linear 空间下制作的, 你就需要跳过上面这道转换工作 (sRGB->linear)
建议查看下方的 "Working with linear Textures" 网页翻译;


# Gamma Textures
见下方的 "Gamma Textures with linear rendering" 网页翻译;


# 注意:
对于 color 变量来说, 这种转换(sRGB->linear) 是隐式的, 
因为unity 在将这些值作为 const 值传递给 gpu 之前, 已经将它们转换成了 浮点数;
(原来是 0-255 的 8-bits 颜色值(每个通道))


When sampling Textures, the GPU automatically removes the gamma correction, converting the result to linear space.


这些 input 值随后会被传入 shader, 然后在 linear 空间 的 shader 中进行光照计算;
当计算完毕, 将获得的 linear 空间的值 写入 framebuffer 时, 
这些值(linear) 
    -- 要么立即执行 gamma 编码 (提亮), 
    -- 要么维持 linear 状态, 等待未来某个环节的 gamma 编码(提亮);

这取决于当前的 渲染配置, 比如,在 HDR 模式中, 计算结果会停留在 linear 状态;
(这样就能在 post-processing 中继续处理这些 linear 数据)
(直到最后的最后才执行 gamma 编码(提亮) )


# ---------------------------------- #
# Differences between linear and gamma color space


因为 计算公式都是 linear 的, 但在不同的工作流中, 传入的数据却是不同的:
gamma 流中传入 gamma 数据
linear 流中传入 linear 数据, (哪怕 texture 是 gamma 的)

这导致两个工作流最后计算出来的视觉效果是不同的;

# Light fall-off
略

# Linear intensity response

当光线强度不断变高时, gamma 工作流 更容易把画面做曝;

略

# Linear and gamma blending

When blending into a framebuffer, the blending occurs in the color space of the framebuffer.

当计算出来的结果, 和 framebuffer 进行 blend 时,
这个 blend 操作发生在 framebuffer 所位于的空间;

在 gamma 工作流中, 计算结果 和 framebuffer 都是 gamma 的, 
它们之间发生 blend, 这在数学上是错误的, 可发生 视觉效果异常; 
但在 gamma 工作流中, 只能这样做;

在 linear 工作流中, framebuffer 是 linear 的, 
blend 也发生在 linear 空间中,
这在数学上是正确的, 最终的视觉效果也是合理的;


# ================================================================ #
#         Gamma Textures with linear rendering
# ================================================================ #
texture 是 gamma 空间的, 但是工作流确实 linear 的; 此时的注意事项;

将一个原本是 gamma 工作流的项目, 转换到 linear 工作流, 你会发现渲染效果变了;
为了保持你想要的 原来那个视觉效果, 可能需要额外地调整 material, texture, lights;




# ---------------------------------- #
# Lightmapping
在 lightmapper 体内执行的 光照计算, 始终位于 linear 空间;
而计算得到的 lightmap tetxures, 则始终存储在 gamma 空间中;

这意味着, 不管你选择那种 工作流, lightmapper 的行为和结果是保持不变得;

当你修改 工作流时, 你需要 重新烘焙各种 lightmap 数据;



# ---------------------------------- #
# Importing lightmaps
由 unity 生成的, 存储在 lightmap .exr 文件中的数据, 是位于 linear 空间中的;
( 粗略的了解到, .exr 中的数据为 rgba每通道 fp16, 一共 64-bits )

此数据会在 import 阶段被转换为 gamma 空间;

当你在 unity 之外的 lightmapper 中创建了 lightmap 数据, 并通过 unity 的 texture import
系统想要将这个数据 传入 unity 项目时, 你可以在 texture import inspector 界面中,
type 一栏选择 Lightmap 项;

这个设置确保了在 import 阶段, "sRGB sampling" 是不被执行的;


# ---------------------------------- #
# Linear supported platforms

不是所有平台都支持 linear 工作流; 支持它的 build targets 有:
    Windows, Mac OS X and Linux (Standalone)
    Xbox One
    PlayStation 4
    Android
    iOS
    WebGL

当设备不支持 linear 工作流时, 并不会 fallback 回 gamma 工作流;
而是 unity 直接不支持你去 开启 linear 工作流;

可查询 "QualitySettings.activeColorSpace" 来获知当前 active 的 颜色空间 (工作流)

    -- 在 Android, linear 工作流 至少需要 OpenGL ES 3.0 和 Android 4.3.

    -- On iOS, linear rendering requires the Metal graphics API.

    -- On WebGL, linear rendering requires at least WebGL 2.0 graphics API.

只有满足了这些要求, unity 的 color space 选择栏 才会开启 linear 选项;
否则, 它只会多出一个 警告窗口, 提示你当前不支持 linear 工作流;


# ---------------------------------- #
# Linear color space and HDR

当选择了 linear 工作流, 同时启用了 HDR,
渲染结果会被写入 "floating point buffers" 中;

这些 buffer 拥有足够的精度, 可直接存储 hdr 值, 无需在 存储/访问 时 转换进/出 gamma 空间;

在这种配置中, framebuffer 也存储 linear 数据;
( 如果不开启 HDR 呢, 可查看下一节的内容 )

因此, 所有的 blend 操作, post-processing, 都将在 linear 空间中进行;
直到获得最终的 渲染结果, 最后才将其执行 linear->sRGB 转换 (提亮);


# ---------------------------------- #
# Linear color space and non-HDR

当选择了 linear 工作流, 同时启用了 LDR,
一种特殊类型的 framebuffer 被启用, 它体内存储的数据位于 gamma 空间,
    当从它 读取数据时, 执行 gamma->linear 转换,
    当向它 写入数据时, 执行 linear->gamma 转换;

当这种 framebuffer 被用于 blending, blend 操作工作在 linear 空间;

当在这种模式下进行 post-processing 时, 每一步的 src/dst target buffer 在创建时都要开启 "sRGB read and write" 功能;

也就是说, post-processing 也发生在 linear 空间中, 只有这些 buffer 自己体内是 gamma 空间的;


# ================================================================ #
#        Working with linear Textures
# ================================================================ #

"sRGB sampling" 允许 unity editor 在 linear 空间中计算光照, 同时 texture 的存储内容又在 gamma 空间中;

当你选择了 linear 工作流, editor 默认使用 "sRGB sampling",
如果你的 texture 在 linear 空间, 那就需要关闭这个 texture 的 "sRGB sampling" 功能;


# ---------------------------------- #
# Legacy GUI
Immediate Mode GUI (IMGUI)

IMGUI 元素的绘制 永远在 gamma 空间进行; 这意味着此时, 在 import inspector 上将
type 设置为 "Editor GUI and Legacy GUI" 并不会移除自己的 gamma 特性;
(猜测: 不会被执行 gamma->linear 转换 )



# ---------------------------------- #
# Linear authored Textures

有些特种 testure: lookup Textures, masks, 或是别的在 rgb 通道里写了数据, 且这些数据是线性的不是 gamma 数据,
那么这些 texture 也应该关闭掉 "sRGB sampling";

unity 默认, type 设置为 GUI 的 texture, 和 法线贴图, 都是 linear 数据, 默认都不开启他们的 "sRGB sampling";



# ---------------------------------- #
# Disabling sRGB sampling

关闭 "sRGB sampling":
在 texture import inspector 中, 禁用: sRGB(Color Texture)



