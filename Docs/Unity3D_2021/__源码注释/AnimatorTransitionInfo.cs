#region Assembly UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Information about the current transition.
[NativeHeader("Modules/Animation/AnimatorInfo.h")]
[RequiredByNativeCode]
public struct AnimatorTransitionInfo
{
    [NativeName("fullPathHash")]
    private int m_FullPath;

    [NativeName("userNameHash")]
    private int m_UserName;

    [NativeName("nameHash")]
    private int m_Name;

    [NativeName("hasFixedDuration")]
    private bool m_HasFixedDuration;

    [NativeName("duration")]
    private float m_Duration;

    [NativeName("normalizedTime")]
    private float m_NormalizedTime;

    [NativeName("anyState")]
    private bool m_AnyState;

    [NativeName("transitionType")]
    private int m_TransitionType;

    //
    // Summary:
    //     The hash name of the Transition.
    public int fullPathHash => m_FullPath;

    //
    // Summary:
    //     The simplified name of the Transition.
    public int nameHash => m_Name;

    //
    // Summary:
    //     The user-specified name of the Transition.
    public int userNameHash => m_UserName;

    //
    // Summary:
    //     The unit of the transition duration.
    public DurationUnit durationUnit => (!m_HasFixedDuration) ? DurationUnit.Normalized : DurationUnit.Fixed;

    //
    // Summary:
    //     Duration of the transition.
    public float duration => m_Duration;

    //
    // Summary:
    //     Normalized time of the Transition.
    public float normalizedTime => m_NormalizedTime;

    //
    // Summary:
    //     Returns true if the transition is from an AnyState node, or from Animator.CrossFade.
    public bool anyState => m_AnyState;

    internal bool entry => (m_TransitionType & 2) != 0;

    internal bool exit => (m_TransitionType & 4) != 0;

    //
    // Summary:
    //     Does name match the name of the active Transition.
    //
    // Parameters:
    //   name:
    public bool IsName(string name)
    {
        return Animator.StringToHash(name) == m_Name || Animator.StringToHash(name) == m_FullPath;
    }

    //
    // Summary:
    //     Does userName match the name of the active Transition.
    //
    // Parameters:
    //   name:
    public bool IsUserName(string name)
    {
        return Animator.StringToHash(name) == m_UserName;
    }
}
#if false // Decompilation log
