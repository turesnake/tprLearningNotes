#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Reflection;

namespace UnityEngine
{
    //
    // 摘要:
    //     Representation of RGBA colors.
    [DefaultMember("Item")]
    [NativeClassAttribute("ColorRGBAf")]
    [NativeHeaderAttribute("Runtime/Math/Color.h")]
    [RequiredByNativeCodeAttribute(Optional = true, GenerateProxy = true)]
    public struct Color : IEquatable<Color>, IFormattable
    {
        //
        // 摘要:
        //     Red component of the color.
        public float r;
        //
        // 摘要:
        //     Green component of the color.
        public float g;
        //
        // 摘要:
        //     Blue component of the color.
        public float b;
        //
        // 摘要:
        //     Alpha component of the color (0 is transparent, 1 is opaque).
        public float a;

        //
        // 摘要:
        //     Constructs a new Color with given r,g,b components and sets a to 1.
        //
        // 参数:
        //   r:
        //     Red component.
        //
        //   g:
        //     Green component.
        //
        //   b:
        //     Blue component.
        public Color(float r, float g, float b);
        //
        // 摘要:
        //     Constructs a new Color with given r,g,b,a components.
        //
        // 参数:
        //   r:
        //     Red component.
        //
        //   g:
        //     Green component.
        //
        //   b:
        //     Blue component.
        //
        //   a:
        //     Alpha component.
        public Color(float r, float g, float b, float a);

        public float this[int index] { get; set; }

        //
        // 摘要:
        //     Yellow. RGBA is (1, 0.92, 0.016, 1), but the color is nice to look at!
        public static Color yellow { get; }
        //
        // 摘要:
        //     Completely transparent. RGBA is (0, 0, 0, 0).
        public static Color clear { get; }
        //
        // 摘要:
        //     English spelling for gray. RGBA is the same (0.5, 0.5, 0.5, 1).
        public static Color grey { get; }
        //
        // 摘要:
        //     Gray. RGBA is (0.5, 0.5, 0.5, 1).
        public static Color gray { get; }
        //
        // 摘要:
        //     Magenta. RGBA is (1, 0, 1, 1).
        public static Color magenta { get; }
        //
        // 摘要:
        //     Cyan. RGBA is (0, 1, 1, 1).
        public static Color cyan { get; }
        //
        // 摘要:
        //     Solid red. RGBA is (1, 0, 0, 1).
        public static Color red { get; }
        //
        // 摘要:
        //     Solid black. RGBA is (0, 0, 0, 1).
        public static Color black { get; }
        //
        // 摘要:
        //     Solid white. RGBA is (1, 1, 1, 1).
        public static Color white { get; }
        //
        // 摘要:
        //     Solid blue. RGBA is (0, 0, 1, 1).
        public static Color blue { get; }
        //
        // 摘要:
        //     Solid green. RGBA is (0, 1, 0, 1).
        public static Color green { get; }
        //
        // 摘要:
        //     A version of the color that has had the gamma curve applied.
        public Color gamma { get; }
        //
        // 摘要:
        //     A linear value of an sRGB color.
        public Color linear { get; }
        //
        // 摘要:
        //     The grayscale value of the color. (Read Only)
        public float grayscale { get; }
        //
        // 摘要:
        //     Returns the maximum color component value: Max(r,g,b).
        public float maxColorComponent { get; }

        //
        // 摘要:
        //     Creates an RGB colour from HSV input.
        //
        // 参数:
        //   H:
        //     Hue [0..1].
        //
        //   S:
        //     Saturation [0..1].
        //
        //   V:
        //     Brightness value [0..1].
        //
        //   hdr:
        //     Output HDR colours. If true, the returned colour will not be clamped to [0..1].
        //
        // 返回结果:
        //     An opaque colour with HSV matching the input.
        public static Color HSVToRGB(float H, float S, float V);
        //
        // 摘要:
        //     Creates an RGB colour from HSV input.
        //
        // 参数:
        //   H:
        //     Hue [0..1].
        //
        //   S:
        //     Saturation [0..1].
        //
        //   V:
        //     Brightness value [0..1].
        //
        //   hdr:
        //     Output HDR colours. If true, the returned colour will not be clamped to [0..1].
        //
        // 返回结果:
        //     An opaque colour with HSV matching the input.
        public static Color HSVToRGB(float H, float S, float V, bool hdr);
        //
        // 摘要:
        //     Linearly interpolates between colors a and b by t.
        //
        // 参数:
        //   a:
        //     Color a.
        //
        //   b:
        //     Color b.
        //
        //   t:
        //     Float for combining a and b.
        public static Color Lerp(Color a, Color b, float t);
        //
        // 摘要:
        //     Linearly interpolates between colors a and b by t.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   t:
        public static Color LerpUnclamped(Color a, Color b, float t);
        public static void RGBToHSV(Color rgbColor, out float H, out float S, out float V);
        public bool Equals(Color other);
        public override bool Equals(object other);
        public override int GetHashCode();
        //
        // 摘要:
        //     Returns a formatted string of this color.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public string ToString(string format, IFormatProvider formatProvider);
        //
        // 摘要:
        //     Returns a formatted string of this color.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public override string ToString();
        //
        // 摘要:
        //     Returns a formatted string of this color.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public string ToString(string format);

        public static Color operator +(Color a, Color b);
        public static Color operator -(Color a, Color b);
        public static Color operator *(float b, Color a);
        public static Color operator *(Color a, float b);
        public static Color operator *(Color a, Color b);
        public static Color operator /(Color a, float b);
        public static bool operator ==(Color lhs, Color rhs);
        public static bool operator !=(Color lhs, Color rhs);


        /* 
            实践可知, Color.rgba 和 Vector4.xyzw 其实是完全相同的; 
            如果 color 是 HDR 的, 那么它的 rgba 值会超过 1f;

            此处的转换, 其实就是 rgba 和 xyzw 的直接转换;
        */
        public static implicit operator Color(Vector4 v);
        public static implicit operator Vector4(Color c);
    }
}

