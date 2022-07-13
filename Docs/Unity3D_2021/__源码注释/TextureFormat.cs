#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    /*
        Format used when creating textures from scripts.

        Note that not all graphics cards support all texture formats, use "SystemInfo.SupportsTextureFormat()" to check. 
        Also, only the Texture2D class supports texture creation from script with "Crunch compression texture formats".


        ----------------------
        Crunch compression
        Crunch is a compression format that works on top of DXT or ETC compression, by providing additional variable bit rate compression. 
        When Unity loads a Crunch-compressed texture, it decompresses the texture to DXT or ETC on the CPU, 
        and then uploads the DXT or ETC compressed texture data to the GPU.

        Crunch compression helps the texture use the lowest possible amount of disk space, but has no effect on runtime memory usage. 
        Crunch textures can take a long time to compress, but decompression at runtime is fairly fast. 
        You can adjust how lossy Crunch compression is, to strike a balance between file size and quality.

        If you are particularly concerned about the size of your build and Crunch is supported on your target platform, 
        consider adding Crunch compression.

    */
    public enum TextureFormat//TextureFormat__RR
    {
        ATC_RGB4 = -127,
        ATC_RGBA8 = -127,
        PVRTC_2BPP_RGB = -127,
        PVRTC_2BPP_RGBA = -127,
        PVRTC_4BPP_RGB = -127,
        PVRTC_4BPP_RGBA = -127,
        //
        // 摘要:
        //     Alpha-only texture format, 8 bit integer.
        Alpha8 = 1,
        //
        // 摘要:
        //     A 16 bits/pixel texture format. Texture stores color with an alpha channel.
        ARGB4444 = 2,
        //
        // 摘要:
        //     Color texture format, 8-bits per channel.
        RGB24 = 3,
        //
        // 摘要:
        //     Color with alpha texture format, 8-bits per channel.
        RGBA32 = 4,

        /*
            Color with alpha texture format, 8-bits per channel.

            Each of RGBA color channels is stored as an 8-bit value in [0..1] range. 
            In memory, the channel data is ordered this way: A, R, G, B bytes one after another.

            Note that "RGBA32" format might be slightly more efficient as the data layout in memory more closely 
            matches what the graphics APIs expect.
            ---
            相比而言, "RGBA32" 的存储更高效;
        */
        ARGB32 = 5,


        //
        // 摘要:
        //     A 16 bit color texture format.
        RGB565 = 7,
        //
        // 摘要:
        //     Single channel (R) texture format, 16 bit integer.
        R16 = 9,
        //
        // 摘要:
        //     Compressed color texture format.
        DXT1 = 10,
        //
        // 摘要:
        //     Compressed color with alpha channel texture format.
        DXT5 = 12,
        //
        // 摘要:
        //     Color and alpha texture format, 4 bit per channel.
        RGBA4444 = 13,
        //
        // 摘要:
        //     Color with alpha texture format, 8-bits per channel.
        BGRA32 = 14,

        //
        // 摘要:
        //     Scalar (R) texture format, 16 bit floating point.
        RHalf = 15,

        //
        // 摘要:
        //     Two color (RG) texture format, 16 bit floating point per channel.
        RGHalf = 16,
        //
        // 摘要:
        //     RGB color and alpha texture format, 16 bit floating point per channel.
        RGBAHalf = 17,
        //
        // 摘要:
        //     Scalar (R) texture format, 32 bit floating point.
        RFloat = 18,
        //
        // 摘要:
        //     Two color (RG) texture format, 32 bit floating point per channel.
        RGFloat = 19,
        //
        // 摘要:
        //     RGB color and alpha texture format, 32-bit floats per channel.
        RGBAFloat = 20,
        //
        // 摘要:
        //     A format that uses the YUV color space and is often used for video encoding or
        //     playback.
        YUY2 = 21,
        //
        // 摘要:
        //     RGB HDR format, with 9 bit mantissa per channel and a 5 bit shared exponent.
        RGB9e5Float = 22,
        //
        // 摘要:
        //     HDR compressed color texture format.
        BC6H = 24,
        //
        // 摘要:
        //     High quality compressed color texture format.
        BC7 = 25,
        //
        // 摘要:
        //     Compressed one channel (R) texture format.
        BC4 = 26,
        //
        // 摘要:
        //     Compressed two-channel (RG) texture format.
        BC5 = 27,
        //
        // 摘要:
        //     Compressed color texture format with Crunch compression for smaller storage sizes.
        DXT1Crunched = 28,
        //
        // 摘要:
        //     Compressed color with alpha channel texture format with Crunch compression for
        //     smaller storage sizes.
        DXT5Crunched = 29,
        //
        // 摘要:
        //     PowerVR (iOS) 2 bits/pixel compressed color texture format.
        PVRTC_RGB2 = 30,
        //
        // 摘要:
        //     PowerVR (iOS) 2 bits/pixel compressed with alpha channel texture format.
        PVRTC_RGBA2 = 31,
        //
        // 摘要:
        //     PowerVR (iOS) 4 bits/pixel compressed color texture format.
        PVRTC_RGB4 = 32,
        //
        // 摘要:
        //     PowerVR (iOS) 4 bits/pixel compressed with alpha channel texture format.
        PVRTC_RGBA4 = 33,
        //
        // 摘要:
        //     ETC (GLES2.0) 4 bits/pixel compressed RGB texture format.
        ETC_RGB4 = 34,
        //
        // 摘要:
        //     ETC2 EAC (GL ES 3.0) 4 bitspixel compressed unsigned single-channel texture format.
        EAC_R = 41,
        //
        // 摘要:
        //     ETC2 EAC (GL ES 3.0) 4 bitspixel compressed signed single-channel texture format.
        EAC_R_SIGNED = 42,
        //
        // 摘要:
        //     ETC2 EAC (GL ES 3.0) 8 bitspixel compressed unsigned dual-channel (RG) texture
        //     format.
        EAC_RG = 43,
        //
        // 摘要:
        //     ETC2 EAC (GL ES 3.0) 8 bitspixel compressed signed dual-channel (RG) texture
        //     format.
        EAC_RG_SIGNED = 44,
        //
        // 摘要:
        //     ETC2 (GL ES 3.0) 4 bits/pixel compressed RGB texture format.
        ETC2_RGB = 45,
        //
        // 摘要:
        //     ETC2 (GL ES 3.0) 4 bits/pixel RGB+1-bit alpha texture format.
        ETC2_RGBA1 = 46,
        //
        // 摘要:
        //     ETC2 (GL ES 3.0) 8 bits/pixel compressed RGBA texture format.
        ETC2_RGBA8 = 47,
        //
        // 摘要:
        //     ASTC (4x4 pixel block in 128 bits) compressed RGB(A) texture format.
        ASTC_4x4 = 48,
        //
        // 摘要:
        //     ASTC (4x4 pixel block in 128 bits) compressed RGB texture format.
        ASTC_RGB_4x4 = 48,
        //
        // 摘要:
        //     ASTC (5x5 pixel block in 128 bits) compressed RGB(A) texture format.
        ASTC_5x5 = 49,
        //
        // 摘要:
        //     ASTC (5x5 pixel block in 128 bits) compressed RGB texture format.
        ASTC_RGB_5x5 = 49,
        //
        // 摘要:
        //     ASTC (6x6 pixel block in 128 bits) compressed RGB(A) texture format.
        ASTC_6x6 = 50,
        //
        // 摘要:
        //     ASTC (6x6 pixel block in 128 bits) compressed RGB texture format.
        ASTC_RGB_6x6 = 50,
        //
        // 摘要:
        //     ASTC (8x8 pixel block in 128 bits) compressed RGB(A) texture format.
        ASTC_8x8 = 51,
        //
        // 摘要:
        //     ASTC (8x8 pixel block in 128 bits) compressed RGB texture format.
        ASTC_RGB_8x8 = 51,
        //
        // 摘要:
        //     ASTC (10x10 pixel block in 128 bits) compressed RGB(A) texture format.
        ASTC_10x10 = 52,
        //
        // 摘要:
        //     ASTC (10x10 pixel block in 128 bits) compressed RGB texture format.
        ASTC_RGB_10x10 = 52,
        //
        // 摘要:
        //     ASTC (12x12 pixel block in 128 bits) compressed RGB(A) texture format.
        ASTC_12x12 = 53,
        //
        // 摘要:
        //     ASTC (12x12 pixel block in 128 bits) compressed RGB texture format.
        ASTC_RGB_12x12 = 53,
        //
        // 摘要:
        //     ASTC (4x4 pixel block in 128 bits) compressed RGBA texture format.
        ASTC_RGBA_4x4 = 54,
        //
        // 摘要:
        //     ASTC (5x5 pixel block in 128 bits) compressed RGBA texture format.
        ASTC_RGBA_5x5 = 55,
        //
        // 摘要:
        //     ASTC (6x6 pixel block in 128 bits) compressed RGBA texture format.
        ASTC_RGBA_6x6 = 56,
        //
        // 摘要:
        //     ASTC (8x8 pixel block in 128 bits) compressed RGBA texture format.
        ASTC_RGBA_8x8 = 57,
        //
        // 摘要:
        //     ASTC (10x10 pixel block in 128 bits) compressed RGBA texture format.
        ASTC_RGBA_10x10 = 58,
        //
        // 摘要:
        //     ASTC (12x12 pixel block in 128 bits) compressed RGBA texture format.
        ASTC_RGBA_12x12 = 59,
        //
        // 摘要:
        //     ETC 4 bits/pixel compressed RGB texture format.
        ETC_RGB4_3DS = 60,
        //
        // 摘要:
        //     ETC 4 bitspixel RGB + 4 bitspixel Alpha compressed texture format.
        ETC_RGBA8_3DS = 61,
        //
        // 摘要:
        //     Two color (RG) texture format, 8-bits per channel.
        RG16 = 62,

        /*
            Single channel (R) texture format, 8 bit integer.
            Currently, this texture format is only useful for runtime or native code plugins 
            as there is no support for texture importing for this format.
            ---
            这种格式的 texture 不能被直接 import, 只能在运行时, 或插件代码中 动态生成;
        */
        R8 = 63,

        //
        // 摘要:
        //     Compressed color texture format with Crunch compression for smaller storage sizes.
        ETC_RGB4Crunched = 64,
        //
        // 摘要:
        //     Compressed color with alpha channel texture format using Crunch compression for
        //     smaller storage sizes.
        ETC2_RGBA8Crunched = 65,
        //
        // 摘要:
        //     ASTC (4x4 pixel block in 128 bits) compressed RGB(A) HDR texture format.
        ASTC_HDR_4x4 = 66,
        //
        // 摘要:
        //     ASTC (5x5 pixel block in 128 bits) compressed RGB(A) HDR texture format.
        ASTC_HDR_5x5 = 67,
        //
        // 摘要:
        //     ASTC (6x6 pixel block in 128 bits) compressed RGB(A) HDR texture format.
        ASTC_HDR_6x6 = 68,
        //
        // 摘要:
        //     ASTC (8x8 pixel block in 128 bits) compressed RGB(A) texture format.
        ASTC_HDR_8x8 = 69,
        //
        // 摘要:
        //     ASTC (10x10 pixel block in 128 bits) compressed RGB(A) HDR texture format.
        ASTC_HDR_10x10 = 70,
        //
        // 摘要:
        //     ASTC (12x12 pixel block in 128 bits) compressed RGB(A) HDR texture format.
        ASTC_HDR_12x12 = 71,
        //
        // 摘要:
        //     Two channel (RG) texture format, 16 bit integer per channel.
        RG32 = 72,
        //
        // 摘要:
        //     Three channel (RGB) texture format, 16 bit integer per channel.
        RGB48 = 73,
        //
        // 摘要:
        //     Four channel (RGBA) texture format, 16 bit integer per channel.
        RGBA64 = 74
    }
}

