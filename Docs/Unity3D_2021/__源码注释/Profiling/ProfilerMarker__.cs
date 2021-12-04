#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Unity.Profiling
{
    /*
        "Performance marker" used for profiling arbitrary code blocks.

        Use "ProfilerMarker" to mark up script code blocks for the Profiler.

        The information produced by markers is displayed in the "CPU Profiler" (窗口) and can be also captured with "Recorder" (class). 

        During development (in Editor and Development Players) this can help to get performance overview 
        of different parts of game code and identify performance issues.


        ProfilerMarker represents a "named profiler handle" and is the most efficient way of profiling your code. 
        It can be used in jobified code.

        Methods "Begin()" and "End()" are marked with ConditionalAttribute. 
        They are conditionally compiled away and thus have zero overhead in non-Developmenet (Release) builds.
        --
        只在条件成立时才被编译, 从而保证 Release 版程序的性能;

        When Profiler collects instrumentation data(仪表数据), "ProfilerMarker" 有助于减少开销和传输的数据量。
        
        "Profiler.BeginSample()" transfers full string to the data stream while "ProfilerMarker.Begin()" 
        and "CustomSampler.Begin()" only integer identifier of the marker.  
        --
        "Profiler.BeginSample()" 将完整字符串传输到数据流，而 "ProfilerMarker.Begin()" 和 "CustomSampler.Begin()" 仅是标记的整数标识符。

        Also "ProfilerMarker.End()" provides a context information to the "Recorder" 
        making it possible to track timings of a marked code in Players.
    */
    [NativeHeaderAttribute("Runtime/Profiler/ScriptBindings/ProfilerMarker.bindings.h")]
    [UsedByNativeCodeAttribute]
    public struct ProfilerMarker//ProfilerMarker__
    {
        /*
            构造函数
            Constructs a new performance marker for code instrumentation.
            Use ProfilerMarker to markup a piece of code for the "Profiler" and "Recorder".

        // 参数:
        //   name:
        //     Marker name.
        //
        //   category:
        //     Profiler category.
        //
        //   nameLen:
        //     Marker name length.
        */
        public ProfilerMarker(string name);
        public ProfilerMarker(char* name, int nameLen);
        public ProfilerMarker(ProfilerCategory category, string name);
        public ProfilerMarker(ProfilerCategory category, char* name, int nameLen);


        //     Gets native handle of the ProfilerMarker.
        //   Use Handle to obtain a native marker handle and extend funtionality of ProfilerMarker.
        public IntPtr Handle { get; }


        /*
            Creates a "helper struct" for the scoped using blocks.
            "ProfilerMarker.Begin()" is called in the constructor and "ProfilerMarker.End()" in the Dispose method.
            Note: Auto is thread safe and can be used in jobified code.
            ---

            具体用法:
                var pm = new ProfilerMarker("MySystem.Simulate");
                using (pm.Auto())
                {
                    // ...
                }

        // 返回结果:
        //     IDisposable struct which calls Begin and End automatically.
        */
        [Pure]
        public AutoScope Auto();


        /*
            Begin profiling a piece of code marked with a custom name defined by this instance
            of ProfilerMarker.

            Code marked with Begin and End will show up in the Profiler hierarchy. 
            Use "Recorder" to obtain per-frame timings in the Player.

            Note: Both Begin and End are thread safe and can be used in jobified code.
        */
        /// <param name="contextUnityObject">Object associated with the operation</param>
        [Conditional("ENABLE_PROFILER")]
        [Pure]
        public void Begin();
        
        [Conditional("ENABLE_PROFILER")]
        public void Begin(UnityEngine.Object contextUnityObject);

        //     End profiling a piece of code marked with a custom name defined by this instance
        //     of ProfilerMarker.
        [Conditional("ENABLE_PROFILER")]
        [Pure]
        public void End();



        //     Helper IDisposable struct for use with ProfilerMarker.Auto.
        [UsedByNativeCodeAttribute]
        public struct AutoScope : IDisposable
        {
            public void Dispose();
        }


    }
}

