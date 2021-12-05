#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Experimental.Rendering
{
    /*
        Use this class to figure out the capabilities of specific "GraphicsFormat";
        Each graphics card may not support all usages across formats. 
        Use "SystemInfo.IsFormatSupported()" to check which usages the graphics card supports.
        --
        tpr: 
            texture/render texture 使用的 "GraphicsFormat", 比如 B8G8R8A8_SRGB, 支持一系列操作;
            本 enum 记录的就是这些操作;

            urp 中居然将 Linear 和 Render 组合起来用,  感觉不太正规;
            好在这个 enum 使用也不是很广泛;

    */
    public enum FormatUsage//FormatUsage__
    {
        
        //     Use this to create and sample textures.
        Sample = 0,
        
        //     Use this to sample textures with a linear filter
        Linear = 1,
        
        //     Use this to create sparse textures
        Sparse = 2, // 稀疏
        
        //     Use this to create and render to a rendertexture.
        Render = 4,
        
        //     Use this to blend on a rendertexture.
        Blend = 5,
        
        //     Use this to get pixel data from a texture.
        GetPixels = 6,
        
        //     Use this to set pixel data to a texture.
        SetPixels = 7,
        
        //     Use this to set pixel data to a texture using `SetPixels32`.
        SetPixels32 = 8,
        
        //     Use this to read back pixels data from a rendertexture.
        ReadPixels = 9,
        
        //     Use this to perform resource load and store on a texture
        LoadStore = 10,
        
        //     Use this to create and render to a MSAA 2X rendertexture.
        MSAA2x = 11,
       
        //     Use this to create and render to a MSAA 4X rendertexture.
        MSAA4x = 12,
        
        //     Use this to create and render to a MSAA 8X rendertexture.
        MSAA8x = 13,
        
        //     Use this enumeration to create and render to the Stencil sub element of a RenderTexture.
        StencilSampling = 16
    }
}

