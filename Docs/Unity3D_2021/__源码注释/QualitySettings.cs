#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Internal;
using UnityEngine.Rendering;

namespace UnityEngine
{
    /*
        "project's Quality Settings" inspector 的 脚本版;

        There can be an arbitrary number of quality settings. 
        The details of each are set up in the "project's Quality Settings". 
        At run time, the current quality level can be changed using this class.

    */
    [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
    [NativeHeaderAttribute("Runtime/Graphics/QualitySettings.h")]
    [StaticAccessorAttribute("GetQualitySettings()", Bindings.StaticAccessorType.Dot)]
    public sealed class QualitySettings //QualitySettings__RR
        : Object
    {
        //
        // 摘要:
        //     A maximum LOD level. All LOD groups.
        public static int maximumLODLevel { get; set; }
        //
        // 摘要:
        //     Use a two-pass shader for the vegetation in the terrain engine.
        public static bool softVegetation { get; set; }
        //
        // 摘要:
        //     The number of vertical syncs that should pass between each frame.
        public static int vSyncCount { get; set; }
        //
        // 摘要:
        //     Set The AA Filtering option.
        public static int antiAliasing { get; set; }
        //
        // 摘要:
        //     Async texture upload provides timesliced async texture upload on the render thread
        //     with tight control over memory and timeslicing. There are no allocations except
        //     for the ones which driver has to do. To read data and upload texture data a ringbuffer
        //     whose size can be controlled is re-used. Use asyncUploadTimeSlice to set the
        //     time-slice in milliseconds for asynchronous texture uploads per frame. Minimum
        //     value is 1 and maximum is 33.
        public static int asyncUploadTimeSlice { get; set; }
        //
        // 摘要:
        //     Asynchronous texture and mesh data upload provides timesliced async texture and
        //     mesh data upload on the render thread with tight control over memory and timeslicing.
        //     There are no allocations except for the ones which driver has to do. To read
        //     data and upload texture and mesh data, Unity re-uses a ringbuffer whose size
        //     can be controlled. Use asyncUploadBufferSize to set the buffer size for asynchronous
        //     texture and mesh data uploads. The size is in megabytes. The minimum value is
        //     2 and the maximum value is 512. The buffer resizes automatically to fit the largest
        //     texture currently loading. To avoid re-sizing of the buffer, which can incur
        //     performance cost, set the value approximately to the size of biggest texture
        //     used in the Scene.
        public static int asyncUploadBufferSize { get; set; }
        //
        // 摘要:
        //     This flag controls if the async upload pipeline's ring buffer remains allocated
        //     when there are no active loading operations. Set this to true, to make the ring
        //     buffer allocation persist after all upload operations have completed. If you
        //     have issues with excessive memory usage, you can set this to false. This means
        //     you reduce the runtime memory footprint, but memory fragmentation can occur.
        //     The default value is true.
        public static bool asyncUploadPersistentBuffer { get; set; }
        //
        // 摘要:
        //     Enables realtime reflection probes.
        public static bool realtimeReflectionProbes { get; set; }
        //
        // 摘要:
        //     If enabled, billboards will face towards camera position rather than camera orientation.
        public static bool billboardsFaceCameraPosition { get; set; }
        //
        // 摘要:
        //     In resolution scaling mode, this factor is used to multiply with the target Fixed
        //     DPI specified to get the actual Fixed DPI to use for this quality setting.
        public static float resolutionScalingFixedDPIFactor { get; set; }
        //
        // 摘要:
        //     Should soft blending be used for particles?
        public static bool softParticles { get; set; }
        //
        // 摘要:
        //     The RenderPipelineAsset for this quality level
        public static RenderPipelineAsset renderPipeline { get; set; }
        //
        // 摘要:
        //     The maximum number of bones per vertex that are taken into account during skinning,
        //     for all meshes in the project.
        public static SkinWeights skinWeights { get; set; }
        //
        // 摘要:
        //     Enable automatic streaming of texture mipmap levels based on their distance from
        //     all active cameras.
        public static bool streamingMipmapsActive { get; set; }
        //
        // 摘要:
        //     The total amount of memory to be used by streaming and non-streaming textures.
        public static float streamingMipmapsMemoryBudget { get; set; }
        //
        // 摘要:
        //     The number of renderer instances that are processed each frame when calculating
        //     which texture mipmap levels should be streamed.
        public static int streamingMipmapsRenderersPerFrame { get; set; }
        //
        // 摘要:
        //     The maximum number of mipmap levels to discard for each texture.
        public static int streamingMipmapsMaxLevelReduction { get; set; }
        //
        // 摘要:
        //     Process all enabled Cameras for texture streaming (rather than just those with
        //     StreamingController components).
        public static bool streamingMipmapsAddAllCameras { get; set; }
        //
        // 摘要:
        //     The maximum number of active texture file IO requests from the texture streaming
        //     system.
        public static int streamingMipmapsMaxFileIORequests { get; set; }
        //
        // 摘要:
        //     Maximum number of frames queued up by graphics driver.
        [StaticAccessorAttribute("QualitySettingsScripting", Bindings.StaticAccessorType.DoubleColon)]
        public static int maxQueuedFrames { get; set; }
        //
        // 摘要:
        //     The indexed list of available Quality Settings.
        [NativePropertyAttribute("QualitySettingsNames")]
        public static string[] names { get; }
        [Obsolete("blendWeights is obsolete. Use skinWeights instead (UnityUpgradable) -> skinWeights", true)]
        public static BlendWeights blendWeights { get; set; }
        //
        // 摘要:
        //     Budget for how many ray casts can be performed per frame for approximate collision
        //     testing.
        public static int particleRaycastBudget { get; set; }
        //
        // 摘要:
        //     Active color space (Read Only).
        public static ColorSpace activeColorSpace { get; }
        //
        // 摘要:
        //     A texture size limit applied to all textures.
        public static int masterTextureLimit { get; set; }
        [Obsolete("Use GetQualityLevel and SetQualityLevel", false)]
        public static QualityLevel currentLevel { get; set; }
        //
        // 摘要:
        //     The maximum number of pixel lights that should affect any object.
        public static int pixelLightCount { get; set; }
        //
        // 摘要:
        //     Desired color space (Read Only).
        public static ColorSpace desiredColorSpace { get; }
        //
        // 摘要:
        //     Directional light shadow projection.
        public static ShadowProjection shadowProjection { get; set; }
        //
        // 摘要:
        //     Number of cascades to use for directional light shadows.
        public static int shadowCascades { get; set; }
        //
        // 摘要:
        //     Shadow drawing distance.
        public static float shadowDistance { get; set; }
        //
        // 摘要:
        //     Realtime Shadows type to be used.
        [NativePropertyAttribute("ShadowQuality")]
        public static ShadowQuality shadows { get; set; }


        /*
            The rendering mode of Shadowmask.

            enum: Shadowmask, DistanceShadowmask;
        */
        [NativePropertyAttribute("ShadowmaskMode")]
        public static ShadowmaskMode shadowmaskMode { get; set; }


        //
        // 摘要:
        //     Offset shadow frustum near plane.
        public static float shadowNearPlaneOffset { get; set; }
        //
        // 摘要:
        //     The normalized cascade distribution for a 2 cascade setup. The value defines
        //     the position of the cascade with respect to Zero.
        public static float shadowCascade2Split { get; set; }
        //
        // 摘要:
        //     The normalized cascade start position for a 4 cascade setup. Each member of the
        //     vector defines the normalized position of the coresponding cascade with respect
        //     to Zero.
        public static Vector3 shadowCascade4Split { get; set; }
        //
        // 摘要:
        //     Global multiplier for the LOD's switching distance.
        [NativePropertyAttribute("LODBias")]
        public static float lodBias { get; set; }
        //
        // 摘要:
        //     Global anisotropic filtering mode.
        [NativePropertyAttribute("AnisotropicTextures")]
        public static AnisotropicFiltering anisotropicFiltering { get; set; }
        //
        // 摘要:
        //     The default resolution of the shadow maps.
        [NativePropertyAttribute("ShadowResolution")]
        public static ShadowResolution shadowResolution { get; set; }

        public static void DecreaseLevel();
        //
        // 摘要:
        //     Decrease the current quality level.
        //
        // 参数:
        //   applyExpensiveChanges:
        //     Should expensive changes be applied (Anti-aliasing etc).
        public static void DecreaseLevel([DefaultValue("false")] bool applyExpensiveChanges);
        //
        // 摘要:
        //     Returns the current graphics quality level.
        [NativeNameAttribute("GetCurrentIndex")]
        public static int GetQualityLevel();
        //
        // 摘要:
        //     Get the Render Pipeline Asset assigned at the specified quality level.
        //
        // 参数:
        //   index:
        //     Index of the quality level to check.
        //
        // 返回结果:
        //     Null if the quality level was not found or there is no assigned SRP Asset for
        //     this level, otherwise the SRP Asset assigned for this quality level.
        public static RenderPipelineAsset GetRenderPipelineAssetAt(int index);
        public static void IncreaseLevel();
        //
        // 摘要:
        //     Increase the current quality level.
        //
        // 参数:
        //   applyExpensiveChanges:
        //     Should expensive changes be applied (Anti-aliasing etc).
        public static void IncreaseLevel([DefaultValue("false")] bool applyExpensiveChanges);
        //
        // 摘要:
        //     Sets the QualitySettings.lodBias|lodBias and QualitySettings.maximumLODLevel|maximumLODLevel
        //     at the same time.
        //
        // 参数:
        //   lodBias:
        //     Global multiplier for the LOD's switching distance.
        //
        //   maximumLODLevel:
        //     A maximum LOD level. All LOD groups.
        //
        //   setDirty:
        //     If true, marks all views as dirty.
        [NativeNameAttribute("SetLODSettings")]
        public static void SetLODSettings(float lodBias, int maximumLODLevel, bool setDirty = true);
        //
        // 摘要:
        //     Sets a new graphics quality level.
        //
        // 参数:
        //   index:
        //     Quality index to set.
        //
        //   applyExpensiveChanges:
        //     Should expensive changes be applied (Anti-aliasing etc).
        [NativeNameAttribute("SetCurrentIndex")]
        public static void SetQualityLevel(int index, [DefaultValue("true")] bool applyExpensiveChanges);
        public static void SetQualityLevel(int index);
    }
}

