#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// D:\Unity_1_editors\2021.3.33\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Color key used by Gradient.
[UsedByNativeCode]
public struct GradientColorKey
{
    //
    // Summary:
    //     Color of key.
    public Color color;

    //
    // Summary:
    //     Time of the key (0 - 1).
    public float time;

    //
    // Summary:
    //     Gradient color key.
    //
    // Parameters:
    //   color:
    //     Color of key.
    //
    //   time:
    //     Time of the key (0 - 1).
    //
    //   col:
    public GradientColorKey(Color col, float time)
    {
        color = col;
        this.time = time;
    }
}

