
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{
    /*
        摘要:
        Blend mode for controlling the blending.

        其实就等于 shader 中配置得 blend src dst;  中得选项;

    */
    [NativeHeaderAttribute("Runtime/GfxDevice/GfxDeviceTypes.h")]
    public enum BlendMode
    {
        
        // 摘要:
        //     Blend factor is (0, 0, 0, 0).
        Zero = 0,
        
        // 摘要:
        //     Blend factor is (1, 1, 1, 1).
        One = 1,
        //
        // 摘要:
        //     Blend factor is (Rd, Gd, Bd, Ad).
        DstColor = 2,
        
        // 摘要:
        //     Blend factor is (Rs, Gs, Bs, As).
        SrcColor = 3,
        
        // 摘要:
        //     Blend factor is (1 - Rd, 1 - Gd, 1 - Bd, 1 - Ad).
        OneMinusDstColor = 4,
        
        // 摘要:
        //     Blend factor is (As, As, As, As).
        SrcAlpha = 5,
        
        // 摘要:
        //     Blend factor is (1 - Rs, 1 - Gs, 1 - Bs, 1 - As).
        OneMinusSrcColor = 6,
        
        // 摘要:
        //     Blend factor is (Ad, Ad, Ad, Ad).
        DstAlpha = 7,
        
        // 摘要:
        //     Blend factor is (1 - Ad, 1 - Ad, 1 - Ad, 1 - Ad).
        OneMinusDstAlpha = 8,
        
        // 摘要:
        //     Blend factor is (f, f, f, 1); where f = min(As, 1 - Ad).
        SrcAlphaSaturate = 9,
        
        // 摘要:
        //     Blend factor is (1 - As, 1 - As, 1 - As, 1 - As).
        OneMinusSrcAlpha = 10
    }
}

