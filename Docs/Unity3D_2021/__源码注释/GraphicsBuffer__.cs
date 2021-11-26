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
        GPU graphics data buffer, for working with data such as vertex and index buffers.

        Most drawcalls supply vertex and index buffers to the GPU. 
        This structure exposes those buffers to script, in order to allow for low-level rendering control.

        "vertex and index buffers":
            也许类似 opengl 中的 FBO, FAO, 
            存储各个顶点的数据, 已经这些顶点的 idx 的有序排列(组合成一个个三角面)

    */
    [NativeHeaderAttribute("Runtime/Shaders/GraphicsBuffer.h")]
    [NativeHeaderAttribute("Runtime/GfxDevice/GfxBuffer.h")]
    [NativeHeaderAttribute("Runtime/Shaders/ComputeShader.h")]
    [NativeHeaderAttribute("Runtime/Export/Graphics/GraphicsBuffer.bindings.h")]
    [UsedByNativeCodeAttribute]
    public sealed class GraphicsBuffer : IDisposable//GraphicsBuffer__
    {

        /*
            Create a Graphics Buffer.

            可使用 GraphicsBuffer.Release() 释放本buffer;

            参数:
            target:
                Select whether this buffer can be used as a vertex or index buffer.
                要么做 vertex buffer, 要么做 index buffer;
                ---
                enum Target 被定义在本文件底部;
                似乎还支持其它 类型 ?

            count:
                buffer 中 元素的个数

            stride:
                buffer 中 一个元素的 步长;
                如果是 index buffer 的话, 此参数要么是 2-bytes, 要么是 4-bytes
        */
        public GraphicsBuffer(Target target, int count, int stride);

        ~GraphicsBuffer();


        
        // 摘要:
        //     Number of elements in the buffer (Read Only).
        public int count { get; }
        
        // 摘要:
        //     Size of one element in the buffer (Read Only).
        public int stride { get; }


        /*
            摘要:
            Copy counter value of append/consume buffer into another buffer.

            "Append/consume buffer" and "counter buffers" 使用一个特殊的 counter 变量来跟踪 buffer 中元素的个数;

            本函数在 参数 dst 的 指定偏移地址处 dstOffsetBytes, 复制写入 src 的 counter 变量值;

            本函数常和 Graphics.DrawProceduralIndirect() 一起使用, 专门用来渲染 任意个数的 primitives (图元), 
            而不将它们的 count 读回 cpu;

            在 d3d11 中, 对参数 dst 存在一个额外限制:
                它必须是: 
                -- ComputeBufferType.Raw, 
                -- GraphicsBuffer.Target.Raw, 
                -- ComputeBufferType.IndirectArguments, 
                -- GraphicsBuffer.Target.IndirectArguments 
                中的一种;
            在别的平台, dst 可以是任意类型;
            
            参数:
            dstOffsetBytes:
        */
        public static void CopyCount(GraphicsBuffer src, GraphicsBuffer dst, int dstOffsetBytes);
        public static void CopyCount(ComputeBuffer src, GraphicsBuffer dst, int dstOffsetBytes);
        public static void CopyCount(GraphicsBuffer src, ComputeBuffer dst, int dstOffsetBytes);
        public static void CopyCount(ComputeBuffer src, ComputeBuffer dst, int dstOffsetBytes);


        public void Dispose();



        /*
            摘要:
            Read data values from the buffer into an array. 
            The array can only use "blittable types".
            (猜测: "可执行 blit 的类型", 微软文档说: 是可在 托管代码和未托管代码间直接传递的 数据类型 )


            The retrieved data will follow the data layout rules of the graphics API in use. 

            取回的数据 要遵循 图形API 的 "data layout rules"
            去这个页面查看 跨平台兼容性信息:
                https://docs.unity3d.com/2021.1/Documentation/Manual/class-ComputeShader.html

            注意:
            本函数从 gpu 端将数据读回 cpu, 这个过程是很慢的;

            如果此时存在一些已经 submit 的, "向目标 buffer 写入数据" 的任务, 那么本函数会先等待这些工作做完,
            然后再去读取目标 buffer, 以保证最终读取的数据, 是最新的;

            因此, 你应该改用 class AsyncGPUReadback, 因为它能在后台执行请求, 不会向本函数一样当初阻塞;
        
            注意:
            只有 "blittable types" can be copied from the buffer to the array, 
            the array's type must be a blittable type. 否则, 会抛出异常
            
            参数:
             data:
                An array to receive the data.
                将读取到的 数据, 存入这个 array 中;
        
            managedBufferStartIndex:
                The first element index in data where retrieved elements are copied.
                array [dst] 中的下标 
            
            computeBufferStartIndex:
                The first element index of the buffer from which elements are read.
                buffer [src] 中的下标
        
            count:
                The number of elements to retrieve.
                要读取的元素的个数;
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
        [FreeFunctionAttribute(Name = "GraphicsBuffer_Bindings::InternalGetNativeBufferPtr", HasExplicitThis = true)]
        public IntPtr GetNativeBufferPtr();

        

        
        // 摘要:
        //     Returns true if this graphics buffer is valid, or false otherwise.
        public bool IsValid();


        
        // 摘要:
        //     Release a Graphics Buffer.
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
            
            参数:
            data:
                Array of values to fill the buffer.
            
            nativeBufferStartIndex:
                (data 存储在 cpu端 原生代码中) 

            managedBufferStartIndex:
                (data 存储在 cpu端 托管代码中) 
                The first element index in data to copy to the graphics buffer.
            
            graphicsBufferStartIndex:
                The first element index in the graphics buffer to receive the data.
                本 buffer 的idx

            count:
                要复制的元素的个数
        */
        [SecuritySafeCritical]
        public void SetData(Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count);

        [SecuritySafeCritical]
        public void SetData<T>(List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) where T : struct;

        [SecuritySafeCritical]
        public void SetData<T>(NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count) where T : struct;
        

        [SecuritySafeCritical]
        public void SetData<T>(NativeArray<T> data) where T : struct;

        [SecuritySafeCritical]
        public void SetData<T>(List<T> data) where T : struct;

        [SecuritySafeCritical]
        public void SetData(Array data);
        


        /*
            摘要:
            The type of graphics buffer.
            这些 flag 是可以相互组合的
        */
        [Flags]
        public enum Target
        {
            
            // 摘要:
            //     GraphicsBuffer can be used to store vertex data.  顶点数据
            Vertex = 1,
            
            // 摘要:
            //     GraphicsBuffer can be used as an index buffer. (顶点的 idx)
            Index = 2,
            
            /*
                摘要:
                GraphicsBuffer can be used as a "structured buffer".
                (可在笔记中查找此关键词)
            */
            Structured = 16,

            /*
                摘要:
                GraphicsBuffer can be used as a raw buffer ("Byte Address Buffer").
                (可在笔记中查找此关键词)
            */
            Raw = 32,
            
            /*
                摘要:
                GraphicsBuffer can be used as an append-consume buffer. 
                "Append and Consume Buffer"
                (可在笔记中查找此关键词)
            */
            Append = 64,


            /*
                摘要:
                GraphicsBuffer with an internal counter. 
                See Also: GraphicsBuffer.SetCounterValue and GraphicsBuffer.CopyCount.

            */
            Counter = 128,


            /*
                摘要:
                GraphicsBuffer can be used as an indirect argument buffer 
                for indirect draws and dispatches.
            */
            IndirectArguments = 256,

            /*
                摘要:
                GraphicsBuffer can be used as a "constant buffer".
            */
            Constant = 512
        }// Target end


    }// GraphicsBuffer end
}

