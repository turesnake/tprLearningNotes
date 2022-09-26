
#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion


namespace UnityEngine
{
    /*
        A capsule-shaped primitive collider.

    */
    [NativeHeaderAttribute("Modules/Physics/CapsuleCollider.h")]
    [RequiredByNativeCodeAttribute]
    public class CapsuleCollider : Collider
    {
        public CapsuleCollider();

        //
        // 摘要:
        //     The center of the capsule, measured in the object's local space.
        public Vector3 center { get; set; }
        //
        // 摘要:
        //     The radius of the sphere, measured in the object's local space.
        public float radius { get; set; }
        //
        // 摘要:
        //     The height of the capsule measured in the object's local space.
        public float height { get; set; }



        /*
            The direction of the capsule.
            值:
                0 -- X Axis
                1 -- Y Axis
                2 -- Z Axis

            这些轴 是 os 空间的, 然后可以配合 transform.forward 之类的方向, 
            得到 真正的 胶囊体 朝向;
        */
        public int direction { get; set; }




    }
}

