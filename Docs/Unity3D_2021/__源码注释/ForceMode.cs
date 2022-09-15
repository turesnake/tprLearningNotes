#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion

namespace UnityEngine
{
    
    // 摘要:
    //     Use ForceMode to specify how to apply a force using Rigidbody.AddForce() or ArticulationBody.AddForce()
    public enum ForceMode
    {
        //
        // 摘要:
        //     Add a continuous force to the rigidbody, using its mass.
        Force = 0,
        //
        // 摘要:
        //     Add an instant force impulse to the rigidbody, using its mass.
        Impulse = 1,
        //
        // 摘要:
        //     Add an instant velocity change to the rigidbody, ignoring its mass.
        VelocityChange = 2,
        //
        // 摘要:
        //     Add a continuous acceleration to the rigidbody, ignoring its mass.
        Acceleration = 5
    }
}


