#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    // 查看完毕
    
    // 摘要:
    //     Set of flags that control the state of a newly-created RenderTexture.
    [Flags]
    public enum RenderTextureCreationFlags//RenderTextureCreationFlags__
    {
        
        // 摘要:
        //      Set this flag to allocate mipmaps in the RenderTexture. 
        //      See RenderTexture.useMipMap for more details.
        MipMap = 1,
        
        /*
            摘要:
            Determines whether or not mipmaps are automatically generated when the RenderTexture is modified. 
            This flag is set by default, and has no effect if the RenderTextureCreationFlags.MipMap flag is not also set. 
            See RenderTexture.autoGenerateMips for more details.
        */
        AutoGenerateMips = 2,
        

        // 摘要:
        //     When this flag is set, reads and writes to this texture are converted to SRGB
        //     color space. See RenderTexture.sRGB for more details.
        SRGB = 4,

        
        // 摘要:
        //     Set this flag when the Texture is to be used as a VR eye texture. This flag is
        //     cleared by default. This flag is set on a RenderTextureDesc when it is returned
        //     from GetDefaultVREyeTextureDesc or other VR functions returning a RenderTextureDesc.
        EyeTexture = 8, // VR

        /*
            摘要:
            Set this flag to enable random access writes to the RenderTexture from shaders.

            通常, frag shader 只能处理它们被给与的那个 frag/pix; 
            如果不开启此 flag, Compute shaders 就无法写入到 texture 中去;

            Random write enables shaders to write to arbitrary locations on a RenderTexture. 
            
            See RenderTexture.enableRandomWrite() for more details, including supported platforms.
        */
        EnableRandomWrite = 16,

        
        // 摘要:
        //     This flag is always set internally when a RenderTexture is created from script.
        //     It has no effect when set manually from script code.
        CreatedFromScript = 32,

        
        // 摘要:
        //     Clear this flag when a RenderTexture is a VR eye texture and the device does
        //     not automatically flip the texture when being displayed. This is platform specific
        //     and It is set by default. This flag is only cleared when part of a RenderTextureDesc
        //     that is returned from GetDefaultVREyeTextureDesc or other VR functions that return
        //     a RenderTextureDesc. Currently, only Hololens eye textures need to clear this
        //     flag.
        AllowVerticalFlip = 128, // VR

        
        // 摘要:
        //     When this flag is set, the engine will not automatically resolve the color surface.
        NoResolvedColorSurface = 256,

        /*
            摘要:
            Set this flag to mark this RenderTexture for Dynamic Resolution should the target
            platform/graphics API support Dynamic Resolution. 

            如果目标平台/图形 API 支持 动态分辨率，则设置此 flag, 以将此 RenderTexture 标记为 动态分辨率。

            See ScalabeBufferManager for more details.
        */
        DynamicallyScalable = 1024,

        /*
            摘要:
            Setting this flag causes the RenderTexture to be bound as a multisampled texture in a shader. 

            当 RenderTexture.antiAliasing 值大于 1 时, 此 flag 能阻止 render texture 被默认执行 "解析" 操作
            (从 multi sampled rt 被解析为一张 常规 render texture)
        */
        BindMS = 2048 // multi sampled
    }
}

