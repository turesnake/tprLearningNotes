## =========================================================== #
#     HLSL in Unity
## =========================================================== #

# Adding HLSL code to your ShaderLab code
将 hlsl 代码块 放在 ShaderLab 代码中, 它们长这样:
# --
Pass {
      // ... the usual pass state setup ...
      
      HLSLPROGRAM
      // compilation directives for this snippet, e.g.:
      #pragma vertex vert
      #pragma fragment frag
      
      // the shader program itself
      
      ENDHLSL

      // ... the rest of pass ...
}

# HLSL syntax
hlsl 有两套语法: 老的 DirectX 9- 风格, 和更现代的 DirectX 10+ 风格.
区别主要在于 texture sampling 函数 如何工作:
-- 
    旧版本使用 sampler2D, tex2D() 以及类似的函数. 这种句法工作在所有平台
-- 
    DX10+ 使用 Texture2D, SamplerState and .Sample() 函数. 其中一部分无法在 opengl 平台上工作, 因为在 opengl 平台中, textures 和 samples 不是不同的 objs.

unity 的 shader libraries, 它们包含 预处理macros, 能替你管理这些不同点.


## =========================================================== #
#     Shader compilation: pragma directives
## =========================================================== #
可以使用 预处理指令 告诉编译器 如何编译一个 shader program. Pragma 指令 是一种 预处理指令. 

# Using pragma directives
默认, unity 不支持在 include files 中使用 pragma指令. 
若在 project settings - editor - shader compilation 中开启了 Caching Preprocessor 选项, 就可以使用 #include_with_pragmas 预处理指令. 
这个指令允许你将 pragma指令 放入 include files. 这对于 启用/禁用 多个文件的 shader debug 符号 特别有效.

# Supported pragma directives
# - Shader stages

