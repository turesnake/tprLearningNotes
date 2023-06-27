#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion

using System;

namespace UnityEngine
{
    //
    // 摘要:
    //     A box-shaped primitive collider.
    [NativeHeaderAttribute("Modules/Physics/BoxCollider.h")]
    [RequiredByNativeCodeAttribute]
    public class BoxCollider : Collider
    {
        public BoxCollider();

        //
        // 摘要:
        //     The center of the box, measured in the object's local space.
        public Vector3 center { get; set; }
        //
        // 摘要:
        //     The size of the box, measured in the object's local space.
        public Vector3 size { get; set; }
        [Obsolete("Use BoxCollider.size instead. (UnityUpgradable) -> size")]
        public Vector3 extents { get; set; }
    }
}