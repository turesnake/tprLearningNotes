# ======================================================= #
#            ParticleSystem 旧粒子系统
# ======================================================= #


# ----------------------------------- #
#      ParticleSystem.cs 的访问
# ----------------------------------- #

https://docs.unity3d.com/2021.3/Documentation/ScriptReference/ParticleSystem.MainModule.html

# ParticleSystem.main
    里面放了 inspector 里的那些参数;





# ----------------------------------- #
#       如何把 ParticleSystem 的数据, 传递到它的 shader 中去
# ----------------------------------- #

# ai 给的方案:
要将 ParticleSystem 中每个粒子的 SizeOverLifetime.X 数据传递给粒子的着色器，你可以使用 Unity 的自定义顶点流功能。通过 ParticleSystemRenderer 的 SetCustomParticleData 方法，你可以将计算出的大小数据传递给着色器。

以下是实现此功能的详细步骤：

1. 配置粒子系统的自定义数据
首先，确保粒子系统的 Renderer 模块使用自定义顶点流：

选择你的粒子系统。
在 Inspector 面板中，展开 Renderer 模块。
在 Custom Vertex Streams 中，添加一个新的流，例如 Custom1.xy，用于传递自定义数据。
2. 编写脚本计算并传递大小数据
编写一个脚本，将每个粒子的 SizeOverLifetime.X 数据传递到自定义数据中：

using UnityEngine;  
using System.Collections.Generic;  

public class ParticleSizeOverLifetimeToShader : MonoBehaviour  
{  
    private ParticleSystem particleSystem;  
    private ParticleSystem.Particle[] particles;  
    private List<Vector4> customData;  

    void Start()  
    {  
        // 获取 ParticleSystem 组件  
        particleSystem = GetComponent<ParticleSystem>();  
        // 初始化粒子数组  
        particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];  
        // 初始化自定义数据列表  
        customData = new List<Vector4>(particleSystem.main.maxParticles);  
    }  

    void Update()  
    {  
        // 获取当前活跃的粒子数  
        int numParticlesAlive = particleSystem.GetParticles(particles);  

        // 清空自定义数据列表  
        customData.Clear();  

        // 获取 SizeOverLifetime 模块  
        var sizeOverLifetime = particleSystem.sizeOverLifetime;  

        // 遍历每个活跃的粒子  
        for (int i = 0; i < numParticlesAlive; i++)  
        {  
            // 获取粒子的生命周期时间  
            float normalizedLifetime = 1f - (particles[i].remainingLifetime / particles[i].startLifetime);  

            // 获取 X 轴的大小变化曲线  
            float sizeOverLifetimeX = sizeOverLifetime.size.curveX.Evaluate(normalizedLifetime);  

            // 将大小存储到自定义数据中  
            customData.Add(new Vector4(sizeOverLifetimeX, 0, 0, 0));  
        }  

        // 将自定义数据设置到粒子系统中  
        particleSystem.SetCustomParticleData(customData, ParticleSystemCustomData.Custom1);  
    }  
}  
3. 编写自定义着色器
编写一个支持自定义数据的粒子着色器：

Shader "Custom/ParticleSizeOverLifetimeShader"  
{  
    Properties  
    {  
        _MainTex ("Texture", 2D) = "white" {}  
    }  
    SubShader  
    {  
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }  
        LOD 200  

        CGPROGRAM  
        #pragma surface surf Lambert alpha:fade  

        sampler2D _MainTex;  

        struct Input  
        {  
            float2 uv_MainTex;  
            float4 custom : TEXCOORD1;  
        };  

        void surf (Input IN, inout SurfaceOutput o)  
        {  
            // 使用自定义数据中的 SizeOverLifetime.X  
            float sizeOverLifetimeX = IN.custom.x;  

            // 使用 SizeOverLifetime.X 进行颜色调整或其他效果  
            half4 c = tex2D(_MainTex, IN.uv_MainTex) * sizeOverLifetimeX;  
            o.Albedo = c.rgb;  
            o.Alpha = c.a;  
        }  
        ENDCG  
    }  
    FallBack "Diffuse"  
}  
代码说明：
SetCustomParticleData: 用于将自定义数据传递给粒子系统。
Evaluate: 使用 Evaluate 方法来获取粒子的 SizeOverLifetime.X 值。
Custom Vertex Streams: 用于在粒子系统中传递额外的数据到着色器。
Shader: 自定义着色器从 TEXCOORD1 中读取自定义数据。
通过这些步骤，你可以将每个粒子的 SizeOverLifetime.X 数据传递给着色器，并在着色器中使用这些数据来实现自定义效果。


# ---------------------------------
# 这个方案的核心就是 custom data;
实践表明:
    -1-
    ParticleSystem 组件中, Custom Data 那个区域是不用开启的;
        因为那个区域的目的是传递 静态数据, 我们现在用脚本来传递了, 就不用它了;

    -2-
    ParticleSystem 组件中, Render 区域的 Custom Vertex Streams 必须配置得和 shader 中得 VertexInput 结果一致;
    至少数据排列上是一致的;
    --
    然后在 cgnix 和 urp 中都支持, 不需要做啥特殊设置;












































