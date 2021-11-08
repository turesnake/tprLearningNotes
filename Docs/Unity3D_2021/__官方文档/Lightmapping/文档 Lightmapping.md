# ================================================================ #
#   Lightmapping
# ================================================================ #

lightmapping 是个预计算过程, 它将场景中 各表面(静态) 的光照信息 存储在一张名为 lightmap 的 texture 中, 以便后续使用.

它能同时将 光照信息 和 遮蔽信息 都记录下来.

lightmap 可同时包含 直接光照 和 间接光照. 这个光照信息 可与其它 surface信息, 比如 albedo, 法线 一起使用.

被烘焙进 lightmap 的信息无法在运行时被修改. 可在此基础上再叠加 实时光照 的影响. 但这些 实时光照 也无法改变 lightmap 中的信息.

我们牺牲了 移动光源的能力, 换来了渲染性能提升. 尤其是在移动平台中. 

unity 提供两种 生成 lightmap 的方式:
    -- Progressive lightmapper
    -- Enlighten (已废弃)


# ================================================================ #
#     The Progressive Lightmapper
# ================================================================ #

The Progressive Lightmapper 是一个 基于"快速路径追踪" 的 lightmapper系统, 它在 editor 中 以 "渐进式更新" 的方式提供 烘焙过的 lightmap 和 lightProbes.

它需要具有 较小面积 和 较小角度误差的 非重贴 UV, 且在 charts 之间设置充足的 间隙.

渐进式 lightmapper 需要一个简短的准备环节, 来处理几何体和实例更新, 并生成 g-buffer 和 chart masks. 然后它会立即产生输出, 并随着时间的推移逐渐完善这个 output, 以一种 大大改进的交互照明工作流.  此外, 烘焙时间也是高度可预测的, 因为 渐进式lightmapper 在烘培时还显示了 时间估值. 

渐进式lightmapper 还 独立地在每个texel 的 lightmap分辨率下, 提供 GI 的烘焙. 此过程无需 上采样方案, irradiance缓存 或其它 全局数据结构. 
这个系统很鲁棒, 允许你烘焙 选定的 lightmap部分, 以便快速测试和迭代场景. 

tpr注: 说白了就是,当你开启了 Auto Generate 后, 它允许你一边调整, 它一边渲染. 而且会把场景修改的最明显变化先展现出来,之后再继续把细节渲染完毕.


# The Progressive CPU Lightmapper and the Progressive GPU Lightmapper (preview)

前者使用 cpu 和内存, 后者使用 gpu 和 vram(显存)

# Render pipeline support
全支持

# Using the Progressive Lightmapper
-- 打开 Window - Rendering - Lighting 面板, 选择 Scene
-- 找到 Lightmapping Settings
-- Set Lightmapper to Progressive CPU or Progressive GPU

可使用的 API:
    LightingSettings
    Lightmapping

# --------------------- #
# Settings

# -- Lightmapper

# -- Prioritize View

# -- Multiple Importance Sampling
    一旦启用, 将使用 多重重要性采样 来对环境进行采样. 
    这会使得 生成lightmap 的收敛速度更快, 但在某些低频环境中会导致噪音. 
    默认不开启

# -- Direct Samples
    用于计算 直射光时, 每个 texel 发射的 path 的数量. (毕竟是 path-tracing). 
    数量越多, 渲染的质量越好, 烘焙耗时也越长
    ---
    catlike 设置为 32

# -- Indirect Samples
    和上条相似,不过用于 间接光照的计算.
    针对室外场景, 100 已经足够了,
    针对室内场景(还内置了自发光物体), 需要不断提高此值, 直到渲染出满意的效果为止. 
    ---
    catlike 设置为 500

# -- Environment Samples
    为了渲染每个 texel, 向天空盒发射的 射线数量. 
    unity 从每个 lightmap texel, 或每个 lightProbe 发射这些射线.
    默认为 500.
    值越高,效果越柔和. 随着性能也会下降.

    在启用了 HDR天空盒 的场景,需要更高的值, 来降低噪音.
    如果天空盒中有 高频信息, 比如太阳, 背光云, 也需要提高采样数.
    ---
    catlike 设置为 500 

# -- Light Probe Sample Multiplier
    控制: 有多少样本用于 lightProbes, 作为上述 "采样数" 的乘数.
    此值越高, lightProbe 质量越好, 但也越耗时. 

    为开启此功能: 去  Project Settings > Editor
    关闭 Use legacy Light Probe sample counts.

    此值默认为 4 

# -- Bounces
    间接光 反弹数量. 
    对于大部分场景, 2次足够了, 室内场景需要更多反弹.

# -- Min Bounces
    默认为 2, 范围[2, 100]

