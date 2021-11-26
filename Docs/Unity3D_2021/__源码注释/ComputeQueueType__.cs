
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        Describes the desired characteristics with respect to prioritisation and load
        balancing of the queue that a command buffer being submitted via Graphics.ExecuteCommandBufferAsync
        or [[ScriptableRenderContext.ExecuteCommandBufferAsync] should be sent to.

        描述了与 "queue 的优先级 和 负载平衡" 相关的所需特征;

        应当通过:
            -- Graphics.ExecuteCommandBufferAsync()
            -- ScriptableRenderContext.ExecuteCommandBufferAsync()
        将 command buffer 发送到这个 queue;
    */
    public enum ComputeQueueType//ComputeQueueType__
    {
        /*
            This queue type would be the choice for compute tasks "supporting or as optimisations
            to graphics processing". CommandBuffers sent to this queue would be expected to
            complete within the scope of a single frame and likely be synchronised with the
            graphics queue via GPUFences. Dispatches on default queue types would execute
            at a lower priority than graphics queue tasks.

            本类型适用的 task: "支持或优化 图形处理"。

            发送到此类型 queue 的 commandbuffer, 预计将在一帧内完成任务, 并可通过 GPUFences 与图形queue 同步;

            default queue types 的 Dispatch(分发,调度) 的优先级, 要低于 graphics queue task;
        */
        Default = 0,


        /*
            Background queue types would be the choice for tasks intended to run for an extended
            period of time, e.g for most of a frame or for several frames. Dispatches on
            background queues would execute at a lower priority than gfx queue tasks.

            本类型适用于 想要长时间运行的 task; (比如这个 task 将占据一帧的大部分时间, 或者连续好几帧)

            Dispatches on background queues 的优先级要低于 gfx queue task;
        */
        Background = 1,


        /*
            This queue type would be the choice for compute tasks requiring processing as
            soon as possible and would be prioritised over the graphics queue.

            Note due to the way that 
            "Unity internally deferrs it's submission of command buffers to the GPU users"
            should not expect 
            "compute shader dispatches sent to Urgent async compute queues" 
            to complete and be available on the CPU immediately. 

            On some platforms it is possible for the OS to schedule GPU work that would take priority 
            over urgent async compute tasks.

            本类型适用的 task: 要求尽快处理, 并且优先于 graphics queue;

            注意:
            由于 unity 在内部会将 command buffer 延迟提交给 gpu users, 所以不该期待 
            发送给 "Urgent async compute queues" 的 "compute shader dispatches" 
            能被立即完成 并在 cpu端可用;

            在某些平台, 操作系统可调度 优先于 "Urgent async compute tasks" 的 gpu工作;
        */
        Urgent = 2 // 紧迫
    }
}