使用下面这些 pragma指令, 告诉编译器 要将你的shader 的哪些部分,编译为不同的 shader stages
(其中, #pragma vertex 和 #pragma fragment 是必须实现的.)

# -- #pragma vertex name

# -- #pragma fragment name

# -- #pragma geometry name
     DX10 geometry shader, 这条指令会自动开启 #pragma target 4.0

# -- #pragma hull name
    DX11 hull shader, 这条指令会自动开启 #pragma target 5.0

# -- #pragma domain name
    DX11 domain shader, 这条指令会自动开启 #pragma target 5.0


# ------------------- 
# Shader variants and keywords
使用下列 pragma指令 告诉编译器如何处理 shader variants 和 keywords

# -- #pragma multi_compile ...
    为给定 keyword 创建一个 variant. 
    multi_compile shaders 的未使用的 variants 将被包含在 游戏 build 中.

# -- #pragma multi_compile_local ...
    类似上面的 multi_compile, 不过 keywords 是局部的.

# -- #pragma shader_feature ...
    为给定 keyword 创建一个 variant. 
    shader_feature shaders 的未使用的 variants 将 不会被包含在 游戏 build 中.

# -- #pragma shader_feature_local ...
    类似 shader_feature, 不过 keywords 是局部的.


# ------------------- 
# Shader model and GPU features
使用下列 pragma指令告诉编译器, 你的 shader target 是特殊的 shader model,
或者需要 特殊的 GPU features

# -- #pragma target name 
    选择哪种 shader model. ( 3.5, 4.0, 5.0 之类的 )

# -- #pragma require feature ...
    shader program 需要的 GPU features


# ------------------- 
# Graphics APIs
使用下列 pragma指令告诉编译器, 为特定的 图形API 编译你的 shader.

# -- #pragma only_renderers space separated names
    仅为给定的 图形API 编译本 shader program. 
    (如: d3d11 playstation xboxone xboxseries vulkan metal switch )

# -- #pragma exclude_renderers space separated names
    不要为后方列举的 图形API 编译本 shader


# -------------------
# Other pragma directives
# -- #pragma enable_d3d11_debug_symbols
    生成 shader debug symbols, 有时会 禁止优化.
    使用此命令调试外部工具中的 shader 代码。

    针对 Vulkan, DirectX 11 and 12,以及支持的 游戏主机, unity 生成 debug symbols and disables optimizations.

    针对  Metal and OpenGL, 默认情况下你就能 debug shaders.
    当你使用此指令,unity 将 禁用优化.

    警告: 使用此指令将导致 文件体积增大, shader性能降低. 在发行版程序中, 记得关闭此行代码.

# -- #pragma hardware_tier_variants renderer name

    没看懂...
    此声明只适用于 built-in 渲染管线.

# -- #pragma hlslcc_bytecode_disassembly
    将 disassembled HLSLcc bytecode 嵌入到 翻译的 shader 中

# -- #pragma disable_fastmath
    启用涉及 NaN处理 的精确 IEEE 754规则。
    此指令目前只被用于 Metal 平台

# -- #pragma glsl_es2
    在 GLSL shader 中设置,以生成一个 GLSL ES 1.0(OpenGL ES 2.0),
    即便 shader target 是 OpenGL ES 3.

# -- #pragma editor_sync_compilation
    强制同步编译. 这只会影响到 unity editor 中的渲染.

# tpr注:
    当在 editor 中测试类似 procedural draw 之类的 高强度渲染任务时, 如果不给 procedural 渲染用 shader
    设置此指令, unity 甚至整个电脑都会因此 歇菜.
        ---
    unity editor(不是 build) 拥有一个 feature: asynchronous shader compilation
    editor 只会在需要时才编译 修改过的 shader, 而不是修改后立即编译. 这能提高 editor 的响应. 
    当一个 shader 还在编译时, editor 会先用一个 青色/紫红色 dummy shader 来代替目标shader.
    直到目标 shader 编译好后, 再替换回去. 
        ---
    但问题是,这个 dummy shader 无法工作于 procedural drawing; 这会显著拖慢 drawing process, 
    甚至搞垮 unity 和 电脑. 
        ---
    一方面, 可通过 project settings 强制关闭 asynchronous shader compilation 功能. 
    另一方面, 可以为负责 procedural 渲染 的 shader, 单独关闭 asynchronous shader compilation 功能.
    方法就是使用本 指令. 




# -- #pragma enable_cbuffer
    当使用 CBUFFER_START(name) and CBUFFER_END macros 时, 从 HLSLSupport 发射 cbuffer(name).
    哪怕当前的平台不支持 cbuffers, 


# -------------------
# Unused pragma directives
下列 编译指令 不起任何作用, 可被安全地删除掉:
-- #pragma glsl
-- #pragma glsl_no_auto_normalization
-- #pragma profileoption
-- #pragma fragmentoption


## =========================================================== #
#  Shader compilation: targeting shader models and GPU features
## =========================================================== #
在 hlsl 中, shader model 是一种描述 gpu功能的 方式. 你可以让 unity 为特定功能的 gpu 编译 shaders, 要么指定 gpu 必须支持的 shader model, 要么指出 gpu 必须支持的 独立 features.


# Specifying a shader model or GPU feature
使用 pragma指令 来指定. 
分别演示了 shader model 和 独立features:
# --
#pragma target 3.5
#pragma require integers 2darray instancing

# Default compilation target
默认, unity 将 shader 编译为最低model: 2.5.
一些指令会把 这个最低值 抬高:

-- #pragma geometry               会设置最低 target 为 4.0
-- #pragma hull or #pragma domain 会设置最低 target 为 4.6

略...

# Supported ‘#pragma target’ names

#pragma target 2.0
#pragma target 2.5 (default)
#pragma target 3.0
#pragma target 3.5 (or es3.0)
#pragma target 4.0
#pragma target 4.5 (or es3.1)
#pragma target 4.6 (or gl4.1)
#pragma target 5.0

以上每个版本的 细节略, 去看原始文档...


# Supported ‘#pragma require’ names
#pragma require xxx  支持的 features 有:

-- interpolators10
-- interpolators15
-- interpolators32
    至少要有 10/15/32 vertex-to-fragment interpolators (插值器)

-- mrt4
-- mrt8
    至少支持 4/8 个 Multiple Render Targets,

-- derivatives
    要支持 ddx/ddy

-- samplelod
    Explicit texture LOD sampling (tex2Dlod / SampleLevel).

-- fragcoord
    Pixel location (XY on screen, ZW depth in clip space) input in pixel shader.

-- integers
    Integers are an actual data type, including bit/shift operations.

-- 2darray
    2D texture arrays (Texture2DArray).

-- cubearray
    Cubemap arrays (CubemapArray).

-- instancing
    SV_InstanceID input system value.

-- geometry
    DX10 geometry shaders.

-- compute
    Compute shaders, structured buffers, atomic operations.

-- randomwrite
    “random write” (UAV) textures.

-- tesshw
    gpu支持的硬件级 tessellation, 但不必是 tessellation shader stages
    (e.g. Metal supports tessellation, but not via shader stages).

-- tessellation
    Tessellation hull/domain shader stages.

-- msaatex
    有能力访问 multi-sampled textures (Texture2DMS in HLSL).

-- sparsetex
    Sparse textures with residency info (“Tier2” support in D3D terms; CheckAccessFullyMapped HLSL

-- framebufferfetch
    Framebuffer fetch – 有能力在 pix shader 中阅读 input pixel color


不同版本的 shader model 支持上述 features 的罗列:
2.5:       derivatives
3.0: 2.5 + interpolators10 + samplelod + fragcoord
3.5: 3.0 + interpolators15 + mrt4 + integers + 2darray + instancing
4.0: 3.5 + geometry
5.0: 4.0 + compute + randomwrite + tesshw + tessellation
4.5: 3.5 + compute + randomwrite
4.6: 4.0 + cubearray + tesshw + tessellation

注意, 
Direct3D 版本的 model 4.0 还添加了 mrt8,
Direct3D 版本的 model 5.0 还添加了 interpolators32 和 cubearray
然而,这些在许多移动平台上 不保证有用. 



## =========================================================== #
#  Shader compilation: targeting graphics APIs
## =========================================================== #
默认. unity 为所有 图形API 编译shader. 你可以告诉编译器 要/不要 支持某 图形API.
当你正在使用一些不被所有平台支持的 feature 时, 此指令很管用.

# Including or excluding graphics APIs
使用 #pragma only_renderers A B C  指定要支持的平台
使用 #pragma exclude_renderers A B C 指定不要支持的平台

# 支持的 图形API 名字:
d3d11:    Direct3D 11/12
glcore:   OpenGL 3.x/4.x
gles:     OpenGL ES 2.0
gles3:    OpenGL ES 3.x
metal:    iOS/Mac Metal
vulkan:   Vulkan
d3d11_9x: Direct3D 11 9.x feature level, 主要用于 WSA platforms
xboxone:  Xbox One
ps4:
n3ds:
wiiu:     



## =========================================================== #
#         Shader semantics   语义
## =========================================================== #
在编写 shader 程序时, input 和 output 变量 需要通过 semantics 设置它们的 "intent"(猜测是 使用目的) 
这是 hlsl 语言中的一个 标准概念. 

# Vertex shader input semantics
vertex shader 的每一个 input变量,都要设置自己的 semantics. 比如:
# --
float4 vertex : POSITION, // vertex position input
float2 uv     : TEXCOORD0 // first texture coordinate input

更多内容请看 后续页面...

# Fragment shader output semantics
通常, frag shader 输出一个颜色, 它的 semantic 被设置为 [SV_Target].
具体代码格式写为:
# --
fixed4 frag (v2f i) : SV_Target {
    ...
}

返回值也可以是个 struct 的, 例如:
# --
struct fragOutput {
    fixed4 color : SV_Target;
};
fragOutput frag (v2f i)
{
    ...
}

当返回值不止一个颜色时,使用 struct 就很不错.

额外的 frag shader 返回值 semantics 有:
[SV_TargetN] 
    (如 [SV_Target1], [SV_Target2])
    用于 Multiple render targets. 这些是 frag shader 写出的 额外的颜色信息. 当一次要向数个 render target 输出信息时, 会用到此 semantics. 
    其中:
        [SV_Target0] 就等于之前常用的 [SV_Target]

[SV_Depth]
    通常, frag shader 不会覆盖 z-buffer 的信息, 
    并且使用源自 常规三角形光栅化 的默认值 (???)
    然而, 为了某种效果, 可以从 frag shader 输出 自定义的, 每个像素的 z 深度值.

    注意,在需要 gpu 上, 使用此 semantics 会关闭一些 和 depth buffer 相关的优化. 所以,除非你知道你在干嘛, 否则不要去复写 z-buffer. 
    由 SV_Depth 招致的额外成本 取决于 不同的 gpu架构. 但整体上, 这个成本 和 alpha testing 的很相似 ( 在 hlsl 中使用 clip() 函数 实现 alpha testing )

    最好在所有常规 不透明shader 之后, 再去执行 SV_Depth shader 的渲染.
    ( 例如, 可通过 AlphaTest rendering queue 来实现这件事 )

    返回的 深度值, 需要为单个 float.


# Vertex shader outputs and fragment shader inputs
vertex shader 需要输出各顶点的 CSPos (剪切空间坐标),(以便 gpu知道在屏幕的哪个位置去光栅化它.) 以及顶点的 深度值. 
上面这组信息( cspos + 深度值 ) 需要被标识 [SV_POSITION] semantic, 其类型为 float4.

由 vertex shader 生成的其它任何输出值 (“interpolators” or “varyings”), 这些顶点值都会在后面的 三角形光栅化过程中 被执行插值计算, 计算出三角形中每个 像素的值, 这些值将成为 frag shader 的 input 变量.

许多现代化 gpu,并不关心这些变量的 semantics.
但一些 旧的系统( 尤其是 shader model 2 GPUs on Direct3D 9 ) 确实对这些 semantics 存在具体的要求:

-- 
    [TEXCOORD0], [TEXCOORD1] 等 被用于指示 任意高精度的值,比如 texture coordinates(猜测是 uv), 或者 position.
--
    [COLOR0] and [COLOR1] 等 用于低精度值, 0–1 range data (比如简单的颜色值).


为了获得最好的平台支持, 将 vertex shader 的输出值, frag shader 的输入值,标记为 [TEXCOORDn] semantics.


# - Interpolator count limits
从 vertex shader 到 frag shader 间能传递的 "需要插值的" 变量的数量是有限的. 这个限制取决于 平台和gpu,通常为:
--
    最多 8 个:
    OpenGL ES 2.0 (Android), Direct3D 11 9.x level (Windows Phone) and Direct3D 9 shader model 2.0 (old PCs).
    这里,8个变量中的每一个, 都能是一个 4元素向量, 所以,有些 shader 会把零碎的数据打包起来,压入这些变量中. 
    比如, 一个 texture coordnate值(uv) 可用一个 float4 变量 来传递 (xy记录 u值, zw记录 v值 )
--
    最多 10 个:
    Direct3D 9 shader model 3.0 (#pragma target 3.0).
--
    最多 16 个:
    OpenGL ES 3.0 (Android), Metal (iOS).
--
    最多 32 个:
    Direct3D 10 shader model 4.0 (#pragma target 4.0).


无论用于哪个平台, 都请尽量减少两 shader 间通信的 变量的数量,这样能提高性能 (毕竟这些变量 都要在 光栅化中 插值到每个像素上去)


# Other special semantics
frag shader 可以接受 像素的 SSPos (屏幕空间pos), 它的 semantics 为 [VPOS].
这个 feature 只在 shader model 3.0 及之后版本 才存在. 

所以想要使用此功能,记得加上:
#pragma target 3.0

在不同的平台上, 屏幕空间pos 的基本类型是不相同的, 故为了最大便携性, 推荐使用 [UNITY_VPOS_TYPE] 宏 (在大部分平台,它的类型为 float4, 在 Direct3D 9, 则为 float2) 具体用法为:

# --
fixed4 frag (v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_Target
{ ... }


额外的, 使用 [VPOS] semantic 使得 程序很难在 vertex-to-frag 通道中 同时拥有 CSPos (SV_POSITION) 和 VPOS. 
( 注: CSPos 是顶点信息, VPOS 是逐像素信息 )

所以, vertex shader 应该将 CSPos 当作一个 特殊的 "out" 类型的参数来 实现输出 (类似 C# 中的 out参数), 

就像这个例子:
# --
// 注意:并未在此 struct 中实现 [SV_POSITION]
struct v2f {
    float2 uv : TEXCOORD0;
};

v2f vert (
    float4 vertex     : POSITION,   // vertex position input
    float2 uv         : TEXCOORD0,  // texture coordinate input
    out float4 outpos : SV_POSITION // clip space position output
                                    // 注意, [SV_POSITION] 在这个被实现
                                    // 这里使用了 "out"参数
    )
{
    v2f o;
    o.uv = uv;
    outpos = UnityObjectToClipPos(vertex);
    return o;
}

fixed4 frag (v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_Target
{
    // 这里能用的输入值就两个:
    // 各像素的 uv 值:        i.uv
    // 各像素的 屏幕空间pos:  screenPos
    // vert shader 中输出的 [SV_POSITION] 参数: output, 似乎无法被访问 ?
    // 至少在本代码中没有被用到
    ...
}


# Face orientation: VFACE
frag shader 可以接收一种变量, 它记录了 本像素所在的三角形的要渲染的那个面,是否正朝向相机.  当我们需要渲染一个 双面都可见的几何体时,这个变量很管用., 比如纸张这种很薄的物体. 使用 [VFACE] 的变量, 在表达正面时 值为正数, 反之负数.

此 feature 要求至少 shader model 3.0 

例子如下:
# --
// turn off backface culling
// 现在, 背面也会被渲染到了
Cull Off 

fixed4 frag (fixed facing : VFACE) : SV_Target
{
    // VFACE input positive for frontbaces,
    // negative for backfaces. Output one
    // of the two colors depending on that.
    return facing > 0 ? _ColorFront : _ColorBack;
}


# Vertex ID:  
[SV_VertexID]
vertex shader 可接收一种变量, 它的类型是 无符号整型, 含义为 顶点的idx. 
当你想从 texture 或 computerbuffer 中获得获取 额外的 逐顶点数据时, 很管用.

此 feature 需要至少支持 DX10 (shader model 4.0) and GLCore / OpenGL ES 3
所以必须写:
#pragma target 3.5

案例:
# --
struct v2f {
    fixed4 color : TEXCOORD0;
    float4 pos   : SV_POSITION;
};

v2f vert (
    float4 vertex : POSITION, // vertex position input
    uint vid      : SV_VertexID // vertex ID, needs to be uint
    )
{
    v2f o;
    o.pos = UnityObjectToClipPos(vertex);
    // output funky colors based on vertex ID
    float f = (float)vid;
    o.color = half4(sin(f/10),sin(f/100),sin(f/1000),0) * 0.5 + 0.5;
    return o;
}



## =========================================================== #
#        Accessing shader properties in Cg/HLSL
## =========================================================== #
上文介绍的 material properties 被定义在 shader - Properties 块中,
若想在 shader program 中访问这些 mat properties, 
你需要声明一个 同名的变量, 并为其分配合适的 类型.

# 例如,已经存在以下 material properties:
_MyColor   ("Some Color",  Color)  = (1,1,1,1) 
_MyVector  ("Some Vector", Vector) = (0,0,0,0) 
_MyFloat   ("My float",    Float)  = 0.5 
_MyTexture ("Texture",     2D)     = "white" {} 
_MyCubemap ("Cubemap",     CUBE)   = "" {} 

# 它们可在 hlsl 代码内被声明为:
fixed4 _MyColor; // low precision type is usually enough for colors
float4 _MyVector;
float _MyFloat; 
sampler2D _MyTexture;
samplerCUBE _MyCubemap;

# hlsl代码 也能接收 uniform 关键字, 不过完全可以不写:
uniform float4 _MyColor;

# 匹配规则
--
    properties: Color, Vector 对应: float4, half4 or fixed4
--
    properties: Range and Float 对应:  float, half or fixed
--
    properties: Texture 对应: sampler2D
--
    properties: Cubemaps 对应: samplerCUBE
--
    properties: 3D textures 对应: sampler3D

# How property values are provided to shaders
从下面这些地方寻找到 shader properties 值, 并将它们提供给 shaders
--
    设置在  MaterialPropertyBlock 中的 Per-Renderer values (每个渲染器的值)
    这些往往是  “per-instance” data (一些共享同一个 material 的 objs 的 自定义 tint color 值)
--
    设置在 Material 面板中, 被用于 被渲染的物体
--
    Global shader properties, 
    要么由 unity 自己的 rendering code 设置,
    要么 从你写的 c#脚本中 ( 如 Shader.SetGlobalTexture )

优先权: 
per-instance data 能覆盖其它一切值. 其次是 Material data, 最后是 Global shader properties.
最后, 如果这三处都没找到 定义的值, 就使用默认值 ( float:0, color:black, texture:empty white texture )


# Serialized and Runtime Material properties
Material 可同时包含 序列化的值, 和 运行时可调整的 properties 值.

序列化的 properties 全被定义在 shader Properties 块中.
通常, 这些值需要被存储进 material, 并可通过 material inspector 修改.

material 还能拥有一些 properties, 它们可被 shader 使用, 但没有被声明在 shader Properties 块中. 通常,这些 properties 是通过 c#脚本 在运行时设置的. (如:  Material.SetColor ) 
注意: 矩阵 和 arrays 只能存在于 "非序列化的 运行时 properties".
(因为并不存在什么方法 能在 shader Properties 块中 定义这两种类型的数据 )


# Special Texture properties
每一个被设置为 shader/material property 的 texture, unity 还设置一些 额外的信息, 在额外的 vector properties 中.

# - Texture tiling & offset
# 命名格式:
{TextureName}_ST

    一个 float4 property, 包含 texture 的 Tiling and Offset 信息:

    x contains X tiling value
    y contains Y tiling value
    z contains X offset value
    w contains Y offset value

若存在一个名为 "_MainTex" 的 texture property, 
那就会伴生一个名为 "_MainTex_ST" 的 vector property.

# - Texture size
# 命名格式:
{TextureName}_TexelSize

    一个 float4 property, 包含 texture 的尺寸信息:

    x contains 1.0/width
    y contains 1.0/height
    z contains width
    w contains height

# - Texture HDR parameters
# 命名格式:
{TextureName}_HDR

    一个 float4 property, 包含如何 根据所使用的 颜色空间, 解码一个潜在的 HDR ( 如 RGBM-encoded )

    查看 UnityCG.cginc 文件中的 DecodeHDR 函数
    (hlsl 版的没提)
    

# Color spaces and color/vector shader data
当使用 线性颜色空间, 所有 material color properties 都以 sRGB 颜色提供, 
但它们在被传入 shader 时,会被转为为 线性空间.

例如: 如果 shader properties 块中包含一个名为 "MyColor" 的 Color property, 
那么, 那个同名的 hlsl 变量, 将会得到它的 线性空间颜色值.

被标记为 Float 或 Vector 类型的 properties, 默认不执行 颜色空间转换. 这两个类型通常被认为 不是用来装 颜色信息的. 
可以为 Float / vector properties 添加 [Gamma] attribute 来指示它们位于 sRGB 空间, 就像 Color 类型那样


## =========================================================== #
#      Providing vertex data to vertex programs
## =========================================================== #
针对 hlsl vert shader 程序, Mesh 中的 顶点数据被当作参数 传入 vert 函数中.
vert 函数的每一个参数, 都需要标注 semantics. 
比如, POSITION 意味着这个参数是 顶点坐标值, NORMAL 意味着这是参数是 顶点法线值.

通常, 这些参数被定义在一个 struct 中, 一个 include 文件中, 预定了一些这类 struct.
在大部分场合中, 它们都够用了. 
这些预定义的 struct 是:
--  
    appdata_base: 
                position, normal, one texture coordinate.
-- 
    appdata_tan: 
                position, tangent, normal, one texture coordinate.
-- 
    appdata_full:
                 position, tangent, normal, four texture coordinates, color.

# ------------ #
你也可以自定义一个.
需要注意的 semantics 规则有:
--
    POSITION 
        顶点坐标, 通常为 float3 or float4.
--
    NORMAL 
        顶点法线, 通常为 float3.
--  
    TEXCOORD0 
        第一个 UV coordinate, 通常为 float2, float3 or float4.
        一般只取其xy分量:

            float2 baseUV     : TEXCOORD0;
            
--
    TEXCOORD1, TEXCOORD2 和 TEXCOORD3 
        分别是第2,第3,第4个 UV coordinates

        按照 catlike 所说, TEXCOORD1 容纳的是 lightmap 的uv值:

            float2 lightMapUV : TEXCOORD1;

        TEXCOORD2 和 TEXCOORD3 的意义未知.

--
    TANGENT 
        切线向量 (用于 normal mapping), 通常为 a float4.
--
    COLOR 
        逐顶点颜色, 通常为 float4.

# ------------ #
当 mesh 数据包含的信息 少于 vect shader 需要的信息时,  那些缺失的信息会被填充以0.
其中 w 分量是例外, 它的默认值是 1.

比如, mesh texture coordinates 通常是 2D向量, 只含有 xy分量. 如果 vert shader 声明了一个 TEXCOORD0 semantic的, 类型为 float4 的参数, 那么 vert函数将收到一个内容为 (x,y,0,1) 的 float4 参数.


想要把这些 顶点信息 可视化,可查看:
https://docs.unity.cn/2021.1/Documentation/Manual/built-in-shader-examples-vertex-data.html


## =========================================================== #
#      Built-in shader include files
## =========================================================== #

略过 CG 语言的 inlcude 文件.


## =========================================================== #
#      Built-in macros
## =========================================================== #
在编译 shader程序时, unity 定义了一些 预处理宏,

[本文中的宏也许都适用于_CG_代码,而不是_HLSL_代码...]

# -------------------- #
# Target platform

SHADER_API_D3D11	    Direct3D 11
SHADER_API_GLCORE	    Desktop OpenGL “core” (GL 3/4)
SHADER_API_GLES	        OpenGL ES 2.0
SHADER_API_GLES3	    OpenGL ES 3.0/3.1
SHADER_API_METAL	    iOS/Mac Metal
SHADER_API_VULKAN	    Vulkan
SHADER_API_D3D11_9X	    Direct3D 11 “feature level 9.x” target 
                        for Universal Windows Platform
SHADER_API_PS4	        PlayStation 4 SHADER_API_PSSL is also defined.
SHADER_API_XBOXONE	    Xbox One
#

SHADER_API_MOBILE       被定义于所有移动平台 (GLES, GLES3, METAL).

SHADER_TARGET_GLSL      当 target shader 语言是 GLSL 是被定义
                        (always true for OpenGL/GLES platforms).


# -------------------- #
# Shader target model

SHADER_TARGET   
    
    被定义为一个数值,它等于 #pragma target 设置的值.
    比如, #pragma target 3.0
    此时 SHADER_TARGET 的值为 30
                    
    可在 shader代码中使用此宏来 做检测.如下:

    #if SHADER_TARGET < 30
        // less than Shader model 3.0:
        // shader 能力很有限, 需要做一些近似
    #else
        // 性能不错,可以做更好的效果
    #endif


# -------------------- #
# Unity version

UNITY_VERSION 

    被定义为一个数值, 表示 unity 版本值.比如, UNITY_VERSION 值为 501, 意味着: Unity 5.0.1
    此宏可用于 版本检测

# -------------------- #
# Shader stage being compiled

在编译每个 shader stage 时, 会定义一组 预处理宏:
SHADER_STAGE_VERTEX, 
SHADER_STAGE_FRAGMENT, 
SHADER_STAGE_DOMAIN, 
SHADER_STAGE_HULL, 
SHADER_STAGE_GEOMETRY, 
SHADER_STAGE_COMPUTE

通常, 当需要在 pix shader 和 compute shader 之间分享 shader 代码时, 这些宏很有用. 可以通过这些宏来检测 当前正在什么阶段.

# Platform difference helpers

不鼓励直接使用这些平台宏，因为它们并不总是有助于代码的未来验证。
例如，如果您正在编写一个检查 D3D11 的着色器，您可能希望确保将来该检查扩展到包括Vulkan。相反，Unity定义了几个helper宏,在: HLSLSupport.cginc

UNITY_BRANCH
    在条件语句之前添加这个命令，告诉编译器应该将它编译成一个实际的分支。
    在 hlsl 平台, 这个宏会被替换为: [branch]  这个 hlsl 自带的指令;
    ---
    如果不添加, 有些 if...else... 条件分支语句会被编译器优化掉

UNITY_FLATTEN
    在条件语句之前添加这个命令，告诉编译器应该将它展平, 以避免生成一个实际的分支。
    在 hlsl 平台, 扩展到 [flatten]  (???)

UNITY_NO_SCREENSPACE_SHADOWS
    此宏会在 不支持 cascade 屏幕空间 shadowmap 的平台(移动平台) 被定义

UNITY_NO_LINEAR_COLORSPACE
    此宏会在 不支持 线性颜色空间 的平台(移动平台) 被定义

UNITY_NO_RGBM
    此宏会在 不支持 "lightmaps 的 RGBM 压缩" 的平台(移动平台) 被定义

UNITY_NO_DXT5nm
    此宏会在 不支持 "DXT5nm 法线贴图压缩" 的平台(移动平台) 被定义

UNITY_FRAMEBUFFER_FETCH_AVAILABLE
    此宏会在 支持 "抓取 framebuffer 颜色的功能" 的平台 被定义
    (generally iOS platforms - OpenGL ES 2.0, 3.0 and Metal).

UNITY_USE_RGBA_FOR_POINT_SHADOWS
    此宏会在 支持如下功能的平台 被定义. 功能为:
    在点光源的 shadowmap 中使用具有编码深度的 RGBA texture.

    (别的平台会使用: 单通道浮点数 texture)

UNITY_ATTEN_CHANNEL
    定义了 "light attenuation texture" 中的哪个通道包含数据.
    通常被用于 逐像素光照计算代码中.
    可被定义为 'r' 或 'a'

UNITY_HALF_TEXEL_OFFSET
    此宏会在这样的平台被定义:
    它需要 在将 texels 映射到 pixels 过程中, 进行半个像素的偏移.
    ( 如: Direct3D 9).

UNITY_UV_STARTS_AT_TOP
    此宏总被定义为 0 或 1.
    若为1:
        这个平台的 texture 的顶部一行的 的 UV.V 值为 0.

    在 Direct3D 类平台上, 顶部一行的 v 值为 1
    在 OpenGL 类平台上, 顶部一行的 v 值为 0

UNITY_MIGHT_NOT_HAVE_DEPTH_Texture
    此宏会在这样的平台被定义:
    此平台可通过 手动将 深度值 渲染到一个 texture 中, 来模拟 shadowmaps 或 depth texture.

    (也就是它自己没有 硬件层支持的 depth texture)

UNITY_PROJ_COORD(a)
    通过参数 提供一个 4分量的向量, 此宏返回一个 适合投影纹理读取的 纹理坐标。
    在大多数平台上，它直接返回给定的值。

# 重要 !!!
UNITY_NEAR_CLIP_VALUE
    此宏被定义为:
        a platform independent near clipping plane value for the clip space
        平台无关的, clip-space 中的 近平面的值
        ---
        tpr注:
            其实它不是 .z 值, 而是 .z/.w 值, 也就是 "depth" 深度值.

    文档中写:
        Direct3D类平台 使用 0.0,
        OpenGL类平台 使用 -1.0
    ---
    tpr注: 此描述似乎是错误的:
        由于 D3D 平台 往往开启了 reversed-z, 所以它们的 clip-space .z 值区间是: [1->0]
        所以,按照源码展示, 此宏的正确值是:
        --
            此值在 D3D 风格平台中    设为 1.0,  如: D3D11, Metal, Switch, Vulkan
        --
            此值在 OpenGL 风格平台中 设为 -1.0, 如: GLCore, GLES2, GLES3



UNITY_VPOS_TYPE
    定义一个数据类型, 此数据为 输入的像素坐标(VPOS)
    (其实就是 屏幕空间 像素坐标, 是个2d数据 )
    (参考别处文件描述的, VPOS 的使用)

    D3D9 平台中,此类型为 float2
    别的平台上为 float4

UNITY_CAN_COMPILE_TESSELLATION
    此宏会在这样的平台被定义:
    它的 shader 编译器能理解 tessellation Shader HLSL 语义.
    (currently only D3D11).

UNITY_INITIALIZE_OUTPUT(type,name)
    将 参数name 绑定的变量, 初始化一个 类型为 参数type, 值为0 的变量.

UNITY_COMPILER_HLSL
UNITY_COMPILER_HLSL2GLSL
UNITY_COMPILER_CG
    此宏能指示, 当前正在被使用的 shader编译器 是哪个.


UNITY_REVERSED_Z
    此宏会在这样的平台被定义:
    这个平台使用 reverse Z buffer. 
    ( 深度值被存储为 1->0, 而不是 0->1 )


# -------------------- #
# Shadow mapping macros
在不同平台上, 声明和采样 shadowmap 可能存在很大不同之处. 
unity 有几个宏来帮助这件事:

UNITY_DECLARE_SHADOWMAP(tex)
       此宏 声明一个 shadowmap texture 变量, 它的名字由参数来设置

UNITY_SAMPLE_SHADOW(tex,uv)
    参数 tex 表示 shadowmap texture 的名字
    参数 uv, 其xy分量是 texture 坐标值, z分量是 要比较的深度值

    此宏执行 shadowmap 采样,返回一个 float值, 这个阴影项的值在 [0,1] 区间, 


UNITY_SAMPLE_SHADOW_PROJ(tex,uv)
    和上一个相似, 但是执行一个 带投影的 shadowmap 读取操作.
    参数 uv 是个 float4.  xyz分量都被 w分量相除 来执行查找


注意,不是所有 显卡都支持 shadowmap 技术. 使用 e SystemInfo.SupportsRenderTextureFormat  来检测.


# -------------------- #
# Constant buffer macros
Direct3D 11 将所有 shader 变量 都打包进入 “constant buffers”.
大部分 unity 内建变量 都已经被打包, 
但你自己的 shader 中的变量, 根据预期的更新频率, 将他们放在一个单独的 constant buffer 中也许更好.

使用 CBUFFER_START(name) 和 CBUFFER_END 宏:
# --
CBUFFER_START( MyRarelyUpdatedVariables )
    float4 _SomeGlobalValue;
    ...
CBUFFER_END
# ==

    CBUFFER_START 宏的参数 name, 是定义的这个 cbuffer 的name



# -------------------- #
# Texture/Sampler declaration macros

通常,你会在 shader代码中使用 texture2D 来声明 Texture 和 Sampler pair.
但在某些平台(DX11),  texture 和 sampler 是不同的 objs, 而且 可用的 sampler 的最大值也是受限的. 

unity 拥有一些宏, 它们可以只为你声明 texture, 而不带 samplers. 然后使用另一个 texture 的 sampler 来对这个新的 texture 进行采样.

如果你确实遇到了 sampler 数量限制, 同时你还知道, 你的一些 textures 事实上可以共享一个 sampler, 那么你就能使用这个功能.
(sampler 定义了 滤波模式 和 wrapping 模式)

UNITY_DECLARE_TEX2D(name)
    声明一个 texture 和 sampler pair

UNITY_DECLARE_TEX2D_NOSAMPLER(name)
    只声明一个 texture, 不带 sampler

UNITY_DECLARE_TEX2DARRAY(name)
    声明一个 Texture array Sampler 变量
    (猜测就是个 texture array, 同时还带了 sampler, 至于带几个不知道)

UNITY_SAMPLE_TEX2D(name,uv)
    从一个 texture 和 sampler pair 上进行采样.
    使用参数 uv 提供的 坐标值

UNITY_SAMPLE_TEX2D_SAMPLER( name, samplername, uv )
    从 参数name 指向的 texture 上进行采样,
    使用 参数samplername 指向的 sampler, 它来自别的 texture

 
UNITY_SAMPLE_TEX2DARRAY(name,uv)
    使用一个 float3 uv, 在一个 texture array 上进行采样.
    参数uv.z 分量 是一个 idx, 指向 texture array 中的某个 texture

UNITY_SAMPLE_TEX2DARRAY_LOD(name,uv,lod)
    从一个 texture array 上进行采样, 
    使用一个 显式的 mipmap level值 (猜测是参数 lod)


更详细内容,推荐阅读下文的: Using sampler states


# -------------------- #
# Surface Shader pass indicators
在编译 Surface Shader 时, 它为不同的 passes 生成了一堆代码 以用来执行光照计算.
当在编译每一个 pass 时, 下面的某一个宏 会被定义:

UNITY_PASS_FORWARDBASE
    Forward rendering base pass (main directional light, lightmaps, SH).

UNITY_PASS_FORWARDADD
    Forward rendering additive pass (one light per pass).

UNITY_PASS_DEFERRED
    Deferred shading pass (renders g-buffer).

UNITY_PASS_SHADOWCASTER
    Shadow caster and depth Texture rendering pass.

UNITY_PASS_PREPASSBASE
    Legacy deferred lighting base pass (renders normals and specular exponent).

UNITY_PASS_PREPASSFINAL
    Legacy deferred lighting final pass (applies lighting and Textures).


# -------------------- #
# Disable Auto-Upgrade

UNITY_SHADER_NO_UPGRADE
    此宏允许你 禁用 "unity自动升级 或者 修改你的shader文件"


# -------------------- #
# Depth Texture helper macros
大部分时候, depth texture 被用来渲染 出发自相机的 深度值.
一些 include 文件中, 包含了一些宏, 来处理这类事件

UNITY_TRANSFER_DEPTH(o):
    计算顶点的 eye-space depth, 并将它输出到 参数o
    参数o 必须是一个 float2 变量.

    当一个 vert shader 要写入一个 depth texture 时, 使用此宏

    如果那个平台 天生就支持 depth textures, 这个宏将什么都不做, 
    因为这个平台会隐式渲染 z-buffer

UNITY_OUTPUT_DEPTH(i):
    参数i 是一个 float2, 猜测是指定一个 2d坐标. 
    此宏返回 i值的 eye-space depth. 

    当一个 frag shader 要写入一个 depth texture 时, 使用此宏

    如果那个平台天生支持 depth texture, 这个宏将始终返回0, 
    因为这个平台会隐式渲染 z-buffer

COMPUTE_EYEDEPTH(i):
    此宏 计算顶点的 eye-space depth, 并将其写入 o (????????)

[感觉文档写错了...]

    当一个 vert shader 没有写入一个 depth texture 时, 使用此宏

DECODE_EYEDEPTH(i) / LinearEyeDepth(i): 
    猜测参数i 表示一个 depth texture.
    给定源自 depth texture i 中的高精度的值. 返回对应的 eye-space depth.

Linear01Depth(i): 
    猜测参数i 表示一个 depth texture.
    给定源自 depth texture i 中的高精度的值. 返回一个对应的 线性深度值, 在区间 [0, 1] 之间

注意: 
在 DX11/12, PS4, XboxOne and Metal, z-buffer 值区间在 1->0.
同时 UNITY_REVERSED_Z 宏会被开启.
在别的空间, 深度值区间为 0->1.


## =========================================================== #
#      Built-in shader helper functions
## =========================================================== #

[全是.cginc文件里的函数]
[只罗列,部分不翻译了]

# Functions declared in UnityCG.cginc

# - Vertex transformation functions in UnityCG.cginc

float4 UnityObjectToClipPos(float3 pos)
float3 UnityObjectToViewPos(float3 pos)

# - Generic helper functions in UnityCG.cginc

float3 WorldSpaceViewDir (float4 v)
float3 ObjSpaceViewDir (float4 v)
float2 ParallaxOffset (half h, half height, half3 viewDir)
fixed Luminance (fixed3 c)
fixed3 DecodeLightmap (fixed4 color)
float4 EncodeFloatRGBA (float v)
float DecodeFloatRGBA (float4 enc)
float2 EncodeFloatRG (float v)
float DecodeFloatRG (float2 enc)
float2 EncodeViewNormalStereo (float3 n)
float3 DecodeViewNormalStereo (float4 enc4)

# - Forward rendering helper functions in UnityCG.cginc

float3 WorldSpaceLightDir (float4 v)
float3 ObjSpaceLightDir (float4 v)
float3 Shade4PointLights (...)

# - Screen-space helper functions in UnityCG.cginc

float4 ComputeScreenPos (float4 clipPos)
float4 ComputeGrabScreenPos (float4 clipPos)

# - Vertex-lit helper functions in UnityCG.cginc

float3 ShadeVertexLights (float4 vertex, float3 normal)


## =========================================================== #
#      Built-in shader variables
## =========================================================== #

[全是.cginc文件里的内容]
[只罗列,部分不翻译了]

# Transformations

UNITY_MATRIX_MVP
UNITY_MATRIX_MV
UNITY_MATRIX_V
UNITY_MATRIX_P
UNITY_MATRIX_VP
UNITY_MATRIX_T_MV
UNITY_MATRIX_IT_MV
unity_ObjectToWorld
unity_WorldToObject

# Camera and screen

_WorldSpaceCameraPos
_ProjectionParams
_ScreenParams
_ZBufferParams
unity_OrthoParams
unity_CameraProjection
unity_CameraInvProjection
unity_CameraWorldClipPlanes[6]

# Time

_Time
_SinTime
_CosTime
unity_DeltaTime

# Lighting

_LightColor0 (declared in UnityLightingCommon.cginc)
_WorldSpaceLightPos0

unity_4LightPosX0,
unity_4LightPosY0, 
unity_4LightPosZ0

unity_4LightAtten0
unity_LightColor
unity_WorldToShadow


_LightColor
unity_WorldToLight (declared in AutoLight.cginc)
unity_WorldToShadow


unity_LightColor
unity_LightPosition
unity_LightAtten
unity_SpotDirection

# Lightmaps

unity_Lightmap
unity_LightmapST

# Fog and Ambient

unity_AmbientSky
unity_AmbientEquator
unity_AmbientGround
UNITY_LIGHTMODEL_AMBIENT
unity_FogColor
unity_FogParams

# Various

unity_LODFade
_TextureSampleAdd


## =========================================================== #
#      Shader variants and keywords
## =========================================================== #
可以编写一些 shader 小片段, 然后拿来做共享代码,.但当一个 keyword 被开启/禁用 时, 这个代码段会被编程成不同的 variants. 

借用 variants, 可以将同一个 shader 分配给不同的 materials, 然后通过 keywords 的设置,获得不同的版本. 这意味着你的 shader代码只需编写一次, 就能最终编译获得多个 shader assets. 

通过 启用/禁用 keywords, 你还可以通过 variants 来在运行时修改 shader 行为.

拥有大量 variants 的 shader 被称为 “mega shaders” or “uber shaders”.
unity 内置的 Standard Shader 就是一个 mega shader.

# --------------------------------- #
# Using shader variants and keywords

# - Creating shader variants
使用以下某个 progma指令 来新建 shader variant:

    #pragma multi_compile
    #pragma multi_compile_local
    #pragma shader_feature
    #pragma shader_feature_local

可在 着色shader 和 compute shader 中使用它们.

如果某个 keyword 只影响一个 shader stage, 可以对这些 指令 添加一个后缀, 来降低冗余的编译工作. 
具体请看下方的 Stage-specific keyword directives 部分.

然后,针对不同的 预处理指令, unity 会将这些 shader代码 编译多次.

# - Enabling and disabling shader keywords
使用如下 API 来 启用/禁用 shader keywords:

Shader.EnableKeyword: 
Shader.DisableKeyword: 
                enable/disable a global keyword

CommandBuffer.EnableShaderKeyword: 
CommandBuffer.DisableShaderKeyword: 
                use a CommandBuffer to enable/disable a global keyword

Material.EnableKeyword: 
Material.DisableKeyword: 
                enable/disable a local keyword for a regular shader

ComputeShader.EnableKeyword: 
ComputeShader.DisableKeyword:
                enable/disable a local keyword for a compute shader

当你 启用/禁用 一个 keyword, unity会去使用对应的 variant.

# - Stripping shader variants from your build
可以阻止某些 variants 进入 build 包中. 一次来减少 build时间, 减小文件尺寸.

使用如下 APIs:

IPreprocessShaders.OnProcessShader:         
        在 unity 将一个 常规shader 编译进 build 之前, 可调用的 callback

IPreprocessComputeShaders.OnProcessComputeShader: 
        在 unity 将一个 compute shader 编译进 build 之前, 可调用的 callback

更多内容,查看此文章:
https://blog.unity.com/technology/stripping-scriptable-shader-variants


# --------------------------------- #
# How multi_compile works
示范代码:
# --
#pragma multi_compile FANCY_STUFF_OFF FANCY_STUFF_ON

    此指令 生成两个 variants, 一个定义了 FANCY_STUFF_OFF, 另一个定义了 FANCY_STUFF_ON.
    在运行时, 基于 material keyword (局部) 或 全局 keyword, unity 其中这两个 variant 中的一个. 
    如果这两个 keyword 一个也没有启用, 则 unity 会默认使用 progma指令 中排第一个的,
    也就是 FANCY_STUFF_OFF

在单个 multi_compile 指令中, 可以放入任意多个 keywords,例如:
# --
#pragma multi_compile SIMPLE_SHADING BETTER_SHADING GOOD_SHADING BEST_SHADING

若不想为 variant 生成 预定义的宏, 可以在这些 kwywords 的第一个位置 放一个 "__".
这只是一种编程技巧. 关键字 "__" 没有任何特殊功能, 使用它只是为了节省 keywords 总数.
在一个项目中, 可自定义的 keywords 数量总数是有上限的 (下文会提),
举例:
# --
#pragma multi_compile __ FOO_ON

    这个指令生成了 2 个 variants, 第一个定义了 keyword: __ (它不代表任何意义)
    第二个定义了 keyword: FOO_ON (我们想要的一个变体)

    在实际使用时, 如果我们没有开启 FOO_ON, 则 unity 会自动使用 第一个 variant,
    它携带一个 __,  不起任何作用. (这正是我们想要的)


# --------------------------------- #
# Difference between shader_feature and multi_compile

两者很类似, 唯一的区别是:
shader_feature 中未使用的 variants, 不会被包含进最终的 build 包中.
而 multi_compile 中的所有 variants, 不管是否被使用, 都会被包含进 build 包中.

所以
针对 material keyword (局部), 最好用 shader_feature
针对 全局 keyword, 最好用 multi_compile

此外,还存在一个只有一个 keyword 的写法:
# --
#pragma shader_feature FANCY_STUFF

    它只是:
#pragma shader_feature _ FANCY_STUFF
    的简写形式.


# --------------------------------- #
# Combining several multi_compile lines
看如下代码:
# --
#pragma multi_compile A B C
#pragma multi_compile D E

    第一行会生成 3 个变体, 但叠加第二行的 2 个变体后, 最终会获得 3*2=6 个变体!

所以, 当你定义了 过多的 multi_compile 指令, 最终生成的 variants 数量是非常惊人的.
比如, 10 行指令, 每行 2 个变体, 最终就会膨胀到 1024 个 variants


# +++++++++++++++++++++++++++++++++ ###
#       Keyword limits
# --------------------------------- ###
unity 中, 一个项目内的 全局 keywords 数量的上限是 384 个. 而且 unity 自己还使用了 60 个.
只有 全局 keyword 才占据这个数量名额. 
所以要小心使用.

# - Local keywords
为了突破 全局keyword 数量限制, 可以改用 局部 keyword (material keyword):
# --
shader_feature_local
multi_compile_local

这两个 局部指令 只在 shader 内定义自己的 keyword. 

当开始使用 局部kewyord 时, 程序性能可能发生变化, 但这个变化 取决于 项目是如何设置的.
一个 shader 所关联的 局部/全局 keywords 数量 影响了性能: 推荐多使用 局部的, 少用全局的.

如果 局部keyword 和 全局keyword 同名, 此时 unity 会优先使用 局部的.

# -- Limitations  
--
    那些用来改写 全局 keyword 的 API, 不能改写 局部 keyword
    (比如: Shader.EnableKeyword or CommandBuffer.EnableShaderKeyword)
--
    每个 shader 最多能有 64 个 局部 keywords
--
    If a Material has a local keyword enabled, and its shader changes to one that is no longer declared, Unity creates a new global keyword.
    (没看懂...)


# --------------------------------- #
# Stage-specific keyword directives
当新建一个 shader varinat 时, 默认行为是: 针对每个 variant, 生成整个 shader代码中的所有 stages. 

万一那个 keyword 不影响所有 stage, 那么这个 "全部stage 都生成" 的行为就会导致冗余工作.
当然, 在这个冗余的生成之后, unity 会把多余的 stage 再删掉. 这保证了 最终的 build 体积一定是不会变大的, 最后的运行时性能也不会受到影响.  但它确实影响了 variants 的编译时间.

为避免此问题, 可使用 stage-specific keyword 指令. 它们在常规指令上 增加了 后缀.
它们告诉 unity, 本 keyword 会影响哪些 stages. (没影响到的就不用编译了)

# - Supported graphics APIs
不是所有平台都支持 stage-specific keyword 指令:
--
    在 OpenGL and Vulkan 中编译 shader 时, editor 自动将任何 stage-specific keyword 指令 复原为 常规 keyword 指令 
    (猜测是不支持)
--
    在 Metal 中编译 shader 时, vertex stage 和 tessellation stage 是绑定在一起的,
    只要指定其中任何一个, 另一个 stage 也会被编译

# - Using stage-specific keyword directives
这些额外的后缀是:
    _vertex
    _fragment
    _hull
    _domain
    _geometry
    _raytracing

比如写成:
multi_compile_fragment
shader_feature_local_vertex

如果需要指定多个 stages, 可在后面跟上多个后缀


# --------------------------------- #
# Built-in multi_compile shortcuts

在 built-in 管线中, 存在多种 缩写指令 (还是用于 variants)
它们主要用来处理 不同的 光照, 阴影 和 lightmap.  


# multi_compile_fwdbase

    编译所有被  PassType.ForwardBase 需要的 variants. 
    这些 variants 处理不同的 lightmap类型, 以及 启用/禁用 主平行光的 阴影

    包含以下 keywords:
        DIRECTIONAL LIGHTMAP_ON DIRLIGHTMAP_COMBINED DYNAMICLIGHTMAP_ON 
        SHADOWS_SCREEN SHADOWS_SHADOWMASK LIGHTMAP_SHADOW_MIXING LIGHTPROBE_SH. 
            ---
        These variants are needed by PassType.ForwardBase.



# multi_compile_fwdadd

    编译所有被 PassType.ForwardAdd 需要的 variants. 
    这些 variants 处理 平行光, spot光, 点光源, 以及它们的 拥有 cookie texture 的 variants.

    包含以下宏:
        POINT, DIRECTIONAL, SPOT, POINT_COOKIE, DIRECTIONAL_COOKIE.
    
    These variants are needed by PassType.ForwardAdd.



# multi_compile_fwdadd_fullshadows

    和 multi_compile_fwdadd 类似, 但也包括对 灯光有 实时阴影 的能力。

    包含以下宏:
        POINT, DIRECTIONAL, SPOT, POINT_COOKIE, DIRECTIONAL_COOKIE, 
        SHADOWS_DEPTH, SHADOWS_SCREEN, SHADOWS_CUBE, SHADOWS_SOFT, SHADOWS_SHADOWMASK, 
        LIGHTMAP_SHADOW_MIXING.



# multi_compile_fog
    多个 variants, 处理不同类型的 fog (off/linear/exp/exp2)
    包含以下keywords:
        FOG_LINEAR, FOG_EXP, FOG_EXP2.

    它还生成 不包含以上所有 keywords 的 variants,
    可通过修改 Graphics settings window 来控制它的行为





大部分 内建缩写指令 生成多个 variants. 如果你知道你的项目 不需要它们, 可使用:
#pragma skip_variants 来跳过一些 variants 的编译.
比如:
# --
#pragma multi_compile_fwdadd
#pragma skip_variants POINT POINT_COOKIE

    第一句生成了 数个 variants, 第二句又把其中的一些给 删除了
    (哪些包含 keywors: POINT 或 POINT_COOKIE 的 variants )


# --------------------------------- #
# Graphics tiers and shader variants
# 图形层

在运行时, unity 检测 gpu 的能力, 并决定使用对应的 Graphics tier.

在 built-in 管线中, 你可为每个 Graphics tier 自动生成一组 variants. 使用指令:
#pragma hardware_tier_variants

这个 feature 只和 built-in 管线有关. 无法用于 srp.

为了启用这个 feature, 写入指令:
#pragma hardware_tier_variants renderer

    参数 renderer 是一个有效的  graphics API

unity 为每个 shader 额外生成 3 个 variants.(叠加在别的 keyword 影响下)
这三个中,每一个 variant 都定义了一个 keyword (如下三个中的一个).
它和设置在 GraphicsTier enum 中的值 是对应的:

    UNITY_HARDWARE_TIER1
    UNITY_HARDWARE_TIER2
    UNITY_HARDWARE_TIER3

你可以使用它们来写入 conditional fallbacks (条件回退) 或 针对 更低/更高的硬件的 额外 features.

当 unity 第一次载入你的程序, 它会检查 GraphicsTier 的值, 然后将返回值 存入  Graphics.activeTier. 想要覆写 Graphics.activeTier 的值,直接修改它就行. 
注意,你必须在 unity 加载任何 "你想修改的 shaders" 之前 执行上述操作. 
一个好的位置是: 在你加载你的 主scene 之前, 在一个 "预加载scene" 中.

为了减小这些 variant 对性能的冲击, unity 只在 player 中加载 一组 shaders.
相同的 shader 不会占用额外的 存储空间.

想要在 unity editor 中测试 tiers, 可在: Edit - Graphic tier 中选择一个 你希望 unity editor 使用的 tier

注意, graphics tiers 和  Quality settings 无关.


# Per-platform shader define settings and graphics tier variants
在 built-in 管线中, 可使用  EditorGraphicsSettings.SetShaderSettingsForPlatform
API 来覆写 unity 内部的 #defines, 针对给定的 built target 和 graphics tier.

这个 feature 只和 built-in 管线有关. 无法用于 srp.

注意, 对于给定的 built target, 针对 不同的 graphic tier, 如果提供了不同的 TierSettings 值, 那么就算你不写 #pragma hardware_tier_variants 指令, unity 也会为 shader 生成 tier variants.


## =========================================================== #
#      Shader data types and precision
## =========================================================== #
为了更好地支持 移动平台, unity 拥有一些额外的 关于 hlsl 语言的 类型.

# --------------------------------- #
# Basic data types
shader 中的大部分计算都是在 浮点数 类型上进行的 (比如 float)
几种浮点数类型为: float, half, fixed (有此包裹出来的 half3 and float4x4 也算)
这几种类型 在精度, 性能 和 电量损耗上 都不一样.

# - High precision: float
32-bits
常用于: 世界空间坐标, texture坐标, 用于 三角函数,幂运算,指数运算 的标量.

# - Medium precision: half
16-bits
( range of –60000 to +60000, 精度约为3位小数 )

用于: short vectors, 方向向量, object-space坐标, HDR颜色值.

# - Low precision: fixed
最低精度的  fixed point 值. 通常为 11-bits.
( range of –2.0 to +2.0, 精度为 1/256 )

用于: 常规颜色值(通常存储在 texture 中)

# - Integer data types
整型 通常在各个平台上运行良好.

基于不同平台, 整型类型 可能不是由 gpu 提供的.
比如: Direct3D 9 and OpenGL ES 2.0 中, gpu 只操作浮点数. 然后使用相当复杂的 浮点数数学指令 来模拟 外观简单的  "整形表达式" (涉及到 位运算 和 逻辑运算)

在 Direct3D 11, OpenGL ES 3, Metal 以及其它移动平台, 它们能支持整型类型, 所以 位移动运算, 位掩码(bit mask) 都能正常工作.


# --------------------------------- #
# Composite vector/matrix types
hlsl 内建的 向量/矩阵类型. 

有些平台,比如 OpenGL ES 2.0, 只支持 方阵,而不是矩阵.


# --------------------------------- #
# Texture/Sampler types
通常用以下语句声明:
# --
sampler2D _MainTex;
samplerCUBE _Cubemap;

在移动平台, 将默认使用 "低精度 sampler". 比如, 此时从 texture 访问到的值可能是 低精度数据. 
如果你知道,你的 texture 内存储了 HDR值, 你可能会希望使用 half precision sampler:
# --
sampler2D_half _MainTex;
samplerCUBE_half _Cubemap;


如果你的 texture 包含 float值 (比如 depth texture), 也可使用 full precision sampler:
# --
sampler2D_float _MainTex;
samplerCUBE_float _Cubemap;


# --------------------------------- #
# Precision, Hardware Support and Performance
pc gpu 总是使用 高精度浮点是 (float). 比如  (Windows/Mac/Linux), 它们不关心你写的是: float, half, fixed. 最后都会使用 float 来处理.

只有在移动平台上, 才会真的使用 half, fixed 类型. 这些类型主要是为了考虑 耗电问题 (偶尔也是因为性能). 最好在移动平台实际测试你的 shader, 以此来确定是否需要照顾精度问题.

就算再移动平台, 不同的 gpu家族,对不同精度的支持也是不一样的:

图标略...

大部分现代移动平台, 将 float 设置为 32-bits, 将 half 和 fixed, 设置为 16-bits.
一些旧的平台,在 vert shader 和 frag shader 中会出现不同的配置.

使用低精度类型 总能变得更快, 这可能是由于改进了GPU寄存器分配，也可能是由于某些较低精度数学运算的特殊“快速路径”执行单元。
即使在没有原始性能优势的情况下，使用较低的精度通常也会降低GPU的功耗，从而延长电池寿命。

一个通用法则是, 除了 坐标 和 texture坐标, 剩余值都是用 半精度类型.
只有在 半精度无法满足某些运算时, 才会提高精度.

# - Support for infinities, NaNs and other special floating point values
不同的 gpu 家族(主要是移动平台) 表现是不一样的.

所有支持  Direct3D 10 的 pc gpu, 都支持非常明确的  IEEE 754 浮点数标准.
这意味着,在这些平台, 浮点数的使用 和 cpu 上是一摸一样的.

移动平台的支持显然不一样. 用0除0 在有些平台会得到 NaN, 在别的平台会得到  infinity,0 或别的未期望的值. 
最好自己实际去目标平台测试下.


# --------------------------------- #
# External GPU Documentation
gpu 生产商 有更详细的文档:

略...


## =========================================================== #
#      Using sampler states
## =========================================================== #
在 shader 中对 texture 做采样的 大部分时候,  sampleing state 应该源自 
texture settings (inspector).
本质上, texture 和 sampler 是绑定在一起的. 当使用 DX9 风格的 shader语句时,两者时绑定的:
# --
sampler2D _MainTex;
// ...
half4 color = tex2D(_MainTex, uv);
# ==

可使用 hlsl keywords: sampler2D, sampler3D, samplerCUBE 来同时声明 texture 和 sampler

大部分时候, 这就是你想要的, 同时也是一些老图形 API 唯一支持的(比如 OpenGL ES)

# --------------------------------- #
# Separate textures and samplers
需要 图形API 和 gpu 都支持对 很多个 texture, 使用少数 sampler. 
比如, Direct3D 11 允许在一个 shader 中最多存在 128 个 texture, 但只能有 16 个 samplers.

unity 允许用 DX11 风格的 hlsl 语法来 分开声明 texture 和 sampler.  但它们的名字上要存在关联. 
如果 sampler 的名字被命名为: “sampler”+TextureName, 那么这个 sampler 就能从那个 texture 中获得 sampling states.

上面那段代码,可用 DX11 风格 重写一下:
# --
Texture2D _MainTex;
SamplerState sampler_MainTex; // "sampler" + “_MainTex”
// ...
half4 color = _MainTex.Sample(sampler_MainTex, uv);
# == 

通过这个技术,可以重用 来自别的 texture 的 sampler 来对另一个 texture 进行采样.
# --
Texture2D _MainTex;
Texture2D _SecondTex;
Texture2D _ThirdTex;
SamplerState sampler_MainTex; // "sampler" + “_MainTex”
// ...
half4 color = _MainTex.Sample(sampler_MainTex, uv);
color += _SecondTex.Sample(sampler_MainTex, uv);
color += _ThirdTex.Sample(sampler_MainTex, uv);
# ==

    在上面代码中, 有三个 texture, 一个 sampler.

注意,这种 DX11 风格的 hlsl语法, 无法在一些旧平台使用( OpenGL ES 2.0)
你可能需要设置指令 #pragma target 3.5 来主动跳过那些 不支持的平台.


unity 提供数个 shader 宏来帮助 "声明和采样 textures". 
# --
UNITY_DECLARE_TEX2D(_MainTex);
UNITY_DECLARE_TEX2D_NOSAMPLER(_SecondTex);
UNITY_DECLARE_TEX2D_NOSAMPLER(_ThirdTex);
// ...
half4 color = UNITY_SAMPLE_TEX2D(_MainTex, uv);
color += UNITY_SAMPLE_TEX2D_SAMPLER(_SecondTex, _MainTex, uv);
color += UNITY_SAMPLE_TEX2D_SAMPLER(_ThirdTex, _MainTex, uv);
# ==

    这段代码可在 unity 支持的 任何平台运行. (多亏了宏的帮忙)
    但在类似 DX9 的老平台,这段代码还是会退化为 "三个texture 配 三个 sampler" 的实现.


# --------------------------------- #
# Inline sampler states
除了将 sampler 命名为: “sampler”+TextureName
unity 还能识别 其它几种模式的 sampler 名字.
当我们需要在 shader 中硬编码 sampling state 时,这很管用:
# --
Texture2D _MainTex;
SamplerState my_point_clamp_sampler;
// ...
half4 color = _MainTex.Sample(my_point_clamp_sampler, uv);

    sampler 的名字为: my_point_clamp_sampler
    它可被识别为: 滤波模式为 点采样, wrapping模式为 clamp

这种就叫做: Inline sampler states:
--
    滤波模式:  “Point”, “Linear” or “Trilinear”
--
    wrap mode:  “Clamp”, “Repeat”, “Mirror” or “MirrorOnce”
    wrap mode 可以具体到每个 axis (轴向) (UVW) (每个轴的模式都单独设置)
    比如写为:
        “ClampU_RepeatV”
--
    当用于 深度值比较时,可设置 “Compare” (可选的)
    和 HLSL SamplerComparisonState 类型, 还有 SampleCmp / SampleCmpLevelZero 函数一起使用


不同模式的图示, 略...


目前, Inline sampler states 只支持: Direct3D 11/12, PS4, XboxOne and Metal.

注意: “MirrorOnce” wrapping mode 在大部分移动平台 不被支持. 使用它会被 fallback 到 Mirror 模式. 


# ------------------------ END ------------------------------ #