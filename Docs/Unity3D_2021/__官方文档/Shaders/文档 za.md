一些零碎的 文档页面

## =========================================================== #
#       Writing shaders for different graphics APIs
## =========================================================== #
不同图形API 之间的 渲染表现是不一样的. 大部分时候, unity editor 隐藏了这份不同,
但少数时候 editor 也没法隐藏. 以下列举了这些时刻

# ---------------------------- #
# Render Texture coordinates
texture 的 垂直坐标约定, 在 Direct3D类 和 OpenGL类 中是不同的:
--
    Direct3D类: 最上行为 0.  (Direct3D, Metal and consoles)
-- 
    OpenGL类: 最下行为 0.    (OpenGL and OpenGL ES)


在你的项目中,这种差异不会有什么影响. 
渲染到 render texture 时除外. 当在 Direct3D类平台 渲染到一个 texture, unity内部会做上下翻转. 这使得 这种差异彻底消失了. unity 整体遵循 opengl 的月约定 (最下行为 0)

Image Effects 和 "rendering in UV space" 是两个需要注意的使用场景, 确保此时 这种差异 不会影响到你的项目.

# -1- Image Effects
当你使用 Image Effects 和 抗锯齿 时, 获得的 texture 不会被翻转以适配 opengl 的约定. 此时, unity 渲染到屏幕 以获得 ""抗锯齿
, 然后将渲染数据解析为 render texture,以供未来的 Image Effects 流程用.

(?????)

若你的 Image Effects 是那种一次处理一个 render texture 的简单过程, Graphics.Blit 函数能自动处理 "纹理纵坐标不一致" 问题. 
然而, 如果你需要将数个 render textures 汇合起来用于 Image Effects 处理, 在 Direct3D类平台, 以及使用抗锯齿时, render texture 可能会出现 "纵坐标不一致" 问题. 

为了让 texture 纵坐标排布标准化, 你需要在你的 vertex shader 中管理 "翻转屏幕 texture", 以符合 opengl 约定.

代码演示:
# --
// Flip sampling of the Texture: 
// The main Texture
// texel size will have negative Y).

#if UNITY_UV_STARTS_AT_TOP
if (_MainTex_TexelSize.y < 0)
        uv.y = 1-uv.y;
#endif
# ==

一个类似的现象在  GrabPass 中发生. 获得的 render texture 在  Direct3D类平台 可能不会被翻转. 如果你的 shader代码 对 GRabPass 的 texture 进行采样, 使用存放在 inlcude 文件中的 
ComputeGrabScreenPos 函数.


# - Rendering in UV space
当在 uv空间中 做渲染时, 可能需要调整你的 shader 代码, 确保在 Direct3D类平台 和 OpenGL类平台 中的一致性.

你还需要调整在 "渲染到屏幕" 和 "渲染到texture" 两者间的渲染问题: 针对 Direct3D类平台 的进行上下翻转.

内建变量 ProjectionParams.x 存在两种值: -1, +1
若为 -1:
    说明这个投影已经执行了 上下翻转,已适应 opengl平台约定.
若为 +1:
    说明尚未执行翻转.

你可在 shader代码中检擦这个值,并作出调整. 如下代码:
# --
float4 vert(float2 uv : TEXCOORD0) : SV_POSITION
{
    float4 pos;
    pos.xy = uv;
    // This example is rendering with upside-down flipped projection,
    // so flip the vertical UV coordinate too
    if (_ProjectionParams.x < 0)
        pos.y = 1 - pos.y;
    pos.z = 0;
    pos.w = 1;
    return pos;
}
# ==


# ---------------------------- #
# Clip space coordinates
和 texture 纵坐标问题一样, clip-space 坐标系 在两大类平台中也是不同的.
(又名 post-projection space coordinates)
--
    Direct3D类, clip-space depth, 近平面为 1.0, 远平面为 0.0
    (Direct3D, Metal and consoles)
--
    OpenGL类,   clip-space depth, 近平面为 -1.0, 远平面为 1.0
    (OpenGL and OpenGL ES.)

可使用内置宏 UNITY_NEAR_CLIP_VALUE 来访问 当前平台的 近平面深度值.

