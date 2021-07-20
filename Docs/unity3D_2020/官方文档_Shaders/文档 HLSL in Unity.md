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

# -- #pragma enable_cbuffer
    当使用 CBUFFER_START(name) and CBUFFER_END macros 时, 从HLSLSupport 发射 cbuffer(name).
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


# Vertex ID: SV_VertexID
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
--
    TEXCOORD1, TEXCOORD2 and TEXCOORD3 
        分别是第2,第3,第4个 UV coordinates
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
    在 hlsl 平台, 扩展到 [branch]  (???)

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

UNITY_NEAR_CLIP_VALUE
    此宏被定义为 近平面的值. 
    Direct3D类平台 使用 0.0,
    OpenGL类平台 使用 -1.0

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
CBUFFER_START(MyRarelyUpdatedVariables)
    float4 _SomeGlobalValue;
    ...
CBUFFER_END


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

UNITY_SAMPLE_TEX2D_SAMPLER( name,samplername,uv)
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
unity_WorldToLight (declared in AutoLight.cginc)

unity_4LightPosX0,
unity_4LightPosY0, 
unity_4LightPosZ0

unity_4LightAtten0
unity_LightColor
unity_WorldToShadow


_LightColor
unity_WorldToLight
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











































