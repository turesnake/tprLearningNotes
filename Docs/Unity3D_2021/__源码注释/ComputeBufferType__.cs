#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        摘要:
        ComputeBuffer type.

        这些 flag 是可以相互组合的, 参考下方的 "Constant" flag 中的描述;
    */
    [Flags]
    public enum ComputeBufferType//ComputeBufferType__
    {
        
        /*
            摘要:
            Default ComputeBuffer type (structured buffer).

            In HLSL shaders, 就是 StructuredBuffer<T> or RWStructuredBuffer<T>.

            与之关联的 stride(步长) (也就是传入 ComputeBuffer() 构造函数中的参数)
            必须符合 structure size, 值必须是 4 的倍数, 且小于 2048;
        */
        Default = 0,


        /*
            摘要:
            Raw ComputeBuffer type (byte address buffer).

            In HLSL shaders, 就是 ByteAddressBuffer or RWByteAddressBuffer. 
            Underlying DX11 format for shader access is typeless R32.
        */
        Raw = 1,


        /*
            摘要:
            Append-consume ComputeBuffer type.

            类似 stack, 可在尾部 添加和删除元素;
            Maps to AppendStructuredBuffer<T> or ConsumeStructuredBuffer<T> in HLSL.

            在构造此 buffer 时, 传入的 stride(步长) 必须符合 structure size, 值必须是 4 的倍数, 且小于 2048;
        */
        Append = 2,


        /*
            摘要:
            ComputeBuffer with a counter.

            Adds a "counter" to a RWStructuredBuffer,
            可以在这个 buffer 上使用 HLSL 函数: IncrementCounter() / DecrementCounter()

            在构造此 buffer 时, 传入的 stride(步长) 必须符合 structure size, 值必须是 4 的倍数, 且小于 2048;
        */
        Counter = 4,

        /*
            摘要:
            ComputeBuffer that you can use as a constant buffer (uniform buffer).

            可将此 buffer 用于 Shader.SetConstantBuffer(), Material.SetConstantBuffer();

            如果你还需要将这个 buffer 绑定为 structured buffer, 你还需要添加
            ComputeBufferType.StructuredBuffer flag;

            有些平台如 DX11, 不支持 即是 constant 又是 structured buffer;
        */
        Constant = 8,

        /*
            摘要:
            ComputeBuffer that you can use as a structured buffer.

            如果但用这个 flag, 那么它的结果, 和使用 ComputeBufferType.Default 是完全一致的;
            
            但是如果你想要用数个 flag 来合成一个 类型, 那么就不该用 Default, 而是用本 flag 去组合;
            (毕竟 Default 值未 0, 它没有开启任何 flag)
        */
        Structured = 16,


        DrawIndirect = 256,


        /*
            摘要:
            ComputeBuffer used for:
                Graphics.DrawProceduralIndirect(), 
                ComputeShader.DispatchIndirect()
                Graphics.DrawMeshInstancedIndirect()

            Buffer size has to be at least 12 bytes. 

            Underlying DX11 unordered access view format will be R32_UINT, 
            and shader resource view format will be R32 typeless.
        */
        IndirectArguments = 256,


        GPUMemory = 512
    }
}

