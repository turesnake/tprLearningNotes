

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
    /*
        摘要:
        Render textures are textures that can be rendered to.

        可被用来实现:
        -- image based rendering effects
        -- dynamic shadows
        -- projectors (几乎没被使用的那个东西)
        -- surveillance cameras (监控摄像机)

        一个特殊用途是, 将它们设置为一个 camera 的 "target texture" property; (Camera.targetTexture)
        此时, camera 将渲染进这个 texture 中, 而不是渲染到 屏幕上;

        注意:
        render texture 的内容可能会在某些 events 中丢失; 比如:
            -- 载入一个新的 level
            -- system going to a screensaver mode
            -- in and out of fullscreen
            -- 等等
        当这些事情发生时, 你的那些已经存在的 render textures 会再次变成 "not yet created";
        此时可使用 RenderTexture.IsCreated() 来检查;

        和其它 "native engine object" 类型一样, 需要注意 render textures 的生命周期,
        且在你完成使用后, 使用 RenderTexture.Release() 释放他们;

        这样, 它们就不会像 常规托管类型那样, 被垃圾回收了;
    */
    [NativeHeaderAttribute("Runtime/Graphics/RenderBufferManager.h")]
    [NativeHeaderAttribute("Runtime/Graphics/RenderTexture.h")]
    [NativeHeaderAttribute("Runtime/Camera/Camera.h")]
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [UsedByNativeCodeAttribute]
    public class RenderTexture : Texture//RenderTexture__
    {

        /*
            摘要:
            Creates a new RenderTexture object.

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

                在 Linear 工作流中, 如果想用本 render texture 存储 线性数据, (比如 非颜色值, 或 hdr颜色)
                可在此变量中选用: RenderTextureReadWrite.Linear;
                    此时, "RenderTexture.sRGB" 值为 false; (表示不执行任何 sRGB<->linear 转换)

                此变量默认为 "Default", 
                    在 linear 工作量中, 此模式默认 render texture 是 sRGB 空间的;
                    此时, "RenderTexture.sRGB" 值为 true; (表示执行 sRGB<->linear 转换)

                在 gamma 工作量中, render texture 是 gamma 空间, 光照计算也是 gamma 空间,
                    不需要任何 sRGB<->linear 转换,
                    此时, 本变量默认值 "Default", 意思是 不转换 (详细解释看这个 enum 翻译文件)
                    且, "RenderTexture.sRGB" 为 false;
        
        //   desc:
        //     Create the RenderTexture with the settings in the RenderTextureDescriptor.
        //
        //   textureToCopy:
        //     Copy the settings from another RenderTexture.
        */
        public RenderTexture(RenderTexture textureToCopy);
        public RenderTexture(RenderTextureDescriptor desc);
        public RenderTexture(int width, int height, int depth, GraphicsFormat format);
        public RenderTexture(int width, int height, int depth, DefaultFormat format);
        public RenderTexture(int width, int height, int depth, [Internal.DefaultValue("RenderTextureFormat.Default")] RenderTextureFormat format, [Internal.DefaultValue("RenderTextureReadWrite.Default")] RenderTextureReadWrite readWrite);
        public RenderTexture(int width, int height, int depth, GraphicsFormat format, int mipCount);

        [ExcludeFromDocs]public RenderTexture(int width, int height, int depth);
        [ExcludeFromDocs]public RenderTexture(int width, int height, int depth, RenderTextureFormat format);
        [ExcludeFromDocs]public RenderTexture(int width, int height, int depth, RenderTextureFormat format, int mipCount);



        [RequiredByNativeCodeAttribute]
        protected internal RenderTexture();


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("RenderTexture.enabled is always now, no need to use it.", false)]
        public static bool enabled { get; set; }
        */


        /*
            摘要:
            Currently active render texture.

            渲染都会被写入 active Render Texture; 
            如果 active Render Texture 是 null, 则一切都会被渲染进 main window

            设置此值, 其作用和调用 Graphics.SetRenderTarget() 是相同的;
            通常, 你会在 实现自定义图形效果时, 才回来修改和询问 active render texture;

            如果你的目的是 想让 camera 渲染进一个指定的 texture 中, 那么你应该去调用: Camera.targetTexture();

            当一个 render texture 变成 active 态, 而且它之前没被这么使用过, 那么它的 hardware rendering context
            会被自动创建;

            See Also: Graphics.SetRenderTarget();
        */
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
        //     The width / height of the render texture in pixels.
        public override int height { get; set; }
        public override int width { get; set; }


        // 摘要:
        //     Dimensionality (type) of the render texture.
        //   比如:
        //      2D, cubemap, 3D, Tex2DArray, CubeArray 这种的
        public override TextureDimension dimension { get; set; }

        
        /*
        // 摘要:
        //     If enabled, this Render Texture will be used as a Texture3D.
        [Obsolete("Use RenderTexture.dimension instead.", false)]
        public bool isVolume { get; set; }
        */


        // 摘要:
        //     The color format of the render texture.
        [NativePropertyAttribute("ColorFormat")]
        public GraphicsFormat graphicsFormat { get; set; }


        // 摘要:
        //     Render texture has mipmaps when this flag is set.
        [NativePropertyAttribute("MipMap")]
        public bool useMipMap { get; set; }

        
        /*
            Does this render texture use "sRGB read/write conversions"? (Read Only).

            猜测:
                true - 表示开启了 "sRGB read/write conversions" 功能;

            如果当前程序选择了 线性颜色空间, 且此值为 true, 那么:
            -- fs输出的数据(linear) 将会执行 linear->sRGB 转换后, 再写入 render texture
                render texture 中存储的数据通常为 sRGB 形式;

            -- 如果想从 render texture 中获取数据(采样), rt 也会先自动执行 sRGB->linear 转换;
                然后这个 linear数据 再去被采样;
                毕竟代码端 工作在 linear 空间; 
            
            本变量是只读的, 它的值就是 构造函数中参数 "readWrite" 的值;
            tpr:
                我们注意到, "RenderTexture.GetTemporary()" 也有相同的参数;
                也能设置此功能;
        */
        [NativePropertyAttribute("SRGBReadWrite")]
        public bool sRGB { get; }

        
        // 摘要:
        //     If this RenderTexture is a VR eye texture used in stereoscopic rendering, this
        //     property decides what special rendering occurs, if any.
        [NativePropertyAttribute("VRUsage")]
        public VRTextureUsage vrUsage { get; set; } // VR

        
        // 摘要:
        //     The render texture memoryless mode property.
        [NativePropertyAttribute("Memoryless")]
        public RenderTextureMemoryless memorylessMode { get; set; }


        public RenderTextureFormat format { get; set; }

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
        public GraphicsFormat stencilFormat { get; set; }


        
        // 摘要:
        //     Mipmap levels are generated automatically when this flag is set.
        public bool autoGenerateMips { get; set; }


        /*
        [Obsolete("Use RenderTexture.dimension instead.", false)]
        public bool isCubemap { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use RenderTexture.autoGenerateMips instead (UnityUpgradable) -> autoGenerateMips", false)]
        public bool generateMips { get; set; }
        */
        

        // 摘要:
        //     This struct contains all the information required to create a RenderTexture.
        //     It can be copied, cached, and reused to easily create RenderTextures that all share the same properties.
        public RenderTextureDescriptor descriptor { get; set; }
        

        // 摘要:
        //     The precision of the render texture's depth buffer in bits 
        //     (0, 16, 24/32 are supported).
        public int depth { get; set; }

        
        // 摘要:
        //     Depth/stencil buffer of the render texture (Read Only).
        public RenderBuffer depthBuffer { get; }
        

        // 摘要:
        //     Color buffer of the render texture (Read Only).
        public RenderBuffer colorBuffer { get; }


        public bool isPowerOfTwo { get; set; } // 文档中没见到说明
        

        // 摘要:
        //     Is the render texture marked to be scaled by the.
        public bool useDynamicScale { get; set; }

        
        
        /*
            摘要:
            Volume extent of a 3D render texture or number of slices of array texture.

            -- For volumetric render textures (see dimension), this variable determines the volume extent.
            -- For array render texture (see dimension), this variable determines the number of slices.
        */
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



        /*
            摘要:
            Enable random access write into this render texture on Shader Model 5.0 level shaders.

            Shader Model 5.0 level frag shader 或者 compute shaders, 可以向 texture 的任意地址写入信息;
            此功能被称为 "unordered access views" in UsingDX11GL3Features. (UAV)

            想要启动此功能, 在新建 render texture 之前, 设置此 flag;

            如果一个 texture 启动了此 flag, 在 hlsl 中, 它能被当作一个 RWTexture* resources 来写入;
            在 glsl 中, 它能被当作一个 image resources 来写入;

            使用 Graphics.SetRandomWriteTarget() 也能在 frag shader 中设置一个 random access write target

            Use SystemInfo.SupportsRandomWriteOnRenderTextureFormat() 来证实:
            if a given format can be used as this depends on the graphics API/hardware/driver.
        */
        public bool enableRandomWrite { get; set; }


        

        /*
            摘要:
            Allocate a temporary render texture.

            如果你为了某些临时计算, 想要一个快速的 Render Texture 时, 此函数对此需求做了优化;
            事后可调用 RenderTexture.ReleaseTemporary() 来释放之; 以便未来可以服用此 rt;

            在内部, unity 维护了一个 temporary render textures 的池子, 所以, 一个 GetTemporary() 调用
            很可能会返回一个 已经新建且被复用过的 rt (只要它的 size, format 是符合需求的)

            只要在数帧之内被没有被用到, 这些 temporary render textures 就会被销毁;

            如果你正在执行一系列 后处理 "blits" 操作, 最好针对每一个 blit, 都单独申请和释放一个 temporary render texture,
            这样对性能是最有利的; 这比复用同一个 temporary render texture 要高效多了;

            这对 移动平台(tile-based) 和 multi-GPU systems 都是最有益的;

            本函数会在内部调用 RenderTexture.DiscardContents() 这有助于避免对先前 render texture 的内容执行昂贵的恢复操作。

            调用本函数返回的 temporary render texture, 里面的任何数据都是不可信的, 说不定就是残留的垃圾信息,
            也可能会复写为某种但一个的颜色值,  这些依平台而定;
            
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
        
        //   readWrite:
        //     Color space conversion mode.

                在 Linear 工作流中, 如果想用本 render texture 存储 线性数据, (比如 非颜色值, 或 hdr颜色)
                可在此变量中选用: RenderTextureReadWrite.Linear;
                    此时, "RenderTexture.sRGB" 值为 false; (表示不执行任何 sRGB<->linear 转换)

                此变量默认为 "Default", 
                    在 linear 工作量中, 此模式默认 render texture 是 sRGB 空间的;
                    此时, "RenderTexture.sRGB" 值为 true; (表示执行 sRGB<->linear 转换)

                在 gamma 工作量中, render texture 是 gamma 空间, 光照计算也是 gamma 空间,
                    不需要任何 sRGB<->linear 转换,
                    此时, 本变量默认值 "Default", 意思是 不转换 (详细解释看这个 enum 翻译文件)
                    且, "RenderTexture.sRGB" 为 false;

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
        */
        public static RenderTexture GetTemporary(RenderTextureDescriptor desc);
        public static RenderTexture GetTemporary(int width, int height, [Internal.DefaultValue("0")] int depthBuffer, [Internal.DefaultValue("RenderTextureFormat.Default")] RenderTextureFormat format, [Internal.DefaultValue("RenderTextureReadWrite.Default")] RenderTextureReadWrite readWrite, [Internal.DefaultValue("1")] int antiAliasing, [Internal.DefaultValue("RenderTextureMemoryless.None")] RenderTextureMemoryless memorylessMode, [Internal.DefaultValue("VRTextureUsage.None")] VRTextureUsage vrUsage, [Internal.DefaultValue("false")] bool useDynamicScale);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, RenderTextureMemoryless memorylessMode);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format, int antiAliasing, RenderTextureMemoryless memorylessMode);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, RenderTextureMemoryless memorylessMode, VRTextureUsage vrUsage);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format, int antiAliasing);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format, int antiAliasing, RenderTextureMemoryless memorylessMode, VRTextureUsage vrUsage);
        [ExcludeFromDocs]public static RenderTexture GetTemporary(int width, int height, int depthBuffer, GraphicsFormat format, [Internal.DefaultValue("1")] int antiAliasing, [Internal.DefaultValue("RenderTextureMemoryless.None")] RenderTextureMemoryless memorylessMode, [Internal.DefaultValue("VRTextureUsage.None")] VRTextureUsage vrUsage, [Internal.DefaultValue("false")] bool useDynamicScale);
        

        /*
            摘要:
            Release a temporary texture allocated with GetTemporary.
            如果一个 temp render texture 在数帧之内没有被使用到, 它会被自动销毁;
        // 参数:
        //   temp: 目标
        */
        [FreeFunctionAttribute("GetRenderBufferManager().GetTextures().ReleaseTempBuffer")]
        public static void ReleaseTemporary(RenderTexture temp);


        
        // 摘要:
        //     Does a RenderTexture have stencil buffer?
        // 参数:
        //   rt:
        //     Render texture, or null for main screen.
        [FreeFunctionAttribute("RenderTextureSupportsStencil")]
        public static bool SupportsStencil(RenderTexture rt);


        /*
            好像用于 VR
        */
        [NativeThrowsAttribute]
        public void ConvertToEquirect(RenderTexture equirect, Camera.MonoOrStereoscopicEye eye = Camera.MonoOrStereoscopicEye.Mono);
        

        /*
            摘要:
            Actually creates the RenderTexture.

            RenderTexture 的构造函数不会真的在硬件层 上分配一个真正的 texture, 
            通常来说, 一个 texture 会在自己第一次被设置为 active 的时候才被 created;

            调用本函数能让你提前 落实这个 硬件层 texture 的新建工作;

            当然, 如果这个 texture 已经确实被创建了, 那么调用本函数不会执行啥工作;
        
            返回结果:
                True if the texture is created, else false.
        */
        public bool Create();

        

        /*
            摘要:
            Hint the GPU driver that the contents of the RenderTexture will not be used.
            ---
            提示 gpu驱动, 这个 render texture 上的内容不会被使用;

            在某些平台上, 如果你能提示某个 render texture 的内容不再被需要, 这能提高性能;
            此时, 当这个 rt 被别的地方使用时, 系统就不需要将它内部的数据 复制到一个 暂存地, 最好再复制回来;
            Xbox 360, XBox One and many mobile GPUs benefit from this.

            知道当目标 render texture 是当前的 active render target 时, 这个操作才是管用的;
            在此函数被调用之后, 目标 render texture 中的内容是未定义的;

            默认时, color buffer 和 depth buffer 都会被 discarded,
            不过通过两个参数, 可具体定制细节

            参数:
            discardColor:
                Should the colour buffer be discarded?
            
            discardDepth:
                Should the depth buffer be discarded?
        */
        public void DiscardContents(bool discardColor, bool discardDepth);
        public void DiscardContents();


        /*
            摘要:
            Generate mipmap levels of a render texture.

            Use this function to manually re-generate mipmap levels of a render texture. 

            The render texture has to have mipmaps (useMipMap set to true), 
            and automatic mip generation turned off (autoGenerateMips set to false).

            在有些平台(比如 D3D9), 是没有办法手动生成 render texture mip 各个层的内容的;
            在这种情况下, 本函数啥也不干
        */
        public void GenerateMips();



        /*
            摘要:
            Retrieve a native (underlying graphics API) pointer to the depth buffer resource.

            可调用本函数来启用 源自 native code plugins(插件) 的 depth buffer manipulation(控制);

            因为本 class 继承于 Texture, 所以可调用 Texture.GetNativeTexturePtr() 来获得 
            a native pointer to the color buffer of a render texture;

            对于 Depth and ShadowMap render texture formats, 上面这两个函数能得到相同的结果;

            若在 project's quality settings 中开启 anti aliasing, 上面这两个函数也能得到相同的结果;
            (为啥)

            注意, 当使用多线程渲染时, 调用此函数将会与 rendering thread 同步,(这是一个缓慢的操作)
            所以, 为了性能, 最好在初始化阶段 调用本函数;

            返回结果:
            Pointer to an underlying graphics API depth buffer resource.
        */
        public IntPtr GetNativeDepthBufferPtr();


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetTexelOffset always returns zero now, no point in using it.", false)]
        public Vector2 GetTexelOffset();
        */


        
        // 摘要:
        //     Is the render texture actually created?
        //  returns true if the hardware resources for this render are created.
        public bool IsCreated();


        /*
        [Obsolete("This function has no effect.", false)]
        public void MarkRestoreExpected();
        */


        /*
            摘要:
            Releases the RenderTexture.

            This function releases the hardware resources used by the render texture. 
            The texture itself is not destroyed, and will be automatically created again when being used.

            和其它 "native engine object" 一样, 需要注意 rt 的生命周期, 然后在你使用完毕后, 就及时释放它们;
            这样, 它们就不会向常规类型那样, 被 垃圾回收 掉;
        */
        public void Release();


        /*
            摘要:
            Force an antialiased render texture to be resolved.

            如果那个 antialiased render texture 启动了 RenderTexture.bindTextureMS flag,
            它就不会被自动 解析;

            Sometimes, it's useful to have both the resolved and the unresolved version of the texture 
            at different stages of the pipeline. 

            If the target parameter is omitted, the render texture will be resolved into itself.
            
            参数:
            target:
                The render texture to resolve into. If set, the target render texture must have
                the same dimensions and format as the source.
        */
        public void ResolveAntiAliasedSurface(RenderTexture target);
        public void ResolveAntiAliasedSurface();


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("UsSetBorderColor is no longer supported.", true)]
        public void SetBorderColor(Color color);
        */


        
        // 摘要:
        //     Assigns this RenderTexture as a global shader property named propertyName.
        //
        // 参数:
        //   propertyName:
        [FreeFunctionAttribute(Name = "RenderTextureScripting::SetGlobalShaderProperty", HasExplicitThis = true)]
        public void SetGlobalShaderProperty(string propertyName);
        
    }
}