# -- Max Bounces
    默认为 2, 范围[2, 100]

    随着 min值 和 max值 之间的差值变大, lightmap 中的噪声也会变多.

# -- Filtering
     渐进式lightmapper 选择的 后处理滤波器, 来消除噪声. 

     在后处理流程中, lightmap 先被分割为 Direct, Indirect 和 AO 
     三大 targets, 对这三个 targets 分别进行 后处理, 然后再合并为单张 lightmap.

    可选项:
    ++ None:
        不使用 滤波器/降噪器

    ++ Auto:
        使用 依赖于平台的 预设置后处理算法.

        如果你的 开发机 能运行 OptiX (Nvidia 的一个AI加速的降噪器), 
        则使用 带有高斯滤波的降噪器. 
        所有 target 的 texel半径都设置为 1

        如果不能运行 OptiX, 
        也使用 带有高斯滤波的降噪器. 
        针对 Direct target, texel 半径为 1
        针对 Indirect target, texel 半径为 5
        针对 AO target, texel 半径为 2 

    ++ Advanced:
        可手动设置 每一种 target. 
        (它还有一个 子面板)

        = Denoiser:
            - Optix:
                Nvidia 的一个AI加速的降噪器.
                需要 nvidia显卡, 4G显存, 390+版本的驱动程序. 
                尽支持 win 平台

            - RadeonPro:
                也是 AI加速降噪器, 需要支持 OpenCL的显卡, 4G显存.

            - OpenImageDenoise:
                Intel的 AI加速降噪器, 

            - None: 
                不使用降噪器
        
        = Filter: 
            - Gaussian:
                双边高斯滤波, 降低了噪声,但带来了模糊 

            - A-Trous:
                在降噪的同时能最大限度地减少模糊

            - None:
                啥都不用
        
        = Radius:
            只在选用了 Gaussian Filter 时才会出现. 
            设置高斯滤波核的 半径. 值越大, 越模糊

        = Sigma:
            只在选用了 A-Trous Filter 时才会出现.
            用此值来调整 保留细节 和 模糊 之间的平衡. 
            值越高, 越模糊.

# -- Indirect Resolution
    针对间接光部分, 
    每个 unit, 其一条边被 分割为几个 lightmap texel.

# -- Lightmap Resolution
    每个 unit, 其一条边被 分割为几个 lightmap texel.
    注意, 当此值翻倍, 实际分配给一个 unit 的 texel 数量要翻四倍. 

    可联系下方的 statistics 部分的 Occupied texels 

# -- Lightmap Padding
    设置 lightmap 中 charts 之间的 间隙的宽度. "多少个texel"
    默认值为 2

# -- Lightmap Size / Max Lightmap Size
    整张 lightmap texture 的 尺寸(边长,像素). 
    默认值为 1024 

# -- Compress Lightmaps
    压缩过的 lightmap 占用更少的存储空间, 但压缩会在 画面中引入额外的
    视觉效果. 
    默认开启
    ---
    catlike 最初选择关闭. 

# -- Ambient Occlusion
     允许你在 烘焙ao 时设置相对亮度, 
     Contribution 值越高, 遮蔽区和亮区 的对比度越高. 

     == Max Distance
        探测距离上界. 值越大, 能贡献越多的 遮蔽值, 
        值越小, 则只有附近的物体能发挥 遮蔽作用. 
        若值设为0, 则表示 探测距离无限远.
        默认值为 1
    
    == Indirect Contribution
        取值区间[0,10]. 控制间接光的亮度(环境光,反弹光 和 自发光)
        默认值为 1, 小于1, 强度会变弱, 大于1, 强度会变强
    
    == Direct Contribution
        取值区间[0,10]. 控制直接光的亮度
        默认为 0. 此值越大, 直接光 和 间接光 的差异就越大

# -- Directional Mode
    可以选择, 是否为 lightmap 中的每一个 texel, 额外存储
    "入射光的主方向" 信息. 

    默认值为 Directional

    共两个选项:
    == Directional:
        在此模式, unity 生成第二张 lightmap 来存储: 
        "入射光的主方向". 
        这使得 漫反射法线贴图 材质 可以和 GI 合作.
        此模式消耗双倍的存储空间.

        (后续网页: Directional Mode 会详谈)

        方向性lightmap 无法在 SM2.0硬件,或 GLES2.0 上解码.
        此时,它们将会退回 无方向的 lightmap.

    == Directional:
        不会生成第二张 存储 "入射光主方向" 的 lightmap. 

# -- Indirect Intensity
    可选区间[0,5]. 控制 "存储在 实时 和 烘焙的 lightmap" 中的
    间接光的强度. 
    默认值为 1, 大于1,则变强, 小于1,则变弱. 

