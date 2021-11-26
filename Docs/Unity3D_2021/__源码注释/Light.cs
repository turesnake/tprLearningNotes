#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.ComponentModel;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     Script interface for.
    [NativeHeaderAttribute("Runtime/Camera/Light.h")]
    [NativeHeaderAttribute("Runtime/Export/Graphics/Light.bindings.h")]
    [RequireComponent(typeof(Transform))]
    [RequireComponent(typeof(Transform))]
    public sealed class Light : Behaviour//Light__RR
    {
        public Light();

        [Obsolete("Use QualitySettings.pixelLightCount instead.")]
        public static int pixelLightCount { get; set; }
        //
        // 摘要:
        //     Set to true to enable custom matrix for culling during shadows.
        public bool useShadowMatrixOverride { get; set; }
        //
        // 摘要:
        //     The to use for this light.
        public Flare flare { get; set; }
        //
        // 摘要:
        //     This property describes the output of the last Global Illumination bake.
        public LightBakingOutput bakingOutput { get; set; }
        //
        // 摘要:
        //     This is used to light certain objects in the Scene selectively.
        public int cullingMask { get; set; }
        //
        // 摘要:
        //     Determines which rendering LayerMask this Light affects.
        public int renderingLayerMask { get; set; }
        //
        // 摘要:
        //     Allows you to override the global Shadowmask Mode per light. Only use this with
        //     render pipelines that can handle per light Shadowmask modes. Incompatible with
        //     the legacy renderers.
        public LightShadowCasterMode lightShadowCasterMode { get; set; }
        //
        // 摘要:
        //     Controls the amount of artificial softening applied to the edges of shadows cast
        //     by the Point or Spot light.
        public float shadowRadius { get; set; }
        //
        // 摘要:
        //     Controls the amount of artificial softening applied to the edges of shadows cast
        //     by directional lights.
        public float shadowAngle { get; set; }
        //
        // 摘要:
        //     How this light casts shadows
        public LightShadows shadows { get; set; }
        //
        // 摘要:
        //     Strength of light's shadows.
        public float shadowStrength { get; set; }
        //
        // 摘要:
        //     The resolution of the shadow map.
        public LightShadowResolution shadowResolution { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Shadow softness is removed in Unity 5.0+", true)]
        public float shadowSoftness { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Shadow softness is removed in Unity 5.0+", true)]
        public float shadowSoftnessFade { get; set; }
        //
        // 摘要:
        //     Per-light, per-layer shadow culling distances. Directional lights only.
        public float[] layerShadowCullDistances { get; set; }
        //
        // 摘要:
        //     The size of a directional light's cookie.
        public float cookieSize { get; set; }
        //
        // 摘要:
        //     The cookie texture projected by the light.
        public Texture cookie { get; set; }
        //
        // 摘要:
        //     How to render the light.
        public LightRenderMode renderMode { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("warning bakedIndex has been removed please use bakingOutput.isBaked instead.", true)]
        public int bakedIndex { get; set; }
        //
        // 摘要:
        //     The size of the area light (Editor only).
        public Vector2 areaSize { get; set; }
        //
        // 摘要:
        //     This property describes what part of a light's contribution can be baked (Editor
        //     only).
        public LightmapBakeType lightmapBakeType { get; set; }
        //
        // 摘要:
        //     Number of command buffers set up on this light (Read Only).
        public int commandBufferCount { get; }
        [Obsolete("light.shadowConstantBias was removed, use light.shadowBias", true)]
        public float shadowConstantBias { get; set; }
        [Obsolete("light.shadowObjectSizeBias was removed, use light.shadowBias", true)]
        public float shadowObjectSizeBias { get; set; }
        [Obsolete("light.attenuate was removed; all lights always attenuate now", true)]
        public bool attenuate { get; set; }
        [Obsolete("Light.lightmappingMode has been deprecated. Use Light.lightmapBakeType instead (UnityUpgradable) -> lightmapBakeType", true)]
        public LightmappingMode lightmappingMode { get; set; }
        //
        // 摘要:
        //     The range of the light.
        public float range { get; set; }
        //
        // 摘要:
        //     Projection matrix used to override the regular light matrix during shadow culling.
        public Matrix4x4 shadowMatrixOverride { get; set; }
        [Obsolete("Light.alreadyLightmapped is no longer supported. Use Light.bakingOutput instead. Allowing to describe mixed light on top of realtime and baked ones.", false)]
        public bool alreadyLightmapped { get; set; }
        //
        // 摘要:
        //     Near plane value to use for shadow frustums.
        public float shadowNearPlane { get; set; }
        //
        // 摘要:
        //     The type of the light.
        [NativePropertyAttribute("LightType")]
        public LightType type { get; set; }
        //
        // 摘要:
        //     This property describes the shape of the spot light. Only Scriptable Render Pipelines
        //     use this property; the built-in renderer does not support it.
        [NativePropertyAttribute("LightShape")]
        public LightShape shape { get; set; }
        //
        // 摘要:
        //     Is the light contribution already stored in lightmaps and/or lightprobes (Read
        //     Only). Obsolete; replaced by Light-lightmapBakeType.
        [Obsolete("Light.isBaked is no longer supported. Use Light.bakingOutput.isBaked (and other members of Light.bakingOutput) instead.", false)]
        public bool isBaked { get; }
        //
        // 摘要:
        //     The angle of the light's spotlight inner cone in degrees.
        public float innerSpotAngle { get; set; }
        //
        // 摘要:
        //     The color of the light.
        public Color color { get; set; }
        //
        // 摘要:
        //     The color temperature of the light. Correlated Color Temperature (abbreviated
        //     as CCT) is multiplied with the color filter when calculating the final color
        //     of a light source. The color temperature of the electromagnetic radiation emitted
        //     from an ideal black body is defined as its surface temperature in Kelvin. White
        //     is 6500K according to the D65 standard. A candle light is 1800K and a soft warm
        //     light bulb is 2700K. If you want to use colorTemperature, GraphicsSettings.lightsUseLinearIntensity
        //     and Light.useColorTemperature has to be enabled. See Also: GraphicsSettings.lightsUseLinearIntensity,
        //     GraphicsSettings.useColorTemperature.
        public float colorTemperature { get; set; }
        //
        // 摘要:
        //     Set to true to use the color temperature.
        public bool useColorTemperature { get; set; }
        //
        // 摘要:
        //     The angle of the light's spotlight cone in degrees.
        public float spotAngle { get; set; }
        //
        // 摘要:
        //     The multiplier that defines the strength of the bounce lighting.
        public float bounceIntensity { get; set; }
        //
        // 摘要:
        //     Set to true to override light bounding sphere for culling.
        public bool useBoundingSphereOverride { get; set; }
        //
        // 摘要:
        //     Bounding sphere used to override the regular light bounding sphere during culling.
        public Vector4 boundingSphereOverride { get; set; }
        //
        // 摘要:
        //     Whether to cull shadows for this Light when the Light is outside of the view
        //     frustum.
        public bool useViewFrustumForShadowCasterCull { get; set; }
        //
        // 摘要:
        //     The custom resolution of the shadow map.
        public int shadowCustomResolution { get; set; }
        //
        // 摘要:
        //     Shadow mapping constant bias.
        public float shadowBias { get; set; }
        //
        // 摘要:
        //     Shadow mapping normal-based bias.
        public float shadowNormalBias { get; set; }
        //
        // 摘要:
        //     The Intensity of a light is multiplied with the Light color.
        public float intensity { get; set; }

        [FreeFunctionAttribute("Light_Bindings::GetLights")]
        public static Light[] GetLights(LightType type, int layer);
        //
        // 摘要:
        //     Add a command buffer to be executed at a specified place.
        //
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        //
        //   buffer:
        //     The buffer to execute.
        //
        //   shadowPassMask:
        //     A mask specifying which shadow passes to execute the buffer for.
        public void AddCommandBuffer(LightEvent evt, CommandBuffer buffer);
        //
        // 摘要:
        //     Add a command buffer to be executed at a specified place.
        //
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        //
        //   buffer:
        //     The buffer to execute.
        //
        //   shadowPassMask:
        //     A mask specifying which shadow passes to execute the buffer for.
        [FreeFunctionAttribute("Light_Bindings::AddCommandBuffer", HasExplicitThis = true)]
        public void AddCommandBuffer(LightEvent evt, CommandBuffer buffer, ShadowMapPass shadowPassMask);
        //
        // 摘要:
        //     Adds a command buffer to the GPU's async compute queues and executes that command
        //     buffer when graphics processing reaches a given point.
        //
        // 参数:
        //   evt:
        //     The point during the graphics processing at which this command buffer should
        //     commence on the GPU.
        //
        //   buffer:
        //     The buffer to execute.
        //
        //   queueType:
        //     The desired async compute queue type to execute the buffer on.
        //
        //   shadowPassMask:
        //     A mask specifying which shadow passes to execute the buffer for.
        [FreeFunctionAttribute("Light_Bindings::AddCommandBufferAsync", HasExplicitThis = true)]
        public void AddCommandBufferAsync(LightEvent evt, CommandBuffer buffer, ShadowMapPass shadowPassMask, ComputeQueueType queueType);
        //
        // 摘要:
        //     Adds a command buffer to the GPU's async compute queues and executes that command
        //     buffer when graphics processing reaches a given point.
        //
        // 参数:
        //   evt:
        //     The point during the graphics processing at which this command buffer should
        //     commence on the GPU.
        //
        //   buffer:
        //     The buffer to execute.
        //
        //   queueType:
        //     The desired async compute queue type to execute the buffer on.
        //
        //   shadowPassMask:
        //     A mask specifying which shadow passes to execute the buffer for.
        public void AddCommandBufferAsync(LightEvent evt, CommandBuffer buffer, ComputeQueueType queueType);
        //
        // 摘要:
        //     Get command buffers to be executed at a specified place.
        //
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        //
        // 返回结果:
        //     Array of command buffers.
        [FreeFunctionAttribute("Light_Bindings::GetCommandBuffers", HasExplicitThis = true)]
        public CommandBuffer[] GetCommandBuffers(LightEvent evt);
        //
        // 摘要:
        //     Remove all command buffers set on this light.
        public void RemoveAllCommandBuffers();
        //
        // 摘要:
        //     Remove command buffer from execution at a specified place.
        //
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        //
        //   buffer:
        //     The buffer to execute.
        public void RemoveCommandBuffer(LightEvent evt, CommandBuffer buffer);
        //
        // 摘要:
        //     Remove command buffers from execution at a specified place.
        //
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        public void RemoveCommandBuffers(LightEvent evt);
        //
        // 摘要:
        //     Revert all light parameters to default.
        public void Reset();
        //
        // 摘要:
        //     Sets a light dirty to notify the light baking backends to update their internal
        //     light representation (Editor only).
        public void SetLightDirty();
    }
}

