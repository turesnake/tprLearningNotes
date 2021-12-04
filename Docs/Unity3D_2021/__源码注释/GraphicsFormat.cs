#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Experimental.Rendering
{

    /*
        摘要:
        Use this format to create either Textures or RenderTextures from scripts.

        每张图形卡都可能只支持部分 formats, 调用 "SystemInfo.IsFormatSupported()" 来检查是否支持;

        每个 enum 值就是一个 format; 命名规则如下:

- For color formats, 子级格式表明了 "R,G,B,A 通道的size" (如果有的话).

- For depth/stencil formats, 子级格式表明了 the size of the depth (D) and stencil (S) components (如果有的话).

- UNorm: The components are "unsigned normalized" values in the range [0,1]. 

- SNorm: The components are "signed normalized" values in the range [-1,1]. 

- UInt: The components are "unsigned integer" values in the range [0, 2^(n-1)]. 

- SInt: The components are "signed integer" values in the range [-2^(n-1),2^(n-1)-1]. 

- UFloat: The components are "unsigned floating-point" numbers 
    (used by packed, shared exponent (共享指数), and some compressed formats). 
    
- SFloat: The components are "signed floating-point" numbers. 

- SRGB: The R,G,B 通道 are "unsigned normalized" values that represent values using "sRGB nonlinear encoding", 
    while the A 通道 (如果存在) is a "regular unsigned normalized" value. 
    
- PACKnn: The format is packed into an "underlying type with nn bits". (nn 是某个具体数字)


    */
    public enum GraphicsFormat//GraphicsFormat__RR
    {
        
        //     The format is not specified.  未指定格式。
        None = 0,
        
        //     A one-component, 8-bit unsigned normalized format that has 
        //     a single 8-bit R component stored with sRGB nonlinear encoding.
        R8_SRGB = 1,
       
        //     A two-component, 16-bit unsigned normalized format that has 
        //     an 8-bit R component stored with sRGB nonlinear encoding in byte 0, 
        //     an 8-bit G component stored with sRGB nonlinear encoding in byte 1.
        R8G8_SRGB = 2,
        //
        // 摘要:
        //     A three-component, 24-bit unsigned normalized format that has an 8-bit R component
        //     stored with sRGB nonlinear encoding in byte 0, an 8-bit G component stored with
        //     sRGB nonlinear encoding in byte 1, and an 8-bit B component stored with sRGB
        //     nonlinear encoding in byte 2.
        R8G8B8_SRGB = 3,
        //
        // 摘要:
        //     A four-component, 32-bit unsigned normalized format that has an 8-bit R component
        //     stored with sRGB nonlinear encoding in byte 0, an 8-bit G component stored with
        //     sRGB nonlinear encoding in byte 1, an 8-bit B component stored with sRGB nonlinear
        //     encoding in byte 2, and an 8-bit A component in byte 3.
        R8G8B8A8_SRGB = 4,
        //
        // 摘要:
        //     A one-component, 8-bit unsigned normalized format that has a single 8-bit R component.
        R8_UNorm = 5,
        //
        // 摘要:
        //     A two-component, 16-bit unsigned normalized format that has an 8-bit R component
        //     stored with sRGB nonlinear encoding in byte 0, and an 8-bit G component stored
        //     with sRGB nonlinear encoding in byte 1.
        R8G8_UNorm = 6,
        //
        // 摘要:
        //     A three-component, 24-bit unsigned normalized format that has an 8-bit R component
        //     in byte 0, an 8-bit G component in byte 1, and an 8-bit B component in byte 2.
        R8G8B8_UNorm = 7,
        //
        // 摘要:
        //     A four-component, 32-bit unsigned normalized format that has an 8-bit R component
        //     in byte 0, an 8-bit G component in byte 1, an 8-bit B component in byte 2, and
        //     an 8-bit A component in byte 3.
        R8G8B8A8_UNorm = 8,
        //
        // 摘要:
        //     A one-component, 8-bit signed normalized format that has a single 8-bit R component.
        R8_SNorm = 9,
        //
        // 摘要:
        //     A two-component, 16-bit signed normalized format that has an 8-bit R component
        //     stored with sRGB nonlinear encoding in byte 0, and an 8-bit G component stored
        //     with sRGB nonlinear encoding in byte 1.
        R8G8_SNorm = 10,
        //
        // 摘要:
        //     A three-component, 24-bit signed normalized format that has an 8-bit R component
        //     in byte 0, an 8-bit G component in byte 1, and an 8-bit B component in byte 2.
        R8G8B8_SNorm = 11,
        //
        // 摘要:
        //     A four-component, 32-bit signed normalized format that has an 8-bit R component
        //     in byte 0, an 8-bit G component in byte 1, an 8-bit B component in byte 2, and
        //     an 8-bit A component in byte 3.
        R8G8B8A8_SNorm = 12,
        //
        // 摘要:
        //     A one-component, 8-bit unsigned integer format that has a single 8-bit R component.
        R8_UInt = 13,
        //
        // 摘要:
        //     A two-component, 16-bit unsigned integer format that has an 8-bit R component
        //     in byte 0, and an 8-bit G component in byte 1.
        R8G8_UInt = 14,
        //
        // 摘要:
        //     A three-component, 24-bit unsigned integer format that has an 8-bit R component
        //     in byte 0, an 8-bit G component in byte 1, and an 8-bit B component in byte 2.
        R8G8B8_UInt = 15,
        //
        // 摘要:
        //     A four-component, 32-bit unsigned integer format that has an 8-bit R component
        //     in byte 0, an 8-bit G component in byte 1, an 8-bit B component in byte 2, and
        //     an 8-bit A component in byte 3.
        R8G8B8A8_UInt = 16,
        //
        // 摘要:
        //     A one-component, 8-bit signed integer format that has a single 8-bit R component.
        R8_SInt = 17,
        //
        // 摘要:
        //     A two-component, 16-bit signed integer format that has an 8-bit R component in
        //     byte 0, and an 8-bit G component in byte 1.
        R8G8_SInt = 18,
        //
        // 摘要:
        //     A three-component, 24-bit signed integer format that has an 8-bit R component
        //     in byte 0, an 8-bit G component in byte 1, and an 8-bit B component in byte 2.
        R8G8B8_SInt = 19,
        //
        // 摘要:
        //     A four-component, 32-bit signed integer format that has an 8-bit R component
        //     in byte 0, an 8-bit G component in byte 1, an 8-bit B component in byte 2, and
        //     an 8-bit A component in byte 3.
        R8G8B8A8_SInt = 20,
        //
        // 摘要:
        //     A one-component, 16-bit unsigned normalized format that has a single 16-bit R
        //     component.
        R16_UNorm = 21,
        //
        // 摘要:
        //     A two-component, 32-bit unsigned normalized format that has a 16-bit R component
        //     in bytes 0..1, and a 16-bit G component in bytes 2..3.
        R16G16_UNorm = 22,
        //
        // 摘要:
        //     A three-component, 48-bit unsigned normalized format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, and a 16-bit B component in
        //     bytes 4..5.
        R16G16B16_UNorm = 23,
        //
        // 摘要:
        //     A four-component, 64-bit unsigned normalized format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, a 16-bit B component in bytes
        //     4..5, and a 16-bit A component in bytes 6..7.
        R16G16B16A16_UNorm = 24,
        //
        // 摘要:
        //     A one-component, 16-bit signed normalized format that has a single 16-bit R component.
        R16_SNorm = 25,
        //
        // 摘要:
        //     A two-component, 32-bit signed normalized format that has a 16-bit R component
        //     in bytes 0..1, and a 16-bit G component in bytes 2..3.
        R16G16_SNorm = 26,
        //
        // 摘要:
        //     A three-component, 48-bit signed normalized format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, and a 16-bit B component in
        //     bytes 4..5.
        R16G16B16_SNorm = 27,
        //
        // 摘要:
        //     A four-component, 64-bit signed normalized format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, a 16-bit B component in bytes
        //     4..5, and a 16-bit A component in bytes 6..7.
        R16G16B16A16_SNorm = 28,
        //
        // 摘要:
        //     A one-component, 16-bit unsigned integer format that has a single 16-bit R component.
        R16_UInt = 29,
        //
        // 摘要:
        //     A two-component, 32-bit unsigned integer format that has a 16-bit R component
        //     in bytes 0..1, and a 16-bit G component in bytes 2..3.
        R16G16_UInt = 30,
        //
        // 摘要:
        //     A three-component, 48-bit unsigned integer format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, and a 16-bit B component in
        //     bytes 4..5.
        R16G16B16_UInt = 31,
        //
        // 摘要:
        //     A four-component, 64-bit unsigned integer format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, a 16-bit B component in bytes
        //     4..5, and a 16-bit A component in bytes 6..7.
        R16G16B16A16_UInt = 32,
        //
        // 摘要:
        //     A one-component, 16-bit signed integer format that has a single 16-bit R component.
        R16_SInt = 33,
        //
        // 摘要:
        //     A two-component, 32-bit signed integer format that has a 16-bit R component in
        //     bytes 0..1, and a 16-bit G component in bytes 2..3.
        R16G16_SInt = 34,
        //
        // 摘要:
        //     A three-component, 48-bit signed integer format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, and a 16-bit B component in
        //     bytes 4..5.
        R16G16B16_SInt = 35,
        //
        // 摘要:
        //     A four-component, 64-bit signed integer format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, a 16-bit B component in bytes
        //     4..5, and a 16-bit A component in bytes 6..7.
        R16G16B16A16_SInt = 36,
        //
        // 摘要:
        //     A one-component, 32-bit unsigned integer format that has a single 32-bit R component.
        R32_UInt = 37,
        //
        // 摘要:
        //     A two-component, 64-bit unsigned integer format that has a 32-bit R component
        //     in bytes 0..3, and a 32-bit G component in bytes 4..7.
        R32G32_UInt = 38,
        //
        // 摘要:
        //     A three-component, 96-bit unsigned integer format that has a 32-bit R component
        //     in bytes 0..3, a 32-bit G component in bytes 4..7, and a 32-bit B component in
        //     bytes 8..11.
        R32G32B32_UInt = 39,
        //
        // 摘要:
        //     A four-component, 128-bit unsigned integer format that has a 32-bit R component
        //     in bytes 0..3, a 32-bit G component in bytes 4..7, a 32-bit B component in bytes
        //     8..11, and a 32-bit A component in bytes 12..15.
        R32G32B32A32_UInt = 40,
        //
        // 摘要:
        //     A one-component, 32-bit signed integer format that has a single 32-bit R component.
        R32_SInt = 41,
        //
        // 摘要:
        //     A two-component, 64-bit signed integer format that has a 32-bit R component in
        //     bytes 0..3, and a 32-bit G component in bytes 4..7.
        R32G32_SInt = 42,
        //
        // 摘要:
        //     A three-component, 96-bit signed integer format that has a 32-bit R component
        //     in bytes 0..3, a 32-bit G component in bytes 4..7, and a 32-bit B component in
        //     bytes 8..11.
        R32G32B32_SInt = 43,
        //
        // 摘要:
        //     A four-component, 128-bit signed integer format that has a 32-bit R component
        //     in bytes 0..3, a 32-bit G component in bytes 4..7, a 32-bit B component in bytes
        //     8..11, and a 32-bit A component in bytes 12..15.
        R32G32B32A32_SInt = 44,
       
        //  A one-component, 16-bit signed floating-point format that has 
        //  a single 16-bit R component.
        R16_SFloat = 45,

        //
        // 摘要:
        //     A two-component, 32-bit signed floating-point format that has a 16-bit R component
        //     in bytes 0..1, and a 16-bit G component in bytes 2..3.
        R16G16_SFloat = 46,
        //
        // 摘要:
        //     A three-component, 48-bit signed floating-point format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, and a 16-bit B component in
        //     bytes 4..5.
        R16G16B16_SFloat = 47,
        //
        // 摘要:
        //     A four-component, 64-bit signed floating-point format that has a 16-bit R component
        //     in bytes 0..1, a 16-bit G component in bytes 2..3, a 16-bit B component in bytes
        //     4..5, and a 16-bit A component in bytes 6..7.
        R16G16B16A16_SFloat = 48,
        //
        // 摘要:
        //     A one-component, 32-bit signed floating-point format that has a single 32-bit
        //     R component.
        R32_SFloat = 49,
        //
        // 摘要:
        //     A two-component, 64-bit signed floating-point format that has a 32-bit R component
        //     in bytes 0..3, and a 32-bit G component in bytes 4..7.
        R32G32_SFloat = 50,
        //
        // 摘要:
        //     A three-component, 96-bit signed floating-point format that has a 32-bit R component
        //     in bytes 0..3, a 32-bit G component in bytes 4..7, and a 32-bit B component in
        //     bytes 8..11.
        R32G32B32_SFloat = 51,
        //
        // 摘要:
        //     A four-component, 128-bit signed floating-point format that has a 32-bit R component
        //     in bytes 0..3, a 32-bit G component in bytes 4..7, a 32-bit B component in bytes
        //     8..11, and a 32-bit A component in bytes 12..15.
        R32G32B32A32_SFloat = 52,
        //
        // 摘要:
        //     A three-component, 24-bit unsigned normalized format that has an 8-bit R component
        //     stored with sRGB nonlinear encoding in byte 0, an 8-bit G component stored with
        //     sRGB nonlinear encoding in byte 1, and an 8-bit B component stored with sRGB
        //     nonlinear encoding in byte 2.
        B8G8R8_SRGB = 56,
        //
        // 摘要:
        //     A four-component, 32-bit unsigned normalized format that has an 8-bit B component
        //     stored with sRGB nonlinear encoding in byte 0, an 8-bit G component stored with
        //     sRGB nonlinear encoding in byte 1, an 8-bit R component stored with sRGB nonlinear
        //     encoding in byte 2, and an 8-bit A component in byte 3.
        B8G8R8A8_SRGB = 57,
        //
        // 摘要:
        //     A three-component, 24-bit unsigned normalized format that has an 8-bit B component
        //     in byte 0, an 8-bit G component in byte 1, and an 8-bit R component in byte 2.
        B8G8R8_UNorm = 58,
        //
        // 摘要:
        //     A four-component, 32-bit unsigned normalized format that has an 8-bit B component
        //     in byte 0, an 8-bit G component in byte 1, an 8-bit R component in byte 2, and
        //     an 8-bit A component in byte 3.
        B8G8R8A8_UNorm = 59,
        //
        // 摘要:
        //     A three-component, 24-bit signed normalized format that has an 8-bit B component
        //     in byte 0, an 8-bit G component in byte 1, and an 8-bit R component in byte 2.
        B8G8R8_SNorm = 60,
        //
        // 摘要:
        //     A four-component, 32-bit signed normalized format that has an 8-bit B component
        //     in byte 0, an 8-bit G component in byte 1, an 8-bit R component in byte 2, and
        //     an 8-bit A component in byte 3.
        B8G8R8A8_SNorm = 61,
        //
        // 摘要:
        //     A three-component, 24-bit unsigned integer format that has an 8-bit B component
        //     in byte 0, an 8-bit G component in byte 1, and an 8-bit R component in byte 2
        B8G8R8_UInt = 62,
        //
        // 摘要:
        //     A four-component, 32-bit unsigned integer format that has an 8-bit B component
        //     in byte 0, an 8-bit G component in byte 1, an 8-bit R component in byte 2, and
        //     an 8-bit A component in byte 3.
        B8G8R8A8_UInt = 63,
        //
        // 摘要:
        //     A three-component, 24-bit signed integer format that has an 8-bit B component
        //     in byte 0, an 8-bit G component in byte 1, and an 8-bit R component in byte 2.
        B8G8R8_SInt = 64,
        //
        // 摘要:
        //     A four-component, 32-bit signed integer format that has an 8-bit B component
        //     in byte 0, an 8-bit G component in byte 1, an 8-bit R component in byte 2, and
        //     an 8-bit A component in byte 3.
        B8G8R8A8_SInt = 65,
        //
        // 摘要:
        //     A four-component, 16-bit packed unsigned normalized format that has a 4-bit R
        //     component in bits 12..15, a 4-bit G component in bits 8..11, a 4-bit B component
        //     in bits 4..7, and a 4-bit A component in bits 0..3.
        R4G4B4A4_UNormPack16 = 66,
        //
        // 摘要:
        //     A four-component, 16-bit packed unsigned normalized format that has a 4-bit B
        //     component in bits 12..15, a 4-bit G component in bits 8..11, a 4-bit R component
        //     in bits 4..7, and a 4-bit A component in bits 0..3.
        B4G4R4A4_UNormPack16 = 67,
        //
        // 摘要:
        //     A three-component, 16-bit packed unsigned normalized format that has a 5-bit
        //     R component in bits 11..15, a 6-bit G component in bits 5..10, and a 5-bit B
        //     component in bits 0..4.
        R5G6B5_UNormPack16 = 68,
        //
        // 摘要:
        //     A three-component, 16-bit packed unsigned normalized format that has a 5-bit
        //     B component in bits 11..15, a 6-bit G component in bits 5..10, and a 5-bit R
        //     component in bits 0..4.
        B5G6R5_UNormPack16 = 69,
        //
        // 摘要:
        //     A four-component, 16-bit packed unsigned normalized format that has a 5-bit R
        //     component in bits 11..15, a 5-bit G component in bits 6..10, a 5-bit B component
        //     in bits 1..5, and a 1-bit A component in bit 0.
        R5G5B5A1_UNormPack16 = 70,
        //
        // 摘要:
        //     A four-component, 16-bit packed unsigned normalized format that has a 5-bit B
        //     component in bits 11..15, a 5-bit G component in bits 6..10, a 5-bit R component
        //     in bits 1..5, and a 1-bit A component in bit 0.
        B5G5R5A1_UNormPack16 = 71,
        //
        // 摘要:
        //     A four-component, 16-bit packed unsigned normalized format that has a 1-bit A
        //     component in bit 15, a 5-bit R component in bits 10..14, a 5-bit G component
        //     in bits 5..9, and a 5-bit B component in bits 0..4.
        A1R5G5B5_UNormPack16 = 72,
        //
        // 摘要:
        //     A three-component, 32-bit packed unsigned floating-point format that has a 5-bit
        //     shared exponent in bits 27..31, a 9-bit B component mantissa in bits 18..26,
        //     a 9-bit G component mantissa in bits 9..17, and a 9-bit R component mantissa
        //     in bits 0..8.
        E5B9G9R9_UFloatPack32 = 73,
        //
        // 摘要:
        //     A three-component, 32-bit packed unsigned floating-point format that has a 10-bit
        //     B component in bits 22..31, an 11-bit G component in bits 11..21, an 11-bit R
        //     component in bits 0..10.
        B10G11R11_UFloatPack32 = 74,
        //
        // 摘要:
        //     A four-component, 32-bit packed unsigned normalized format that has a 2-bit A
        //     component in bits 30..31, a 10-bit B component in bits 20..29, a 10-bit G component
        //     in bits 10..19, and a 10-bit R component in bits 0..9.
        A2B10G10R10_UNormPack32 = 75,
        //
        // 摘要:
        //     A four-component, 32-bit packed unsigned integer format that has a 2-bit A component
        //     in bits 30..31, a 10-bit B component in bits 20..29, a 10-bit G component in
        //     bits 10..19, and a 10-bit R component in bits 0..9.
        A2B10G10R10_UIntPack32 = 76,
        //
        // 摘要:
        //     A four-component, 32-bit packed signed integer format that has a 2-bit A component
        //     in bits 30..31, a 10-bit B component in bits 20..29, a 10-bit G component in
        //     bits 10..19, and a 10-bit R component in bits 0..9.
        A2B10G10R10_SIntPack32 = 77,
        //
        // 摘要:
        //     A four-component, 32-bit packed unsigned normalized format that has a 2-bit A
        //     component in bits 30..31, a 10-bit R component in bits 20..29, a 10-bit G component
        //     in bits 10..19, and a 10-bit B component in bits 0..9.
        A2R10G10B10_UNormPack32 = 78,
        //
        // 摘要:
        //     A four-component, 32-bit packed unsigned integer format that has a 2-bit A component
        //     in bits 30..31, a 10-bit R component in bits 20..29, a 10-bit G component in
        //     bits 10..19, and a 10-bit B component in bits 0..9.
        A2R10G10B10_UIntPack32 = 79,
        //
        // 摘要:
        //     A four-component, 32-bit packed signed integer format that has a 2-bit A component
        //     in bits 30..31, a 10-bit R component in bits 20..29, a 10-bit G component in
        //     bits 10..19, and a 10-bit B component in bits 0..9.
        A2R10G10B10_SIntPack32 = 80,
        //
        // 摘要:
        //     A four-component, 32-bit packed unsigned normalized format that has a 2-bit A
        //     component in bits 30..31, a 10-bit R component in bits 20..29, a 10-bit G component
        //     in bits 10..19, and a 10-bit B component in bits 0..9. The components are gamma
        //     encoded and their values range from -0.5271 to 1.66894. The alpha component is
        //     clamped to either 0.0 or 1.0 on sampling, rendering, and writing operations.
        A2R10G10B10_XRSRGBPack32 = 81,
        //
        // 摘要:
        //     A four-component, 32-bit packed unsigned normalized format that has a 2-bit A
        //     component in bits 30..31, a 10-bit R component in bits 20..29, a 10-bit G component
        //     in bits 10..19, and a 10-bit B component in bits 0..9. The components are linearly
        //     encoded and their values range from -0.752941 to 1.25098 (pre-expansion). The
        //     alpha component is clamped to either 0.0 or 1.0 on sampling, rendering, and writing
        //     operations.
        A2R10G10B10_XRUNormPack32 = 82,
        //
        // 摘要:
        //     A four-component, 32-bit packed unsigned normalized format that has a 10-bit
        //     R component in bits 20..29, a 10-bit G component in bits 10..19, and a 10-bit
        //     B component in bits 0..9. The components are gamma encoded and their values range
        //     from -0.5271 to 1.66894. The alpha component is clamped to either 0.0 or 1.0
        //     on sampling, rendering, and writing operations.
        R10G10B10_XRSRGBPack32 = 83,
        //
        // 摘要:
        //     A four-component, 32-bit packed unsigned normalized format that has a 10-bit
        //     R component in bits 20..29, a 10-bit G component in bits 10..19, and a 10-bit
        //     B component in bits 0..9. The components are linearly encoded and their values
        //     range from -0.752941 to 1.25098 (pre-expansion).
        R10G10B10_XRUNormPack32 = 84,
        //
        // 摘要:
        //     A four-component, 64-bit packed unsigned normalized format that has a 10-bit
        //     A component in bits 30..39, a 10-bit R component in bits 20..29, a 10-bit G component
        //     in bits 10..19, and a 10-bit B component in bits 0..9. The components are gamma
        //     encoded and their values range from -0.5271 to 1.66894. The alpha component is
        //     clamped to either 0.0 or 1.0 on sampling, rendering, and writing operations.
        A10R10G10B10_XRSRGBPack32 = 85,
        //
        // 摘要:
        //     A four-component, 64-bit packed unsigned normalized format that has a 10-bit
        //     A component in bits 30..39, a 10-bit R component in bits 20..29, a 10-bit G component
        //     in bits 10..19, and a 10-bit B component in bits 0..9. The components are linearly
        //     encoded and their values range from -0.752941 to 1.25098 (pre-expansion). The
        //     alpha component is clamped to either 0.0 or 1.0 on sampling, rendering, and writing
        //     operations.
        A10R10G10B10_XRUNormPack32 = 86,
        RGB_DXT1_SRGB = 96,
        //
        // 摘要:
        //     A three-component, block-compressed format (also known as BC1). Each 64-bit compressed
        //     texel block encodes a 4×4 rectangle of unsigned normalized RGB texel data with
        //     sRGB nonlinear encoding. This format has a 1 bit alpha channel.
        RGBA_DXT1_SRGB = 96,
        RGB_DXT1_UNorm = 97,
        //
        // 摘要:
        //     A three-component, block-compressed format (also known as BC1). Each 64-bit compressed
        //     texel block encodes a 4×4 rectangle of unsigned normalized RGB texel data. This
        //     format has a 1 bit alpha channel.
        RGBA_DXT1_UNorm = 97,
        //
        // 摘要:
        //     A four-component, block-compressed format (also known as BC2) where each 128-bit
        //     compressed texel block encodes a 4×4 rectangle of unsigned normalized RGBA texel
        //     data with the first 64 bits encoding alpha values followed by 64 bits encoding
        //     RGB values with sRGB nonlinear encoding.
        RGBA_DXT3_SRGB = 98,
        //
        // 摘要:
        //     A four-component, block-compressed format (also known as BC2) where each 128-bit
        //     compressed texel block encodes a 4×4 rectangle of unsigned normalized RGBA texel
        //     data with the first 64 bits encoding alpha values followed by 64 bits encoding
        //     RGB values.
        RGBA_DXT3_UNorm = 99,
        //
        // 摘要:
        //     A four-component, block-compressed format (also known as BC3) where each 128-bit
        //     compressed texel block encodes a 4×4 rectangle of unsigned normalized RGBA texel
        //     data with the first 64 bits encoding alpha values followed by 64 bits encoding
        //     RGB values with sRGB nonlinear encoding.
        RGBA_DXT5_SRGB = 100,
        //
        // 摘要:
        //     A four-component, block-compressed format (also known as BC3) where each 128-bit
        //     compressed texel block encodes a 4×4 rectangle of unsigned normalized RGBA texel
        //     data with the first 64 bits encoding alpha values followed by 64 bits encoding
        //     RGB values.
        RGBA_DXT5_UNorm = 101,
        //
        // 摘要:
        //     A one-component, block-compressed format where each 64-bit compressed texel block
        //     encodes a 4×4 rectangle of unsigned normalized red texel data.
        R_BC4_UNorm = 102,
        //
        // 摘要:
        //     A one-component, block-compressed format where each 64-bit compressed texel block
        //     encodes a 4×4 rectangle of signed normalized red texel data.
        R_BC4_SNorm = 103,
        //
        // 摘要:
        //     A two-component, block-compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RG texel data with the first
        //     64 bits encoding red values followed by 64 bits encoding green values.
        RG_BC5_UNorm = 104,
        //
        // 摘要:
        //     A two-component, block-compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of signed normalized RG texel data with the first
        //     64 bits encoding red values followed by 64 bits encoding green values.
        RG_BC5_SNorm = 105,

        //
        // 摘要:
        //     A three-component, block-compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned floating-point RGB texel data.
        RGB_BC6H_UFloat = 106,
        
        //
        // 摘要:
        //     A three-component, block-compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of signed floating-point RGB texel data.
        RGB_BC6H_SFloat = 107,

        //
        // 摘要:
        //     A four-component, block-compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGBA texel data with sRGB
        //     nonlinear encoding applied to the RGB components.
        RGBA_BC7_SRGB = 108,
        //
        // 摘要:
        //     A four-component, block-compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGBA texel data.
        RGBA_BC7_UNorm = 109,
        //
        // 摘要:
        //     A three-component, PVRTC compressed format where each 64-bit compressed texel
        //     block encodes a 8×4 rectangle of unsigned normalized RGB texel data with sRGB
        //     nonlinear encoding. This format has no alpha and is considered opaque.
        RGB_PVRTC_2Bpp_SRGB = 110,
        //
        // 摘要:
        //     A three-component, PVRTC compressed format where each 64-bit compressed texel
        //     block encodes a 8×4 rectangle of unsigned normalized RGB texel data. This format
        //     has no alpha and is considered opaque.
        RGB_PVRTC_2Bpp_UNorm = 111,
        //
        // 摘要:
        //     A three-component, PVRTC compressed format where each 64-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGB texel data with sRGB
        //     nonlinear encoding. This format has no alpha and is considered opaque.
        RGB_PVRTC_4Bpp_SRGB = 112,
        //
        // 摘要:
        //     A three-component, PVRTC compressed format where each 64-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGB texel data. This format
        //     has no alpha and is considered opaque.
        RGB_PVRTC_4Bpp_UNorm = 113,
        //
        // 摘要:
        //     A four-component, PVRTC compressed format where each 64-bit compressed texel
        //     block encodes a 8×4 rectangle of unsigned normalized RGBA texel data with the
        //     first 32 bits encoding alpha values followed by 32 bits encoding RGB values with
        //     sRGB nonlinear encoding applied.
        RGBA_PVRTC_2Bpp_SRGB = 114,
        //
        // 摘要:
        //     A four-component, PVRTC compressed format where each 64-bit compressed texel
        //     block encodes a 8×4 rectangle of unsigned normalized RGBA texel data with the
        //     first 32 bits encoding alpha values followed by 32 bits encoding RGB values.
        RGBA_PVRTC_2Bpp_UNorm = 115,
        //
        // 摘要:
        //     A four-component, PVRTC compressed format where each 64-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGBA texel data with the
        //     first 32 bits encoding alpha values followed by 32 bits encoding RGB values with
        //     sRGB nonlinear encoding applied.
        RGBA_PVRTC_4Bpp_SRGB = 116,
        //
        // 摘要:
        //     A four-component, PVRTC compressed format where each 64-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGBA texel data with the
        //     first 32 bits encoding alpha values followed by 32 bits encoding RGB values.
        RGBA_PVRTC_4Bpp_UNorm = 117,
        //
        // 摘要:
        //     A three-component, ETC compressed format where each 64-bit compressed texel block
        //     encodes a 4×4 rectangle of unsigned normalized RGB texel data. This format has
        //     no alpha and is considered opaque.
        RGB_ETC_UNorm = 118,
        //
        // 摘要:
        //     A three-component, ETC2 compressed format where each 64-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGB texel data with sRGB
        //     nonlinear encoding. This format has no alpha and is considered opaque.
        RGB_ETC2_SRGB = 119,
        //
        // 摘要:
        //     A three-component, ETC2 compressed format where each 64-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGB texel data. This format
        //     has no alpha and is considered opaque.
        RGB_ETC2_UNorm = 120,
        //
        // 摘要:
        //     A four-component, ETC2 compressed format where each 64-bit compressed texel block
        //     encodes a 4×4 rectangle of unsigned normalized RGB texel data with sRGB nonlinear
        //     encoding, and provides 1 bit of alpha.
        RGB_A1_ETC2_SRGB = 121,
        //
        // 摘要:
        //     A four-component, ETC2 compressed format where each 64-bit compressed texel block
        //     encodes a 4×4 rectangle of unsigned normalized RGB texel data, and provides 1
        //     bit of alpha.
        RGB_A1_ETC2_UNorm = 122,
        //
        // 摘要:
        //     A four-component, ETC2 compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGBA texel data with the
        //     first 64 bits encoding alpha values followed by 64 bits encoding RGB values with
        //     sRGB nonlinear encoding applied.
        RGBA_ETC2_SRGB = 123,
        //
        // 摘要:
        //     A four-component, ETC2 compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGBA texel data with the
        //     first 64 bits encoding alpha values followed by 64 bits encoding RGB values.
        RGBA_ETC2_UNorm = 124,
        //
        // 摘要:
        //     A one-component, ETC2 compressed format where each 64-bit compressed texel block
        //     encodes a 4×4 rectangle of unsigned normalized red texel data.
        R_EAC_UNorm = 125,
        //
        // 摘要:
        //     A one-component, ETC2 compressed format where each 64-bit compressed texel block
        //     encodes a 4×4 rectangle of signed normalized red texel data.
        R_EAC_SNorm = 126,
        //
        // 摘要:
        //     A two-component, ETC2 compressed format where each 128-bit compressed texel block
        //     encodes a 4×4 rectangle of unsigned normalized RG texel data with the first 64
        //     bits encoding red values followed by 64 bits encoding green values.
        RG_EAC_UNorm = 127,
        //
        // 摘要:
        //     A two-component, ETC2 compressed format where each 128-bit compressed texel block
        //     encodes a 4×4 rectangle of signed normalized RG texel data with the first 64
        //     bits encoding red values followed by 64 bits encoding green values.
        RG_EAC_SNorm = 128,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGBA texel data with sRGB
        //     nonlinear encoding applied to the RGB components.
        RGBA_ASTC4X4_SRGB = 129,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of unsigned normalized RGBA texel data.
        RGBA_ASTC4X4_UNorm = 130,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 5×5 rectangle of unsigned normalized RGBA texel data with sRGB
        //     nonlinear encoding applied to the RGB components.
        RGBA_ASTC5X5_SRGB = 131,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 5×5 rectangle of unsigned normalized RGBA texel data.
        RGBA_ASTC5X5_UNorm = 132,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 6×6 rectangle of unsigned normalized RGBA texel data with sRGB
        //     nonlinear encoding applied to the RGB components.
        RGBA_ASTC6X6_SRGB = 133,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 6×6 rectangle of unsigned normalized RGBA texel data.
        RGBA_ASTC6X6_UNorm = 134,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes an 8×8 rectangle of unsigned normalized RGBA texel data with sRGB
        //     nonlinear encoding applied to the RGB components.
        RGBA_ASTC8X8_SRGB = 135,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes an 8×8 rectangle of unsigned normalized RGBA texel data.
        RGBA_ASTC8X8_UNorm = 136,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 10×10 rectangle of unsigned normalized RGBA texel data with sRGB
        //     nonlinear encoding applied to the RGB components.
        RGBA_ASTC10X10_SRGB = 137,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 10×10 rectangle of unsigned normalized RGBA texel data.
        RGBA_ASTC10X10_UNorm = 138,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 12×12 rectangle of unsigned normalized RGBA texel data with sRGB
        //     nonlinear encoding applied to the RGB components.
        RGBA_ASTC12X12_SRGB = 139,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 12×12 rectangle of unsigned normalized RGBA texel data.
        RGBA_ASTC12X12_UNorm = 140,
        //
        // 摘要:
        //     YUV 4:2:2 Video resource format.
        YUV2 = 141,
        //
        // 摘要:
        //     Automatic format used for Depth buffers (Platform dependent)
        DepthAuto = 142,
        //
        // 摘要:
        //     Automatic format used for Shadow buffer (Platform dependent)
        ShadowAuto = 143,
        //
        // 摘要:
        //     Automatic format used for Video buffer (Platform dependent)
        VideoAuto = 144,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 4×4 rectangle of float RGBA texel data.
        RGBA_ASTC4X4_UFloat = 145,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 5×5 rectangle of float RGBA texel data.
        RGBA_ASTC5X5_UFloat = 146,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 6×6 rectangle of float RGBA texel data.
        RGBA_ASTC6X6_UFloat = 147,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes an 8×8 rectangle of float RGBA texel data.
        RGBA_ASTC8X8_UFloat = 148,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 10×10 rectangle of float RGBA texel data.
        RGBA_ASTC10X10_UFloat = 149,
        //
        // 摘要:
        //     A four-component, ASTC compressed format where each 128-bit compressed texel
        //     block encodes a 12×12 rectangle of float RGBA texel data.
        RGBA_ASTC12X12_UFloat = 150
    }
}