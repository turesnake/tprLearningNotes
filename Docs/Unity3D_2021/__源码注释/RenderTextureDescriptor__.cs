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
        --
        此 struct 包含用来创建 RenderTexture 所需的一切信息。

        不要去使用 默认构造函数，因为它不会使用 推荐值 去初始化某些 flags;
    */
    public struct RenderTextureDescriptor//RenderTextureDescriptor__
    {
        /*
            摘要:
            Create a RenderTextureDescriptor with default values, or a certain width, height, and format.

            参数:
            width/height:
                Width/height of the RenderTexture in pixels.
            
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
        public VRTextureUsage vrUsage { readonly get; set; } // VR

        
        // 摘要:
        //     Determines how the RenderTexture is sampled if it is used as a shadow map.
        //      -- CompareDepths
        //      -- RawDepth
        //      -- None
        public ShadowSamplingMode shadowSamplingMode { readonly get; set; }

        
        // 摘要:
        //   Dimensionality (type) of the render texture. See Also: RenderTexture.dimension.
        //   比如:
        //      2D, cubemap, 3D, Tex2DArray, CubeArray 这种的
        public TextureDimension dimension { readonly get; set; }


        // 摘要:
        //      The precision of the render texture's depth buffer in bits 
        //      (0, 16, 24/32 are supported). 
        //      See Also: RenderTexture.depth.
        public int depthBufferBits { get; set; }

        /*
            摘要:
            你可以封装在 render texture 中的 stencil 数据 的格式;

            指定此属性将为 Render Texture 创建一个 stencil 元素, 并设置其格式; 

            这允许将 stencil 数据 作为一个 texture, 
            绑定到 "支持 stencil 的平台的" 所有的 shader 类型;

            This property does not specify the format of the stencil buffer, 
            which is constrained by the depth buffer format specified in RenderTexture.depth.
            ---
            本 property 并不指定 stencil buffer 的格式,  
            后者由 RenderTexture.depth (即 depth buffer format) 来指定;
            (没看懂...)

            目前, 大部分平台仅支持 R8_UInt (DirectX11, DirectX12), 
            while PS4 also supports R8_UNorm.
        */
        public GraphicsFormat stencilFormat { readonly get; set; }


        public RenderTextureFormat colorFormat { get; set; }

        
        /*
            If true and 本类的 msaaSamples is greater than 1, the render texture will not be resolved by default. 
            Use this if the render texture needs to be bound as a multisampled texture in a shader.
        */
        public bool bindMS { get; set; }

        
        // 摘要:
        //     The color format for the RenderTexture.
        //  存储 color 数据的 texture 使用的 format
        public GraphicsFormat graphicsFormat { get; set; }

        /*
            摘要:
            User-defined mipmap count. 感觉就是 mip 层数

            Use this property to override the number of mipmaps that will be generated for this render texture. 
            Only supported on devices that return true for SystemInfo.hasMipMaxLevel.
            
            See Also: RenderTextureDescriptor.useMipMap.
        */
        public int mipCount { readonly get; set; }
        
        /*
            摘要:
            Volume extent of a 3D render texture.

            For "volumetric render textures" (see 本类的 dimension), 
            this variable determines the volume extent. Ignored for non-3D textures. 
            
            The valid range for 3D textures is 1 to 2000.
        */
        public int volumeDepth { readonly get; set; }
        

        /*
            The multisample antialiasing level for the RenderTexture. See Also: "RenderTexture.antiAliasing".
            猜测: 单像素采样的次数: 1,2,4,8 这种;

            在 urp 中, 此值是被 SystemInfo.GetRenderTextureSupportedMSAASampleCount() 检测过的值
            (平台支持的 采样数)
        */
        public int msaaSamples { readonly get; set; }
        
        /*
            摘要:
            The width / height of the render texture in pixels.
        */
        public int height { readonly get; set; }
        public int width { readonly get; set; }

        
        // 摘要:
        //     This flag causes the render texture uses sRGB read/write conversions.
        // 若为 true, 那么不管 render texture 内部数据format 是 ldr 还是 hdr, 它的对外读写口都一定是 linear 格式的;
        public bool sRGB { get; set; }

        
        // 摘要:
        //     Set to true to enable dynamic resolution scaling on this render texture. 
        //     See Also: RenderTexture.useDynamicScale.
        public bool useDynamicScale { get; set; }
        
    }
}
