# ================================================================ #
#            unity3d shader URP
# ================================================================ #
urp 使用了一套新的 API

本文也立即了大量 srp 的使用技巧


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

事实上, 就算彻底删除 frag shader 的参数项, 然后让 frag 函数返回一个 固定颜色值, 整个shader 也是可以正常运行的.
这意味着, vert shader 输出的 posHCS, 并不需要显示地传入 frag shader 中



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
#            _CameraNormalsTexture
# ---------------------------------------------- #
urp 10.0 开始支持 _CameraNormalsTexture

# 如何使用它 ?
首先新建一个 Renderer Feature
    在 AddRenderPasses() 中添加：
    m_ScriptablePass.ConfigureInput( ScriptableRenderPassInput.Normal );

复制一套 Lit shader组文件，
    或者别的已经实现了 DepthNormals pass 的 shader
    在 frag() 中，已经配置好了 InputData 实例 inputData，

inputData.normalizedScreenSpaceUV
    就是 屏幕空间的 uv 坐标值

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareNormalsTexture.hlsl"


float3 normalVal = SampleSceneNormals(uv);
    xyz: [-1,1]
    此时返回的是一个 单位向量（分量中存在负值）
    想要显示它，需要做 nm*0.5+0.5 的操作






# ---------------------------------------------- #
#             ddx ddy fwidth
# ---------------------------------------------- #
#
    这组概念 仅能在 frag shader 中使用。

# ddx,ddy 原理
    在 texture 采样流程中，gpu需要知道，当前位置，纹素 和 像素 之间的比例关系。这个比例有时存在形变，
    比如一个 像素，它所覆盖的 可能是一个 梯形 的 纹理区域。gpu 通常使用 "偏导数xy" 来记录这个概念，比如
    X轴方向，相邻的两个 screen-space pix，这两个 pix 的 center，所对应的 纹素，间距为多少。
        ---
    在 实际机器中，gpu 以 2X2 像素为一组，来记录这两个 偏导数的值：
    以左下角像素 为基础，它和 右侧像素的 纹素间距，就是 ddx
    它和 上方像素的 纹素间距，就是 ddy。
    为了提高性能，在这 2X2 组内，4个像素点的 ddx，ddy 值是相同的，（都等于 左下角的那个）
        ---
    根据 此组偏导数 的大小，可以判断应该使用哪一层的贴图LOD
    这个距离越大表示三角形离开摄像机越远，需要使用更小分辨率的贴图；
    反之表示离开摄像机近，需要使用更高分辨率的贴图。

# ddx，ddy 的使用
    ddx,ddy 常被用在 texture 采样中，比如：
        [urp]
        float3 texVal = SAMPLE_TEXTURE2D_GRAD( _Tex, sampler_Tex, uv1, ddx(uv2), ddy(uv2) );

# 为什么要用户手动输入 ddx，ddy
    大部分情况，用户不需要管理这组值，gpu会自动计算默认的值
    但有时，由于纹理贴合的方式，会导致一些 画面上的 bug，
    比如 IQ：
        https://www.iquilezles.org/www/articles/tunnel/tunnel.htm

    为了搞定这些 bug，gpu 允许用户传入一组 指定的 ddx,ddy 计算方法。

# 调用 ddx()，ddy() 后，最终的那组 偏导数 到底是怎么计算出来的 ?
    这个问题确实很迷, 参见：
        https://stackoverflow.com/questions/16365385/explanation-of-dfdx
    
    从表面看，我们向 ddx(),ddy() 传入的是一个 孤立的值，比如某个多次计算后的，发生形变的 uv 值。
    为什么仅仅传入这个值，gpu 就能根据它，计算出最后需要的 xy偏导数呢 ？？？

    因为在机器中，一组 frag 是同步运算的（比如上文提到的 2X2 4个像素）它们会非常一致地同时执行每一行代码。
    所以，当开始执行 ddx(),ddy() 指令时，gpu 不光知道 本像素的 参数 uv2。还知道它所在的 2X2 组内，其余3个
    像素的 参数 uv2 的值。
    这样，整个 ddx(), ddy() 的行为就能得到解释了。

# ddx(),ddy() 参数的注意事项：
    参数的计算要保证是连续的
    不要嵌套使用，比如写成 ddx(ddx()), 这样的行为可能是未定义的。
    

# fwidth
    fwidth = abs(ddx(v)) + abs(ddy(v));
    ---
    用处：暂不明...





# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #


