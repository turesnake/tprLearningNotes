# ================================================================ #
#         core: Common.hlsl 实现的内容
# ================================================================ #

"Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"





# ---------------------------------- #
#  GetQuadOffset
float2 GetQuadOffset(int2 screenPos)

// 得到这个像素在自己所在的 quad 中的 offset: 左下:(-1,-1), 右上(1,1)

# QuadReadAcross_ ...
一系列这个名字开头的函数;


# ---------------------------------- #
# Swap
void Swap( inout T a, inout T b );
一系列交换函数, 可以交换两参数: a,b


# ---------------------------------- #
#  CubeMap 系列:

# CubeMapFaceID
float CubeMapFaceID(float3 dir)
传入一个 dir向量, 得到对应的 cubemap idx; 


# ---------------------------------- #
#  一系列 数值 检测函数:
bool IsNaN(float x)
bool AnyIsNaN(float2 v)
bool IsInf(float x)
bool AnyIsInf(float2 v)
bool IsFinite(float x)
float SanitizeFinite(float x)   // 若 x 为 finite, 则返回 x, 否则返回 0;
bool IsPositiveFinite(float x)
float SanitizePositiveFinite(float x)


# ---------------------------------- #
#  弧度 角度 互换
real DegToRad(real deg)
real RadToDeg(real rad)


# ---------------------------------- #
#  Sq
T Sq(T a);       平方函数; 得到 a*a; (各分量独立运算)


# ---------------------------------- #
#    IsPower2
bool IsPower2(uint x);     是不是 2 的 X 次方值;


# ---------------------------------- #
#   反三角函数
real FastACosPos(real inX);    // Input [0, 1] and output [0, PI/2]
real FastACos(real inX);       // Input [-1, 1] and output [0, PI]
real FastASin(real x);         // input [-1, 1] and output [-PI/2, PI/2]
real FastATanPos(real x);      // input [0, infinity] and output [0, PI/2]
real FastATan(real x);         // input [-infinity, infinity] and output [-PI/2, PI/2]
real FastAtan2(real y, real x); // 

# ---------------------------------- #
#   FastLog2
uint FastLog2(uint x);         // 得到 参数 x 的粗略的 指数级数, 比如, 8, 将得到 3


# ---------------------------------- #
#  PositivePow
T PositivePow (base, power)
普通的 pow() 函数要求参数 base 为 正数, 否则编译器会报错; 但是对于那些我们知道它是正数的 参数, 
每次都手动写入 abs(base) 就很麻烦,
本函数 解决了此问题;

类似的还有这几个函数:
SafePositivePow
SafePositivePow_float
SafePositivePow_half


# ---------------------------------- #
#  得到一些 类型的 极限值:
float Eps_float() { return FLT_EPS; }
float Min_float() { return FLT_MIN; }
float Max_float() { return FLT_MAX; }
half Eps_half() { return HALF_EPS; }
half Min_half() { return HALF_MIN; }
half Max_half() { return HALF_MAX; }


# ---------------------------------- #
# sign 相关的 (正负符号)
float CopySign(float x, float s, bool ignoreNegZero = true);    // 把 参数s的符号给 x, 返回新的 x;
float FastSign(float s, bool ignoreNegZero = true);             // 若s为正,返回 1, 否则返回 -1;  (此描述有点含糊,建议看源码)


# ---------------------------------- #
#   Orthonormalize
real3 Orthonormalize(real3 tangent, real3 normal);
假设, 参数 tangent 和 normal 并不相互垂直, 使用此函数, 可得到一个 与 normal 垂直的 新的 tangent 向量;


# ---------------------------------- #
# remap 系列函数
Remap01         // [start, end] -> [0, 1]
Remap10         // [start, end] -> [1, 0]

real2 RemapHalfTexelCoordTo01(real2 coord, real2 size);
    // 这个映射是这样的:
    // 假设一个 4x4 的texture, (size = 4), 每个 texel 中心位置有个点; 若以 uv 值为基准, 
    // 则最左端为 0, 最右端为 1;
    // 则 最左端的 texel 的中点为 0.5/size, 最右端的 texel 的中点为 1 - 0.5/size
    // 本函数, 将这两个 中点值 之间的区间, 映射为 [0,1]

real2 Remap01ToHalfTexelCoord(real2 coord, real2 size);
    与上一个相反

# ---------------------------------- #
# smoothstep 系列函数
real Smoothstep01(real x)
real Smootherstep01(real x)
real Smootherstep(real a, real b, real t)

# ---------------------------------- #
# NLerp
float3 NLerp(float3 A, float3 B, float t)
先 lerp() 运算, 后 normalize() 运算;


# ---------------------------------- #
# Length2
float Length2(float3 v)
得到参数 v 向量的 "长度的平方"


# ---------------------------------- #
# Pow4
real Pow4(real x)
四次方

# ---------------------------------- #
# RangeRemap
T RangeRemap(min, max, t);
得到 t 在 [mi,max] 区间的 比值;


# ---------------------------------- #
# Inverse
float4x4 Inverse(float4x4 m)
计算矩阵 m 的 逆矩阵;


# ---------------------------------- #
#   ComputeTextureLOD
float ComputeTextureLOD(float2 uvdx, float2 uvdy, float2 scale, float bias = 0.0)
float ComputeTextureLOD(float2 uv, float bias = 0.0)
float ComputeTextureLOD(float2 uv, float2 texelSize, float bias = 0.0)
float ComputeTextureLOD(float3 duvw_dx, float3 duvw_dy, float3 duvw_dz, float scale, float bias = 0.0)

