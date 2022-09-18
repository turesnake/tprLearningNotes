#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion

namespace UnityEngine
{
    /*
        CollisionFlags is a bitmask returned by CharacterController.Move.

        It gives you a broad overview of where your character collided with any other objects.
    
    
    */
    public enum CollisionFlags
    {
        //
        // 摘要:
        //     CollisionFlags is a bitmask returned by CharacterController.Move.
        None = 0,
        //
        // 摘要:
        //     CollisionFlags is a bitmask returned by CharacterController.Move.
        Sides = 1,
        CollidedSides = 1,
        //
        // 摘要:
        //     CollisionFlags is a bitmask returned by CharacterController.Move.
        Above = 2,
        CollidedAbove = 2,
        //
        // 摘要:
        //     CollisionFlags is a bitmask returned by CharacterController.Move.
        Below = 4,
        CollidedBelow = 4
    }
}

