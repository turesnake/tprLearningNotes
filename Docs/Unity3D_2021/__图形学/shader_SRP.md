# ================================================================ #
#            unity3d shader SRP
# ================================================================ #
一些 urp 的源码信息,
一些 srp 的使用技巧


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
    BRDF:
        DirectBRDFSpecular()

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

GPU Instancing


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
#              unity 常用 函数
# ------------------------------------------------------- #



# ------------------ #
# real PerceptualSmoothnessToPerceptualRoughness( real Smoothness_ );
- CommonMaterial.hlsl
简单返回 (1.0 - Smoothness_);
用来计算 Roughness
其中 Smoothness 和 Roughness 都是 Perceptual的（感性的）





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
struct InputData         // urp 12.1.6
{
    float3  positionWS;
    float4  positionCS;
    half3   normalWS;
    half3   viewDirectionWS;
    float4  shadowCoord;
    half    fogCoord;
    half3   vertexLighting;
    half3   bakedGI;

    float2  normalizedScreenSpaceUV;
    half4   shadowMask;
    half3x3 tangentToWorld;

    #if defined(DEBUG_DISPLAY)       // debug 用, 可忽略
        half2   dynamicLightmapUV;
        half2   staticLightmapUV;
        float3  vertexSH;

        half3 brdfDiffuse;
        half3 brdfSpecular;
        float2 uv;
        uint mipCount;

        // texelSize :
        // x = 1 / width
        // y = 1 / height
        // z = width
        // w = height
        float4 texelSize;

        // mipInfo :
        // x = quality settings minStreamingMipLevel
        // y = original mip count for texture
        // z = desired on screen mip level
        // w = loaded mip level
        float4 mipInfo;
    #endif
};


- SurfaceData.hlsl
struct SurfaceData   // urp 12.1.6
{
    half3 albedo;
    half3 specular;
    half  metallic;
    half  smoothness;
    half3 normalTS;
    half3 emission;
    half  occlusion;
    half  alpha;
    half  clearCoatMask;
    half  clearCoatSmoothness;
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





# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
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



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#         urp 的 核心 cs 文件在哪 ？？？
# ---------------------------------------------- #

# UniversalRenderPipelineAsset : RenderPipelineAsset
    Runtime/Data/UniversalRenderPipelineAsset.cs:

# UniversalRenderPipeline : RenderPipeline
    Runtime/UniversalRenderPipeline.cs
    Runtime/UniversalRenderPipelineCore.cs
    


# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
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
    当在 Deferred 渲染中，必须对某个物体做 Forward渲染时，使用本 pass。
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

## URP 不支持以下 LightMode tag：
    Always, ForwardAdd, PrepassBase, PrepassFinal, Vertex, VertexLMRGBM, VertexLM 





# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#          flipped projection matrix 
# ---------------------------------------------- #
OpenGL风格的 texture 坐标系, 最下行 uv.v = 0;
D3D风格的 texture 坐标系,    最上行 uv.v = 0;

unity 整体遵循 OpenGL风格, 所以在处于 D3D类平台时, 会做一些修正措施:

--
    针对 普通 texture, unity 会直接翻转这个 texture 的 uv.v 轴坐标系. ( 0,1 之间的翻转)
    可通过宏: UNITY_UV_STARTS_AT_TOP 来查找之.

-- 针对 render target 这种 texture, unity 无法对其进行翻转, 

    unity 选择 翻转 投影矩阵 ( posVS -> posHCS ) 的 y轴 (朝向的翻转,从向上变成向下)

    内置的 投影矩阵 据说可以自动调整(根据不同平台), 但自定义的投影矩阵, 就需要使用此文中介绍的方法来调整:
    https://zhuanlan.zhihu.com/p/119145598

    针对 unity 内置投影矩阵, 可在 shader 中检查:

        _ProjectionParams.x

    此值若为  1, 说明 投影矩阵 没有把 y轴 上下翻转
    此值若为 -1, 说明 投影矩阵 已经把 y轴 上下翻转 (D3D类平台)

    此时, 直接将这个 值乘以 posHCS.y 即可翻转过来.



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#        vert shader 生成的 posHCS 到底存了啥    
#   posHSC        pos HSC
#   positionHCS   position HCS
# ---------------------------------------------- #

# -1-
整体上, 这个 posHCS 存储了最正常的 齐次裁剪空间pos. 这些值符合如下规律:

