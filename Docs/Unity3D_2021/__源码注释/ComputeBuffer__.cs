#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.Security;
using Unity.Collections;

namespace UnityEngine
{
    /*
        摘要:
        GPU data buffer, mostly for use with compute shaders.




        ComputeShader programs often need arbitrary data to be read & written into memory buffers. 
        ComputeBuffer class 就是为这个目的而生的;

        你可以在 cpu脚本端 新建/填充 这些 buffer, 然后在 compute shaders / 常规图形 shader 中使用这些 buffer;
        
        Compute buffers 总是支持 compute shaders. 
        可在运行时查询 SystemInfo.supportsComputeShaders 来得知 是否支持 Compute shader;

        至少要达到 shader model 4.5, 常规图形 shader 才能支持 Compute buffer;

        如果一个 ComputeBuffer 它被设定携带一个 counter (记录存储了多少个元素) 变量;
            Metal and Vulkan 平台 不会在 buffer 里实现这个 counter, 而是改用一个 小的独立的 buffer 来实现这个 counter;
            这些 小buffer 与 ComputeBuffer 分开绑定，而且它们也被计入 buffer 总数, 受到 数量上限 的限制;
            ( 比如, Metal 最多支持 31 个 buffer,  )

    */
    [NativeHeaderAttribute("Runtime/Shaders/ComputeShader.h")]
    [NativeHeaderAttribute("Runtime/Export/Shaders/ComputeShader.bindings.h")]
    [UsedByNativeCodeAttribute]
    public sealed class ComputeBuffer : IDisposable//ComputeBuffer__
    {


        /*
            摘要:
            Create a Compute Buffer.

            使用 ComputeBuffer.Release() 来释放它;
            
            参数:
            count:
                buffer 的元素的个数
            
            stride:
                一个元素的 步长, 必须符合 size of buffer type in the shader.
                参考 跨平台兼容性信息:
                https://docs.unity3d.com/2021.1/Documentation/Manual/class-ComputeShader.html
            
            type:
                参见此 enum 的翻译文件
        */
        public ComputeBuffer(int count, int stride);
        public ComputeBuffer(int count, int stride, ComputeBufferType type);
        public ComputeBuffer(int count, int stride, ComputeBufferType type, ComputeBufferMode usage);


        ~ComputeBuffer();

        
        // 摘要:
        //     Number of elements in the buffer (Read Only).
        public int count { get; }
        
        // 摘要:
        //     Size of one element in the buffer (Read Only).
        public int stride { get; }
        

        // 摘要:
        //     The debug label for the ComputeBuffer. 
        //      This name shows up in profiling and frame debugger tools, wherever supported.
        public string name { set; }


        /*
            摘要:
            Copy counter value of append/consume buffer into another buffer.
        
            将 src 中的 counter 值, 复制给 dst 中, 放在 dstOffsetBytes 这个位置;

            本函数主要配合 Graphics.DrawProceduralIndirect() 一起使用,
            to render arbitrary number of primitives without reading their count back to the CPU.
            以此来入渲染 任意数量的 图元, 而不用将它们的 count 写回 cpu;

            在 dx11 平台, dst 必须是 ComputeBufferType.Raw 或 ComputeBufferType.IndirectArguments 类型;
            (或者说, 类型必须开启这两种 flag 之一)
            在别的平台, dst 可以是任何类型;

        参数:
          src:
            Append/consume buffer to copy the counter from.
        
          dst:
            A buffer to copy the counter to.
        
          dstOffsetBytes:
            Target byte offset in dst.
        */
        public static void CopyCount(ComputeBuffer src, ComputeBuffer dst, int dstOffsetBytes);



        /*
            Begins a write operation to the buffer;

            Use this to begin a write operation on the buffer. 

            此方法比 ComputeBuffer.SetData() 使用更少的 内存复制, 所以速度更快;

            出于兼容性考虑, 只有当 ComputeBufferMode 被设置为 ComputeBufferMode.SubUpdates 时,
            此函数才能被调用, 否则 unity 会抛出异常;

            如果可能, 返回的 native array 将直接指向 GPU memory,  若做不到, 它将指向一个 "gpu memory 中的 temp buffer";
            能否做到前一种 取决于很多因素:
                -- buffer mode
                -- active graphics device
                -- hardware support
            
            因此, 返回的 array 中的内容, 不一定就是 gpu 端对应buffer 中的内容;
            所以针对这个返回的 array, 只能向其写入数据, 不能读取它的数据;

            当写入结束后, 调用 ComputeBuffer.EndWrite() 以结束操作, and mark the returned NativeArray as unusable.
            (并将返回的 NativeArray 标记为 不可用);

            如果本函数能直接写入 gpu memory, 而不是写入 "gpu memory 中的 temp buffer",
            那么它的性能会更快;

            但不管是哪一种, 它都一定比 SetData() 消耗更少的 内存复制操作;

            向返回的 native array 写入的数据, 必须符合 图形api 的 data layout rules;
            参见 跨平台兼容性信息:
            https://docs.unity3d.com/2021.1/Documentation/Manual/class-ComputeShader.html

            参数:
            computeBufferStartIndex:
                Offset in number of elements to which the write operation will occur

            count:
                Maximum number of elements which will be written

            返回:
                A NativeArray of size count

        */
        public NativeArray<T> BeginWrite<T>(int computeBufferStartIndex, int count) where T : struct;


