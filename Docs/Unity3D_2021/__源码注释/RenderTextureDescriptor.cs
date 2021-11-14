#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace UnityEngine
{
    /*
        摘要:
        This struct contains all the information required to create a RenderTexture.
        It can be copied, cached, and reused to easily create RenderTextures that all share the same properties. 

        不要去使用 默认构造函数，因为它不会使用 推荐值 去初始化某些 flags;
    */
    public struct RenderTextureDescriptor
    {
        /*
            摘要:
            Create a RenderTextureDescriptor with default values, or a certain width, height, and format.

            参数:
            width:
                Width of the RenderTexture in pixels.
            height:
                Height of the RenderTexture in pixels.
            
            colorFormat:
                The color format for the RenderTexture.
            
            depthBufferBits:
                The number of bits to use for the depth buffer.
                (depth can be 0, 16 or 24)
        */
        public RenderTextureDescriptor(int width, int height);
        public RenderTextureDescriptor(int width, int height, RenderTextureFormat colorFormat);
        public RenderTextureDescriptor(int width, int height, RenderTextureFormat colorFormat, int depthBufferBits);
        public RenderTextureDescriptor(int width, int height, GraphicsFormat colorFormat, int depthBufferBits);
        public RenderTextureDescriptor(int width, int height, RenderTextureFormat colorFormat, int depthBufferBits, int mipCount);
        public RenderTextureDescriptor(int width, int height, GraphicsFormat colorFormat, int depthBufferBits, int mipCount);



        
        // 摘要:
        //      Enable random access write into this render texture on Shader Model 5.0 level shaders. 
        //      See Also: RenderTexture.enableRandomWrite.
        public bool enableRandomWrite { get; set; }

        
        // 摘要:
        //     Mipmap levels are generated automatically when this flag is set.
        public bool autoGenerateMips { get; set; }

        
        // 摘要:
        //     Render texture has mipmaps when this flag is set. See Also: RenderTexture.useMipMap.
        public bool useMipMap { get; set; }

        
        // 摘要:
        //     The render texture memoryless mode property.
        public RenderTextureMemoryless memoryless { readonly get; set; }

        
        // 摘要:
        //     A set of "RenderTextureCreationFlags" that control how the texture is created.
        //     见此 enum 的详细翻译
        public RenderTextureCreationFlags flags { get; }
        

        // 摘要:
        //     If this RenderTexture is a VR eye texture used in stereoscopic rendering, this
        //     property decides what special rendering occurs, if any. Instead of setting this
        //     manually, use the value returned by XR.XRSettings.eyeTextureDesc|eyeTextureDesc
        //     or other VR functions returning a RenderTextureDescriptor.
        public VRTextureUsage vrUsage { readonly get; set; }
        //
        // 摘要:
        //     Determines how the RenderTexture is sampled if it is used as a shadow map. See
        //     Also: ShadowSamplingMode for more details.
        public ShadowSamplingMode shadowSamplingMode { readonly get; set; }
        //
        // 摘要:
        //     Dimensionality (type) of the render texture. See Also: RenderTexture.dimension.
        public TextureDimension dimension { readonly get; set; }
        //
        // 摘要:
        //     The precision of the render texture's depth buffer in bits (0, 16, 24/32 are
        //     supported). See Also: RenderTexture.depth.
        public int depthBufferBits { get; set; }
        //
        // 摘要:
        //     The format of the stencil data that you can encapsulate within a RenderTexture.
        //     Specifying this property creates a stencil element for the RenderTexture and
        //     sets its format. This allows for stencil data to be bound as a Texture to all
        //     shader types for the platforms that support it. This property does not specify
        //     the format of the stencil buffer, which is constrained by the depth buffer format
        //     specified in RenderTexture.depth. Currently, most platforms only support R8_UInt
        //     (DirectX11, DirectX12), while PS4 also supports R8_UNorm.
        public GraphicsFormat stencilFormat { readonly get; set; }
        public RenderTextureFormat colorFormat { get; set; }
        //
        // 摘要:
        //     If true and msaaSamples is greater than 1, the render texture will not be resolved
        //     by default. Use this if the render texture needs to be bound as a multisampled
        //     texture in a shader.
        public bool bindMS { get; set; }
        //
        // 摘要:
        //     The color format for the RenderTexture.
        public GraphicsFormat graphicsFormat { get; set; }
        //
        // 摘要:
        //     User-defined mipmap count.
        public int mipCount { readonly get; set; }
        //
        // 摘要:
        //     Volume extent of a 3D render texture.
        public int volumeDepth { readonly get; set; }
        //
        // 摘要:
        //     The multisample antialiasing level for the RenderTexture. See Also: RenderTexture.antiAliasing.
        public int msaaSamples { readonly get; set; }
        //
        // 摘要:
        //     The height of the render texture in pixels.
        public int height { readonly get; set; }
        //
        // 摘要:
        //     The width of the render texture in pixels.
        public int width { readonly get; set; }
        //
        // 摘要:
        //     This flag causes the render texture uses sRGB read/write conversions.
        public bool sRGB { get; set; }
        //
        // 摘要:
        //     Set to true to enable dynamic resolution scaling on this render texture. See
        //     Also: RenderTexture.useDynamicScale.
        public bool useDynamicScale { get; set; }
    }
}
