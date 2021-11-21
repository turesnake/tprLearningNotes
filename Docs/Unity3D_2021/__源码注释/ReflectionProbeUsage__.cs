#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Reflection Probe usage.
    */
    public enum ReflectionProbeUsage
    {
        
        // 摘要:
        //     Reflection probes are disabled, skybox will be used for reflection.
        Off = 0,

        /*
            摘要:
            Reflection probes are enabled. Blending occurs only between probes, useful in
            indoor environments. The renderer will use default reflection if there are no
            reflection probes nearby, but no blending between default reflection and probe
            will occur.
            ---
            反射探针被启用, 只在数个 反射探针之间执行 blend, (而不涉及 skybox)
            适用于室内;
            如果某区域附近没有 反射探针可用, renderer 将使用 default reflection;

            不存在 default reflection 和 反射探针 之间的 blend;
        */
        BlendProbes = 1,

        /*
            摘要:
            Reflection probes are enabled. Blending occurs between probes or probes and default
            reflection, useful for outdoor environments.
            ---
            blende 可在: "探针之间", "探针 和 default reflection之间" 进行;
            适用于 室外环境;
        */
        BlendProbesAndSkybox = 2,


        /*
            摘要:
            Reflection probes are enabled, but no blending will occur between probes when
            there are two overlapping volumes.

            不存在 blend;
        */
        Simple = 3
    }
}

