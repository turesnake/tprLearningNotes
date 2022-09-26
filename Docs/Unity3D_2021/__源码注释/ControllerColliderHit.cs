#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     ControllerColliderHit is used by CharacterController.OnControllerColliderHit
    //     to give detailed information about the collision and how to deal with it.
    [RequiredByNativeCodeAttribute]
    public class ControllerColliderHit
    {
        public ControllerColliderHit();

        //
        // 摘要:
        //     The controller that hit the collider.
        public CharacterController controller { get; }
        //
        // 摘要:
        //     The collider that was hit by the controller.
        public Collider collider { get; }
        //
        // 摘要:
        //     The rigidbody that was hit by the controller.
        public Rigidbody rigidbody { get; }
        //
        // 摘要:
        //     The game object that was hit by the controller.
        public GameObject gameObject { get; }
        //
        // 摘要:
        //     The transform that was hit by the controller.
        public Transform transform { get; }
        //
        // 摘要:
        //     The impact point in world space.
        public Vector3 point { get; }
        //
        // 摘要:
        //     The normal of the surface we collided with in world space.
        public Vector3 normal { get; }
        //
        // 摘要:
        //     The direction the CharacterController was moving in when the collision occured.
        public Vector3 moveDirection { get; }
        //
        // 摘要:
        //     How far the character has travelled until it hit the collider.
        public float moveLength { get; }
    }
}

