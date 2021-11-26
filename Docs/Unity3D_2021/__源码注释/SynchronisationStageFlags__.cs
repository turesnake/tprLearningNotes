#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Describes the various stages of GPU processing against which the GraphicsFence
        can be set and waited against.
        --
        描述 "可以设置和等待 GraphicsFence" 的 "GPU处理" 的数个阶段。

        这些 flag 可以组合, 
        比如, 一旦先前所有的 drawcalls 都完成了它们的 vs 部分, 同时 先前所有的 computer-shader dispatches 也完成了,
        那么一个创建时设置为 "VertexProcessing" | "ComputeProcessing" 的 GraphicsFence 就完成了;
    */
    public enum SynchronisationStageFlags//SynchronisationStageFlags__
    {
        /*
            All aspects of vertex processing in the GPU.

            gpu 中所有的 vertex-shader 部分;
        */
        VertexProcessing = 1,
        
        //     All aspects of pixel processing in the GPU.
        //    gpu 中所有的 frag-shader 部分;
        PixelProcessing = 2,
        
        //     All compute shader dispatch operations.
        //   gpu 中所有的 compute-shader 部分;
        ComputeProcessing = 4,
        

        //     All previous GPU operations (vertex, pixel and compute).
        //  包含上述三种部分
        AllGPUOperations = 7
    }
}

