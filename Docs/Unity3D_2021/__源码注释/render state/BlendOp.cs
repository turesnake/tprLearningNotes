#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{
    /*
        摘要:
        Blend operation.

        其实就类似 shader 中得 blend op

        The blend operation that is used to combine the pixel shader output with the render target. 
        This can be passed through Material.SetInt() to change the blend operation during runtime.

        Note that the logical operations are only supported in Gamma (non-sRGB) colorspace, 
        on DX11.1 hardware running on DirectX 11.1 runtime.

        Advanced OpenGL blend operations are supported only on hardware supporting either 
        GL_KHR_blend_equation_advanced or GL_NV_blend_equation_advanced 
        and may require use of GL.RenderTargetBarrier(). 
        
        In addition, the shaders that are used with the advanced blend operations 
        must have a UNITY_REQUIRE_ADVANDED_BLEND(mode) declaration in the shader code 
        where mode is one of the blend operations 
        or "all_equations" for supporting all advanced blend operations 
        (see the KHR_blend_equation_advanced spec for other values).

    */
    [NativeHeaderAttribute("Runtime/GfxDevice/GfxDeviceTypes.h")]
    public enum BlendOp//BlendOp__RR
    {
        
        // 摘要:
        //     Add (s + d).
        Add = 0,
        
        // 摘要:
        //     Subtract.
        Subtract = 1,
        
        // 摘要:
        //     Reverse subtract.
        ReverseSubtract = 2,
        
        // 摘要:
        //     Min.
        Min = 3,
        //
        // 摘要:
        //     Max.
        Max = 4,
        //
        // 摘要:
        //     Logical Clear (0).
        LogicalClear = 5,
        //
        // 摘要:
        //     Logical SET (1) (D3D11.1 only).
        LogicalSet = 6,
        //
        // 摘要:
        //     Logical Copy (s) (D3D11.1 only).
        LogicalCopy = 7,
        //
        // 摘要:
        //     Logical inverted Copy (!s) (D3D11.1 only).
        LogicalCopyInverted = 8,
        //
        // 摘要:
        //     Logical No-op (d) (D3D11.1 only).
        LogicalNoop = 9,
        //
        // 摘要:
        //     Logical Inverse (!d) (D3D11.1 only).
        LogicalInvert = 10,
        //
        // 摘要:
        //     Logical AND (s & d) (D3D11.1 only).
        LogicalAnd = 11,
        //
        // 摘要:
        //     Logical NAND !(s & d). D3D11.1 only.
        LogicalNand = 12,
        //
        // 摘要:
        //     Logical OR (s | d) (D3D11.1 only).
        LogicalOr = 13,
        //
        // 摘要:
        //     Logical NOR !(s | d) (D3D11.1 only).
        LogicalNor = 14,
        //
        // 摘要:
        //     Logical XOR (s XOR d) (D3D11.1 only).
        LogicalXor = 15,
        //
        // 摘要:
        //     Logical Equivalence !(s XOR d) (D3D11.1 only).
        LogicalEquivalence = 16,
        //
        // 摘要:
        //     Logical reverse AND (s & !d) (D3D11.1 only).
        LogicalAndReverse = 17,
        //
        // 摘要:
        //     Logical inverted AND (!s & d) (D3D11.1 only).
        LogicalAndInverted = 18,
        //
        // 摘要:
        //     Logical reverse OR (s | !d) (D3D11.1 only).
        LogicalOrReverse = 19,
        //
        // 摘要:
        //     Logical inverted OR (!s | d) (D3D11.1 only).
        LogicalOrInverted = 20,
        //
        // 摘要:
        //     Multiply (Advanced OpenGL blending).
        Multiply = 21,
        //
        // 摘要:
        //     Screen (Advanced OpenGL blending).
        Screen = 22,
        //
        // 摘要:
        //     Overlay (Advanced OpenGL blending).
        Overlay = 23,
        //
        // 摘要:
        //     Darken (Advanced OpenGL blending).
        Darken = 24,
        //
        // 摘要:
        //     Lighten (Advanced OpenGL blending).
        Lighten = 25,
        //
        // 摘要:
        //     Color dodge (Advanced OpenGL blending).
        ColorDodge = 26,
        //
        // 摘要:
        //     Color burn (Advanced OpenGL blending).
        ColorBurn = 27,
        //
        // 摘要:
        //     Hard light (Advanced OpenGL blending).
        HardLight = 28,
        //
        // 摘要:
        //     Soft light (Advanced OpenGL blending).
        SoftLight = 29,
        //
        // 摘要:
        //     Difference (Advanced OpenGL blending).
        Difference = 30,
        //
        // 摘要:
        //     Exclusion (Advanced OpenGL blending).
        Exclusion = 31,
        //
        // 摘要:
        //     HSL Hue (Advanced OpenGL blending).
        HSLHue = 32,
        //
        // 摘要:
        //     HSL saturation (Advanced OpenGL blending).
        HSLSaturation = 33,
        //
        // 摘要:
        //     HSL color (Advanced OpenGL blending).
        HSLColor = 34,
        //
        // 摘要:
        //     HSL luminosity (Advanced OpenGL blending).
        HSLLuminosity = 35
    }
}