        public void Dispose();


        /*
            Ends a write operation to the buffer;

            调用此函数时, unity 会将 BeginWrite() 返回的那个 NativeArray 标记为 unusuable,
            and then disposes of it.

            参数:
            countWritten:
                Number of elements written to the buffer. Counted from the first element.
        */
        public void EndWrite<T>(int countWritten) where T : struct;


        /*
            摘要:
            Read data values from the buffer into an array. The array can only use "blittable type";

            获得的数据必须符合 图形api 的 data layout rules;
            参考跨平台兼容性信息:
            https://docs.unity3d.com/2021.1/Documentation/Manual/class-ComputeShader.html

            注意:
            本函数将数据 从 gpu 读回 cpu, 这个过程很慢;

            如果此时存在一些已经 submit 的, "向目标 buffer 写入数据" 的任务, 那么本函数会先等待这些工作做完,
            然后再去读取目标 buffer, 以保证最终读取的数据, 是最新的;

            因此, 你应该改用 class AsyncGPUReadback, 因为它能在后台执行请求, 不会向本函数一样当初阻塞;

            注意:
            参数 data 的中元素的类型必须是 "blittable type" 的;
        
        // 参数:
        //   data:
        //     An array to receive the data.  接收端
        //
        //   managedBufferStartIndex:
        //     The first element index in data where retrieved elements are copied.
        //
        //   computeBufferStartIndex:
        //     The first element index of the compute buffer from which elements are read.
        //
        //   count:
        //     The number of elements to retrieve.
        */
        [SecurityCritical]
        public void GetData(Array data);

        [SecurityCritical]
        public void GetData(Array data, int managedBufferStartIndex, int computeBufferStartIndex, int count);


        /*
            摘要:
            Retrieve a native (underlying graphics API) pointer to the buffer.

            以便让 native code plugins(插件) 来处理 graphics buffer data;

            当你使用 unity api 去修改 buffer 数据时, 它会改变底层的 graphics API native pointer;

            此时要再次调用本函数, 获得新的 native pointer
            
            返回的数据的类型, 取决于 底层图形API:
            -- ID3D11Buffer on D3D11
            -- ID3D12Resource on D3D12
            -- buffer "name" (as GLuint) on OpenGL/ES
            -- MTLBuffer on Metal

            注意:
            当使用 多线程渲染 时, 调用本函数会让本线程与 rendering thread 强制同步,(这是很缓慢的)
            所以最好在程序的 初始阶段 就设置好 必要的 buffer 的 pointer;

            返回结果:
                Pointer to the underlying graphics API buffer.
        */
        public IntPtr GetNativeBufferPtr();

        
        
        // 摘要:
        //     Returns true if this compute buffer is valid and false otherwise.
        public bool IsValid();

        
        // 摘要:
        //     Release a Compute Buffer.
        public void Release();

       
        /*
            摘要:
            Sets counter value of append/consume buffer.

            "Append/consume buffer" and "counter buffers" 使用一个特殊的 counter 变量来跟踪 buffer 中元素的个数;

            注意:
            如果 buffer 通过 Graphics.SetRandomWriteTarget() 绑定, 那么它就不能调用本函数;

            参数:
            counterValue:
                Value of the append/consume counter.
        */
        public void SetCounterValue(uint counterValue);


        
        /*
            将 cpu端 参数 data 中的数据, 部分/全部 复制到本 buffer 中;

            输入的数据 参数data, 必须符合 图形api 规定的 data layout rules;
            参考下方跨平台兼容性信息:
            https://docs.unity3d.com/2021.1/Documentation/Manual/class-ComputeShader.html

            参数data 中的元素, 必须是 "blittable type" 的 (可执行 blit 的)

            
            参数:
            data:
                Array of values to fill the buffer.
            
            nativeBufferStartIndex:
                (data 存储在 cpu端 原生代码中) 

            managedBufferStartIndex:
                (data 存储在 cpu端 托管代码中) 
                The first element index in data to copy to the compute buffer.

            computeBufferStartIndex:
                The first element index in compute buffer to receive the data.
                本 buffer 的idx;

            count:
                要复制的元素的个数
        */
        [SecuritySafeCritical]
        public void SetData(Array data, int managedBufferStartIndex, int computeBufferStartIndex, int count);
        [SecuritySafeCritical]
        public void SetData<T>(NativeArray<T> data, int nativeBufferStartIndex, int computeBufferStartIndex, int count) where T : struct;
        [SecuritySafeCritical]
        public void SetData<T>(List<T> data, int managedBufferStartIndex, int computeBufferStartIndex, int count) where T : struct;
    
        [SecuritySafeCritical]
        public void SetData(Array data);
        [SecuritySafeCritical]
        public void SetData<T>(List<T> data) where T : struct;
        [SecuritySafeCritical]
        public void SetData<T>(NativeArray<T> data) where T : struct;
    
    
    }
}
