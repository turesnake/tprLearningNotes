#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion

using System;
using System.ComponentModel;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Control of an object's position through physics simulation.
    [NativeHeaderAttribute("Modules/Physics/Rigidbody.h")]
    [RequireComponent(typeof(Transform))]
    public class Rigidbody : Component
    {
        public Rigidbody();

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Please use Rigidbody.solverVelocityIterations instead. (UnityUpgradable) -> solverVelocityIterations")]
        // public int solverVelocityIterationCount { get; set; }


        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Please use Rigidbody.solverIterations instead. (UnityUpgradable) -> solverIterations")]
        // public int solverIterationCount { get; set; }


        /*
        摘要:
            The solverVelocityIterations affects how how accurately Rigidbody joints and
            collision contacts are resolved. Overrides Physics.defaultSolverVelocityIterations.
            Must be positive.

            速度迭代次数
        */
        public int solverVelocityIterations { get; set; }

        //
        // 摘要:
        //     The maximimum angular velocity of the rigidbody measured in radians per second.
        //     (Default 7) range { 0, infinity }.
        public float maxAngularVelocity { get; set; }

        /*
        摘要:
            The mass-normalized energy threshold, below which objects start going to sleep.

            质量归一化的 能量阈值, 当能量低于此值时, obj 开始休眠
        
        */
        public float sleepThreshold { get; set; }

        //
        // 摘要:
        //     The solverIterations determines how accurately Rigidbody joints and collision
        //     contacts are resolved. Overrides Physics.defaultSolverIterations. Must be positive.
        public int solverIterations { get; set; }

        /*
            摘要:
                Interpolation allows you to smooth out the effect of running physics at a fixed
                frame rate.

                速度迭代次数
        */
        public RigidbodyInterpolation interpolation { get; set; }


        /*
            The velocity vector of the rigidbody. It represents the rate of change of Rigidbody position.

            In most cases you should not modify the velocity directly, as this can result in unrealistic behaviour - 
            use AddForce() instead Do not set the velocity of an object every physics step, this will lead to unrealistic physics simulation. 

            注意:
                本值位于 world-space;
        
            ==================================
            在每帧 FixedUpdate() 中, 通过直接设置此值, 可直接驱动 rigid 做我们想要的运动; 通常很适合 第一人称第三人称 角色运动;

            FixedUpdate() 先被调用, 然后才执行 物理引擎自己的计算, 此时会发生碰撞, 然后调用 OnCollisionXXX(), 在此cb 内可发现 velocity 等参数以及和 FixedUpdate() 中的不一样了;
            最后才调用 yield return new WaitForFixedUpdate(); 

            所以我们可以先在 FixedUpdate() 中修改速度, 然后等待物理引擎去处理碰撞;

            !! 不要直接改写 rigid 的 position, 这么做 物理引擎是不知道的, 这导致当两帧之间出现 物体过穿时, 物理引擎无法处理这个过穿;
            !! 比较好的就是只修改 velocity, 不修改 position
            !! 若想实现类似 直改 position 的效果, 可以新建一个 tgtTF 节点, 然后 input 会移动这个 tgtTF, 然后 rigid 每帧都快速向 tgtTF 运动; 只要设置的速度足够快, 看起来就是一样的效果;


            注意:
                此值的含义是: XXX m/s; 
                所以, 设置给它的值, 不需要乘以 Time.deltaTime; 
                ---
                但是, 请参考 catlike 中的用法, 它选择 先缓存 上一帧的 velocity, 然后在此基础上 累加本帧的 额外 加速度;
                基于这个思路去实现, 则需要  velocity += a * Time.deltaTime; 

            tpr:
                和 AddForce() 不同, AddForce() 是会考虑 质量mass 因素的; 直接改写本值则完全无视 质量;
        */
        public Vector3 velocity { get; set; }



        /*
            摘要:
            The angular velocity vector of the rigidbody measured in radians per second.
            measured in degrees per second.

            方向表示旋转轴, 模长表示旋转速度;    猜测单位: 角度/秒

        */
        public Vector3 angularVelocity { get; set; }

        /*
            摘要:
                The drag of the object.

            速度阻力
        */
        public float drag { get; set; }
        
        /*
            摘要:
                The angular drag of the object.

            角速度阻力
        */
        public float angularDrag { get; set; }
        
        //
        // 摘要:
        //     The mass of the rigidbody.
        public float mass { get; set; }
        
        //
        // 摘要:
        //     Controls whether gravity affects this rigidbody.
        public bool useGravity { get; set; }
        
        /*
            摘要:
                Maximum velocity of a rigidbody when moving out of penetrating state.

            刚体脱离穿透状态时的 最大速度。
        */
        public float maxDepenetrationVelocity { get; set; }


        /*
            Controls whether physics affects the rigidbody.

            If isKinematic is enabled, Forces, collisions or joints will not affect the rigidbody anymore. 
            The rigidbody will be under full control of animation or script control by changing transform.position. 
            Kinematic bodies also affect the motion of other rigidbodies through collisions or joints. 
            Eg. can connect a kinematic rigidbody to a normal rigidbody with a joint and the rigidbody will be constrained with the motion of the kinematic body. 
            Kinematic rigidbodies are also particularly useful for making characters which are normally driven by an animation, 
            but on certain events can be quickly turned into a ragdoll by setting isKinematic to false.


        */
        public bool isKinematic { get; set; }


        //
        // 摘要:
        //     Controls whether physics will change the rotation of the object.
        public bool freezeRotation { get; set; }

        /*
            摘要:
                Controls which degrees of freedom are allowed for the simulation of this Rigidbody.

            pos, rot 6个轴的锁;
        */
        public RigidbodyConstraints constraints { get; set; }
        
        //
        // 摘要:
        //     The Rigidbody's collision detection mode.
        public CollisionDetectionMode collisionDetectionMode { get; set; }
        
        //
        // 摘要:
        //     The center of mass relative to the transform's origin.
        public Vector3 centerOfMass { get; set; }
        //
        // 摘要:
        //     The center of mass of the rigidbody in world space (Read Only).
        public Vector3 worldCenterOfMass { get; }

        //
        // 摘要:
        //     The rotation of the inertia tensor.   惯性矩的 旋转
        public Quaternion inertiaTensorRotation { get; set; }
        
        /*
            摘要:
                The inertia tensor of this body, defined as a diagonal matrix in a reference
                frame positioned at this body's center of mass and rotated by Rigidbody.inertiaTensorRotation.

                
        */
        public Vector3 inertiaTensor { get; set; }

        /*
            摘要:
                Should collision detection be enabled? (By default always enabled).

                借助它来关闭 碰撞检测
        */
        public bool detectCollisions { get; set; }

        
        // 摘要:
        //     The linear velocity below which objects start going to sleep. (Default 0.14)
        //     range { 0, infinity }.
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("The sleepVelocity is no longer supported. Use sleepThreshold. Note that sleepThreshold is energy but not velocity.", true)]
        // public float sleepVelocity { get; set; }

        
    
        //     The position of the rigidbody.
        public Vector3 position { get; set; }


        //     The rotation of the Rigidbody.
        public Quaternion rotation { get; set; }

        
        // 摘要:
        //     Force cone friction to be used for this rigidbody.
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Cone friction is no longer supported.", true)]
        // public bool useConeFriction { get; set; }

        
        // 摘要:
        //     The angular velocity below which objects start going to sleep. (Default 0.14)
        //     range { 0, infinity }.
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("The sleepAngularVelocity is no longer supported. Use sleepThreshold to specify energy.", true)]
        // public float sleepAngularVelocity { get; set; }

        
        // 摘要:
        //     Applies a force to a rigidbody that simulates explosion effects.
        //
        // 参数:
        //   explosionForce:
        //     The force of the explosion (which may be modified by distance).
        //
        //   explosionPosition:
        //     The centre of the sphere within which the explosion has its effect.
        //
        //   explosionRadius:
        //     The radius of the sphere within which the explosion has its effect.
        //
        //   upwardsModifier:
        //     Adjustment to the apparent position of the explosion to make it seem to lift
        //     objects.
        //
        //   mode:
        //     The method used to apply the force to its targets.
        public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, [Internal.DefaultValue("0.0f")] float upwardsModifier, [Internal.DefaultValue("ForceMode.Force)")] ForceMode mode);
        //
        // 摘要:
        //     Applies a force to a rigidbody that simulates explosion effects.
        //
        // 参数:
        //   explosionForce:
        //     The force of the explosion (which may be modified by distance).
        //
        //   explosionPosition:
        //     The centre of the sphere within which the explosion has its effect.
        //
        //   explosionRadius:
        //     The radius of the sphere within which the explosion has its effect.
        //
        //   upwardsModifier:
        //     Adjustment to the apparent position of the explosion to make it seem to lift
        //     objects.
        //
        //   mode:
        //     The method used to apply the force to its targets.
        [ExcludeFromDocs]
        public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier);
        //
        // 摘要:
        //     Applies a force to a rigidbody that simulates explosion effects.
        //
        // 参数:
        //   explosionForce:
        //     The force of the explosion (which may be modified by distance).
        //
        //   explosionPosition:
        //     The centre of the sphere within which the explosion has its effect.
        //
        //   explosionRadius:
        //     The radius of the sphere within which the explosion has its effect.
        //
        //   upwardsModifier:
        //     Adjustment to the apparent position of the explosion to make it seem to lift
        //     objects.
        //
        //   mode:
        //     The method used to apply the force to its targets.
        [ExcludeFromDocs]
        public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius);

        /*
            Adds a force to the Rigidbody.

            本函数会考虑 质量mass 因素;
            

            参数:
            force:
                Force vector in world coordinates.
            
            x:
                Size of force along the world x-axis.
            
            y:
                Size of force along the world y-axis.
            
            z:
                Size of force along the world z-axis.
            
            mode:
                Type of force to apply.
        */
        public void AddForce(Vector3 force, [Internal.DefaultValue("ForceMode.Force")] ForceMode mode);
        
        [ExcludeFromDocs]
        public void AddForce(Vector3 force);
        
        public void AddForce(float x, float y, float z, [Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

        [ExcludeFromDocs]
        public void AddForce(float x, float y, float z);


        
        // 摘要:
        //     Applies force at position. As a result this will apply a torque and force on
        //     the object.
        //
        // 参数:
        //   force:
        //     Force vector in world coordinates.
        //
        //   position:
        //     Position in world coordinates.
        //
        //   mode:
        //     Type of force to apply.
        public void AddForceAtPosition(Vector3 force, Vector3 position, [Internal.DefaultValue("ForceMode.Force")] ForceMode mode);
        //
        // 摘要:
        //     Applies force at position. As a result this will apply a torque and force on
        //     the object.
        //
        // 参数:
        //   force:
        //     Force vector in world coordinates.
        //
        //   position:
        //     Position in world coordinates.
        //
        //   mode:
        //     Type of force to apply.
        [ExcludeFromDocs]
        public void AddForceAtPosition(Vector3 force, Vector3 position);
        //
        // 摘要:
        //     Adds a force to the rigidbody relative to its coordinate system.
        //
        // 参数:
        //   force:
        //     Force vector in local coordinates.
        //
        //   mode:
        //     Type of force to apply.
        public void AddRelativeForce(Vector3 force, [Internal.DefaultValue("ForceMode.Force")] ForceMode mode);
        //
        // 摘要:
        //     Adds a force to the rigidbody relative to its coordinate system.
        //
        // 参数:
        //   x:
        //     Size of force along the local x-axis.
        //
        //   y:
        //     Size of force along the local y-axis.
        //
        //   z:
        //     Size of force along the local z-axis.
        //
        //   mode:
        //     Type of force to apply.
        [ExcludeFromDocs]
        public void AddRelativeForce(float x, float y, float z);
        //
        // 摘要:
        //     Adds a force to the rigidbody relative to its coordinate system.
        //
        // 参数:
        //   x:
        //     Size of force along the local x-axis.
        //
        //   y:
        //     Size of force along the local y-axis.
        //
        //   z:
        //     Size of force along the local z-axis.
        //
        //   mode:
        //     Type of force to apply.
        public void AddRelativeForce(float x, float y, float z, [Internal.DefaultValue("ForceMode.Force")] ForceMode mode);
        //
        // 摘要:
        //     Adds a force to the rigidbody relative to its coordinate system.
        //
        // 参数:
        //   force:
        //     Force vector in local coordinates.
        //
        //   mode:
        //     Type of force to apply.
        [ExcludeFromDocs]
        public void AddRelativeForce(Vector3 force);
        //
        // 摘要:
        //     Adds a torque to the rigidbody relative to its coordinate system.
        //
        // 参数:
        //   x:
        //     Size of torque along the local x-axis.
        //
        //   y:
        //     Size of torque along the local y-axis.
        //
        //   z:
        //     Size of torque along the local z-axis.
        //
        //   mode:
        //     Type of force to apply.
        [ExcludeFromDocs]
        public void AddRelativeTorque(float x, float y, float z);
        //
        // 摘要:
        //     Adds a torque to the rigidbody relative to its coordinate system.
        //
        // 参数:
        //   torque:
        //     Torque vector in local coordinates.
        //
        //   mode:
        //     Type of force to apply.
        public void AddRelativeTorque(Vector3 torque, [Internal.DefaultValue("ForceMode.Force")] ForceMode mode);
        //
        // 摘要:
        //     Adds a torque to the rigidbody relative to its coordinate system.
        //
        // 参数:
        //   torque:
        //     Torque vector in local coordinates.
        //
        //   mode:
        //     Type of force to apply.
        [ExcludeFromDocs]
        public void AddRelativeTorque(Vector3 torque);
        //
        // 摘要:
        //     Adds a torque to the rigidbody relative to its coordinate system.
        //
        // 参数:
        //   x:
        //     Size of torque along the local x-axis.
        //
        //   y:
        //     Size of torque along the local y-axis.
        //
        //   z:
        //     Size of torque along the local z-axis.
        //
        //   mode:
        //     Type of force to apply.
        public void AddRelativeTorque(float x, float y, float z, [Internal.DefaultValue("ForceMode.Force")] ForceMode mode);
        //
        // 摘要:
        //     Adds a torque to the rigidbody.
        //
        // 参数:
        //   torque:
        //     Torque vector in world coordinates.
        //
        //   mode:
        //     The type of torque to apply.
        [ExcludeFromDocs]
        public void AddTorque(Vector3 torque);
        //
        // 摘要:
        //     Adds a torque to the rigidbody.
        //
        // 参数:
        //   torque:
        //     Torque vector in world coordinates.
        //
        //   mode:
        //     The type of torque to apply.
        public void AddTorque(Vector3 torque, [Internal.DefaultValue("ForceMode.Force")] ForceMode mode);
        //
        // 摘要:
        //     Adds a torque to the rigidbody.
        //
        // 参数:
        //   x:
        //     Size of torque along the world x-axis.
        //
        //   y:
        //     Size of torque along the world y-axis.
        //
        //   z:
        //     Size of torque along the world z-axis.
        //
        //   mode:
        //     The type of torque to apply.
        public void AddTorque(float x, float y, float z, [Internal.DefaultValue("ForceMode.Force")] ForceMode mode);
        //
        // 摘要:
        //     Adds a torque to the rigidbody.
        //
        // 参数:
        //   x:
        //     Size of torque along the world x-axis.
        //
        //   y:
        //     Size of torque along the world y-axis.
        //
        //   z:
        //     Size of torque along the world z-axis.
        //
        //   mode:
        //     The type of torque to apply.
        [ExcludeFromDocs]
        public void AddTorque(float x, float y, float z);
        //
        // 摘要:
        //     The closest point to the bounding box of the attached colliders.
        //
        // 参数:
        //   position:
        public Vector3 ClosestPointOnBounds(Vector3 position);
        //
        // 摘要:
        //     The velocity of the rigidbody at the point worldPoint in global space.
        //
        // 参数:
        //   worldPoint:
        public Vector3 GetPointVelocity(Vector3 worldPoint);
        //
        // 摘要:
        //     The velocity relative to the rigidbody at the point relativePoint.
        //
        // 参数:
        //   relativePoint:
        public Vector3 GetRelativePointVelocity(Vector3 relativePoint);
        //
        // 摘要:
        //     Is the rigidbody sleeping?
        public bool IsSleeping();
        //
        // 摘要:
        //     Moves the kinematic Rigidbody towards position.
        //
        // 参数:
        //   position:
        //     Provides the new position for the Rigidbody object.
        public void MovePosition(Vector3 position);


        /*
            Rotates the rigidbody to rotation.

            使用本函数来旋转 rigidbody, 它将符合 Rigidbody 组件上的 "interpolation" 插值设置选项:

            If Rigidbody interpolation is enabled on the Rigidbody, 
            calling Rigidbody.MoveRotation will resulting in a smooth transition between the two rotations in any intermediate frames rendered. 
            This should be used if you want to continuously rotate a rigidbody in each FixedUpdate.

            Set "Rigidbody.rotation" instead, if you want to teleport a rigidbody from one rotation to another, with no intermediate positions being rendered.

            
            参数:
            rot:
                The new rotation for the Rigidbody.
        */
        public void MoveRotation(Quaternion rot);


        //
        // 摘要:
        //     Reset the center of mass of the rigidbody.
        public void ResetCenterOfMass();
        //
        // 摘要:
        //     Reset the inertia tensor value and rotation.
        public void ResetInertiaTensor();
        //
        // 摘要:
        //     Sets the mass based on the attached colliders assuming a constant density.
        //
        // 参数:
        //   density:
        public void SetDensity(float density);

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Use Rigidbody.maxAngularVelocity instead.")]
        // public void SetMaxAngularVelocity(float a);

        //
        // 摘要:
        //     Forces a rigidbody to sleep at least one frame.
        public void Sleep();
        [ExcludeFromDocs]
        public bool SweepTest(Vector3 direction, out RaycastHit hitInfo);
        public bool SweepTest(Vector3 direction, out RaycastHit hitInfo, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        [ExcludeFromDocs]
        public bool SweepTest(Vector3 direction, out RaycastHit hitInfo, float maxDistance);
        [ExcludeFromDocs]
        public RaycastHit[] SweepTestAll(Vector3 direction);
        [ExcludeFromDocs]
        public RaycastHit[] SweepTestAll(Vector3 direction, float maxDistance);
        //
        // 摘要:
        //     Like Rigidbody.SweepTest, but returns all hits.
        //
        // 参数:
        //   direction:
        //     The direction into which to sweep the rigidbody.
        //
        //   maxDistance:
        //     The length of the sweep.
        //
        //   queryTriggerInteraction:
        //     Specifies whether this query should hit Triggers.
        //
        // 返回结果:
        //     An array of all colliders hit in the sweep.
        public RaycastHit[] SweepTestAll(Vector3 direction, [Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
        //
        // 摘要:
        //     Forces a rigidbody to wake up.
        public void WakeUp();
    }
}