# -- Albedo Boost
    区间[1,10]. 控制 在表面间反弹的 光的数量.(amount of light)
    为了实现这点, unity 增强了场景中 材质的 albedo. 
    将此值变大, 用于间接光计算的 albedo值 会趋向于白色. 
    默认值是1, 符合物理正确性.

# -- Lightmap Parameters
    unity 还使用一组 通用参数. 

    网页 Lightmap Parameters Asset 会详谈. 

    默认值为 Default-Medium.

# ------------------------------ #
# Statistics 统计数据

Light 面板中,在 Auto Generate 按钮下方的区域, 显示 统计数据.
包括:

-- unity 已经生产的 lightmap 的数量

-- Memory Usage: 
    当前的 lightmaps 消耗的内存

-- Occupied Texels:
    lightmap UV 空间内分配的 texels 数量

-- Lightmaps in view: 
    视口中 lightmap 的数量

-- Lightmaps not in view: 
    视口外的 lightmap 的数量:
    - Converged: 
        彻底烘焙好的 lightmap 的数量
    - Not Converged:
        仍在烘焙中的 lightmap 数量

-- Bake Performance: 
    每秒钟射线的数量. 如果数值比较低(小于2), 那你需要调整你的设置,
    或你的硬件,来提高 射线数量.

# ---------------------- #
# During baking
可在 烘焙进行时, 显示或停止 烘焙过程. 

# ETA
“estimated time of arrival” (displayed as ETA).
预期完成时间. 

# Force Stop
略


# ================================================================ #
#     The Progressive GPU Lightmapper (preview)
# ================================================================ #
略


# ================================================================ #
#     Lightmapping using Enlighten (deprecated)
# ================================================================ #
略


# ================================================================ #
#     Lightmapping: Getting started
# ================================================================ #
一些步骤

未来翻译


# ================================================================ #
#     Lightmap Parameters Asset
# ================================================================ #
这是一个 asset, 包含一些设置选项. 

可以预先配置一些 不同的 asset 实例, 来使用不同的使用场合.

# Creating a Lightmap Parameters Asset
Asset - Create - Lightmap Parameters

# Properties
可在 inspector 中查看内容

# Realtime GI (废弃)
这些参数使用 Enlighten, 它们在 URP/HDRP 中都不被支持.

略

# ------------- #
# Baked GI
这些参数 同时在 Enlighten 和 渐进式lightmap 中被使用.
我们只记录 和 后者相关的:

# -- Blur Radius
    弃用

# -- Anti-aliasing Samples
    为了降噪 supersample 一个 texel 的次数. 
    [1,3] 关闭 supersampling
    [4, 8] 提供 2x supersampling
    [9, 256] 提供 4x supersampling
    
    这主要影响到 pos 和 法线 buffer 的内存使用量
    (2x 模式使用 4倍内存, 4x模式 使用 16倍内存)

# -- Direct Light Quality
    弃用

# -- Backface Tolerance 背面宽容度
    从 output texel 中射出的 射线, 必须射中 front face 的百分比.
    如果某个 texel, 其射出的射线大部分都命中了 背面, 则允许这个 texel无效
    (比如, 它在 几何体内部.)
    此时会从周围 texel 中复制有效值,来避免视觉问题.
    
    若此值设为 0.0, 只有全部都射中背面时, 此 texel 才被作废.
    若设为 1.0,  只要射中以此背面, 此texel 就作废

    ...未完...

# -- Pushoff
    [0,1] 
    The amount to push off ray origins away from geometry 
    along the normal for ray tracing, in modelling units.

    看不懂...

    它同时对 直射光, 间接光, AO 都起作用.
    它对于 摆脱不需要的 遮蔽/阴影 有管用.

# -- Baked Tag
    和 System Tag 类似, 这个数字 允许你将 特定物体组合起来, 写入单独的
    烘焙的 lightmaps. 和 System Tag 类似,具体的数值不是很直观.
    拥有不同 Baked tag 的物体, 不会被 烘焙进同一个 atlas.
    反过来,拥有相同 baked tag 的物体, 不一定会写入共一个 atlas. 

    当使用 多场景烘焙API 时, 你不需要设置这个值, 因为组合工作会自动进行.
    (使用 baked ag 来复制一些 Lock Atals option 的行为)

    tpr注: Lightmap parameter asset 不仅可以绑定到 scene, 
    还可以单独绑定到 各个 gameobj 上去.
    我们只需要制作很多份 asset 实例, 每个实例的 Baked Tag 设置不同的值.
    然后把这些 asset 实例绑到不同的 go 上去, 就能实现分类.


