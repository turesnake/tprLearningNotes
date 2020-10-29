# ================================================================ #
#            unity3d shader URP
# ================================================================ #
urp 使用了一套新的 API


# ======================================================= #
#                   常用 文件
# ------------------------------------------------------- #


# ------------------ #
#   Core.hlsl      [urp]
[file](rp.universal@8.2.0/ShaderLibrary/Core.hlsl)

通常在 主 shader 中直接 include，包含常用变量和宏，以及更多 .hlsl 文件


# ------------------ #
#   Input.hlsl      [urp]
[file](rp.universal@8.2.0/ShaderLibrary/Input.hlsl)



# ------------------ #
#   UnityInput.hlsl      [urp]
[file](rp.universal@8.2.0/ShaderLibrary/UnityInput.hlsl)


float4 _ScreenParams;
    屏幕长宽（像素）
    可以搭配: float4 sp : VPOS; 计算每个片元的 positionSS


# ------------------ #
#   Common.hlsl   [core]
[file](rp.core@8.2.0/ShaderLibrary/Common.hlsl)


# ------------------ #
#   Packing.hlsl   [core]
[file](rp.core@8.2.0/ShaderLibrary/Packing.hlsl)


# ------------------ #
#   Version.hlsl   [core]
[file](rp.core@8.2.0/ShaderLibrary/Version.hlsl)


# ------------------ #
#   UnityInstancing.hlsl   [core]
[file](rp.core@8.2.0/ShaderLibrary/UnityInstancing.hlsl)


# ------------------ #
#   SpaceTransforms.hlsl   [core]
[file](rp.core@8.2.0/ShaderLibrary/SpaceTransforms.hlsl)

常见的 空间转换函数，和常用 矩阵的 get 函数（更直观）


# ------------------ #
#   Random.hlsl   [core]
[file](rp.core@8.2.0/ShaderLibrary/Random.hlsl)



# ------------------ #
#   Macros.hlsl   [core]
[file](rp.core@8.2.0/ShaderLibrary/Macros.hlsl)


# ------------------ #
#   GeometricTools.hlsl   [core]
[file](rp.core@8.2.0/ShaderLibrary/GeometricTools.hlsl)

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
[file](rp.core@8.2.0/ShaderLibrary/Debug.hlsl)

GetIndexColor




# ======================================================= #
#                   常用 函数
# ------------------------------------------------------- #


# ------------------ #
# real3 SafeNormalize (float3 inVec);
- Common.hlsl [core]
就是普通的 normalize 功能，safe 版

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
为参数的每个分量，计算一个（近似值）的 倒数。（1/x）


# ------------------ #
# T trunc (T x);
- hlsl
返回 参数分量的 整数部分 （原参数是否被改变 ？？？ ）
# T frac (T x);
- hlsl
返回 参数分量的 小数部分 （原参数是否被改变 ？？？ ）



# ======================================================= #
#                   常用 数据结构， 变量，宏
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


# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #


