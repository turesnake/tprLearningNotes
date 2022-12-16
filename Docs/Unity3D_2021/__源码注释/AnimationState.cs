
#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion

using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     The AnimationState gives full control over animation blending.
    [NativeHeaderAttribute("Modules/Animation/AnimationState.h")]
    [UsedByNativeCodeAttribute]
    public sealed class AnimationState : TrackedReference
    {
        public AnimationState();

        //
        // 摘要:
        //     Enables / disables the animation.
        public bool enabled { get; set; }
        //
        // 摘要:
        //     The weight of animation.
        public float weight { get; set; }
        //
        // 摘要:
        //     Wrapping mode of the animation.
        public WrapMode wrapMode { get; set; }
        //
        // 摘要:
        //     The current time of the animation.
        public float time { get; set; }
        //
        // 摘要:
        //     The normalized time of the animation.
        public float normalizedTime { get; set; }
        //
        // 摘要:
        //     The playback speed of the animation. 1 is normal playback speed.
        public float speed { get; set; }
        //
        // 摘要:
        //     The normalized playback speed.
        public float normalizedSpeed { get; set; }
        //
        // 摘要:
        //     The length of the animation clip in seconds.
        public float length { get; }
        public int layer { get; set; }
        //
        // 摘要:
        //     The clip that is being played by this animation state.
        public AnimationClip clip { get; }
        //
        // 摘要:
        //     The name of the animation.
        public string name { get; set; }
        //
        // 摘要:
        //     Which blend mode should be used?
        public AnimationBlendMode blendMode { get; set; }

        //
        // 摘要:
        //     Adds a transform which should be animated. This allows you to reduce the number
        //     of animations you have to create.
        //
        // 参数:
        //   mix:
        //     The transform to animate.
        //
        //   recursive:
        //     Whether to also animate all children of the specified transform.
        [ExcludeFromDocs]
        public void AddMixingTransform(Transform mix);
        //
        // 摘要:
        //     Adds a transform which should be animated. This allows you to reduce the number
        //     of animations you have to create.
        //
        // 参数:
        //   mix:
        //     The transform to animate.
        //
        //   recursive:
        //     Whether to also animate all children of the specified transform.
        public void AddMixingTransform([NotNullAttribute("NullExceptionObject")] Transform mix, [DefaultValue("true")] bool recursive);
        //
        // 摘要:
        //     Removes a transform which should be animated.
        //
        // 参数:
        //   mix:
        public void RemoveMixingTransform([NotNullAttribute("NullExceptionObject")] Transform mix);
    }
}