    x/w: [ -1, 1 ]
    y/w: [ -1, 1 ]
    z/w: 
        -- 启用 reversed-z 的平台:          [near, 0]
        -- 无 reversed-z, D3D风格的平台:    [0, far]
        -- 无 reversed-z, OpenGL风格的平台: [-near, far]
    w == 1 

也就是说,对 posHCS 执行 齐次除法 (除以w项) 后, 将自动进入 NDC空间.

(tpr注: d3d 和 opengl 的 NDC 空间, 其z值 范围也是不同的)


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
    posHCS.y *= -1.0;    // 如果要处理的是 uv.y, 则应该: uv.y = 1-uv.y;
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



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#        如何获得像素的 posSS 屏幕空间坐标
#        positionSS
# ---------------------------------------------- #

# positionSS
屏幕空间上的, [0,1] 区间的值;

# == 理论 ==
准备好当前位置的 posHCS, 执行齐次除法, 获得 NDC 值: posNDC (float3)
取 posNDC 的 xy 两项, 此时它们的取值区间为 [-1, 1] 执行:
    x*0.5 + 0.5,
    y*0.5 + 0.5,

即可得到 屏幕空间坐标: posSS  positionSS
完整的过程也可表达为:
    (posHCS.xy/posHCS.w) * 0.5 + 0.5;


# == 实践 ==
具体该怎么算非常灵活, 实践证明不管是在 vert shader 中,还是在 frag shader 中计算,都可行.
这里选择 unity 源码选择的方式: 延迟齐次除法:

# vert shader
编写代码:

    // 这个值要作为参数 传递给 frag shader
    // 之所以把大头工作放在 vert shader 中做, 也许是为了利用 vs->fs 插值运算来建设这部分计算 (我猜)
    float4 posNDC = float4(
        posHCS.x * 0.5 + posHCS.w * 0.5,
        posHCS.y * 0.5 * _ProjectionParams.x + posHCS.w * 0.5,
        posHCS.z,
        posHCS.w
    );

# frag shader
编写代码:

    float2 posSS = posNDC.xy / posNDC.w; // 延迟的齐次除法


# == 现成 API ==
-- ComputeScreenPos()   srp 中废弃了
-- GetVertexPositionInputs().positionNDC
-- ComputeNormalizedDeviceCoordinatesWithZ()



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
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




# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#             ddx ddy fwidth
# ---------------------------------------------- #
#
    这组概念 仅能在 frag shader 中使用。


# 注意!!! ddx(uv2) 返回的也是一个 float2 值;


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
    fwidth = abs(ddx(x)) + abs(ddy(x));
    ---
    用处：暂不明...

    x 就是个任意参数;





# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#         MaterialPropertyBlock
# ---------------------------------------------- #
似乎支持 全管线.

每一个 obj / mesh / renderer 通过自定义一个脚本,在其中维护一个 MaterialPropertyBlock 结构,
然后调用类似 Renderer.SetPropertyBlock 这种函数, 就能维护自己独有的 material properties 值

这样一来, 就算无数个 objs 使用同一个 material (当然更是同一个 shader variant)
每个 obj 也能各自设置各自的 properties

具体用法在此文中搜索:
https://catlikecoding.com/unity/tutorials/custom-srp/draw-calls/

# 但是, 这样配置后的 obj, 将无法被归入 SRP Batcher 中, 变成一个个 孤零零的 batch

# 但此技术支持 GPU Instancing 






# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#        四种渲染管线批处理优化:
#          Static batching
#          Dynamic batching
#          GPU Instancing
#          SRP Batcher
# ---------------------------------------------- #
暂时只记录了 粗略介绍, 有待未来的详细整理

# -------------------------
# -1- Static batching
在运行时之前, 将那些使用相同 material 的 静态物体, 
在 cpu 端合成为一个 巨大的 mesh, 一口气传入 gpu.

缺点:
对 cpu->gpu 存储,带宽负担很大.

不建议使用

# -------------------------
# -2- Dynamic batching
在运行时, 将符合条件的 动态对象, 在一次 draw call 中绘制, 从而较低 draw call 数量

条件为:
    -- 不超过 300个顶点, 不超过 900 个properties (意味着只能处理很简单的物体)
    -- 不能包含 镜像 scale 修改
    -- material 相同
    -- 物体的 lightmap 指向的位置相同

缺点:
运行时 cpu 的负担巨大. 其消耗可能大于此技术的收益. 

不建议使用, unity 默认不实用此功能


# -------------------------
# -3- GPU Instancing
如果多个物体, 拥有相同的 mesh (比如重复的叶子,重复的石头), 
在 cpu 中收集每个 物体实例的 transform 信息, material properties 数据, 并将它们组成一个 array.
然后发送给 gpu.  然后这个 mesh 固有的信息(顶点信息) 则只需在 gpu 中存储一次(毕竟都是 复制品)
此时, gpu 只需一次 draw call 就能把这所有的 复制物体实例, 全部绘制出来

很不错的技术, 但只适合那些大量复制品. 


可在这篇文章内搜索 srp 中的实现方法:
https://catlikecoding.com/unity/tutorials/custom-srp/draw-calls/

# 如何让 material 支持 GPU Instancing 功能 ?
在 material 使用的 shader 中, 加入指令:
    
