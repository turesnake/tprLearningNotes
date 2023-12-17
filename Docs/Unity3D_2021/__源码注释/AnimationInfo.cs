#region Assembly UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace UnityEngine;

//
// Summary:
//     Information about what animation clips is played and its weight.
[StructLayout(LayoutKind.Sequential, Size = 1)]
[Obsolete("Use AnimatorClipInfo instead (UnityUpgradable) -> AnimatorClipInfo", true)]
[EditorBrowsable(EditorBrowsableState.Never)]
public struct AnimationInfo
{
    //
    // Summary:
    //     Animation clip that is played.
    public AnimationClip clip => null;

    //
    // Summary:
    //     The weight of the animation clip.
    public float weight => 0f;
}
#if false // Decompilation log
