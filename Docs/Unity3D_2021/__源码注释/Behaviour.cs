
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     Behaviours are Components that can be enabled or disabled.
    [NativeHeaderAttribute("Runtime/Mono/MonoBehaviour.h")]
    [UsedByNativeCodeAttribute]
    public class Behaviour : Component
    {
        public Behaviour();

        //
        // 摘要:
        //     Enabled Behaviours are Updated, disabled Behaviours are not.
        [NativePropertyAttribute]
        [RequiredByNativeCodeAttribute]
        public bool enabled { get; set; }
        //
        // 摘要:
        //     Reports whether a GameObject and its associated Behaviour is active and enabled.
        [NativePropertyAttribute]
        public bool isActiveAndEnabled { get; }
    }
}
