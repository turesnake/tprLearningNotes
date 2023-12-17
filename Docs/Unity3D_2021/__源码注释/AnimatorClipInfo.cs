#region Assembly UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Information about clip being played and blended by the Animator.
[NativeHeader("Modules/Animation/AnimatorInfo.h")]
[NativeHeader("Modules/Animation/ScriptBindings/Animation.bindings.h")]
[UsedByNativeCode]
public struct AnimatorClipInfo
{
    private int m_ClipInstanceID;

    private float m_Weight;

    //
    // Summary:
    //     Returns the animation clip played by the Animator.
    public AnimationClip clip => (m_ClipInstanceID != 0) ? InstanceIDToAnimationClipPPtr(m_ClipInstanceID) : null;

    //
    // Summary:
    //     Returns the blending weight used by the Animator to blend this clip.
    public float weight => m_Weight;

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction("AnimationBindings::InstanceIDToAnimationClipPPtr")]
    private static extern AnimationClip InstanceIDToAnimationClipPPtr(int instanceID);
}
#if false // Decompilation log
