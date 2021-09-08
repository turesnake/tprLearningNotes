// ramp texture
// + pix_BlinnPhong (lambert + specular)

// 名义上，可以实现更细腻的光照效果，但本 shader 暂不支持 法线贴图
// 这意味着如果用它来渲染 一个 低模球体，这个球体仍然是 块面分明的 

// 只支持一盏 平行光 （scene 默认光）
// 额外灯光 一律不支持

// ----------------------
// 实现某种卡通风格的 着色
// 仅仅实现了 色调控制部分，轮廓线没有实现


Shader "tpr/tpr_005_RampTexture"
{
    Properties
    {
        _Color ("Diffuse", Color) = ( 1.0, 1.0, 1.0, 1.0 )

        _RampTex ( "Ramp Tex", 2D ) = "white" {}
            // 绑定的 纹理文件，需要设置 Wrap Mode: Clamp
            // 防止因浮点数精度问题，在高光区出现 小黑点

        // 控制 高光反射颜色
        _Specular ("Specular", Color) = ( 1.0, 1.0, 1.0, 1.0 )
        // 控制 高光区域大小
        _Gloss ("Gloss", Range(8.0, 256.0)) = 20.0

    }
    SubShader
    {
        Tags { 
            "RenderType"="Opaque" 
        }
        LOD 100

        //-------------------------------//
        //     
        //-------------------------------//
        Pass
        {
            Tags{
                "LightMode" = "ForwardBase"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc" 
                // _LightColor0

            // Properties 
            sampler2D _RampTex;
            float4 _RampTex_ST;

            fixed4 _Color;
            fixed4 _Specular;
            float _Gloss;


            struct appdata{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f{
                float4 posHCS : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float2 uv : TEXCOORD2;
            };        


            v2f vert ( appdata v ){
                v2f o;
                // obj-space to clip-space
                o.posHCS = UnityObjectToClipPos( v.vertex );
                o.worldNormal = UnityObjectToWorldNormal( v.normal );
                o.worldPos = mul( unity_ObjectToWorld, v.vertex).xyz;
                o.uv = TRANSFORM_TEX( v.texcoord, _RampTex );
                return o;
            }
            

            fixed4 frag( v2f i ) : SV_Target{

                fixed3 worldNormal = normalize( i.worldNormal ); // MUST normalize !!!
                fixed3 worldLightDir = normalize( UnityWorldSpaceLightDir(i.worldPos) );// MUST normalize !!!
                fixed3 viewDir = normalize( UnityWorldSpaceViewDir(i.worldPos) );// MUST normalize !!!


                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;

                fixed halfLambert = 0.5 * dot(worldNormal,worldLightDir) + 0.5;
                fixed3 diffuseColor = tex2D( _RampTex, fixed2(halfLambert,halfLambert) ).rgb * _Color.rgb;

                fixed3 diffuse = _LightColor0.rgb * diffuseColor;


                //--- specular ---//
                fixed3 halfDir = normalize( worldLightDir + viewDir );

                fixed3 specular = _LightColor0.rgb * _Specular.rgb * 
                    pow( max(0.0, dot( worldNormal, halfDir)), _Gloss );

                fixed3 color = ambient + diffuse + specular;
                return fixed4(
                    color,
                    1.0
                );
            }

            ENDCG
        }
        
    }
    Fallback "Specular"
}

