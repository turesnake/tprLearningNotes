#ifndef UNIVERSAL_INPUT_INCLUDED
#define UNIVERSAL_INPUT_INCLUDED


#define MAX_VISIBLE_LIGHTS_UBO  32
#define MAX_VISIBLE_LIGHTS_SSBO 256
#define USE_STRUCTURED_BUFFER_FOR_LIGHT_DATA 0


#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderTypes.cs.hlsl"


#if defined(SHADER_API_MOBILE) || 
    (defined(SHADER_API_GLCORE) && !defined(SHADER_API_SWITCH)) || // Workaround for bug on Nintendo Switch where SHADER_API_GLCORE is mistakenly defined
    defined(SHADER_API_GLES) || 
    defined(SHADER_API_GLES3) 
    // 低端平台
    #define MAX_VISIBLE_LIGHTS 32
#else  
    // 高端平台
    #define MAX_VISIBLE_LIGHTS 256
#endif



// 被各个 urp.shaders 广泛应用
struct InputData
{
    float3  positionWS;
    half3   normalWS;
    half3   viewDirectionWS;
    float4  shadowCoord; // =posSTS
    half    fogCoord;
    half3   vertexLighting;
    half3   bakedGI;
};



///////////////////////////////////////////////////////////////////////////////
//                      Constant Buffers                                     //
///////////////////////////////////////////////////////////////////////////////

half4 _GlossyEnvironmentColor;
half4 _SubtractiveShadowColor;

#define _InvCameraViewProj unity_MatrixInvVP
// 源自: UniversalRenderPipelineCore.cs
float4 _ScaledScreenParams;


// 主光源数据，源自: ForwardLights.cs
// 即可存为 lightPos, 又可存为 lightDir，若 w==1.0, 则存储的是 非平行光的 pos
float4 _MainLightPosition;
half4 _MainLightColor;


// Global object render pass data containing various settings.
// x,y,z are currently unused
// w is used for knowing whether the object is opaque(1) or alpha blended(0)
half4 _DrawObjectPassData;


// 主光源数据，源自: ForwardLights.cs
half4 _AdditionalLightsCount;



#if USE_STRUCTURED_BUFFER_FOR_LIGHT_DATA
    // // 主光源数据，源自: ForwardLights.cs
    // StructuredBuffer, 一个类似 std::vector<T> 的范型容器
    StructuredBuffer<LightData> _AdditionalLightsBuffer;
    StructuredBuffer<int>       _AdditionalLightsIndices;
#else
    // GLES3 causes a performance regression in some devices when using CBUFFER.
    // 在 GLES3 中，如果使用 CBUFFER，某些设备性能会下降。 
    // 只在 非 GLES3 平台，开启 CBUFFER 功能:
    #ifndef SHADER_API_GLES3
        CBUFFER_START(AdditionalLights)
    #endif

        // 主光源数据，源自: ForwardLights.cs
        float4 _AdditionalLightsPosition[MAX_VISIBLE_LIGHTS];
        half4 _AdditionalLightsColor[MAX_VISIBLE_LIGHTS];
        half4 _AdditionalLightsAttenuation[MAX_VISIBLE_LIGHTS];
        half4 _AdditionalLightsSpotDir[MAX_VISIBLE_LIGHTS];
        half4 _AdditionalLightsOcclusionProbes[MAX_VISIBLE_LIGHTS];

    #ifndef SHADER_API_GLES3
        CBUFFER_END
    #endif
#endif


// 常用变换矩阵
#define UNITY_MATRIX_M     unity_ObjectToWorld
#define UNITY_MATRIX_I_M   unity_WorldToObject
#define UNITY_MATRIX_V     unity_MatrixV
#define UNITY_MATRIX_I_V   unity_MatrixInvV
#define UNITY_MATRIX_P     OptimizeProjectionMatrix(glstate_matrix_projection)
#define UNITY_MATRIX_I_P   ERROR_UNITY_MATRIX_I_P_IS_NOT_DEFINED
#define UNITY_MATRIX_VP    unity_MatrixVP
#define UNITY_MATRIX_I_VP  unity_MatrixInvVP
#define UNITY_MATRIX_MV    mul(UNITY_MATRIX_V, UNITY_MATRIX_M)
#define UNITY_MATRIX_T_MV  transpose(UNITY_MATRIX_MV)
#define UNITY_MATRIX_IT_MV transpose(mul(UNITY_MATRIX_I_M, UNITY_MATRIX_I_V))
#define UNITY_MATRIX_MVP   mul(UNITY_MATRIX_VP, UNITY_MATRIX_M)


#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityInput.hlsl"
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/SpaceTransforms.hlsl"

#endif
