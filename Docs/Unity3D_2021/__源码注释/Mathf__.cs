#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using UnityEngine.Internal;

namespace UnityEngine
{
    /*
        摘要:
        A collection of common math functions.
    */
    [Il2CppEagerStaticClassConstructionAttribute]
    [NativeHeaderAttribute("Runtime/Utilities/BitUtility.h")]
    [NativeHeaderAttribute("Runtime/Math/ColorSpaceConversion.h")]
    [NativeHeaderAttribute("Runtime/Math/FloatConversion.h")]
    [NativeHeaderAttribute("Runtime/Math/PerlinNoise.h")]
    public struct Mathf//Mathf__
    {
        
        // 摘要:
        //     The well-known 3.14159265358979... value (Read Only).
        public const float PI = 3.14159274F;

        
        // 摘要:
        //     A representation of positive infinity (Read Only).
        public const float Infinity = float.PositiveInfinity;

        
        // 摘要:
        //     A representation of negative infinity (Read Only).
        public const float NegativeInfinity = float.NegativeInfinity;

        
        // 摘要:
        //     Degrees-to-radians conversion constant (Read Only). = (PI * 2) / 360
        public const float Deg2Rad = 0.0174532924F;

        
        // 摘要:
        //     Radians-to-degrees conversion constant (Read Only). = 360 / (PI * 2)
        public const float Rad2Deg = 57.29578F;

        /*
            摘要:
            A tiny floating point value (Read Only).

            float 类型能拥有的 大于 0 的最小数值;
                -- anyValue + Epsilon = anyValue
                -- anyValue - Epsilon = anyValue
                -- 0 + Epsilon = Epsilon
                -- 0 - Epsilon = -Epsilon

            A value Between any number and Epsilon will result in an arbitrary number due to truncating errors.
            (没看懂)
        */
        public static readonly float Epsilon;

        
        // 摘要:
        //     Returns the absolute value of f.
        public static float Abs(float f);
        public static int Abs(int value);


        /*
         摘要:
            Returns the arc-cosine of f
        
         参数:
           f: 
            the angle in radians whose cosine is f
            必须位于 [-1,1] 区间, 否则本函数将计算出 NaN 
        */
        public static float Acos(float f);



        /*
            摘要:
            Compares two floating point values and returns true if they are similar.

            只要比较的两值之间的差值 小于 Mathf.Epsilon, 就认定这两个 float值 相等;
        */
        public static bool Approximately(float a, float b);


        /*
            摘要:
            Returns the arc-sine of f
        
            参数:
            f:
                the angle in radians whose sine is f.
                必须位于区间 [-1,1]
        */
        public static float Asin(float f);


        /*
            摘要:
            Returns the arc-tangent of f

            参数:
            f:
                the angle in radians whose tangent is f.
        */
        public static float Atan(float f);


        /*
            摘要:
            Returns the angle in radians whose Tan is y/x.

            注意:
                本函数能正确处理 "x为0" 这个情况, 此时将返回 0;
                而不是抛出 "除0" 异常;
        
            参数:
            y:
                目标角的 对边
            x:
                目标角的 临边
        */
        public static float Atan2(float y, float x);


        /*
            摘要:
            Returns the smallest integer greater to or equal to f.
            返回 f 的右侧整数; (若 f 是整数, 返回自己)
        */
        public static float Ceil(float f);

        // 摘要:
        //     Returns the smallest integer greater to or equal to f.
        //     大于等于 f 的整数
        public static int CeilToInt(float f);


        /*
            摘要:
            Clamps the given value between a range defined by the given minimum and
            maximum values. Returns the given value if it is within min and max.

            注意:
                如果 参数 min 大于 max, 本函数能返回值, 不过这个值也没啥意义 (毕竟 range 都错了)

        // 参数:
        //   value:
        //     The value to restrict inside the min-to-max range.
        //
        //   min:
        //     The minimum value to compare against. (包含此值)
        //
        //   max:
        //     The maximum value to compare against. (包含此值)
        //
        // 返回结果:
        //     The result between min and max values.
        */
        public static int Clamp(int value, int min, int max);
        public static float Clamp(float value, float min, float max);


        
        // 摘要:
        //     Clamps value between 0 and 1 and returns value.
        public static float Clamp01(float value);


