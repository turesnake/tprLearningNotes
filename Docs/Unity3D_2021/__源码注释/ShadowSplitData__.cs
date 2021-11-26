#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Describes the culling information for a given "shadow split" (e.g. directional cascade).

        "shadow split":
        就是 cascade 中的一层;  

        当调用 ComputeDirectionalShadowMatricesAndCullingPrimitives(),
        将获得一个 ShadowSplitData 实例，里面就包含 cascade 相关的数据

        本 class 实例，只记录 单个光 的单个 cascade 区间 的信息。
        ========

        猜测:
            存在两种分法:
            -- 
                用面去两个 split 之间的边界;
                此时可用本类中的 cull plane 相关的成员;

            --
                每个 split 都覆盖一个 world-space 中的 球体区域;
                也是最常用的 分割方式;
                此时可用本类中的 cull sphere 相关的成员;
    */
    [UsedByNativeCodeAttribute]
    public struct ShadowSplitData /*ShadowSplitData__*/
        : IEquatable<ShadowSplitData>
    {
        
        // 摘要:
        //     The maximum number of culling planes.
        public static readonly int maximumCullingPlaneCount;

        
        // 摘要:
        //     The number of culling planes.
        public int cullingPlaneCount { get; set; }

        
        /*
            摘要:
            vector4 的前三个分量 记录 cull sphere 的 center posWS, 分量w 记录 球的半径; 
        */ 
        public Vector4 cullingSphere { get; set; }


        /*
            摘要:
            A multiplier applied to the radius of the culling sphere. Values must be in the
            range 0 to 1. With higher values, Unity culls more objects. Lower makes the cascades
            share more rendered objects. Using lower values allows blending between different
            cascades as they then share objects.

            作用于 cull sphere 的半径 的一个 因子; 区间[0,1]

            此因子 值越高, 那些处于 sphere 边界处的 物体就会被 剔除掉
            此值较低时, 这些边界处的 物体 就会被保留, 被渲染(深度值);

            这样一来, 一个位于 cascade 边界处的物体, 可以被前后两个 split map 都渲染一次(深度值);
        */
        public float shadowCascadeBlendCullingFactor { get; set; }



        public bool Equals(ShadowSplitData other);
        public override bool Equals(object obj);

        
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

