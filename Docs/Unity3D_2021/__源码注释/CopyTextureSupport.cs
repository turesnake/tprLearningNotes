#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     Support for various Graphics.CopyTexture cases.
    [Flags]
    public enum CopyTextureSupport//CopyTextureSupport__RR
    {
        //
        // 摘要:
        //     No support for Graphics.CopyTexture.
        None = 0,
        //
        // 摘要:
        //     Basic Graphics.CopyTexture support.
        Basic = 1,
        //
        // 摘要:
        //     Support for Texture3D in Graphics.CopyTexture.
        Copy3D = 2,
        //
        // 摘要:
        //     Support for Graphics.CopyTexture between different texture types.
        DifferentTypes = 4,
        //
        // 摘要:
        //     Support for Texture to RenderTexture copies in Graphics.CopyTexture.
        TextureToRT = 8,
        //
        // 摘要:
        //     Support for RenderTexture to Texture copies in Graphics.CopyTexture.
        RTToTexture = 16
    }
}