        /*
            摘要:
            Returns the closest power of two value.

            返回离 参数 value 最近的 2^x 值;
            可以比 value 大, 也可以比它小;
        */
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static int ClosestPowerOfTwo(int value);


        /*
            摘要:
            Convert a color temperature in Kelvin to RGB color.

            Curve fit error is max 0.008.

            "Correlated color temperature":
                is defined as the color temperature of the electromagnetic radiation emitted from 
                an ideal black body with its surface temperature given in degrees Kelvin.
                ---
                被定义为从 理想黑体 发出的电磁辐射的色温，其表面温度以开尔文度表示。
        
        // 参数:
        //   kelvin:
        //     Temperature in Kelvin. Range 1000 to 40000 Kelvin.
        //
        // 返回结果:
        //     Correlated Color Temperature as floating point RGB color.
        */
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static Color CorrelatedColorTemperatureToRGB(float kelvin);


        /*
            摘要:
            Returns the cosine of angle f. 参数 弧度

            注意:
                本函数的参数 存在一个接收区间, 每个平台的区间定义都不同;
                在 windows 上, 区间为: [-9223372036854775295, 9223372036854775295]
                ---
                如果 参数超出此区间, 本函数直接返回 参数值, 而不会抛出异常;
        
        // 参数:
        //   f:
        //     The input angle, in radians.
        //
        // 返回结果:
        //     The return value between -1 and 1.
        */
        public static float Cos(float f);



        /*
            摘要:
                Calculates the shortest difference between two given angles given in degrees.
                因为角度始终在 0-360 内打转, 可用此函数 快速计算出, 任意两角度之间的 夹角
        */
        public static float DeltaAngle(float current, float target);


        /*
            摘要:
            Returns e raised to the specified power.
            返回: e^power
        */
        public static float Exp(float power);


        /*
            摘要:
            Encode a floating point value into a 16-bit representation.

            Converting a float to a half causes it to lose precision and also 
            reduces the maximum range of values it can represent. 
            
            The new range is [-65.504, 65.504] 
            For more information on 16-bit floating-point numbers, 
            and for information on how precision changes over the range of values, 参见:
            https://en.wikipedia.org/wiki/Half-precision_floating-point_format

            如果参数 恰好落在两个 short 值的正中间, 本函数更偏向那个 "离0更远" 的值;
            (Round away from zero tie-break rule)
        
        // 参数:
        //   val:
        //     The floating point value to convert.
        //
        // 返回结果:
        //     The converted half-precision float, stored in a 16-bit unsigned integer.
        */
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static ushort FloatToHalf(float val);


        /*
            摘要:
            Returns the largest integer smaller than or equal to f.
            返回位于 参数 f 左侧的整数; (如果 f自己就是整数, 那就返回自己)
        */
        public static float Floor(float f);


        /*
            Returns the largest integer smaller to or equal to f.

            小于等于 f 的最大整数;
        */
        public static int FloorToInt(float f);


        
        public static float Gamma(float value, float absmax, float gamma);


        // 摘要:
        //     Converts the given value from gamma (sRGB) to linear color space.
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static float GammaToLinearSpace(float value);


        
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


        /*
            摘要:
             Calculates the linear parameter t that produces the interpolant value within the range [a, b].

            实现细节:
            对参数 a, b, value, 都先减去a, 这样就得到: ( 0, b-a, value-a );
            然后根据这三个值来计算 t 值;

            参数 value 位于 区间 [a,b] 上 (也可能超出此区间), 本函数计算 value 在 [a,b] 上的 相对关系值 t:
            若 value 位于 [a,b], 本函数返回的 t值 位于 [0,1];
            若 value 小于 a, 本函数返回 0;
            若 value 大于 b, 本函数返回 1;

        参数:
          a:
            Start value.
          b:
            End value.
          value:
            Value between start and end.
        
        返回结果:
            Percentage of value between start and end. 返回 t 值;
        */
        public static float InverseLerp(float a, float b, float value);


        
        // 摘要:
        //     Returns true if the value is power of two.
        //
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static bool IsPowerOfTwo(int value);