    #pragma multi_compile_instancing

它能生成两版 shader variants, 一版有 gpu instancing 功能, 一版没有.

然后, material inspector 中会出现一个 选项框: Enable GPU Instancing.
你可以手动勾选 来选择 是否在本 material 中启用 这个技术.

# Instance ID
就是每个物体的 id 值, 通过它可访问 gpu 中 instanced data arrays 中的数据.

此值被存储在 UnityInstancing.hlsl: unity_InstanceID 变量中. (static uint)

# -1-
    分别在 vert/frag struct 中放置宏: 
    
UNITY_VERTEX_INPUT_INSTANCE_ID, 

    此宏会在 struct 中声明一个 uint instanceID 变量.
    (之所这个 宏名字中带 VERTEX, 大概是因为 instance id 主要是通过 vert struct 传入的, 之后还能原样传入 frag shader 中 )

# -2-
    分别在 vert/frag shader 中调用宏:

UNITY_SETUP_INSTANCE_ID( struct_input ); 

    此宏函数 从 input 中获取 instance id, 将其存储 全局静态变量 "unity_InstanceID" 中,
    有时还会执行额外的 procedural function, 来配置其它 instance data

# -3-
    若 frag shader 也想使用 instance id. 可在 vert shader 中调用宏:

UNITY_TRANSFER_INSTANCE_ID( input, output );

    它会将 instance id, 从 input 复制到 output 中.

# -4-
    将所有 material properties, 存储在一个 特殊的 cbuffer 中:

UNITY_INSTANCING_BUFFER_START(UnityPerMaterial) 
    UNITY_DEFINE_INSTANCED_PROP( float4, _BaseColor )
UNITY_INSTANCING_BUFFER_END(UnityPerMaterial)

    名字被限定为 "UnityPerMaterial" 是为了支持 SRP Batcher, 至于 cbuffer 的前后包围格式, 内部变量的声明格式,
    都要按照这个示例的来.

# -5-
    上面这些 cbuffer 中的 material properties, 也是被串起来存储在 gpu 的一个列表中的, 想要访问自己物体 对应的 那个cbuffer,
    就要用上 instance id 去索引.
    此后可在 vert/frag shader 中使用宏函数:

UNITY_ACCESS_INSTANCED_PROP( UnityPerMaterial, _BaseColor )

