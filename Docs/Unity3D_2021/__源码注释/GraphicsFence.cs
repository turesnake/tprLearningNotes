#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{
    /*
        摘要:
        用于管理 "async compute queues" 和 "graphics queue" 中的 tasks 之间的同步。
        猜测:
            假设要同步两个 task, 这两个 task 的类型可以是 上面两者中的任意一种, 
            可以都是 "async compute queues" 的, 或都是 "graphics queue" 的;

        Not all platforms support Graphics fences. See "SystemInfo.supportsGraphicsFence".

        一个 "GraphicsFence" 表示 gpu运算流程 中的一个时间节点, 
            要么是在 某个 "compute shader dispatch" 运算结束时,
            要么是在 某个 draw call (的某个环节,比如 vs, fs) 运算结束时;
        
        通过让一个或多个 queue 等待, 直到通过给定的 fence，
        "GraphicsFence" 可用于在 "async compute queue" 或 "graphics queue" 中的 tasks 之间实现同步。
        tpr:
            假设有两个 task 要同步, fence 就是一个预定要同步的时间节点, 让其中某一个先执行的 task 等待一下,
            这个等待一直持续到 fence 这个时间节点;  以此来实现两个 task 得同步;

        这是使用 async compute 时的一个重要考虑因素，因为在 "graphics queue" 和 "async compute queues" 
        上同时运行的各种 tasks 是提高 GPU 性能的关键。

        如果一个 task 向一个资源写入数据, 而这个数据会被另一个 task 读取, GPUFences 不需要被用来去同步这样的 task;
        这种 资源的 依赖关系, 会被 unity 自动处理;

        应该调用 "Graphics.CreateGraphicsFence()" 或 "CommandBuffer.CreateGraphicsFence()" 来新建一个 GPUFence,
        如果使用的 GPUFence 不是从这两个函数创建的, 将会抛出异常;

        依靠 GraphicsFences 可以实现 "circular dependencies" (循环依赖), 这会导致 GPU 死锁;

        在 editor 中 unity 会探查这种 循环依赖, 在调用以下函数:
            Graphics.CreateGraphicsFence()
            Graphics.WaitOnGraphicsFence()
            Graphics.ExecuteCommandBuffer() 
            Graphics.ExecuteCommandBufferAsync()
            ScriptableRenderContext.ExecuteCommandBuffer() 
            ScriptableRenderContext.ExecuteCommandBufferAsync()
        之后, 如果探查到 循环依赖, 会抛出异常;

    */
    [NativeHeaderAttribute("Runtime/Graphics/GPUFence.h")]
    [UsedByNativeCodeAttribute]
    public struct GraphicsFence
    {
        /*
            摘要:
            Determines whether the GraphicsFence has passed. 

            毕竟 fence 就是个时间节点, 探查这个 时间节点 是否达到;

            Allows the CPU to determine whether the GPU has passed the point 
            in its processing represented by the GraphicsFence.
        */
        public bool passed { get; }
    }
}

