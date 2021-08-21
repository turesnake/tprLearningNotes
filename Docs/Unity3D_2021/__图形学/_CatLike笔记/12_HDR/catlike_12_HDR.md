

# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#                       LDR    HDR
# ---------------------------------------------------------------- #

# ====== 各颜色空间使用流程:
# -1- 原始线性数据
    就是在 shader 中计算的数据.

# -2- gamma 校正
    当原始线性数据存入硬盘时, 会对数据人为做一道 gamma校正: color^(1/2.2)
    校正过的颜色 进入 gamma颜色空间. 这个值会被存入硬盘.

# -3- sRGB 颜色空间
    就是上文提到的 gamma 颜色空间的一种, 适合存储数据.

# -4- 显示屏显示
    显示屏从硬盘中(也可以是内存/显存) 获得 sRGB 空间的 frameBuffer,
    对它做一个 color^2.2 的操作, 这个计算会与之前的 gamma校正 相互抵消.
    最终在 显示屏上显出出正确的 线性空间颜色.
    (显示屏的这道计算是约定俗成的, 写死在硬件中, 是行业规范, 不能改)
    (所以才要用前方的 gamma校正 来中和)



# ===========================:
# LDR
    unity 中默认的 render target 为: 
        RenderTextureFormat.Default
        即: B8G8R8A8_SRGB
    
    每通道 8-bits 容量, 它将被 "存储" 在 sRGB 颜色空间.

    shader 计算是在线性空间进行的, 此时可对每个颜色通道(rgb) 可写入 [0,inf] 值.
    (对, 允许 大于 1 的值)

    当把 rt 写到 显示屏上时, 会自动将这些颜色值 clamp 到 [0,1] 区间, 
    然后执行gamma运算, 写入 sRGB颜色空间.

    这个 clamp 到 [0,1] 的操作, 就等于在 frag-shader 结尾自动执行一个 saturate(color); 运算

# ===========================:
# HDR
    向 LDR render target 写入数据时的 clamp 操作, 把所有亮度大于1 的颜色都 clamp 回了 1.
    当表现 光源, 高亮镜反时, 画面就会显得不够真实. 

    此时就需要 HDR, 在 unity中为:
        RenderTextureFormat.DefaultHDR
        即: R16G16B16A16_SFloat
    
    每通道 16-bits, 共 64-bits. 

# HDR Render texture
    它只和 post-processing 一起使用才存在意义. 
    因为我们需要在 post-processing, 通过计算, 将这些亮度超过 1 的颜色值, 表现到画面中
    (其实是让这些高亮值, 对周边画面产生影响)
    毕竟最终还是要 clamp 回 [0,1] 的....

#   在硬盘/内存中, HDR Render texture 以线性空间 格式存储 (不执行 gamma校正)
    当我们将 _CameraFrameBuffer 和 bloom 中的各种 temp rt 都设置为 HDR 模式后,
    这些 texture 将直接以 线性颜色空间 的形式存储在 硬盘/内存中.

    此时我们去 Frame Buffer 窗口中查看各个 draw call, 会发现画面非常暗
    恰恰是因为, 这些存储在 HDR texture 中的颜色, 没有经过 gamma校正, 然后直接被传输到显示屏显示.
    最终的结果就是 偏暗



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#               Scattering Bloom
# ---------------------------------------------------------------- #
这是一个非物理的, 有点复杂的流程.

有时间可以大致整理下. 



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#                  ToneMapping
# ---------------------------------------------------------------- #
尽管 原始渲染, 部分 post-processing 之后的 render target 中存储的是 线性颜色, 
这些颜色如果不做处理, 仍会被 clamp 到 [0,1] 区间. 高亮信息将被丢失.

原则上, 高亮信息可以无限亮, inf. 

我们只用 tonemapping 技术,将 [0,inf] 区间的颜色值, 映射到 [0,1] 这个 LDR 区间.
然后尽可能地少改动 中等偏暗的颜色, 尽可能大力压缩 超高亮度的颜色值.

# -1-: Reinhard
对 rgb 每个颜色通道,执行 c/(1+c) 即可

# -2-: Neutral
有点复杂, 未来展开
unity Color.hlsl 提供了现成函数: 
    color.rgb = NeutralTonemap(color.rgb);

# -3-: ACES
全称: Academy Color Encoding System
unity 自己实现了一个 aces hlsl, color.hlsl 包含了这个文件
    color.rgb = AcesTonemap( unity_to_ACES(color.rgb) );

# ACES 会适当将 中等偏暗的 frags 适当压暗一些.  

# 对于亮度值很高的,带有颜色的 高亮frag, ACES 在调节它的亮度的同时,
# 还会将它的 颜色,朝着泛白的方向调. 这也符合人眼观察. 

# ----------------------- #
# 一步优化
亮度接近 inf 的值, 在执行上述计算时,可能会遭遇 精度丢失现象. 
有时是因为选择了 half 存储而导致的, 可改为 float
但是在 Metal 平台中, shader 编译器存在一个bug, 这导致就算改用了 float, 此问题依然存在
这会出现在 ios, osx 等平台上. 

解决方案时,在执行 tonemapping 之前, 优先将 超高亮度值, clamp 到一个适中的值:

color.rgb = min(color.rgb, 60.0);












