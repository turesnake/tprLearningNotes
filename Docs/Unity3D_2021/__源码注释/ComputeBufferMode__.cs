#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    /*
        摘要:
        Intended usage of the buffer. buffer 的预期用途

        使用此 enum, 将 buffer 的预期用途传递给引擎, 
        以便 unity 直到 where and how 存储 buffer 数据;
    */
    [NativeTypeAttribute("Runtime/GfxDevice/GfxDeviceTypes.h")]
    public enum ComputeBufferMode//ComputeBufferMode__
    {

        /*
            摘要:
            Static buffer, only initial upload allowed by the CPU

            除了在 buffer 创建时可选地提供 buffer 的初始内容之外，CPU 不会修改此 buffer;
            unity 通常将这些 buffer 存储在 "GPU 专用内存"（如果可用）中。
            (就是 显卡内存, 显存)

            Compute shaders and other GPU operations 允许修改这个 buffer 的内容;
        */
        Immutable = 0, // 不可变

        /*
            摘要:
            Dynamic buffer.

            如果 cpu 端需要频繁的修改数据, 选择此项;

            unity 会将这种 buffer 存储到 "GPU-visible CPU memory", 
            以支持频繁的 cpu 端改写, 代价就是 gpu 需要额外支付: 读取 cpu 端内存的代价;

            如果 gpu 正在读, 而 cpu又要改写之,  Unity makes the GPU see the buffer contents 
            as they were at the time the GPU command was issued. (没看懂)

            这会创建 buffer 的 瞬时额外副本, 当 gpu端操作(读取) 接收后, 这些临时副本 会被立即删除
        */
        Dynamic = 1,


        
        // 摘要:
        //     Legacy mode, do not use. 废弃, 不使用
        Circular = 2,

        /*
            摘要:
            Stream Out / Transform Feedback output buffer. Internal use only.

            似乎是 unity 内部专用 ?
        */
        StreamOut = 3,

        /*
            摘要:
            Dynamic, unsynchronized(不同步) access to the buffer.

            和上面的 Dynamic 相似, 不同在于: unity 不执行 cpu-gpu 同步操作;

            如果 cpu端写入 和 gpu端读取 同时发生, 结果未定义;

            比如:
            将此模式的 buffer, 结合 GraphicsFence 一起使用, 可用来实现 circular buffers
        */
        SubUpdates = 4
    }
}