在脚本中,使用  GL.GetGPUProjectionMatrix  将 unity默认的约定(OpenGL风格) 转换为 D3D风格.(如果平台需要这样做时)

# 此段中的 "深度值" 到底是指啥 ???
tpr 猜测为 .z/.w 这个值,  



# ---------------------------- #
# Precision of Shader computations
在目标平台上做 shader程序的测试 来避免 精度问题. 移动平台 和 pc平台 在 浮点数精度上存在差异. pc平台 将所有 浮点数, 都看作 32-bits float 来使用.


# ---------------------------- #
# Const declarations in Shaders
在 hlsl 语言 和 glsl 语言之间, const 的使用时不同的.
--
    hlsl 中: const 的含义 和 c++/c# 中的一样: 只读变量, 可在任何地方被声明和初始化
--
    glsl 中: 要求在 编译时就已经是 const 的了, 所以必须在 编译时的 构造器中被初始化
        (要么是 字面值, 要么使用其它 const 的值来初始化之)
    
最好遵循 OpengL 约定, 避免用别的变量的值来初始化一个 const 变量.


# ---------------------------- #
# Semantics used by Shaders
--
    Vertex Shader output (clip space) position: SV_POSITION
        有时会用 POSITION semantics, 注意, 这个词在启用了tessellation 的 ps4 中无效.
--
    Fragment Shader output color: SV_Target
        有时会用 COLOR or COLOR0 semantics, 注意, 这个词在 ps4 中无效.

    
当把 meshes 渲染成 很多点时, 在 vert shader 中输出 PSIZE semantics 的变量.(比如,将其设置为 1)
OpenGL ES or Metal 等平台, 当 point size 没有从 shader 写入时, 会将其看作 "未定义值"


# ---------------------------- #
# Direct3D Shader compiler syntax
d3d 平台使用微软的  HLSL Shader compiler 编译器. 此编译器在处理 各种shader错误时,要比别的编译器 更加严格. 
比如,它不接收 函数输出的 未正确初始化的值.

常见现象有:
# -1- 
    一个拥有 out参数的 Surface Shader 顶点修改器, 像这样去初始化这个值:
# --
void vert (inout appdata_full v, out Input o) 
{
    **UNITY_INITIALIZE_OUTPUT(Input,o);**
    // ...
}
# ==

# -2- 
    部分初始化的值.
    比如一个函数返回一个 float4 值, 但只有 xyz分量被设置了. 此时也会报错
# -3-
    在 vert shader 中使用 tex2D.
    这样做是无效的, 因为 UV衍生品 在 vert shader 中并不存在. 你应该改为显式地 采样一个 mip lvl.
    比如,使用 tex2Dlod (tex, float4(uv,0,0)).
    还需要写入 #pragma target 3.0, 以支持 tex2Dlod 的使用

    (???????)

# ---------------------------- #
# DirectX 11 (DX11) HLSL syntax in Shaders

Surface Shader 编译管线 的一些部分 无法理解  DirectX 11 风格的 hlsl 语法.

如果使用 hlsl features,比如 StructuredBuffers, RWTextures, (或者其它不属于 DirectX 9 的语法), 请将它们包裹进一个 DirectX 11 独占的 预处理宏 之中,如下:
# --
#ifdef SHADER_API_D3D11
// DirectX11-specific code, for example
StructuredBuffer<float4> myColors;
RWTexture2D<float4> myRandomWriteTexture;
#endif
# ==


# ---------------------------- #
# Using Shader framebuffer fetch (提取)
有些 gpu(尤其是 ios 中的 PowerVR-based ones) 允许你 将当前 frag颜色 当作 输入参数 传入 frag shader, 来执行一种 可编程 blending.
  (see EXT_shader_framebuffer_fetch on khronos.org).

可在 unity shader 中使用 framebuffer fetch 功能. 在你编写 hlsl 或 cg 语言的 frag shader 时, 使用一个 inout参数 传入 颜色值.例如(cg版):
# --
CGPROGRAM
// only compile Shader for platforms that can potentially
// do it (currently gles,gles3,metal)
#pragma only_renderers framebufferfetch