        /*
            摘要:
            Linearly interpolates between a and b by t.
        
        // 参数:
        //   a:
        //     The start value.
        //   b:
        //     The end value.
        //   t:
        //     The interpolation value between the two floats. 
                此参数会被函数内部 clamp 到 [0,1]
    
        // 返回结果:
        //     The interpolated float result between the two float values.
        */
        public static float Lerp(float a, float b, float t);


        /*
            摘要:
            Same as Lerp but makes sure the values interpolate correctly when they wrap around 360 degrees.

            仍然是在 a,b 之间, 用 t做插值; 不过此处的 a,b 都是角度值; 
            这个插值是按照 圆盘上的两个角度 来做的, 而不是单纯依靠 a, b 两个数值;
            它正确的处理了 0-360 边界问题; 所以非常适用于 角度值;
        
        // 参数:
        //   a:
        //   b:
        //   t:
                此参数会被函数内部 clamp 到 [0,1]
        */
        public static float LerpAngle(float a, float b, float t);


        /*
            摘要:
            Linearly interpolates between a and b by t with no limit to t.
            
            t 允许是任何值, 也不会被函数 clamp 为 [0,1];
            当 t 超过 [0,1], 它能插值出 超过 [a,b] 区间的值;
            比如:
                LerpUnclamped( 0f, 2f, -1f ) 能得到 -2f;

        // 参数:
        //   a:
        //     The start value.
        //   b:
        //     The end value.
        //   t:
        //     The interpolation between the two floats.
                不会被 clamp 为 [0,1]
        // 返回结果:
        //     The float value as a result from the linear interpolation.
        */
        public static float LerpUnclamped(float a, float b, float t);


        
        // 摘要:
        //     Converts the given value from linear to gamma (sRGB) color space.
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static float LinearToGammaSpace(float value);


        /*
            摘要:
            Returns the logarithm of a specified number in a specified base.
            参数 p 为底数;
                Log( 8f, 2f ) 得到 3f; 

        */
        public static float Log(float f, float p);
        // 强制底数为 e; 
        public static float Log(float f);
        // 强制底数为 10;
        public static float Log10(float f);


        
        // 摘要:
        //     Returns the largest of two or more values.
        public static int Max(int a, int b);
        public static float Max(params float[] values);
        public static float Max(float a, float b);
        public static int Max(params int[] values);


        
        // 摘要:
        //     Returns the smallest of two or more values.
        public static int Min(params int[] values);
        public static int Min(int a, int b);
        public static float Min(params float[] values);
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


        /*
            摘要:
            Returns the next power of two that is equal to, or greater than, the argument.
            返回 大于等于 参数 value 的 2^x 值;
        */
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static int NextPowerOfTwo(int value);


        /*
            摘要:
            Generate 2D Perlin noise.

            参数 x,y 可以取任意值;

            返回值区间可能为 [0,1]
        
        // 参数:
        //   x:
        //     X-coordinate of sample point.
        //   y:
        //     Y-coordinate of sample point.
        // 返回结果:
        //     Value between 0.0 and 1.0. (Return value might be slightly below 0.0 or beyond
        //     1.0.)
        */
        [FreeFunctionAttribute("PerlinNoise::NoiseNormalized", IsThreadSafe = true)]
        public static float PerlinNoise(float x, float y);