    参数1 为 cbuffer 名字, 参数2 为 变量名字. 这个宏会自动使用 instance id.



# 为什么有时候看不到 GPU Instancing 被使用 ?
通常, SRP Batcher 的优先级要高于 GPU Instancing, 如果管线已经支持 SRP Batcher, 
我们可能压根就观测不到 GPU Instancing 的启用.

此时可以 故意破坏掉 SRP Batcher 的规则, 比如, 将 cbuffer: UnityPerDraw 换个名字啥的,


# -------------------------
# -4- SRP Batcher
使用相同 shader variant 的物体, 可被整合进一个 batch 中, 然后传入 gpu.
是 这几种技术中 通用度最高的技术.

具体细节在别的文件中有描述...



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#     SRP Batcher  和  global property  的兼容问题
# ---------------------------------------------- #


# 什么是 global property ?
    如果一个 shader property 没有出现在 material Properties{} 中, 
    而且它在 HLSL 作用域内被声明了,
    而且它在 vs/fs 代码内被使用了 (重要)
    --
    那么这就是一个 shader global property;

# 一个 global property, 不能被放在 UnityPerMaterial cbuffer 中;
否则, 从 c# 层向它传值时, 可能会发生错误;
比如在 lod == 200 时, 传值失败;

# gloabl property 是否会影响 srp batcher 合批呢 ?
    不会 !!!!!
    可以放心使用 !!!!!





# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#         unity_WorldTransformParams  是啥
# ---------------------------------------------- #
存储在 UnityInput.hlsl 中, (11.0)

catlike 中说, 这其中包含一些我们不再需要的转换信息, 

其 w分量 与物体 transform 的scale值有关。如果有 奇数个负数的 scale，则 w 为-1，否则为 1。

(即，在scale为负数的时候，物体的纹理可能会被翻转，导致TBN空间不对)
(这句话也可能描述得不对)

如果此值为 -1, 你需要将 binormal 翻转;




# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#     keyword: UNITY_ASSUME_UNIFORM_SCALING
# ---------------------------------------------- #
如果你的 shader 所处理的 物体, 不会出现 "非统一缩放", 
那么就能通过以下指令开启这个 keyword:

#pragma instancing_options assumeuniformscaling

这样一来, 类似 法线的 空间转换(OS->WS) 就不需要用到  UNITY_MATRIX_I_M 这种 原始变换矩阵的 逆矩阵了.

如果你的 shader 开启了 GPU Instancing, 那么这样做的收益会更大. 
此时, 往往需要向 gpu 传入一整个 array 的 逆矩阵, 启用此优化小技巧, 可以节省下大量的 带宽 和 gpu内存.






# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#          shader 的编译和优化
# ---------------------------------------------- #
当我们在 shader 代码中 设置各种 struct, 各种中间变量, 各种函数时, 它们不会真的影响到 shader 的性能.
因为最后 shader 的 编译器会重写这些代码, 以保证足够的运行性能.




# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#      Mesh Renderer:  Dynamic Occlusion
# ---------------------------------------------- #
当 Dynamic Occlusion 被开启, 且这个物体被 static occluder 遮挡 (从 camera 观察时)
这个物体会被 culling. 

Dynamic Occlusion 默认设为开启.

当 Dynamic Occlusion 被关闭, 就算这个物体给 static occluder 遮蔽, 也不会被 culling.
可以使用此功能来 渲染 "墙壁后的人" 
(想想 CS 之类的游戏)

此技术 和  occlusion culling  有关.




# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#      commandbuffer.BeginSample( "name" )
#      ...
#      commandbuffer.EndSample( "name" )
# ---------------------------------------------- #
很复杂, 一言难尽...

# --
一个直观的表现是, 在 Frame Debug 窗口中, 会把 中间那段操作, 嵌套在一个 名为 "name" 的折叠作用域 中.

catlike 常用这一招来 管理 Frame Debug 中的层级关系.






# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#    InterleavedGradientNoise( posCS.xy, frameCount )
# ---------------------------------------------- #
一个 随机数/dither 生成器, 返回随机值 [0.0, 1.0] 

-- 参数1 -- 可输入每个 frag 的 posCS.xy 
-- 参数2 -- 可输入一个随时间变化的计数器. 控制时间流动, 
            不希望随机值随时间发生变化,可设为 0

挺实用的 




# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#    是否可以在 CGPROGRAM  作用区内, include hlsl 文件 ?
# ---------------------------------------------- #
可以

CGPROGRAM 和 HLSLPROGRAM 作用域的核心区别是 它们默认包含的 文件不相同





# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#      如何在 ShaderGraph 中绑定我们自定义的 shader 程序  
# ---------------------------------------------- #

# -1-
    新建一个 hlsl 文件, 写入一般 pass 中需要的代码. (不包含 #pragma 指令)

# -2-
    在此文件中, 额外准备一组 接口 dummy 函数组:

        void ShaderGraphFunction_float (float3 In, out float3 Out) 
        {
            Out = In;
        }
        void ShaderGraphFunction_half (half3 In, out half3 Out) 
        {
            Out = In;
        }
    
    这组 dummy 函数通常有两个, 分别以 _float, _half 结尾, 表示它们支持的精度
    shaderGraph 一般就支持这两个精度.
    注意. 这两个后缀, 是不算入 函数名的. 

# -3-
    在目标 shaderGraph 中, 新建一个 Custom Fuction Node. 
        -- Type 设置为 File
        -- Name 写 ShaderGraphFunction (注意看,没有 后缀)
        -- Source 绑定 此 hlsl 文件
        -- Inputs 区新建一个变量,  名字写 In, 类型为 Vector3
        -- Outputs 区新建一个变量, 名字写 Out, 类型为 Vector3
    
    然后给这个 node 的 input 端绑定 positionOS, 
    output端 则连接到 Vertex function 的 Position 上

# -4-
    如果还想添加 #pragma 之类的指令, 还需要另外新建一个 custom fuction node. 
        -- Type 设为 String
        -- Name 随意,可写为 InjectPragmas
        -- Body 部分写注入的 指令信息, 比如:
            #pragma xxxxx
            #pragma xxxxx
            Out = In;
        
        注意最后一句 Out = In; 必须加上. 

        -- 然后同样设置 input 端 和 output 端.

    这个 node 放在 上一个 custom function node 的前面, 以相同的方式串连. 

# ---
这样一样, 上面这两段信息 就能注入到 shaderGraph 所生成的 shader 程序中去了.





# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#  c# 源码中的宏:
#       ENABLE_VR
#       ENABLE_VR_MODULE
#       ENABLE_XR_MODULE
# ---------------------------------------------- #

# ENABLE_VR:
    "if the platform supports VR", 引擎的 c++ 代码中会设置此宏;
    and cannot be changed unless you edit and recompile source code.
    ---
    这意味着, 设置了此宏, 并不意味着 程序是个 vr 程序... 


# ENABLE_VR_MODULE
    Unity sets this define if your Project includes the built-in VR module "com.unity.modules.vr";
    即, 只有安装了对应的 package, 此宏才会被设置;


# ENABLE_XR_MODULE
    Unity sets this define if your Project includes the built-in XR module "com.unity.modules.xr";
    即, 只有安装了对应的 package, 此宏才会被设置;


# 在一个 普通 win10 非xr项目中:
    ENABLE_VR 通常为 true;
    ENABLE_VR_MODULE, ENABLE_XR_MODULE 通常为 false

    所以:
        #if ENABLE_VR && ENABLE_VR_MODULE
        #if ENABLE_VR && ENABLE_XR_MODULE
    
    此时都为 false


# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#       _USE_DRAW_PROCEDURAL    (shader keyword)
#       UseDrawProcedural       (string)
# ---------------------------------------------- #
    "should be true when rendering for XR"

在 BeginXRRendering(), EndXRRendering() 见到这个 keyword 被设置;
确实与 xr, vr 相关;

可以尝试把它 相关的代码都 注释掉


# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#      "_ScaleBias"       (shader float4)
#       scaleBias         (vector4)
#       "_ScaleBiasRt"    (shader float4)
#       scaleBiasRt       (vector4)
# ---------------------------------------------- #
这是 urp 自己写入的值, 最好的办法: 针对每个具体的 pass, 去查看 c# 端写入了什么数据;


x 分量 表示用户是否需要手动实现 uv "y-flip" 操作:

    output.positionCS.y *= _ScaleBiasRt.x;



# ----------------------------------------------#
#  系统自己定义的 keyword:  UNITY_USE_NATIVE_HDR
# ----------------------------------------------#
此 keyword 仅在 urp 被使用过一次, hdrp 中未出现;

Reflection Probes (as lightmaps) 可以被编码为:
    -- "native HDR texture", (16bit per channel or BC6H)
    -- RGBM
    -- dLDR

如果 "UNITY_USE_NATIVE_HDR" 被定义:
    说明 texture 中的数据没有被 编码, 
    (猜测:  虽然 BC6H 会引发压缩, 但这个压缩解压过程仅在 texture 读写时发生, 在 shader 中, 
            texel 中每个通道的值都是 16-bits float, 它们没有被编码;
    )
    此时, 我们可以直接使用 texel 中的值( 每通道都是 16-bits float 值 ), 不需要执行 decoding 解码工作;

否则, 如果 "UNITY_USE_NATIVE_HDR" 未被定义:
    需要对 texel 中的数据进行解码, 比如调用 "DecodeHDREnvironment()" 函数;
    具体解码细节, 因 "encoding type (RGBM/dLDR)" 和 "colorspace" 而异;


至于数据是如何编码的, 则基于 平台 和 project settings: Player -> Other Settings -> "Lightmap Encoding"
移动平台默认会编码为 dLDR, 除非你覆写 Texture Compression setting;



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#    #pragma fragmentoption ARB_precision_hit_fastest
# ---------------------------------------------- #

在编写 Unity Shader时， 可以通过 fragmentoption 来对片段着色器进行配置，
从而指定当前着色器的精度:

#pragma fragmentoption ARB_precision_hint_fastest -- 标记当前片段着色器为最快的

#pragma fragmentoption ARB_precision_hint_nicest -- 标记片段着色器为效果最好的

(一个片段着色器只能标记一个，如果两个都标记则会编译失败)







