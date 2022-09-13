#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     Describes a contact point where the collision occurs.
    [NativeHeaderAttribute("Modules/Physics/MessageParameters.h")]
    [UsedByNativeCodeAttribute]
    public struct ContactPoint
    {
        //
        // 摘要:
        //     The point of contact.
        public Vector3 point { get; }

        //
        // 摘要:
        //     Normal of the contact point.
        public Vector3 normal { get; }

        //
        // 摘要:
        //     The first collider in contact at the point.
        public Collider thisCollider { get; }

        //
        // 摘要:
        //     The other collider in contact at the point.
        public Collider otherCollider { get; }
        
        //
        // 摘要:
        //     The distance between the colliders at the contact point.
        public float separation { get; }
    }
}