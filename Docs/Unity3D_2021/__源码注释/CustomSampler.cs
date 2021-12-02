
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System.Diagnostics;

namespace UnityEngine.Profiling
{
    /*
        Custom CPU Profiler label "used for profiling arbitrary code blocks".
        用于分析任意代码块。
    */
    [NativeHeaderAttribute("Runtime/Profiler/ScriptBindings/Sampler.bindings.h")]
    [NativeHeaderAttribute("Runtime/Profiler/Marker.h")]
    [UsedByNativeCodeAttribute]
    public sealed class CustomSampler //CustomSampler__RR
        : Sampler
    {

        //
        // 摘要:
        //     Creates a new CustomSampler for profiling parts of your code.
        //
        // 参数:
        //   name:
        //     Name of the Sampler.
        //
        //   collectGpuData:
        //     Specifies whether this Sampler records GPU timings. If you want the Sampler to
        //     record GPU timings, set this to true.
        //
        // 返回结果:
        //     CustomSampler object or null if a built-in Sampler with the same name exists.
        public static CustomSampler Create(string name, bool collectGpuData = false);


        //
        // 摘要:
        //     Begin profiling a piece of code with a custom label defined by this instance
        //     of CustomSampler.
        //
        // 参数:
        //   targetObject:
        [Conditional("ENABLE_PROFILER")]
        public void Begin();


        //
        // 摘要:
        //     Begin profiling a piece of code with a custom label defined by this instance
        //     of CustomSampler.
        //
        // 参数:
        //   targetObject:
        [Conditional("ENABLE_PROFILER")]
        public void Begin(Object targetObject);

        
        //
        // 摘要:
        //     End profiling a piece of code with a custom label.
        [Conditional("ENABLE_PROFILER")]
        public void End();
    }
}

