/*
    urp 版的 spritesRenderer 用的 shader
    其实是请 new bing 生成的, 没怎么看过细节
*/
Shader "URP/Sprites-Simple"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                float4 color    : COLOR;
                half2 texcoord  : TEXCOORD0;
            };

            float4 _Color;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = TransformObjectToHClip(IN.vertex.xyz);

                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color;

                /*
                    UNITY_UI_CLIP_RECT is a macro that defines a float4 property called _ClipRect in the shader. 
                    This property is used to clip the UI elements based on the rect transform of the canvas. 
                    It is only defined when the URP asset has the UI clipping feature enabled¹. 
                    You can use this macro to implement custom UI shaders that support clipping in URP. 
                    For example, you can use the UnityGet2DClipping function to apply the clipping to the fragment color².

                    Source: Conversation with Bing, 2023/9/13
                    (1) Unity - Manual: Universal RP. https://docs.unity3d.com/Manual/com.unity.render-pipelines.universal.html.
                    (2) how do you make an UI additive shader in URP? - Unity Forum. https://forum.unity.com/threads/how-do-you-make-an-ui-additive-shader-in-urp.989594/.
                    (3) Universal Render Pipeline overview | Universal RP | 11.0.0. https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@11.0/manual/. 
                */
                #if UNITY_UI_CLIP_RECT
                OUT.vertex.zw = UnityStereoTransformScreenSpaceTex(OUT.vertex);
                #endif

                /*
                    PIXELSNAP_ON is a shader keyword that enables pixel snapping for 2D sprites in Unity. 
                    Pixel snapping is a technique that aligns the pixels of a sprite to the pixels of the screen, avoiding sub-pixel rendering and blurry edges. 
                    PIXELSNAP_ON is declared using a #pragma directive in the HLSL code, and it can be used in an if statement to apply pixel snapping to the vertex position¹³. 
                    PIXELSNAP_ON is not specific to URP, but it can be used in any shader that supports HLSL. You can enable or disable PIXELSNAP_ON using the Inspector or C# scripting².

                    Source: Conversation with Bing, 2023/9/13
                    (1) Pixel Snap! - Unity Forum. https://forum.unity.com/threads/pixel-snap.901406/.
                    (2) UnityPixelSnap in Surface shader (2D sprites) - Unity Forum. https://forum.unity.com/threads/unitypixelsnap-in-surface-shader-2d-sprites.400546/.
                    (3) Unity - Manual: Declaring and using shader keywords in HLSL. https://docs.unity3d.com/Manual/SL-MultipleProgramVariants.html. 
                */
                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap (OUT.vertex);
                #endif

                return OUT;
            }

            sampler2D _MainTex;

            float4 frag(v2f IN) : SV_Target
            {
                float4 c = tex2D(_MainTex, IN.texcoord) * IN.color;
                c.rgb *= c.a;
                return c;
            }
            ENDHLSL
        }
    }
}
