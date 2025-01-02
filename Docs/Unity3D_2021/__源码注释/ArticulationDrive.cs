#region Assembly UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using UnityEngine.Bindings;

namespace UnityEngine;

//
// Summary:
//     Drive applies forces and torques to the connected bodies.
/*
    可以看到, drive 全程只关注一个 float 值的变化;

*/
[NativeHeader("Modules/Physics/ArticulationBody.h")]
public struct ArticulationDrive
{
    //
    // Summary:
    //     The lower limit of motion for a particular degree of freedom.
    public float lowerLimit;

    //
    // Summary:
    //     The upper limit of motion for a particular degree of freedom.
    public float upperLimit;

    /*
    Summary:
        The stiffness of the spring connected to this drive.

        刚度系数, 值越大越有弹性; 比如设置 1000, 会像弹簧一样
    */
    public float stiffness;

    /*
    Summary:
        The damping of the spring attached to this drive.

        阻尼,
    */
    public float damping;

    //
    // Summary:
    //     The maximum force this drive can apply to a body.
    public float forceLimit;

    //
    // Summary:
    //     The target value the drive will try to reach.
    public float target;

    //
    // Summary:
    //     The velocity of the body this drive will try to reach.
    public float targetVelocity;
}



