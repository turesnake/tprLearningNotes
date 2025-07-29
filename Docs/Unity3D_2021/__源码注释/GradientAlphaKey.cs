#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// D:\Unity_1_editors\2021.3.33\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Alpha key used by Gradient.
[UsedByNativeCode]
public struct GradientAlphaKey
{
    //
    // Summary:
    //     Alpha channel of key.
    public float alpha;

    //
    // Summary:
    //     Time of the key (0 - 1).
    public float time;

    //
    // Summary:
    //     Gradient alpha key.
    //
    // Parameters:
    //   alpha:
    //     Alpha of key (0 - 1).
    //
    //   time:
    //     Time of the key (0 - 1).
    public GradientAlphaKey(float alpha, float time)
    {
        this.alpha = alpha;
        this.time = time;
    }
}
