#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    /*
        Priority of a thread.

        Lower priority means a background operation will run less often and will take up less time, but will progress more slowly.

        一个后台操作的 优先级越低, 意味着它的运行频率会越低, 占用时间较少, 但是它的 推进速度也更慢;
    */
    public enum ThreadPriority
    {
        //
        // 摘要:
        //     Lowest thread priority.
        Low = 0,
        //
        // 摘要:
        //     Below normal thread priority.
        BelowNormal = 1,
        //
        // 摘要:
        //     Normal thread priority.
        Normal = 2,
        //
        // 摘要:
        //     Highest thread priority.
        High = 4
    }
}
