#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    /*
        Waits until next fixed frame rate update function. See Also: MonoBehaviour.FixedUpdate.
        WaitForFixedUpdate can only be used with a yield statement in coroutines.
        ---
        待机直到下一次调用 FixedUpdate();
    */
    [RequiredByNativeCodeAttribute]
    public sealed class WaitForFixedUpdate : YieldInstruction
    {
        public WaitForFixedUpdate();
    }
}

