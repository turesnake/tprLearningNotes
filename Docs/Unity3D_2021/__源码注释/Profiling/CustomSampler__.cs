
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System.Diagnostics;

namespace UnityEngine.Profiling
{
    /*
        Custom CPU Profiler label "used for profiling arbitrary code blocks".
        用于分析任意代码块。

        使用本类来测量 一段代码块的执行时间,生成的信息被显示在 "CPU Profiler" 窗口上,
        也可以被 "Recorder" class 捕获;

        使用本类要比使用 "Profiler.BeginSample" 更高效, 这是因为本类的 "Begin()" 函数的调用
        负担非常轻;

        "CustomSampler.Begin()" 使用 ConditionalAttribute 有条件地编译掉; 当它被部署在 正式版程序中时,
        它将具有 零开销 
        (意味着这些 profiling 代码可以保留在 项目中)

        仅在 urp 中见到被使用;

    */
    [NativeHeaderAttribute("Runtime/Profiler/ScriptBindings/Sampler.bindings.h")]
    [NativeHeaderAttribute("Runtime/Profiler/Marker.h")]
    [UsedByNativeCodeAttribute]
    public sealed class CustomSampler //CustomSampler__
        : Sampler
    {

        /*
            Creates a new CustomSampler for profiling parts of your code.

            使用相同的参数反复调用本函数, 将得到很多个独立的 实例; 但是这些实例最终指向的 原生代码实体, 却是同一个;
            在这个过程中, 本类实例只是一个 handle;
        */
        /// <param name="name">Name of the Sampler</param>
        /// <param name="collectGpuData"> Specifies whether this Sampler records GPU timings. 
        ///     If you want the Sampler to record GPU timings, set this to true.
        /// </param>
        /// <returns>CustomSampler object or null if a built-in Sampler with the same name exists.</returns>
        public static CustomSampler Create(string name, bool collectGpuData = false);


        /*
            Begin profiling a piece of code "with a custom label defined by this instance of CustomSampler".
            这个参数到底怎么用, 没看到示范
        */

        /// <param name="targetObject"></param>
        [Conditional("ENABLE_PROFILER")]public void Begin();
        [Conditional("ENABLE_PROFILER")]public void Begin(Object targetObject);

        
        /*
            End profiling a piece of code with a custom label.
            这将会显示在 Profiler hierarchy 中
        */
        [Conditional("ENABLE_PROFILER")]
        public void End();
    }
}

