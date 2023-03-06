#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion

using System;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Global physics properties and helper methods.
    [NativeHeaderAttribute("Modules/Physics/PhysicsManager.h")]
    [StaticAccessorAttribute("GetPhysicsManager()", Bindings.StaticAccessorType.Dot)]
    public class Physics
    {
        //
        // 摘要:
        //     Layer mask constant to select ignore raycast layer.
        public const int IgnoreRaycastLayer = 4;
        //
        // 摘要:
        //     Layer mask constant to select default raycast layers.
        public const int DefaultRaycastLayers = -5;
        //
        // 摘要:
        //     Layer mask constant to select all layers.
        public const int AllLayers = -1;
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Please use Physics.IgnoreRaycastLayer instead. (UnityUpgradable) -> IgnoreRaycastLayer", true)]
        public const int kIgnoreRaycastLayer = 4;
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Please use Physics.DefaultRaycastLayers instead. (UnityUpgradable) -> DefaultRaycastLayers", true)]
        public const int kDefaultRaycastLayers = -5;
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Please use Physics.AllLayers instead. (UnityUpgradable) -> AllLayers", true)]
        public const int kAllLayers = -1;

        public Physics();

        //
        // 摘要:
        //     Enables an improved patch friction mode that guarantees static and dynamic friction
        //     do not exceed analytical results.
        public static bool improvedPatchFriction { get; set; }
        //
        // 摘要:
        //     Default maximum angular speed of the dynamic Rigidbody, in radians (default 50).
        public static float defaultMaxAngularSpeed { get; set; }
        //
        // 摘要:
        //     The defaultSolverVelocityIterations affects how accurately the Rigidbody joints
        //     and collision contacts are resolved. (default 1). Must be positive.
        public static int defaultSolverVelocityIterations { get; set; }
        //
        // 摘要:
        //     The defaultSolverIterations determines how accurately Rigidbody joints and collision
        //     contacts are resolved. (default 6). Must be positive.
        public static int defaultSolverIterations { get; set; }
        //
        // 摘要:
        //     The maximum default velocity needed to move a Rigidbody's collider out of another
        //     collider's surface penetration. Must be positive.
        public static float defaultMaxDepenetrationVelocity { get; set; }

        /*
            Specifies whether queries (raycasts, spherecasts, overlap tests, etc.) hit Triggers by default.
            This can be overridden on a per-query level by specifying the QueryTriggerInteraction parameter.

            指定了当调用 各种 Physics.xxxCast() 函数时, 碰撞检测是否要相应那些 trigger collider;

            本处是全局配置, 其实还可以在各个 cast() 函数内指定本次检测的 设置;
        */
        public static bool queriesHitTriggers { get; set; }
        //
        // 摘要:
        //     Whether physics queries should hit back-face triangles.
        public static bool queriesHitBackfaces { get; set; }
        //
        // 摘要:
        //     The PhysicsScene automatically created when Unity starts.
        [NativePropertyAttribute("DefaultPhysicsSceneHandle", true, Bindings.TargetType.Function, true)]
        public static PhysicsScene defaultPhysicsScene { get; }
        //
        // 摘要:
        //     The mass-normalized energy threshold, below which objects start going to sleep.
        public static float sleepThreshold { get; set; }
        //
        // 摘要:
        //     The default contact offset of the newly created colliders.
        public static float defaultContactOffset { get; set; }


        
        //   The gravity applied to all rigid bodies in the Scene.
        //   tpr: 打印出来为: ( 0f, -9.81f, 0f )
        public static Vector3 gravity { get; set; }


        //
        // 摘要:
        //     Two colliding objects with a relative velocity below this will not bounce (default
        //     2). Must be positive.
        public static float bounceThreshold { get; set; }


        /*
            Sets whether the physics should be simulated automatically or not.
            ---
            对应 project settings -- physic 面板上的 Auto Simulation 开关
            关闭后可节省 物理模拟开销;
        */
        public static bool autoSimulation { get; set; }


        //
        // 摘要:
        //     Sets the minimum separation distance for cloth inter-collision.
        [StaticAccessorAttribute("GetPhysicsManager()")]
        public static float interCollisionDistance { get; set; }
        //
        // 摘要:
        //     Determines whether the garbage collector should reuse only a single instance
        //     of a Collision type for all collision callbacks.
        public static bool reuseCollisionCallbacks { get; set; }
        //
        // 摘要:
        //     Sets the cloth inter-collision stiffness.
        [StaticAccessorAttribute("GetPhysicsManager()")]
        public static float interCollisionStiffness { get; set; }
        [StaticAccessorAttribute("GetPhysicsManager()")]
        public static bool interCollisionSettingsToggle { get; set; }
        //
        // 摘要:
        //     Cloth Gravity setting. Set gravity for all cloth components.
        public static Vector3 clothGravity { get; set; }
        //
        // 摘要:
        //     The minimum contact penetration value in order to apply a penalty force (default
        //     0.05). Must be positive.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Physics.defaultContactOffset or Collider.contactOffset instead.", true)]
        public static float minPenetrationForPenalty { get; set; }
        [Obsolete("Please use bounceThreshold instead. (UnityUpgradable) -> bounceThreshold")]
        public static float bounceTreshold { get; set; }
        //
        // 摘要:
        //     The default linear velocity, below which objects start going to sleep (default
        //     0.15). Must be positive.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("The sleepVelocity is no longer supported. Use sleepThreshold. Note that sleepThreshold is energy but not velocity.", true)]
        public static float sleepVelocity { get; set; }
        //
        // 摘要:
        //     The default angular velocity, below which objects start sleeping (default 0.14).
        //     Must be positive.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("The sleepAngularVelocity is no longer supported. Use sleepThreshold. Note that sleepThreshold is energy but not velocity.", true)]
        public static float sleepAngularVelocity { get; set; }
        //
        // 摘要:
        //     The default maximum angular velocity permitted for any rigid bodies (default
        //     7). Must be positive.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Rigidbody.maxAngularVelocity instead.", true)]
        public static float maxAngularVelocity { get; set; }
        [Obsolete("Please use Physics.defaultSolverIterations instead. (UnityUpgradable) -> defaultSolverIterations")]
        public static int solverIterationCount { get; set; }
        [Obsolete("Please use Physics.defaultSolverVelocityIterations instead. (UnityUpgradable) -> defaultSolverVelocityIterations")]
        public static int solverVelocityIterationCount { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("penetrationPenaltyForce has no effect.", true)]
        public static float penetrationPenaltyForce { get; set; }
        //
        // 摘要:
        //     Whether or not to automatically sync transform changes with the physics system
        //     whenever a Transform component changes.
        public static bool autoSyncTransforms { get; set; }

        public static event Action<PhysicsScene, NativeArray<ModifiableContactPair>> ContactModifyEvent;
        public static event Action<PhysicsScene, NativeArray<ModifiableContactPair>> ContactModifyEventCCD;

        //
        // 摘要:
        //     Prepares the Mesh for use with a MeshCollider.
        //
        // 参数:
        //   meshID:
        //     The instance ID of the Mesh to bake collision data from.
        //
        //   convex:
        //     A flag to indicate whether to bake convex geometry or not.
        [StaticAccessorAttribute("GetPhysicsManager()")]
        [ThreadSafeAttribute]
        public static void BakeMesh(int meshID, bool convex);
        [ExcludeFromDocs]
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction);
        [ExcludeFromDocs]
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance);
        [ExcludeFromDocs]
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask);
        //
        // 摘要:
        //     Casts the box along a ray and returns detailed information on what was hit.
        //
        // 参数:
        //   center:
        //     Center of the box.
        //
        //   halfExtents:
        //     Half the size of the box in each dimension.
        //
        //   direction:
        //     The direction in which to cast the box.
        //
        //   orientation:
        //     Rotation of the box.
        //
        //   maxDistance:
        //     The max length of the cast.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     True, if any intersections were found.
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, [Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation);
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, [Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance);
        [ExcludeFromDocs]
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation);
        [ExcludeFromDocs]
        public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo);
        [ExcludeFromDocs]
        public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation);
        [ExcludeFromDocs]
        public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance);
        [ExcludeFromDocs]
        public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction);
        //
        // 摘要:
        //     Like Physics.BoxCast, but returns all hits.
        //
        // 参数:
        //   center:
        //     Center of the box.
        //
        //   halfExtents:
        //     Half the size of the box in each dimension.
        //
        //   direction:
        //     The direction in which to cast the box.
        //
        //   orientation:
        //     Rotation of the box.
        //
        //   maxDistance:
        //     The max length of the cast.
        //
        //   layermask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        //   layerMask:
        //
        // 返回结果:
        //     All colliders that were hit.
        public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, [Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results);
        [ExcludeFromDocs]
        public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, float maxDistance);
        [ExcludeFromDocs]
        public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation);
        //
        // 摘要:
        //     Cast the box along the direction, and store hits in the provided buffer.
        //
        // 参数:
        //   center:
        //     Center of the box.
        //
        //   halfExtents:
        //     Half the size of the box in each dimension.
        //
        //   direction:
        //     The direction in which to cast the box.
        //
        //   results:
        //     The buffer to store the results in.
        //
        //   orientation:
        //     Rotation of the box.
        //
        //   maxDistance:
        //     The max length of the cast.
        //
        //   layermask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        //   layerMask:
        //
        // 返回结果:
        //     The amount of hits stored to the results buffer.
        public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, [Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask);
        //
        // 摘要:
        //     Casts a capsule against all colliders in the Scene and returns detailed information
        //     on what was hit.
        //
        // 参数:
        //   point1:
        //     The center of the sphere at the start of the capsule.
        //
        //   point2:
        //     The center of the sphere at the end of the capsule.
        //
        //   radius:
        //     The radius of the capsule.
        //
        //   direction:
        //     The direction into which to sweep the capsule.
        //
        //   maxDistance:
        //     The max length of the sweep.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     True when the capsule sweep intersects any collider, otherwise false.
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance);
        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo);
        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance);
        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction);
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        
        
        [ExcludeFromDocs]
        public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance);
        [ExcludeFromDocs]
        public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction);
        //
        // 摘要:
        //     Like Physics.CapsuleCast, but this function will return all hits the capsule
        //     sweep intersects.
        //
        // 参数:
        //   point1:
        //     The center of the sphere at the start of the capsule.
        //
        //   point2:
        //     The center of the sphere at the end of the capsule.
        //
        //   radius:
        //     The radius of the capsule.
        //
        //   direction:
        //     The direction into which to sweep the capsule.
        //
        //   maxDistance:
        //     The max length of the sweep.
        //
        //   layermask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        //   layerMask:
        //
        // 返回结果:
        //     An array of all colliders hit in the sweep.
        public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        //
        // 摘要:
        //     Casts a capsule against all colliders in the Scene and returns detailed information
        //     on what was hit into the buffer.
        //
        // 参数:
        //   point1:
        //     The center of the sphere at the start of the capsule.
        //
        //   point2:
        //     The center of the sphere at the end of the capsule.
        //
        //   radius:
        //     The radius of the capsule.
        //
        //   direction:
        //     The direction into which to sweep the capsule.
        //
        //   results:
        //     The buffer to store the hits into.
        //
        //   maxDistance:
        //     The max length of the sweep.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     The amount of hits stored into the buffer.
        public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results);
        [ExcludeFromDocs]
        public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, float maxDistance);
        //
        // 摘要:
        //     Check whether the given box overlaps with other colliders or not.
        //
        // 参数:
        //   center:
        //     Center of the box.
        //
        //   halfExtents:
        //     Half the size of the box in each dimension.
        //
        //   orientation:
        //     Rotation of the box.
        //
        //   layermask:
        //     A that is used to selectively ignore colliders when casting a ray.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     True, if the box overlaps with any colliders.
        public static bool CheckBox(Vector3 center, Vector3 halfExtents, [Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [Internal.DefaultValue("DefaultRaycastLayers")] int layermask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask);
        [ExcludeFromDocs]
        public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation);
        [ExcludeFromDocs]
        public static bool CheckBox(Vector3 center, Vector3 halfExtents);
        //
        // 摘要:
        //     Checks if any colliders overlap a capsule-shaped volume in world space.
        //
        // 参数:
        //   start:
        //     The center of the sphere at the start of the capsule.
        //
        //   end:
        //     The center of the sphere at the end of the capsule.
        //
        //   radius:
        //     The radius of the capsule.
        //
        //   layermask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        //   layerMask:
        public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layerMask);
        [ExcludeFromDocs]
        public static bool CheckCapsule(Vector3 start, Vector3 end, float radius);
        [ExcludeFromDocs]
        public static bool CheckSphere(Vector3 position, float radius, int layerMask);
        //
        // 摘要:
        //     Returns true if there are any colliders overlapping the sphere defined by position
        //     and radius in world coordinates.
        //
        // 参数:
        //   position:
        //     Center of the sphere.
        //
        //   radius:
        //     Radius of the sphere.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        public static bool CheckSphere(Vector3 position, float radius, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool CheckSphere(Vector3 position, float radius);
        //
        // 摘要:
        //     Returns a point on the given collider that is closest to the specified location.
        //
        // 参数:
        //   point:
        //     Location you want to find the closest point to.
        //
        //   collider:
        //     The collider that you find the closest point on.
        //
        //   position:
        //     The position of the collider.
        //
        //   rotation:
        //     The rotation of the collider.
        //
        // 返回结果:
        //     The point on the collider that is closest to the specified location.
        public static Vector3 ClosestPoint(Vector3 point, Collider collider, Vector3 position, Quaternion rotation);
        public static bool ComputePenetration(Collider colliderA, Vector3 positionA, Quaternion rotationA, Collider colliderB, Vector3 positionB, Quaternion rotationB, out Vector3 direction, out float distance);
        //
        // 摘要:
        //     Checks whether the collision detection system will ignore all collisionstriggers
        //     between collider1 and collider2/ or not.
        //
        // 参数:
        //   collider1:
        //     The first collider to compare to collider2.
        //
        //   collider2:
        //     The second collider to compare to collider1.
        //
        // 返回结果:
        //     Whether the collision detection system will ignore all collisionstriggers between
        //     collider1 and collider2/ or not.
        public static bool GetIgnoreCollision([NotNullAttribute("NullExceptionObject")] Collider collider1, [NotNullAttribute("NullExceptionObject")] Collider collider2);
        //
        // 摘要:
        //     Are collisions between layer1 and layer2 being ignored?
        //
        // 参数:
        //   layer1:
        //
        //   layer2:
        public static bool GetIgnoreLayerCollision(int layer1, int layer2);
        //
        // 摘要:
        //     Makes the collision detection system ignore all collisions between collider1
        //     and collider2.
        //
        // 参数:
        //   collider1:
        //     Any collider.
        //
        //   collider2:
        //     Another collider you want to have collider1 to start or stop ignoring collisions
        //     with.
        //
        //   ignore:
        //     Whether or not the collisions between the two colliders should be ignored or
        //     not.
        public static void IgnoreCollision([NotNullAttribute("NullExceptionObject")] Collider collider1, [NotNullAttribute("NullExceptionObject")] Collider collider2, [Internal.DefaultValue("true")] bool ignore);
        [ExcludeFromDocs]
        public static void IgnoreCollision(Collider collider1, Collider collider2);
        //
        // 摘要:
        //     Makes the collision detection system ignore all collisions between any collider
        //     in layer1 and any collider in layer2. Note that IgnoreLayerCollision will reset
        //     the trigger state of affected colliders, so you might receive OnTriggerExit and
        //     OnTriggerEnter messages in response to calling this.
        //
        // 参数:
        //   layer1:
        //
        //   layer2:
        //
        //   ignore:
        [NativeNameAttribute("IgnoreCollision")]
        public static void IgnoreLayerCollision(int layer1, int layer2, [Internal.DefaultValue("true")] bool ignore);
        [ExcludeFromDocs]
        public static void IgnoreLayerCollision(int layer1, int layer2);
        [ExcludeFromDocs]
        public static bool Linecast(Vector3 start, Vector3 end);
        //
        // 摘要:
        //     Returns true if there is any collider intersecting the line between start and
        //     end.
        //
        // 参数:
        //   start:
        //     Start point.
        //
        //   end:
        //     End point.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a ray.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        public static bool Linecast(Vector3 start, Vector3 end, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask);
        [ExcludeFromDocs]
        public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo);
        [ExcludeFromDocs]
        public static bool Linecast(Vector3 start, Vector3 end, int layerMask);
        public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask);
        //
        // 摘要:
        //     Find all colliders touching or inside of the given box.
        //
        // 参数:
        //   center:
        //     Center of the box.
        //
        //   halfExtents:
        //     Half of the size of the box in each dimension.
        //
        //   orientation:
        //     Rotation of the box.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a ray.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     Colliders that overlap with the given box.
        public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, [Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [Internal.DefaultValue("AllLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents);
        [ExcludeFromDocs]
        public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation);
        //
        // 摘要:
        //     Find all colliders touching or inside of the given box, and store them into the
        //     buffer.
        //
        // 参数:
        //   center:
        //     Center of the box.
        //
        //   halfExtents:
        //     Half of the size of the box in each dimension.
        //
        //   results:
        //     The buffer to store the results in.
        //
        //   orientation:
        //     Rotation of the box.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a ray.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        //   mask:
        //
        // 返回结果:
        //     The amount of colliders stored in results.
        public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, [Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [Internal.DefaultValue("AllLayers")] int mask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation);
        [ExcludeFromDocs]
        public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results);
        [ExcludeFromDocs]
        public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation, int mask);
        [ExcludeFromDocs]
        public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius);
        [ExcludeFromDocs]
        public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius, int layerMask);
        //
        // 摘要:
        //     Check the given capsule against the physics world and return all overlapping
        //     colliders.
        //
        // 参数:
        //   point0:
        //     The center of the sphere at the start of the capsule.
        //
        //   point1:
        //     The center of the sphere at the end of the capsule.
        //
        //   radius:
        //     The radius of the capsule.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     Colliders touching or inside the capsule.
        public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius, [Internal.DefaultValue("AllLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results);
        [ExcludeFromDocs]
        public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, int layerMask);
        //
        // 摘要:
        //     Check the given capsule against the physics world and return all overlapping
        //     colliders in the user-provided buffer.
        //
        // 参数:
        //   point0:
        //     The center of the sphere at the start of the capsule.
        //
        //   point1:
        //     The center of the sphere at the end of the capsule.
        //
        //   radius:
        //     The radius of the capsule.
        //
        //   results:
        //     The buffer to store the results into.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     The amount of entries written to the buffer.
        public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, [Internal.DefaultValue("AllLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static Collider[] OverlapSphere(Vector3 position, float radius);
        [ExcludeFromDocs]
        public static Collider[] OverlapSphere(Vector3 position, float radius, int layerMask);
        //
        // 摘要:
        //     Computes and stores colliders touching or inside the sphere.
        //
        // 参数:
        //   position:
        //     Center of the sphere.
        //
        //   radius:
        //     Radius of the sphere.
        //
        //   layerMask:
        //     A defines which layers of colliders to include in the query.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     Returns an array with all colliders touching or inside the sphere.
        public static Collider[] OverlapSphere(Vector3 position, float radius, [Internal.DefaultValue("AllLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, int layerMask);
        [ExcludeFromDocs]
        public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results);
        //
        // 摘要:
        //     Computes and stores colliders touching or inside the sphere into the provided
        //     buffer.
        //
        // 参数:
        //   position:
        //     Center of the sphere.
        //
        //   radius:
        //     Radius of the sphere.
        //
        //   results:
        //     The buffer to store the results into.
        //
        //   layerMask:
        //     A defines which layers of colliders to include in the query.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     Returns the amount of colliders stored into the results buffer.
        public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, [Internal.DefaultValue("AllLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        
        
        
        /*
            Casts a ray, from point origin, in direction direction, of length maxDistance,
            against all colliders in the Scene.

            注意:
                如果 origin 自己位于某个 collider 体内, 那么这个 collider 是不会被本函数检测到的...

            实践表明, 若在此次检测中测得多个碰撞点, 此函数返回得 一定是最近的那个点;
            
            参数:
            ray:
                The starting point and direction of the ray.   

            origin:
                The starting point of the ray in world coordinates.
            
            direction:
                The direction of the ray.
            
            maxDistance:
                The max distance the ray should check for collisions.
            
            layerMask:
                A that is used to selectively ignore Colliders when casting a ray.
            
            queryTriggerInteraction:
                Specifies whether this query should hit Triggers.
            
            返回结果:
                Returns true if the ray intersects with a Collider, otherwise false.
        */
        public static bool Raycast(Ray ray, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        [RequiredByNativeCodeAttribute]
        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance);
        [ExcludeFromDocs]
        public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance);
        [ExcludeFromDocs]
        public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo);
        [ExcludeFromDocs]
        public static bool Raycast(Ray ray, out RaycastHit hitInfo);
        [ExcludeFromDocs]
        public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance);
        [ExcludeFromDocs]
        public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask);
        public static bool Raycast(Ray ray, out RaycastHit hitInfo, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool Raycast(Ray ray);
        [ExcludeFromDocs]
        public static bool Raycast(Ray ray, float maxDistance);
        [ExcludeFromDocs]
        public static bool Raycast(Ray ray, float maxDistance, int layerMask);
        public static bool Raycast(Vector3 origin, Vector3 direction, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool Raycast(Vector3 origin, Vector3 direction);


    
        //
        // 摘要:
        //     See Also: Raycast.
        //
        // 参数:
        //   origin:
        //     The starting point of the ray in world coordinates.
        //
        //   direction:
        //     The direction of the ray.
        //
        //   maxDistance:
        //     The max distance the rayhit is allowed to be from the start of the ray.
        //
        //   layermask:
        //     A that is used to selectively ignore colliders when casting a ray.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        //   layerMask:
        public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance);
        [ExcludeFromDocs]
        public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction);
        //
        // 摘要:
        //     Casts a ray through the Scene and returns all hits. Note that order of the results
        //     is undefined.
        //
        // 参数:
        //   ray:
        //     The starting point and direction of the ray.
        //
        //   maxDistance:
        //     The max distance the rayhit is allowed to be from the start of the ray.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a ray.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     An array of RaycastHit objects. Note that the order of the results is undefined.
        public static RaycastHit[] RaycastAll(Ray ray, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        [RequiredByNativeCodeAttribute]
        public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static RaycastHit[] RaycastAll(Ray ray);
        [ExcludeFromDocs]
        public static RaycastHit[] RaycastAll(Ray ray, float maxDistance);
        [ExcludeFromDocs]
        public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance);
        //
        // 摘要:
        //     Cast a ray through the Scene and store the hits into the buffer.
        //
        // 参数:
        //   origin:
        //     The starting point and direction of the ray.
        //
        //   results:
        //     The buffer to store the hits into.
        //
        //   direction:
        //     The direction of the ray.
        //
        //   maxDistance:
        //     The max distance the rayhit is allowed to be from the start of the ray.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a ray.
        //
        // 返回结果:
        //     The amount of hits stored into the results buffer.
        public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static int RaycastNonAlloc(Ray ray, RaycastHit[] results);
        [ExcludeFromDocs]
        public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance);
        [ExcludeFromDocs]
        [RequiredByNativeCodeAttribute]
        public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance, int layerMask);
        //
        // 摘要:
        //     Cast a ray through the Scene and store the hits into the buffer.
        //
        // 参数:
        //   ray:
        //     The starting point and direction of the ray.
        //
        //   results:
        //     The buffer to store the hits into.
        //
        //   maxDistance:
        //     The max distance the rayhit is allowed to be from the start of the ray.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a ray.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     The amount of hits stored into the results buffer.
        public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results);
        //
        // 摘要:
        //     Rebuild the broadphase interest regions as well as set the world boundaries.
        //
        // 参数:
        //   worldBounds:
        //     Boundaries of the physics world.
        //
        //   subdivisions:
        //     How many cells to create along x and z axis.
        public static void RebuildBroadphaseRegions(Bounds worldBounds, int subdivisions);
        //
        // 摘要:
        //     Simulate physics in the Scene.
        //
        // 参数:
        //   step:
        //     The time to advance physics by.
        public static void Simulate(float step);
        //
        // 摘要:
        //     Casts a sphere along a ray and returns detailed information on what was hit.
        //
        // 参数:
        //   ray:
        //     The starting point and direction of the ray into which the sphere sweep is cast.
        //
        //   radius:
        //     The radius of the sphere.
        //
        //   maxDistance:
        //     The max length of the cast.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a capsule.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     True when the sphere sweep intersects any collider, otherwise false.
        public static bool SphereCast(Ray ray, float radius, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo);
        [ExcludeFromDocs]
        public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo);
        [ExcludeFromDocs]
        public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance, int layerMask);
        public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static bool SphereCast(Ray ray, float radius);
        [ExcludeFromDocs]
        public static bool SphereCast(Ray ray, float radius, float maxDistance);
        [ExcludeFromDocs]
        public static bool SphereCast(Ray ray, float radius, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance);
        [ExcludeFromDocs]
        public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance);
        [ExcludeFromDocs]
        public static RaycastHit[] SphereCastAll(Ray ray, float radius);
        [ExcludeFromDocs]
        public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance);
        [ExcludeFromDocs]
        public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction);
        //
        // 摘要:
        //     Like Physics.SphereCast, but this function will return all hits the sphere sweep
        //     intersects.
        //
        // 参数:
        //   ray:
        //     The starting point and direction of the ray into which the sphere sweep is cast.
        //
        //   radius:
        //     The radius of the sphere.
        //
        //   maxDistance:
        //     The max length of the sweep.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a sphere.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        public static RaycastHit[] SphereCastAll(Ray ray, float radius, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance);
        //
        // 摘要:
        //     Like Physics.SphereCast, but this function will return all hits the sphere sweep
        //     intersects.
        //
        // 参数:
        //   origin:
        //     The center of the sphere at the start of the sweep.
        //
        //   radius:
        //     The radius of the sphere.
        //
        //   direction:
        //     The direction in which to sweep the sphere.
        //
        //   maxDistance:
        //     The max length of the sweep.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a sphere.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     An array of all colliders hit in the sweep.
        public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask);
        //
        // 摘要:
        //     Cast sphere along the direction and store the results into buffer.
        //
        // 参数:
        //   origin:
        //     The center of the sphere at the start of the sweep.
        //
        //   radius:
        //     The radius of the sphere.
        //
        //   direction:
        //     The direction in which to sweep the sphere.
        //
        //   results:
        //     The buffer to save the hits into.
        //
        //   maxDistance:
        //     The max length of the sweep.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a sphere.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     The amount of hits stored into the results buffer.
        public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results);
        //
        // 摘要:
        //     Cast sphere along the direction and store the results into buffer.
        //
        // 参数:
        //   ray:
        //     The starting point and direction of the ray into which the sphere sweep is cast.
        //
        //   radius:
        //     The radius of the sphere.
        //
        //   results:
        //     The buffer to save the results to.
        //
        //   maxDistance:
        //     The max length of the sweep.
        //
        //   layerMask:
        //     A that is used to selectively ignore colliders when casting a sphere.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     The amount of hits stored into the results buffer.
        public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, float maxDistance, int layerMask);
        [ExcludeFromDocs]
        public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, float maxDistance);
        [ExcludeFromDocs]
        public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results);
        [ExcludeFromDocs]
        public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance);
        //
        // 摘要:
        //     Apply Transform changes to the physics engine.
        public static void SyncTransforms();
    }
}

