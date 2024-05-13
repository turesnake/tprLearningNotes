#region Assembly UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

namespace UnityEngine;

//
// Summary:
//     Use these flags to constrain motion of Rigidbodies.
public enum RigidbodyConstraints
{
    //
    // Summary:
    //     No constraints.
    None = 0,
    //
    // Summary:
    //     Freeze motion along the X-axis.
    FreezePositionX = 2,
    //
    // Summary:
    //     Freeze motion along the Y-axis.
    FreezePositionY = 4,
    //
    // Summary:
    //     Freeze motion along the Z-axis.
    FreezePositionZ = 8,
    //
    // Summary:
    //     Freeze rotation along the X-axis.
    FreezeRotationX = 16,
    //
    // Summary:
    //     Freeze rotation along the Y-axis.
    FreezeRotationY = 32,
    //
    // Summary:
    //     Freeze rotation along the Z-axis.
    FreezeRotationZ = 64,
    //
    // Summary:
    //     Freeze motion along all axes.
    FreezePosition = 14,
    //
    // Summary:
    //     Freeze rotation along all axes.
    FreezeRotation = 112,
    //
    // Summary:
    //     Freeze rotation and motion along all axes.
    FreezeAll = 126
}

