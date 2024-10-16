#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Globalization;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Representation of a plane in 3D space.
[UsedByNativeCode]
public struct Plane : IFormattable
{
    internal const int size = 16;

    private Vector3 m_Normal;

    private float m_Distance;

    //
    // Summary:
    //     Normal vector of the plane.
    public Vector3 normal
    {
        get
        {
            return m_Normal;
        }
        set
        {
            m_Normal = value;
        }
    }

    //
    // Summary:
    //     The distance measured from the Plane to the origin, along the Plane's normal.
    public float distance
    {
        get
        {
            return m_Distance;
        }
        set
        {
            m_Distance = value;
        }
    }

    //
    // Summary:
    //     Returns a copy of the plane that faces in the opposite direction.
    public Plane flipped => new Plane(-m_Normal, 0f - m_Distance);

    //
    // Summary:
    //     Creates a plane.
    //
    // Parameters:
    //   inNormal:
    //
    //   inPoint:
    public Plane(Vector3 inNormal, Vector3 inPoint)
    {
        m_Normal = Vector3.Normalize(inNormal);
        m_Distance = 0f - Vector3.Dot(m_Normal, inPoint);
    }

    //
    // Summary:
    //     Creates a plane.
    //
    // Parameters:
    //   inNormal:
    //
    //   d:
    public Plane(Vector3 inNormal, float d)
    {
        m_Normal = Vector3.Normalize(inNormal);
        m_Distance = d;
    }

    //
    // Summary:
    //     Creates a plane.
    //
    // Parameters:
    //   a:
    //
    //   b:
    //
    //   c:
    public Plane(Vector3 a, Vector3 b, Vector3 c)
    {
        m_Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));
        m_Distance = 0f - Vector3.Dot(m_Normal, a);
    }

    //
    // Summary:
    //     Sets a plane using a point that lies within it along with a normal to orient
    //     it.
    //
    // Parameters:
    //   inNormal:
    //     The plane's normal vector.
    //
    //   inPoint:
    //     A point that lies on the plane.
    public void SetNormalAndPosition(Vector3 inNormal, Vector3 inPoint)
    {
        m_Normal = Vector3.Normalize(inNormal);
        m_Distance = 0f - Vector3.Dot(inNormal, inPoint);
    }

    //
    // Summary:
    //     Sets a plane using three points that lie within it. The points go around clockwise
    //     as you look down on the top surface of the plane.
    //
    // Parameters:
    //   a:
    //     First point in clockwise order.
    //
    //   b:
    //     Second point in clockwise order.
    //
    //   c:
    //     Third point in clockwise order.
    public void Set3Points(Vector3 a, Vector3 b, Vector3 c)
    {
        m_Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));
        m_Distance = 0f - Vector3.Dot(m_Normal, a);
    }

    //
    // Summary:
    //     Makes the plane face in the opposite direction.
    public void Flip()
    {
        m_Normal = -m_Normal;
        m_Distance = 0f - m_Distance;
    }

    //
    // Summary:
    //     Moves the plane in space by the translation vector.
    //
    // Parameters:
    //   translation:
    //     The offset in space to move the plane with.
    public void Translate(Vector3 translation)
    {
        m_Distance += Vector3.Dot(m_Normal, translation);
    }

    //
    // Summary:
    //     Returns a copy of the given plane that is moved in space by the given translation.
    //
    //
    // Parameters:
    //   plane:
    //     The plane to move in space.
    //
    //   translation:
    //     The offset in space to move the plane with.
    //
    // Returns:
    //     The translated plane.
    public static Plane Translate(Plane plane, Vector3 translation)
    {
        return new Plane(plane.m_Normal, plane.m_Distance += Vector3.Dot(plane.m_Normal, translation));
    }

    //
    // Summary:
    //     For a given point returns the closest point on the plane.
    //
    // Parameters:
    //   point:
    //     The point to project onto the plane.
    //
    // Returns:
    //     A point on the plane that is closest to point.
    public Vector3 ClosestPointOnPlane(Vector3 point)
    {
        float num = Vector3.Dot(m_Normal, point) + m_Distance;
        return point - m_Normal * num;
    }

    //
    // Summary:
    //     Returns a signed distance from plane to point.
    //
    // Parameters:
    //   point:
    public float GetDistanceToPoint(Vector3 point)
    {
        return Vector3.Dot(m_Normal, point) + m_Distance;
    }

    //
    // Summary:
    //     Is a point on the positive side of the plane?
    //
    // Parameters:
    //   point:
    public bool GetSide(Vector3 point)
    {
        return Vector3.Dot(m_Normal, point) + m_Distance > 0f;
    }

    //
    // Summary:
    //     Are two points on the same side of the plane?
    //
    // Parameters:
    //   inPt0:
    //
    //   inPt1:
    public bool SameSide(Vector3 inPt0, Vector3 inPt1)
    {
        float distanceToPoint = GetDistanceToPoint(inPt0);
        float distanceToPoint2 = GetDistanceToPoint(inPt1);
        return (distanceToPoint > 0f && distanceToPoint2 > 0f) || (distanceToPoint <= 0f && distanceToPoint2 <= 0f);
    }


    // 检测 射线 与 平面 的相交信息:
    // 
    // enter: 存储 射线 与 平面 的交点距离射线起点的距离。如果射线与平面相交，这个值将被设置为交点的距离。
    // ret:   如果返回 true，表示射线与平面相交；如果返回 false，表示射线与平面不相交。
    public bool Raycast(Ray ray, out float enter)
    {
        float num = Vector3.Dot(ray.direction, m_Normal);
        float num2 = 0f - Vector3.Dot(ray.origin, m_Normal) - m_Distance;
        if (Mathf.Approximately(num, 0f))
        {
            enter = 0f;
            return false;
        }

        enter = num2 / num;
        return enter > 0f;
    }

    public override string ToString()
    {
        return ToString(null, null);
    }

    public string ToString(string format)
    {
        return ToString(format, null);
    }

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

        return UnityString.Format("(normal:{0}, distance:{1})", m_Normal.ToString(format, formatProvider), m_Distance.ToString(format, formatProvider));
    }
}

