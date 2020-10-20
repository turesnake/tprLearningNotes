// mask texture
// + pix_BlinnPhong (lambert + specular)


// 只支持一盏 平行光 （scene 默认光）
// 额外灯光 一律不支持

Shader "tpr/tpr_006_MaskTexture"
{
    Properties
    {
        _MainTex ( "Main Tex", 2D ) = "white" {}
        
        _Color ("Diffuse", Color) = ( 1.0, 1.0, 1.0, 1.0 )

        //-- 法线贴图 --
        _BumpMap ("Normal Map", 2D) = "bump" {}
            // "bump" 是 unity 内置法线纹理
        _BumpScale ("Bump Scale", Float) = 1.0
            // 控制 凹凸 强度，若为0，表示 法线贴图 不起作用

        //-- 高光反射遮罩贴图 --
        _SpecularMask ("Specular Mask", 2D) = "white" {}
        _SpecularScale ("Specular Scale", Float) = 1.0

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
        //          切线空间
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
            sampler2D _MainTex;
            float4 _MainTex_ST;
                // MainTex, BumpMap, SpecularMask 共用

            sampler2D _BumpMap;
            float _BumpScale;

            sampler2D _SpecularMask;
            float _SpecularScale;

            fixed4 _Color;
            fixed4 _Specular;
            float _Gloss;


            struct appdata{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f{
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 lightDir : TEXCOORD1;// tangent-space
                float3 viewDir : TEXCOORD2; // tangent-space
            };        


            v2f vert ( appdata v ){
                v2f o;
                // vertex.pos, obj-space to clip-space
                o.pos = UnityObjectToClipPos( v.vertex );

                o.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;// 材质贴图坐标

                TANGENT_SPACE_ROTATION;
                o.lightDir = mul( rotation, ObjSpaceLightDir(v.vertex) ).xyz;
                o.viewDir = mul( rotation, ObjSpaceViewDir(v.vertex) ).xyz;

                return o;
            }


            fixed4 frag( v2f i ) : SV_Target{
                
                fixed3 tangentLightDir = normalize(i.lightDir);
                fixed3 tangentViewDir = normalize(i.viewDir);

                fixed3 tangentNormal = UnpackNormal(tex2D( _BumpMap, i.uv ));
                tangentNormal.xy *= _BumpScale;
                tangentNormal.z = sqrt(
                    1.0 - saturate(dot( tangentNormal.xy, tangentNormal.xy ))
                );

                // 采样 材质纹素
                fixed3 albedo = tex2D(_MainTex, i.uv ).rgb * _Color.rgb;

                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;

                
                fixed3 diffuse = _LightColor0.rgb * albedo * 
                    saturate( dot( tangentNormal, tangentLightDir ) );

                //--- specular ---//
                fixed3 halfDir = normalize( tangentLightDir + tangentViewDir );

                fixed specularMask = tex2D(_SpecularMask, i.uv).x * _SpecularScale;
                    // 实际上只使用了 一个分量 x
                    // 剩余分量都被浪费了，可以记录其它信息

                fixed3 specular = _LightColor0.rgb * _Specular.rgb * 
                    pow( max(0.0, dot( tangentNormal, halfDir)), _Gloss ) * specularMask;

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
