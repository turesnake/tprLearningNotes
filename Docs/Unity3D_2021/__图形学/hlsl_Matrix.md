# ================================================================ #
#                   HLSL   Matrix
# ================================================================ #

float2x2
float3x3
float4x4


MS官网搜索：Per-Component Math Operations
https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-per-component-math#the-matrix-type


# --- 类型书写规则 --
# float2x1 m;
    with 2 rows, 1 cols;  [-符合习惯-]

# --- 初始化 =1= --
# float2x2 fMatrix = { 0.0f, 0.1, // row 1
#                      2.1f, 2.2f // row 2
#                     }; 

# --- 初始化 =2= --
# float2x2 fMatrix = float2x2(  vec1.xy, // row 1
#                               vec2.xy  // row 2
#                            ); 
    注意此处的参数，
    vec1.xy 依次写入 m00, m01
    vec2.xy 依次写入 m10, m11
    这个顺序是 反直觉的 （通常来讲，我们希望输入的向量被布置为 竖向量...）
    他可能会影响后续的 mul() 中，矩阵参数 和 向量参数 的前后顺序

# --- 分量表达 =1= ---
# _m00, _m01, _m02, _m03
# _m10, _m11, _m12, _m13
# _m20, _m21, _m22, _m23
# _m30, _m31, _m32, _m33
# --- 分量表达 =2= ---
# _11, _12, _13, _14
# _21, _22, _23, _24
# _31, _32, _33, _34
# _41, _42, _43, _44
# --- 分量表达 =3= ---
# [0][0], [0][1], [0][2], [0][3]
# [1][0], [1][1], [1][2], [1][3]
# [2][0], [2][1], [2][2], [2][3]
# [3][0], [3][1], [3][2], [3][3]
    前一个数字表示 row_idx (H)， 后一个数字表示 col_idx (W)
    带 m 的表达，以 0 起步
    不带 的表达，以 1 起步  [-不符合习惯-]


# --- 将数个分量，联合成一个 向量 ---
# mat._m00_m11
# mat._11_22
# mat[0][0]_[1][1] - ERROR



# -- 访问某一列:
float3 row_0 = myMatrix[0];


# -- 计算逆矩阵:

#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
float4x4 inverseMatrix = Inverse(myMatrix);








