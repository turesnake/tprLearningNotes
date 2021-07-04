
// CullingResults
// 简略笔记

#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using Unity.Collections;

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     Culling results (visible objects, lights, reflection probes).
    
    [NativeHeaderAttribute("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
    [NativeHeaderAttribute("Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
    [NativeHeaderAttribute("Runtime/Graphics/ScriptableRenderLoop/ScriptableCulling.h")]
    public struct CullingResults : IEquatable<CullingResults>
    {
        //
        // 摘要:
        //     Gets the number of per-object light and reflection probe indices.
        //
        // 返回结果:
        //     The number of per-object light and reflection probe indices.
        public int lightAndReflectionProbeIndexCount { get; }
        //
        // 摘要:
        //     Gets the number of per-object light indices.
        //
        // 返回结果:
        //     The number of per-object light indices.
        public int lightIndexCount { get; }
        //
        // 摘要:
        //     Array of visible reflection probes.
        public NativeArray<VisibleReflectionProbe> visibleReflectionProbes { get; }
        //
        // 摘要:
        //     Off screen lights that still effect visible Scene vertices.

        // 有的光源在屏幕之外,但仍照到屏幕内的 顶点上.

        public NativeArray<VisibleLight> visibleOffscreenVertexLights { get; }

        //
        // 摘要:
        //     Array of visible lights.
        public NativeArray<VisibleLight> visibleLights { get; }

        //
        // 摘要:
        //     Gets the number of per-object reflection probe indices.
        //
        // 返回结果:
        //     The number of per-object reflection probe indices.
        public int reflectionProbeIndexCount { get; }

        // 计算 三种光的 ShadowMatrices 和 CullingPrimitives

        public bool ComputeDirectionalShadowMatricesAndCullingPrimitives(int activeLightIndex, int splitIndex, int splitCount, Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData);
        public bool ComputePointShadowMatricesAndCullingPrimitives(int activeLightIndex, CubemapFace cubemapFace, float fovBias, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData);
        public bool ComputeSpotShadowMatricesAndCullingPrimitives(int activeLightIndex, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData);
        
        
        public override bool Equals(object obj);
        public bool Equals(CullingResults other);
        //


        // 摘要:
        //     Fills a buffer with per-object light indices.
        //
        // 参数:
        //   computeBuffer:
        //     The compute buffer object to fill.
        //
        //   buffer:
        //     The buffer object to fill.
        public void FillLightAndReflectionProbeIndices(GraphicsBuffer buffer);

        //
        // 摘要:
        //     Fills a buffer with per-object light indices.
        //
        // 参数:
        //   computeBuffer:
        //     The compute buffer object to fill.
        //
        //   buffer:
        //     The buffer object to fill.
        public void FillLightAndReflectionProbeIndices(ComputeBuffer computeBuffer);
        public override int GetHashCode();
        public NativeArray<int> GetLightIndexMap(Allocator allocator);
        public NativeArray<int> GetReflectionProbeIndexMap(Allocator allocator);
        public bool GetShadowCasterBounds(int lightIndex, out Bounds outBounds);
        public void SetLightIndexMap(NativeArray<int> lightIndexMap);
        public void SetReflectionProbeIndexMap(NativeArray<int> lightIndexMap);

        public static bool operator ==(CullingResults left, CullingResults right);
        public static bool operator !=(CullingResults left, CullingResults right);
    }
}