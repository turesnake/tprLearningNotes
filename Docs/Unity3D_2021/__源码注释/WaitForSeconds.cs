#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    /*
        Suspends the coroutine execution for the given amount of seconds using scaled time.

        The real time suspended is equal to the given time divided by Time.timeScale. 
        See WaitForSecondsRealtime() if you wish to wait using unscaled time. 
        WaitForSeconds can only be used with a yield statement in coroutines.

        There are some factors which can mean the actual amount of time waited does not precisely match the amount of time specified:
        有一些因素可能意味着实际等待的时间量与指定的时间量不完全匹配：
        1. Start waiting at the end of the current frame. 
            If you start WaitForSeconds with duration 't' in a long frame 
            (for example, one which has a long operation which blocks the main thread such as some synchronous loading), 
            the coroutine will return 't' seconds after the end of the frame, not 't' seconds after it was called.
            ---
            一个具有长操作的线程，该操作阻塞了主线程，例如一些同步加载; 
            协程会在本帧结束时 返回 t 秒, 而不是从自己调用时算起的 t 秒;
        
        2. Allow the coroutine to resume on the first frame after 't' seconds has passed, 
            not exactly after 't' seconds has passed.
            ---
            允许协程在 t 秒后的 第一帧 内恢复, 而不是正好在 t 秒后立即恢复;

    */
    [RequiredByNativeCodeAttribute]
    public sealed class WaitForSeconds : YieldInstruction
    {
        /*
            Suspends the coroutine execution for the given amount of seconds using scaled time.

            Create a yield instruction. Wait for seconds multiplied by Time.scaledTime. 
            If seconds is set to 2.0f and Time.scaledTime is set to 0.5f, the wait is 4.0f (2.0f divided by 0.5f seconds). 
        
            参数:
            seconds:
                Delay execution by the amount of time in seconds.

        */
        public WaitForSeconds(float seconds);
    }
}

