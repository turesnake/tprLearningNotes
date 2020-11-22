#ifndef UNIVERSAL_SIMPLE_LIT_PASS_INCLUDED
#define UNIVERSAL_SIMPLE_LIT_PASS_INCLUDED

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareNormalsTexture.hlsl"

// PI in Macros.hlsl


static const float3 baseColor = float3( 0.9, 0.4, 0.1 );
static const float MinDistanceToSurface = 0.01;
static const int MaxRaymarchingTimes = 200;


// 从 “检测边界” 到 ball center 的距离因子 [1,+inf]
// 用它 乘以 ball radius, 能获得实际的 “检测区半径值” pix
// ---
// 能控制 metaball 的粘稠程度 
static const float detectBorder = 23.7;
static const float invertDetectBorder = 1/detectBorder;


float4 _QuadBasePosWS; //xyz posWS


static const float ballNum = 3;
// VectorArray 不能被写进 Properties 中
float4 _BallPosesWS[ballNum];// xyz:posWS, w:radius




struct Attributes
{
    float4 positionOS    : POSITION;
    float3 normalOS      : NORMAL;
    float4 tangentOS     : TANGENT;
    float2 texcoord      : TEXCOORD0;
    float2 lightmapUV    : TEXCOORD1;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};


struct Varyings
{
    float2 uv                       : TEXCOORD0; // uv in texture 
    DECLARE_LIGHTMAP_OR_SH(lightmapUV, vertexSH, 1);

    float3 posWS                    : TEXCOORD2;    // xyz: posWS

#ifdef _NORMALMAP
    float4 normal                   : TEXCOORD3;    // xyz: normal, w: viewDir.x
    float4 tangent                  : TEXCOORD4;    // xyz: tangent, w: viewDir.y
    float4 bitangent                : TEXCOORD5;    // xyz: bitangent, w: viewDir.z
#else
    float3  normal                  : TEXCOORD3;
    float3 viewDir                  : TEXCOORD4;
#endif

    half4 fogFactorAndVertexLight   : TEXCOORD6; // x: fogFactor, yzw: vertex light

#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
    float4 shadowCoord              : TEXCOORD7;
#endif

    float4 positionCS               : SV_POSITION;
    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};


void InitializeInputData(Varyings input, half3 normalTS, out InputData inputData)
{
    inputData.positionWS = input.posWS;

#ifdef _NORMALMAP
    half3 viewDirWS = half3(input.normal.w, input.tangent.w, input.bitangent.w);
    inputData.normalWS = TransformTangentToWorld(normalTS,
        half3x3(input.tangent.xyz, input.bitangent.xyz, input.normal.xyz));
#else
    half3 viewDirWS = input.viewDir;
    inputData.normalWS = input.normal;
#endif

    inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
    viewDirWS = SafeNormalize(viewDirWS);

    inputData.viewDirectionWS = viewDirWS;

#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
    inputData.shadowCoord = input.shadowCoord;
#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
    inputData.shadowCoord = TransformWorldToShadowCoord(inputData.positionWS);
#else
    inputData.shadowCoord = float4(0, 0, 0, 0);
#endif

    inputData.fogCoord = input.fogFactorAndVertexLight.x;
    inputData.vertexLighting = input.fogFactorAndVertexLight.yzw;
    inputData.bakedGI = SAMPLE_GI(input.lightmapUV, input.vertexSH, inputData.normalWS);
    inputData.normalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(input.positionCS);
    inputData.shadowMask = SAMPLE_SHADOWMASK(input.lightmapUV);
}




///////////////////////////////////////////////////////////////////////////////
//                          Raymarching                         
///////////////////////////////////////////////////////////////////////////////



// 计算 步进点 到 模型表面的 距离
// param: P: 光线上步进的一点
float distanceToSurface( float3 P ){

    // frag 和 balls 的最近距离
    float minLen = 100000;

    // 最小 边界因子 [0,1]
    // 当 frag 位于某个 ball 的 detect Border 范围内时，将会计算出一个 [0,1] 的 临界因子
    // 这个因子会与 borderFactor 累乘，缩小 borderFactor 的值
    // 而那些 远离 detect Border 的 ball，它们的 临界因子 是一个大于 1 的值，
    // 会被 saturate 回1，（累乘计算不会修改 borderFactor）
    // 当把所有 ball 都考虑完毕后，将 borderFactor 和一个 边界限定值 做对比
    // 以此来确定，frag 是否在 粘稠体体内
    float borderFactor = 1.0;

    for( int i=0; i<ballNum; i++ ){

        float3 posOff = P - _BallPosesWS[i].xyz;
        float ballRadius = _BallPosesWS[i].w;
        float dist = length(posOff) - ballRadius;// frag 到 球心的距离 pix

        // dist >= detectBorderRadius: 1
        // dist <  detectBorderRadius: [0,1)
        float factor = saturate( dist / (ballRadius * detectBorder) );// 太远的被夹回 1

        borderFactor *= factor;

        minLen = min( minLen, dist );
    }

    return (borderFactor > invertDetectBorder ) ? minLen : 0;

}




