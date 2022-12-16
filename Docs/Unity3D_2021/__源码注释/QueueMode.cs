#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion

namespace UnityEngine
{
    //
    // 摘要:
    //     Used by Animation.Play function.
    public enum QueueMode
    {
        //
        // 摘要:
        //     Will start playing after all other animations have stopped playing.
        CompleteOthers = 0,
        //
        // 摘要:
        //     Starts playing immediately. This can be used if you just want to quickly create
        //     a duplicate animation.
        PlayNow = 2
    }
}
