#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// D:\Unity_1_editors\2021.3.33\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

namespace UnityEngine;

//
// Summary:
//     Select how gradients will be evaluated.
public enum GradientMode
{
    //
    // Summary:
    //     Find the 2 keys adjacent to the requested evaluation time, and linearly interpolate
    //     between them to obtain a blended color.
    Blend,
    //
    // Summary:
    //     Return a fixed color, by finding the first key whose time value is greater than
    //     the requested evaluation time.
    Fixed
}

