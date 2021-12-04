#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Profiling
{

    /*
        Controls the "Profiler"(Profiler窗口) from script.

        You can add custom Profiler sections in your scripts with "Profiler.BeginSample()" and "Profiler.EndSample()";

        在 standalone 平台上, 可将所有 profiling information 保持进一个文件中, 以便后续 查看它们;
        为实现此功能, 你必须设置一个 "Profiler.logFile", 同时开启: "Profiler.enabled" 和 "Profiler.enableBinaryLog" 两个 bool值;

        本类的使用会影响程序性能, 所以大部分 Profiler API 都仅在 "Development Build" 中起效, 如果在 release 版 Build 中, 
        本类的大部分功能是关闭的;

        例外情况是: 与内存使用相关的 API, 访问这些信息的 开销不是很大, 就算在 release 版 Build 中, 这些 API 也能被访问;
        但是 "Profiler.GetAllocatedMemoryForGraphicsDriver" 和 "Profiler.GetRuntimeMemorySizeLong" 不符合这个描述;
        因为它们需要额外的信息, 这些信息只有在 "Development Build" 中会被提供;
    */
    [MovedFrom("UnityEngine")]
    [NativeHeaderAttribute("Runtime/Utilities/MemoryUtilities.h")]
    [NativeHeaderAttribute("Runtime/ScriptingBackend/ScriptingApi.h")]
    [NativeHeaderAttribute("Runtime/Profiler/ScriptBindings/Profiler.bindings.h")]
    [NativeHeaderAttribute("Runtime/Profiler/Profiler.h")]
    [NativeHeaderAttribute("Runtime/Allocator/MemoryManager.h")]
    [UsedByNativeCodeAttribute]
    public sealed class Profiler
    {

        /*
            Returns the number of bytes that Unity has allocated.
            不包含 第三方库 和 驱动分配的内存;
            如果 profiler is disabled, 返回 0
        */
        public static long usedHeapSizeLong { get; }

        //
        // 摘要:
        //     Sets the maximum amount of memory that Profiler uses for buffering data. This
        //     property is expressed in bytes.
        /*  
            Sets the maximum amount of memory that Profiler "uses for buffering data". 以字节为单位;

            When Profiler is enabled, 它会持续收集数据, 要么将数据存入一个文件, 要么将数据发送到 Editor 中;(以便显示在 窗口上)

            鉴于 硬盘写入速度 和 网络带宽, Profiler 收集的数据 可能快于 它能写出的速度; 此时, Profiler 会把数据收集到一个 
            ring buffer chain 上, 当这个 buffer chain 的数据总量达到 "maxUsedMemory" 上限时, Profiler 就会停止接收数据;
            这个停止会一直持续,  直到 buffer chain 空出空间为止;
            
            默认时, 本值为: 128MB for Players and 512MB for the Editor;
            You can use the -profiler-maxusedmemory command line argument to set the maxUsedMemory parameter at startup. 
            For example, -profiler-maxusedmemory 16777216,
            (暂未找到这个是怎么设置的...)
        */
        public static int maxUsedMemory { get; set; }

        
        /*
            Enables the logging of profiling data to a file.

            开启后, 系统会将数据写入 "Profiler.logFile" 指定的文件中; 系统会自动分配文件的 后缀 “.raw”;
            可以在 editor 中, 加载这个文件, 并使用 Profiler 窗口来查看数据;

            必须将 "Profiler.enabled" 设置为 true; 

            如果 buffer(内存中的) 尺寸太小, 无法容 profiler data, 你将会得到一个 debug log:
            "Skipping profile frame. Receiver can not keep up with the amount of data sent".
            此时可使用 "Profiler.maxUsedMemory" 来增大 buffer 尺寸;
        */
        public static bool enableBinaryLog { get; set; }


        
        /*
            Specifies the file to use when writing profiling data.

            必须开启 "Profiler.enabled" 和 "Profiler.enableBinaryLog";

            如果传入的 path 是 null 或 "", "Profiler.enableBinaryLog" 会自动设置为 false;

            如果 buffer(内存中的) 尺寸太小, 无法容 profiler data, 你将会得到一个 debug log:
            "Skipping profile frame. Receiver can not keep up with the amount of data sent".
            此时可使用 "Profiler.maxUsedMemory" 来增大 buffer 尺寸;
        */
        [StaticAccessorAttribute("ProfilerBindings", Bindings.StaticAccessorType.DoubleColon)]
        public static string logFile { get; set; }



        public static bool supported { get; }

        /*
            The number of "ProfilerArea"(一个 enum) that you can profile.

            本值现在是固定的, 
            Try not to rely on it staying the same throughout the lifetime of the editor instance though, 
            as this is prone(倾向于) to change in the future.
        */
        public static int areaCount { get; }


        /*
        // Heap size used by the program.
        // 返回结果:
        //     Size of the used heap in bytes, (or 0 if the profiler is disabled).
        [Obsolete("usedHeapSize has been deprecated since it is limited to 4GB. Please use usedHeapSizeLong instead.")]
        public static uint usedHeapSize { get; }
        */

        
        //
        // 摘要:
        //     Enables the Profiler.
        public static bool enabled { get; set; }


        /*
        //     Resize the profiler sample buffers to allow the desired amount of samples per
        //     thread.
        [Obsolete("maxNumberOfSamplesPerFrame has been depricated. Use maxUsedMemory instead")]
        public static int maxNumberOfSamplesPerFrame { get; set; }
        */


        //
        // 摘要:
        //     Enables the recording of callstacks for managed allocations.
        public static bool enableAllocationCallstacks { get; set; }

        //
        // 摘要:
        //     Displays the recorded profile data in the profiler.
        //
        // 参数:
        //   file:
        //     The name of the file containing the frame data, including extension.
        [Conditional("UNITY_EDITOR")]
        public static void AddFramesFromFile(string file);


        //
        // 摘要:
        //     Begin profiling a piece of code with a custom label.
        //
        // 参数:
        //   name:
        //     A string to identify the sample in the Profiler window.
        //
        //   targetObject:
        //     An object that provides context to the sample,.
        [Conditional("ENABLE_PROFILER")]public static void BeginSample(string name, Object targetObject);
        [Conditional("ENABLE_PROFILER")]public static void BeginSample(string name);


        //
        // 摘要:
        //     Enables profiling on the thread from which you call this method.
        //
        // 参数:
        //   threadGroupName:
        //     The name of the thread group to which the thread belongs.
        //
        //   threadName:
        //     The name of the thread.
        [Conditional("ENABLE_PROFILER")]
        public static void BeginThreadProfiling(string threadGroupName, string threadName);
        [Conditional("ENABLE_PROFILER")]
        public static void EmitFrameMetaData<T>(Guid id, int tag, List<T> data) where T : struct;
        //
        // 摘要:
        //     Write metadata associated with the current frame to the Profiler stream.
        //
        // 参数:
        //   id:
        //     Module identifier. Used to distinguish metadata streams between different plugins,
        //     packages or modules.
        //
        //   tag:
        //     Data stream index.
        //
        //   data:
        //     Binary data.
        [Conditional("ENABLE_PROFILER")]
        public static void EmitFrameMetaData(Guid id, int tag, Array data);
        [Conditional("ENABLE_PROFILER")]
        public static void EmitFrameMetaData<T>(Guid id, int tag, NativeArray<T> data) where T : struct;
        //
        // 摘要:
        //     Ends the current profiling sample.
        [Conditional("ENABLE_PROFILER")]
        [NativeMethodAttribute(Name = "ProfilerBindings::EndSample", IsFreeFunction = true, IsThreadSafe = true)]
        public static void EndSample();
        //
        // 摘要:
        //     Frees the internal resources used by the Profiler for the thread.
        [NativeConditionalAttribute("ENABLE_PROFILER")]
        public static void EndThreadProfiling();
        //
        // 摘要:
        //     Returns the amount of allocated memory for the graphics driver, in bytes. Only
        //     available in development players and editor.
        [NativeConditionalAttribute("ENABLE_PROFILER")]
        [NativeMethodAttribute(Name = "GetRegisteredGFXDriverMemory")]
        [StaticAccessorAttribute("GetMemoryManager()", Bindings.StaticAccessorType.Dot)]
        public static long GetAllocatedMemoryForGraphicsDriver();
        //
        // 摘要:
        //     Returns whether or not a given ProfilerArea is currently enabled.
        //
        // 参数:
        //   area:
        //     Which area you want to check the state of.
        //
        // 返回结果:
        //     Returns whether or not a given ProfilerArea is currently enabled.
        [FreeFunctionAttribute("profiler_is_area_enabled")]
        [NativeConditionalAttribute("ENABLE_PROFILER")]
        public static bool GetAreaEnabled(ProfilerArea area);


        /*
        //     Returns the size of the mono heap.
        [Obsolete("GetMonoHeapSize has been deprecated since it is limited to 4GB. Please use GetMonoHeapSizeLong() instead.")]
        public static uint GetMonoHeapSize();
        */


        //
        // 摘要:
        //     Returns the size of the reserved space for managed-memory.
        //
        // 返回结果:
        //     The size of the managed heap.
        [NativeMethodAttribute(Name = "scripting_gc_get_heap_size", IsFreeFunction = true)]
        public static long GetMonoHeapSizeLong();

        /*
        //     Returns the used size from mono.
        [Obsolete("GetMonoUsedSize has been deprecated since it is limited to 4GB. Please use GetMonoUsedSizeLong() instead.")]
        public static uint GetMonoUsedSize();
        */

        //
        // 摘要:
        //     Gets the allocated managed memory for live objects and non-collected objects.
        //
        // 返回结果:
        //     Returns a long integer value of the memory in use.
        [NativeMethodAttribute(Name = "scripting_gc_get_used_size", IsFreeFunction = true)]
        public static long GetMonoUsedSizeLong();

        /*
        //     Returns the runtime memory usage of the resource.
        [Obsolete("GetRuntimeMemorySize has been deprecated since it is limited to 2GB. Please use GetRuntimeMemorySizeLong() instead.")]
        public static int GetRuntimeMemorySize(Object o);
        */


        //
        // 摘要:
        //     Gathers the native-memory used by a Unity object.
        //
        // 参数:
        //   o:
        //     The target Unity object.
        //
        // 返回结果:
        //     The amount of native-memory used by a Unity object. This returns 0 if the Profiler
        //     is not available.
        [NativeMethodAttribute(Name = "ProfilerBindings::GetRuntimeMemorySizeLong", IsFreeFunction = true)]
        public static long GetRuntimeMemorySizeLong([NotNullAttribute("ArgumentNullException")] Object o);
        //
        // 摘要:
        //     Returns the size of the temp allocator.
        //
        // 返回结果:
        //     Size in bytes.
        [NativeConditionalAttribute("ENABLE_MEMORY_MANAGER")]
        [StaticAccessorAttribute("GetMemoryManager()", Bindings.StaticAccessorType.Dot)]
        public static uint GetTempAllocatorSize();

        /*
        //     Returns the amount of allocated and used system memory.
        [Obsolete("GetTotalAllocatedMemory has been deprecated since it is limited to 4GB. Please use GetTotalAllocatedMemoryLong() instead.")]
        public static uint GetTotalAllocatedMemory();
        */

        //
        // 摘要:
        //     The total memory allocated by the internal allocators in Unity. Unity reserves
        //     large pools of memory from the system. This function returns the amount of used
        //     memory in those pools.
        //
        // 返回结果:
        //     The amount of memory allocated by Unity. This returns 0 if the Profiler is not
        //     available.
        [NativeConditionalAttribute("ENABLE_MEMORY_MANAGER")]
        [NativeMethodAttribute(Name = "GetTotalAllocatedMemory")]
        [StaticAccessorAttribute("GetMemoryManager()", Bindings.StaticAccessorType.Dot)]
        public static long GetTotalAllocatedMemoryLong();
        [NativeConditionalAttribute("ENABLE_MEMORY_MANAGER")]
        public static long GetTotalFragmentationInfo(NativeArray<int> stats);

        /*
        //     Returns the amount of reserved system memory.
        [Obsolete("GetTotalReservedMemory has been deprecated since it is limited to 4GB. Please use GetTotalReservedMemoryLong() instead.")]
        public static uint GetTotalReservedMemory();
        */

        //
        // 摘要:
        //     The total memory Unity has reserved.
        //
        // 返回结果:
        //     Memory reserved by Unity in bytes. This returns 0 if the Profiler is not available.
        [NativeConditionalAttribute("ENABLE_MEMORY_MANAGER")]
        [NativeMethodAttribute(Name = "GetTotalReservedMemory")]
        [StaticAccessorAttribute("GetMemoryManager()", Bindings.StaticAccessorType.Dot)]
        public static long GetTotalReservedMemoryLong();

        /*
        //     Returns the amount of reserved but not used system memory.
        [Obsolete("GetTotalUnusedReservedMemory has been deprecated since it is limited to 4GB. Please use GetTotalUnusedReservedMemoryLong() instead.")]
        public static uint GetTotalUnusedReservedMemory();
        */

        //
        // 摘要:
        //     Unity allocates memory in pools for usage when unity needs to allocate memory.
        //     This function returns the amount of unused memory in these pools.
        //
        // 返回结果:
        //     The amount of unused memory in the reserved pools. This returns 0 if the Profiler
        //     is not available.
        [NativeConditionalAttribute("ENABLE_MEMORY_MANAGER")]
        [NativeMethodAttribute(Name = "GetTotalUnusedReservedMemory")]
        [StaticAccessorAttribute("GetMemoryManager()", Bindings.StaticAccessorType.Dot)]
        public static long GetTotalUnusedReservedMemoryLong();
        //
        // 摘要:
        //     Enable or disable a given ProfilerArea.
        //
        // 参数:
        //   area:
        //     The area you want to enable or disable.
        //
        //   enabled:
        //     Enable or disable the collection of data for this area.
        [Conditional("ENABLE_PROFILER")]
        [FreeFunctionAttribute("profiler_set_area_enabled")]
        public static void SetAreaEnabled(ProfilerArea area, bool enabled);
        //
        // 摘要:
        //     Sets the size of the temp allocator.
        //
        // 参数:
        //   size:
        //     Size in bytes.
        //
        // 返回结果:
        //     Returns true if requested size was successfully set. Will return false if value
        //     is disallowed (too small).
        [NativeConditionalAttribute("ENABLE_MEMORY_MANAGER")]
        [StaticAccessorAttribute("GetMemoryManager()", Bindings.StaticAccessorType.Dot)]
        public static bool SetTempAllocatorRequestedSize(uint size);
    }
}

