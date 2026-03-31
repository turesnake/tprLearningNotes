#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

using UnityEngine.Scripting;

namespace Unity.Collections;

//
// Summary:
//     Used to specify allocation type for NativeArray.
[UsedByNativeCode]
public enum Allocator
{
    //
    // Summary:
    //     Invalid allocation.
    Invalid,
    //
    // Summary:
    //     No allocation.
    None,
    //
    // Summary:
    //     Temporary allocation.
    Temp,
    //
    // Summary:
    //     Temporary job allocation.
    TempJob,
    //
    // Summary:
    //     Persistent allocation.
    Persistent,
    //
    // Summary:
    //     Allocation associated with a DSPGraph audio kernel.
    AudioKernel
}
