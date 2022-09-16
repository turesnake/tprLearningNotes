#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion


namespace UnityEngine
{
    /*
        A CharacterController allows you to easily do movement constrained by collisions
        without having to deal with a rigidbody.
        
    */
    [NativeHeaderAttribute("Modules/Physics/CharacterController.h")]
    public class CharacterController : Collider
    {
        public CharacterController();

        //
        // 摘要:
        //     The current relative velocity of the Character (see notes).
        public Vector3 velocity { get; }
        //
        // 摘要:
        //     Was the CharacterController touching the ground during the last move?
        public bool isGrounded { get; }
        //
        // 摘要:
        //     What part of the capsule collided with the environment during the last CharacterController.Move
        //     call.
        public CollisionFlags collisionFlags { get; }
        //
        // 摘要:
        //     The radius of the character's capsule.
        public float radius { get; set; }
        //
        // 摘要:
        //     The height of the character's capsule.
        public float height { get; set; }
        //
        // 摘要:
        //     The center of the character's capsule relative to the transform's position.
        public Vector3 center { get; set; }
        //
        // 摘要:
        //     The character controllers slope limit in degrees.
        public float slopeLimit { get; set; }
        //
        // 摘要:
        //     The character controllers step offset in meters.
        public float stepOffset { get; set; }
        //
        // 摘要:
        //     The character's collision skin width.
        public float skinWidth { get; set; }
        //
        // 摘要:
        //     Gets or sets the minimum move distance of the character controller.
        public float minMoveDistance { get; set; }
        //
        // 摘要:
        //     Determines whether other rigidbodies or character controllers collide with this
        //     character controller (by default this is always enabled).
        public bool detectCollisions { get; set; }
        //
        // 摘要:
        //     Enables or disables overlap recovery. Enables or disables overlap recovery. Used
        //     to depenetrate character controllers from static objects when an overlap is detected.
        public bool enableOverlapRecovery { get; set; }

        //
        // 摘要:
        //     Supplies the movement of a GameObject with an attached CharacterController component.
        //
        // 参数:
        //   motion:
        public CollisionFlags Move(Vector3 motion);
        //
        // 摘要:
        //     Moves the character with speed.
        //
        // 参数:
        //   speed:
        public bool SimpleMove(Vector3 speed);
    }
}