///////////////////////////////////////////////////////////////////////////////
//                  Vertex and Fragment functions                            //
///////////////////////////////////////////////////////////////////////////////

// Used in Standard (Simple Lighting) shader
Varyings LitPassVertexSimple(Attributes input)
{
    Varyings output = (Varyings)0;

    UNITY_SETUP_INSTANCE_ID(input);
    UNITY_TRANSFER_INSTANCE_ID(input, output);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

    VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
    VertexNormalInputs normalInput = GetVertexNormalInputs(input.normalOS, input.tangentOS);
    half3 viewDirWS = GetWorldSpaceViewDir(vertexInput.positionWS);
    half3 vertexLight = VertexLighting(vertexInput.positionWS, normalInput.normalWS);
    half fogFactor = ComputeFogFactor(vertexInput.positionCS.z);

    // = (tex.xy) * tex_ST.xy + tex_ST.zw
    output.uv = TRANSFORM_TEX(input.texcoord, _BaseMap); // uv in texture 
    output.posWS.xyz = vertexInput.positionWS;
    output.positionCS = vertexInput.positionCS;

#ifdef _NORMALMAP
    output.normal = half4(normalInput.normalWS, viewDirWS.x);
    output.tangent = half4(normalInput.tangentWS, viewDirWS.y);
    output.bitangent = half4(normalInput.bitangentWS, viewDirWS.z);
#else
    output.normal = NormalizeNormalPerVertex(normalInput.normalWS);
    output.viewDir = viewDirWS;
#endif

    OUTPUT_LIGHTMAP_UV(input.lightmapUV, unity_LightmapST, output.lightmapUV);
    OUTPUT_SH(output.normal.xyz, output.vertexSH);

    output.fogFactorAndVertexLight = half4(fogFactor, vertexLight);

#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
    output.shadowCoord = GetShadowCoord(vertexInput);
#endif

    return output;
}



// Used for StandardSimpleLighting shader
float4 LitPassFragmentSimple(Varyings input) : SV_Target
{
    UNITY_SETUP_INSTANCE_ID(input);
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

    // uv in texture, NOT uvSS
    float2 uv = input.uv;
    half4 diffuseAlpha = SampleAlbedoAlpha(uv, TEXTURE2D_ARGS(_BaseMap, sampler_BaseMap));
    half3 diffuse = diffuseAlpha.rgb * _BaseColor.rgb;

    half alpha = diffuseAlpha.a * _BaseColor.a;
    // 此处禁止 clip
    //AlphaDiscard(alpha, _Cutoff);

    #ifdef _ALPHAPREMULTIPLY_ON
        diffuse *= alpha;
    #endif

    half3 normalTS = SampleNormal(uv, TEXTURE2D_ARGS(_BumpMap, sampler_BumpMap));
    half3 emission = SampleEmission(uv, _EmissionColor.rgb, TEXTURE2D_ARGS(_EmissionMap, sampler_EmissionMap));
    half4 specular = SampleSpecularSmoothness(uv, alpha, _SpecColor, TEXTURE2D_ARGS(_SpecGlossMap, sampler_SpecGlossMap));
    half smoothness = specular.a;

    InputData inputData;
    InitializeInputData(input, normalTS, inputData);

    //half4 color = UniversalFragmentBlinnPhong(inputData, diffuse, specular, smoothness, emission, alpha);
    //color.rgb = MixFog(color.rgb, inputData.fogCoord);
    //color.a = OutputAlpha(color.a, _Surface);
    //return color;

    // ================================================ //
    //                  Our Job
    // ================================================ //
    // 已知数据
    // inputData.viewDirectionWS
    // GetCurrentViewPosition() -- cameraPosWS
    // _ProjectionParams.z -- far plane depth
    // ...

    //float3 viewPosWS = GetCurrentViewPosition();
    float3 rayOriginWS = GetCurrentViewPosition();
    float3 rayDirWS = -normalize( inputData.viewDirectionWS );

    // balls data
    for( int i=0; i<ballNum; i++ ){
        _BallPosesWS[i].xyz += _QuadBasePosWS;
    }


    // ------------------------------ //
    //          Raymarching
    // ------------------------------ //
    float t = 0;
    // max t when ray hit far plane
    float max_t = abs( _ProjectionParams.z / TransformWorldToViewDir(rayDirWS,true).z );

    float  d; // distance form frag to metaball surface each time
    float3 X; // tPointPos
    bool isHit = false;

    int j=0;
    for(; j<MaxRaymarchingTimes; j++ ){
        X = rayOriginWS + rayDirWS * t;

        d = distanceToSurface(X);
        isHit = (d < MinDistanceToSurface);
        if( isHit ){ break; }

        t += d;
        if( t>max_t ){ break; }
    }

    float3 color;

    if( isHit ){
        color = float3( 1, 1, 1 );

    }else{
        color = float3( 0.1, 0.3, 0.5 );
    }

    return float4( color, 1 );


}

#endif