void frag (v2f i, inout half4 ocol : SV_Target)
{
    // ocol can be read (current framebuffer color)
    // and written into (will change color to that one)
    // ...
}   
ENDCG
# ==


# ---------------------------- #
# The Depth (Z) direction in Shaders
在不同平台, z的方向是不同的.

# -- DirectX 11, DirectX 12, PS4, Xbox One, Metal: 方向是反的:
--
    z值, 近平面为 1.0, 远平面为 0.0
--
    Clip space range is [near,0]
    (意味着, 近平面的距离就是 近平面深度值本身, 而远平面深度值则为 0,)

# -- 其它平台:
--
    z值, 近平面为 0.0, 远平面为 1.0
--
    clip space range 还存在区分:
    ---
        Direct3D风格平台, range is [0,far]
    ---
        OpenGl风格平台,   range is [-near,far]



注意 z值得反转, 设置它的主要目的是为了让 z值在不同深度的分布变得均匀
(别的 图片文件 中有描述)


所以, 当你使用的平台存在 z-reverse 时:
    -- 
        宏 UNITY_REVERSED_Z 会被定义
    --
        _CameraDepth texture 的 range 为 1 (near) to 0 (far).
    --
        Clip space range 为 “near” (near) to 0 (far).


然后,如下宏和函数 自动处理了 z-reverse 问题:
-- Linear01Depth(float z)
-- LinearEyeDepth(float z)
-- UNITY_CALC_FOG_FACTOR(coord)

# - Fetching the depth Buffer
如果你正在手动提取 z-buffer 值, 你可能要检测下 z-reverse 问题,如下:
# --
float z = tex2D(_CameraDepthTexture, uv);
#if defined(UNITY_REVERSED_Z)
    z = 1.0f - z;
#endif
# ==


# - Using clip space
如果你正在手动使用 clip spase z 深度值, 您可能还希望通过使用以下宏来抽象平台差异
# --
float clipSpaceRange01 = UNITY_Z_0_FAR_FROM_CLIPSPACE(rawClipSpace);

    此宏将各种平台的 z 值都映射为 [0,far] 区间;

注意, 此宏不在 OpenGL or OpenGL ES 平台更改 clip space, 在这些平台, 它返回: [-near, far]
(tpr注: 它是为了性能, 故意不修改的, 可查看源码注释)



# - Projection matrices
如果你在 z翻转 的平台, GL.GetGPUProjectionMatrix() 返回一个 z翻转的 矩阵.
但是,如果你在手动处理 投影矩阵( 自定义阴影 或 深度值渲染 ), 当深度值是通过 脚本 提供时,你需要手动翻转 z 值:
# --
var shadowProjection = Matrix4x4.Ortho(...); //shadow camera projection matrix
var shadowViewMat = ...                     //shadow camera view matrix
var shadowSpaceMatrix = ...                 //from clip to shadowMap texture space
    
// 'm_shadowCamera.projectionMatrix' is implicitly reversed 
// when the engine calculates device projection matrix 
// from the camera projection
m_shadowCamera.projectionMatrix = shadowProjection; 

// 'shadowProjection' is manually flipped before 
// being concatenated to 'm_shadowMatrix'
// because it is seen as any other matrix to a Shader.

// 把矩阵的 第三行 全部取反
if(SystemInfo.usesReversedZBuffer) 
{
    shadowProjection[2, 0] = -shadowProjection[2, 0];
    shadowProjection[2, 1] = -shadowProjection[2, 1];
    shadowProjection[2, 2] = -shadowProjection[2, 2];
    shadowProjection[2, 3] = -shadowProjection[2, 3];
}
    m_shadowMatrix = shadowSpaceMatrix * shadowProjection * shadowViewMat;
# ==

# - Depth (Z) bias
unity 自动处理 z bias, 使得它能符合 z的朝向问题.
但是,如果你正在使用一个 原生代码渲染插件, 你需要在你的 c/c++ 代码中 翻转 z值


# --- Tools to check for depth (Z) direction
使用  SystemInfo.usesReversedZBuffer 来检查你的平台 是否使用 z翻转






