#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Representation of 3D vectors and points using integers.
[UsedByNativeCode]
[Il2CppEagerStaticClassConstruction]
public struct Vector3Int : IEquatable<Vector3Int>, IFormattable
{
    private int m_X;

    private int m_Y;

    private int m_Z;

    private static readonly Vector3Int s_Zero = new Vector3Int(0, 0, 0);

    private static readonly Vector3Int s_One = new Vector3Int(1, 1, 1);

    private static readonly Vector3Int s_Up = new Vector3Int(0, 1, 0);

    private static readonly Vector3Int s_Down = new Vector3Int(0, -1, 0);

    private static readonly Vector3Int s_Left = new Vector3Int(-1, 0, 0);

    private static readonly Vector3Int s_Right = new Vector3Int(1, 0, 0);

    private static readonly Vector3Int s_Forward = new Vector3Int(0, 0, 1);

    private static readonly Vector3Int s_Back = new Vector3Int(0, 0, -1);

    //
    // Summary:
    //     X component of the vector.
    public int x
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return m_X;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            m_X = value;
        }
    }

    //
    // Summary:
    //     Y component of the vector.
    public int y
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return m_Y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            m_Y = value;
        }
    }

    //
    // Summary:
    //     Z component of the vector.
    public int z
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return m_Z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            m_Z = value;
        }
    }

    public int this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return index switch
            {
                0 => x,
                1 => y,
                2 => z,
                _ => throw new IndexOutOfRangeException(UnityString.Format("Invalid Vector3Int index addressed: {0}!", index)),
            };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            switch (index)
            {
                case 0:
                    x = value;
                    break;
                case 1:
                    y = value;
                    break;
                case 2:
                    z = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(UnityString.Format("Invalid Vector3Int index addressed: {0}!", index));
            }
        }
    }

    //
    // Summary:
    //     Returns the length of this vector (Read Only).
    public float magnitude
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return Mathf.Sqrt(x * x + y * y + z * z);
        }
    }

    //
    // Summary:
    //     Returns the squared length of this vector (Read Only).
    public int sqrMagnitude
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return x * x + y * y + z * z;
        }
    }

    //
    // Summary:
    //     Shorthand for writing Vector3Int(0, 0, 0).
    public static Vector3Int zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return s_Zero;
        }
    }

    //
    // Summary:
    //     Shorthand for writing Vector3Int(1, 1, 1).
    public static Vector3Int one
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return s_One;
        }
    }

    //
    // Summary:
    //     Shorthand for writing Vector3Int(0, 1, 0).
    public static Vector3Int up
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return s_Up;
        }
    }

    //
    // Summary:
    //     Shorthand for writing Vector3Int(0, -1, 0).
    public static Vector3Int down
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return s_Down;
        }
    }

    //
    // Summary:
    //     Shorthand for writing Vector3Int(-1, 0, 0).
    public static Vector3Int left
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return s_Left;
        }
    }

    //
    // Summary:
    //     Shorthand for writing Vector3Int(1, 0, 0).
    public static Vector3Int right
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return s_Right;
        }
    }

    //
    // Summary:
    //     Shorthand for writing Vector3Int(0, 0, 1).
    public static Vector3Int forward
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return s_Forward;
        }
    }

    //
    // Summary:
    //     Shorthand for writing Vector3Int(0, 0, -1).
    public static Vector3Int back
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return s_Back;
        }
    }

    //
    // Summary:
    //     Initializes and returns an instance of a new Vector3Int with x and y components
    //     and sets z to zero.
    //
    // Parameters:
    //   x:
    //     The X component of the Vector3Int.
    //
    //   y:
    //     The Y component of the Vector3Int.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector3Int(int x, int y)
    {
        m_X = x;
        m_Y = y;
        m_Z = 0;
    }

    //
    // Summary:
    //     Initializes and returns an instance of a new Vector3Int with x, y, z components.
    //
    //
    // Parameters:
    //   x:
    //     The X component of the Vector3Int.
    //
    //   y:
    //     The Y component of the Vector3Int.
    //
    //   z:
    //     The Z component of the Vector3Int.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector3Int(int x, int y, int z)
    {
        m_X = x;
        m_Y = y;
        m_Z = z;
    }

    //
    // Summary:
    //     Set x, y and z components of an existing Vector3Int.
    //
    // Parameters:
    //   x:
    //
    //   y:
    //
    //   z:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int x, int y, int z)
    {
        m_X = x;
        m_Y = y;
        m_Z = z;
    }

    //
    // Summary:
    //     Returns the distance between a and b.
    //
    // Parameters:
    //   a:
    //
    //   b:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Distance(Vector3Int a, Vector3Int b)
    {
        return (a - b).magnitude;
    }

    //
    // Summary:
    //     Returns a vector that is made from the smallest components of two vectors.
    //
    // Parameters:
    //   lhs:
    //
    //   rhs:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int Min(Vector3Int lhs, Vector3Int rhs)
    {
        return new Vector3Int(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z));
    }

    //
    // Summary:
    //     Returns a vector that is made from the largest components of two vectors.
    //
    // Parameters:
    //   lhs:
    //
    //   rhs:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int Max(Vector3Int lhs, Vector3Int rhs)
    {
        return new Vector3Int(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z));
    }

    //
    // Summary:
    //     Multiplies two vectors component-wise.
    //
    // Parameters:
    //   a:
    //
    //   b:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int Scale(Vector3Int a, Vector3Int b)
    {
        return new Vector3Int(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    //
    // Summary:
    //     Multiplies every component of this vector by the same component of scale.
    //
    // Parameters:
    //   scale:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Scale(Vector3Int scale)
    {
        x *= scale.x;
        y *= scale.y;
        z *= scale.z;
    }

    //
    // Summary:
    //     Clamps the Vector3Int to the bounds given by min and max.
    //
    // Parameters:
    //   min:
    //
    //   max:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clamp(Vector3Int min, Vector3Int max)
    {
        x = Math.Max(min.x, x);
        x = Math.Min(max.x, x);
        y = Math.Max(min.y, y);
        y = Math.Min(max.y, y);
        z = Math.Max(min.z, z);
        z = Math.Min(max.z, z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector3(Vector3Int v)
    {
        return new Vector3(v.x, v.y, v.z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Vector2Int(Vector3Int v)
    {
        return new Vector2Int(v.x, v.y);
    }

    //
    // Summary:
    //     Converts a Vector3 to a Vector3Int by doing a Floor to each value.
    //
    // Parameters:
    //   v:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int FloorToInt(Vector3 v)
    {
        return new Vector3Int(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y), Mathf.FloorToInt(v.z));
    }

    //
    // Summary:
    //     Converts a Vector3 to a Vector3Int by doing a Ceiling to each value.
    //
    // Parameters:
    //   v:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int CeilToInt(Vector3 v)
    {
        return new Vector3Int(Mathf.CeilToInt(v.x), Mathf.CeilToInt(v.y), Mathf.CeilToInt(v.z));
    }

    //
    // Summary:
    //     Converts a Vector3 to a Vector3Int by doing a Round to each value.
    //
    // Parameters:
    //   v:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int RoundToInt(Vector3 v)
    {
        return new Vector3Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int operator +(Vector3Int a, Vector3Int b)
    {
        return new Vector3Int(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int operator -(Vector3Int a, Vector3Int b)
    {
        return new Vector3Int(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int operator *(Vector3Int a, Vector3Int b)
    {
        return new Vector3Int(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int operator -(Vector3Int a)
    {
        return new Vector3Int(-a.x, -a.y, -a.z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int operator *(Vector3Int a, int b)
    {
        return new Vector3Int(a.x * b, a.y * b, a.z * b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int operator *(int a, Vector3Int b)
    {
        return new Vector3Int(a * b.x, a * b.y, a * b.z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int operator /(Vector3Int a, int b)
    {
        return new Vector3Int(a.x / b, a.y / b, a.z / b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Vector3Int lhs, Vector3Int rhs)
    {
        return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Vector3Int lhs, Vector3Int rhs)
    {
        return !(lhs == rhs);
    }

    //
    // Summary:
    //     Returns true if the objects are equal.
    //
    // Parameters:
    //   other:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object other)
    {
        if (!(other is Vector3Int))
        {
            return false;
        }

        return Equals((Vector3Int)other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Vector3Int other)
    {
        return this == other;
    }

    //
    // Summary:
    //     Gets the hash code for the Vector3Int.
    //
    // Returns:
    //     The hash code of the Vector3Int.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        int hashCode = y.GetHashCode();
        int hashCode2 = z.GetHashCode();
        return x.GetHashCode() ^ (hashCode << 4) ^ (hashCode >> 28) ^ (hashCode2 >> 4) ^ (hashCode2 << 28);
    }

    //
    // Summary:
    //     Returns a formatted string for this vector.
    //
    // Parameters:
    //   format:
    //     A numeric format string.
    //
    //   formatProvider:
    //     An object that specifies culture-specific formatting.
    public override string ToString()
    {
        return ToString(null, null);
    }

    //
    // Summary:
    //     Returns a formatted string for this vector.
    //
    // Parameters:
    //   format:
    //     A numeric format string.
    //
    //   formatProvider:
    //     An object that specifies culture-specific formatting.
    public string ToString(string format)
    {
        return ToString(format, null);
    }

    //
    // Summary:
    //     Returns a formatted string for this vector.
    //
    // Parameters:
    //   format:
    //     A numeric format string.
    //
    //   formatProvider:
    //     An object that specifies culture-specific formatting.
    public string ToString(string format, IFormatProvider formatProvider)
    {
        if (formatProvider == null)
        {
            formatProvider = CultureInfo.InvariantCulture.NumberFormat;
        }

        return UnityString.Format("({0}, {1}, {2})", x.ToString(format, formatProvider), y.ToString(format, formatProvider), z.ToString(format, formatProvider));
    }
}

