#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        The type of the GraphicsFence. 
        Currently the only supported fence type is AsyncQueueSynchronization.

    */
    public enum GraphicsFenceType
    {
        /*
            The GraphicsFence can be used to synchronise between different GPU queues, as
            well as to synchronise between GPU and the CPU.

            GraphicsFence 可被用来在不同的 gpu queue 之间做同步, 
            和在 "cpu 和 gpu 之间做同步" 是一样的;
        */
        AsyncQueueSynchronisation = 0,


        /*
            The GraphicsFence can only be used to synchronize between the GPU and the CPU.

            GraphicsFence 只能用来在 "cpu 和 gpu 之间做同步";
        */
        CPUSynchronisation = 1
    }
}

