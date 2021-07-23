# ================================================================ #
#            unity3d shader URP
# ================================================================ #
urp 使用了一套新的 API


# ======================================================= #
#                   常用 文件
# ------------------------------------------------------- #


# ------------------ #
#   Core.hlsl      [urp]
[file](../rp.URP@10.1.0/ShaderLibrary/Core.hlsl)

通常在 主 shader 中直接 include，包含常用变量和宏，以及更多 .hlsl 文件


# ------------------ #
#   Input.hlsl      [urp]
[file](../rp.URP@10.1.0/ShaderLibrary/Input.hlsl)



# ------------------ #
#   UnityInput.hlsl      [urp]
[file](../rp.URP@10.1.0/ShaderLibrary/UnityInput.hlsl)


float4 _ScreenParams;
    屏幕长宽（像素）
    可以搭配: float4 sp : VPOS; 计算每个片元的 positionSS


# ------------------ #
#   Lighting.hlsl      [urp]
[file](../rp.URP@10.1.0/ShaderLibrary/Lighting.hlsl)
包含：
    BRDF
    UniversalFragmentPBR()
    UniversalFragmentBlinnPhong()


# ------------------ #
#   Shadows.hlsl      [urp]
[file](../rp.URP@10.1.0/ShaderLibrary/Shadows.hlsl)
包含：
    float4 TransformWorldToShadowCoord(float3 positionWS);



# ------------------ #
#   Common.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/Common.hlsl)

# ------------------ #
#   CommonMaterial.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/CommonMaterial.hlsl)


# ------------------ #
#   Packing.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/Packing.hlsl)


# ------------------ #
#   Version.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/Version.hlsl)


# ------------------ #
#   UnityInstancing.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/UnityInstancing.hlsl)


# ------------------ #
#   SpaceTransforms.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/SpaceTransforms.hlsl)

常见的 空间转换函数，和常用 矩阵的 get 函数（更直观）


# ------------------ #
#   Random.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/Random.hlsl)



# ------------------ #
#   Macros.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/Macros.hlsl)
包含：
    TRANSFORM_TEX(tex, name)

        将 2D uv值 (参数tex) 施加上 name_ST 的影响 (texture: tiling 和 offset 值)
        返回一个调整过的 uv 值
        此宏的目的仅仅是 施加 "tex"_ST 的修正
        如果你的 texture 未设置 tiling 和 offset 修正, 可以不用调用此宏


# ------------------ #
#   GeometricTools.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/GeometricTools.hlsl)

三维旋转函数：
  Rotate
  RotationFromAxisAngle
二次方程 解算器 函数：
  SolveQuadraticEquation
碰撞检测函数：
  IntersectRayAABB
  IntersectRayAABBSimple
  IntersectRaySphere
  IntersectRaySphereSimple
  IntersectRayPlane
  IntersectRayCone
其它函数：
  DistancePointBox
  ProjectPointOnPlane
  DistanceFromPlane
  CullTriangleFrustum
  CullTriangleEdgesFrustum
  CullTriangleBackFaceView
  CullTriangleBackFace


# ------------------ #
#   Debug.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/Debug.hlsl)

GetIndexColor


# ------------------ #
#   Color.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/Color.hlsl)


# ------------------ #
#   BRDF.hlsl   [core]
[file](../rp.core@10.1.0/ShaderLibrary/BRDF.hlsl)




# ======================================================= #
#              unity.hlsl 常用 函数
# ------------------------------------------------------- #


# ------------------ #
# real3 SafeNormalize (float3 inVec);
- Common.hlsl [core]
就是普通的 normalize 的 safe 版
搞定 分母为 0 的问题


# ------------------ #
# real PerceptualSmoothnessToPerceptualRoughness( real Smoothness_ );
- CommonMaterial.hlsl
简单返回 (1.0 - Smoothness_);
用来计算 Roughness
其中 Smoothness 和 Roughness 都是 Perceptual的（感性的）


