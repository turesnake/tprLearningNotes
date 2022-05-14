#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using Unity.Collections;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        A struct containing the results of a culling operation.

        在 srp 中, 当 unity 执行一次 culling 操作, 他会将操作的结果 存储在一个 CullingResults 实例中;
        它包含的信息有: 
        -- visible objects
        -- lights
        -- reflection probes

        unity 会使用这些数据去 渲染物体, 以及 处理光源;

        本类还包含了一些 辅助 shadow rendering 的 方法;

        在 RenderPipeline.Render() callback 函数体内(用户实现的那堆), 本类实例是 有效的;
        当这个函数结束后, 就不该继续使用 CullingResults 中的数据了;

        在同一个 render loop 中, 可以把同一个 CullingResults 实例使用很多次;
        如果你们确保 几个 camera 都能看到相同的 objs 时, 你还能在这些 camera 之间共享 一个 CullingResults 实例 的数据;
        以上这些操作能节省 cpu 运行负担;

    */
    [NativeHeaderAttribute("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
    [NativeHeaderAttribute("Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
    [NativeHeaderAttribute("Runtime/Graphics/ScriptableRenderLoop/ScriptableCulling.h")]
    public struct CullingResults : IEquatable<CullingResults>//CullingResults__
    {
        
        /*
            摘要:
             Gets the number of per-object light and reflection probe indices.

             为啥 light 和 反射探针 要放到一起 ???
            
            返回结果:
            The number of per-object light and reflection probe indices.
        */
        public int lightAndReflectionProbeIndexCount { get; }


        /*
            摘要:
            Gets the number of per-object light indices.

            "per-object light indices" 是一个 unity 自带系统, 可在笔记中搜索此关键词;
            此系统存在问题, 最好别用;
        */
        public int lightIndexCount { get; }


        /*
            摘要:
            Array of visible reflection probes.
            此 class 具体信息在另一文件中
        */
        public NativeArray<VisibleReflectionProbe> visibleReflectionProbes { get; }


        /*
            摘要:
            Off screen lights that still effect visible Scene vertices.

            有的光源在屏幕之外,但仍照到 可视区域的 物体顶点上.
        */
        public NativeArray<VisibleLight> visibleOffscreenVertexLights { get; }


        
        // 摘要:
        //     Array of visible lights.
        public NativeArray<VisibleLight> visibleLights { get; }


        
        // 摘要:
        //     Gets the number of per-object reflection probe indices.
        //
        // 返回结果:
        //     The number of per-object reflection probe indices.
        public int reflectionProbeIndexCount { get; }


        /*
            shadowmap 工作原理:
                为一个 平行光 生成一个 "clip-space cube", 使这个 cube 沿平行光方向分布, 且覆盖 "camera 能看到的 frustum",
                在这个 "clip-space cube" 内捕获下来的 depth 值, 就会被记录到 shadowmap 中;

            在后面的绘制阴影的 shader 中, camera 视角, 我们希望拿着任意一点的 posWS, 都能寻找到与之对应的 shadowmap 上的某个点(uv);
            此时就需要一个转换矩阵: posWS -> posSTS (shadow texture/tile space)

            本函数完成了最初的工作: 它帮我们计算好原始的 viewMatrix, projMatrix;
            在此基础上, 我们还需要:
                -1- 为部分平台支持 reverse-z 功能
                -2- 需要将 HCS 的 [-1,1] 映射为 uv 的 [0,1]
                -3- 如果支持 cascade, 则要将每一片 shadow tile, 从 "布满整个 map" 缩小偏移到 "tile 所在的具体区域"

            以上这组工作, 
                在 catilike srp 中, 由 "ConvertToAtlasMatrix()" 完成;
                在 urp 中, 由 "GetShadowTransform()" + "ApplySliceTransform()" 完成;

            最后, 我们得到一个 "_MainLightWorldToShadow" 矩阵 (urp),
            在 shader 中, 使用这个矩阵, 就能找到一个 posWS 的 shadowmap 的 uv值;
            ---------------------

            除此之外, 本函数还计算了 shadowSplitData 信息;
            
            返回值:
                If false, the shadow map for this cascade does not need to be rendered this frame.
        */
        public bool ComputeDirectionalShadowMatricesAndCullingPrimitives(
            int activeLightIndex, 
            int splitIndex, 
            int splitCount, 
            Vector3 splitRatio, 
            int shadowResolution, 
            float shadowNearPlaneOffset, 
            out Matrix4x4 viewMatrix, 
            out Matrix4x4 projMatrix, 
            out ShadowSplitData shadowSplitData
        );
        // point光 版本
        public bool ComputePointShadowMatricesAndCullingPrimitives(
            int activeLightIndex, 
            CubemapFace cubemapFace, 
            float fovBias, 
            out Matrix4x4 viewMatrix, 
            out Matrix4x4 projMatrix, 
            out ShadowSplitData shadowSplitData
        );
        // spot 光版本
        public bool ComputeSpotShadowMatricesAndCullingPrimitives(
            int activeLightIndex, 
            out Matrix4x4 viewMatrix, 
            out Matrix4x4 projMatrix, 
            out ShadowSplitData shadowSplitData
        );
        


        
        public override bool Equals(object obj);
        public bool Equals(CullingResults other);
        

        /*
            摘要:
            Fills(填充) a buffer with per-object light indices.

            使用所有 "逐物体-光" 的 idx 值, 填充一个 buffer (参数指定的);
            
            参数:
            computeBuffer:
                The compute buffer object to fill.
            buffer:
                The buffer object to fill.
        */
        public void FillLightAndReflectionProbeIndices(GraphicsBuffer buffer);
        public void FillLightAndReflectionProbeIndices(ComputeBuffer computeBuffer);




        public override int GetHashCode();

        /*
            If a RenderPipeline sorts or otherwise modifies the VisibleLight list, 
            an index remap will be necessary to properly make use of per-object light lists.

            如果渲染管线 排序or改写了 VisibleLight list 的排序,
            那么对于正确使用 "逐对象-光" list 来说, 一个 "idx 重映射表" 就很有必要;

            ------------------------------------------
            假设 visibleLights 里一共有 7 个光源, main light 在 [2] 号位(起始为0), 
            那么 IndexMap 中原始数据为:
                { 0, 1, 2(m), 3, 4, 5, 6 }

            如果我们不修改这个 IndexMap, 那么 visibleLights 中所有 light 的信息都会被传入 shader 中;
            如果 IndexMap 中某个元素被设置为 -1, 那么 unity 就会跳过这个位置的 光源, 

            比如 urp 中常见的作法: "仅保留 合格的 add lights":
                -- main light 将被剔除,
                -- 超出上限的 add light 也将被剔除 (这些光往往在 visibleLights 的尾部)

            这些被提出的光, 其在 IndexMap 中的对应位置都会写上 -1,
            那些排在 main light 后面的 add light, 它们的 idx 值需要减一; 

            现在假设 案例中只支持 4 个 add lights, 那么 IndexMap 将被修改成:
                { 0, 1, -1(m), 2, 3, -1, -1 }

            相应的, unity 最终也只会向 shader 传入 4 个 add lights 的光源信息;
        */
        public NativeArray<int> GetLightIndexMap(Allocator allocator);

        // 功能同上
        public NativeArray<int> GetReflectionProbeIndexMap(Allocator allocator);



        /*
            在 shadow distance 范围内, 光源可能没有遇见任何 shadow caster.

            此函数将 检测到的 shadow casters 装入一个 AABB 盒, 从 2号参数 返回给 调用者;
            同时,  若参数 b 不为空, 本函数返回 true. (表示本光源 确实投射出了投影)
            ----
            catilike: 2019.4 之后, 在处理平行光时, 即便没有捕捉到 shader caster, 此函数仍然返回 true
            这个改变可能会失去了 一部分优化功能, 不过不是大影响

            参数:
            lightIndex:
                    The index of the shadow-casting light.

            outBounds:
                    The bounds to be computed. (返回的 AABB 盒)

            返回值:
            bool: 
                True if the light affects at least one "shadow casting object" in the Scene.
        */
        public bool GetShadowCasterBounds(int lightIndex, out Bounds outBounds);


        /*
            如果渲染管线 排序or改写了 VisibleLight list 的排序,
            那么对于正确使用 "逐对象-光" list 来说, 一个 "idx 重映射表" 就很有必要;

            If an element of the array is set to -1, the light corresponding to that element will be disabled.
            idx 标记为 -1 的光, 意味着它不需要被处理

            参考上面 "GetLightIndexMap()" 中的详细解释;
        */
        public void SetLightIndexMap(NativeArray<int> lightIndexMap);

        // 功能同上
        public void SetReflectionProbeIndexMap(NativeArray<int> lightIndexMap);

        

        public static bool operator ==(CullingResults left, CullingResults right);
        public static bool operator !=(CullingResults left, CullingResults right);
    }
}