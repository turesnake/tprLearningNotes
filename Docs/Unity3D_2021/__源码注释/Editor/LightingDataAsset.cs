#region Assembly UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Bindings;

namespace UnityEditor;

//
// Summary:
//     The lighting data asset used by the active Scene.
[ExcludeFromPreset]
[NativeHeader("Editor/Src/GI/Enlighten/LightingDataAsset.h")]
public sealed class LightingDataAsset : Object
{
    internal extern bool isValid
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("IsValid")]
        get;
    }

    internal extern string validityErrorMessage
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    private LightingDataAsset()
    {
    }
}

