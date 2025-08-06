/*
    三平面映射采样

    原始文章:
    https://bgolus.medium.com/normal-mapping-for-a-triplanar-shader-10bf39dca05a

*/
Shader "tpr/Triplanar Mapping Normal"
{
    Properties
    {
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {} // 目标 texture
        _TextureScale("_TextureScale", Float) = 1.0
        _TriplannarBlendSharpness("_TriplannarBlendSharpness", Float) = 1.0
        _ColorPct("固有色显示百分比", Range(0,1)) = 0.5

        //---
        [NoScaleOffset] _BumpMap("Normal Map", 2D) = "bump" {}
        [HideInInspector] _BumpScale("Scale", Float) = 1.0
        _NormalScale("_NormalScale", Float) = 1.0
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
        }
        LOD 100

        Pass
        {

            Name "tpr_texture_color"

            HLSLPROGRAM

            #pragma vertex vert 
            #pragma fragment frag 

            #define _NORMALMAP 1 // 强开 法线贴图

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
            

            // SurfaceInput 文件里声明过了:
            // TEXTURE2D( _BaseMap );   SAMPLER( sampler_BaseMap );
            // TEXTURE2D( _BumpMap );   SAMPLER( sampler_BumpMap );


            // 为支持 SRP Batcher 功能, 所有 material properties 都要被整合进 cbuffer 中
            // 参数是 cbuffer 的名字
            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                float _TextureScale;
                float _TriplannarBlendSharpness;
                float _ColorPct;
                float _NormalScale;
            CBUFFER_END


            struct Attributes{
                float4 posOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float2 uv    : TEXCOORD0;
            };


            struct Varyings{
                float4 posHCS : SV_POSITION;
                float2 uv     : TEXCOORD0;
                //--
                float3  positionOS          : TEXCOORD1;
                float3  normalOS          : TEXCOORD2;
                //--
                float3 positionWS        : TEXCOORD3;
                float3  normalWS          : TEXCOORD4;
            };


            Varyings vert( Attributes input )
            {
                Varyings o;
                // #define TRANSFORM_TEX(tex, name) ((tex.xy) * name##_ST.xy + name##_ST.zw)
                o.uv = TRANSFORM_TEX( input.uv, _BaseMap ); 
                //--
                o.positionWS = TransformObjectToWorld( input.posOS.xyz );
                VertexNormalInputs normalInput = GetVertexNormalInputs(input.normalOS, input.tangentOS);
                o.normalWS = normalInput.normalWS;  
                //--
                o.posHCS = TransformObjectToHClip( input.posOS.xyz );
                o.positionOS = input.posOS.xyz;
                o.normalOS = input.normalOS;
                return o;
            }


            float3 SampleColor( Varyings input ) 
            {
                float3 pos = input.positionWS;

                float2 xUV = pos.zy / _TextureScale;
                float2 yUV = pos.xz / _TextureScale;
                float2 zUV = pos.xy / _TextureScale;

                float3 xDiff = SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, xUV );
                float3 yDiff = SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, yUV );
                float3 zDiff = SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, zUV );

                // 三平面边界过度锐利度
                float3 blendWeights = pow( abs(input.normalOS), _TriplannarBlendSharpness );
                // 此处不能用 normalize(), 否则交界处会出现白边;
                blendWeights = blendWeights / (blendWeights.x + blendWeights.y + blendWeights.z);

                float3 color = xDiff * blendWeights.x + yDiff * blendWeights.y + zDiff * blendWeights.z;
                return color;
            }



            // -1- 性能好:
            float3 SampleNormal_UDN( Varyings input ) 
            {
                //--------------
                float3 pos = input.positionWS;
                float3 normalWorld = input.normalWS;

                float2 xUV = pos.zy / _NormalScale;
                float2 yUV = pos.xz / _NormalScale;
                float2 zUV = pos.xy / _NormalScale;

                // Tangent space normal maps
                float3 xNormalTS = SampleNormal(xUV, TEXTURE2D_ARGS(_BumpMap, sampler_BumpMap));
                float3 yNormalTS = SampleNormal(yUV, TEXTURE2D_ARGS(_BumpMap, sampler_BumpMap));
                float3 zNormalTS = SampleNormal(zUV, TEXTURE2D_ARGS(_BumpMap, sampler_BumpMap));
                
                // Swizzle world normals into tangent space and apply UDN blend.
                // These should get normalized, but it's very a minor visual
                // difference to skip it until after the blend.
                xNormalTS = half3(xNormalTS.xy + normalWorld.zy, normalWorld.x);
                yNormalTS = half3(yNormalTS.xy + normalWorld.xz, normalWorld.y);
                zNormalTS = half3(zNormalTS.xy + normalWorld.xy, normalWorld.z);

                // 三平面边界过度锐利度
                float3 blendWeights = pow( abs(normalWorld), _TriplannarBlendSharpness );
                // 此处不能用 normalize(), 否则交界处会出现白边;
                blendWeights = blendWeights / (blendWeights.x + blendWeights.y + blendWeights.z);

                // Swizzle tangent normals to match world orientation and triblend
                half3 worldNormal = normalize(
                    xNormalTS.zyx * blendWeights.x +
                    yNormalTS.xzy * blendWeights.y +
                    zNormalTS.xyz * blendWeights.z
                    );

                return worldNormal;
            }



            // -2- 效果好, 成本比 UDN 版略高:
            float3 SampleNormal_Whiteout( Varyings input ) 
            {
                //--------------
                float3 pos = input.positionWS;
                float3 normalWorld = input.normalWS;

                float2 xUV = pos.zy / _NormalScale;
                float2 yUV = pos.xz / _NormalScale;
                float2 zUV = pos.xy / _NormalScale;

                // Tangent space normal maps
                float3 xNormalTS = SampleNormal(xUV, TEXTURE2D_ARGS(_BumpMap, sampler_BumpMap));
                float3 yNormalTS = SampleNormal(yUV, TEXTURE2D_ARGS(_BumpMap, sampler_BumpMap));
                float3 zNormalTS = SampleNormal(zUV, TEXTURE2D_ARGS(_BumpMap, sampler_BumpMap));

                // 三平面边界过度锐利度
                float3 blendWeights = pow( abs(normalWorld), _TriplannarBlendSharpness );
                // 此处不能用 normalize(), 否则交界处会出现白边;
                blendWeights = blendWeights / (blendWeights.x + blendWeights.y + blendWeights.z);

                // Swizzle world normals into tangent space and apply Whiteout blend
                xNormalTS = half3(
                    xNormalTS.xy + normalWorld.zy,
                    abs(xNormalTS.z) * normalWorld.x
                    );
                yNormalTS = half3(
                    yNormalTS.xy + normalWorld.xz,
                    abs(yNormalTS.z) * normalWorld.y
                    );
                zNormalTS = half3(
                    zNormalTS.xy + normalWorld.xy,
                    abs(zNormalTS.z) * normalWorld.z
                    );
                // Swizzle tangent normals to match world orientation and triblend
                half3 worldNormal = normalize(
                    xNormalTS.zyx * blendWeights.x +
                    yNormalTS.xzy * blendWeights.y +
                    zNormalTS.xyz * blendWeights.z
                    );
                return worldNormal;
            }



            half4 frag( Varyings input ) : SV_Target
            {
                float3 albedo = SampleColor(input);
                float3 color = lerp( float3(0.5,0.5,0.5), albedo, saturate(_ColorPct) );


                float3 normalWS2 = SampleNormal_UDN(input);
                //float3 normalWS2 = SampleNormal_Whiteout(input);

                Light light = GetMainLight();
                float3 lightDirWS = light.direction;

                float3 diffuse =  color.rgb * 
                    saturate( dot( normalWS2, lightDirWS ) );
                //diffuse = color;

                return float4( diffuse.xyz, 1 );
            }

            ENDHLSL
        }
    }


}