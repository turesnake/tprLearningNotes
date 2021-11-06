

// TS_to_WS 空间变换矩阵 的原理, 可参考同目录图: "TS_to_WS.jpg"


// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "fenglele/normal_WS" {
	Properties {
		_Color ("Color Tint", Color) = (1, 1, 1, 1)
		_MainTex ("Main Tex", 2D) = "white" {}
		_BumpMap ("Normal Map", 2D) = "bump" {}
		_BumpScale ("Bump Scale", Float) = 1.0
		_Specular ("Specular", Color) = (1, 1, 1, 1)
		_Gloss ("Gloss", Range(8.0, 256)) = 20
	}
	SubShader {
		Pass { 
			Tags { "LightMode"="ForwardBase" }
		
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			
			#include "Lighting.cginc"
			
			fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _BumpMap;
			float4 _BumpMap_ST;
			float _BumpScale;
			fixed4 _Specular;
			float _Gloss;
			
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float2 baseUV : TEXCOORD0;
			};
			
			struct v2f {
				float4 positionCS 	: SV_POSITION;
				float2 baseUV 		: VAR_BASE_UV; // 用户自定义的 semantic, gpu 无法识别
				float4 TtoW0 		: TEXCOORD1;  
				float4 TtoW1 		: TEXCOORD2;  
				float4 TtoW2 		: TEXCOORD3; 
			};
			
			v2f vert(a2v v) {
				v2f o;
				o.positionCS = UnityObjectToClipPos(v.vertex);
				float3 positionWS = mul(unity_ObjectToWorld, v.vertex).xyz;  
				
				o.baseUV = v.baseUV * _MainTex_ST.xy + _MainTex_ST.zw;
				

				fixed3 normalWS = UnityObjectToWorldNormal(v.normal);  
				fixed3 tangentWS = UnityObjectToWorldDir(v.tangent.xyz);  
				// 通过 tangent.w 来控制 binormal 的方向
				fixed3 worldBinormal = cross(normalWS, tangentWS) * v.tangent.w; 

				
				// Compute the matrix that transform directions from tangent space to world space
				// Put the world position in w component for optimization
				o.TtoW0 = float4(tangentWS.x, worldBinormal.x, normalWS.x, positionWS.x);
				o.TtoW1 = float4(tangentWS.y, worldBinormal.y, normalWS.y, positionWS.y);
				o.TtoW2 = float4(tangentWS.z, worldBinormal.z, normalWS.z, positionWS.z);
				
				return o;
			}
			
            
			fixed4 frag(v2f i) : SV_Target {

				// Get the position in world space		
				float3 positionWS = float3(i.TtoW0.w, i.TtoW1.w, i.TtoW2.w);

				// Compute the light and view dir in world space
				fixed3 lightDir = normalize(UnityWorldSpaceLightDir(positionWS));
				fixed3 viewDir = normalize(UnityWorldSpaceViewDir(positionWS));
				
				// Get the normal in tangent space
				fixed3 bump = UnpackNormal(tex2D(_BumpMap, i.baseUV));
				bump.xy *= _BumpScale;
				bump.z = sqrt(1.0 - saturate(dot(bump.xy, bump.xy)));

				// !!!!!
				// Transform the narmal from tangent space to world space
				bump = normalize(half3(	dot(i.TtoW0.xyz, bump), 
										dot(i.TtoW1.xyz, bump), 
										dot(i.TtoW2.xyz, bump)
								));

				
				fixed3 albedo = tex2D(_MainTex, i.baseUV).rgb * _Color.rgb;
				
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
				
				fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(bump, lightDir));

				fixed3 halfDir = normalize(lightDir + viewDir);
				fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0, dot(bump, halfDir)), _Gloss);
				
				return fixed4(ambient + diffuse + specular, 1.0);
			}
			
			ENDCG
		}
	} 
	FallBack "Specular"
}
