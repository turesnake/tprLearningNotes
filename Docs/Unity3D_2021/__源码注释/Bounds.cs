#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    //
    // 摘要:
    //     Represents an axis aligned bounding box.
    [NativeClassAttribute("AABB")]
    [NativeHeaderAttribute("Runtime/Math/MathScripting.h")]
    [NativeHeaderAttribute("Runtime/Geometry/Ray.h")]
    [NativeHeaderAttribute("Runtime/Geometry/Intersection.h")]
    [NativeHeaderAttribute("Runtime/Geometry/AABB.h")]
    [NativeTypeAttribute(Header = "Runtime/Geometry/AABB.h")]
    [RequiredByNativeCodeAttribute(Optional = true, GenerateProxy = true)]
    public struct Bounds : IEquatable<Bounds>, IFormattable//Bounds__
    {
        //
        // 摘要:
        //     Creates a new Bounds.
        //
        // 参数:
        //   center:
        //     The location of the origin of the Bounds.
        //
        //   size:
        //     The dimensions of the Bounds.
        public Bounds(Vector3 center, Vector3 size);

        //
        // 摘要:
        //     The extents of the Bounding Box. This is always half of the size of the Bounds.
        public Vector3 extents { get; set; }
        //
        // 摘要:
        //     The total size of the box. This is always twice as large as the extents.
        public Vector3 size { get; set; }
        //
        // 摘要:
        //     The center of the bounding box.
        public Vector3 center { get; set; }
        //
        // 摘要:
        //     The minimal point of the box. This is always equal to center-extents.
        public Vector3 min { get; set; }
        //
        // 摘要:
        //     The maximal point of the box. This is always equal to center+extents.
        public Vector3 max { get; set; }

        //
        // 摘要:
        //     The closest point on the bounding box.
        //
        // 参数:
        //   point:
        //     Arbitrary point.
        //
        // 返回结果:
        //     The point on the bounding box or inside the bounding box.
        [FreeFunctionAttribute("BoundsScripting::ClosestPoint", HasExplicitThis = true, IsThreadSafe = true)]
        public Vector3 ClosestPoint(Vector3 point);
        //
        // 摘要:
        //     Is point contained in the bounding box?
        //
        // 参数:
        //   point:
        [NativeMethodAttribute("IsInside", IsThreadSafe = true)]
        public bool Contains(Vector3 point);
        //
        // 摘要:
        //     Grows the Bounds to include the point.
        //
        // 参数:
        //   point:
        public void Encapsulate(Vector3 point);
        //
        // 摘要:
        //     Grow the bounds to encapsulate the bounds.
        //
        // 参数:
        //   bounds:
        public void Encapsulate(Bounds bounds);
        public override bool Equals(object other);
        public bool Equals(Bounds other);
        //
        // 摘要:
        //     Expand the bounds by increasing its size by amount along each side.
        //
        // 参数:
        //   amount:
        public void Expand(float amount);
        //
        // 摘要:
        //     Expand the bounds by increasing its size by amount along each side.
        //
        // 参数:
        //   amount:
        public void Expand(Vector3 amount);
        public override int GetHashCode();
        //
        // 摘要:
        //     Does ray intersect this bounding box?
        //
        // 参数:
        //   ray:
        public bool IntersectRay(Ray ray);
        public bool IntersectRay(Ray ray, out float distance);
        //
        // 摘要:
        //     Does another bounding box intersect with this bounding box?
        //
        // 参数:
        //   bounds:
        public bool Intersects(Bounds bounds);
        //
        // 摘要:
        //     Sets the bounds to the min and max value of the box.
        //
        // 参数:
        //   min:
        //
        //   max:
        public void SetMinMax(Vector3 min, Vector3 max);
        //
        // 摘要:
        //     The smallest squared distance between the point and this bounding box.
        //
        // 参数:
        //   point:
        [FreeFunctionAttribute("BoundsScripting::SqrDistance", HasExplicitThis = true, IsThreadSafe = true)]
        public float SqrDistance(Vector3 point);
        //
        // 摘要:
        //     Returns a formatted string for the bounds.
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
        //     Returns a formatted string for the bounds.
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
        //     Returns a formatted string for the bounds.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public string ToString(string format);

        public static bool operator ==(Bounds lhs, Bounds rhs);
        public static bool operator !=(Bounds lhs, Bounds rhs);
    }
}

