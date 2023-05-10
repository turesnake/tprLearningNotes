#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     A sphere-shaped primitive collider.
    [NativeHeaderAttribute("Modules/Physics/SphereCollider.h")]
    [RequiredByNativeCodeAttribute]
    public class SphereCollider : Collider
    {
        public SphereCollider();

        //
        // 摘要:
        //     The center of the sphere in the object's local space.
        public Vector3 center { get; set; }
        //
        // 摘要:
        //     The radius of the sphere measured in the object's local space.
        public float radius { get; set; }
    }
}

