
#region Assembly UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// D:\Unity_1_editors\2021.3.14f1c1\Editor\Data\Managed\UnityEngine\UnityEngine.AnimationModule.dll
#endregion

using UnityEngine.Bindings;

namespace UnityEngine
{
    //
    // Summary:
    //     Use this struct to specify the position and rotation weight mask for Animator.MatchTarget.
    [NativeHeader("Modules/Animation/Animator.h")]
    public struct MatchTargetWeightMask
    {
        //
        // Summary:
        //     MatchTargetWeightMask contructor.
        //
        // Parameters:
        //   positionXYZWeight:
        //     Position XYZ weight.
        //
        //   rotationWeight:
        //     Rotation weight.
        public MatchTargetWeightMask(Vector3 positionXYZWeight, float rotationWeight);

        //
        // Summary:
        //     Position XYZ weight.
        public Vector3 positionXYZWeight { get; set; }
        //
        // Summary:
        //     Rotation weight.
        public float rotationWeight { get; set; }
    }
}