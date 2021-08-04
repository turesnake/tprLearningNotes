
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
    








    // 摘要:
    //     Parameters that configure a culling operation in the Scriptable Render Pipeline.
    [UsedByNativeCodeAttribute]
    public struct ScriptableCullingParameters : IEquatable<ScriptableCullingParameters>
    {
        //
        // 摘要:
        //     Maximum amount of culling planes that can be specified.
        public static readonly int maximumCullingPlaneCount;
        //
        // 摘要:
        //     The amount of layers available.
        public static readonly int layerCount;

        //
        // 摘要:
        //     The upper limit to the value ScriptableCullingParameters.maximumPortalCullingJobs.
        public static int cullingJobsUpperLimit { get; }
        //
        // 摘要:
        //     The lower limit to the value ScriptableCullingParameters.maximumPortalCullingJobs.
        public static int cullingJobsLowerLimit { get; }
        


        /* 
            此变量控制: 有多少 激活态的 jobs 正在执行 occlusion culling
            值必须在 1-16 之间, 默认为 6. 最好的值随场景的变化而变化,
            当 culling system 执行 culling 时, 他会把场景 分割为很多块, 
            每个 job 处理一个 grid, 

            job 数量越多, 每个job 需要处理的 grid 也越小, 性能也越好.
            当然, 每多一个 job, 就多一份 开销, 不是越多越好 
        */

        // 摘要:
        //     This parameter controls how many active jobs contribute to occlusion culling.
        public int maximumPortalCullingJobs { get; set; }
        
        /* 
            此变量决定了 occlusion culling 的检测距离 query distance, 

            当 LOD 发生改变时, 此变量控制 distance. 

            默认为 -1, 任何小于 0 的值,具有相同的效果. 
            默认值会自动计算 LOD. 

            当使用 occlusion culling, 随着 LOD 的变化, 世界的 occlusion data 也会发生变化. 
            在 occlusion data 中, 有各种大小的 tiles. 每个 tile 都包含一个 cells-and-portals graph
            (细胞 和 入口图)
            在每个 cell 中, 可见性 是相同的. 这意味着, 在同一个 cell 中, 任意点的可见性是相同的. 
            portal 是 cell 之间的开口, 它决定了 cell 之间的 可见性. 

            tiles 在 k-d tree 中, 此树包含不同尺寸的 tiles. 每个 tile 代表一层 LOD, 
            当你访问一个小的 tile, 你以查询时间为代价, 获得精确的 查询结果. 

            在 culling 过程中, 随着离 camera 的距离的改变, tile 的尺寸也在改变. 这使得 靠近camera
            的区域 具有精确的细节, 远离的区域具有 粗糙的细节. 

            本变量的值越高, 原理camera处区域的 精度也越高. 较高的值会影响 性能. 
        */
        // 摘要:
        //     This parameter determines query distance for occlusion culling.
        public float accurateOcclusionThreshold { get; set; }
        //
        // 摘要:
        //     Distance between the virtual eyes.
        public float stereoSeparationDistance { get; set; }
        //
        // 摘要:
        //     The projection matrix generated for single-pass stereo culling.
        public Matrix4x4 stereoProjectionMatrix { get; set; }
        //
        // 摘要:
        //     The view matrix generated for single-pass stereo culling.
        public Matrix4x4 stereoViewMatrix { get; set; }
        
    
        // 摘要:
        //     Camera Properties used for culling.
        public CameraProperties cameraProperties { get; set; }
        //
        // 摘要:
        //     Reflection Probe Sort options for the cull.
        public ReflectionProbeSortingCriteria reflectionProbeSortingCriteria { get; set; }
        //
        // 摘要:
        //     Flags to configure a culling operation in the Scriptable Render Pipeline.
        public CullingOptions cullingOptions { get; set; }
        //
        // 摘要:
        //     Shadow distance to use for the cull.
        public float shadowDistance { get; set; }
        //
        // 摘要:
        //     Position for the origin of the cull.
        public Vector3 origin { get; set; }
        

        /* 
            culling 操作的 矩阵. 

            unity 从  Camera.cullingMatrix property 中复制来此值.
            在真的执行 culling 操作之间, 你可以覆写 此值. 
        */
        // 摘要:
        //     The matrix for the culling operation.
        public Matrix4x4 cullingMatrix { get; set; }
        
        /* 
            culling 操作的 掩码. 

            unity 从  Camera.cullingMask property 中复制来此值. 
            在真的执行 culling 操作之间, 你可以覆写 此值. 
        */
        // 摘要:
        //     The mask for the culling operation.
        public uint cullingMask { get; set; }
        //
        // 摘要:
        //     LODParameters for culling.
        public LODParameters lodParameters { get; set; }
        //
        // 摘要:
        //     Is the cull orthographic.
        public bool isOrthographic { get; set; }
        //
        // 摘要:
        //     Number of culling planes to use.
        public int cullingPlaneCount { get; set; }
        
        /* 
            允许的 最大 可见光源 数量. 
            默认设置为 -1, 表示 无限多个. 

            当为其设置了上限, 总是优先安排 直射光,  
            然后根据 离相机的距离 逐个添加剩余的 光源
        */
        // 摘要:
        //     This parameter controls how many visible lights are allowed.
        public int maximumVisibleLights { get; set; }

        public override bool Equals(object obj);
        public bool Equals(ScriptableCullingParameters other);
        //
        // 摘要:
        //     Fetch the culling plane at the given index.
        //
        // 参数:
        //   index:
        public Plane GetCullingPlane(int index);
        public override int GetHashCode();
        //
        // 摘要:
        //     Get the distance for the culling of a specific layer.
        //
        // 参数:
        //   layerIndex:
        public float GetLayerCullingDistance(int layerIndex);
        //
        // 摘要:
        //     Set the culling plane at a given index.
        //
        // 参数:
        //   index:
        //
        //   plane:
        public void SetCullingPlane(int index, Plane plane);
        //
        // 摘要:
        //     Set the distance for the culling of a specific layer.
        //
        // 参数:
        //   layerIndex:
        //
        //   distance:
        public void SetLayerCullingDistance(int layerIndex, float distance);

        public static bool operator ==(ScriptableCullingParameters left, ScriptableCullingParameters right);
        public static bool operator !=(ScriptableCullingParameters left, ScriptableCullingParameters right);

        [CompilerGenerated]
        [UnsafeValueType]
        public struct <m_CullingPlanes>e__FixedBuffer
        {
            public byte FixedElementField;
        }
        [CompilerGenerated]
        [UnsafeValueType]
        public struct <m_LayerFarCullDistances>e__FixedBuffer
        {
            public float FixedElementField;
        }
    }
}
