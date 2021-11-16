#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     Describes the culling information for a given shadow split (e.g. directional
    //     cascade).
    [UsedByNativeCodeAttribute]
    public struct ShadowSplitData : IEquatable<ShadowSplitData>
    {
        //
        // 摘要:
        //     The maximum number of culling planes.
        public static readonly int maximumCullingPlaneCount;

        //
        // 摘要:
        //     The number of culling planes.
        public int cullingPlaneCount { get; set; }
        //
        // 摘要:
        //     The culling sphere. The first three components of the vector describe the sphere
        //     center, and the last component specifies the radius.
        public Vector4 cullingSphere { get; set; }
        //
        // 摘要:
        //     A multiplier applied to the radius of the culling sphere. Values must be in the
        //     range 0 to 1. With higher values, Unity culls more objects. Lower makes the cascades
        //     share more rendered objects. Using lower values allows blending between different
        //     cascades as they then share objects.
        public float shadowCascadeBlendCullingFactor { get; set; }

        public bool Equals(ShadowSplitData other);
        public override bool Equals(object obj);
        //
        // 摘要:
        //     Gets a culling plane.
        //
        // 参数:
        //   index:
        //     The culling plane index.
        //
        // 返回结果:
        //     The culling plane.
        public Plane GetCullingPlane(int index);
        public override int GetHashCode();
        //
        // 摘要:
        //     Sets a culling plane.
        //
        // 参数:
        //   index:
        //     The index of the culling plane to set.
        //
        //   plane:
        //     The culling plane.
        public void SetCullingPlane(int index, Plane plane);

        public static bool operator ==(ShadowSplitData left, ShadowSplitData right);
        public static bool operator !=(ShadowSplitData left, ShadowSplitData right);

        [CompilerGenerated]
        [UnsafeValueType]
        public struct <m_CullingPlanes>e__FixedBuffer
        {
            public byte FixedElementField;
        }
    }
}

