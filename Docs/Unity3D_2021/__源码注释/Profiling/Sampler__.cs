#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System.Collections.Generic;

namespace UnityEngine.Profiling
{
    /*
        Provides control over a CPU Profiler label.

        Sampler is a counter which produces timings information you can see in CPU Profiler. 
        Use this class to get information about built-in or custom Profiler label.
    */
    [NativeHeaderAttribute("Runtime/Profiler/Marker.h")]
    [NativeHeaderAttribute("Runtime/Profiler/ScriptBindings/Sampler.bindings.h")]
    [UsedByNativeCodeAttribute]
    public class Sampler//Sampler__
    {

        /*
            Returns true if Sampler is valid. (Read Only)

            无效的 Sampler 表示 "non-existing Profiler label".

            注意, 目前, all built-in counters are available only in the Editor and Development Players. 
            "Sampler.Get()" in "non-Development Players" 返回一个无效的 实例;
        */
        public bool isValid { get; }

        
        //  Sampler name. (Read Only)
        //  使用本 sampler 生成的数据, 在 Profiler window 中会用这个 name string 来标记;
        //  注意, 如果 Sampler 是无效的, 本变量返回 null 或 "";
        public string name { get; }


        /*
            Returns Sampler object for the specific CPU Profiler label.

            返回一个 "Sampler" 实例, 它的 CPU Profiler label 就是 参数 name 标识的;

            生成的 实例 与一个 "built-in or custom label" 关联;
            参数 name 就是你能在 Profiler Window 中见到的 Hierarchy 标签;

            如果这个参数 name 指定的 label 并不存在, 或者 Player 无法访问到这个 label,
            则本函数返回一个 无效的 Smapler 实例;

            然后必须调用 "Sampler.isValid" 来查看这个返回的实例 是否有效;
            
            本函数可用来获得任何已经存在的 Sampler, 其中包含 custom Sampler;
            返回的对象的类型永远为 Sampler, 它不能被 cast 为 "CustomSampler" 类型;

            注意, 目前, all built-in counters are available only in the Editor and Development Players. 
            "Get()" in non-Development Players returns invalid Sampler.
        */
        /// <param name="name">Profiler Sampler name</param>
        /// <returns>Sampler object which represents specific profiler label.</returns>
        public static Sampler Get(string name);


        /*
            Returns number and names of all registered Profiler labels.

            调用本函数来获得 available Samplers 的数量, 并把这些 labels 的name 填入参数 list 中;

            Note: 目前, all built-in counters are available only in the Editor and Development Players. 
            "GetNames()" in non-Development Players returns returns 0 and empty list.
        */
        /// <param name="names">Preallocated list the Sampler names are written to. 
        ///                     Or null if you want to get number of Samplers only.
        /// </param>
        /// <returns>Number of active Samplers.</returns>
        public static int GetNames(List<string> names);


 
        /*
            Returns Recorder object associated with the Sampler.

            Each Sampler has only one recorder. 
            多次调用本函数将获得多个 对象, 但它们指向的都是同一个 native Recorder object;
            
            If Sampler object is 无效的, 本函数也返回一个 无效的 Recorder object

            Note: 目前, Samplers are available only in the Editor and Development Players. 
            Use "Sampler.isValid" to verify if Sampler can be used to create a valid Recorder.
        */
        public Recorder GetRecorder();
    }
}