# ret normalize (x);
- hlsl
在这种最原版的实现中，当 向量长度==0，返回的结果是 indefinite

- 这两函数，在 .hlsl 文件中都有使用


# ------------------ #
# int   asint   ( T x );
# float asfloat ( T x );
- hlsl
Interprets the bit pattern of x as an integer / floating-point
不是简单的 cast 操作

# ------------------ #
# ret rsqrt (x);
- hlsl
Returns 1 / sqrt(x)

# ------------------ #
# ret rcp (x);
- hlsl
 

# ------------------ #
# T trunc (T x);
- hlsl
返回 参数分量的 整数部分 （原参数是否被改变 ？？？ ）
# T frac (T x);
- hlsl
返回 参数分量的 小数部分 （原参数是否被改变 ？？？ ）

# ------------------ #
# ret lerp ( x, y, s );
- hlsl
线性插值: x*(1-s) + y*s





# ======================================================= #
#             unity.hlsl 常用 数据结构， 变量，宏
# ------------------------------------------------------- #

# ------------------ #
# StructuredBuffer<int> data;
# StructuredBuffer<StructA> data;
- hlsl
一个容器，指定统一的 元素类型T，用起来类似 std::vector<T>
似乎是 read-only 的


# ------------------ #
# UNITY_ASSUME_UNIFORM_SCALING
- unity
一个可被定义的全局变量，用来告诉 unity，当前 mesh 执行的 scale，是 统一的缩放。
若是统一缩放，那么在计算 法线转换时（OS <-> WS）将直接使用简单的 TransformObjectToWorldDir() 系列函数。
否则（即非统一缩放），则需要在每一帧，将 mesh 的 UNITY_MATRIX_I_M 矩阵，从 cpu，发给 gpu
这会影响渲染性能，尤其是使用 GPU instancing 时。
---
用户可以手动设置这个变量，通过：
# pragma instancing_options assumeuniformscaling
(看起来这个指令，是只针对 gpu instancing 模式的 ？？？ )


# ------------------ #
- ShaderLib: Input.hlsl
struct InputData
{
    float3  positionWS;
    half3   normalWS;
    half3   viewDirectionWS;
    float4  shadowCoord;
    half    fogCoord;
    half3   vertexLighting;
    half3   bakedGI;
};

- ShaderLib: SurfaceInput.hlsl
struct SurfaceData
{
    half3 albedo;
    half3 specular;
    half  metallic;
    half  smoothness;
    half3 normalTS; // Tangent-Space
    half3 emission;
    half  occlusion;
    half  alpha;
};

- ShaderLib: Lighting.hlsl
struct BRDFData
{
    half3 diffuse;
    half3 specular;
    half perceptualRoughness;
    half roughness;
    half roughness2;
    half grazingTerm;

    half normalizationTerm;     // roughness * 4.0 + 2.0
    half roughness2MinusOne;    // roughness^2 - 1.0
};




# ======================================================= #
#             unity SRP 提到的 class
# ------------------------------------------------------- #

# ScriptableRenderContext
    简称 context
    定义当前 rp 使用的 状况 和 指令。

# CommandBuffer
    存储一组 render commands

# RenderSettings
    当前场景中相关的 render settings，
    比如 sun, fog, ambient light
    这些参数 在 Lighting inspector 中可见

# CullingResults


# NativeArray<T0>
    字面理解就是 "本地数组"，可以在 jobs 中安全使用，
    provides a connection to a native memory buffer。
    efficiently share data between managed C# code and 
    the native Unity engine code.
    ---
    另一个文件中有具体描述, 可搜索之


# VisibleLight
    包含一个 可见光 的数据
    在执行完  ScriptableRenderContext.Cull() 之后，
    CullingResults.visibleLights 将会自动包含 一组 VisibleLight 数据。


# Profiler
# CameraRenderer
# RenderPipelineAsset
# RenderPipeline
# GraphicsSettings

# MaterialPropertyBlock

# ScriptableCullingParameters


# ShaderGUI
# BaseShaderGUI [urp]
# MaterialEditor
# MaterialProperty





