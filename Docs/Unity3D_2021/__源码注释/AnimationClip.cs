#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion

using System;

namespace UnityEngine
{
    //
    // 摘要:
    //     Stores keyframe based animations.
    [NativeHeaderAttribute("Modules/Animation/ScriptBindings/AnimationClip.bindings.h")]
    [NativeTypeAttribute("Modules/Animation/AnimationClip.h")]
    public sealed class AnimationClip : Motion
    {
        //
        // 摘要:
        //     Creates a new animation clip.
        public AnimationClip();

        //
        // 摘要:
        //     Returns true if the AnimationClip has root motion curves.
        public bool hasMotionCurves { get; }
        //
        // 摘要:
        //     Returns true if the AnimationClip has editor curves for its root motion.
        public bool hasMotionFloatCurves { get; }
        //
        // 摘要:
        //     Returns true if the Animation has animation on the root transform.
        public bool hasGenericRootTransform { get; }
        //
        // 摘要:
        //     Returns true if the animation clip has no curves and no events.
        public bool empty { get; }
        //
        // 摘要:
        //     Returns true if the animation contains curve that drives a humanoid rig.
        public bool humanMotion { get; }
        //
        // 摘要:
        //     Set to true if the AnimationClip will be used with the Legacy Animation component
        //     ( instead of the Animator ).
        public bool legacy { get; set; }
        //
        // 摘要:
        //     AABB of this Animation Clip in local space of Animation component that it is
        //     attached too.
        [NativePropertyAttribute("Bounds", false, Bindings.TargetType.Function)]
        public Bounds localBounds { get; set; }
        //
        // 摘要:
        //     Sets the default wrap mode used in the animation state.
        [NativePropertyAttribute("WrapMode", false, Bindings.TargetType.Function)]
        public WrapMode wrapMode { get; set; }
        //
        // 摘要:
        //     Frame rate at which keyframes are sampled. (Read Only)
        [NativePropertyAttribute("SampleRate", false, Bindings.TargetType.Function)]
        public float frameRate { get; set; }
        //
        // 摘要:
        //     Animation length in seconds. (Read Only)
        [NativePropertyAttribute("Length", false, Bindings.TargetType.Function)]
        public float length { get; }
        //
        // 摘要:
        //     Returns true if the AnimationClip has root Curves.
        public bool hasRootCurves { get; }
        //
        // 摘要:
        //     Animation Events for this animation clip.
        public AnimationEvent[] events { get; set; }

        //
        // 摘要:
        //     Adds an animation event to the clip.
        //
        // 参数:
        //   evt:
        //     AnimationEvent to add.
        public void AddEvent(AnimationEvent evt);
        //
        // 摘要:
        //     Clears all curves from the clip.
        public void ClearCurves();
        //
        // 摘要:
        //     Realigns quaternion keys to ensure shortest interpolation paths.
        public void EnsureQuaternionContinuity();
        //
        // 摘要:
        //     Samples an animation at a given time for any animated properties.
        //
        // 参数:
        //   go:
        //     The animated game object.
        //
        //   time:
        //     The time to sample an animation.
        public void SampleAnimation(GameObject go, float time);
        //
        // 摘要:
        //     Assigns the curve to animate a specific property.
        //
        // 参数:
        //   relativePath:
        //     Path to the game object this curve applies to. The relativePath is formatted
        //     similar to a pathname, e.g. "rootspineleftArm". If relativePath is empty it refers
        //     to the game object the animation clip is attached to.
        //
        //   type:
        //     The class type of the component that is animated.
        //
        //   propertyName:
        //     The name or path to the property being animated.
        //
        //   curve:
        //     The animation curve.
        [FreeFunctionAttribute("AnimationClipBindings::Internal_SetCurve", HasExplicitThis = true)]
        public void SetCurve([NotNullAttribute("ArgumentNullException")] string relativePath, [NotNullAttribute("ArgumentNullException")] Type type, [NotNullAttribute("ArgumentNullException")] string propertyName, AnimationCurve curve);
    }
}