        /*
            摘要:
            PingPong returns a value that will increment and decrement between the value 0 and length.

            参数:
            t:
                一个不断增大的值, 然后隔一段时间调用一次本函数;
        
            length:
        */
        public static float PingPong(float t, float length);

        
        /* 摘要:
            Returns f raised to power p.
            如:
                Pow( 2f, 3f ) = 8f;

                Pow(f,p ) = f^p
         参数:
           f: 底数
           p: 指数
        */
        public static float Pow(float f, float p);



        /*
            摘要:
            Loops the value t, so that it is never larger than length and never smaller than 0.

            本函数和 "取模" 有点类似; 只不过本函数作用于 float;
            可以理解为, 对参数 t, 在 [0,length] 区间内 "取模";

            如果 t 是一个类似 time 的不断增长的值, 那么 t 会在越过 length 后, 在此从 0 开始增长;
        
        // 参数:
        //   t:
        //
        //   length:
        */
        public static float Repeat(float t, float length);


        /*
            摘要:
            Returns f rounded to the nearest integer.

            四舍五入;
            如果 f 的小数部分为 0.5 将取 两端中的 偶数的那一个; 比如:
            Round( 1.5f ) 得到 2f
            Round( 2.5f ) 得到 2f
        
        */
        public static float Round(float f);

        // Returns f rounded to the nearest integer.
        // 若小数部分为 0.5, 就选择两侧中的 偶数;
        public static int RoundToInt(float f);



        // ret  1:  when f is positive or zero, 
        // ret -1:  when f is negative.
        public static float Sign(float f);


        /*
            摘要:
            Returns the sine of angle f.

            注意:
                本函数的参数 存在一个接收区间, 每个平台的区间定义都不同;
                在 windows 上, 区间为: [-9223372036854775295, 9223372036854775295]
                ---
                如果 参数超出此区间, 本函数直接返回 参数值, 而不会抛出异常;
        
        // 参数:
        //   f:
        //     The input angle, in radians.
        // 返回结果:
        //     The return value between -1 and +1.
        */
        public static float Sin(float f);



        /*
            Gradually changes a value towards a desired goal over time.

            The value is smoothed by some spring-damper like function(类似弹簧阻尼器的功能), 
            which will never overshoot. 
            The function can be used to smooth any kind of value, positions, colors, scalars.


            参数:
            current:
                The current position.

            target:
                The position we are trying to reach.

            currentVelocity:
                The current velocity, this value is modified by the function every time you call it.
                注意, 此参数为 ref;
                猜测是个 被本函数不断维护的一个值;

            smoothTime:
                Approximately the time it will take to reach the target. 
                A smaller value will reach the target faster.

            maxSpeed:
                Optionally allows you to clamp the maximum speed.

            deltaTime:
                The time since the last call to this function. By default Time.deltaTime.

            返回值:
                本帧计算出来的, [current, target] 间的某个值, 表示本帧应该运动到的 pos;
        */
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime);
        [ExcludeFromDocs]public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed);
        [ExcludeFromDocs]public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime);
        
        /*
            Gradually changes an angle given in degrees towards a desired goal angle over time.

            功能和 SmoothDamp() 类似, 不过专门处理 角度值; 
            猜测能正确地搞定 0-360 过度线;
            所以, 参数 current, target, 应该都是 角度值;
        */
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime);
        [ExcludeFromDocs]public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed);
        [ExcludeFromDocs]public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime);
        
        
        /*
            摘要:
            Interpolates between min and max with smoothing at the limits.

            和线性插值 Lerp() 类似, 不过是圆滑过度, 不那么生硬;

            猜测插值曲线为: 3t^2-2t^3

            当参数 t 小于 0 时, 会被当成 0 来使用, 此时函数返回 from;
            当参数 t 大于 1 时, 会被当成 1 来使用, 此时函数返回 to;
        
        */
        public static float SmoothStep(float from, float to, float t);

        /*
            摘要:
            Returns square root of f.
            返回 f 的平方根;
            Sqrt(9f) 得到 3f;
        */
        public static float Sqrt(float f);



        // Returns the tangent of angle f in radians.
        // 参数 弧度
        public static float Tan(float f);
    }
}
