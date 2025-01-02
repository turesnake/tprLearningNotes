#region Assembly UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Describes a contact point where the collision occurs.
[NativeHeader("Modules/Physics/MessageParameters.h")]
[UsedByNativeCode]
public struct ContactPoint
{
    internal Vector3 m_Point;

    internal Vector3 m_Normal;

    internal int m_ThisColliderInstanceID;

    internal int m_OtherColliderInstanceID;

    internal float m_Separation;

    //
    // Summary:
    //     The point of contact.
    public Vector3 point => m_Point;

    //
    // Summary:
    //     Normal of the contact point.
    public Vector3 normal => m_Normal;

    //
    // Summary:
    //     The first collider in contact at the point.
    public Collider thisCollider => GetColliderByInstanceID(m_ThisColliderInstanceID);

    //
    // Summary:
    //     The other collider in contact at the point.
    public Collider otherCollider => GetColliderByInstanceID(m_OtherColliderInstanceID);

    //
    // Summary:
    //     The distance between the colliders at the contact point.
    public float separation => m_Separation;

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    private static extern Collider GetColliderByInstanceID(int instanceID);
}

