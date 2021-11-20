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
    /*
        摘要:
        General functionality for all renderers.

        A renderer is what makes an object appear on the screen. 
        
        Use this class to access the renderer of any object, mesh or Particle System. 
        
        Renderers can be disabled to make objects invisible (see enabled), 
        and the materials can be accessed and modified through them (see material).


    */
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Graphics/Renderer.h")]
    [RequireComponent(typeof(Transform))]
    [UsedByNativeCodeAttribute]
    public class Renderer : Component
    {

        public Renderer();

        /*
            摘要:
            Specifies the mode for motion vector rendering.

            Motion vectors track the per-pixel object velocity from one frame to the next. 
            使用此信息可实现一些特殊效果, 如 motion blur, 或 TAA;

            enum:
            -- Camera
            -- Object
            -- ForceNoMotion
        */
        public MotionVectorGenerationMode motionVectorGenerationMode { get; set; }


        /*
            摘要:
            Determines which rendering layer this renderer lives on.

            "Rendering Layer Mask" 是一个 srp 新增技术;
                具体信息可在笔记中 查找此关键词
        */
        public uint renderingLayerMask { get; set; }


        
        // This value sorts renderers by priority. Lower values are rendered first and higher values are rendered last.
        public int rendererPriority { get; set; }


        /*
            摘要:
            Describes how this renderer is updated for ray tracing.
            class RayTracingMode 还在实验阶段;
        */
        public RayTracingMode rayTracingMode { get; set; }



        /*
            摘要:
            Name / "Unique ID" of the Renderer's sorting layer.

            sorting layer 仅用于 2d 渲染, 如 sprite;
        */
        public string sortingLayerName { get; set; }
        public int sortingLayerID { get; set; }

        // 未翻译..
        // 摘要:
        //     Renderer's order within a sorting layer.
        //    sorting layer 仅用于 2d 渲染, 如 sprite;
        public int sortingOrder { get; set; }


        /*
            Controls if "dynamic occlusion culling" should be performed for this renderer.

            "occlusion culling" 就是那个和 "frustum culling" 平行的 culling 技术;
        */
        [NativePropertyAttribute("IsDynamicOccludee")]
        public bool allowOcclusionWhenDynamic { get; set; }


        /*
            Has this renderer been statically batched with any other renderers?
            不推荐使用 static batch
        */
        public bool isPartOfStaticBatch { get; }


        /*
            摘要:
            Matrix that transforms a point from world space into local space (Read Only).

            注意:
                如果你正在设置 shader parameter, 
                不能使用 Transform.worldToLocalMatrix; 
                而要改用: Renderer.worldToLocalMatrix; (本变量)

                猜测似乎与 static batch 相关; 当一个物体被合并为 static batch 后
                (很多个mesh 合并成一个 大mesh)
                它的 Renderer 的矩阵会变成 单位矩阵, 而 Transform 矩阵还是原来那个;
                (这是我暂时找到的唯一相关信息...)
        */
        public Matrix4x4 worldToLocalMatrix { get; }

        /*
            摘要:
            Matrix that transforms a point from local space into world space (Read Only).

            注意:
                如果你正在设置 shader parameter, 
                不能使用 Transform.localToWorldMatrix; 
                而要改用: Renderer.localToWorldMatrix; (本变量)

                猜测似乎与 static batch 相关; 当一个物体被合并为 static batch 后
                (很多个mesh 合并成一个 大mesh)
                它的 Renderer 的矩阵会变成 单位矩阵, 而 Transform 矩阵还是原来那个;
                (这是我暂时找到的唯一相关信息...)
        */
        public Matrix4x4 localToWorldMatrix { get; }


        /*
            摘要:
            If set, the Renderer will use the "Light Probe Proxy Volume" component attached to the source GameObject.
            猜测:
                此 go 可绑定一个 LPPV 对象, 就是在 inspector 中设置的那个;
        */
        public GameObject lightProbeProxyVolumeOverride { get; set; }


        /*
            摘要:
            If set, Renderer will use this Transform's position to find the light or reflection probe.

            Otherwise the center of Renderer's AABB will be used.

            猜测:
                就是 inspector 中的 Anchor Override 绑定槽, 在此绑定一个 transform 对象, 
                它就是 lightprobe 或 反射探针;
                ---
                为啥 两种探针 合用同一个 绑定槽 ? 

            在 catlike 教程中, 这个位置似乎没被绑定过东西;
        */
        public Transform probeAnchor { get; set; }


        /*
            摘要:
            The index of the baked lightmap applied to this renderer.

            这个 idx 指向 LightmapSettings.lightmaps array;

            -- A value of -1 (0xFFFF) means no lightmap has been assigned, which is the default.  
            -- 如果一个物体将自己的 renderer inspector 中的 "Scale in Lightmap" 值设置为 0, 那么本变量值为 0xFFFE;
                这些物体能被写入 lightmap, 但它们无法被 lightmap 照亮;

            idx 存储在 16-bits 空间中, 不能大于 65533 (0xFFFE).

            注意:
            this property is only serialized when building the player. 
            In all the other cases it's the responsibility of the Unity lightmapping system 
            (or a custom script that brings external lightmapping data) 
            to set it when the Scene loads or playmode is entered.
        */
        public int lightmapIndex { get; set; }


        /*
            摘要:
            The index of the realtime lightmap applied to this renderer.

            -- A value of -1 (0xFFFF) means no lightmap has been assigned, which is the default.  
            -- 如果一个物体将自己的 renderer inspector 中的 "Scale in Lightmap" 值设置为 0, 那么本变量值为 0xFFFE;
                这些物体能被写入 lightmap, 但它们无法被 lightmap 照亮;

            idx 存储在 16-bits 空间中, 不能大于 65533 (0xFFFE).

            注意:
            this property is only serialized when building the player. 
            In all the other cases it's the responsibility of the Unity lightmapping system 
            (or a custom script that brings external lightmapping data) 
            to set it when the Scene loads or playmode is entered.
        */
        public int realtimeLightmapIndex { get; set; }


        /*
            摘要:
            The UV scale & offset used for a lightmap.
            The vector's x and y refer to UV scale, while z and w refer to UV offset.

            注意:
            this property is only serialized when building the player. 
            In all the other cases it's the responsibility of the Unity lightmapping system 
            (or a custom script that brings external lightmapping data) 
            to set it when the Scene loads or playmode is entered.
        */
        public Vector4 lightmapScaleOffset { get; set; }


        /*
            摘要:
            The UV scale & offset used for a realtime lightmap.
            The vector's x and y refer to UV scale, while z and w refer to UV offset.

            注意:
            this property is only serialized when building the player. 
            In all the other cases it's the responsibility of the Unity lightmapping system 
            (or a custom script that brings external lightmapping data) 
            to set it when the Scene loads or playmode is entered.
        */
        public Vector4 realtimeLightmapScaleOffset { get; set; }


        /*
            摘要:
            Returns all the instantiated materials of this object.

            This is an array of all materials used by the renderer. 
            Unity supports a single object using multiple materials; 

            "Renderer.sharedMaterial" and "Renderer.material" properties 
            return the first used material if there is more than one.
        */
        public Material[] materials { get; set; }


        /*
            摘要:
            Returns the first instantiated Material assigned to the renderer.

            本物体独占的 material 实例;

            If the material is used by any other renderers, 
            this will clone the shared material and start using it from now on.

            注意:
            


This function automatically instantiates the materials and makes them unique to this renderer. It is your responsibility to destroy the materials when the game object is being destroyed. Resources.UnloadUnusedAssets also destroys the materials but it is usually only called when loading a new level.




        */
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



        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property lightmapTilingOffset has been deprecated. Use lightmapScaleOffset (UnityUpgradable) -> lightmapScaleOffset", true)]
        public Vector4 lightmapTilingOffset { get; set; }
        */

        //
        // 摘要:
        //     The shared material of this object.
        public Material sharedMaterial { get; set; }


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use shadowCastingMode instead.", false)]
        public bool castShadows { get; set; }
        */

        /*
        // 摘要:
        //     Specifies whether this renderer has a per-object motion vector pass.
        [Obsolete("Use motionVectorGenerationMode instead.", false)]
        public bool motionVectors { get; set; }
        */

        /*
        // 摘要:
        //     Should light probes be used for this Renderer?
        [Obsolete("Use lightProbeUsage instead.", false)]
        public bool useLightProbes { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use probeAnchor instead (UnityUpgradable) -> probeAnchor", true)]
        public Transform lightProbeAnchor { get; set; }
        */

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
        public void SetPropertyBlock(MaterialPropertyBlock properties);
    }
}