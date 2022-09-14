#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Reflection;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Quaternions are used to represent rotations.
    [DefaultMember("Item")]
    [Il2CppEagerStaticClassConstruction]
    [NativeHeaderAttribute("Runtime/Math/MathScripting.h")]
    [NativeTypeAttribute(Header = "Runtime/Math/Quaternion.h")]
    [UsedByNativeCodeAttribute]
    public struct Quaternion//Quaternion__RR
        : IEquatable<Quaternion>, IFormattable
    {
        public const float kEpsilon = 1E-06F;
        //
        // 摘要:
        //     X component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float x;
        //
        // 摘要:
        //     Y component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float y;
        //
        // 摘要:
        //     Z component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float z;
        //
        // 摘要:
        //     W component of the Quaternion. Do not directly modify quaternions.
        public float w;

        
        // 摘要:
        //     Constructs new Quaternion with given x,y,z,w components.
        public Quaternion(float x, float y, float z, float w);


        public float this[int index] { get; set; }


        // 摘要:
        //     The identity rotation (Read Only).  单位旋转
        public static Quaternion identity { get; }

        
        // 摘要:
        //     Returns or sets the euler angle representation of the rotation.
        public Vector3 eulerAngles { get; set; }

        
        // 摘要:
        //     Returns this quaternion with a magnitude of 1 (Read Only).
        public Quaternion normalized { get; }

        
        // 摘要:
        //     Returns the angle in degrees between two rotations a and b.
        public static float Angle(Quaternion a, Quaternion b);

        
        // 摘要:
        //     Creates a rotation which rotates angle degrees around axis.
        [FreeFunctionAttribute("QuaternionScripting::AngleAxis", IsThreadSafe = true)]
        public static Quaternion AngleAxis(float angle, Vector3 axis);

        /*
        [Obsolete("Use Quaternion.AngleAxis instead. This function was deprecated because it uses radians instead of degrees")]
        public static Quaternion AxisAngle(Vector3 axis, float angle);
        */ 

        //
        // 摘要:
        //     The dot product between two rotations.
        //
        // 参数:
        //   a:
        //
        //   b:
        public static float Dot(Quaternion a, Quaternion b);
        //
        // 摘要:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis.
        //
        // 参数:
        //   euler:
        public static Quaternion Euler(Vector3 euler);
        //
        // 摘要:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis; applied in that order.
        //
        // 参数:
        //   x:
        //
        //   y:
        //
        //   z:
        public static Quaternion Euler(float x, float y, float z);

        /*
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Quaternion EulerAngles(Vector3 euler);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Quaternion EulerAngles(float x, float y, float z);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Quaternion EulerRotation(float x, float y, float z);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Quaternion EulerRotation(Vector3 euler);
        */

        //
        // 摘要:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        //
        // 参数:
        //   fromDirection:
        //
        //   toDirection:
        [FreeFunctionAttribute("FromToQuaternionSafe", IsThreadSafe = true)]
        public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection);
        //
        // 摘要:
        //     Returns the Inverse of rotation.
        //
        // 参数:
        //   rotation:
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static Quaternion Inverse(Quaternion rotation);
        //
        // 摘要:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is clamped to the range [0, 1].
        //
        // 参数:
        //   a:
        //     Start value, returned when t = 0.
        //
        //   b:
        //     End value, returned when t = 1.
        //
        //   t:
        //     Interpolation ratio.
        //
        // 返回结果:
        //     A quaternion interpolated between quaternions a and b.
        [FreeFunctionAttribute("QuaternionScripting::Lerp", IsThreadSafe = true)]
        public static Quaternion Lerp(Quaternion a, Quaternion b, float t);
        //
        // 摘要:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is not clamped.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   t:
        [FreeFunctionAttribute("QuaternionScripting::LerpUnclamped", IsThreadSafe = true)]
        public static Quaternion LerpUnclamped(Quaternion a, Quaternion b, float t);
        //
        // 摘要:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // 参数:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        [ExcludeFromDocs]
        public static Quaternion LookRotation(Vector3 forward);
        //
        // 摘要:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // 参数:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        [FreeFunctionAttribute("QuaternionScripting::LookRotation", IsThreadSafe = true)]
        public static Quaternion LookRotation(Vector3 forward, [DefaultValue("Vector3.up")] Vector3 upwards);
        //
        // 摘要:
        //     Converts this quaternion to one with the same orientation but with a magnitude
        //     of 1.
        //
        // 参数:
        //   q:
        public static Quaternion Normalize(Quaternion q);
        //
        // 摘要:
        //     Rotates a rotation from towards to.
        //
        // 参数:
        //   from:
        //
        //   to:
        //
        //   maxDegreesDelta:
        public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta);
        //
        // 摘要:
        //     Spherically interpolates between quaternions a and b by ratio t. The parameter
        //     t is clamped to the range [0, 1].
        //
        // 参数:
        //   a:
        //     Start value, returned when t = 0.
        //
        //   b:
        //     End value, returned when t = 1.
        //
        //   t:
        //     Interpolation ratio.
        //
        // 返回结果:
        //     A quaternion spherically interpolated between quaternions a and b.
        [FreeFunctionAttribute("QuaternionScripting::Slerp", IsThreadSafe = true)]
        public static Quaternion Slerp(Quaternion a, Quaternion b, float t);
        //
        // 摘要:
        //     Spherically interpolates between a and b by t. The parameter t is not clamped.
        //
        // 参数:
        //   a:
        //
        //   b:
        //
        //   t:
        [FreeFunctionAttribute("QuaternionScripting::SlerpUnclamped", IsThreadSafe = true)]
        public static Quaternion SlerpUnclamped(Quaternion a, Quaternion b, float t);

        /*
        [Obsolete("Use Quaternion.eulerAngles instead. This function was deprecated because it uses radians instead of degrees.")]
        public static Vector3 ToEulerAngles(Quaternion rotation);
        */

        public bool Equals(Quaternion other);
        public override bool Equals(object other);
        public override int GetHashCode();
        public void Normalize();
        //
        // 摘要:
        //     Set x, y, z and w components of an existing Quaternion.
        //
        // 参数:
        //   newX:
        //
        //   newY:
        //
        //   newZ:
        //
        //   newW:
        public void Set(float newX, float newY, float newZ, float newW);

        /*
        [Obsolete("Use Quaternion.AngleAxis instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetAxisAngle(Vector3 axis, float angle);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerAngles(Vector3 euler);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerAngles(float x, float y, float z);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerRotation(float x, float y, float z);
        [Obsolete("Use Quaternion.Euler instead. This function was deprecated because it uses radians instead of degrees.")]
        public void SetEulerRotation(Vector3 euler);
        */

        //
        // 摘要:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        //
        // 参数:
        //   fromDirection:
        //
        //   toDirection:
        public void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection);
        //
        // 摘要:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // 参数:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        [ExcludeFromDocs]
        public void SetLookRotation(Vector3 view);

        //
        // 摘要:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // 参数:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        public void SetLookRotation(Vector3 view, [DefaultValue("Vector3.up")] Vector3 up);
        public void ToAngleAxis(out float angle, out Vector3 axis);

        /*
        [Obsolete("Use Quaternion.ToAngleAxis instead. This function was deprecated because it uses radians instead of degrees.")]
        public void ToAxisAngle(out Vector3 axis, out float angle);
        [Obsolete("Use Quaternion.eulerAngles instead. This function was deprecated because it uses radians instead of degrees.")]
        public Vector3 ToEuler();
        [Obsolete("Use Quaternion.eulerAngles instead. This function was deprecated because it uses radians instead of degrees.")]
        public Vector3 ToEulerAngles();
        */

        //
        // 摘要:
        //     Returns a formatted string for this quaternion.
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
        //     Returns a formatted string for this quaternion.
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
        //     Returns a formatted string for this quaternion.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public override string ToString();

        public static Vector3 operator *(Quaternion rotation, Vector3 point);
        public static Quaternion operator *(Quaternion lhs, Quaternion rhs);
        public static bool operator ==(Quaternion lhs, Quaternion rhs);
        public static bool operator !=(Quaternion lhs, Quaternion rhs);
    }
}