# ---------------------------------------------- #
#             if define  
# ---------------------------------------------- #
用法1:
    #define AAA 0
    #if AAA
        // do something a...
    #elese
        // do something b...
    #endif
注意此处的用法，使用语句 #if AAA , 来判断 目标变量 是否为0（或是否存在）



# ---------------------------------------------- #
#         urp 的 核心 cs 文件在哪 ？？？
# ---------------------------------------------- #

# UniversalRenderPipelineAsset : RenderPipelineAsset
    Runtime/Data/UniversalRenderPipelineAsset.cs:

# UniversalRenderPipeline : RenderPipeline
    Runtime/UniversalRenderPipeline.cs
    Runtime/UniversalRenderPipelineCore.cs
    


# ---------------------------------------------- #
#             LightMode
#        int shader.pass.Tags
# ---------------------------------------------- #
URP Manual: URP ShaderLab Pass tags

也可自定义一个 LightMode tag

# - SRPDefaultUnlit  [-Default-]
    当一个 pass 不明确标记自己的 LightMode 时，urp 自动选用此项
    ---
    当渲染物体时，使用此 pass 来执行 额外的 pass。例如：离线绘制一个物体
    此 tag 同时适用于 Forward / Deferred 渲染路径。

# - UniversalForward
    此 pass 渲染几何体，计算所有光源的贡献。用于 Forward 渲染路径

# - UniversalGBuffer
    此 pass 渲染物体时 不考虑任何光线。用于 Deferred 渲染路径

# - UniversalForwardOnly
    此 pass 渲染几何体，计算所有光源的贡献，和 UniversalForward 类似。
    区别在于，本 tag 可被用于 Deferred 渲染。
    当在 Deferred 渲染中，必须对某个物体做 Forward悬案时，使用本 pass。
    比如 清漆材质物体，只能用 Forward渲染路径 来渲染。

    如果一个 shader，必须同时执行 Forward / Deferred 渲染路径，要实现两个 pass
    一个为 UniversalForward，另一个为 UniversalGBuffer。
    如果一个 shader 必须执行 Forward 渲染，不管 urp选择了何种 渲染路径，
    此时只需实现一个 pass：UniversalForwardOnly.
    （没看懂）

# - Universal2D
    2d物体，2d光照。用于 2d renderer

# - ShadowCaster
    针对各个光源，将物体深度值 写进 shadowmap 或 depth texture

# - DepthOnly
    针对一个相机，将物体深度值（从相机出发的）写入 depth texture

# - Meta
    仅在 unity editor 中执行 lightmap 烘培时，unity 才执行此 pass。
    Unity strips this Pass from shaders when building a Player.

## URP 不支持一下 LightMode tag：
    Always, ForwardAdd, PrepassBase, PrepassFinal, Vertex, VertexLMRGBM, VertexLM 





# ---------------------------------------------- #
#          flipped projection matrix 
# ---------------------------------------------- #
OpenGL风格的 texture 坐标系, 最下行 uv.v = 0;
D3D风格的 texture 坐标系,    最上行 uv.v = 0;

unity 整体遵循 OpenGL风格, 所以在处于 D3D类平台时, 会做一些修正措施:

--
    针对 普通 texture, unity 会直接翻转这个 texture 的 uv.v 轴坐标系. ( 0,1 之间的翻转)
    可通过宏: UNITY_UV_STARTS_AT_TOP 来查找之.

-- 针对 render target 这种 texture, unity 无法对齐进行翻转, 

    unity 选择 翻转 投影矩阵 ( posVS -> posHCS ) 的 y轴 (朝向的翻转,从向上变成向下)

    内置的 投影矩阵 据说可以自动调整(根据不同平台), 但自定义的投影矩阵, 就需要使用此文中介绍的方法来调整:
    https://zhuanlan.zhihu.com/p/119145598

    针对 unity 内置投影矩阵, 可在 shader 中检查:

        _ProjectionParams.x

    此值若为  1, 说明 投影矩阵 没有把 y轴 上下翻转
    此值若为 -1, 说明 投影矩阵 已经把 y轴 上下翻转 (D3D类平台)

    此时, 直接将这个 值乘以 posHCS.y 即可翻转过来.



