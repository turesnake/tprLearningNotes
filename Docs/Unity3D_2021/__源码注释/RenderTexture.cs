

#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.ComponentModel;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Internal;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     Render textures are textures that can be rendered to.
    [NativeHeaderAttribute("Runtime/Graphics/RenderBufferManager.h")]
    [NativeHeaderAttribute("Runtime/Graphics/RenderTexture.h")]
    [NativeHeaderAttribute("Runtime/Camera/Camera.h")]
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [UsedByNativeCodeAttribute]
    public class RenderTexture : Texture
    {
        //
        // 摘要:
        //     Creates a new RenderTexture object.
        //
        // 参数:
        //   width:
        //     Texture width in pixels.
        //
        //   height:
        //     Texture height in pixels.
        //
        //   depth:
        //     Number of bits in depth buffer (0, 16 or 24). Note that only 24 bit depth has
        //     stencil buffer.
        //
        //   format:
        //     Texture color format.
        //
        //   readWrite:
        //     How or if color space conversions should be done on texture read/write.
        //
        //   desc:
        //     Create the RenderTexture with the settings in the RenderTextureDescriptor.
        //
        //   textureToCopy:
        //     Copy the settings from another RenderTexture.
        public RenderTexture(RenderTexture textureToCopy);
        //
        // 摘要:
        //     Creates a new RenderTexture object.
        //
        // 参数:
        //   width:
        //     Texture width in pixels.
        //
        //   height:
        //     Texture height in pixels.
        //
        //   depth:
        //     Number of bits in depth buffer (0, 16 or 24). Note that only 24 bit depth has
        //     stencil buffer.
        //
        //   format:
        //     Texture color format.
        //
        //   readWrite:
        //     How or if color space conversions should be done on texture read/write.
        //
        //   desc:
        //     Create the RenderTexture with the settings in the RenderTextureDescriptor.
        //
        //   textureToCopy:
        //     Copy the settings from another RenderTexture.
        public RenderTexture(RenderTextureDescriptor desc);
        [ExcludeFromDocs]
        public RenderTexture(int width, int height, int depth);
        public RenderTexture(int width, int height, int depth, GraphicsFormat format);
        [ExcludeFromDocs]
        public RenderTexture(int width, int height, int depth, RenderTextureFormat format);
        public RenderTexture(int width, int height, int depth, DefaultFormat format);
        [ExcludeFromDocs]
        public RenderTexture(int width, int height, int depth, RenderTextureFormat format, int mipCount);
        //
        // 摘要:
        //     Creates a new RenderTexture object.
        //
        // 参数:
        //   width:
        //     Texture width in pixels.
        //
        //   height:
        //     Texture height in pixels.
        //
        //   depth:
        //     Number of bits in depth buffer (0, 16 or 24). Note that only 24 bit depth has
        //     stencil buffer.
        //
        //   format:
        //     Texture color format.
        //
        //   readWrite:
        //     How or if color space conversions should be done on texture read/write.
        //
        //   desc:
        //     Create the RenderTexture with the settings in the RenderTextureDescriptor.
        //
        //   textureToCopy:
        //     Copy the settings from another RenderTexture.
        public RenderTexture(int width, int height, int depth, [Internal.DefaultValue("RenderTextureFormat.Default")] RenderTextureFormat format, [Internal.DefaultValue("RenderTextureReadWrite.Default")] RenderTextureReadWrite readWrite);
        public RenderTexture(int width, int height, int depth, GraphicsFormat format, int mipCount);
        [RequiredByNativeCodeAttribute]
        protected internal RenderTexture();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("RenderTexture.enabled is always now, no need to use it.", false)]
        public static bool enabled { get; set; }
        //
        // 摘要:
        //     Currently active render texture.
        public static RenderTexture active { get; set; }
        
        /*
            摘要:
            If true and antiAliasing is greater than 1, the render texture will not be resolved
            by default. Use this if the render texture needs to be bound as a multisampled
            texture in a shader.
            ---
            若此变量为 true, 同时 antiAliasing 值大于1, 那么在默认情况下, render texture 不会被解析;
            (也就是保持 multisampled texture 的状态)

            当在 shader 中, 需要将一个 render texture 绑定为一个  multisampled texture 时,
            可以将此变量 设为 true;
        */
        public bool bindTextureMS { get; set; }
        

        // 摘要:
        //     The height of the render texture in pixels.
        public override int height { get; set; }
        //
        // 摘要:
        //     Dimensionality (type) of the render texture.
        public override TextureDimension dimension { get; set; }
        //
        // 摘要:
        //     If enabled, this Render Texture will be used as a Texture3D.
        [Obsolete("Use RenderTexture.dimension instead.", false)]
        public bool isVolume { get; set; }
        //
        // 摘要:
        //     The color format of the render texture.
        [NativePropertyAttribute("ColorFormat")]
        public GraphicsFormat graphicsFormat { get; set; }
        //
        // 摘要:
        //     Render texture has mipmaps when this flag is set.
        [NativePropertyAttribute("MipMap")]
        public bool useMipMap { get; set; }
        //
        // 摘要:
        //     Does this render texture use sRGB read/write conversions? (Read Only).
        [NativePropertyAttribute("SRGBReadWrite")]
        public bool sRGB { get; }
        //
        // 摘要:
        //     If this RenderTexture is a VR eye texture used in stereoscopic rendering, this
        //     property decides what special rendering occurs, if any.
        [NativePropertyAttribute("VRUsage")]
        public VRTextureUsage vrUsage { get; set; }
        //
        // 摘要:
        //     The render texture memoryless mode property.
        [NativePropertyAttribute("Memoryless")]
        public RenderTextureMemoryless memorylessMode { get; set; }
        public RenderTextureFormat format { get; set; }
        //
        // 摘要:
        //     The format of the stencil data that you can encapsulate within a RenderTexture.
        //     Specifying this property creates a stencil element for the RenderTexture and
        //     sets its format. This allows for stencil data to be bound as a Texture to all
        //     shader types for the platforms that support it. This property does not specify
        //     the format of the stencil buffer, which is constrained by the depth buffer format
        //     specified in RenderTexture.depth. Currently, most platforms only support R8_UInt
        //     (DirectX11, DirectX12), while PS4 also supports R8_UNorm.
        public GraphicsFormat stencilFormat { get; set; }
        //
        // 摘要:
        //     Mipmap levels are generated automatically when this flag is set.
        public bool autoGenerateMips { get; set; }
        [Obsolete("Use RenderTexture.dimension instead.", false)]
        public bool isCubemap { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use RenderTexture.autoGenerateMips instead (UnityUpgradable) -> autoGenerateMips", false)]
        public bool generateMips { get; set; }
        //
        // 摘要:
        //     This struct contains all the information required to create a RenderTexture.
        //     It can be copied, cached, and reused to easily create RenderTextures that all
        //     share the same properties.
        public RenderTextureDescriptor descriptor { get; set; }
        //
        // 摘要:
        //     The precision of the render texture's depth buffer in bits (0, 16, 24/32 are
        //     supported).
        public int depth { get; set; }
        //
        // 摘要:
        //     Depth/stencil buffer of the render texture (Read Only).
        public RenderBuffer depthBuffer { get; }
        //
        // 摘要:
        //     The width of the render texture in pixels.
        public override int width { get; set; }
        //
        // 摘要:
        //     Color buffer of the render texture (Read Only).
        public RenderBuffer colorBuffer { get; }
        public bool isPowerOfTwo { get; set; }
        //
        // 摘要:
        //     Is the render texture marked to be scaled by the.
        public bool useDynamicScale { get; set; }
        //
        // 摘要:
        //     Volume extent of a 3D render texture or number of slices of array texture.
        public int volumeDepth { get; set; }


        /*
            摘要:
            The antialiasing level for the RenderTexture.

            此值表示了 samples per pixel 的数量; 
            如果设置的值 不被硬件或 渲染API支持, 那就使用 小于这个变量的, 同时被系统支持的 最大的那个值;

            When a RenderTexture is using anti-aliasing, 
            then any rendering into it will happen into the multi-sampled texture, 
            which will be "resolved" into a regular texture when switching to another render target. 
            To the rest of the system only this "resolved" surface is visible.
            
            当一个 render texture 正在使用 anti-aliasing, 实际的 "渲染" 会被作用在一个 multi-sampled texture 中,
            然后当它被转换到另一张 render target 中时, 它会被 "resolved"(解析) 为一张 常规 texture, 
            对于系统中的其它部分来说, 他们能看到的只有这张 被"解析" 过的 常规 texture;
        */
        public int antiAliasing { get; set; }



        //
        // 摘要:
        //     Enable random access write into this render texture on Shader Model 5.0 level
        //     shaders.
        public bool enableRandomWrite { get; set; }

        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, RenderTextureMemoryless memorylessMode);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format, int antiAliasing, RenderTextureMemoryless memorylessMode);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, RenderTextureMemoryless memorylessMode, VRTextureUsage vrUsage);
        //
        // 摘要:
        //     Allocate a temporary render texture.
        //
        // 参数:
        //   width:
        //     Width in pixels.
        //
        //   height:
        //     Height in pixels.
        //
        //   depthBuffer:
        //     Depth buffer bits (0, 16 or 24). Note that only 24 bit depth has stencil buffer.
        //
        //   format:
        //     Render texture format.
        //
        //   readWrite:
        //     Color space conversion mode.
        //
        //   antiAliasing:
        //     Number of antialiasing samples to store in the texture. Valid values are 1, 2,
        //     4, and 8. Throws an exception if any other value is passed.
        //
        //   memorylessMode:
        //     Render texture memoryless mode.
        //
        //   desc:
        //     Use this RenderTextureDesc for the settings when creating the temporary RenderTexture.
        //
        //   vrUsage:
        //
        //   useDynamicScale:
        public static RenderTexture GetTemporary(int width, int height, [Internal.DefaultValue("0")] int depthBuffer, [Internal.DefaultValue("RenderTextureFormat.Default")] RenderTextureFormat format, [Internal.DefaultValue("RenderTextureReadWrite.Default")] RenderTextureReadWrite readWrite, [Internal.DefaultValue("1")] int antiAliasing, [Internal.DefaultValue("RenderTextureMemoryless.None")] RenderTextureMemoryless memorylessMode, [Internal.DefaultValue("VRTextureUsage.None")] VRTextureUsage vrUsage, [Internal.DefaultValue("false")] bool useDynamicScale);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format, int antiAliasing);
        //
        // 摘要:
        //     Allocate a temporary render texture.
        //
        // 参数:
        //   width:
        //     Width in pixels.
        //
        //   height:
        //     Height in pixels.
        //
        //   depthBuffer:
        //     Depth buffer bits (0, 16 or 24). Note that only 24 bit depth has stencil buffer.
        //
        //   format:
        //     Render texture format.
        //
        //   readWrite:
        //     Color space conversion mode.
        //
        //   antiAliasing:
        //     Number of antialiasing samples to store in the texture. Valid values are 1, 2,
        //     4, and 8. Throws an exception if any other value is passed.
        //
        //   memorylessMode:
        //     Render texture memoryless mode.
        //
        //   desc:
        //     Use this RenderTextureDesc for the settings when creating the temporary RenderTexture.
        //
        //   vrUsage:
        //
        //   useDynamicScale:
        public static RenderTexture GetTemporary(RenderTextureDescriptor desc);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format, int antiAliasing, RenderTextureMemoryless memorylessMode, VRTextureUsage vrUsage);
        [ExcludeFromDocs]
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format, [Internal.DefaultValue("1")] int antiAliasing, [Internal.DefaultValue("RenderTextureMemoryless.None")] RenderTextureMemoryless memorylessMode, [Internal.DefaultValue("VRTextureUsage.None")] VRTextureUsage vrUsage, [Internal.DefaultValue("false")] bool useDynamicScale);
        //
        // 摘要:
        //     Release a temporary texture allocated with GetTemporary.
        //
        // 参数:
        //   temp:
        [FreeFunctionAttribute("GetRenderBufferManager().GetTextures().ReleaseTempBuffer")]
        public static void ReleaseTemporary(RenderTexture temp);
        //
        // 摘要:
        //     Does a RenderTexture have stencil buffer?
        //
        // 参数:
        //   rt:
        //     Render texture, or null for main screen.
        [FreeFunctionAttribute("RenderTextureSupportsStencil")]
        public static bool SupportsStencil(RenderTexture rt);
        [NativeThrowsAttribute]
        public void ConvertToEquirect(RenderTexture equirect, Camera.MonoOrStereoscopicEye eye = Camera.MonoOrStereoscopicEye.Mono);
        //
        // 摘要:
        //     Actually creates the RenderTexture.
        //
        // 返回结果:
        //     True if the texture is created, else false.
        public bool Create();
        //
        // 摘要:
        //     Hint the GPU driver that the contents of the RenderTexture will not be used.
        //
        // 参数:
        //   discardColor:
        //     Should the colour buffer be discarded?
        //
        //   discardDepth:
        //     Should the depth buffer be discarded?
        public void DiscardContents(bool discardColor, bool discardDepth);
        //
        // 摘要:
        //     Hint the GPU driver that the contents of the RenderTexture will not be used.
        //
        // 参数:
        //   discardColor:
        //     Should the colour buffer be discarded?
        //
        //   discardDepth:
        //     Should the depth buffer be discarded?
        public void DiscardContents();
        //
        // 摘要:
        //     Generate mipmap levels of a render texture.
        public void GenerateMips();
        //
        // 摘要:
        //     Retrieve a native (underlying graphics API) pointer to the depth buffer resource.
        //
        // 返回结果:
        //     Pointer to an underlying graphics API depth buffer resource.
        public IntPtr GetNativeDepthBufferPtr();
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetTexelOffset always returns zero now, no point in using it.", false)]
        public Vector2 GetTexelOffset();
        //
        // 摘要:
        //     Is the render texture actually created?
        public bool IsCreated();
        //
        // 摘要:
        //     Indicate that there's a RenderTexture restore operation expected.
        [Obsolete("This function has no effect.", false)]
        public void MarkRestoreExpected();
        //
        // 摘要:
        //     Releases the RenderTexture.
        public void Release();
        //
        // 摘要:
        //     Force an antialiased render texture to be resolved.
        //
        // 参数:
        //   target:
        //     The render texture to resolve into. If set, the target render texture must have
        //     the same dimensions and format as the source.
        public void ResolveAntiAliasedSurface(RenderTexture target);
        //
        // 摘要:
        //     Force an antialiased render texture to be resolved.
        //
        // 参数:
        //   target:
        //     The render texture to resolve into. If set, the target render texture must have
        //     the same dimensions and format as the source.
        public void ResolveAntiAliasedSurface();
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("UsSetBorderColor is no longer supported.", true)]
        public void SetBorderColor(Color color);
        //
        // 摘要:
        //     Assigns this RenderTexture as a global shader property named propertyName.
        //
        // 参数:
        //   propertyName:
        [FreeFunctionAttribute(Name = "RenderTextureScripting::SetGlobalShaderProperty", HasExplicitThis = true)]
        public void SetGlobalShaderProperty(string propertyName);
    }
}



