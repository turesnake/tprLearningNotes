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

其中, #pragma vertex 和 #pragma fragment 是必须实现的.

# ==
-- #pragma vertex name

-- #pragma fragment name

-- #pragma geometry name
     DX10 geometry shader, 这条指令会自动开启 #pragma target 4.0

-- #pragma hull name
    DX11 hull shader, 这条指令会自动开启 #pragma target 5.0

-- #pragma domain name
    DX11 domain shader, 这条指令会自动开启 #pragma target 5.0

# Shader variants and keywords
使用下列 pragma指令 告诉编译器如何处理 shader variants 和 keywords

-- #pragma multi_compile ...
    为给定 keyword 创建一个 variant. 
    multi_compile shaders 的未使用的 variants 将被包含在 游戏 build 中.

-- #pragma multi_compile_local ...
    类似上面的 multi_compile, 不过 keywords 是局部的.

-- #pragma shader_feature ...
    为给定 keyword 创建一个 variant. 
    shader_feature shaders 的未使用的 variants 将 不会被包含在 游戏 build 中.

-- #pragma shader_feature_local ...
    类似 shader_feature, 不过 keywords 是局部的.

# Shader model and GPU features
使用下列 pragma指令告诉编译器, 你的 shader target 是特殊的 shader model,
或者需要 特殊的 GPU features

-- #pragma target name 
    选择哪种 shader model. ( 3.5, 4.0, 5.0 之类的 )

-- #pragma require feature ...
    shader program 需要的 GPU features

# Graphics APIs
使用下列 pragma指令告诉编译器, 为特定的 图形API 编译你的 shader.

-- #pragma only_renderers space separated names
    仅为给定的 图形API 编译本 shader program. 
    (如: d3d11 playstation xboxone xboxseries vulkan metal switch )

-- #pragma exclude_renderers space separated names
    不要为后方列举的 图形API 编译本 shader

# Other pragma directives
-- #pragma enable_d3d11_debug_symbols
    生成 shader debug symbols, 有时会 禁止优化.
    使用此命令调试外部工具中的 shader 代码。

    针对 Vulkan, DirectX 11 and 12,以及支持的 游戏主机, unity 生成 debug symbols and disables optimizations.

    针对  Metal and OpenGL, 默认情况下你就能 debug shaders.
    当你使用此指令,unity 将 禁用优化.

    警告: 使用此指令将导致 文件体积增大, shader性能降低. 在发行版程序中, 记得关闭此行代码.

-- #pragma hardware_tier_variants renderer name

    没看懂...
    此声明只适用于 built-in 渲染管线.

-- #pragma hlslcc_bytecode_disassembly
    将 disassembled HLSLcc bytecode 嵌入到 翻译的 shader 中

-- #pragma disable_fastmath
    启用涉及 NaN处理 的精确 IEEE 754规则。
    此指令目前只被用于 Metal 平台

-- #pragma glsl_es2
    在 GLSL shader 中设置,以生成一个 GLSL ES 1.0(OpenGL ES 2.0),
    即便 shader target 是 OpenGL ES 3.

-- #pragma editor_sync_compilation
    强制同步编译. 这只会影响到 unity editor 中的渲染.

-- #pragma enable_cbuffer
    当使用 CBUFFER_START(name) and CBUFFER_END macros 时, 从HLSLSupport 发射 cbuffer(name).
    哪怕当前的平台不支持 cbuffers, 

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
2.5: derivatives
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
使用  #pragma exclude_renderers A B C 指定不要支持的平台

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
在编写 shader 程序时, input 和 output 变量 需要通过 semantics 设置它们的 "intent"(猜测是 使用方向) 
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

    返回的 深度值, 类型需要为单个 float.


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


无论用于哪个平台, 都请尽量较少两 shader 间通信的 变量的数量,这样能提高性能 (毕竟这些变量 都要在 光栅化中 插值到每个像素上去)


# Other special semantics
frag shader 可以接受 像素的 SSPos (屏幕空间pos), 它的 semantics 为 [VPOS].
这个 feature 只在 shader model 3.0 及之后版本 才存在. 

在不同的平台上, 屏幕空间pos 的基本类型是不相同的, 故为了最大便携性, 推荐使用 [UNITY_VPOS_TYPE] 宏 (在大部分平台,它的类型为 float4, 在 Direct3D 9, 则为 float2) 具体用法为:

# --
fixed4 frag (v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_Target
{ ... }


额外的, 使用 [VPOS] semantic 使得 程序很难在 vertex-to-frag 通道中 同时拥有 CSPos (SV_POSITION) 和 VPOS. 
( 注: CSPos 是顶点信息, VPOS 是逐像素信息 )

所以, vertex shader 应该将 CSPos 当作一个 特殊的 "out" 类型的参数来 实现输出 (类似 C# 中的 out参数), 

就像这个例子:
# --
// 注意:并未在此 struct 中实现 SV_POSITION
struct v2f {
    float2 uv : TEXCOORD0;
};

v2f vert (
    float4 vertex     : POSITION,   // vertex position input
    float2 uv         : TEXCOORD0,  // texture coordinate input
    out float4 outpos : SV_POSITION // clip space position output
                                    // 注意,这里使用了 "out"
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
vertex shader 可接收一种变量, 它的类型时 无符号整型, 含义为 顶点的idx. 
当你想从 texture 或 computerbuffer 中获得获取 额外的 逐顶点数据时, 很管用.

此 feature 需要至少支持 DX10 (shader model 4.0) and GLCore / OpenGL ES 3
所以必须写:
#pragma target 3.5

案例:
# --
struct v2f {
    fixed4 color : TEXCOORD0;
    float4 pos : SV_POSITION;
};

v2f vert (
    float4 vertex : POSITION, // vertex position input
    uint vid : SV_VertexID // vertex ID, needs to be uint
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












