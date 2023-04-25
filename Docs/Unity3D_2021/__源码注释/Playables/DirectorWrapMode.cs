
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Playables
{
    //
    // 摘要:
    //     Wrap mode for Playables.
    public enum DirectorWrapMode
    {
        //
        // 摘要:
        //     Hold the last frame when the playable time reaches it's duration.
        Hold = 0,
        //
        // 摘要:
        //     Loop back to zero time and continue playing.
        Loop = 1,
        //
        // 摘要:
        //     Do not keep playing when the time reaches the duration.
        None = 2
    }
}
