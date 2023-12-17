#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        Information about the current or next state.


    */
    [NativeHeaderAttribute("Modules/Animation/AnimatorInfo.h")]
    [RequiredByNativeCodeAttribute]
    public struct AnimatorStateInfo
    {
        //
        // 摘要:
        //     The full path hash for this state.
        //
        //     通常用此值是否变了, 来判断 animator 有没有切换自己的 state
        //
        public int fullPathHash { get; }

        // //
        // // 摘要:
        // //     The hashed name of the State.
        // [Obsolete("AnimatorStateInfo.nameHash has been deprecated. Use AnimatorStateInfo.fullPathHash instead.")]
        // public int nameHash { get; }


        /*            
            摘要:
                The hash is generated using Animator.StringToHash(). The hash does not include
                the name of the parent layer.

                比如 animator 中有个 clip 叫 "AA", 那就通过 Animator.StringToHash("AA")
        */
        public int shortNameHash { get; }


        /*
            Normalized time of the State.

            小数部分表示 本帧 anim clip 的播放进度条, 大致在 [0f,1f] 区间内; 实际可能会超 1f, 最后 clamp 下再用; 
        */
        public float normalizedTime { get; }



        //
        // 摘要:
        //     Current duration of the state.
        public float length { get; }
        //
        // 摘要:
        //     The playback speed of the animation. 1 is the normal playback speed.
        public float speed { get; }
        //
        // 摘要:
        //     The speed multiplier for this state.
        public float speedMultiplier { get; }
        //
        // 摘要:
        //     The Tag of the State.
        public int tagHash { get; }
        //
        // 摘要:
        //     Is the state looping.
        public bool loop { get; }

        //
        // 摘要:
        //     Does name match the name of the active state in the statemachine?
        //
        // 参数:
        //   name:
        public bool IsName(string name);

        /*
            Does tag match the tag of the active state in the statemachine.
            ---

            判断本 stateinfo 的 tag 是否为 参数指定的 tag;
            
            参数:
            tag:
        */
        public bool IsTag(string tag);
    }
}