# ---------------------------------- #
#   GetMipCount
uint GetMipCount(TEXTURE2D_PARAM(tex, smp))

得到: The number of mipmap levels.


# ---------------------------------- #
#    经纬度  方向向量   之间的转换
float2 DirectionToLatLongCoordinate(float3 unDir)
float3 LatlongToDirectionCoordinate(float2 coord)

此处的经纬度 有点不够直观... 建议用 https://graphtoy.com/ 实际演示下 函数1中返回值的两个分量的区间;


# ---------------------------------- #
#  Depth encoding/decoding
float Linear01DepthFromNear(float depth, float4 zBufferParam)
float Linear01Depth(float depth, float4 zBufferParam)
float LinearEyeDepth(float depth, float4 zBufferParam)
float LinearEyeDepth(float2 positionNDC, float deviceDepth, float4 invProjParam)
float LinearEyeDepth(float3 positionWS, float4x4 viewMatrix)
float EncodeLogarithmicDepthGeneralized(float z, float4 encodingParams)
float DecodeLogarithmicDepthGeneralized(float d, float4 decodingParams)
float EncodeLogarithmicDepth(float z, float4 encodingParams)
float DecodeLogarithmicDepth(float d, float4 encodingParams)


# ---------------------------------- #
#    前后景 两个颜色的混合
real4 CompositeOver(real4 front, real4 back)
void CompositeOver(...)


# ---------------------------------- #
# Space transformations
float4 ComputeClipSpacePosition(float2 positionNDC, float deviceDepth)
float4 ComputeClipSpacePosition(float3 position, float4x4 clipSpaceTransform = k_identity4x4)
float3 ComputeNormalizedDeviceCoordinatesWithZ(float3 position, float4x4 clipSpaceTransform = k_identity4x4)
float2 ComputeNormalizedDeviceCoordinates(float3 position, float4x4 clipSpaceTransform = k_identity4x4)
float3 ComputeViewSpacePosition(float2 positionNDC, float deviceDepth, float4x4 invProjMatrix)
float3 ComputeWorldSpacePosition(float2 positionNDC, float deviceDepth, float4x4 invViewProjMatrix)
float3 ComputeWorldSpacePosition(float4 positionCS, float4x4 invViewProjMatrix)


# ---------------------------------- #
#    PositionInputs
struct PositionInputs;

PositionInputs GetPositionInput(float2 positionSS, float2 invScreenSize, uint2 tileCoord)
PositionInputs GetPositionInput(float2 positionSS, float2 invScreenSize)
PositionInputs GetPositionInput(float2 positionSS, float2 invScreenSize, float3 positionWS)
...
void ApplyDepthOffsetPositionInput(float3 V, float depthOffsetVS, float3 viewForwardDir, float4x4 viewProjMatrix, inout PositionInputs posInput)


# ---------------------------------- #
#     Heightmap 的打包和解包
real4 PackHeightmap(real height)
real UnpackHeightmap(real4 height)






# ---------------------------------- #
#    HasFlag
bool HasFlag(uint bitfield, uint flag)
查看 bitfield 里有没有目标 flag; 
参数 flag 其实也是一个 bitmask...

# ---------------------------------- #
#   Normalize
real3 SafeNormalize(float3 inVec)
bool IsNormalized(float3 inVec)


real SafeDiv(real numer, real denom)
real SafeSqrt(real x)


# ---------------------------------- #
#    SinFromCos
real SinFromCos(real cosX)
// Assumes that (0 <= x <= Pi).
拿着 cos 值计算 sin 值;


# ---------------------------------- #
#     SphericalDot
real SphericalDot(real cosTheta1, real phi1, real cosTheta2, real phi2)
    // Dot product in spherical coordinates.
    // 两个向量, 都用 球极坐标系 来表达: (Theta1, phi1), (Theta2, phi2);  这两个向量应该都是 归一化的
    // 然后使用本函数来计算这两个 向量的点击;


# ---------------------------------- #
#    GetFullScreenTriangleTexCoord
float2 GetFullScreenTriangleTexCoord(uint vertexID)
    // Generates a triangle in homogeneous clip space, s.t.
    // v0 = (-1, -1, 1), v1 = (3, -1, 1), v2 = (-1, 3, 1).
    // 这是一个巨大的 三角形, 它恰好能覆盖 [-1,1] 这个 HCS.xy 区间;
    // 向此函数传入 3个 顶点idx: {0,1,2}
    // 得到: 三个顶点的 新的坐标 xy: 
    //    版本1: { (0,0), (2,0), (0,2) }
    //    版本2: { (0,1), (2,-1), (0,-1) }
    // 可在坐标系上画出这两组坐标, 可看到, 它们也都是一个三角形, 包裹住了 [0,1] 这个正方形区间;


float4 GetFullScreenTriangleVertexPosition(uint vertexID, float z = UNITY_NEAR_CLIP_VALUE)
类似的, 没细看;


# ---------------------------------- #
#  GetQuadTexCoord
float2 GetQuadTexCoord(uint vertexID)
输入 {0,1,2,3}
得到 quad: 2x2一共4个像素 的每个像素的 坐标offset


# ---------------------------------- #
#  GetStencilValue
uint GetStencilValue(uint2 stencilBufferVal)
    // 有些 平台把 stencil值 存储在 r通道, 有些则存储在 g通道...
    所以使用本函数来 安全地提取...


# ---------------------------------- #
#  ClampToFloat16Max() 一系列函数
// 将参数 value 限制住, 使其不超过 HALF_MAX;









