#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using Unity.Collections;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Class for handling 2D texture arrays.
    [NativeHeaderAttribute("Runtime/Graphics/Texture2DArray.h")]
    public sealed class Texture2DArray//Texture2DArray__RR
        : Texture
    {
        //
        // 摘要:
        //     Create a new texture array.
        //
        // 参数:
        //   width:
        //     Width of texture array in pixels.
        //
        //   height:
        //     Height of texture array in pixels.
        //
        //   depth:
        //     Number of elements in the texture array.
        //
        //   format:
        //     Format of the texture.
        //
        //   mipmap:
        //     Should mipmaps be created?
        //
        //   linear:
        //     Does the texture contain non-color data (i.e. don't do any color space conversions
        //     when sampling)? Default is false.
        //
        //   textureFormat:
        //
        //   mipChain:
        public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, bool mipChain);
        [RequiredByNativeCodeAttribute]
        public Texture2DArray(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags);
        public Texture2DArray(int width, int height, int depth, DefaultFormat format, TextureCreationFlags flags);
        public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, int mipCount, [DefaultValue("true")] bool linear);
        //
        // 摘要:
        //     Create a new texture array.
        //
        // 参数:
        //   width:
        //     Width of texture array in pixels.
        //
        //   height:
        //     Height of texture array in pixels.
        //
        //   depth:
        //     Number of elements in the texture array.
        //
        //   format:
        //     Format of the texture.
        //
        //   mipmap:
        //     Should mipmaps be created?
        //
        //   linear:
        //     Does the texture contain non-color data (i.e. don't do any color space conversions
        //     when sampling)? Default is false.
        //
        //   textureFormat:
        //
        //   mipChain:
        public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, bool mipChain, [DefaultValue("true")] bool linear);
        public Texture2DArray(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags, int mipCount);

        //
        // 摘要:
        //     Read Only. This property is used as a parameter in some overloads of the CommandBuffer.Blit,
        //     Graphics.Blit, CommandBuffer.SetRenderTarget, and Graphics.SetRenderTarget methods
        //     to indicate that all texture array slices are bound. The value of this property
        //     is -1.
        public static int allSlices { get; }
        //
        // 摘要:
        //     Number of elements in a texture array (Read Only).
        public int depth { get; }
        //
        // 摘要:
        //     Texture format (Read Only).
        public TextureFormat format { get; }
        //
        // 摘要:
        //     Returns true if this texture array is Read/Write Enabled; otherwise returns false.
        //     For dynamic textures created from script, always returns true.
        public override bool isReadable { get; }

        //
        // 摘要:
        //     Actually apply all previous SetPixels changes.
        //
        // 参数:
        //   updateMipmaps:
        //     When set to true, mipmap levels are recalculated.
        //
        //   makeNoLongerReadable:
        //     When set to true, system memory copy of a texture is released.
        public void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable);
        public void Apply(bool updateMipmaps);
        public void Apply();
        public NativeArray<T> GetPixelData<T>(int mipLevel, int element) where T : struct;
        public Color[] GetPixels(int arrayElement);
        //
        // 摘要:
        //     Returns pixel colors of a single array slice.
        //
        // 参数:
        //   arrayElement:
        //     Array slice to read pixels from.
        //
        //   miplevel:
        //     Mipmap level to read pixels from.
        //
        // 返回结果:
        //     Array of pixel colors.
        [FreeFunctionAttribute(Name = "Texture2DArrayScripting::GetPixels", HasExplicitThis = true, ThrowsException = true)]
        public Color[] GetPixels(int arrayElement, int miplevel);
        public Color32[] GetPixels32(int arrayElement);
        //
        // 摘要:
        //     Returns pixel colors of a single array slice.
        //
        // 参数:
        //   arrayElement:
        //     Array slice to read pixels from.
        //
        //   miplevel:
        //     Mipmap level to read pixels from.
        //
        // 返回结果:
        //     Array of pixel colors in low precision (8 bits/channel) format.
        [FreeFunctionAttribute(Name = "Texture2DArrayScripting::GetPixels32", HasExplicitThis = true, ThrowsException = true)]
        public Color32[] GetPixels32(int arrayElement, int miplevel);
        public void SetPixelData<T>(T[] data, int mipLevel, int element, int sourceDataStartIndex = 0);
        public void SetPixelData<T>(NativeArray<T> data, int mipLevel, int element, int sourceDataStartIndex = 0) where T : struct;
        public void SetPixels(Color[] colors, int arrayElement);
        //
        // 摘要:
        //     Set pixel colors for the whole mip level.
        //
        // 参数:
        //   colors:
        //     An array of pixel colors.
        //
        //   arrayElement:
        //     The texture array element index.
        //
        //   miplevel:
        //     The mip level.
        [FreeFunctionAttribute(Name = "Texture2DArrayScripting::SetPixels", HasExplicitThis = true, ThrowsException = true)]
        public void SetPixels(Color[] colors, int arrayElement, int miplevel);
        //
        // 摘要:
        //     Set pixel colors for the whole mip level.
        //
        // 参数:
        //   colors:
        //     An array of pixel colors.
        //
        //   arrayElement:
        //     The texture array element index.
        //
        //   miplevel:
        //     The mip level.
        [FreeFunctionAttribute(Name = "Texture2DArrayScripting::SetPixels32", HasExplicitThis = true, ThrowsException = true)]
        public void SetPixels32(Color32[] colors, int arrayElement, int miplevel);
        public void SetPixels32(Color32[] colors, int arrayElement);
    }
}

