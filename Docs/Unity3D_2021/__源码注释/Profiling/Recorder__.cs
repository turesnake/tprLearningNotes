#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Profiling
{
    /*
        Records profiling data produced by a specific Sampler.

        Recorder 记录在一帧中, 每个 Begin/End 对内的代码 运算消耗的时间;
        使用 "Recorder.elapsedNanoseconds" 来得到上一帧的累计时间;

        注意:
        无论 Profiler state 是什么, Recorder 都会收集数据; 当一个 Recorder 被开启, 每帧的数据都会被收集;
        这个数据和你在 editor Profiler 窗口的 Hierarchy view 中看到的是一样的;

        目前, Samplers are available only in the Editor and Development Players. 
        Use "Recorder.isValid" to verify if Recorder can collect the data.

        Recorder supports only "internal static Profiler labels" and "labels generated by CustomSampler". 
        "Dynamic internal labels produced by scripting method calls" and "labels produced by Profiler.BeginSample" are not supported.
    */
    [NativeHeaderAttribute("Runtime/Profiler/Recorder.h")]
    [NativeHeaderAttribute("Runtime/Profiler/ScriptBindings/Recorder.bindings.h")]
    [UsedByNativeCodeAttribute]
    public sealed class Recorder//Recorder__
    {

        ~Recorder();


        //     Returns true if Recorder is valid and can collect data. (Read Only)
        public bool isValid { get; }
       
        //     Enables recording.
        //  When enabled Recorder collects data regardless of Profiler being enabled or not.
        public bool enabled { get; set; }

        /*
            Accumulated time of Begin/End pairs for the previous frame in nanoseconds. (Read Only)

            持久操作（如: on a preloading thread）可能不会在单个帧内结束。

            此时, "elapsedNanoseconds" 会持续计算到一帧的结束, so you can always see activity for these operations.
        */
        public long elapsedNanoseconds { get; }

        /*
            Gets the accumulated(累计) GPU time, in nanoseconds, for a frame. 
            The Recorder has a three frame delay so this gives the timings for the frame that was three frames
            before the one that you access this property on. (Read Only).

            想要得到有效值, 平台必须支持 GPU Recorder 才行, 检查 "SystemInfo.supportsGpuRecorder";
        */
        public long gpuElapsedNanoseconds { get; }


        /*
            Number of time Begin/End pairs was called during the previous frame. (Read Only)
            再上一帧中, 调用 Begin/End pairs 的次数;

            数值表示前一帧中 已经完整或正在运行的 profiling block 的数量。
        */
        public int sampleBlockCount { get; }

        /*
            Gets the number of Begin/End time pairs that the GPU executed during a frame.
            The Recorder has a three frame delay so this gives the timings for the frame that was three frames 
            before the one that you access this property on. (Read Only).

            数值表示 目标帧中 已经完整或正在运行的 GPU profiling block 的数量。
        */
        public int gpuSampleBlockCount { get; }


        /*
            Use this function to get a Recorder for the "specific Profiler label".
        */
        /// <param name="samplerName"></param>
        /// <returns>Recorder object for the specified Sampler.</returns>
        public static Recorder Get(string samplerName);

        /*
            Configures the recorder to collect samples from all threads.

            A recorder collects sample data from all threads by default, 
            but if you have configured it to collect from only a single thread using "Recorder.FilterToCurrentThread()", 
            then you can call this method afterwards to resume collection from all threads.
        */
        [ThreadSafeAttribute]
        public void CollectFromAllThreads();


        /*
            Configures(配置) the recorder to only collect data from the current thread.

            By default, a Recorder collects samples from its corresponding Sampler 
            regardless of which thread those samples occur on. 
            
            Call this function to limit sample collection to the current thread only.

            Limiting sample collection to the current thread is particularly useful 
            当使用非常常用的 samplers 去进行测试时 (such as GC.Alloc), 
            因为在测试期间 "确保后台线程不活动" 可能很困难。

            Note that when you have more than one Recorder object for the same Sampler, 
            本配置会作用于它们所有成员;
            
            如果所有的 Recorder 实例都被销毁了, 一个从 Sampler 那获得的新的 Recorder 实例将回退回 default behavior,
            它将 collect samples from all threads.

            However, because it is difficult to predict the timing of object destruction, 
            always call "Recorder.CollectFromAllThreads()" to reset sample collection.
        */
        [ThreadSafeAttribute]
        public void FilterToCurrentThread();
    }
}

