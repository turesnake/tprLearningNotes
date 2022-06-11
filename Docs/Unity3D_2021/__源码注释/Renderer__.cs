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
    public class Renderer : Component//Renderer__
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

            还可查看下方的: Renderer.GetMaterials(), 功能类似;

        */
        public Material[] materials { get; set; }


        /*
            摘要:
            Returns the first instantiated Material assigned to the renderer.

            本物体独占的 material 实例;

            If the material is used by any other renderers, 
            this will clone the shared material and start using it from now on.

            注意:
            本函数会自动将 materials 实例化, 并让这些返回的 materials 成为你这个 物体(renderer) 的专属物;
            当你这个 go 被销毁时, 用户有责任把本函数返回的这些 materials 也销毁掉;

            Resources.UnloadUnusedAssets() 也能销毁 materials, 不过此函数仅在加载新 level 时才会被调用;

            如果本 renderer 绑定了数个 materials, 则返回第一个绑定的那个(的副本);
        */
        public Material material { get; set; }


        /*
            摘要:
            Should reflection probes be used for this Renderer?

            enum:
            -- Off
            -- BlendProbes
            -- BlendProbesAndSkybox
            -- Simple

            如果本实例没有选择 Off, 且本物体所在的 posWS 存在可用的 反射探针,
            a reflection texture will be picked for this object 
            and set as a built-in shader uniform variable. 
            Surface shaders use this information automatically.
        */
        public ReflectionProbeUsage reflectionProbeUsage { get; set; }


        /*
            摘要:
            The light probe interpolation type.

            enum:
            -- Off
            -- BlendProbes
            -- UseProxyVolume
            -- CustomProvided
        */
        public LightProbeUsage lightProbeUsage { get; set; }


        /*
            摘要:
            All the shared materials of this object.

            返回的 material 是共享的,
            修改 sharedMaterials, 会直接改写这个 material 本身, 所有使用它的物体都将受到影响;
            如果你想要改写 material, 应该改用 Renderer.material;

            注意:
            like all arrays returned by Unity, this returns a copy of "materials array". 
            ( 一个 array 对象的 复制体 )
            If you want to change some materials in it, get the value, change an entry and set materials back.
            ( 此处的 change 指的是 更换这个 array副本中的 material 对象 )
            ( 由于 array 是复制体, 更换元素 是不会影响到 renderer.sharedMaterials 本身的 )

            还可查看下方的: Renderer.GetSharedMaterials(), 功能类似;
        */
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


        /*
            摘要:
            The shared material of this object.

            返回的 "本 renderer metarials array" 中, 第一个绑定的 material 的本体(的引用);

            修改 sharedMaterial, 会直接改写这个 material 本身, 所有使用它的物体都将受到影响;
            如果你想要改写 material, 应该改用 Renderer.material;

            如果本 renderer 绑定了数个 materials, 则返回第一个绑定的那个;
        */
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

        
        // 摘要:
        //     Makes the rendered 3D object visible if enabled.
        public bool enabled { get; set; }

        /*
            摘要:
            Is this renderer visible in any camera? (Read Only)

            Note that the object is considered visible when it needs to be rendered in the Scene. 
            For example, it might not actually be visible by any camera but still need to be rendered for shadows. 

            是否需要被渲染, 而不是是否被当前 camrera 看见;
            一个物体就是不被任何 camera 看见, 它的投影说不定也会被看见, 这个物体还是需要被渲染的;

            When running in the editor, the Scene view cameras will also cause this value to be true.
        */
        public bool isVisible { get; }


        /*
            摘要:
            Does this object cast shadows?

            enum:
            -- Off
            -- On
            -- TwoSided
            -- ShadowsOnly
        */
        public ShadowCastingMode shadowCastingMode { get; set; }


        /*
            摘要:
            Does this object receive shadows?

            有些场合故意关闭一个物体的 阴影接收, 可提高性能;

            本开关不能作用于 延迟渲染, 此时所有物体都接收阴影;
        */
        public bool receiveShadows { get; set; }


        /*
            摘要:
            Allows turning off rendering for a specific component.

            This is useful for manually controlling the rendering of a component. 
            Such as in a case of custom visibility culling.

            Note that the enabled state of the render component does not change, 
            but it is simply excluded from being rendered.
        */
        public bool forceRenderingOff { get; set; }


        /*
            摘要:
             The bounding volume of the renderer (Read Only).

            在 world-space 中完全包裹物体的 AABB 盒;

            有时候, bounds.center 要比  Transform.position 更能描述 物体的坐标;
            尤其是当这个物体不是对称的时;

            Mesh.bounds 和本变量很类似, 不过它得到的是 mesh 在 obj-space 中的信息;
        */
        public Bounds bounds { get; }



        /*
            返回一个 list, 里面存储了 最近的 反射探针的: 探针本体信息 + 这个探针的 weight;
            weight shows how much influence the probe has on the renderer, 
            weight 也被用来做 探针之间的 blend;
        */
        public void GetClosestReflectionProbes(List<ReflectionProbeBlendInfo> result);


        /*
            Returns all the instantiated materials of this object.

            Use this method instead of "Renderer.materials" if you control the life cycle of the list passed in 
            and you want to avoid allocating a new array with every access.
            --
            如果你掌握了参数 m 的生命周期, 而且不希望每次调用都要重分配一个 array 对象;
            可以使用本函数来代替 Renderer.materials
        */
        public void GetMaterials(List<Material> m);


        /*
            摘要:
            Get per-Renderer or per-Material property block.

            此函数应该和下方的 SetPropertyBlock() 相对应, 建议先查看它的细节;

            从本实例中获得 block 信息, 将其存入参数 properties 中;

            The retrieved properties are stored in the property block passed in through "properties". 
            If no properties are set, the property block is cleared. 
            In either case the property block you pass in is completely overwritten.
            --
            如果本 renderer 没有设置任何 block, 那么参数 properties 将被 cleared;
            反正不管怎样, 参数 properties 中的数据一定会被覆写;

            If you provide a Material index, only the parameters of that Material are retrieved.

        // 参数:
        //   properties:
        //     Material parameters to retrieve(获取).  输出端
        //
        //   materialIndex:
        //     The index of the Material you want to get overridden parameters from. The index
        //     ranges from 0 to Renderer.sharedMaterials.Length-1.
        */
        public void GetPropertyBlock(MaterialPropertyBlock properties, int materialIndex);
        public void GetPropertyBlock(MaterialPropertyBlock properties);


        /*
            Returns all the shared materials of this object.

            Use this method instead of sharedMaterials if you control the life cycle of the list passed in 
            and you want to avoid allocating a new array with every access.
        */
        public void GetSharedMaterials(List<Material> m);


        
        // Returns true if the Renderer has a material property block attached via SetPropertyBlock.
        [FreeFunctionAttribute(Name = "RendererScripting::HasPropertyBlock", HasExplicitThis = true)]
        public bool HasPropertyBlock();


        /*
            摘要:
            Lets you set or clear per-renderer or per-material parameter overrides.
        

            You can also provide a Material index (from 0 to Renderer.materials.Length-1). 
            In this case, only parameters of that Material are set. 
            If there is both a per-renderer and a per-material block, only the per-Material block is used.

            To disable any of per-Renderer or per-Material overrides, pass null as the property’s argument.

            catlike 就是使用此函数来完成 black 设置的;

        // 参数:
        //   properties:
        //     Property block with values you want to override.
        //
        //   materialIndex:
        //     The index of the Material you want to override the parameters of. The index ranges
        //     from 0 to Renderer.sharedMaterial.Length-1.
        */
        public void SetPropertyBlock(MaterialPropertyBlock properties, int materialIndex);
        public void SetPropertyBlock(MaterialPropertyBlock properties);
    }
}