#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     A base class of all colliders.
    [NativeHeaderAttribute("Modules/Physics/Collider.h")]
    [RequireComponent(typeof(Transform))]
    [RequiredByNativeCodeAttribute]
    public class Collider : Component
    {
        public Collider();

        //
        // 摘要:
        //     Enabled Colliders will collide with other Colliders, disabled Colliders won't.
        public bool enabled { get; set; }
        //
        // 摘要:
        //     The rigidbody the collider is attached to.
        public Rigidbody attachedRigidbody { get; }
        //
        // 摘要:
        //     The articulation body the collider is attached to.
        public ArticulationBody attachedArticulationBody { get; }
        //
        // 摘要:
        //     Is the collider a trigger?
        public bool isTrigger { get; set; }
        //
        // 摘要:
        //     Contact offset value of this collider.
        public float contactOffset { get; set; }
        //
        // 摘要:
        //     The world space bounding volume of the collider (Read Only).
        public Bounds bounds { get; }
        //
        // 摘要:
        //     Specify whether this Collider's contacts are modifiable or not.
        public bool hasModifiableContacts { get; set; }
        //
        // 摘要:
        //     The shared physic material of this collider.
        [NativeMethodAttribute("Material")]
        public PhysicMaterial sharedMaterial { get; set; }
        //
        // 摘要:
        //     The material used by the collider.
        public PhysicMaterial material { get; set; }

        //
        // 摘要:
        //     Returns a point on the collider that is closest to a given location.
        //
        // 参数:
        //   position:
        //     Location you want to find the closest point to.
        //
        // 返回结果:
        //     The point on the collider that is closest to the specified location.
        public Vector3 ClosestPoint(Vector3 position);


        /*
            The closest point to the bounding box of the attached collider.
            This can be used to calculate hit points when applying explosion damage.

            传入的参数一般为 爆心点; 

            猜测: 
                方法调用者, 那个 collider 实例, 可以是 "被爆炸击中的一个物体"; 传入的参数就是 爆心pos,
                计算得到 本物体身上, 离爆心pos 最近的一个点; (球形扩散)
            

        // 参数:
        //   position:
        */
        public Vector3 ClosestPointOnBounds(Vector3 position);


        public bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance);
    }
}
