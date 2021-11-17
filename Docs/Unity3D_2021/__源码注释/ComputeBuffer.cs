#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.Security;
using Unity.Collections;

namespace UnityEngine
{
    //
    // 摘要:
    //     GPU data buffer, mostly for use with compute shaders.
    [NativeHeaderAttribute("Runtime/Shaders/ComputeShader.h")]
    [NativeHeaderAttribute("Runtime/Export/Shaders/ComputeShader.bindings.h")]
    [UsedByNativeCodeAttribute]
    public sealed class ComputeBuffer : IDisposable
    {
        //
        // 摘要:
        //     Create a Compute Buffer.
        //
        // 参数:
        //   count:
        //     Number of elements in the buffer.
        //
        //   stride:
        //     Size of one element in the buffer. Has to match size of buffer type in the shader.
        //     See for cross-platform compatibility information.
        //
        //   type:
        //     Type of the buffer, default is ComputeBufferType.Default (structured buffer).
        public ComputeBuffer(int count, int stride);
        public ComputeBuffer(int count, int stride, ComputeBufferType type);
        public ComputeBuffer(int count, int stride, ComputeBufferType type, ComputeBufferMode usage);

        ~ComputeBuffer();

        //
        // 摘要:
        //     Number of elements in the buffer (Read Only).
        public int count { get; }
        //
        // 摘要:
        //     Size of one element in the buffer (Read Only).
        public int stride { get; }
        //
        // 摘要:
        //     The debug label for the ComputeBuffer. This name shows up in profiling and frame
        //     debugger tools, wherever supported.
        public string name { set; }

        //
        // 摘要:
        //     Copy counter value of append/consume buffer into another buffer.
        //
        // 参数:
        //   src:
        //     Append/consume buffer to copy the counter from.
        //
        //   dst:
        //     A buffer to copy the counter to.
        //
        //   dstOffsetBytes:
        //     Target byte offset in dst.
        public static void CopyCount(ComputeBuffer src, ComputeBuffer dst, int dstOffsetBytes);
        public NativeArray<T> BeginWrite<T>(int computeBufferStartIndex, int count) where T : struct;
        public void Dispose();
        public void EndWrite<T>(int countWritten) where T : struct;


        //
        // 摘要:
        //     Read data values from the buffer into an array. The array can only use <a href="https:docs.microsoft.comen-usdotnetframeworkinteropblittable-and-non-blittable-types">blittable<a>
        //     types.
        //
        // 参数:
        //   data:
        //     An array to receive the data.
        [SecurityCritical]
        public void GetData(Array data);


        //
        // 摘要:
        //     Partial read of data values from the buffer into an array.
        //
        // 参数:
        //   data:
        //     An array to receive the data.
        //
        //   managedBufferStartIndex:
        //     The first element index in data where retrieved elements are copied.
        //
        //   computeBufferStartIndex:
        //     The first element index of the compute buffer from which elements are read.
        //
        //   count:
        //     The number of elements to retrieve.
        [SecurityCritical]
        public void GetData(Array data, int managedBufferStartIndex, int computeBufferStartIndex, int count);


        //
        // 摘要:
        //     Retrieve a native (underlying graphics API) pointer to the buffer.
        //
        // 返回结果:
        //     Pointer to the underlying graphics API buffer.
        public IntPtr GetNativeBufferPtr();

        
        //
        // 摘要:
        //     Returns true if this compute buffer is valid and false otherwise.
        public bool IsValid();
        //
        // 摘要:
        //     Release a Compute Buffer.
        public void Release();
        //
        // 摘要:
        //     Sets counter value of append/consume buffer.
        //
        // 参数:
        //   counterValue:
        //     Value of the append/consume counter.
        public void SetCounterValue(uint counterValue);
        //
        // 摘要:
        //     Set the buffer with values from an array.
        //
        // 参数:
        //   data:
        //     Array of values to fill the buffer.
        [SecuritySafeCritical]
        public void SetData(Array data);
        [SecuritySafeCritical]
        public void SetData<T>(List<T> data) where T : struct;
        [SecuritySafeCritical]
        public void SetData<T>(NativeArray<T> data) where T : struct;
        //
        // 摘要:
        //     Partial copy of data values from an array into the buffer.
        //
        // 参数:
        //   data:
        //     Array of values to fill the buffer.
        //
        //   managedBufferStartIndex:
        //     The first element index in data to copy to the compute buffer.
        //
        //   computeBufferStartIndex:
        //     The first element index in compute buffer to receive the data.
        //
        //   count:
        //     The number of elements to copy.
        //
        //   nativeBufferStartIndex:
        [SecuritySafeCritical]
        public void SetData(Array data, int managedBufferStartIndex, int computeBufferStartIndex, int count);
        [SecuritySafeCritical]
        public void SetData<T>(NativeArray<T> data, int nativeBufferStartIndex, int computeBufferStartIndex, int count) where T : struct;
        [SecuritySafeCritical]
        public void SetData<T>(List<T> data, int managedBufferStartIndex, int computeBufferStartIndex, int count) where T : struct;
    }
}