# ---------------------------------------------- #
#        vert shader 生成的 posHCS 到底存了啥    
# ---------------------------------------------- #

# -1-
整体上, 这个 posHCS 存储了最正常的 齐次裁剪空间pos. 这些值符合如下规律:

    x/w: [ -1, 1 ]
    y/w: [ -1, 1 ]
    z/w: [ -1, 1 ]
    w == 1 

也就是说,对 posHCS 执行 齐次除法 (除以w项) 后, 将自动进入 NDC空间.

单纯的 posHCS 数据不存在很强的含义, 它的存在仅仅是为了将 齐次除法 延迟到后面某个阶段. 
从而允许在 中间插入 别的操作 (比如 clip, 我猜)

总之, 涉及到 posHCS 的计算, 如果感觉不够直观, 都可以把 齐次除法加进去看看.

# -2- y轴上下翻转

    // Our world space, view space, screen space and NDC space are Y-up.
    // Our clip space is flipped upside-down due to poor legacy Unity design.
    // The flip is baked into the projection matrix, so we only have to flip
    // manually when going from CS to NDC and back.

    在 unity 中, WS, VS, SS 和 NDC 都是 y轴朝上, 但唯独 HCS y轴朝下 (这是 unity 特有的) 
    unity 的 投影矩阵 内嵌了这个 翻转 y轴 的操作, 
    所以, 当坐标从 cs 传入 NDC 然后再返回时, 只需手动 翻转一下.
    ---

    大致意思还是 上文片段: "flipped projection matrix" 中所述. 

# -- 代码示范 -1- :
# --
#if UNITY_UV_STARTS_AT_TOP
    posHCS.y *= -1.0;
#endif
# ==

# -- 代码示范 -2- :
# --
posHCS.y *= _ProjectionParams.x; 
# ==


# -3- 如何在 frag shader 中访问 posHCS ?
那个标记 semantic 为 SV_POSITION 的 posHCS 是没办法在 frag shader 中直接使用的, 它被 渲染管线使用了(还做了改写)

我们可以在 vert shader 阶段, 复制一份顶点的 posHCS, 然后作为参数传递给 frag shader, 中间会经历插值运算,
在 frag shader 中拿到 逐像素的 posHCS 值.



# ---------------------------------------------- #
#        如何获得像素的 posSS 屏幕空间坐标
# ---------------------------------------------- #

# == 理论 ==
准备好当前位置的 posHCS, 执行齐次除法, 获得 NDC 值: posNDC (float3)
取 posNDC 的 xy 两项, 此时它们的取值区间为 [-1, 1] 执行:
    x*0.5 + 0.5,
    y*0.5 + 0.5,

即可得到 屏幕空间坐标: posSS

# == 实践 ==
具体该怎么算非常灵活, 实践证明不管是在 vert shader 中,还是在 frag shader 中计算,都可行.
这里选择 unity 源码选择的方式: 延迟齐次除法:

# vert shader
编写代码:

    // 这个值要作为参数 传递给 frag shader
    // 之所以把大头工作放在 vert shader 中做, 也许是为了利用 从三角形到frags 的插值运算, 
    // 建设这部分计算 (瞎猜的)
    float4 posNDC = float4(
        posHCS.x * 0.5,
        posHCS.y * 0.5 * _ProjectionParams.x,
        posHCS.z,
        posHCS.w
    );

# frag shader
编写代码:

    float2 posSS = posNDC.xy / posNDC.w; // 延迟的齐次除法






# == 现成 API ==
-- ComputeScreenPos()
-- GetVertexPositionInputs().positionNDC
-- ComputeNormalizedDeviceCoordinatesWithZ()



# ---------------------------------------------- #
#             
# ---------------------------------------------- #


# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #


