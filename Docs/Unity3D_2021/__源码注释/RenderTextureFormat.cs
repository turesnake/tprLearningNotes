#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    //
    // 摘要:
    //     Format of a RenderTexture.
    public enum RenderTextureFormat
    {
        //
        // 摘要:
        //     Color render texture format, 8 bits per channel.
        ARGB32 = 0,


        /*
            摘要:
            A depth render texture format.

            此 format 被用来将 "高精度 depth 值" 渲染进 render texture 中;

            具体使用哪种 format 由平台而定;
            -- On OpenGL it is the native "depth component" format (usually 24 or 16 bits)
            -- on Direct3D9 it is the 32 bit floating point ("R32F") format

            在编写 "使用 或 写入 depth texture" 的 shader 时, 要小心这些代码是否能被 opengl 和 d3d 同时支持;
            参考:
                https://docs.unity3d.com/2021.1/Documentation/Manual/SL-CameraDepthTexture.html

            注意,
            不是所有 图形卡都支持 depth texture, 使用 SystemInfo.SupportsRenderTextureFormat() 来查找;
        */
        Depth = 1,


        //
        // 摘要:
        //     Color render texture format, 16 bit floating point per channel.
        ARGBHalf = 2,
        //
        // 摘要:
        //     A native shadowmap render texture format.
        Shadowmap = 3,
        //
        // 摘要:
        //     Color render texture format.
        RGB565 = 4,
        //
        // 摘要:
        //     Color render texture format, 4 bit per channel.
        ARGB4444 = 5,
        //
        // 摘要:
        //     Color render texture format, 1 bit for Alpha channel, 5 bits for Red, Green and
        //     Blue channels.
        ARGB1555 = 6,
        //
        // 摘要:
        //     Default color render texture format: will be chosen accordingly to Frame Buffer
        //     format and Platform.
        Default = 7,
        //
        // 摘要:
        //     Color render texture format. 10 bits for colors, 2 bits for alpha.
        ARGB2101010 = 8,
        //
        // 摘要:
        //     Default HDR color render texture format: will be chosen accordingly to Frame
        //     Buffer format and Platform.
        DefaultHDR = 9,
        //
        // 摘要:
        //     Four color render texture format, 16 bits per channel, fixed point, unsigned
        //     normalized.
        ARGB64 = 10,
        //
        // 摘要:
        //     Color render texture format, 32 bit floating point per channel.
        ARGBFloat = 11,
        //
        // 摘要:
        //     Two color (RG) render texture format, 32 bit floating point per channel.
        RGFloat = 12,
        //
        // 摘要:
        //     Two color (RG) render texture format, 16 bit floating point per channel.
        RGHalf = 13,
        //
        // 摘要:
        //     Scalar (R) render texture format, 32 bit floating point.
        RFloat = 14,
        //
        // 摘要:
        //     Scalar (R) render texture format, 16 bit floating point.
        RHalf = 15,
        //
        // 摘要:
        //     Single channel (R) render texture format, 8 bit integer.
        R8 = 16,
        //
        // 摘要:
        //     Four channel (ARGB) render texture format, 32 bit signed integer per channel.
        ARGBInt = 17,
        //
        // 摘要:
        //     Two channel (RG) render texture format, 32 bit signed integer per channel.
        RGInt = 18,
        //
        // 摘要:
        //     Scalar (R) render texture format, 32 bit signed integer.
        RInt = 19,
        //
        // 摘要:
        //     Color render texture format, 8 bits per channel.
        BGRA32 = 20,
        //
        // 摘要:
        //     Color render texture format. R and G channels are 11 bit floating point, B channel
        //     is 10 bit floating point.
        RGB111110Float = 22,
        //
        // 摘要:
        //     Two color (RG) render texture format, 16 bits per channel, fixed point, unsigned
        //     normalized.
        RG32 = 23,
        //
        // 摘要:
        //     Four channel (RGBA) render texture format, 16 bit unsigned integer per channel.
        RGBAUShort = 24,
        //
        // 摘要:
        //     Two channel (RG) render texture format, 8 bits per channel.
        RG16 = 25,
        //
        // 摘要:
        //     Color render texture format, 10 bit per channel, extended range.
        BGRA10101010_XR = 26,
        //
        // 摘要:
        //     Color render texture format, 10 bit per channel, extended range.
        BGR101010_XR = 27,
        //
        // 摘要:
        //     Single channel (R) render texture format, 16 bit integer.
        R16 = 28
    }
}