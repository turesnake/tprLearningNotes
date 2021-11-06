// Stencil Check 
// --------------
// 此版本 暂时仅在 built-in 管线中测试;

// 如果某个 frag 的 stencil 值为 我们想寻找的, 
// 就把这个 frag, 用某种颜色标记出来;

// 暂时支持 5 个值的标记;
// 可用开关关闭掉掉一部分;
// ---

// 使用方法:
// 在 camera 下挂在一个 Plane gameobj, 
// 设置其 rotation x = -90; 使它正对着 camera, 
// 并且让它足够接近 near plane, 比如把 z值设置为 0.4;

// 新建 material, 绑定本 shader, 绑定此 material 到 plane 上;
// 在 material inspector 中配置我们想查找的 stencil 信息;


Shader "tpr/Stencil_Check" 
{

    Properties 
    {
        [Toggle(_PASS1)] _Pass1("---- Pass 1 ----",float) = 0 // turn on/off
        _Color_1 ("Color 1", Color) = (1, 0, 0, 1)// red
        _Ref_1 ("Ref 1", Float) = 0

        [Toggle(_PASS2)] _Pass2("---- Pass 2 ----",float) = 0 // turn on/off
        _Color_2 ("Color 2", Color) = (0, 1, 0, 1) // green
        _Ref_2 ("Ref 2", Float) = 0

        [Toggle(_PASS3)] _Pass3("---- Pass 3 ----",float) = 0 // turn on/off
        _Color_3 ("Color 3", Color) = (0, 0, 1, 1) // blue
        _Ref_3 ("Ref 3", Float) = 0

        [Toggle(_PASS4)] _Pass4("---- Pass 4 ----",float) = 0 // turn on/off
        _Color_4 ("Color 4", Color) = (1, 1, 0, 1)// yellow
        _Ref_4 ("Ref 4", Float) = 0

        [Toggle(_PASS5)] _Pass5("---- Pass 5 ----",float) = 0 // turn on/off
        _Color_5 ("Color 5", Color) = (0, 1, 1, 1)// purple
        _Ref_5 ("Ref 5", Float) = 0
    }


    SubShader 
    {  
        
        Tags 
        { 
            "RenderType"="Opaque" 
            //渲染次序, 确保在所有人后面
            "Queue"="Geometry+10"
        }  

        // --------------1---------------- //
        Pass 
        { 
            // 和 ref 值相等的 frag, 将被渲染指定的颜色;
            Stencil 
            { 
                Ref  [_Ref_1]
                Comp equal
            }  

            CGPROGRAM  
            #pragma vertex vert  
            #pragma fragment frag  

            #include "AutoLight.cginc"

            float4 _Color_1;
            #define _COLOR   _Color_1

            #pragma shader_feature _PASS1
            #if defined(_PASS1)
                #define _IS_PASS 1
            #endif

            #include "Stencil_Check.cginc"
            
            ENDCG  
        }  

        // --------------2---------------- //
        Pass 
        { 
            // 和 ref 值相等的 frag, 将被渲染指定的颜色;
            Stencil 
            { 
                Ref  [_Ref_2]
                Comp equal
            }  

            CGPROGRAM  
            #pragma vertex vert  
            #pragma fragment frag  

            #include "AutoLight.cginc"

            float4 _Color_2;
            #define _COLOR   _Color_2

            #pragma shader_feature _PASS2
            #if defined(_PASS2)
                #define _IS_PASS 1
            #endif

            #include "Stencil_Check.cginc"
            
            ENDCG  
        } 


        // --------------3---------------- //
        Pass 
        { 
            // 和 ref 值相等的 frag, 将被渲染指定的颜色;
            Stencil 
            { 
                Ref  [_Ref_3]
                Comp equal
            }  

            CGPROGRAM  
            #pragma vertex vert  
            #pragma fragment frag  

            #include "AutoLight.cginc"

            float4 _Color_3;
            #define _COLOR   _Color_3

            #pragma shader_feature _PASS3
            #if defined(_PASS3)
                #define _IS_PASS 1
            #endif

            #include "Stencil_Check.cginc"
            
            ENDCG  
        } 


        // --------------4---------------- //
        Pass 
        { 
            // 和 ref 值相等的 frag, 将被渲染指定的颜色;
            Stencil 
            { 
                Ref  [_Ref_4]
                Comp equal
            }  

            CGPROGRAM  
            #pragma vertex vert  
            #pragma fragment frag  

            #include "AutoLight.cginc"

            float4 _Color_4;
            #define _COLOR   _Color_4

            #pragma shader_feature _PASS4
            #if defined(_PASS4)
                #define _IS_PASS 1
            #endif

            #include "Stencil_Check.cginc"
            
            ENDCG  
        } 


        // --------------5---------------- //
        Pass 
        { 
            // 和 ref 值相等的 frag, 将被渲染指定的颜色;
            Stencil 
            { 
                Ref  [_Ref_5]
                Comp equal
            }  

            CGPROGRAM  
            #pragma vertex vert  
            #pragma fragment frag  

            #include "AutoLight.cginc"

            float4 _Color_5;
            #define _COLOR   _Color_5

            #pragma shader_feature _PASS5
            #if defined(_PASS5)
                #define _IS_PASS 1
            #endif

            #include "Stencil_Check.cginc"
            
            ENDCG  
        } 


        



    }
}  