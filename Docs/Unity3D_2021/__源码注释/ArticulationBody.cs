#region Assembly UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

/*
    Summary:
        A body that forms part of a Physics articulation.

    如何在代码中修改一个轴的值:

        public ArticulationBody ab;
        ArticulationDrive drive = ab.yDrive;
        drive.target = 0.3f;
        ab.yDrive = drive;

    然后把这个 drive 的 stifness 调到 100000, 就行了

*/
[NativeHeader("Modules/Physics/ArticulationBody.h")]
[NativeClass("Unity::ArticulationBody")]
public class ArticulationBody : Behaviour
{
    //
    // Summary:
    //     The type of joint connecting this body to its parent body.
    public extern ArticulationJointType jointType
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Position of the anchor relative to this body.
    public Vector3 anchorPosition
    {
        get
        {
            get_anchorPosition_Injected(out var ret);
            return ret;
        }
        set
        {
            set_anchorPosition_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Position of the anchor relative to this body's parent.
    public Vector3 parentAnchorPosition
    {
        get
        {
            get_parentAnchorPosition_Injected(out var ret);
            return ret;
        }
        set
        {
            set_parentAnchorPosition_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Rotation of the anchor relative to this body.
    public Quaternion anchorRotation
    {
        get
        {
            get_anchorRotation_Injected(out var ret);
            return ret;
        }
        set
        {
            set_anchorRotation_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Rotation of the anchor relative to this body's parent.
    public Quaternion parentAnchorRotation
    {
        get
        {
            get_parentAnchorRotation_Injected(out var ret);
            return ret;
        }
        set
        {
            set_parentAnchorRotation_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Indicates whether this body is the root body of the articulation (Read Only).
    public extern bool isRoot
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    [Obsolete("computeParentAnchor has been renamed to matchAnchors (UnityUpgradable) -> matchAnchors")]
    public bool computeParentAnchor
    {
        get
        {
            return matchAnchors;
        }
        set
        {
            matchAnchors = value;
        }
    }

    //
    // Summary:
    //     Whether the parent anchor should be computed automatically or not.
    public extern bool matchAnchors
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The type of lock along X axis of movement.
    public extern ArticulationDofLock linearLockX
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The type of lock along Y axis of movement.
    public extern ArticulationDofLock linearLockY
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The type of lock along Z axis of movement.
    public extern ArticulationDofLock linearLockZ
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The magnitude of the conical swing angle relative to Y axis.
    public extern ArticulationDofLock swingYLock
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The magnitude of the conical swing angle relative to Z axis.
    public extern ArticulationDofLock swingZLock
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The type of lock for twist movement.
    public extern ArticulationDofLock twistLock
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The properties of drive along or around X.
    public ArticulationDrive xDrive
    {
        get
        {
            get_xDrive_Injected(out var ret);
            return ret;
        }
        set
        {
            set_xDrive_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The properties of drive along or around Y.
    public ArticulationDrive yDrive
    {
        get
        {
            get_yDrive_Injected(out var ret);
            return ret;
        }
        set
        {
            set_yDrive_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The properties of drive along or around Z.
    public ArticulationDrive zDrive
    {
        get
        {
            get_zDrive_Injected(out var ret);
            return ret;
        }
        set
        {
            set_zDrive_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Allows you to specify that this body is not movable.
    public extern bool immovable
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Controls whether gravity affects this articulation body.
    public extern bool useGravity
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Damping factor that affects how this body resists linear motion.
    public extern float linearDamping
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Damping factor that affects how this body resists rotations.
    public extern float angularDamping
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Allows you to specify the amount of friction that is applied as a result of the
    //     parent body moving relative to this body.
    public extern float jointFriction
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Linear velocity of the body defined in world space.
    public Vector3 velocity
    {
        get
        {
            get_velocity_Injected(out var ret);
            return ret;
        }
        set
        {
            set_velocity_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The angular velocity of the body defined in world space.
    public Vector3 angularVelocity
    {
        get
        {
            get_angularVelocity_Injected(out var ret);
            return ret;
        }
        set
        {
            set_angularVelocity_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The mass of this articulation body.
    public extern float mass
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The center of mass of the body defined in local space.
    public Vector3 centerOfMass
    {
        get
        {
            get_centerOfMass_Injected(out var ret);
            return ret;
        }
        set
        {
            set_centerOfMass_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The center of mass of the body defined in world space (Read Only).
    public Vector3 worldCenterOfMass
    {
        get
        {
            get_worldCenterOfMass_Injected(out var ret);
            return ret;
        }
    }

    //
    // Summary:
    //     The inertia tensor of this body.
    public Vector3 inertiaTensor
    {
        get
        {
            get_inertiaTensor_Injected(out var ret);
            return ret;
        }
        set
        {
            set_inertiaTensor_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The rotation of the inertia tensor.
    public Quaternion inertiaTensorRotation
    {
        get
        {
            get_inertiaTensorRotation_Injected(out var ret);
            return ret;
        }
        set
        {
            set_inertiaTensorRotation_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The mass-normalized energy threshold, below which objects start going to sleep.
    public extern float sleepThreshold
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The solverIterations determines how accurately articulation body joints and collision
    //     contacts are resolved.
    public extern int solverIterations
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The solverVelocityIterations affects how accurately articulation body joints
    //     and collision contacts are resolved during bounce.
    public extern int solverVelocityIterations
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The maximimum angular velocity of the articulation body measured in radians per
    //     second.
    public extern float maxAngularVelocity
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The maximum linear velocity of the articulation body measured in meters per second.
    public extern float maxLinearVelocity
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The maximum joint velocity of the articulation body joint in reduced coordinates.
    public extern float maxJointVelocity
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The maximum velocity of an articulation body when moving out of penetrating state.
    public extern float maxDepenetrationVelocity
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The joint position in reduced coordinates.
    public ArticulationReducedSpace jointPosition
    {
        get
        {
            get_jointPosition_Injected(out var ret);
            return ret;
        }
        set
        {
            set_jointPosition_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The joint velocity in reduced coordinates.
    public ArticulationReducedSpace jointVelocity
    {
        get
        {
            get_jointVelocity_Injected(out var ret);
            return ret;
        }
        set
        {
            set_jointVelocity_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The joint acceleration in reduced coordinates.
    public ArticulationReducedSpace jointAcceleration
    {
        get
        {
            get_jointAcceleration_Injected(out var ret);
            return ret;
        }
        set
        {
            set_jointAcceleration_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The joint force in reduced coordinates.
    public ArticulationReducedSpace jointForce
    {
        get
        {
            get_jointForce_Injected(out var ret);
            return ret;
        }
        set
        {
            set_jointForce_Injected(ref value);
        }
    }

    //
    // Summary:
    //     The amount of degrees of freedom of a body.
    public extern int dofCount
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     The index of the body in the hierarchy of articulation bodies.
    public extern int index
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetBodyIndex")]
        get;
    }

    //
    // Summary:
    //     The ArticulationBody's collision detection mode.
    public extern CollisionDetectionMode collisionDetectionMode
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Applies a force to the ArticulationBody.
    //
    // Parameters:
    //   force:
    //     The force vector to apply.
    //
    //   mode:
    //     The type of force to apply.
    public void AddForce(Vector3 force, [DefaultValue("ForceMode.Force")] ForceMode mode)
    {
        AddForce_Injected(ref force, mode);
    }

    //
    // Summary:
    //     Applies a force to the ArticulationBody.
    //
    // Parameters:
    //   force:
    //     The force vector to apply.
    //
    //   mode:
    //     The type of force to apply.
    [ExcludeFromDocs]
    public void AddForce(Vector3 force)
    {
        AddForce(force, ForceMode.Force);
    }

    //
    // Summary:
    //     Applies a force to the Articulation Body, relative to its local coordinate system.
    //
    //
    // Parameters:
    //   force:
    //     The force vector in local coordinates.
    //
    //   mode:
    //     The type of force to apply.
    public void AddRelativeForce(Vector3 force, [DefaultValue("ForceMode.Force")] ForceMode mode)
    {
        AddRelativeForce_Injected(ref force, mode);
    }

    //
    // Summary:
    //     Applies a force to the Articulation Body, relative to its local coordinate system.
    //
    //
    // Parameters:
    //   force:
    //     The force vector in local coordinates.
    //
    //   mode:
    //     The type of force to apply.
    [ExcludeFromDocs]
    public void AddRelativeForce(Vector3 force)
    {
        AddRelativeForce(force, ForceMode.Force);
    }

    //
    // Summary:
    //     Add torque to the articulation body.
    //
    // Parameters:
    //   torque:
    //     The torque to apply.
    //
    //   mode:
    //     The type of torque to apply.
    public void AddTorque(Vector3 torque, [DefaultValue("ForceMode.Force")] ForceMode mode)
    {
        AddTorque_Injected(ref torque, mode);
    }

    //
    // Summary:
    //     Add torque to the articulation body.
    //
    // Parameters:
    //   torque:
    //     The torque to apply.
    //
    //   mode:
    //     The type of torque to apply.
    [ExcludeFromDocs]
    public void AddTorque(Vector3 torque)
    {
        AddTorque(torque, ForceMode.Force);
    }

    //
    // Summary:
    //     Applies a torque to the articulation body, relative to its local coordinate system.
    //
    //
    // Parameters:
    //   torque:
    //     The torque vector in local coordinates.
    //
    //   mode:
    //     The type of torque to apply.
    public void AddRelativeTorque(Vector3 torque, [DefaultValue("ForceMode.Force")] ForceMode mode)
    {
        AddRelativeTorque_Injected(ref torque, mode);
    }

    //
    // Summary:
    //     Applies a torque to the articulation body, relative to its local coordinate system.
    //
    //
    // Parameters:
    //   torque:
    //     The torque vector in local coordinates.
    //
    //   mode:
    //     The type of torque to apply.
    [ExcludeFromDocs]
    public void AddRelativeTorque(Vector3 torque)
    {
        AddRelativeTorque(torque, ForceMode.Force);
    }

    //
    // Summary:
    //     Applies a force at a specific position, resulting in applying a torque and force
    //     on the object.
    //
    // Parameters:
    //   force:
    //     The force vector in world coordinates.
    //
    //   position:
    //     A position in world coordinates.
    //
    //   mode:
    //     The type of force to apply.
    public void AddForceAtPosition(Vector3 force, Vector3 position, [DefaultValue("ForceMode.Force")] ForceMode mode)
    {
        AddForceAtPosition_Injected(ref force, ref position, mode);
    }

    //
    // Summary:
    //     Applies a force at a specific position, resulting in applying a torque and force
    //     on the object.
    //
    // Parameters:
    //   force:
    //     The force vector in world coordinates.
    //
    //   position:
    //     A position in world coordinates.
    //
    //   mode:
    //     The type of force to apply.
    [ExcludeFromDocs]
    public void AddForceAtPosition(Vector3 force, Vector3 position)
    {
        AddForceAtPosition(force, position, ForceMode.Force);
    }

    //
    // Summary:
    //     Resets the center of mass of the articulation body.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void ResetCenterOfMass();

    //
    // Summary:
    //     Resets the inertia tensor value and rotation.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void ResetInertiaTensor();

    //
    // Summary:
    //     Forces an articulation body to sleep.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Sleep();

    //
    // Summary:
    //     Indicates whether the articulation body is sleeping.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool IsSleeping();

    //
    // Summary:
    //     Forces an articulation body to wake up.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void WakeUp();

    //
    // Summary:
    //     Teleport the root body of the articulation to a new pose.
    //
    // Parameters:
    //   position:
    //     The new position of the root articulation body.
    //
    //   rotation:
    //     The new orientation of the root articulation body.
    public void TeleportRoot(Vector3 position, Quaternion rotation)
    {
        TeleportRoot_Injected(ref position, ref rotation);
    }

    //
    // Summary:
    //     Return the point on the articulation body that is closest to a given one.
    //
    // Parameters:
    //   point:
    //     The point of interest.
    //
    // Returns:
    //     The point on the surfaces of all Colliders attached to this articulation body
    //     that is closest to the given one.
    public Vector3 GetClosestPoint(Vector3 point)
    {
        GetClosestPoint_Injected(ref point, out var ret);
        return ret;
    }

    //
    // Summary:
    //     The velocity relative to the articulation body at the point relativePoint.
    //
    // Parameters:
    //   relativePoint:
    public Vector3 GetRelativePointVelocity(Vector3 relativePoint)
    {
        GetRelativePointVelocity_Injected(ref relativePoint, out var ret);
        return ret;
    }

    //
    // Summary:
    //     Gets the velocity of the articulation body at the specified worldPoint in global
    //     space.
    //
    // Parameters:
    //   worldPoint:
    public Vector3 GetPointVelocity(Vector3 worldPoint)
    {
        GetPointVelocity_Injected(ref worldPoint, out var ret);
        return ret;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetDenseJacobian(ref ArticulationJacobian jacobian);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetJointPositions(List<float> positions);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetJointPositions(List<float> positions);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetJointVelocities(List<float> velocities);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetJointVelocities(List<float> velocities);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetJointAccelerations(List<float> accelerations);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetJointAccelerations(List<float> accelerations);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetJointForces(List<float> forces);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetJointForces(List<float> forces);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetDriveTargets(List<float> targets);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetDriveTargets(List<float> targets);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetDriveTargetVelocities(List<float> targetVelocities);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetDriveTargetVelocities(List<float> targetVelocities);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetDofStartIndices(List<int> dofStartIndices);

    //
    // Summary:
    //     Snap the anchor to the closest contact between the connected bodies.
    public void SnapAnchorToClosestContact()
    {
        if ((bool)base.transform.parent)
        {
            ArticulationBody componentInParent = base.transform.parent.GetComponentInParent<ArticulationBody>();
            while ((bool)componentInParent && !componentInParent.enabled)
            {
                componentInParent = componentInParent.transform.parent.GetComponentInParent<ArticulationBody>();
            }

            if ((bool)componentInParent)
            {
                Vector3 vector = componentInParent.worldCenterOfMass;
                Vector3 closestPoint = GetClosestPoint(vector);
                anchorPosition = base.transform.InverseTransformPoint(closestPoint);
                anchorRotation = Quaternion.FromToRotation(Vector3.right, base.transform.InverseTransformDirection(vector - closestPoint).normalized);
            }
        }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_anchorPosition_Injected(out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_anchorPosition_Injected(ref Vector3 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_parentAnchorPosition_Injected(out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_parentAnchorPosition_Injected(ref Vector3 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_anchorRotation_Injected(out Quaternion ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_anchorRotation_Injected(ref Quaternion value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_parentAnchorRotation_Injected(out Quaternion ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_parentAnchorRotation_Injected(ref Quaternion value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_xDrive_Injected(out ArticulationDrive ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_xDrive_Injected(ref ArticulationDrive value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_yDrive_Injected(out ArticulationDrive ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_yDrive_Injected(ref ArticulationDrive value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_zDrive_Injected(out ArticulationDrive ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_zDrive_Injected(ref ArticulationDrive value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void AddForce_Injected(ref Vector3 force, [DefaultValue("ForceMode.Force")] ForceMode mode);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void AddRelativeForce_Injected(ref Vector3 force, [DefaultValue("ForceMode.Force")] ForceMode mode);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void AddTorque_Injected(ref Vector3 torque, [DefaultValue("ForceMode.Force")] ForceMode mode);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void AddRelativeTorque_Injected(ref Vector3 torque, [DefaultValue("ForceMode.Force")] ForceMode mode);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void AddForceAtPosition_Injected(ref Vector3 force, ref Vector3 position, [DefaultValue("ForceMode.Force")] ForceMode mode);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_velocity_Injected(out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_velocity_Injected(ref Vector3 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_angularVelocity_Injected(out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_angularVelocity_Injected(ref Vector3 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_centerOfMass_Injected(out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_centerOfMass_Injected(ref Vector3 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_worldCenterOfMass_Injected(out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_inertiaTensor_Injected(out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_inertiaTensor_Injected(ref Vector3 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_inertiaTensorRotation_Injected(out Quaternion ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_inertiaTensorRotation_Injected(ref Quaternion value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_jointPosition_Injected(out ArticulationReducedSpace ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_jointPosition_Injected(ref ArticulationReducedSpace value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_jointVelocity_Injected(out ArticulationReducedSpace ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_jointVelocity_Injected(ref ArticulationReducedSpace value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_jointAcceleration_Injected(out ArticulationReducedSpace ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_jointAcceleration_Injected(ref ArticulationReducedSpace value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_jointForce_Injected(out ArticulationReducedSpace ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_jointForce_Injected(ref ArticulationReducedSpace value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void TeleportRoot_Injected(ref Vector3 position, ref Quaternion rotation);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetClosestPoint_Injected(ref Vector3 point, out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetRelativePointVelocity_Injected(ref Vector3 relativePoint, out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetPointVelocity_Injected(ref Vector3 worldPoint, out Vector3 ret);
}

