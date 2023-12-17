#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Globalization;

namespace UnityEngine;

//
// Summary:
//     Representation of rays.
public struct Ray : IFormattable
{
    private Vector3 m_Origin;

    private Vector3 m_Direction;

    //
    // Summary:
    //     The origin point of the ray.
    public Vector3 origin
    {
        get
        {
            return m_Origin;
        }
        set
        {
            m_Origin = value;
        }
    }

    //
    // Summary:
    //     The direction of the ray.
    public Vector3 direction
    {
        get
        {
            return m_Direction;
        }
        set
        {
            m_Direction = value.normalized;
        }
    }

    //
    // Summary:
    //     Creates a ray starting at origin along direction.
    //
    // Parameters:
    //   origin:
    //
    //   direction:
    public Ray(Vector3 origin, Vector3 direction)
    {
        m_Origin = origin;
        m_Direction = direction.normalized;
    }

    //
    // Summary:
    //     Returns a point at distance units along the ray.
    //
    // Parameters:
    //   distance:
    public Vector3 GetPoint(float distance)
    {
        return m_Origin + m_Direction * distance;
    }

    //
    // Summary:
    //     Returns a formatted string for this ray.
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
    //     Returns a formatted string for this ray.
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
    //     Returns a formatted string for this ray.
    //
    // Parameters:
    //   format:
    //     A numeric format string.
    //
    //   formatProvider:
    //     An object that specifies culture-specific formatting.
    public string ToString(string format, IFormatProvider formatProvider)
    {
        if (string.IsNullOrEmpty(format))
        {
            format = "F2";
        }

        if (formatProvider == null)
        {
            formatProvider = CultureInfo.InvariantCulture.NumberFormat;
        }

        return UnityString.Format("Origin: {0}, Dir: {1}", m_Origin.ToString(format, formatProvider), m_Direction.ToString(format, formatProvider));
    }
}


