#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.Internal;
using UnityEngine.Rendering;

namespace UnityEngine
{
    /*
        摘要:
        Raw interface to Unity's drawing functions.

        This is the high-level shortcut into the optimized mesh drawing functionality of Unity.
        这是 "unity 的绘制 mesh 的函数" 的高级缩写版;

    */
    [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
    [NativeHeaderAttribute("Runtime/Graphics/ColorGamut.h")]
    [NativeHeaderAttribute("Runtime/Graphics/CopyTexture.h")]
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Shaders/ComputeShader.h")]
    [NativeHeaderAttribute("Runtime/Camera/LightProbeProxyVolume.h")]
    public class Graphics//Graphics__
    {
        public Graphics();

        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property deviceVersion has been deprecated. Use SystemInfo.graphicsDeviceVersion instead (UnityUpgradable) -> UnityEngine.SystemInfo.graphicsDeviceVersion", true)]
        public static string deviceVersion { get; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property deviceName has been deprecated. Use SystemInfo.graphicsDeviceName instead (UnityUpgradable) -> UnityEngine.SystemInfo.graphicsDeviceName", true)]
        public static string deviceName { get; }
        */



        //     Currently active depth/stencil buffer (Read Only).
        public static RenderBuffer activeDepthBuffer { get; }


        //     Currently active color buffer (Read Only).
        public static RenderBuffer activeColorBuffer { get; }


        //     The minimum OpenGL ES version. The value is specified in PlayerSettings.
        public static OpenGLESVersion minOpenGLESVersion { get; }


        /*
            是否保留 framebuffer 的 alpha 通道信息 (readonly).
        
            当 player settings 中的 "rendering over native UI" 被启用, 此值为 true;
            查看: PlayerSettings.preserveFramebufferAlpha:
                When enabled, preserves the alpha value in the framebuffer 
                to support rendering over native UI on Android.
            ---
            在 urp 中, 根据本变量, 来选择 texture/render texture 的 GraphicsFormat 类型,
            比如是否携带 alpha 通道;
        */
        public static bool preserveFramebufferAlpha { get; }


        /*
            The GraphicsTier for the current device.

            注意:
            Graphics tiers are only supported in the Built-in Render Pipeline.

            unity 自动检测此值, 并在 startup 过程中设置它;

            This value determines which "TierSettings" are in use, 
            and which tier variants Unity loads when it loads shaders. 
            更改此值会影响任何随后加载的 shaders;
        */
        [StaticAccessorAttribute("GetGfxDevice()", Bindings.StaticAccessorType.Dot)]
        public static GraphicsTier activeTier { get; set; }



        //  Returns the currently active color gamut. (色域)
        //  The active color gamut is guaranteed to not change mid-frame.
        // 保证不会在 一帧的中间时间点 被更改
        public static ColorGamut activeColorGamut { get; }

        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property deviceVendor has been deprecated. Use SystemInfo.graphicsDeviceVendor instead (UnityUpgradable) -> UnityEngine.SystemInfo.graphicsDeviceVendor", true)]
        public static string deviceVendor { get; }
        */



        /*
            摘要:
            Copies source texture into destination render texture with a shader.

            Blit 将参数 dest 设置为 render target, 将参数 "source" 设置为 material 的 "_MainTex" property;
            然后 draws a full-screen quad.

            ====================
            若向想 screen backbuffer 写入数据:
            -- built-in 管线:
                必须确保参数 dest 为 null; 且主camera (Camera.main) 的 "camera.targetTexture" 变量也是 null;
                因为当 本函数的参数 dest 为 null 时, unity 会去自动使用 "Camera.main.targetTexture" 当作目标地址;

            -- srp 管线:
                必须在: "RenderPipelineManager.endFrameRendering" 或 "RenderPipelineManager.endContextRendering"
                这两个回调函数的实现体内, 调用本函数;

            ====================
            If you want to use a depth or stencil buffer that is part of the "source" (Render)texture
            --
            如果 参数 "source" 是个 render texture, 而你想使用它的 depth / stencil buffer:
                那么你不能直接使用本函数来达到目的, 而应该手动调用一组函数来模拟 Blit 的功能:
                -1- "Graphics.SetRenderTarget" with "destination color buffer" and "source depth buffer"
                    调用 "Graphics.SetRenderTarget()", 参数为 dest color buffer 和 src depth buffer;
                    (为什么这么设置 ? )
                
                -2- 调用 "GL.LoadOrtho()" 设置 正交透视模式

                -3- 调用 "Material.SetPass()" 设置 material pass

                -4- 调用 "GL.Begin()" 绘制一个 quad;

            =====================
            在 线性颜色空间, 设置正确的 sRGB<->Linear 转换 state 是很重要的;

            上一个渲染过程所配置的 state 很可能不是你现在想要的;
            你应该在调用 Blit() 或任何手动渲染工作之前, 设置 "GL.sRGBWrite" 

            =====================
            如果将参数 dest 和 source 设置为同一个 render texture, 将导致未定义行为;

                正确的选择是使用一个 自定义 render texture, 它带有 double buffering,
                ( CustomRenderTexture 这个 class 可以实现 )
                或者使用两个 render textures 来手动实现 double buffering 功能;
            
            =======
            本函数改写了变量: "RenderTexture.active";
            如果你希望它不被改写, 你应该在调用本函数之前手动 暂存它, 并在调用后设置回去;
            
        // 参数:
        //   source:
        //     Source texture.
        //
        //   dest:
        //     The destination RenderTexture. Set this to null to blit directly to screen. 
                当 dest 为 null 时, unity 会去自动使用 "Camera.main.targetTexture" 当作目标地址;
        //
        //   mat:
        //     Material to use. Material's shader could do some post-processing effect, for example.
        //
        //   pass:
        //     If -1 (default), draws all passes in the material. Otherwise, draws given pass only.
        //
        //   offset:
        //     Offset applied to the "source" texture coordinate.
        //
        //   scale:
        //     Scale applied to the "source" texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.  
                选择 texture array 中的某一片
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
                选择 texture array 中的某一片
        */
        public static void Blit(Texture source, RenderTexture dest, Vector2 scale, Vector2 offset);
        public static void Blit(Texture source, RenderTexture dest, Vector2 scale, Vector2 offset, int sourceDepthSlice, int destDepthSlice);
        public static void Blit(Texture source, RenderTexture dest, Material mat, [Internal.DefaultValue("-1")] int pass);
        public static void Blit(Texture source, RenderTexture dest, Material mat, int pass, int destDepthSlice);
        public static void Blit(Texture source, RenderTexture dest, Material mat);
        public static void Blit(Texture source, RenderTexture dest);
        public static void Blit(Texture source, RenderTexture dest, int sourceDepthSlice, int destDepthSlice);
        public static void Blit(Texture source, Material mat, int pass, int destDepthSlice);
        public static void Blit(Texture source, Material mat);
        public static void Blit(Texture source, Material mat, [Internal.DefaultValue("-1")] int pass);


        /*
            摘要:
            Copies source texture into destination, for "multi-tap shader".

            主要用来实现某些 post-processing 效果, 如:
            高斯模糊, iterative Cone blurring (迭代锥体模糊), 它们会在 参数 source texture 
            上的不同位置执行 多次采样;

            本函数
            将参数 dest 设置为 active render texture,
            将参数 source 设置为 material 的 "_MainTex" property,
            然后绘制一个 全屏 quad;

            quad 的每个顶点, 被设置了数个 texture coords, 由参数 offsets 来设置 偏移的像素值;

            本函数和 "Graphics.Blit()" 拥有相同的限制;

        // 参数:
        //   source:
        //     Source texture.
        //
        //   dest:
        //     Destination RenderTexture, or null to blit directly to screen.
        //
        //   mat:
        //     Material to use for copying. Material's shader should do some post-processing
        //     effect.
        //
        //   offsets:
        //     Variable number of filtering offsets. Offsets are given in pixels.
                可变数量的过滤偏移, 以像素为单位

        //   destDepthSlice:
        //     The texture array destination slice to blit to.
        */
        public static void BlitMultiTap(Texture source, RenderTexture dest, Material mat, params Vector2[] offsets);
        public static void BlitMultiTap(Texture source, RenderTexture dest, Material mat, int destDepthSlice, params Vector2[] offsets);
        

        
        /*
            摘要:
            Clear "random write targets" for "Shader Model 4.5 的 frag shader"

            This function clears any "random write targets" 
            that were previously set with "Graphics.SetRandomWriteTarget()";
        */
        [StaticAccessorAttribute("GetGfxDevice()", Bindings.StaticAccessorType.Dot)]
        public static void ClearRandomWriteTargets();


        /*
            摘要:
            This function provides an efficient way to convert between textures of different
            formats and dimensions. 
            
            参数 dst texture 的 format 必须是 未压缩的, 且是一种被支持的 "RenderTextureFormat";
            
            此函数只操作 gpu-side 的数据; 使用 "Texture2D.ReadPixels()" to get the pixs from GPU to CPU.

            此函数当前支持 2d, cubemap 为 参数 src 的类型;
            支持 2D, cubemap, 2D array and cubemap array textures 为参数 dst 类型;

            本函数不支持从 cubemap 向 Texture2D 的转换;
            它也不支持 render texture, 对于这种情况, 应该改用 "Graphics.Blit()";

            由于 api 的限制, 本函数不支持 dx9, 或 Mac+OpenGL;

            有些平台不支持 某一种 texture 之间的转换; 这是因为本函数内部基于 "Graphics.CopyTexture()" 提供的功能,
            调用 "SystemInfo.copyTextureSupport" 来检查 当前平台是否支持 你想要的 类型间转换;
            参考: "Graphics.CopyTexture()" 和 "CopyTextureSupport" (enum class)

        // 参数:
        //   src:
        //     Source texture.
        //
        //   dst:
        //     Destination texture.
        //
        //   srcElement:
        //     Source element (e.g. cubemap face). Set this to 0 for 2D source textures.
        //
        //   dstElement:
        //     Destination element (e.g. cubemap face or texture array element).
        //
        // 返回结果:
        //     True if the call succeeded.
        */
        public static bool ConvertTexture(Texture src, int srcElement, Texture dst, int dstElement);
        public static bool ConvertTexture(Texture src, Texture dst);



        /*
            摘要:
            Copy texture contents.
            copying pixel data from one texture into another efficiently. 

            可以是复制整个 texture, 也可以复制 cubemap, texture array 的一层, 
            也可以是复制一层中的 一个区域 (定义区域的起始坐标和长宽)

            注意:
            这个数据复制, 仅在 GPU 端执行;

            这个复制是不存在任何缩放的, src 的复制区, 和 dst 的接收区, 必须是一模一样大的;

            texture format 必须是兼容的;
            (比如 "TextureFormat.ARGB32" 和 "RenderTextureFormat.ARGB32" 两者是兼容的 )
            Exact rules for which formats are compatible vary a bit between graphics APIs;
            相同的通用类型, 一定是兼容的;
            再有的平台,比如 d3d11, 你甚至可以在两个 拥有相同 bit width 的 format 之间复制;

            对于那个支持 部分区域复制的 重载版本, "Compressed texture formats" 拥有额外的限制;
            比如:
                PVRTC formats are not supported since they are not block-based 
                (对于这些类型, 你只能复制一整个 texture, 或一整个 mip lvl)

                For block-based formats (e.g. DXT, BCn, ETC), 
                区域size 和 coords 必须是 "compression block size"(4 pixels for DXT) 的整数倍


            如果 src 和 dst texture 都被标记了 "readable"
            (即, 数据副本 存在于系统内存中，用于在 CPU 上读/写)
            本函数可以复制它们;

            有些平台可能只包含 复制功能的一部分:
            ( 比如, 不支持从 render texture 复制到 regular texture )

            查看 "CopyTextureSupport" (enum class)
            使用 "SystemInfo.copyTextureSupport" 去检查;

            在调用本函数之后调用: "Texture2D.Apply()", "Texture2DArray.Apply()" or "Texture3D.Apply()" 
            将导致未定义行为; 
            这是因为本函数仅仅操作于 gpu 端的数据, 
            而上面的 "Apply" 函数会将数据从 cpu 传递到 gpu;

        // 参数:
        //   src:
        //     Source texture.
        //
        //   dst:
        //     Destination texture.
        //
        //   srcElement:
        //     Source texture element (cubemap face, texture array layer or 3D texture depth
        //     slice).
        //
        //   srcMip:
        //     Source texture mipmap level.
        //
        //   dstElement:
        //     Destination texture element (cubemap face, texture array layer or 3D texture
        //     depth slice).
        //
        //   dstMip:
        //     Destination texture mipmap level.
        //
        //   srcX:
        //     X coordinate of source texture region to copy (left side is zero).
        //
        //   srcY:
        //     Y coordinate of source texture region to copy (bottom is zero).
        //
        //   srcWidth:
        //     Width of source texture region to copy.
        //
        //   srcHeight:
        //     Height of source texture region to copy.
        //
        //   dstX:
        //     X coordinate of where to copy region in destination texture (left side is zero).
        //
        //   dstY:
        //     Y coordinate of where to copy region in destination texture (bottom is zero).
        */
        public static void CopyTexture(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, Texture dst, int dstElement, int dstMip, int dstX, int dstY);
        public static void CopyTexture(Texture src, int srcElement, int srcMip, Texture dst, int dstElement, int dstMip);
        public static void CopyTexture(Texture src, int srcElement, Texture dst, int dstElement);
        public static void CopyTexture(Texture src, Texture dst);


        /*
            摘要:
            Shortcut for calling "Graphics.CreateGraphicsFence()" 
            with "GraphicsFenceType.AsyncQueueSynchronization" as the first parameter.
        
        // 参数:
        //   stage:
        //     The synchronization stage. See Graphics.CreateGraphicsFence.
        //
        // 返回结果:
        //     Returns a new GraphicsFence.
        */
        public static GraphicsFence CreateAsyncGraphicsFence([Internal.DefaultValue("SynchronisationStage.PixelProcessing")] SynchronisationStage stage);
        public static GraphicsFence CreateAsyncGraphicsFence();


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("CreateGPUFence has been deprecated. Use CreateGraphicsFence instead (UnityUpgradable) -> CreateAsyncGraphicsFence(*)", true)]
        public static GPUFence CreateGPUFence();
        */

        /*
        // 摘要:
        //     This functionality is deprecated, and should no longer be used. Please use Graphics.CreateGraphicsFence.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("CreateGPUFence has been deprecated. Use CreateGraphicsFence instead (UnityUpgradable) -> CreateAsyncGraphicsFence(*)", true)]
        public static GPUFence CreateGPUFence([Internal.DefaultValue("UnityEngine.Rendering.SynchronisationStage.PixelProcessing")] SynchronisationStage stage);
        */

        
        /*
            Creates a GraphicsFence which will be passed after the last:
                Blit, Clear, Draw, Dispatch or Texture Copy command 
            prior to this call has been completed on the GPU.
            --
            创建一个 "GraphicsFence", 它将会在:
                在先于本次函数调用的: Blit, Clear, Draw, Dispatch or "Texture Copy" command 执行完毕后(在 gpu端),
            被 "passed";
            ( GraphicsFence 是一个 时间节点, "被 passed" 就是: 运行到这个时间节点了 )

            这些指令包含: 在本 GraphicsFence 创建之前就存在的, 位于本 commandbuffer 的需要立即执行的 指令;

            有些平台无法区分 vs的结束点 和 fs的结束点, 在这样的平台上, 参数 stage 将失效, fence 的时间点被强制
            定在 fs结束点;
            
            对于那些不支持 "GraphicsFences" 功能的平台, 本函数也能被调用, 尽管这样做得到的 fence 不起任何作用,
            而且若对这个 fence 调用 "Graphics.WaitOnAsyncGraphicsFence()" 或 "CommandBuffer.WaitOnAsyncGraphicsFence()",
            也不会其任何作用;

            参数:
            fenceType:
                The type of GraphicsFence to create. 
                Currently the only supported value is "GraphicsFenceType.AsyncQueueSynchronization"

            stage:
                在有些平台, 在单个 draw call 的 vs的结束点 和 fs开始点 之间存在一段明显的间隙;
                可用本参数来设置 GraphicsFence 的时间节点, 要么在 vs的结束点, 要么在 fs的结束点;    
                If a "compute shader dispatch" was the last task submitted then this parameter is ignored.
        */
        public static GraphicsFence CreateGraphicsFence(
            GraphicsFenceType fenceType, 
            [Internal.DefaultValue("SynchronisationStage.PixelProcessing")] SynchronisationStageFlags stage
        );
        
        
        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("Method DrawMesh has been deprecated. Use Graphics.DrawMeshNow instead (UnityUpgradable) -> DrawMeshNow(*)", true)]
        public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("Method DrawMesh has been deprecated. Use Graphics.DrawMeshNow instead (UnityUpgradable) -> DrawMeshNow(*)", true)]
        public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, int materialIndex);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("Method DrawMesh has been deprecated. Use Graphics.DrawMeshNow instead (UnityUpgradable) -> DrawMeshNow(*)", true)]
        public static void DrawMesh(Mesh mesh, Matrix4x4 matrix);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("Method DrawMesh has been deprecated. Use Graphics.DrawMeshNow instead (UnityUpgradable) -> DrawMeshNow(*)", true)]
        public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, int materialIndex);
        */
       
       
        
        /*
            摘要:
            Draw a mesh.

            本函数在一帧内绘制 mesh, 这个 mesh 能收到 lights 的影响, 可以投射阴影, 接收阴影,
            可以受到 Projectors 的影响(一个几乎废弃的功能);
            就好像这个 mesh 是某个 go 的一部分;

            这个 mesh 可以被所有 camera 绘制, 或某些特定的 camera;

            本函数适用于:
                你想要绘制大量 meshes, 但又不想承担 创建和管理 GameObj 实例 的成本;

            注意, 本函数不会立即绘制 mesh, 它仅仅是将 mesh submit 到 渲染队列中去;
            当常规的 渲染过程开始执行时, 这个 mesh 就会被 渲染;
            如果你向立即渲染一个 mesh, 应该调用 "Graphics.DrawMeshNow()";

            因为本函数不会立即渲染 mesh, 在两次本函数调用的中间间隙, 修改 material properties,
            最终会让 前后两次 mesh 绘制出相同的效果;

            此时, 你应该改用 参数 properties ("MaterialPropertyBlock") 来营造差异;

            注意:
            调用本函数 将在 "mesh 在等待被渲染期间" 在内部创建一些资源;
            这些资源会被立即分配, 
            -- 若将 mesh 分配给所有 cameras, 那么这个中间资源将在本帧的结束时才被释放;
            -- 若将 mesh 分配给某个特定的 camera, 那么这个中间资源将在 目标 camera 渲染结束后 被释放;
            
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   position:
        //     Position of the mesh.
        //
        //   rotation:
        //     Rotation of the mesh.
        //
        //   matrix:
        //     Transformation matrix of the mesh (combines position, rotation and other transformations).
        //
        //   material:
        //     Material to use.
        //
        //   layer:
        //     "Layer" to use.  猜测是 mesh 的
        //
        //   camera:
        //     If null (default), the mesh will be drawn in all cameras. Otherwise it will be
        //     rendered in the given Camera only.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This applies only to meshes that are composed
        //     of several materials.
        //
        //   properties:
        //     Additional material properties to apply onto material just before this mesh will
        //     be drawn. See "MaterialPropertyBlock".
        //
        //   castShadows:
        //     Determines whether the mesh can cast shadows.
        //
        //   receiveShadows:
        //     Determines whether the mesh can receive shadows.
        //
        //   useLightProbes:
        //     Should the mesh use light probes?
        //
        //   probeAnchor:
        //     If used light probes, the mesh will use this Transform's position to sample light probes and
        //     find the matching reflection probe.
        //
        //   lightProbeUsage:
        //     LightProbeUsage for the mesh.
        //
        //   lightProbeProxyVolume:
        */
        public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, [Internal.DefaultValue("true")] bool receiveShadows, [Internal.DefaultValue("null")] Transform probeAnchor, [Internal.DefaultValue("true")] bool useLightProbes);
        
        public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, [Internal.DefaultValue("null")] Camera camera, [Internal.DefaultValue("0")] int submeshIndex, [Internal.DefaultValue("null")] MaterialPropertyBlock properties, [Internal.DefaultValue("true")] bool castShadows, [Internal.DefaultValue("true")] bool receiveShadows, [Internal.DefaultValue("true")] bool useLightProbes);
        public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor, LightProbeUsage lightProbeUsage, [Internal.DefaultValue("null")] LightProbeProxyVolume lightProbeProxyVolume);
        public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, [Internal.DefaultValue("true")] bool receiveShadows, [Internal.DefaultValue("null")] Transform probeAnchor, [Internal.DefaultValue("true")] bool useLightProbes);
        public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, [Internal.DefaultValue("null")] Camera camera, [Internal.DefaultValue("0")] int submeshIndex, [Internal.DefaultValue("null")] MaterialPropertyBlock properties, [Internal.DefaultValue("true")] bool castShadows, [Internal.DefaultValue("true")] bool receiveShadows, [Internal.DefaultValue("true")] bool useLightProbes);
        
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows, bool receiveShadows);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows, bool receiveShadows);
            [ExcludeFromDocs]public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor, LightProbeUsage lightProbeUsage);
            



        
        /*
            摘要:
            Draws the same mesh multiple times using "GPU instancing".
        
            和 "Graphics.DrawMesh()" 类似, 本函数在一帧之内将一个 mesh 绘制很多次, 
            而不需要为这些 mesh 创建 go 实例;

            本函数和 GPU Instancing 技术有关;

            Unity culls and sorts instanced Meshes as a group. 

            它创建一个 AABB 盒, 包含所有的 meshes, 计算这个 aabb 盒的 center point,
            然后使用这个信息来 cull 和 sort 这些 mesh instances;

            注意:
            在对 "combined instances "执行完上述的 culling 和 sorting 操作后, 
            unity 不再对 "单个 mesh instance" 执行 view frustum or baked occluder culling;

            它也不会对 "单个 mesh instance" 执行排序 for transparency or depth efficiency.

            每个 instance 的 转换矩阵 应该收集放入 参数 matrices 中;
            你可以指定 instance 的数量, 或者, 它通常是 参数 matrices 中元素的个数;

            至于其它 逐-instance 数据, 如果 shader 对此有需求, 应该通过参数 properties 提供,

            若想使用 light probe, 通过 MaterialPropertyBlock 提供 light probe data
            and specify lightProbeUsage with LightProbeUsage.CustomProvided. 
            查看: "LightProbes.CalculateInterpolatedLightAndOcclusionProbes()"

            注意, 
                最多只能绘制 1023 个 instances;

            如果参数 material 没有开启 "Material.enableInstancing", 或者当前api 不支持 GPU Instancing,
            将抛出异常;
            可查看: "SystemInfo.supportsInstancing";

            catlike 教程中使用过此函数;

        参数:
          mesh:
            The Mesh to draw.
        
          submeshIndex:
            Which subset of the mesh to draw. This applies only to meshes that are composed
            of several materials.
        
          material:
            Material to use.
        
          matrices:
            The array of object transformation matrices.
        
          count:
            The number of instances to be drawn.  要绘制的实例的数量 
        
          properties:
            Additional material properties to apply. See MaterialPropertyBlock.
        
          castShadows:
            Determines whether the Meshes should cast shadows.
        
          receiveShadows:
            Determines whether the Meshes should receive shadows.
        
          layer:
            Layer to use.
        
          camera:
            If null (default), the mesh will be drawn in all cameras. Otherwise it will be
            drawn in the given Camera only.
        
          lightProbeUsage:
            LightProbeUsage for the instances.
        
          lightProbeProxyVolume:
        */
        public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, [Internal.DefaultValue("matrices.Length")] int count, [Internal.DefaultValue("null")] MaterialPropertyBlock properties, [Internal.DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, [Internal.DefaultValue("true")] bool receiveShadows, [Internal.DefaultValue("0")] int layer, [Internal.DefaultValue("null")] Camera camera, [Internal.DefaultValue("LightProbeUsage.BlendProbes")] LightProbeUsage lightProbeUsage, [Internal.DefaultValue("null")] LightProbeProxyVolume lightProbeProxyVolume);
        public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, [Internal.DefaultValue("null")] MaterialPropertyBlock properties, [Internal.DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, [Internal.DefaultValue("true")] bool receiveShadows, [Internal.DefaultValue("0")] int layer, [Internal.DefaultValue("null")] Camera camera, [Internal.DefaultValue("LightProbeUsage.BlendProbes")] LightProbeUsage lightProbeUsage, [Internal.DefaultValue("null")] LightProbeProxyVolume lightProbeProxyVolume);
        
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera, LightProbeUsage lightProbeUsage);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties, ShadowCastingMode castShadows);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera);
            [ExcludeFromDocs]public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera, LightProbeUsage lightProbeUsage);
            

        
        /*
            摘要:
            Draws the same mesh multiple times using GPU instancing.
        
            和 "Graphics.DrawMeshInstanced()" 类似, 不同点在于, 本函数中, 
            绘制多少个 instances 的数据, 来自于参数 bufferWithArgs;

            tpr:
                改用 ComputeBuffer/GraphicsBuffer 来存储 各个 instance 的绘制信息;

            Meshes are not further culled by the view frustum or baked occluders, 
            nor sorted for transparency or z efficiency.

            参数 "bufferWithArgs", has to have five integer numbers at given argsOffset offset: 
            -- index count per instance, 
            -- instance count, 
            -- start index location, 
            -- base vertex location, 
            -- start instance location.

            只有当 mesh 体内的 submeshes 拥有不同的 拓扑结构时, (比如, 三角形 和 直线)
            unity 才会用到 参数 submeshIndex;
            否则, all the information about which submesh to draw comes from the 参数 "bufferWithArgs";

            文档给出了 示范代码;

        参数:
          mesh:
            The Mesh to draw.
        
          submeshIndex:
            Which subset of the mesh to draw. This applies only to meshes that are composed
            of several materials.
        
          material:
            Material to use.
        
          bounds:
            The bounding volume surrounding the instances you intend to draw.
        
          bufferWithArgs:
            The GPU buffer containing the arguments for how many instances of this mesh to
            draw.
        
          argsOffset:
            The byte offset into the buffer, where the draw arguments start.
        
          properties:
            Additional material properties to apply. See MaterialPropertyBlock.
        
          castShadows:
            Determines whether the mesh can cast shadows.
        
          receiveShadows:
            Determines whether the mesh can receive shadows.
        
          layer:
            Layer to use.
        
          camera:
            If null (default), the mesh will be drawn in all cameras. Otherwise it will be
            drawn in the given Camera only.
        
          lightProbeUsage:
            LightProbeUsage for the instances.
        
          lightProbeProxyVolume:
        */
        public static void DrawMeshInstancedIndirect(
            Mesh mesh, 
            int submeshIndex, 
            Material material, 
            Bounds bounds, 
            ComputeBuffer bufferWithArgs, 
            [Internal.DefaultValue("0")] int argsOffset, 
            [Internal.DefaultValue("null")] MaterialPropertyBlock properties, 
            [Internal.DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, 
            [Internal.DefaultValue("true")] bool receiveShadows, 
            [Internal.DefaultValue("0")] int layer, 
            [Internal.DefaultValue("null")] Camera camera, 
            [Internal.DefaultValue("LightProbeUsage.BlendProbes")] LightProbeUsage lightProbeUsage, 
            [Internal.DefaultValue("null")] LightProbeProxyVolume lightProbeProxyVolume
        );

        public static void DrawMeshInstancedIndirect(
            Mesh mesh, 
            int submeshIndex, 
            Material material, 
            Bounds bounds, 
            GraphicsBuffer bufferWithArgs, 
            [Internal.DefaultValue("0")] int argsOffset, 
            [Internal.DefaultValue("null")] MaterialPropertyBlock properties, 
            [Internal.DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, 
            [Internal.DefaultValue("true")] bool receiveShadows, 
            [Internal.DefaultValue("0")] int layer, 
            [Internal.DefaultValue("null")] Camera camera, 
            [Internal.DefaultValue("LightProbeUsage.BlendProbes")] LightProbeUsage lightProbeUsage, 
            [Internal.DefaultValue("null")] LightProbeProxyVolume lightProbeProxyVolume
        );
        
            [ExcludeFromDocs]public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset = 0, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0, Camera camera = null, LightProbeUsage lightProbeUsage = LightProbeUsage.BlendProbes);
            [ExcludeFromDocs]public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, GraphicsBuffer bufferWithArgs, int argsOffset = 0, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0, Camera camera = null, LightProbeUsage lightProbeUsage = LightProbeUsage.BlendProbes);
            

        
        /*
            摘要:
            Draws the same mesh multiple times using GPU instancing. 
            
            本函数和 "Graphics.DrawMeshInstancedIndirect()" 相似, 
            只不过 instance 的数量 可以直接通过 参数 count 提供, 而不需要通过 ComputeBuffer;

            若想使用 light probe, 通过 MaterialPropertyBlock 提供 light probe data
            and specify lightProbeUsage with LightProbeUsage.CustomProvided. 
            查看: "LightProbes.CalculateInterpolatedLightAndOcclusionProbes()"

            catlike 数个教程中都是使用过此函数


        参数:
          mesh:
            The Mesh to draw.
        
          submeshIndex:
            Which subset of the mesh to draw. This applies only to meshes that are composed
            of several materials.
        
          material:
            Material to use.
        
          bounds:
            The bounding volume surrounding the instances you intend to draw.
        
          count:
            The number of instances to be drawn.
        
          properties:
            Additional material properties to apply. See MaterialPropertyBlock.
        
          castShadows:
            Determines whether the Meshes should cast shadows.
        
          receiveShadows:
            Determines whether the Meshes should receive shadows.
        
          layer:
            to use.
        
          camera:
            If null (default), the mesh will be drawn in all cameras. Otherwise it will be
            drawn in the given Camera only.
        
          lightProbeUsage:
            LightProbeUsage for the instances.
        
          lightProbeProxyVolume:
        */
        public static void DrawMeshInstancedProcedural(
            Mesh mesh, int submeshIndex, Material material, Bounds bounds, int count, 
            MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, 
            bool receiveShadows = true, int layer = 0, Camera camera = null, 
            LightProbeUsage lightProbeUsage = LightProbeUsage.BlendProbes, LightProbeProxyVolume lightProbeProxyVolume = null
        );
        


        /*
            摘要:
            Draw a mesh immediately.
            
            Currently set shader and material (see "Material.SetPass()") will be used.

            The mesh will be just drawn once, 
            此mesh 不会执行 逐像素-光照计算, 不投射阴影, 不接收阴影, 
            如果需要上述内容, 应该改用 "Graphics.DrawMesh()";
            
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   position:
        //     Position of the mesh.
        //
        //   rotation:
        //     Rotation of the mesh.
        //
        //   matrix:
        //     The transformation matrix of the mesh (combines position, rotation and other
        //     transformations).
        //
        //   materialIndex:
        //     Subset of the mesh to draw.
        */
        public static void DrawMeshNow(Mesh mesh, Matrix4x4 matrix);
        public static void DrawMeshNow(Mesh mesh, Vector3 position, Quaternion rotation);
        public static void DrawMeshNow(Mesh mesh, Matrix4x4 matrix, int materialIndex);
        public static void DrawMeshNow(Mesh mesh, Vector3 position, Quaternion rotation, int materialIndex);


        /*
            摘要:
            Draws procedural geometry on the GPU.
            do a draw call on the GPU, without any vertex or index buffers. 

            This is mainly useful on "Shader Model 4.5 level hardware" 
            where shaders can read arbitrary data from ComputeBuffer buffers.

            "CommandBuffer.DrawProcedural()" 和本函数相似;

        // 参数:
        //   material:
        //     Material to use.
        //
        //   bounds:
        //     The bounding volume surrounding the instances you intend to draw.
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.
        //
        //   instanceCount:
        //     Instance count to render.  实例数量
        //
        //   indexCount:
        //     Index count to render. 
        //
        //   camera:
        //     If null (default), the mesh will be drawn in all cameras. Otherwise it will be
        //     rendered in the given Camera only.
        //
        //   properties:
        //     Additional material properties to apply onto material just before this mesh will
        //     be drawn. See MaterialPropertyBlock.
        //
        //   castShadows:
        //     Determines whether the mesh can cast shadows.
        //
        //   receiveShadows:
        //     Determines whether the mesh can receive shadows.
        //
        //   layer:
        //     Layer to use.
        */
        public static void DrawProcedural(Material material, Bounds bounds, MeshTopology topology, GraphicsBuffer indexBuffer, int indexCount, int instanceCount = 1, Camera camera = null, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0);
        public static void DrawProcedural(Material material, Bounds bounds, MeshTopology topology, int vertexCount, int instanceCount = 1, Camera camera = null, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0);
        


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("Method DrawProcedural has been deprecated. Use Graphics.DrawProceduralNow instead. (UnityUpgradable) -> DrawProceduralNow(*)", true)]
        public static void DrawProcedural(MeshTopology topology, int vertexCount, int instanceCount = 1);
        */
        

        /*
            摘要:
            Draws procedural geometry on the GPU.
            does a draw call on the GPU, without any vertex or index buffers. 
            
            The amount of geometry to draw is read from a ComputeBuffer. 

            主要用途为: generating an "arbitrary amount of data" from a ComputeShader and then rendering that, 
            without requiring a readback to the CPU.

            主用于 "Shader Model 4.5 level hardware" where shaders can read arbitrary data from ComputeBuffer buffers.

            参数 "bufferWithArgs", 需要拥有 four integer numbers at given argsOffset offset: 
                -- vertex count per instance, 
                -- instance count, 
                -- start vertex location, 
                -- start instance location. 
                
            This maps to Direct3D11 "DrawInstancedIndirect()" and equivalent functions on other graphics APIs. 
            
            在早于 4.2的 Opengl 版本, 和所有 OpenGL ES 的支持 "indirect draw" 的版本,
            the last argument is reserved and therefore must be zero.

            本函数和 "CommandBuffer.DrawProceduralIndirect.()" 类似;

        // 参数:
        //   material:
        //     Material to use.
        //
        //   bounds:
        //     The bounding volume surrounding the instances you intend to draw.
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.
        //
        //   camera:
        //     If null (default), the mesh will be drawn in all cameras. Otherwise it will be
        //     rendered in the given Camera only.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        //
        //   properties:
        //     Additional material properties to apply onto material just before this mesh will
        //     be drawn. See MaterialPropertyBlock.
        //
        //   castShadows:
        //     Determines whether the mesh can cast shadows.
        //
        //   receiveShadows:
        //     Determines whether the mesh can receive shadows.
        //
        //   layer:
        //     to use.
        */
        public static void DrawProceduralIndirect(Material material, Bounds bounds, MeshTopology topology, GraphicsBuffer indexBuffer, ComputeBuffer bufferWithArgs, int argsOffset = 0, Camera camera = null, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0);
        public static void DrawProceduralIndirect(Material material, Bounds bounds, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset = 0, Camera camera = null, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0);
        
        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("Method DrawProceduralIndirect has been deprecated. Use Graphics.DrawProceduralIndirectNow instead. (UnityUpgradable) -> DrawProceduralIndirectNow(*)", true)]
        public static void DrawProceduralIndirect(MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset = 0);
        */
        


        /*
            摘要:
            Draws procedural geometry on the GPU.

            does a draw call on the GPU, without any vertex or index buffers. 
            The amount of geometry to draw is read from a ComputeBuffer. 

            主要用途为 generating an arbitrary amount of data from a ComputeShader and then rendering that, 
            without requiring a readback to the CPU.

            主用于 "Shader Model 4.5 level hardware" 
            where shaders can read arbitrary data from ComputeBuffer buffers.

            参数 "bufferWithArgs", 必须拥有 four integer numbers at given argsOffset offset: 
                -- vertex count per instance, 
                -- instance count, 
                -- start vertex location, 
                -- start instance location. 
    
            This maps to Direct3D11 "DrawInstancedIndirect" 
            and equivalent functions on other graphics APIs. 
    
            在早于 4.2的 Opengl 版本, 和所有 OpenGL ES 的支持 "indirect draw" 的版本,
            the last argument is reserved and therefore must be zero.

            注意:
            本函数立即执行, 类似 "Graphics.DrawMeshNow()", 
            It uses the currently set "render target", transformation matrices and shader pass.

            类似的函数有 "CommandBuffer.DrawProceduralIndirect()"

        // 参数:
        //   topology:
        //     Topology of the procedural geometry.

        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        */
        public static void DrawProceduralIndirectNow(MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset = 0);
        public static void DrawProceduralIndirectNow(MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset = 0);
        public static void DrawProceduralIndirectNow(MeshTopology topology, GraphicsBuffer indexBuffer, ComputeBuffer bufferWithArgs, int argsOffset = 0);
        public static void DrawProceduralIndirectNow(MeshTopology topology, GraphicsBuffer indexBuffer, GraphicsBuffer bufferWithArgs, int argsOffset = 0);
        
        
        /*
            摘要:
            Draws procedural geometry on the GPU.
        
            does a draw call on the GPU, without any vertex or index buffers. 

            主用于 on Shader Model 4.5 level hardware 
            where shaders can read arbitrary data from ComputeBuffer buffers.

            注意:
            本函数立即执行渲染, similar to "Graphics.DrawMeshNow()". 
            It uses the currently set render target, transformation matrices and shader pass.

            类似函数有 "CommandBuffer.DrawProcedural()"

        // 参数:
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   indexCount:
        //     Index count to render.
        //
        //   instanceCount:
        //     Instance count to render.
        //
        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.

        //   vertexCount:
        //     Vertex count to render.
        */
        public static void DrawProceduralNow(MeshTopology topology, GraphicsBuffer indexBuffer, int indexCount, int instanceCount = 1);
        public static void DrawProceduralNow(MeshTopology topology, int vertexCount, int instanceCount = 1);


        
        /*
            摘要:
            Draw a texture in screen coordinates.

            如果你想从 OnGUI 回调函数体内调用本函数, 你只能在 "EventType.Repaint" 发生时才能做;
            检测方式:

                if (Event.current.type.Equals(EventType.Repaint))
                {
                    Graphics.DrawTexture(new Rect(10, 10, 100, 100), aTexture);
                }
        
            It's probably better to use "GUI.DrawTexture()" for GUI code.

            建议查看 原文档中的示例代码;

        // 参数:
        //   screenRect:
        //     Rectangle on the screen to use for the texture. In pixel coordinates with (0,0)
        //     in the upper-left corner.
        //
        //   texture:
        //     Texture to draw.
        //
        //   sourceRect:
        //     Region of the texture to use. In normalized coordinates with (0,0) in the bottom-left
        //     corner.
        //
        //   leftBorder:
        //     Number of pixels from the left that are not affected by scale.
        //
        //   rightBorder:
        //     Number of pixels from the right that are not affected by scale.
        //
        //   topBorder:
        //     Number of pixels from the top that are not affected by scale.
        //
        //   bottomBorder:
        //     Number of pixels from the bottom that are not affected by scale.
        //
        //   color:
        //     Color that modulates(调节) the output. 
                The neutral value is (0.5, 0.5, 0.5, 0.5). Set as vertex color for the shader.
        
        //   mat:
        //     Custom Material that can be used to draw the texture. If null is passed, a default
        //     material with the Internal-GUITexture.shader is used.
        //
        //   pass:
        //     If -1 (default), draws all passes in the material. Otherwise, draws given pass
        //     only.
        */
        public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, [Internal.DefaultValue("null")] Material mat, [Internal.DefaultValue("-1")] int pass);
        public static void DrawTexture(Rect screenRect, Texture texture, [Internal.DefaultValue("null")] Material mat, [Internal.DefaultValue("-1")] int pass);
        public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, [Internal.DefaultValue("null")] Material mat, [Internal.DefaultValue("-1")] int pass);
        public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color, [Internal.DefaultValue("null")] Material mat, [Internal.DefaultValue("-1")] int pass);
        

            [ExcludeFromDocs]public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color);
            [ExcludeFromDocs]public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder);
            [ExcludeFromDocs]public static void DrawTexture(Rect screenRect, Texture texture, Material mat);
            [ExcludeFromDocs]public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat);
            [ExcludeFromDocs]public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat);
            [ExcludeFromDocs]public static void DrawTexture(Rect screenRect, Texture texture);
            [ExcludeFromDocs]public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder);
            [ExcludeFromDocs]public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color, Material mat);
            
        
        /*
            摘要:
            Execute a command buffer.
            All commands in the buffer will be executed immediately.
        
        // 参数:
        //   buffer:
        //     The buffer to execute.
        */
        [NativeMethodAttribute(Name = "GraphicsScripting::ExecuteCommandBuffer", IsFreeFunction = true, ThrowsException = true)]
        public static void ExecuteCommandBuffer([NotNullAttribute("ArgumentNullException")] CommandBuffer buffer);


        /*
            摘要:
            Executes a command buffer on an async compute queue 
            with the queue selected based on the "ComputeQueueType" parameter passed.

            要求 command buffer 内的所有 commands, 它们的类型都要支持 async compute queues;
            如果其中有一个 command 不符合要求, editor 就会报错;

            异步执行所允许的 "CommandBuffer" class 的函数们, 被罗列在 原生文档中,在此略

            command buffer 中的所有 commands, 被保证一定会在 same queue 中被执行;
            如果目标平台不支持 async compute queues, then the work is dispatched on the graphics queue.

        // 参数:
        //   buffer:
        //     The CommandBuffer to be executed.
        //
        //   queueType:
        //     Describes the desired async compute queue the supplied CommandBuffer should be
        //     executed on.
        */
        [NativeMethodAttribute(Name = "GraphicsScripting::ExecuteCommandBufferAsync", IsFreeFunction = true, ThrowsException = true)]
        public static void ExecuteCommandBufferAsync([NotNullAttribute("ArgumentNullException")] CommandBuffer buffer, ComputeQueueType queueType);
        
        
        /*
            摘要:
            Set "random write target" for "Shader Model 4.5 的 frag-shaders";
        
            Shader Model 4.5 及以上版本的 frag shader 可以向某些 texture/buffer 的任意地址 写入数据;
            在 d3d11 中被称为 "unordered access views" (UAV);

            "random write targets" 的设置 和 "multiple render targets" 的设置是相似的;

            要么使用一个 启用了 "enableRandomWrite" flag 的 RenderTexture 来当作 target,
            要么使用一个 ComputeBuffer 来当作 target,

            在不同平台上, UAV indexing 存在微小不同;

            On DX11 the first valid "UAV index" is the number of active render targets. 
            所以,在 "single render target" 的大部分情景中, the UAV indexing will start from 1. 
            那些使用 "automatically translated HLSL shaders" 的平台也会符合此规则; 

            但是, 手写的 GLSL shader, 它们的 UAV indexes will match the bindings.
            On PS4 the indexing starts always from 1 to match the most common case.

            When setting a ComputeBuffer, the preserveCounterValue parameter 指示了:
            是否保留 counter 值不变, 还是将它重置为 0 (这是默认行为)

            这些 targets 保持 set, 直到你手动调用 "Graphics.ClearRandomWriteTargets()"
            在你的渲染完成后, 最好及时调用这个 clear 函数;
            如果你漏掉了这一步, 会出现 渲染错误, 一些 built-in unity pass 会崩溃;

        // 参数:
        //   index:
        //     Index of the "random write target" in the shader.
        //
        //   uav:
        //     Buffer or texture to set as the "write target"."
        //
        //   preserveCounterValue:
        //     Whether to leave the append/consume counter value unchanged.
        */
        public static void SetRandomWriteTarget(int index, GraphicsBuffer uav, [Internal.DefaultValue("false")] bool preserveCounterValue);
        public static void SetRandomWriteTarget(int index, RenderTexture uav);
        public static void SetRandomWriteTarget(int index, ComputeBuffer uav, [Internal.DefaultValue("false")] bool preserveCounterValue);
        
            [ExcludeFromDocs]public static void SetRandomWriteTarget(int index, GraphicsBuffer uav);
            [ExcludeFromDocs]public static void SetRandomWriteTarget(int index, ComputeBuffer uav);


        
        /*
            摘要:
            Sets current render target.
        
            本函数设置了, 接下来的渲染将要被写入 "哪一个 render texture" 或 "那一对 render buffer 组合";

            带有参数 "colorBuffers" 的那个重载, 可以让 frag-shader 向 "Multiple Render Targets" 写入数据

            调用只有一个 rendertarget 参数的重载版本, is the same as setting "RenderTexture.active" property.

            注意:
            当启用了 linear 工作流, 设置正确的 sRGB<->Linear 转换是很有必要的 (针对 render texture)
            Depending on what was rendered previously, the current state might not be the one you expect. 
            You should consider setting "GL.sRGBWrite()" as you need it before doing SetRenderTarget 
            or any other manual rendering.

        // 参数:
        //   rt:
        //     RenderTexture to set as active render target.
        //
        //   mipLevel:
        //     Mipmap level to render into (use 0 if not mipmapped).
        //
        //   face:
        //     Cubemap face to render into (use Unknown if not a cubemap).
        //
        //   depthSlice:
        //     Depth slice to render into (use 0 if not a 3D or 2DArray render target).
        //
        //   colorBuffer:
        //     Color buffer to render into.
        //
        //   depthBuffer:
        //     Depth buffer to render into.
        //
        //   colorBuffers:
        //     Color buffers to render into (for multiple render target effects).
        //
        //   setup:
        //     Full render target setup information.
        */
        public static void SetRenderTarget(RenderTargetSetup setup);
        public static void SetRenderTarget(RenderBuffer[] colorBuffers, RenderBuffer depthBuffer);
        public static void SetRenderTarget(
            RenderBuffer colorBuffer, 
            RenderBuffer depthBuffer, 
            [Internal.DefaultValue("0")] int mipLevel, 
            [Internal.DefaultValue("CubemapFace.Unknown")] CubemapFace face, 
            [Internal.DefaultValue("0")] int depthSlice);
        public static void SetRenderTarget(
            RenderTexture rt, 
            [Internal.DefaultValue("0")] int mipLevel, 
            [Internal.DefaultValue("CubemapFace.Unknown")] CubemapFace face, 
            [Internal.DefaultValue("0")] int depthSlice);

            [ExcludeFromDocs] public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel, CubemapFace face);
            [ExcludeFromDocs] public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer);
            [ExcludeFromDocs] public static void SetRenderTarget(RenderTexture rt, int mipLevel, CubemapFace face);
            [ExcludeFromDocs] public static void SetRenderTarget(RenderTexture rt, int mipLevel);
            [ExcludeFromDocs] public static void SetRenderTarget(RenderTexture rt);
            [ExcludeFromDocs] public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel);
            
        
        
        
        /*
            摘要:
            本函数要求 "graphics queue" 的 gpu端运算 进入待机状态, 直到参数 fence 被 passed 为止
            ( GraphicsFence 是个时间节点, "被 passed" 就是指: 到达这个时间节点了 )


            有的平台无法区别 vs的开始点 和 fs的开始点, 在这样的平台, fence 始终被设置在 下一个 vs开始点;
            此时, 参数 stage 不起任何作用;

            参数 fence 在被创建时, 必须指定为: "GraphicsFenceType.AsyncQueueSynchronization";

            不支持 GraphicsFences 功能的平台, 本函数可以被调用, 不过不起任何作用;
            查看: "SystemInfo.supportsGraphicsFence";

            用户使用本函数, 可能会制造出 "GPU deadlocks" (死锁), 所以在调用本函数之前, 要确保
            参数 fence 是有效的, 它的 时间节点一定能被 passed 才行;

            本函数在 cpu端一经调用立即返回, 而在 gpu端, 运算进程则会暂定下来, 直到 fence passed;

            参数:
            fence:
                在继续处理 graphics queue 之前，GPU 将被要求等待的 GraphicsFence 被passed;
            
            stage:
                在有些平台, 在单个 draw call 的 vs的结束点 和 fs开始点 之间存在一段明显的间隙;
                可用本参数来设置 GraphicsFence 的时间节点, 要么在 vs的开始点, 要么在 fs的开始点;    
                If a compute shader dispatch is the next item to be submitted then this parameter is ignored.
        */
        public static void WaitOnAsyncGraphicsFence(GraphicsFence fence);
        public static void WaitOnAsyncGraphicsFence(
            GraphicsFence fence, 
            [Internal.DefaultValue("SynchronisationStage.PixelProcessing")] SynchronisationStage stage);
        
        
        /*
        // 摘要:
        //     This functionality is deprecated, and should no longer be used. Please use Graphics.WaitOnAsyncGraphicsFence.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("WaitOnGPUFence has been deprecated. Use WaitOnAsyncGraphicsFence instead (UnityUpgradable) -> WaitOnAsyncGraphicsFence(*)", true)]
        public static void WaitOnGPUFence(GPUFence fence, [Internal.DefaultValue("UnityEngine.Rendering.SynchronisationStage.PixelProcessing")] SynchronisationStage stage);
        */

        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("WaitOnGPUFence has been deprecated. Use WaitOnAsyncGraphicsFence instead (UnityUpgradable) -> WaitOnAsyncGraphicsFence(*)", true)]
        public static void WaitOnGPUFence(GPUFence fence);
        */


    }
}
