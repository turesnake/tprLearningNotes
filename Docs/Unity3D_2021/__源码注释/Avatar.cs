#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     Avatar definition.
    [NativeHeaderAttribute("Modules/Animation/Avatar.h")]
    [UsedByNativeCodeAttribute]
    public class Avatar : Object
    {
        //
        // 摘要:
        //     Return true if this avatar is a valid mecanim avatar. It can be a generic avatar
        //     or a human avatar.
        public bool isValid { get; }
        //
        // 摘要:
        //     Return true if this avatar is a valid human avatar.
        public bool isHuman { get; }
        //
        // 摘要:
        //     Returns the HumanDescription used to create this Avatar.
        public HumanDescription humanDescription { get; }
    }
}