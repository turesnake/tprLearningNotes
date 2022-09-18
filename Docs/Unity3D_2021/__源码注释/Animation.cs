
#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion

using System;
using System.Collections;
using System.Reflection;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     The animation component is used to play back animations.
    [DefaultMember("Item")]
    [NativeHeaderAttribute("Modules/Animation/Animation.h")]
    public sealed class Animation : Behaviour, IEnumerable
    {
        public Animation();

        public AnimationState this[string name] { get; }

        //
        // 摘要:
        //     AABB of this Animation animation component in local space.
        public Bounds localBounds { get; set; }
        //
        // 摘要:
        //     Should the default animation clip (the Animation.clip property) automatically
        //     start playing on startup?
        public bool playAutomatically { get; set; }
        //
        // 摘要:
        //     Controls culling of this Animation component.
        public AnimationCullingType cullingType { get; set; }
        //
        // 摘要:
        //     The default animation.
        public AnimationClip clip { get; set; }
        //
        // 摘要:
        //     How should time beyond the playback range of the clip be treated?
        public WrapMode wrapMode { get; set; }
        //
        // 摘要:
        //     When turned on, animations will be executed in the physics loop. This is only
        //     useful in conjunction with kinematic rigidbodies.
        public bool animatePhysics { get; set; }
        //
        // 摘要:
        //     When turned on, Unity might stop animating if it thinks that the results of the
        //     animation won't be visible to the user.
        [Obsolete("Use cullingType instead")]
        public bool animateOnlyIfVisible { get; set; }
        //
        // 摘要:
        //     Is an animation currently being played?
        public bool isPlaying { get; }

        //
        // 摘要:
        //     Adds clip to the only play between firstFrame and lastFrame. The new clip will
        //     also be added to the animation with name newName.
        //
        // 参数:
        //   addLoopFrame:
        //     Should an extra frame be inserted at the end that matches the first frame? Turn
        //     this on if you are making a looping animation.
        //
        //   clip:
        //
        //   newName:
        //
        //   firstFrame:
        //
        //   lastFrame:
        public void AddClip([NotNullAttribute("NullExceptionObject")] AnimationClip clip, string newName, int firstFrame, int lastFrame, [DefaultValue("false")] bool addLoopFrame);
        //
        // 摘要:
        //     Adds clip to the only play between firstFrame and lastFrame. The new clip will
        //     also be added to the animation with name newName.
        //
        // 参数:
        //   addLoopFrame:
        //     Should an extra frame be inserted at the end that matches the first frame? Turn
        //     this on if you are making a looping animation.
        //
        //   clip:
        //
        //   newName:
        //
        //   firstFrame:
        //
        //   lastFrame:
        [ExcludeFromDocs]
        public void AddClip(AnimationClip clip, string newName, int firstFrame, int lastFrame);
        //
        // 摘要:
        //     Adds a clip to the animation with name newName.
        //
        // 参数:
        //   clip:
        //
        //   newName:
        public void AddClip(AnimationClip clip, string newName);
        //
        // 摘要:
        //     Blends the animation named animation towards targetWeight over the next time
        //     seconds.
        //
        // 参数:
        //   animation:
        //
        //   targetWeight:
        //
        //   fadeLength:
        [ExcludeFromDocs]
        public void Blend(string animation);
        //
        // 摘要:
        //     Blends the animation named animation towards targetWeight over the next time
        //     seconds.
        //
        // 参数:
        //   animation:
        //
        //   targetWeight:
        //
        //   fadeLength:
        [ExcludeFromDocs]
        public void Blend(string animation, float targetWeight);
        //
        // 摘要:
        //     Blends the animation named animation towards targetWeight over the next time
        //     seconds.
        //
        // 参数:
        //   animation:
        //
        //   targetWeight:
        //
        //   fadeLength:
        public void Blend(string animation, [DefaultValue("1.0F")] float targetWeight, [DefaultValue("0.3F")] float fadeLength);
        //
        // 摘要:
        //     Fades the animation with name animation in over a period of time seconds and
        //     fades other animations out.
        //
        // 参数:
        //   animation:
        //
        //   fadeLength:
        //
        //   mode:
        [ExcludeFromDocs]
        public void CrossFade(string animation);
        //
        // 摘要:
        //     Fades the animation with name animation in over a period of time seconds and
        //     fades other animations out.
        //
        // 参数:
        //   animation:
        //
        //   fadeLength:
        //
        //   mode:
        [ExcludeFromDocs]
        public void CrossFade(string animation, float fadeLength);
        //
        // 摘要:
        //     Fades the animation with name animation in over a period of time seconds and
        //     fades other animations out.
        //
        // 参数:
        //   animation:
        //
        //   fadeLength:
        //
        //   mode:
        public void CrossFade(string animation, [DefaultValue("0.3F")] float fadeLength, [DefaultValue("PlayMode.StopSameLayer")] PlayMode mode);
        //
        // 摘要:
        //     Cross fades an animation after previous animations has finished playing.
        //
        // 参数:
        //   animation:
        //
        //   fadeLength:
        //
        //   queue:
        //
        //   mode:
        [ExcludeFromDocs]
        public AnimationState CrossFadeQueued(string animation);
        //
        // 摘要:
        //     Cross fades an animation after previous animations has finished playing.
        //
        // 参数:
        //   animation:
        //
        //   fadeLength:
        //
        //   queue:
        //
        //   mode:
        [ExcludeFromDocs]
        public AnimationState CrossFadeQueued(string animation, float fadeLength, QueueMode queue);
        //
        // 摘要:
        //     Cross fades an animation after previous animations has finished playing.
        //
        // 参数:
        //   animation:
        //
        //   fadeLength:
        //
        //   queue:
        //
        //   mode:
        [ExcludeFromDocs]
        public AnimationState CrossFadeQueued(string animation, float fadeLength);
        //
        // 摘要:
        //     Cross fades an animation after previous animations has finished playing.
        //
        // 参数:
        //   animation:
        //
        //   fadeLength:
        //
        //   queue:
        //
        //   mode:
        [FreeFunctionAttribute("AnimationBindings::CrossFadeQueuedImpl", HasExplicitThis = true)]
        public AnimationState CrossFadeQueued(string animation, [DefaultValue("0.3F")] float fadeLength, [DefaultValue("QueueMode.CompleteOthers")] QueueMode queue, [DefaultValue("PlayMode.StopSameLayer")] PlayMode mode);
        public AnimationClip GetClip(string name);
        //
        // 摘要:
        //     Get the number of clips currently assigned to this animation.
        public int GetClipCount();
        public IEnumerator GetEnumerator();
        //
        // 摘要:
        //     Is the animation named name playing?
        //
        // 参数:
        //   name:
        public bool IsPlaying(string name);
        //
        // 摘要:
        //     Plays an animation without blending.
        //
        // 参数:
        //   mode:
        //
        //   animation:
        public bool Play(string animation, [DefaultValue("PlayMode.StopSameLayer")] PlayMode mode);
        //
        // 摘要:
        //     Plays an animation without blending.
        //
        // 参数:
        //   mode:
        //
        //   animation:
        [ExcludeFromDocs]
        public bool Play(string animation);
        //
        // 摘要:
        //     Plays an animation without blending.
        //
        // 参数:
        //   mode:
        //
        //   animation:
        public bool Play([DefaultValue("PlayMode.StopSameLayer")] PlayMode mode);
        [ExcludeFromDocs]
        public bool Play();
        [Obsolete("use PlayMode instead of AnimationPlayMode.")]
        public bool Play(AnimationPlayMode mode);
        [Obsolete("use PlayMode instead of AnimationPlayMode.")]
        public bool Play(string animation, AnimationPlayMode mode);
        //
        // 摘要:
        //     Plays an animation after previous animations has finished playing.
        //
        // 参数:
        //   animation:
        //
        //   queue:
        //
        //   mode:
        [ExcludeFromDocs]
        public AnimationState PlayQueued(string animation, QueueMode queue);
        //
        // 摘要:
        //     Plays an animation after previous animations has finished playing.
        //
        // 参数:
        //   animation:
        //
        //   queue:
        //
        //   mode:
        [FreeFunctionAttribute("AnimationBindings::PlayQueuedImpl", HasExplicitThis = true)]
        public AnimationState PlayQueued(string animation, [DefaultValue("QueueMode.CompleteOthers")] QueueMode queue, [DefaultValue("PlayMode.StopSameLayer")] PlayMode mode);
        //
        // 摘要:
        //     Plays an animation after previous animations has finished playing.
        //
        // 参数:
        //   animation:
        //
        //   queue:
        //
        //   mode:
        [ExcludeFromDocs]
        public AnimationState PlayQueued(string animation);
        //
        // 摘要:
        //     Remove clip from the animation list.
        //
        // 参数:
        //   clipName:
        public void RemoveClip(string clipName);
        //
        // 摘要:
        //     Remove clip from the animation list.
        //
        // 参数:
        //   clip:
        public void RemoveClip([NotNullAttribute("NullExceptionObject")] AnimationClip clip);
        //
        // 摘要:
        //     Rewinds the animation named name.
        //
        // 参数:
        //   name:
        public void Rewind(string name);
        //
        // 摘要:
        //     Rewinds all animations.
        public void Rewind();
        //
        // 摘要:
        //     Samples animations at the current state.
        public void Sample();
        //
        // 摘要:
        //     Stops an animation named name.
        //
        // 参数:
        //   name:
        public void Stop(string name);
        //
        // 摘要:
        //     Stops all playing animations that were started with this Animation.
        public void Stop();
        public void SyncLayer(int layer);
    }
}