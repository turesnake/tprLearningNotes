#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Playables
{
    //
    // 摘要:
    //     Status of a Playable.
    public enum PlayState
    {
        //
        // 摘要:
        //     The Playable has been paused. Its local time will not advance.
        Paused = 0,
        //
        // 摘要:
        //     The Playable is currently Playing.
        Playing = 1,
        //
        // 摘要:
        //     The Playable has been delayed, using PlayableExtensions.SetDelay. It will not
        //     start until the delay is entirely consumed (消耗).
        Delayed = 2
    }
}
