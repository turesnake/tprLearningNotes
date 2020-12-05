#ifndef UNIVERSAL_SIMPLE_LIT_PASS_INCLUDED
#define UNIVERSAL_SIMPLE_LIT_PASS_INCLUDED

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareNormalsTexture.hlsl"

// PI in Macros.hlsl


TEXTURE2D ( _TunnelTex ); SAMPLER ( sampler_TunnelTex );


#include "noises/snoise.hlsl"
#include "noises/gradientNoise3D.hlsl"


// ================================================ // 


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

    float4 posSS                    : TEXCOORD8; // 存在 8 号吗？

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



/*
void InitializeInputData(Varyings input, half3 normalTS, out InputData inputData)
{
    inputData.positionWS = input.posWS;

#ifdef _NORMALMAP // 测试表面，此 keyword 并未被声明 
    half3 viewDirWS = half3(input.normal.w, input.tangent.w, input.bitangent.w);
    inputData.normalWS = TransformTangentToWorld(normalTS,
        half3x3(input.tangent.xyz, input.bitangent.xyz, input.normal.xyz));
#else
    // 常用这段
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
*/



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

    output.posSS = ComputeScreenPos( output.positionCS );

    return output;
}



// Used for StandardSimpleLighting shader
float4 LitPassFragmentSimple(Varyings input) : SV_Target
{
    /*
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
    */

    

    // ================================================ //
    //                  Tunnel
    // Learn from Inigo Quilez:
    //     https://www.shadertoy.com/view/Ms2SWW
    // ================================================ //
    // 已知数据
    // inputData.viewDirectionWS = SafeNormalize(input.viewDir);
    // GetCurrentViewPosition() -- cameraPosWS
    // _ProjectionParams.z -- far plane depth
    // ...


    //float3 viewPosWS = GetCurrentViewPosition();
    float3 rayOriginWS = GetCurrentViewPosition();
    //float3 rayDirWS = -normalize( inputData.viewDirectionWS );
    float3 rayDirWS = -SafeNormalize( input.viewDir );

    float2 uvSS = input.posSS.xy / input.posSS.w; // 延迟的 齐次除法
    float2 coordSS = uvSS * 2.0 - 1.0; // [-1,1]


    // ------------------------------ //
    //           tunnel
    // ------------------------------ //

    // squareish tunnel
    // 一个三维的 方形截面 的漏斗，(0,0)位置值最小（接近0）外侧逐渐升高
    // 这个 deep 求得就是这个图形中的 z值
    // ---
    float powNum = 8.0;
    float deep = pow( pow(abs(coordSS.x),powNum) + pow(abs(coordSS.y),powNum), 1.0/powNum );
    //float deep = abs(coordSS.x) + abs(coordSS.y);


    // angle of each pixel to the center of the screen
    // 求 frag 在 球极坐标系 中的弧度值 [-PI,PI]
    // PI 到 -PI 的分界线，是 -X轴。这个位置附近的 pix 如果不正确处理，将会出现 明显的分界线
    // ---
    // 为了处理这个问题，额外准备了值 b，在此计算中，左半球的所有pix，都将计算出一个 和右半球 相同的值
    // 在 b 中，四个象限的值都是连续的: 0 -> PI/2 -> 0 -> PI/2 -> 0
    float a = atan2(coordSS.y,coordSS.x);       // [-PI, PI]
    float b = atan2(coordSS.y, abs(coordSS.x)); // [-0.5PI, 0.5PI]


    float time = 0.2*_Time.y;// anim


    // index texture by (animated inverse) radious and angle
    // x: 1/deep * n
    //     deep 越接近 (0,0) 值越接近0；1/deep 则能获得一个接近 无限大 的值
    //     用这个值 去采样，可实现一个 无限神的 洞
    // y: radian/PI
    //     在 上下两个半圆中，各自获得一个 [0,1] 区间值 （顺时针方向）
    // ---
    // 
    float2 uv1 = float2( 1/deep + time, a/PI );
    float2 uvR = float2( 1/deep + time, b/PI );


    // 用 ddx,ddy 来重新指定每个 pix 的 偏导数。而这个偏导数 则是从 uvR 中计算得到的
    // 由于 uvR 是一个 4个象限都连续的 值，所以计算得到的 偏导数 也是连续的
    // 修复了 -X轴 断裂的 问题
    // ---    
    float3 col = SAMPLE_TEXTURE2D_GRAD( _TunnelTex, sampler_TunnelTex, uv1, ddx(uvR), ddy(uvR) ).xyz;

    // darken at the center    
    col = col*deep * deep;

    return float4( col, 1 );
    

}

#endif
