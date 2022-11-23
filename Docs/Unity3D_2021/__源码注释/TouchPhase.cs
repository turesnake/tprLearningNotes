#region 程序集 UnityEngine.InputLegacyModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.InputLegacyModule.dll
#endregion

namespace UnityEngine
{
    //
    // 摘要:
    //     Describes phase of a finger touch.
    public enum TouchPhase
    {
        //
        // 摘要:
        //     A finger touched the screen.
        Began = 0,
        //
        // 摘要:
        //     A finger moved on the screen.
        Moved = 1,
        //
        // 摘要:
        //     A finger is touching the screen but hasn't moved.
        Stationary = 2,
        //
        // 摘要:
        //     A finger was lifted from the screen. This is the final phase of a touch.
        Ended = 3,
        //
        // 摘要:
        //     The system cancelled tracking for the touch.
        Canceled = 4
    }
}
