#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.LowLevel;

//
// Summary:
//     The representation of a single system being updated by the player loop in Unity.
[MovedFrom("UnityEngine.Experimental.LowLevel")]
public struct PlayerLoopSystem
{
    public delegate void UpdateFunction();

    //
    // Summary:
    //     This property is used to identify which native system this belongs to, or to
    //     get the name of the managed system to show in the profiler.
    public Type type;

    /*
        Summary:
           A list of sub systems which run as part of this item in the player loop.

        !!! 数组中现存的元素有:
            TimeUpdate
            Initialization
            EarlyUpdate
            FixedUpdate
            PreUpdate
            Update
            PreLateUpdate
            PostLateUpdate

    */
    public PlayerLoopSystem[] subSystemList;

    //
    // Summary:
    //     A managed delegate. You can set this to create a new C# entrypoint in the player
    //     loop.
    public UpdateFunction updateDelegate;

    //
    // Summary:
    //     A native engine system. To get a valid value for this, you must copy it from
    //     one of the PlayerLoopSystems returned by PlayerLoop.GetDefaultPlayerLoop.
    public IntPtr updateFunction;

    //
    // Summary:
    //     The loop condition for a native engine system. To get a valid value for this,
    //     you must copy it from one of the PlayerLoopSystems returned by PlayerLoop.GetDefaultPlayerLoop.
    public IntPtr loopConditionFunction;

    public override string ToString()
    {
        return type.Name;
    }
}

