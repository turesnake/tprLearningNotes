#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     General functionality for all renderers.
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Graphics/Renderer.h")]
    [RequireComponent(typeof(Transform))]
    [UsedByNativeCodeAttribute]
    public class Renderer : Component
    {
        public Renderer();

        //
        // 摘要:
        //     Specifies the mode for motion vector rendering.
        public MotionVectorGenerationMode motionVectorGenerationMode { get; set; }


        /*
            摘要:
            Determines which rendering layer this renderer lives on.

            "Rendering Layer Mask" 是一个 srp 新增技术;
                具体信息可在笔记中 查找此关键词
        */
        public uint renderingLayerMask { get; set; }


        //
        // 摘要:
        //     This value sorts renderers by priority. Lower values are rendered first and higher
        //     values are rendered last.
        public int rendererPriority { get; set; }


        /*
            摘要:
            Describes how this renderer is updated for ray tracing.
            class RayTracingMode 还在实验阶段;
        */
        public RayTracingMode rayTracingMode { get; set; }



        //
        // 摘要:
        //     Name of the Renderer's sorting layer.
        public string sortingLayerName { get; set; }
        //
        // 摘要:
        //     Unique ID of the Renderer's sorting layer.
        public int sortingLayerID { get; set; }
        //
        // 摘要:
        //     Renderer's order within a sorting layer.
        public int sortingOrder { get; set; }
        //
        // 摘要:
        //     Controls if dynamic occlusion culling should be performed for this renderer.
        [NativePropertyAttribute("IsDynamicOccludee")]
        public bool allowOcclusionWhenDynamic { get; set; }
        //
        // 摘要:
        //     Has this renderer been statically batched with any other renderers?
        public bool isPartOfStaticBatch { get; }
        //
        // 摘要:
        //     Matrix that transforms a point from world space into local space (Read Only).
        public Matrix4x4 worldToLocalMatrix { get; }
        //
        // 摘要:
        //     Matrix that transforms a point from local space into world space (Read Only).
        public Matrix4x4 localToWorldMatrix { get; }
        //
        // 摘要:
        //     If set, the Renderer will use the Light Probe Proxy Volume component attached
        //     to the source GameObject.
        public GameObject lightProbeProxyVolumeOverride { get; set; }
        //
        // 摘要:
        //     If set, Renderer will use this Transform's position to find the light or reflection
        //     probe.
        public Transform probeAnchor { get; set; }
        //
        // 摘要:
        //     The index of the baked lightmap applied to this renderer.
        public int lightmapIndex { get; set; }
        //
        // 摘要:
        //     The index of the realtime lightmap applied to this renderer.
        public int realtimeLightmapIndex { get; set; }
        //
        // 摘要:
        //     The UV scale & offset used for a lightmap.
        public Vector4 lightmapScaleOffset { get; set; }
        //
        // 摘要:
        //     The UV scale & offset used for a realtime lightmap.
        public Vector4 realtimeLightmapScaleOffset { get; set; }
        //
        // 摘要:
        //     Returns all the instantiated materials of this object.
        public Material[] materials { get; set; }
        //
        // 摘要:
        //     Returns the first instantiated Material assigned to the renderer.
        public Material material { get; set; }
        //
        // 摘要:
        //     Should reflection probes be used for this Renderer?
        public ReflectionProbeUsage reflectionProbeUsage { get; set; }
        //
        // 摘要:
        //     The light probe interpolation type.
        public LightProbeUsage lightProbeUsage { get; set; }
        //
        // 摘要:
        //     All the shared materials of this object.
        public Material[] sharedMaterials { get; set; }


        /*
            摘要:
            Is this renderer a static shadow caster?

            When enabled, Unity considers this renderer as being static for the sake of shadow rendering. 
            If the SRP implements cached shadow maps, this field indicates to the render pipeline what 
            renderers are considered static and what renderers are considered dynamic.
            ---
            若开启此 bool值, unity 会在 渲染shadow 的阶段, 认为这个 物体(renderer) 是静态的;
            如果一个 srp管线 缓存了 shadowmap, 本 bool值 告诉管线: 哪些 renderer 是静态的, 哪些不是;
        */
        public bool staticShadowCaster { get; set; }




        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property lightmapTilingOffset has been deprecated. Use lightmapScaleOffset (UnityUpgradable) -> lightmapScaleOffset", true)]
        public Vector4 lightmapTilingOffset { get; set; }
        //
        // 摘要:
        //     The shared material of this object.
        public Material sharedMaterial { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use shadowCastingMode instead.", false)]
        public bool castShadows { get; set; }
        //
        // 摘要:
        //     Specifies whether this renderer has a per-object motion vector pass.
        [Obsolete("Use motionVectorGenerationMode instead.", false)]
        public bool motionVectors { get; set; }
        //
        // 摘要:
        //     Should light probes be used for this Renderer?
        [Obsolete("Use lightProbeUsage instead.", false)]
        public bool useLightProbes { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use probeAnchor instead (UnityUpgradable) -> probeAnchor", true)]
        public Transform lightProbeAnchor { get; set; }
        //
        // 摘要:
        //     Makes the rendered 3D object visible if enabled.
        public bool enabled { get; set; }
        //
        // 摘要:
        //     Is this renderer visible in any camera? (Read Only)
        public bool isVisible { get; }
        //
        // 摘要:
        //     Does this object cast shadows?
        public ShadowCastingMode shadowCastingMode { get; set; }
        //
        // 摘要:
        //     Does this object receive shadows?
        public bool receiveShadows { get; set; }
        //
        // 摘要:
        //     Allows turning off rendering for a specific component.
        public bool forceRenderingOff { get; set; }
        //
        // 摘要:
        //     The bounding volume of the renderer (Read Only).
        public Bounds bounds { get; }

        public void GetClosestReflectionProbes(List<ReflectionProbeBlendInfo> result);
        public void GetMaterials(List<Material> m);
        //
        // 摘要:
        //     Get per-Renderer or per-Material property block.
        //
        // 参数:
        //   properties:
        //     Material parameters to retrieve.
        //
        //   materialIndex:
        //     The index of the Material you want to get overridden parameters from. The index
        //     ranges from 0 to Renderer.sharedMaterials.Length-1.
        public void GetPropertyBlock(MaterialPropertyBlock properties, int materialIndex);
        //
        // 摘要:
        //     Get per-Renderer or per-Material property block.
        //
        // 参数:
        //   properties:
        //     Material parameters to retrieve.
        //
        //   materialIndex:
        //     The index of the Material you want to get overridden parameters from. The index
        //     ranges from 0 to Renderer.sharedMaterials.Length-1.
        public void GetPropertyBlock(MaterialPropertyBlock properties);
        public void GetSharedMaterials(List<Material> m);
        //
        // 摘要:
        //     Returns true if the Renderer has a material property block attached via SetPropertyBlock.
        [FreeFunctionAttribute(Name = "RendererScripting::HasPropertyBlock", HasExplicitThis = true)]
        public bool HasPropertyBlock();
        //
        // 摘要:
        //     Lets you set or clear per-renderer or per-material parameter overrides.
        //
        // 参数:
        //   properties:
        //     Property block with values you want to override.
        //
        //   materialIndex:
        //     The index of the Material you want to override the parameters of. The index ranges
        //     from 0 to Renderer.sharedMaterial.Length-1.
        public void SetPropertyBlock(MaterialPropertyBlock properties, int materialIndex);
        //
        // 摘要:
        //     Lets you set or clear per-renderer or per-material parameter overrides.
        //
        // 参数:
        //   properties:
        //     Property block with values you want to override.
        //
        //   materialIndex:
        //     The index of the Material you want to override the parameters of. The index ranges
        //     from 0 to Renderer.sharedMaterial.Length-1.
        public void SetPropertyBlock(MaterialPropertyBlock properties);
    }
}