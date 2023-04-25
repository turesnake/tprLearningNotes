#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        AnimationEvent lets you call a script function similar to SendMessage as part
        of playing back an animation.


        
    */
    [RequiredByNativeCodeAttribute]
    public sealed class AnimationEvent
    {
        //
        // 摘要:
        //     Creates a new animation event.
        public AnimationEvent();

        [Obsolete("Use stringParameter instead")]
        public string data { get; set; }
        //
        // 摘要:
        //     String parameter that is stored in the event and will be sent to the function.
        public string stringParameter { get; set; }
        //
        // 摘要:
        //     Float parameter that is stored in the event and will be sent to the function.
        public float floatParameter { get; set; }
        //
        // 摘要:
        //     Int parameter that is stored in the event and will be sent to the function.
        public int intParameter { get; set; }
        //
        // 摘要:
        //     Object reference parameter that is stored in the event and will be sent to the
        //     function.
        public Object objectReferenceParameter { get; set; }


        //
        // 摘要:
        //     The name of the function that will be called.
        public string functionName { get; set; }
        //
        // 摘要:
        //     The time at which the event will be fired off.
        public float time { get; set; }
        //
        // 摘要:
        //     Function call options.
        public SendMessageOptions messageOptions { get; set; }
        //
        // 摘要:
        //     Returns true if this Animation event has been fired by an Animation component.
        public bool isFiredByLegacy { get; }
        //
        // 摘要:
        //     Returns true if this Animation event has been fired by an Animator component.
        public bool isFiredByAnimator { get; }
        //
        // 摘要:
        //     The animation state that fired this event (Read Only).
        public AnimationState animationState { get; }
        //
        // 摘要:
        //     The animator state info related to this event (Read Only).
        public AnimatorStateInfo animatorStateInfo { get; }
        //
        // 摘要:
        //     The animator clip info related to this event (Read Only).
        public AnimatorClipInfo animatorClipInfo { get; }
    }
}

