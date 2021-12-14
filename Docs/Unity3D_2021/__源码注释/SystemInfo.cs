#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     Access system and hardware information.
    [NativeHeaderAttribute("Runtime/Shaders/GraphicsCapsScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Misc/SystemInfo.h")]
    [NativeHeaderAttribute("Runtime/Camera/RenderLoops/MotionVectorRenderLoop.h")]
    [NativeHeaderAttribute("Runtime/Input/GetInput.h")]
    [NativeHeaderAttribute("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsFormatUtility.bindings.h")]
    public sealed class SystemInfo//SystemInfo__RR
    {
        //
        // 摘要:
        //     Value returned by SystemInfo string properties which are not supported on the
        //     current platform.
        public const string unsupportedIdentifier = "n/a";

        public SystemInfo();

        //
        // 摘要:
        //     Determines how many compute buffers Unity supports simultaneously in a vertex
        //     shader for reading. (Read Only)
        public static int maxComputeBufferInputsVertex { get; }
        //
        // 摘要:
        //     Maximum Cubemap texture size (Read Only).
        public static int maxCubemapSize { get; }
        //
        // 摘要:
        //     Maximum texture size (Read Only).
        public static int maxTextureSize { get; }
        //
        // 摘要:
        //     What NPOT (non-power of two size) texture support does the GPU provide? (Read
        //     Only)
        public static NPOTSupport npotSupport { get; }


        /*
        // 摘要:
        //     Is the stencil buffer supported? (Read Only)
        [Obsolete("supportsStencil always returns true, no need to call it")]
        public static int supportsStencil { get; }
        */


        /*
            This property is true if the current platform uses a reversed depth buffer 
            (where values range from 1 at the near plane and 0 at far plane), 
            and false if the depth buffer is normal (0 is near, 1 is far). (Read Only)
            ---
            如果当前平台使用 "reversed depth buffer", [1->0]; 本变量为 true;
        */
        public static bool usesReversedZBuffer { get; }


        //
        // 摘要:
        //     Returns true if the 'Mirror Once' texture wrap mode is supported. (Read Only)
        public static int supportsTextureWrapMirrorOnce { get; }


        /*
            Returns true if multisampled textures are resolved automatically

            Some platforms support multisampling without using an intermediate multisampled texture that needs to be explicitly resolved. 
            Such platforms automatically resolve the multisampling which provides a performance gain by saving bandwidth. 
            See Also: "CommandBuffer.Blit".
            ---

            如果 multisampled textures 能被自动解析, 返回 true;

            有的平台能自动解析 MSAA, 它不需要用户手动分配一张 "intermediate multisampled texture", 然后手动解析之;
            这种平台能提高对 带宽的利用;

            urp 中提到 Metal/iOS 就属于这样的平台;
        */
        public static bool supportsMultisampleAutoResolve { get; }


        //
        // 摘要:
        //     Boolean that indicates whether multisampled texture arrays are supported (true
        //     if supported, false if not supported).
        public static bool supportsMultisampled2DArrayTextures { get; }
        //
        // 摘要:
        //     Are multisampled textures supported? (Read Only)
        public static int supportsMultisampledTextures { get; }
        //
        // 摘要:
        //     The maximum number of random write targets (UAV) that Unity supports simultaneously.
        //     (Read Only)
        public static int supportedRandomWriteTargetCount { get; }
        //
        // 摘要:
        //     Returns true when the platform supports different blend modes when rendering
        //     to multiple render targets, or false otherwise.
        public static bool supportsSeparatedRenderTargetsBlend { get; }


        /*
            How many simultaneous(同时的) render targets (MRTs) are supported? (Read Only)
        */
        public static int supportedRenderTargetCount { get; }


        //
        // 摘要:
        //     Are sparse textures supported? (Read Only)
        public static bool supportsSparseTextures { get; }
        //
        // 摘要:
        //     Are 32-bit index buffers supported? (Read Only)
        public static bool supports32bitsIndexBuffer { get; }
        //
        // 摘要:
        //     Does the hardware support quad topology? (Read Only)
        public static bool supportsHardwareQuadTopology { get; }
        //
        // 摘要:
        //     Is GPU draw call instancing supported? (Read Only)
        public static bool supportsInstancing { get; }
        //
        // 摘要:
        //     Boolean that indicates if SV_RenderTargetArrayIndex can be used in a vertex shader
        //     (true if it can be used, false if not).
        public static bool supportsRenderTargetArrayIndexFromVertexShader { get; }
        //
        // 摘要:
        //     Are tessellation shaders supported? (Read Only)
        public static bool supportsTessellationShaders { get; }
        //
        // 摘要:
        //     Are geometry shaders supported? (Read Only)
        public static bool supportsGeometryShaders { get; }
        //
        // 摘要:
        //     Are compute shaders supported? (Read Only)
        public static bool supportsComputeShaders { get; }
        //
        // 摘要:
        //     Determines how many compute buffers Unity supports simultaneously in a fragment
        //     shader for reading. (Read Only)
        public static int maxComputeBufferInputsFragment { get; }
        //
        // 摘要:
        //     Determines how many compute buffers Unity supports simultaneously in a geometry
        //     shader for reading. (Read Only)
        public static int maxComputeBufferInputsGeometry { get; }
        //
        // 摘要:
        //     Determines how many compute buffers Unity supports simultaneously in a domain
        //     shader for reading. (Read Only)
        public static int maxComputeBufferInputsDomain { get; }
        //
        // 摘要:
        //     Determines how many compute buffers Unity supports simultaneously in a hull shader
        //     for reading. (Read Only)
        public static int maxComputeBufferInputsHull { get; }


        /*
            如果目标 build 平台的 图形api 支持 "RenderBufferStoreAction.StoreAndResolve" 功能,
            本变量返回 true;

            若为 false, "RenderBufferStoreAction.StoreAndResolve" 将会退化为 "RenderBufferStoreAction.Resolve";

            Use this property to ensure that any "multisampled render target" content is stored 
            and can be loaded correctly by any following "RenderBufferLoadAction.Load" load action.
            ---
            使用本变量来保证, "multisampled render target" 的数据能被存储, 
            同时在下一次 render target load 阶段(也是激活阶段), 这份旧数据能被有效地 load 到(读取到);
            (这个 loaded render target 需要设置为 "RenderBufferLoadAction.Load" )
        */
        public static bool supportsStoreAndResolveAction { get; }


        //
        // 摘要:
        //     Boolean that indicates whether Multiview is supported (true if supported, false
        //     if not supported). (Read Only)
        public static bool supportsMultiview { get; }
        //
        // 摘要:
        //     Is conservative rasterization supported? (Read Only)
        public static bool supportsConservativeRaster { get; }
        //
        // 摘要:
        //     Returns a bitwise combination of HDRDisplaySupportFlags describing the support
        //     for HDR displays on the system.
        public static HDRDisplaySupportFlags hdrDisplaySupportFlags { get; }
        //
        // 摘要:
        //     True if the Graphics API takes RenderBufferLoadAction and RenderBufferStoreAction
        //     into account, false if otherwise.
        public static bool usesLoadStoreActions { get; }

        /*
        [Obsolete("graphicsPixelFillrate is no longer supported in Unity 5.0+.")]
        public static int graphicsPixelFillrate { get; }
        */


        //
        // 摘要:
        //     Is streaming of texture mip maps supported? (Read Only)
        public static bool supportsMipStreaming { get; }
        //
        // 摘要:
        //     Returns true if the GPU supports partial mipmap chains (Read Only).
        public static bool hasMipMaxLevel { get; }


        /*
        // 摘要:
        //     Obsolete - use SystemInfo.constantBufferOffsetAlignment instead. Minimum buffer
        //     offset (in bytes) when binding a constant buffer using Shader.SetConstantBuffer
        //     or Material.SetConstantBuffer.
        [Obsolete("Use SystemInfo.constantBufferOffsetAlignment instead.")]
        public static bool minConstantBufferOffsetAlignment { get; }
        */


        /*
            当使用 Shader.SetConstantBuffer() (不存在了) 或 Material.SetConstantBuffer() 绑定一个 constant buffer 时,
            允许的 最小的 buffer offset (in bytes) 值;

            如果当前 active renderer 支持 "直接绑定 constant buffer" (参考 SystemInfo.supportsSetConstantBuffer)
            同时还支持 binding constant buffers with an offset,

            那么本变量指定了 "minimum required alignment in bytes for the offset parameter"
            ( offset 所需的 最小对齐字节数 )

            如果本变量值为 0, 那么当前 renderer 仅支持 "binding constant buffers at offset 0";
            ( 比如, 例如，不公开 DX11.1 功能的 DX11 设备 )
        */
        public static int constantBufferOffsetAlignment { get; }


        /*
            摘要:
            Does the current renderer support binding constant buffers directly? (Read Only)

            类似 Material.SetConstantBuffer() 这种函数, 允许使用一个 ComputeBuffer / GraphicsBuffer 中的数据
            去覆写一个 "指定的 constant buffer" 中的全部 shader 参数;

            如果当前 active renderer 支持 "直接" 绑定一个 constant buffer, 则返回 true;
        */
        public static bool supportsSetConstantBuffer { get; }



        //
        // 摘要:
        //     Checks if ray tracing is supported by the current configuration.
        public static bool supportsRayTracing { get; }
        //
        // 摘要:
        //     Returns true if asynchronous readback of GPU data is available for this device
        //     and false otherwise.
        public static bool supportsAsyncGPUReadback { get; }
        //
        // 摘要:
        //     Returns true when the platform supports GraphicsFences, and false if otherwise.
        public static bool supportsGraphicsFence { get; }
        //
        // 摘要:
        //     Specifies whether the current platform supports the GPU Recorder or not. (Read
        //     Only).
        public static bool supportsGpuRecorder { get; }
        //
        // 摘要:
        //     Returns true when the platform supports asynchronous compute queues and false
        //     if otherwise.
        public static bool supportsAsyncCompute { get; }
        //
        // 摘要:
        //     The maximum number of work groups that a compute shader can use in Z dimension
        //     (Read Only).
        public static int maxComputeWorkGroupSizeZ { get; }
        //
        // 摘要:
        //     The maximum number of work groups that a compute shader can use in Y dimension
        //     (Read Only).
        public static int maxComputeWorkGroupSizeY { get; }
        //
        // 摘要:
        //     The maximum number of work groups that a compute shader can use in X dimension
        //     (Read Only).
        public static int maxComputeWorkGroupSizeX { get; }
        //
        // 摘要:
        //     The largest total number of invocations in a single local work group that can
        //     be dispatched to a compute shader (Read Only).
        public static int maxComputeWorkGroupSize { get; }
        //
        // 摘要:
        //     Determines how many compute buffers Unity supports simultaneously in a compute
        //     shader for reading. (Read Only)
        public static int maxComputeBufferInputsCompute { get; }
        //
        // 摘要:
        //     Support for various Graphics.CopyTexture cases (Read Only).
        public static CopyTextureSupport copyTextureSupport { get; }
        //
        // 摘要:
        //     Are Cubemap Array textures supported? (Read Only)
        public static bool supportsCubemapArrayTextures { get; }
        //
        // 摘要:
        //     Are 3D (volume) RenderTextures supported? (Read Only)
        public static bool supports3DRenderTextures { get; }
        //
        // 摘要:
        //     Are 2D Array textures supported? (Read Only)
        public static bool supports2DArrayTextures { get; }
        //
        // 摘要:
        //     Returns the kind of device the application is running on (Read Only).
        public static DeviceType deviceType { get; }
        //
        // 摘要:
        //     Is there an Audio device available for playback? (Read Only)
        public static bool supportsAudio { get; }


        /*
        [Obsolete("Vertex program support is required in Unity 5.0+")]
        public static bool supportsVertexPrograms { get; }
        */

        //
        // 摘要:
        //     Is the device capable of reporting its location?
        public static bool supportsLocationService { get; }
        //
        // 摘要:
        //     Is a gyroscope available on the device?
        public static bool supportsGyroscope { get; }
        //
        // 摘要:
        //     Is an accelerometer available on the device?
        public static bool supportsAccelerometer { get; }
        //
        // 摘要:
        //     The model of the device (Read Only).
        public static string deviceModel { get; }
        //
        // 摘要:
        //     The user defined name of the device (Read Only).
        public static string deviceName { get; }
        //
        // 摘要:
        //     A unique device identifier. It is guaranteed to be unique for every device (Read
        //     Only).
        public static string deviceUniqueIdentifier { get; }
        //
        // 摘要:
        //     Amount of system memory present (Read Only).
        public static int systemMemorySize { get; }
        //
        // 摘要:
        //     Number of processors present (Read Only).
        public static int processorCount { get; }
        //
        // 摘要:
        //     Processor frequency in MHz (Read Only).
        public static int processorFrequency { get; }
        //
        // 摘要:
        //     Processor name (Read Only).
        public static string processorType { get; }
        //
        // 摘要:
        //     Returns the operating system family the game is running on (Read Only).
        public static OperatingSystemFamily operatingSystemFamily { get; }
        //
        // 摘要:
        //     Operating system name with version (Read Only).
        public static string operatingSystem { get; }
        //
        // 摘要:
        //     Returns the current status of the device's battery (Read Only).
        public static BatteryStatus batteryStatus { get; }
        //
        // 摘要:
        //     The current battery level (Read Only).
        [NativePropertyAttribute]
        public static float batteryLevel { get; }
        //
        // 摘要:
        //     Amount of video memory present (Read Only).
        public static int graphicsMemorySize { get; }
        //
        // 摘要:
        //     The name of the graphics device (Read Only).
        public static string graphicsDeviceName { get; }
        //
        // 摘要:
        //     Is the device capable of providing the user haptic feedback by vibration?
        public static bool supportsVibration { get; }
        //
        // 摘要:
        //     The identifier code of the graphics device (Read Only).
        public static int graphicsDeviceID { get; }
        //
        // 摘要:
        //     Are compressed formats for 3D (volume) textures supported? (Read Only).
        public static bool supportsCompressed3DTextures { get; }
        //
        // 摘要:
        //     Are 3D (volume) textures supported? (Read Only)
        public static bool supports3DTextures { get; }


        /*
        // 摘要:
        //     Are image effects supported? (Read Only)
        [Obsolete("supportsImageEffects always returns true, no need to call it")]
        public static bool supportsImageEffects { get; }
        */


        //
        // 摘要:
        //     The vendor of the graphics device (Read Only).
        public static string graphicsDeviceVendor { get; }
        //
        // 摘要:
        //     Whether motion vectors are supported on this platform.
        public static bool supportsMotionVectors { get; }


        /*
        // 摘要:
        //     Are render textures supported? (Read Only)
        [Obsolete("supportsRenderTextures always returns true, no need to call it")]
        public static bool supportsRenderTextures { get; }
        */


        //
        // 摘要:
        //     Is sampling raw depth from shadowmaps supported? (Read Only)
        public static bool supportsRawShadowDepthSampling { get; }
        //
        // 摘要:
        //     Are built-in shadows supported? (Read Only)
        public static bool supportsShadows { get; }


        /*
        // 摘要:
        //     Are cubemap render textures supported? (Read Only)
        [Obsolete("supportsRenderToCubemap always returns true, no need to call it")]
        public static bool supportsRenderToCubemap { get; }
        */


        /*
            True if the GPU supports "hidden surface removal". (隐藏面去除)
            --
            有些 gpu 在渲染 不透明物体时, 支持 "hidden surface removal" 功能;
            在这样的 gpu 上运行的程序, 就不必对 不透明物体 执行 "front-to-back" 排序工作了, 以提供性能;
        */
        public static bool hasHiddenSurfaceRemovalOnGPU { get; }

        //
        // 摘要:
        //     Returns true when the GPU has native support for indexing uniform arrays in fragment
        //     shaders without restrictions.
        public static bool hasDynamicUniformArrayIndexingInFragmentShaders { get; }
        //
        // 摘要:
        //     The identifier code of the graphics device vendor (Read Only).
        public static int graphicsDeviceVendorID { get; }
        //
        // 摘要:
        //     The graphics API type used by the graphics device (Read Only).
        public static GraphicsDeviceType graphicsDeviceType { get; }



        /*
            如果当前平台的 texture 约定, y轴的0点 是在上方, (从上向下), 
            那么本函数返回 true;

            This matches the "UNITY_UV_STARTS_AT_TOP" macro in shaders.
        */
        public static bool graphicsUVStartsAtTop { get; }


        /*
        // 摘要:
        //     This functionality is deprecated, and should no longer be used. Please use SystemInfo.supportsGraphicsFence.
        [Obsolete("SystemInfo.supportsGPUFence has been deprecated, use SystemInfo.supportsGraphicsFence instead (UnityUpgradable) ->  supportsGraphicsFence", true)]
        public static bool supportsGPUFence { get; }
        */


        //
        // 摘要:
        //     Graphics device shader capability level (Read Only).
        public static int graphicsShaderLevel { get; }
        //
        // 摘要:
        //     Is graphics device using multi-threaded rendering (Read Only)?
        public static bool graphicsMultiThreaded { get; }
        //
        // 摘要:
        //     Application's actual rendering threading mode (Read Only).
        public static RenderingThreadingMode renderingThreadingMode { get; }
        //
        // 摘要:
        //     The graphics API type and driver version used by the graphics device (Read Only).
        public static string graphicsDeviceVersion { get; }

        [FreeFunctionAttribute("ScriptingGraphicsCaps::GetCompatibleFormat")]
        public static GraphicsFormat GetCompatibleFormat(GraphicsFormat format, FormatUsage usage);


        /*
            Returns the platform-specific GraphicsFormat that is associated with the DefaultFormat.

            传入的参数只是笼统的 LDR, HDR; 
            比如传入 HDR, 本函数就返回 当前平台为 HDR 分配的具体 数据类型;

        */
        /// <param name="format">The DefaultFormat format to look up
        ///                         enum: LDR, HDR
        /// </param>
        [FreeFunctionAttribute("ScriptingGraphicsCaps::GetGraphicsFormat")]
        public static GraphicsFormat GetGraphicsFormat(DefaultFormat format);


        
        /*
            Checks if the target platform supports the MSAA samples count in the RenderTextureDescriptor argument.

            If the target platform supports the given MSAA samples count of RenderTextureDescriptor,
            returns the given MSAA samples count. Otherwise returns a lower fallback MSAA
            samples count value that the target platform supports.
            --
            参数 desc 中记录了需要的 msaa 采样次数值, 本函数检测当前平台是否支持这个 采样次数;
            -- 如果支持这个次数, 那就返回这个次数值;
            -- 如果不支持, 那就返回一个 fallback 值; (当前平台支持的最大 msaa 采样次数值)
        */
        /// <param name="desc"></param>
        /// <returns></returns>
        [FreeFunctionAttribute("ScriptingGraphicsCaps::GetRenderTextureSupportedMSAASampleCount")]
        public static int GetRenderTextureSupportedMSAASampleCount(RenderTextureDescriptor desc);



        /*
            Verifies that the specified graphics format is supported for the specified usage.
            If a specific usage is not supported by a format, the operation will fail.
            ---
            查询在当前平台中, 参数format 是否支持 "参数usage 所指示的操作", 如果支持,就返回 true;
            "GraphicsFormat" 表示 texture/render texture 的某种实际存储格式;
            在不同平台上, 每一种格式, 都支持一系列操作; (但又不去全支持)
            ---
            urp 中的 "RenderingUtils.SupportsGraphicsFormat()" 是对本函数的封装;
        */
        /// <param name="format">The GraphicsFormat format to look up.</param>
        /// <param name="usage">The FormatUsage usage to look up.</param>
        /// <returns>Returns true if the format is supported for the specific usage.</returns>
        [FreeFunctionAttribute("ScriptingGraphicsCaps::IsFormatSupported")]
        public static bool IsFormatSupported(GraphicsFormat format, FormatUsage usage);



        //
        // 摘要:
        //     Is blending supported on render texture format?
        //
        // 参数:
        //   format:
        //     The format to look up.
        //
        // 返回结果:
        //     True if blending is supported on the given format.
        public static bool SupportsBlendingOnRenderTextureFormat(RenderTextureFormat format);
        //
        // 摘要:
        //     Tests if a RenderTextureFormat can be used with RenderTexture.enableRandomWrite.
        //
        // 参数:
        //   format:
        //     The format to look up.
        //
        // 返回结果:
        //     True if the format can be used for random access writes.
        public static bool SupportsRandomWriteOnRenderTextureFormat(RenderTextureFormat format);

 
        /*
            Is render texture format supported?
        */
        /// <param name="format">The format to look up</param>
        /// <returns>True if the format is supported.</returns>
        public static bool SupportsRenderTextureFormat(RenderTextureFormat format);


        //
        // 摘要:
        //     Is texture format supported on this device?
        //
        // 参数:
        //   format:
        //     The TextureFormat format to look up.
        //
        // 返回结果:
        //     True if the format is supported.
        public static bool SupportsTextureFormat(TextureFormat format);
        //
        // 摘要:
        //     Indicates whether the given combination of a vertex attribute format and dimension
        //     is supported on this device.
        //
        // 参数:
        //   format:
        //     The VertexAttributeFormat format to look up.
        //
        //   dimension:
        //     The dimension of vertex data to check for.
        //
        // 返回结果:
        //     True if the format with the given dimension is supported.
        public static bool SupportsVertexAttributeFormat(VertexAttributeFormat format, int dimension);
    }
}