# -- Limit Lightmap Count 
    设置了 unity 能用的 最大lightmap数量, 当将一组 烘焙GI设置相同的 gameobj 打包到一起的时候. 

    当你启用此选项, 一个名为 Max Lightmaps 的变量就会出现. 使用它来设置
    最大值.

    如果两个go 的以下配置相同: 
        Anti-aliasing Samples, 
        Pushoff, 
        Baked Tag, 
        ackface Tolerance. 
    那么这两个go 就会被 untiy 视为 "拥有相同的 烘焙GI设置". 
    这意味着, unity会将 与不同的 lightmap parameter assets 关联的
    go 打包到一起. 
    在执行打包时, unity 逐渐缩小 UV layouts 直到所有go 都塞入 指定数量的
    lightmaps 中. 
    
    这个操作可能降低 lightmap 分辨率.

# ---------- #
# Baked AO

# -- Quality
    在计算AO时, 投射的射线数量. 值越高,效果越好,性能越差

# -- Anti-aliasing Samples
    在对 AO 执行抗锯齿时 使用的 采样数. 值越高效果越好,性能越差. 

# ---------- # 
# General GI

# -- Backface Tolerance
    和上面的 同名变量 功能相同. 

# ----------- # 
# Assigning Lightmap Parameters Assets

# 分配到 Scenes:
Lighting - Scene - Lightmap parameters

# 分配到 GameObjs
Mesh Renderer: 先勾选 Contribute GI. 然后在下方找到: 
Lightmap parameters

# 分配到 Terrain:
略

此网页修改与 2019-3-28


# ================================================================ #
#     Directional Mode
# ================================================================ #
有两种模式: Directional 和 Non-Directional.
默认设置为 Directional. 

当选用 Directional 模式, unity 生成两张 lightmap, 
第一张保存 texel 接收到的 光照的 强度和颜色,(这一张 和 Non-Directional 模式是相同的)
第二张保存 "入射光的主方向", 以及一个 因子: 从这个主方向打进来的 入射光 占全部入射光的 百分比 (大概这个意思)

# ----------- #
# Performance
Directional 需要两张 texture, 多用了运行时 显卡内存, 也增长了 烘焙时间.
但视觉效果提高了.

# ----------- # 
# Setting your lightmap mode
Lighting - Scene - Lightmapping settings - Directional Mode

也可在 设置在一个 Lighting Settings asset 中, 然后绑定给不同的 scene. 

# ----------- # 
# Using Directional Mode with additive loading
Unity can load Scenes additively. 这意味着你可使用 Multi-Scene editing,
当你 load Scenes additively, 它们都必须使用相同的 Directional Mode. 
这些载入的 scenes 没有被烘焙, 对这些 scene 使用相同的 Lightmap Parameters asset  可帮助你避免 设置上的 冲突. 

# ================================================================ #
#      Lightmaps and LOD
# ================================================================ #

未开始...




# ================================================================ #
#      Lightmapping and the Shader Meta Pass
# ================================================================ #
如果一个 go 想要支持 lightmap, 它所使用的 material 必须含有 Meta Pass;

meta pass 会将一个物体的 albedo 和 emission 信息 提供给 lightmapper;
即便后续烘焙出 光照信息;

meta pass 会被 lightmapper 调用两次, 一次用来收集 albedo, 一次用来收集 emission;

meta pass 在 texture-space 中提供 albedo 和 emission 信息; 

这些值与实时渲染中使用的值是分开的，这意味着您可以使用 Meta Pass 来控制 GameObject 从光照烘焙系统的角度来看的外观，而不会影响其在运行时的外观。

一个有效的例子是:
如果你希望 悬崖上的绿苔藓 在你的 lightmap 中生成夸张的绿色间接光,
但又不希望在 实时 pass 中为地形重新着色;
(没看懂...)


unity 的每一种 built-in materials 都实现了 meta pass;
standard shader 也包含 meta pass;

如果你在使用自定义 shader, 你需要手动实现一个 meta pass;

# Example Shader with a Meta pass
...


# Technical information
在 unity 所有默认 meta passes 中, 光照烘焙系统使用 meta pass 来处理 diffuse 和 metallic surface 的 albedo 信息;

lightmapper 处理 diffuse 传输, 且在每次反弹中使用 surface albedo;
几乎接近黑色的 metallic surface albedo 不反弹任何光线;

渲染 albedo 的 meta shader pass, 将 albedp 偏向具有金属色调的更亮的颜色。

电介质材质拥有 接近白色(无色)的 镜反颜色;
金属拥有 有色的 镜反颜色;

如果你想拥有不同的表现, 你应该自定义一个 meta pass;






















