#ifndef UNIVERSAL_SIMPLE_LIT_PASS_INCLUDED
#define UNIVERSAL_SIMPLE_LIT_PASS_INCLUDED

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareNormalsTexture.hlsl"




TEXTURE2D ( _FlatMap ); SAMPLER ( sampler_FlatMap );
float _FlatMapRadius;
float4 _CenterPosWS; //xyz posWS


// 用这个矩阵，来计算 虚拟球空间内的坐标
float4 _QuadCoord0;
float4 _QuadCoord1;
float4 _QuadCoord2;

// PI in Macros.hlsl



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


// Combines the top and bottom colors using normal blending.
// https://en.wikipedia.org/wiki/Blend_modes#Normal_blend_mode
// This performs the same operation as Blend SrcAlpha OneMinusSrcAlpha.
/*
float4 alphaBlend(float4 top, float4 bottom)
{
	float3 color = (top.rgb * top.a) + (bottom.rgb * (1 - top.a));
	float alpha = top.a + bottom.a * (1 - top.a);

	return float4(color, alpha);
}
*/


///////////////////////////////////////////////////////////////////////////////
//                          Quad Sphere                          
///////////////////////////////////////////////////////////////////////////////


// param: oc: view - sphere_center
// param: rayDir: normalize
// ret: t
// ---
// in World-Space
float calc_hitT( float3 oc, float3 rayDir ){

    float a = dot( rayDir, rayDir );
    float b = 2 * dot( oc, rayDir );
    float c = dot(oc,oc) - _FlatMapRadius*_FlatMapRadius;
    float discriminant = b*b - 4*a*c;

    // if 判别式小于0，说明射线没有命中 sphere
    clip( discriminant ); 
        //if( discriminant < 0 ){return -99;}


    float sqrtD = sqrt(discriminant);
    float t = (-b - sqrtD) / 2*a;// 简化实现
    // 当 view 进入 sphere，直接放弃渲染此 quad
    clip( t ); 
        //if( t < 0 ){return -99;}

    return t;
}


// param: dir: hitPos-sphere_center; normalize
// ---
// in World-Space
float2 calc_uv( float3 dir ){

    float3 i = normalize(float3(
        dot( _QuadCoord0, dir ),
        dot( _QuadCoord1, dir ),
        dot( _QuadCoord2, dir )
    ));

    // ms-manual 说：当 y=0，atan2() 会出问题
    // 暂未处理, 但并未发生问题...
    return float2(
        (PI + atan2(i.y, i.x)) / (2*PI),
        (PI - acos(i.z)) / PI // 半径为1
    );
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
half4 LitPassFragmentSimple(Varyings input) : SV_Target
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

    // ---------------------------------- //
    //             Flat Tex
    // ---------------------------------- //
    // 已知数据
    // inputData.viewDirectionWS
    // GetCurrentViewPosition() -- cameraPosWS

    float3 viewPosWS = GetCurrentViewPosition();
    float3 rayDirWS = -normalize( inputData.viewDirectionWS );

    float hitT = calc_hitT(
        viewPosWS - _CenterPosWS.xyz,
        rayDirWS
    );

        //if( hitT>-100 && hitT<-98 ){
        //    return float4( 0, 0, 1, 1 );
        //}

    float3 hitPosWS = viewPosWS + (hitT * rayDirWS );
    float2 sphereUV = calc_uv( normalize( hitPosWS - _CenterPosWS.xyz ) );
    float3 albedo = SAMPLE_TEXTURE2D( _FlatMap, sampler_FlatMap, sphereUV );

    return float4( albedo, 1 );

}

#endif
