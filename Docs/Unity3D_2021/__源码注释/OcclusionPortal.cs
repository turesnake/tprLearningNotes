#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

//
// Summary:
//     The portal for dynamically changing occlusion at runtime.
[NativeHeader("Runtime/Camera/OcclusionPortal.h")]
public sealed class OcclusionPortal : Component
{
    //
    // Summary:
    //     Gets / sets the portal's open state.
    [NativeProperty("IsOpen")]
    public extern bool open
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }
}

