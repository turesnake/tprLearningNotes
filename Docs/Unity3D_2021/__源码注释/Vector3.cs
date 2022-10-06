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
    //     Representation of 3D vectors and points.
    [DefaultMember("Item")]
    [Il2CppEagerStaticClassConstructionAttribute]
    [NativeClassAttribute("Vector3f")]
    [NativeHeaderAttribute("Runtime/Math/Vector3.h")]
    [NativeHeaderAttribute("Runtime/Math/MathScripting.h")]
    [NativeTypeAttribute(Header = "Runtime/Math/Vector3.h")]
    [RequiredByNativeCodeAttribute(Optional = true, GenerateProxy = true)]
    public struct Vector3 : IEquatable<Vector3>, IFormattable
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
        //     Z component of the vector.
        public float z;

        //
        // 摘要:
        //     Creates a new vector with given x, y components and sets z to zero.
        //
        // 参数:
        //   x:
        //
        //   y:
        public Vector3(float x, float y);
        //
        // 摘要:
        //     Creates a new vector with given x, y, z components.
        //
        // 参数:
        //   x:
        //
        //   y:
        //
        //   z:
        public Vector3(float x, float y, float z);

        public float this[int index] { get; set; }

        //
        // 摘要:
        //     Shorthand for writing Vector3(1, 0, 0).
        public static Vector3 right { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector3(-1, 0, 0).
        public static Vector3 left { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector3(0, 1, 0).
        public static Vector3 up { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector3(0, 0, -1).
        public static Vector3 back { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector3(0, 0, 1).
        public static Vector3 forward { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector3(1, 1, 1).
        public static Vector3 one { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector3(0, 0, 0).
        public static Vector3 zero { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector3(float.NegativeInfinity, float.NegativeInfinity,
        //     float.NegativeInfinity).
        public static Vector3 negativeInfinity { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector3(float.PositiveInfinity, float.PositiveInfinity,
        //     float.PositiveInfinity).
        public static Vector3 positiveInfinity { get; }
        //
        // 摘要:
        //     Shorthand for writing Vector3(0, -1, 0).
        public static Vector3 down { get; }


        // [Obsolete("Use Vector3.forward instead.")]
        // public static Vector3 fwd { get; }


        //
        // 摘要:
        //     Returns this vector with a magnitude of 1 (Read Only).
        public Vector3 normalized { get; }
        //
        // 摘要:
        //     Returns the length of this vector (Read Only).
        public float magnitude { get; }
        //
        // 摘要:
        //     Returns the squared length of this vector (Read Only).
        public float sqrMagnitude { get; }

        /*
            Calculates the angle between vectors from and.

            The angle returned is the angle of rotation from the first vector to the second, 
            when treating these two vector inputs as directions.
            
            Note: 
                The angle returned will always be between 0 and 180 degrees, because the method returns the smallest angle between the vectors. 
                That is, it will never return a reflex angle.
                ----

                本函数永远返回 两个方向间的 最小夹角值 (angle);
                本函数的返回值: [0f, 180f]; 
                如果从 from 转向 to 是逆时针旋转, 本函数也会返回一个正值; 
                也就是说, 本函数的返回值是不会表达 旋转的 顺时针/逆时针 性的;

                我们需要用 叉乘 去手动判断 是否为 逆时针, 然后将本函数的返回值 *= -1f;

                注意:
                    其实还能直接用 本class 中的 SignedAngle() 函数;
            
            参数:
            from:
                The vector from which the angular difference is measured.
            
            to:
                The vector to which the angular difference is measured.
            
            返回结果:
                The angle in degrees between the two vectors.
        */
        public static float Angle(Vector3 from, Vector3 to);


        // [Obsolete("Use Vector3.Angle instead. AngleBetween uses radians instead of degrees and was deprecated for this reason")]
        // public static float AngleBetween(Vector3 from, Vector3 to);


        /*
            Returns a copy of vector with its magnitude clamped to maxLength.
            ---
            很常用 !!!
            
            参数:
            vector:
            
            maxLength:
        */
        public static Vector3 ClampMagnitude(Vector3 vector, float maxLength);


        /*
            Cross Product of two vectors.
            
            若参数里存在 零向量, 则返回值为 零向量;
            若两个 参数向量 无限接近, 则返回值为 零向量;
        */
        public static Vector3 Cross(Vector3 lhs, Vector3 rhs);


        //
        // 摘要:
        //     Returns the distance between a and b.
        //
        // 参数:
        //   a:
        //
        //   b:
        public static float Distance(Vector3 a, Vector3 b);
        //
        // 摘要:
        //     Dot Product of two vectors.
        //
        // 参数:
        //   lhs:
        //
        //   rhs:
        public static float Dot(Vector3 lhs, Vector3 rhs);


        // [Obsolete("Use Vector3.ProjectOnPlane instead.")]
        // public static Vector3 Exclude(Vector3 excludeThis, Vector3 fromThat);


        //
        // 摘要:
        //     Linearly interpolates between two points.
        //
        // 参数:
        //   a:
        //     Start value, returned when t = 0.
        //
        //   b:
        //     End value, returned when t = 1.
        //
        //   t:
        //     Value used to interpolate between a and b.
        //
        // 返回结果:
        //     Interpolated value, equals to a + (b - a) * t.
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t);
        //
        // 摘要:
        //     Linearly interpolates between two vectors.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   t:
        public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float t);
        public static float Magnitude(Vector3 vector);
        //
        // 摘要:
        //     Returns a vector that is made from the largest components of two vectors.
        //
        // 参数:
        //   lhs:
        //
        //   rhs:
        public static Vector3 Max(Vector3 lhs, Vector3 rhs);
        //
        // 摘要:
        //     Returns a vector that is made from the smallest components of two vectors.
        //
        // 参数:
        //   lhs:
        //
        //   rhs:
        public static Vector3 Min(Vector3 lhs, Vector3 rhs);
        //
        // 摘要:
        //     Calculate a position between the points specified by current and target, moving
        //     no farther than the distance specified by maxDistanceDelta.
        //
        // 参数:
        //   current:
        //     The position to move from.
        //
        //   target:
        //     The position to move towards.
        //
        //   maxDistanceDelta:
        //     Distance to move current per call.
        //
        // 返回结果:
        //     The new position.
        public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta);
        //
        // 摘要:
        //     Makes this vector have a magnitude of 1.
        //
        // 参数:
        //   value:
        public static Vector3 Normalize(Vector3 value);
        public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent, ref Vector3 binormal);
        public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent);
        //
        // 摘要:
        //     Projects a vector onto another vector.
        //
        // 参数:
        //   vector:
        //
        //   onNormal:
        public static Vector3 Project(Vector3 vector, Vector3 onNormal);


        /*
            Projects a vector onto a plane defined by a normal orthogonal to the plane.
            ---

            注意:
                tpr 实践得知, 返回值向量 没有被 归一化;
            
            参数:
            planeNormal:
                The direction from the vector towards the plane.
            
            vector:
                The location of the vector above the plane.
            
            返回结果:
                The location of the vector on the plane.
        */
        public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal);



        //
        // 摘要:
        //     Reflects a vector off the plane defined by a normal.
        //
        // 参数:
        //   inDirection:
        //
        //   inNormal:
        public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal);


        /*
            Rotates a vector current towards target.
            
            参数:
            current:
                The vector being managed.
            
            target:
                The vector.
            
            maxRadiansDelta:
                The maximum angle in radians allowed for this rotation.
            
            maxMagnitudeDelta:
                The maximum allowed change in vector magnitude for this rotation.
            
            返回结果:
                The location that RotateTowards generates.
        */
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static Vector3 RotateTowards(Vector3 current, Vector3 target, float maxRadiansDelta, float maxMagnitudeDelta);


        //
        // 摘要:
        //     Multiplies two vectors component-wise.
        //
        // 参数:
        //   a:
        //
        //   b:
        public static Vector3 Scale(Vector3 a, Vector3 b);
        //
        // 摘要:
        //     Calculates the signed angle between vectors from and to in relation to axis.
        //
        // 参数:
        //   from:
        //     The vector from which the angular difference is measured.
        //
        //   to:
        //     The vector to which the angular difference is measured.
        //
        //   axis:
        //     A vector around which the other vectors are rotated.
        //
        // 返回结果:
        //     Returns the signed angle between from and to in degrees.
        public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis);
        //
        // 摘要:
        //     Spherically interpolates between two vectors.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   t:
        [FreeFunctionAttribute("VectorScripting::Slerp", IsThreadSafe = true)]
        public static Vector3 Slerp(Vector3 a, Vector3 b, float t);
        //
        // 摘要:
        //     Spherically interpolates between two vectors.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   t:
        [FreeFunctionAttribute("VectorScripting::SlerpUnclamped", IsThreadSafe = true)]
        public static Vector3 SlerpUnclamped(Vector3 a, Vector3 b, float t);
        [ExcludeFromDocs]
        public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime);
        [ExcludeFromDocs]
        public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed);
        public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime);
        public static float SqrMagnitude(Vector3 vector);
        //
        // 摘要:
        //     Returns true if the given vector is exactly equal to this vector.
        //
        // 参数:
        //   other:
        public override bool Equals(object other);
        public bool Equals(Vector3 other);
        public override int GetHashCode();
        public void Normalize();
        //
        // 摘要:
        //     Multiplies every component of this vector by the same component of scale.
        //
        // 参数:
        //   scale:
        public void Scale(Vector3 scale);
        //
        // 摘要:
        //     Set x, y and z components of an existing Vector3.
        //
        // 参数:
        //   newX:
        //
        //   newY:
        //
        //   newZ:
        public void Set(float newX, float newY, float newZ);
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

        public static Vector3 operator +(Vector3 a, Vector3 b);
        public static Vector3 operator -(Vector3 a);
        public static Vector3 operator -(Vector3 a, Vector3 b);
        public static Vector3 operator *(float d, Vector3 a);
        public static Vector3 operator *(Vector3 a, float d);
        public static Vector3 operator /(Vector3 a, float d);
        public static bool operator ==(Vector3 lhs, Vector3 rhs);
        public static bool operator !=(Vector3 lhs, Vector3 rhs);
    }
}

