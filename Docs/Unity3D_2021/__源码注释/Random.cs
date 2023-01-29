#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    //
    // 摘要:
    //     Easily generate random data for games.
    [NativeHeaderAttribute("Runtime/Export/Random/Random.bindings.h")]
    public static class Random
    {
        //
        // 摘要:
        //     Returns a random rotation with uniform distribution (Read Only).
        public static Quaternion rotationUniform { get; }
        //
        // 摘要:
        //     Returns a random rotation (Read Only).
        public static Quaternion rotation { get; }
        //
        // 摘要:
        //     Returns a random point on the surface of a sphere with radius 1.0 (Read Only).
        public static Vector3 onUnitSphere { get; }
        //
        // 摘要:
        //     Returns a random point inside or on a circle with radius 1.0 (Read Only).
        public static Vector2 insideUnitCircle { get; }


        /*
        [Obsolete("Deprecated. Use InitState() function or Random.state property instead.")]
        [StaticAccessorAttribute("GetScriptingRand()", Bindings.StaticAccessorType.Dot)]
        public static int seed { get; set; }
        */ 


        //
        // 摘要:
        //     Gets or sets the full internal state of the random number generator.
        [StaticAccessorAttribute("GetScriptingRand()", Bindings.StaticAccessorType.Dot)]
        public static State state { get; set; }
        //
        // 摘要:
        //     Returns a random float within [0.0..1.0] (range is inclusive) (Read Only).
        public static float value { get; }
        //
        // 摘要:
        //     Returns a random point inside or on a sphere with radius 1.0 (Read Only).
        public static Vector3 insideUnitSphere { get; }

        //
        // 摘要:
        //     Generates a random color from HSV and alpha ranges.
        //
        // 参数:
        //   hueMin:
        //     Minimum hue [0..1].
        //
        //   hueMax:
        //     Maximum hue [0..1].
        //
        //   saturationMin:
        //     Minimum saturation [0..1].
        //
        //   saturationMax:
        //     Maximum saturation [0..1].
        //
        //   valueMin:
        //     Minimum value [0..1].
        //
        //   valueMax:
        //     Maximum value [0..1].
        //
        //   alphaMin:
        //     Minimum alpha [0..1].
        //
        //   alphaMax:
        //     Maximum alpha [0..1].
        //
        // 返回结果:
        //     A random color with HSV and alpha values in the (inclusive) input ranges. Values
        //     for each component are derived via linear interpolation of value.
        public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax, float alphaMin, float alphaMax);
        //
        // 摘要:
        //     Generates a random color from HSV and alpha ranges.
        //
        // 参数:
        //   hueMin:
        //     Minimum hue [0..1].
        //
        //   hueMax:
        //     Maximum hue [0..1].
        //
        //   saturationMin:
        //     Minimum saturation [0..1].
        //
        //   saturationMax:
        //     Maximum saturation [0..1].
        //
        //   valueMin:
        //     Minimum value [0..1].
        //
        //   valueMax:
        //     Maximum value [0..1].
        //
        //   alphaMin:
        //     Minimum alpha [0..1].
        //
        //   alphaMax:
        //     Maximum alpha [0..1].
        //
        // 返回结果:
        //     A random color with HSV and alpha values in the (inclusive) input ranges. Values
        //     for each component are derived via linear interpolation of value.
        public static Color ColorHSV();
        //
        // 摘要:
        //     Generates a random color from HSV and alpha ranges.
        //
        // 参数:
        //   hueMin:
        //     Minimum hue [0..1].
        //
        //   hueMax:
        //     Maximum hue [0..1].
        //
        //   saturationMin:
        //     Minimum saturation [0..1].
        //
        //   saturationMax:
        //     Maximum saturation [0..1].
        //
        //   valueMin:
        //     Minimum value [0..1].
        //
        //   valueMax:
        //     Maximum value [0..1].
        //
        //   alphaMin:
        //     Minimum alpha [0..1].
        //
        //   alphaMax:
        //     Maximum alpha [0..1].
        //
        // 返回结果:
        //     A random color with HSV and alpha values in the (inclusive) input ranges. Values
        //     for each component are derived via linear interpolation of value.
        public static Color ColorHSV(float hueMin, float hueMax);
        //
        // 摘要:
        //     Generates a random color from HSV and alpha ranges.
        //
        // 参数:
        //   hueMin:
        //     Minimum hue [0..1].
        //
        //   hueMax:
        //     Maximum hue [0..1].
        //
        //   saturationMin:
        //     Minimum saturation [0..1].
        //
        //   saturationMax:
        //     Maximum saturation [0..1].
        //
        //   valueMin:
        //     Minimum value [0..1].
        //
        //   valueMax:
        //     Maximum value [0..1].
        //
        //   alphaMin:
        //     Minimum alpha [0..1].
        //
        //   alphaMax:
        //     Maximum alpha [0..1].
        //
        // 返回结果:
        //     A random color with HSV and alpha values in the (inclusive) input ranges. Values
        //     for each component are derived via linear interpolation of value.
        public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax);
        //
        // 摘要:
        //     Generates a random color from HSV and alpha ranges.
        //
        // 参数:
        //   hueMin:
        //     Minimum hue [0..1].
        //
        //   hueMax:
        //     Maximum hue [0..1].
        //
        //   saturationMin:
        //     Minimum saturation [0..1].
        //
        //   saturationMax:
        //     Maximum saturation [0..1].
        //
        //   valueMin:
        //     Minimum value [0..1].
        //
        //   valueMax:
        //     Maximum value [0..1].
        //
        //   alphaMin:
        //     Minimum alpha [0..1].
        //
        //   alphaMax:
        //     Maximum alpha [0..1].
        //
        // 返回结果:
        //     A random color with HSV and alpha values in the (inclusive) input ranges. Values
        //     for each component are derived via linear interpolation of value.
        public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax);
        //
        // 摘要:
        //     Initializes the random number generator state with a seed.
        //
        // 参数:
        //   seed:
        //     Seed used to initialize the random number generator.
        [NativeMethodAttribute("SetSeed")]
        [StaticAccessorAttribute("GetScriptingRand()", Bindings.StaticAccessorType.Dot)]
        public static void InitState(int seed);

        //[Obsolete("Use Random.Range instead")]public static float RandomRange(float min, float max);
        //[Obsolete("Use Random.Range instead")]public static int RandomRange(int min, int max);


        //
        // 摘要:
        //     Return a random int within [minInclusive..maxExclusive) (Read Only).
        //
        // 参数:
        //   minInclusive:
        //
        //   maxExclusive:
        public static int Range(int minInclusive, int maxExclusive);
        //
        // 摘要:
        //     Returns a random float within [minInclusive..maxInclusive] (range is inclusive).
        //
        // 参数:
        //   minInclusive:
        //
        //   maxInclusive:
        [FreeFunctionAttribute]
        public static float Range(float minInclusive, float maxInclusive);

        //
        // 摘要:
        //     Serializable structure used to hold the full internal state of the random number
        //     generator. See Also: Random.state.
        public struct State
        {
        }
    }
}

