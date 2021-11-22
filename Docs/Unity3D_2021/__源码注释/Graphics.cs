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
    public class Graphics
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
            查看: PlayerSettings.preserveFramebufferAlpha.
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
        


        // 参数:
        //   source:
        //     Source texture.
        //
        //   dest:
        //     The destination RenderTexture. Set this to null to blit directly to screen. 
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


        //
        // 摘要:
        //     Copies source texture into destination, for multi-tap shader.
        //
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
        //
        //   destDepthSlice:
        //     The texture array destination slice to blit to.
        public static void BlitMultiTap(Texture source, RenderTexture dest, Material mat, params Vector2[] offsets);
        public static void BlitMultiTap(Texture source, RenderTexture dest, Material mat, int destDepthSlice, params Vector2[] offsets);
        
        
        //
        // 摘要:
        //     Clear random write targets for level pixel shaders.
        [StaticAccessorAttribute("GetGfxDevice()", Bindings.StaticAccessorType.Dot)]
        public static void ClearRandomWriteTargets();


        //
        // 摘要:
        //     This function provides an efficient way to convert between textures of different
        //     formats and dimensions. The destination texture format should be uncompressed
        //     and correspond to a supported RenderTextureFormat.
        //
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
        public static bool ConvertTexture(Texture src, int srcElement, Texture dst, int dstElement);
        public static bool ConvertTexture(Texture src, Texture dst);


        //
        // 摘要:
        //     Copy texture contents.
        //
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
        public static void CopyTexture(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, Texture dst, int dstElement, int dstMip, int dstX, int dstY);
        public static void CopyTexture(Texture src, int srcElement, int srcMip, Texture dst, int dstElement, int dstMip);
        public static void CopyTexture(Texture src, int srcElement, Texture dst, int dstElement);
        public static void CopyTexture(Texture src, Texture dst);


        //
        // 摘要:
        //     Shortcut for calling Graphics.CreateGraphicsFence with GraphicsFenceType.AsyncQueueSynchronization
        //     as the first parameter.
        //
        // 参数:
        //   stage:
        //     The synchronization stage. See Graphics.CreateGraphicsFence.
        //
        // 返回结果:
        //     Returns a new GraphicsFence.
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

        
        public static GraphicsFence CreateGraphicsFence(GraphicsFenceType fenceType, [Internal.DefaultValue("SynchronisationStage.PixelProcessing")] SynchronisationStageFlags stage);
        
        
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
       
       
        
        //
        // 摘要:
        //     Draw a mesh.
        //
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
        //     to use.
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
        //     be drawn. See MaterialPropertyBlock.
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
        //     If used, the mesh will use this Transform's position to sample light probes and
        //     find the matching reflection probe.
        //
        //   lightProbeUsage:
        //     LightProbeUsage for the mesh.
        //
        //   lightProbeProxyVolume:
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
            



        
        //
        // 摘要:
        //     Draws the same mesh multiple times using GPU instancing.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This applies only to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   matrices:
        //     The array of object transformation matrices.
        //
        //   count:
        //     The number of instances to be drawn.
        //
        //   properties:
        //     Additional material properties to apply. See MaterialPropertyBlock.
        //
        //   castShadows:
        //     Determines whether the Meshes should cast shadows.
        //
        //   receiveShadows:
        //     Determines whether the Meshes should receive shadows.
        //
        //   layer:
        //     to use.
        //
        //   camera:
        //     If null (default), the mesh will be drawn in all cameras. Otherwise it will be
        //     drawn in the given Camera only.
        //
        //   lightProbeUsage:
        //     LightProbeUsage for the instances.
        //
        //   lightProbeProxyVolume:
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
            

        
        //
        // 摘要:
        //     Draws the same mesh multiple times using GPU instancing.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This applies only to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   bounds:
        //     The bounding volume surrounding the instances you intend to draw.
        //
        //   bufferWithArgs:
        //     The GPU buffer containing the arguments for how many instances of this mesh to
        //     draw.
        //
        //   argsOffset:
        //     The byte offset into the buffer, where the draw arguments start.
        //
        //   properties:
        //     Additional material properties to apply. See MaterialPropertyBlock.
        //
        //   castShadows:
        //     Determines whether the mesh can cast shadows.
        //
        //   receiveShadows:
        //     Determines whether the mesh can receive shadows.
        //
        //   layer:
        //     to use.
        //
        //   camera:
        //     If null (default), the mesh will be drawn in all cameras. Otherwise it will be
        //     drawn in the given Camera only.
        //
        //   lightProbeUsage:
        //     LightProbeUsage for the instances.
        //
        //   lightProbeProxyVolume:
        

        public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, [Internal.DefaultValue("0")] int argsOffset, [Internal.DefaultValue("null")] MaterialPropertyBlock properties, [Internal.DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, [Internal.DefaultValue("true")] bool receiveShadows, [Internal.DefaultValue("0")] int layer, [Internal.DefaultValue("null")] Camera camera, [Internal.DefaultValue("LightProbeUsage.BlendProbes")] LightProbeUsage lightProbeUsage, [Internal.DefaultValue("null")] LightProbeProxyVolume lightProbeProxyVolume);

        public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, GraphicsBuffer bufferWithArgs, [Internal.DefaultValue("0")] int argsOffset, [Internal.DefaultValue("null")] MaterialPropertyBlock properties, [Internal.DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, [Internal.DefaultValue("true")] bool receiveShadows, [Internal.DefaultValue("0")] int layer, [Internal.DefaultValue("null")] Camera camera, [Internal.DefaultValue("LightProbeUsage.BlendProbes")] LightProbeUsage lightProbeUsage, [Internal.DefaultValue("null")] LightProbeProxyVolume lightProbeProxyVolume);
        
            [ExcludeFromDocs]public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset = 0, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0, Camera camera = null, LightProbeUsage lightProbeUsage = LightProbeUsage.BlendProbes);
            [ExcludeFromDocs]public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, GraphicsBuffer bufferWithArgs, int argsOffset = 0, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0, Camera camera = null, LightProbeUsage lightProbeUsage = LightProbeUsage.BlendProbes);
            

        
        //
        // 摘要:
        //     Draws the same mesh multiple times using GPU instancing. This is similar to Graphics.DrawMeshInstancedIndirect,
        //     except that when the instance count is known from script, it can be supplied
        //     directly using this method, rather than via a ComputeBuffer.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This applies only to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   bounds:
        //     The bounding volume surrounding the instances you intend to draw.
        //
        //   count:
        //     The number of instances to be drawn.
        //
        //   properties:
        //     Additional material properties to apply. See MaterialPropertyBlock.
        //
        //   castShadows:
        //     Determines whether the Meshes should cast shadows.
        //
        //   receiveShadows:
        //     Determines whether the Meshes should receive shadows.
        //
        //   layer:
        //     to use.
        //
        //   camera:
        //     If null (default), the mesh will be drawn in all cameras. Otherwise it will be
        //     drawn in the given Camera only.
        //
        //   lightProbeUsage:
        //     LightProbeUsage for the instances.
        //
        //   lightProbeProxyVolume:
        public static void DrawMeshInstancedProcedural(Mesh mesh, int submeshIndex, Material material, Bounds bounds, int count, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0, Camera camera = null, LightProbeUsage lightProbeUsage = LightProbeUsage.BlendProbes, LightProbeProxyVolume lightProbeProxyVolume = null);
        
        //
        // 摘要:
        //     Draw a mesh immediately.
        //
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
        public static void DrawMeshNow(Mesh mesh, Matrix4x4 matrix);
        public static void DrawMeshNow(Mesh mesh, Vector3 position, Quaternion rotation);
        public static void DrawMeshNow(Mesh mesh, Matrix4x4 matrix, int materialIndex);
        public static void DrawMeshNow(Mesh mesh, Vector3 position, Quaternion rotation, int materialIndex);


        //
        // 摘要:
        //     Draws procedural geometry on the GPU.
        //
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
        //     Instance count to render.
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
        //     to use.
        public static void DrawProcedural(Material material, Bounds bounds, MeshTopology topology, GraphicsBuffer indexBuffer, int indexCount, int instanceCount = 1, Camera camera = null, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0);
        public static void DrawProcedural(Material material, Bounds bounds, MeshTopology topology, int vertexCount, int instanceCount = 1, Camera camera = null, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0);
        
        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("Method DrawProcedural has been deprecated. Use Graphics.DrawProceduralNow instead. (UnityUpgradable) -> DrawProceduralNow(*)", true)]
        public static void DrawProcedural(MeshTopology topology, int vertexCount, int instanceCount = 1);
        */
        
        //
        // 摘要:
        //     Draws procedural geometry on the GPU.
        //
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
        public static void DrawProceduralIndirect(Material material, Bounds bounds, MeshTopology topology, GraphicsBuffer indexBuffer, ComputeBuffer bufferWithArgs, int argsOffset = 0, Camera camera = null, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0);
        public static void DrawProceduralIndirect(Material material, Bounds bounds, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset = 0, Camera camera = null, MaterialPropertyBlock properties = null, ShadowCastingMode castShadows = ShadowCastingMode.On, bool receiveShadows = true, int layer = 0);
        
        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ExcludeFromDocs]
        [Obsolete("Method DrawProceduralIndirect has been deprecated. Use Graphics.DrawProceduralIndirectNow instead. (UnityUpgradable) -> DrawProceduralIndirectNow(*)", true)]
        public static void DrawProceduralIndirect(MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset = 0);
        */
        
        //
        // 摘要:
        //     Draws procedural geometry on the GPU.
        //
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
        public static void DrawProceduralIndirectNow(MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset = 0);
        public static void DrawProceduralIndirectNow(MeshTopology topology, GraphicsBuffer indexBuffer, ComputeBuffer bufferWithArgs, int argsOffset = 0);
        public static void DrawProceduralIndirectNow(MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset = 0);

        public static void DrawProceduralIndirectNow(MeshTopology topology, GraphicsBuffer indexBuffer, GraphicsBuffer bufferWithArgs, int argsOffset = 0);
        
        
        //
        // 摘要:
        //     Draws procedural geometry on the GPU.
        //
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

        public static void DrawProceduralNow(MeshTopology topology, GraphicsBuffer indexBuffer, int indexCount, int instanceCount = 1);
        public static void DrawProceduralNow(MeshTopology topology, int vertexCount, int instanceCount = 1);


        
        //
        // 摘要:
        //     Draw a texture in screen coordinates.
        //
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
        //     Color that modulates the output. The neutral value is (0.5, 0.5, 0.5, 0.5). Set
        //     as vertex color for the shader.
        //
        //   mat:
        //     Custom Material that can be used to draw the texture. If null is passed, a default
        //     material with the Internal-GUITexture.shader is used.
        //
        //   pass:
        //     If -1 (default), draws all passes in the material. Otherwise, draws given pass
        //     only.
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
            
        
        //
        // 摘要:
        //     Execute a command buffer.
        //
        // 参数:
        //   buffer:
        //     The buffer to execute.
        [NativeMethodAttribute(Name = "GraphicsScripting::ExecuteCommandBuffer", IsFreeFunction = true, ThrowsException = true)]
        public static void ExecuteCommandBuffer([NotNullAttribute("ArgumentNullException")] CommandBuffer buffer);


        //
        // 摘要:
        //     Executes a command buffer on an async compute queue with the queue selected based
        //     on the ComputeQueueType parameter passed.
        //
        // 参数:
        //   buffer:
        //     The CommandBuffer to be executed.
        //
        //   queueType:
        //     Describes the desired async compute queue the supplied CommandBuffer should be
        //     executed on.
        [NativeMethodAttribute(Name = "GraphicsScripting::ExecuteCommandBufferAsync", IsFreeFunction = true, ThrowsException = true)]
        public static void ExecuteCommandBufferAsync([NotNullAttribute("ArgumentNullException")] CommandBuffer buffer, ComputeQueueType queueType);
        
        
        //
        // 摘要:
        //     Set random write target for level pixel shaders.
        //
        // 参数:
        //   index:
        //     Index of the random write target in the shader.
        //
        //   uav:
        //     Buffer or texture to set as the write target.
        //
        //   preserveCounterValue:
        //     Whether to leave the append/consume counter value unchanged.
        public static void SetRandomWriteTarget(int index, GraphicsBuffer uav, [Internal.DefaultValue("false")] bool preserveCounterValue);
        public static void SetRandomWriteTarget(int index, RenderTexture uav);
        public static void SetRandomWriteTarget(int index, ComputeBuffer uav, [Internal.DefaultValue("false")] bool preserveCounterValue);
        
            [ExcludeFromDocs]public static void SetRandomWriteTarget(int index, GraphicsBuffer uav);
            [ExcludeFromDocs]public static void SetRandomWriteTarget(int index, ComputeBuffer uav);


        
        //
        // 摘要:
        //     Sets current render target.
        //
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
        public static void SetRenderTarget(RenderBuffer[] colorBuffers, RenderBuffer depthBuffer);
        public static void SetRenderTarget(RenderTargetSetup setup);
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
            
        
        
        
        //
        // 摘要:
        //     Instructs the GPU's processing of the graphics queue to wait until the given
        //     GraphicsFence is passed.
        //
        // 参数:
        //   fence:
        //     The GraphicsFence that the GPU will be instructed to wait upon before proceeding
        //     with its processing of the graphics queue.
        //
        //   stage:
        //     On some platforms there is a significant gap between the vertex processing completing
        //     and the pixel processing begining for a given draw call. This parameter allows
        //     for requested wait to be before the next items vertex or pixel processing begins.
        //     If a compute shader dispatch is the next item to be submitted then this parameter
        //     is ignored.
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
