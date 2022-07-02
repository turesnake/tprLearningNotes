#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

namespace UnityEditor
{
    //
    // 摘要:
    //     Imported texture format for TextureImporter.
    public enum TextureImporterFormat
    {
        //
        // 摘要:
        //     Choose a compressed HDR format automatically.
        AutomaticCompressedHDR = -7,
        //
        // 摘要:
        //     Choose an HDR format automatically.
        AutomaticHDR = -6,
        //
        // 摘要:
        //     Choose a crunched format automatically.
        AutomaticCrunched = -5,
        //
        // 摘要:
        //     Choose a Truecolor format automatically.
        AutomaticTruecolor = -3,
        //
        // 摘要:
        //     Choose a 16 bit format automatically.
        Automatic16bit = -2,
        //
        // 摘要:
        //     Choose texture format automatically based on the texture parameters.
        Automatic = -1,
        //
        // 摘要:
        //     Choose a compressed format automatically.
        AutomaticCompressed = -1,
        //
        // 摘要:
        //     TextureFormat.Alpha8 texture format.
        Alpha8 = 1,
        //
        // 摘要:
        //     TextureFormat.ARGB4444 texture format.
        ARGB16 = 2,
        //
        // 摘要:
        //     TextureFormat.RGB24 texture format.
        RGB24 = 3,
        //
        // 摘要:
        //     TextureFormat.RGBA32 texture format.
        RGBA32 = 4,
        //
        // 摘要:
        //     TextureFormat.ARGB32 texture format.
        ARGB32 = 5,
        //
        // 摘要:
        //     TextureFormat.RGB565 texture format.
        RGB16 = 7,
        //
        // 摘要:
        //     TextureFormat.R16 texture format.
        R16 = 9,
        //
        // 摘要:
        //     TextureFormat.DXT1 (BC1) compressed texture format.
        DXT1 = 10,
        //
        // 摘要:
        //     TextureFormat.DXT5 (BC3) compressed texture format.
        DXT5 = 12,
        //
        // 摘要:
        //     TextureFormat.RGBA4444 texture format.
        RGBA16 = 13,
        //
        // 摘要:
        //     TextureFormat.RHalf half-precision floating point texture format.
        RHalf = 15,
        //
        // 摘要:
        //     TextureFormat.RGHalf half-precision floating point texture format.
        RGHalf = 16,
        //
        // 摘要:
        //     TextureFormat.RGBAHalf half-precision floating point texture format.
        RGBAHalf = 17,
        //
        // 摘要:
        //     TextureFormat.RFloat floating point texture format.
        RFloat = 18,
        //
        // 摘要:
        //     TextureFormat.RGFloat floating point texture format.
        RGFloat = 19,
        //
        // 摘要:
        //     TextureFormat.RGBAFloat floating point RGBA texture format.
        RGBAFloat = 20,
        //
        // 摘要:
        //     TextureFormat.RGB9e5Float packed unsigned floating point texture format with
        //     shared exponent.
        RGB9E5 = 22,
        //
        // 摘要:
        //     TextureFormat.BC6H compressed HDR texture format.
        BC6H = 24,
        //
        // 摘要:
        //     TextureFormat.BC7 compressed texture format.
        BC7 = 25,
        //
        // 摘要:
        //     TextureFormat.BC4 compressed texture format.
        BC4 = 26,
        //
        // 摘要:
        //     TextureFormat.BC5 compressed texture format.
        BC5 = 27,
        //
        // 摘要:
        //     DXT1 (BC1) compressed texture format using Crunch compression for smaller storage
        //     sizes.
        DXT1Crunched = 28,
        //
        // 摘要:
        //     DXT5 (BC3) compressed texture format using Crunch compression for smaller storage
        //     sizes.
        DXT5Crunched = 29,
        //
        // 摘要:
        //     PowerVR/iOS TextureFormat.PVRTC_RGB2 compressed texture format.
        PVRTC_RGB2 = 30,
        //
        // 摘要:
        //     PowerVR/iOS TextureFormat.PVRTC_RGBA2 compressed texture format.
        PVRTC_RGBA2 = 31,
        //
        // 摘要:
        //     PowerVR/iOS TextureFormat.PVRTC_RGB4 compressed texture format.
        PVRTC_RGB4 = 32,
        //
        // 摘要:
        //     PowerVR/iOS TextureFormat.PVRTC_RGBA4 compressed texture format.
        PVRTC_RGBA4 = 33,
        //
        // 摘要:
        //     ETC (GLES2.0) 4 bits/pixel compressed RGB texture format.
        ETC_RGB4 = 34,
        ATC_RGB4 = 35,
        ATC_RGBA8 = 36,
        //
        // 摘要:
        //     ETC2EAC compressed 4 bits pixel unsigned R texture format.
        EAC_R = 41,
        //
        // 摘要:
        //     ETC2EAC compressed 4 bits pixel signed R texture format.
        EAC_R_SIGNED = 42,
        //
        // 摘要:
        //     ETC2EAC compressed 8 bits pixel unsigned RG texture format.
        EAC_RG = 43,
        //
        // 摘要:
        //     ETC2EAC compressed 4 bits pixel signed RG texture format.
        EAC_RG_SIGNED = 44,
        //
        // 摘要:
        //     ETC2 compressed 4 bits / pixel RGB texture format.
        ETC2_RGB4 = 45,
        //
        // 摘要:
        //     ETC2 compressed 4 bits / pixel RGB + 1-bit alpha texture format.
        ETC2_RGB4_PUNCHTHROUGH_ALPHA = 46,
        //
        // 摘要:
        //     ETC2 compressed 8 bits / pixel RGBA texture format.
        ETC2_RGBA8 = 47,
        //
        // 摘要:
        //     ASTC compressed RGB(A) texture format, 4x4 block size.
        ASTC_4x4 = 48,
        //
        // 摘要:
        //     ASTC compressed RGB texture format, 4x4 block size.
        ASTC_RGB_4x4 = 48,
        //
        // 摘要:
        //     ASTC compressed RGB(A) texture format, 5x5 block size.
        ASTC_5x5 = 49,
        //
        // 摘要:
        //     ASTC compressed RGB texture format, 5x5 block size.
        ASTC_RGB_5x5 = 49,
        //
        // 摘要:
        //     ASTC compressed RGB(A) texture format, 6x6 block size.
        ASTC_6x6 = 50,
        //
        // 摘要:
        //     ASTC compressed RGB texture format, 6x6 block size.
        ASTC_RGB_6x6 = 50,
        //
        // 摘要:
        //     ASTC compressed RGB(A) texture format, 8x8 block size.
        ASTC_8x8 = 51,
        //
        // 摘要:
        //     ASTC compressed RGB texture format, 8x8 block size.
        ASTC_RGB_8x8 = 51,
        //
        // 摘要:
        //     ASTC compressed RGB(A) texture format, 10x10 block size.
        ASTC_10x10 = 52,
        //
        // 摘要:
        //     ASTC compressed RGB texture format, 10x10 block size.
        ASTC_RGB_10x10 = 52,
        //
        // 摘要:
        //     ASTC compressed RGB(A) texture format, 12x12 block size.
        ASTC_12x12 = 53,
        //
        // 摘要:
        //     ASTC compressed RGB texture format, 12x12 block size.
        ASTC_RGB_12x12 = 53,
        //
        // 摘要:
        //     ASTC compressed RGBA texture format, 4x4 block size.
        ASTC_RGBA_4x4 = 54,
        //
        // 摘要:
        //     ASTC compressed RGBA texture format, 5x5 block size.
        ASTC_RGBA_5x5 = 55,
        //
        // 摘要:
        //     ASTC compressed RGBA texture format, 6x6 block size.
        ASTC_RGBA_6x6 = 56,
        //
        // 摘要:
        //     ASTC compressed RGBA texture format, 8x8 block size.
        ASTC_RGBA_8x8 = 57,
        //
        // 摘要:
        //     ASTC compressed RGBA texture format, 10x10 block size.
        ASTC_RGBA_10x10 = 58,
        //
        // 摘要:
        //     ASTC compressed RGBA texture format, 12x12 block size.
        ASTC_RGBA_12x12 = 59,
        //
        // 摘要:
        //     ETC (Nintendo 3DS) 4 bits/pixel compressed RGB texture format.
        ETC_RGB4_3DS = 60,
        //
        // 摘要:
        //     ETC (Nintendo 3DS) 8 bits/pixel compressed RGBA texture format.
        ETC_RGBA8_3DS = 61,
        //
        // 摘要:
        //     TextureFormat.RG16 texture format.
        RG16 = 62,
        //
        // 摘要:
        //     TextureFormat.R8 texture format.
        R8 = 63,
        //
        // 摘要:
        //     ETC_RGB4 compressed texture format using Crunch compression for smaller storage
        //     sizes.
        ETC_RGB4Crunched = 64,
        //
        // 摘要:
        //     ETC2_RGBA8 compressed color with alpha channel texture format using Crunch compression
        //     for smaller storage sizes.
        ETC2_RGBA8Crunched = 65,
        //
        // 摘要:
        //     ASTC compressed RGB(A) HDR texture format, 4x4 block size.
        ASTC_HDR_4x4 = 66,
        //
        // 摘要:
        //     ASTC compressed RGB(A) HDR texture format, 5x5 block size.
        ASTC_HDR_5x5 = 67,
        //
        // 摘要:
        //     ASTC compressed RGB(A) HDR texture format, 6x6 block size.
        ASTC_HDR_6x6 = 68,
        //
        // 摘要:
        //     ASTC compressed RGB(A) HDR texture format, 8x8 block size.
        ASTC_HDR_8x8 = 69,
        //
        // 摘要:
        //     ASTC compressed RGB(A) HDR texture format, 10x10 block size.
        ASTC_HDR_10x10 = 70,
        //
        // 摘要:
        //     ASTC compressed RGB(A) HDR texture format, 12x12 block size.
        ASTC_HDR_12x12 = 71,
        //
        // 摘要:
        //     TextureFormat.RG32 texture format.
        RG32 = 72,
        //
        // 摘要:
        //     TextureFormat.RGB48 texture format.
        RGB48 = 73,
        //
        // 摘要:
        //     TextureFormat.RGBA64 texture format.
        RGBA64 = 74
    }
}

