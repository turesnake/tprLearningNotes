
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Reflection;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Representation of 2D vectors and points.
    [DefaultMember("Item")]
    [Il2CppEagerStaticClassConstructionAttribute]
    [NativeClassAttribute("Vector2f")]
    [RequiredByNativeCodeAttribute(Optional = true, GenerateProxy = true)]
    public struct Vector2 : IEquatable<Vector2>, IFormattable
    {
        public const float kEpsilon = 1E-05F;
        public const float kEpsilonNormalSqrt = 1E-15F;
        //
        // 摘要:
        //     X component of the vector.
        public float x;
        //
        // 摘要:
        //     Y component of the vector.
        public float y;

        //
        // 摘要:
        //     Constructs a new vector with given x, y components.
        //
        // 参数:
        //   x:
        //
        //   y:
        public Vector2(float x, float y);

        public float this[int index] { get; set; }

        //
        // 摘要:
        //     Shorthand for writing Vector2(1, 0).
        public static Vector2 right { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector2(-1, 0).
        public static Vector2 left { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector2(0, -1).
        public static Vector2 down { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector2(0, 1).
        public static Vector2 up { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector2(1, 1).
        public static Vector2 one { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector2(0, 0).
        public static Vector2 zero { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector2(float.PositiveInfinity, float.PositiveInfinity).
        public static Vector2 positiveInfinity { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector2(float.NegativeInfinity, float.NegativeInfinity).
        public static Vector2 negativeInfinity { get; }
        //
        // 摘要:
        //     Returns the squared length of this vector (Read Only).
        public float sqrMagnitude { get; }
        //
        // 摘要:
        //     Returns this vector with a magnitude of 1 (Read Only).
        public Vector2 normalized { get; }
        //
        // 摘要:
        //     Returns the length of this vector (Read Only).
        public float magnitude { get; }

        //
        // 摘要:
        //     Gets the unsigned angle in degrees between from and to.
        //
        // 参数:
        //   from:
        //     The vector from which the angular difference is measured.
        //
        //   to:
        //     The vector to which the angular difference is measured.
        //
        // 返回结果:
        //     The unsigned angle in degrees between the two vectors.
        public static float Angle(Vector2 from, Vector2 to);


        /*
            Returns a copy of vector with its magnitude clamped to maxLength.

            !!! 注意, 本函数只能将 向量缩短, 不能定制向量的长度....
            
            参数:
            vector:
            
            maxLength:
        */
        public static Vector2 ClampMagnitude(Vector2 vector, float maxLength);
        //
        // 摘要:
        //     Returns the distance between a and b.
        //
        // 参数:
        //   a:
        //
        //   b:
        public static float Distance(Vector2 a, Vector2 b);
        //
        // 摘要:
        //     Dot Product of two vectors.
        //
        // 参数:
        //   lhs:
        //
        //   rhs:
        public static float Dot(Vector2 lhs, Vector2 rhs);
        //
        // 摘要:
        //     Linearly interpolates between vectors a and b by t.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   t:
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t);
        //
        // 摘要:
        //     Linearly interpolates between vectors a and b by t.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   t:
        public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t);
        //
        // 摘要:
        //     Returns a vector that is made from the largest components of two vectors.
        //
        // 参数:
        //   lhs:
        //
        //   rhs:
        public static Vector2 Max(Vector2 lhs, Vector2 rhs);
        //
        // 摘要:
        //     Returns a vector that is made from the smallest components of two vectors.
        //
        // 参数:
        //   lhs:
        //
        //   rhs:
        public static Vector2 Min(Vector2 lhs, Vector2 rhs);
        //
        // 摘要:
        //     Moves a point current towards target.
        //
        // 参数:
        //   current:
        //
        //   target:
        //
        //   maxDistanceDelta:
        public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta);
        //
        // 摘要:
        //     Returns the 2D vector perpendicular to this 2D vector. The result is always rotated
        //     90-degrees in a counter-clockwise direction for a 2D coordinate system where
        //     the positive Y axis goes up.
        //
        // 参数:
        //   inDirection:
        //     The input direction.
        //
        // 返回结果:
        //     The perpendicular direction.
        public static Vector2 Perpendicular(Vector2 inDirection);
        //
        // 摘要:
        //     Reflects a vector off the vector defined by a normal.
        //
        // 参数:
        //   inDirection:
        //
        //   inNormal:
        public static Vector2 Reflect(Vector2 inDirection, Vector2 inNormal);
        //
        // 摘要:
        //     Multiplies two vectors component-wise.
        //
        // 参数:
        //   a:
        //
        //   b:
        public static Vector2 Scale(Vector2 a, Vector2 b);
        //
        // 摘要:
        //     Gets the signed angle in degrees between from and to.
        //
        // 参数:
        //   from:
        //     The vector from which the angular difference is measured.
        //
        //   to:
        //     The vector to which the angular difference is measured.
        //
        // 返回结果:
        //     The signed angle in degrees between the two vectors.
        public static float SignedAngle(Vector2 from, Vector2 to);
        [ExcludeFromDocs]
        public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed);
        [ExcludeFromDocs]
        public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime);
        public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime);
        public static float SqrMagnitude(Vector2 a);
        public bool Equals(Vector2 other);
        //
        // 摘要:
        //     Returns true if the given vector is exactly equal to this vector.
        //
        // 参数:
        //   other:
        public override bool Equals(object other);
        public override int GetHashCode();
        //
        // 摘要:
        //     Makes this vector have a magnitude of 1.
        public void Normalize();
        //
        // 摘要:
        //     Multiplies every component of this vector by the same component of scale.
        //
        // 参数:
        //   scale:
        public void Scale(Vector2 scale);
        //
        // 摘要:
        //     Set x and y components of an existing Vector2.
        //
        // 参数:
        //   newX:
        //
        //   newY:
        public void Set(float newX, float newY);
        public float SqrMagnitude();
        //
        // 摘要:
        //     Returns a formatted string for this vector.
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
        //     Returns a formatted string for this vector.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public string ToString(string format);
        //
        // 摘要:
        //     Returns a formatted string for this vector.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public override string ToString();

        public static Vector2 operator +(Vector2 a, Vector2 b);
        public static Vector2 operator -(Vector2 a);
        public static Vector2 operator -(Vector2 a, Vector2 b);
        public static Vector2 operator *(float d, Vector2 a);
        public static Vector2 operator *(Vector2 a, float d);
        public static Vector2 operator *(Vector2 a, Vector2 b);
        public static Vector2 operator /(Vector2 a, float d);
        public static Vector2 operator /(Vector2 a, Vector2 b);
        public static bool operator ==(Vector2 lhs, Vector2 rhs);
        public static bool operator !=(Vector2 lhs, Vector2 rhs);

        public static implicit operator Vector2(Vector3 v);
        public static implicit operator Vector3(Vector2 v);
    }
}
