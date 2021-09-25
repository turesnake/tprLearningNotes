#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     A collection of common math functions.
    [Il2CppEagerStaticClassConstructionAttribute]
    [NativeHeaderAttribute("Runtime/Utilities/BitUtility.h")]
    [NativeHeaderAttribute("Runtime/Math/ColorSpaceConversion.h")]
    [NativeHeaderAttribute("Runtime/Math/FloatConversion.h")]
    [NativeHeaderAttribute("Runtime/Math/PerlinNoise.h")]
    public struct Mathf
    {
        //
        // 摘要:
        //     The well-known 3.14159265358979... value (Read Only).
        public const float PI = 3.14159274F;
        //
        // 摘要:
        //     A representation of positive infinity (Read Only).
        public const float Infinity = float.PositiveInfinity;
        //
        // 摘要:
        //     A representation of negative infinity (Read Only).
        public const float NegativeInfinity = float.NegativeInfinity;
        //
        // 摘要:
        //     Degrees-to-radians conversion constant (Read Only).
        public const float Deg2Rad = 0.0174532924F;
        //
        // 摘要:
        //     Radians-to-degrees conversion constant (Read Only).
        public const float Rad2Deg = 57.29578F;
        //
        // 摘要:
        //     A tiny floating point value (Read Only).
        public static readonly float Epsilon;

        //
        // 摘要:
        //     Returns the absolute value of f.
        //
        // 参数:
        //   f:
        public static float Abs(float f);
        //
        // 摘要:
        //     Returns the absolute value of value.
        //
        // 参数:
        //   value:
        public static int Abs(int value);

        /*
         摘要:
             Returns the arc-cosine of f - the angle in radians whose cosine is f.
        
         参数:
           f: 必须位于 [-1,1] 区间, 否则本函数将计算出 NaN 
        */
        public static float Acos(float f);

        //
        // 摘要:
        //     Compares two floating point values and returns true if they are similar.
        //
        // 参数:
        //   a:
        //
        //   b:
        public static bool Approximately(float a, float b);
        //
        // 摘要:
        //     Returns the arc-sine of f - the angle in radians whose sine is f.
        //
        // 参数:
        //   f:
        public static float Asin(float f);
        //
        // 摘要:
        //     Returns the arc-tangent of f - the angle in radians whose tangent is f.
        //
        // 参数:
        //   f:
        public static float Atan(float f);
        //
        // 摘要:
        //     Returns the angle in radians whose Tan is y/x.
        //
        // 参数:
        //   y:
        //
        //   x:
        public static float Atan2(float y, float x);
        //
        // 摘要:
        //     Returns the smallest integer greater to or equal to f.
        //
        // 参数:
        //   f:
        public static float Ceil(float f);
        //
        // 摘要:
        //     Returns the smallest integer greater to or equal to f.
        //
        // 参数:
        //   f:
        public static int CeilToInt(float f);
        //
        // 摘要:
        //     Clamps the given value between a range defined by the given minimum integer and
        //     maximum integer values. Returns the given value if it is within min and max.
        //
        // 参数:
        //   value:
        //     The integer point value to restrict inside the min-to-max range.
        //
        //   min:
        //     The minimum integer point value to compare against.
        //
        //   max:
        //     The maximum integer point value to compare against.
        //
        // 返回结果:
        //     The int result between min and max values.
        public static int Clamp(int value, int min, int max);
        //
        // 摘要:
        //     Clamps the given value between the given minimum float and maximum float values.
        //     Returns the given value if it is within the minimum and maximum range.
        //
        // 参数:
        //   value:
        //     The floating point value to restrict inside the range defined by the minimum
        //     and maximum values.
        //
        //   min:
        //     The minimum floating point value to compare against.
        //
        //   max:
        //     The maximum floating point value to compare against.
        //
        // 返回结果:
        //     The float result between the minimum and maximum values.
        public static float Clamp(float value, float min, float max);
        //
        // 摘要:
        //     Clamps value between 0 and 1 and returns value.
        //
        // 参数:
        //   value:
        public static float Clamp01(float value);
        //
        // 摘要:
        //     Returns the closest power of two value.
        //
        // 参数:
        //   value:
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static int ClosestPowerOfTwo(int value);
        //
        // 摘要:
        //     Convert a color temperature in Kelvin to RGB color.
        //
        // 参数:
        //   kelvin:
        //     Temperature in Kelvin. Range 1000 to 40000 Kelvin.
        //
        // 返回结果:
        //     Correlated Color Temperature as floating point RGB color.
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static Color CorrelatedColorTemperatureToRGB(float kelvin);
        //
        // 摘要:
        //     Returns the cosine of angle f.
        //
        // 参数:
        //   f:
        //     The input angle, in radians.
        //
        // 返回结果:
        //     The return value between -1 and 1.
        public static float Cos(float f);

        /*
            摘要:
                Calculates the shortest difference between two given angles given in degrees.
                因为角度始终在 0-360 内打转, 可用此函数 快速计算出, 任意两角度之间的 夹角
        */
        public static float DeltaAngle(float current, float target);
        //
        // 摘要:
        //     Returns e raised to the specified power.
        //
        // 参数:
        //   power:
        public static float Exp(float power);
        //
        // 摘要:
        //     Encode a floating point value into a 16-bit representation.
        //
        // 参数:
        //   val:
        //     The floating point value to convert.
        //
        // 返回结果:
        //     The converted half-precision float, stored in a 16-bit unsigned integer.
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static ushort FloatToHalf(float val);
        //
        // 摘要:
        //     Returns the largest integer smaller than or equal to f.
        //
        // 参数:
        //   f:
        public static float Floor(float f);
        //
        // 摘要:
        //     Returns the largest integer smaller to or equal to f.
        //
        // 参数:
        //   f:
        public static int FloorToInt(float f);
        public static float Gamma(float value, float absmax, float gamma);
        //
        // 摘要:
        //     Converts the given value from gamma (sRGB) to linear color space.
        //
        // 参数:
        //   value:
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static float GammaToLinearSpace(float value);
        //
        // 摘要:
        //     Convert a half precision float to a 32-bit floating point value.
        //
        // 参数:
        //   val:
        //     The half precision value to convert.
        //
        // 返回结果:
        //     The decoded 32-bit float.
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static float HalfToFloat(ushort val);
        //
        // 摘要:
        //     Calculates the linear parameter t that produces the interpolant value within
        //     the range [a, b].
        //
        // 参数:
        //   a:
        //     Start value.
        //
        //   b:
        //     End value.
        //
        //   value:
        //     Value between start and end.
        //
        // 返回结果:
        //     Percentage of value between start and end.
        public static float InverseLerp(float a, float b, float value);
        //
        // 摘要:
        //     Returns true if the value is power of two.
        //
        // 参数:
        //   value:
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static bool IsPowerOfTwo(int value);
        //
        // 摘要:
        //     Linearly interpolates between a and b by t.
        //
        // 参数:
        //   a:
        //     The start value.
        //
        //   b:
        //     The end value.
        //
        //   t:
        //     The interpolation value between the two floats.
        //
        // 返回结果:
        //     The interpolated float result between the two float values.
        public static float Lerp(float a, float b, float t);
        //
        // 摘要:
        //     Same as Lerp but makes sure the values interpolate correctly when they wrap around
        //     360 degrees.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   t:
        public static float LerpAngle(float a, float b, float t);
        //
        // 摘要:
        //     Linearly interpolates between a and b by t with no limit to t.
        //
        // 参数:
        //   a:
        //     The start value.
        //
        //   b:
        //     The end value.
        //
        //   t:
        //     The interpolation between the two floats.
        //
        // 返回结果:
        //     The float value as a result from the linear interpolation.
        public static float LerpUnclamped(float a, float b, float t);
        //
        // 摘要:
        //     Converts the given value from linear to gamma (sRGB) color space.
        //
        // 参数:
        //   value:
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static float LinearToGammaSpace(float value);
        //
        // 摘要:
        //     Returns the logarithm of a specified number in a specified base.
        //
        // 参数:
        //   f:
        //
        //   p:
        public static float Log(float f, float p);
        //
        // 摘要:
        //     Returns the natural (base e) logarithm of a specified number.
        //
        // 参数:
        //   f:
        public static float Log(float f);
        //
        // 摘要:
        //     Returns the base 10 logarithm of a specified number.
        //
        // 参数:
        //   f:
        public static float Log10(float f);
        //
        // 摘要:
        //     Returns the largest of two or more values.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   values:
        public static int Max(int a, int b);
        //
        // 摘要:
        //     Returns largest of two or more values.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   values:
        public static float Max(params float[] values);
        //
        // 摘要:
        //     Returns largest of two or more values.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   values:
        public static float Max(float a, float b);
        //
        // 摘要:
        //     Returns the largest of two or more values.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   values:
        public static int Max(params int[] values);
        //
        // 摘要:
        //     Returns the smallest of two or more values.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   values:
        public static int Min(params int[] values);
        //
        // 摘要:
        //     Returns the smallest of two or more values.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   values:
        public static int Min(int a, int b);
        //
        // 摘要:
        //     Returns the smallest of two or more values.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   values:
        public static float Min(params float[] values);
        //
        // 摘要:
        //     Returns the smallest of two or more values.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   values:
        public static float Min(float a, float b);

       
        /* 
            摘要:
            Moves a value current towards target.
            将一个值从 current 移动到 target, 且移动速度不超过 maxDelta

            因为此函数只被调用了一次, 所以无法真的表达完整的 "移动过程"
            而只是仅仅移动了 "一帧"
        
         参数:
           current: The current value.
           target: The value to move towards.
           maxDelta: The maximum change that should be applied to the value.
        */
        public static float MoveTowards(float current, float target, float maxDelta);

        /*
            摘要:
                Same as MoveTowards but makes sure the values interpolate correctly when they
                wrap around 360 degrees.
                可专门用于 角度的过度

                因为此函数只被调用了一次, 所以无法真的表达完整的 "转动过程"
                而只是仅仅转动了 "一帧"
            参数:
                maxDelta:
        */
        public static float MoveTowardsAngle(float current, float target, float maxDelta);

        //
        // 摘要:
        //     Returns the next power of two that is equal to, or greater than, the argument.
        //
        // 参数:
        //   value:
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static int NextPowerOfTwo(int value);
        //
        // 摘要:
        //     Generate 2D Perlin noise.
        //
        // 参数:
        //   x:
        //     X-coordinate of sample point.
        //
        //   y:
        //     Y-coordinate of sample point.
        //
        // 返回结果:
        //     Value between 0.0 and 1.0. (Return value might be slightly below 0.0 or beyond
        //     1.0.)
        [FreeFunctionAttribute("PerlinNoise::NoiseNormalized", IsThreadSafe = true)]
        public static float PerlinNoise(float x, float y);
        //
        // 摘要:
        //     PingPong returns a value that will increment and decrement between the value
        //     0 and length.
        //
        // 参数:
        //   t:
        //
        //   length:
        public static float PingPong(float t, float length);

        
        /* 摘要:
            Returns f raised to power p.
            如:
                Pow( 2f, 3f ) = 8f;
         参数:
           f: 底数
           p: 指数
        */
        public static float Pow(float f, float p);

        //
        // 摘要:
        //     Loops the value t, so that it is never larger than length and never smaller than
        //     0.
        //
        // 参数:
        //   t:
        //
        //   length:
        public static float Repeat(float t, float length);
        //
        // 摘要:
        //     Returns f rounded to the nearest integer.
        //
        // 参数:
        //   f:
        public static float Round(float f);
        //
        // 摘要:
        //     Returns f rounded to the nearest integer.
        //
        // 参数:
        //   f:
        public static int RoundToInt(float f);
        //
        // 摘要:
        //     Returns the sign of f.
        //
        // 参数:
        //   f:
        public static float Sign(float f);
        //
        // 摘要:
        //     Returns the sine of angle f.
        //
        // 参数:
        //   f:
        //     The input angle, in radians.
        //
        // 返回结果:
        //     The return value between -1 and +1.
        public static float Sin(float f);
        [ExcludeFromDocs]
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed);
        [ExcludeFromDocs]
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime);
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime);
        [ExcludeFromDocs]
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed);
        [ExcludeFromDocs]
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime);
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime);
        //
        // 摘要:
        //     Interpolates between min and max with smoothing at the limits.
        //
        // 参数:
        //   from:
        //
        //   to:
        //
        //   t:
        public static float SmoothStep(float from, float to, float t);
        //
        // 摘要:
        //     Returns square root of f.
        //
        // 参数:
        //   f:
        public static float Sqrt(float f);
        //
        // 摘要:
        //     Returns the tangent of angle f in radians.
        //
        // 参数:
        //   f:
        public static float Tan(float f);
    }
}
