#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Class that represents textures in C# code.
    [NativeHeaderAttribute("Runtime/Graphics/Texture2D.h")]
    [NativeHeaderAttribute("Runtime/Graphics/GeneratedTextures.h")]
    [UsedByNativeCodeAttribute]
    public sealed class Texture2D : Texture
    {
        //
        // 摘要:
        //     Create a new empty texture.
        //
        // 参数:
        //   width:
        //
        //   height:
        public Texture2D(int width, int height);
        //
        // 摘要:
        //     Create a new empty texture.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   textureFormat:
        //
        //   mipChain:
        public Texture2D(int width, int height, TextureFormat textureFormat, bool mipChain);
        public Texture2D(int width, int height, GraphicsFormat format, TextureCreationFlags flags);
        public Texture2D(int width, int height, DefaultFormat format, TextureCreationFlags flags);
        public Texture2D(int width, int height, GraphicsFormat format, int mipCount, TextureCreationFlags flags);
        //
        // 摘要:
        //     Create a new empty texture.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   textureFormat:
        //
        //   mipChain:
        //
        //   linear:
        public Texture2D(int width, int height, [DefaultValue("TextureFormat.RGBA32")] TextureFormat textureFormat, [DefaultValue("true")] bool mipChain, [DefaultValue("false")] bool linear);
        public Texture2D(int width, int height, [DefaultValue("TextureFormat.RGBA32")] TextureFormat textureFormat, [DefaultValue("-1")] int mipCount, [DefaultValue("false")] bool linear);

        //
        // 摘要:
        //     Gets a small Texture with all gray pixels.
        [StaticAccessorAttribute("builtintex", Bindings.StaticAccessorType.DoubleColon)]
        public static Texture2D linearGrayTexture { get; }
        //
        // 摘要:
        //     Gets a small Texture with pixels that represent surface normal vectors at a neutral
        //     position.
        [StaticAccessorAttribute("builtintex", Bindings.StaticAccessorType.DoubleColon)]
        public static Texture2D normalTexture { get; }
        //
        // 摘要:
        //     Gets a small Texture with all white pixels.
        [StaticAccessorAttribute("builtintex", Bindings.StaticAccessorType.DoubleColon)]
        public static Texture2D whiteTexture { get; }
        //
        // 摘要:
        //     Gets a small Texture with all black pixels.
        [StaticAccessorAttribute("builtintex", Bindings.StaticAccessorType.DoubleColon)]
        public static Texture2D blackTexture { get; }
        //
        // 摘要:
        //     Gets a small Texture with all red pixels.
        [StaticAccessorAttribute("builtintex", Bindings.StaticAccessorType.DoubleColon)]
        public static Texture2D redTexture { get; }
        //
        // 摘要:
        //     Gets a small Texture with all gray pixels.
        [StaticAccessorAttribute("builtintex", Bindings.StaticAccessorType.DoubleColon)]
        public static Texture2D grayTexture { get; }
        //
        // 摘要:
        //     Returns true if the Read/Write Enabled checkbox was checked when the texture
        //     was imported; otherwise returns false. For a dynamic Texture created from script,
        //     always returns true. For additional information, see TextureImporter.isReadable.
        public override bool isReadable { get; }
        //
        // 摘要:
        //     Restricts the mipmap streaming system to a minimum mip level for this Texture.
        public int minimumMipmapLevel { get; set; }
        //
        // 摘要:
        //     The mipmap level calculated by the streaming system, which takes into account
        //     the streaming Cameras and the location of the objects containing this Texture.
        //     This is unaffected by requestedMipmapLevel or minimumMipmapLevel.
        public int calculatedMipmapLevel { get; }
        //
        // 摘要:
        //     The mipmap level that the streaming system would load before memory budgets are
        //     applied.
        public int desiredMipmapLevel { get; }
        //
        // 摘要:
        //     The mipmap level that the mipmap streaming system is in the process of loading.
        public int loadingMipmapLevel { get; }
        //
        // 摘要:
        //     The format of the pixel data in the texture (Read Only).
        public TextureFormat format { get; }
        //
        // 摘要:
        //     The mipmap level to load.
        public int requestedMipmapLevel { get; set; }
        //
        // 摘要:
        //     The mipmap level that is currently loaded by the streaming system.
        public int loadedMipmapLevel { get; }
        //
        // 摘要:
        //     Indicates whether this texture was imported with TextureImporter.alphaIsTransparency
        //     enabled. This setting is available only in the Editor scripts. Note that changing
        //     this setting will have no effect; it must be enabled in TextureImporter instead.
        public bool alphaIsTransparency { get; set; }
        //
        // 摘要:
        //     Sets the relative priority for this Texture when reducing memory size to fit
        //     within the memory budget.
        public int streamingMipmapsPriority { get; }
        //
        // 摘要:
        //     Determines whether mipmap streaming is enabled for this Texture.
        public bool streamingMipmaps { get; }
        //
        // 摘要:
        //     Returns true if the VTOnly checkbox was checked when the texture was imported;
        //     otherwise returns false. For additional information, see TextureImporter.vtOnly.
        [NativeConditionalAttribute("ENABLE_VIRTUALTEXTURING && UNITY_EDITOR")]
        [NativeNameAttribute("VTOnly")]
        public bool vtOnly { get; }

        //
        // 摘要:
        //     Creates a Unity Texture out of an externally created native texture object.
        //
        // 参数:
        //   nativeTex:
        //     Native 2D texture object.
        //
        //   width:
        //     Width of texture in pixels.
        //
        //   height:
        //     Height of texture in pixels.
        //
        //   format:
        //     Format of underlying texture object.
        //
        //   mipmap:
        //     Does the texture have mipmaps?
        //
        //   linear:
        //     Is texture using linear color space?
        //
        //   mipChain:
        public static Texture2D CreateExternalTexture(int width, int height, TextureFormat format, bool mipChain, bool linear, IntPtr nativeTex);
        public static bool GenerateAtlas(Vector2[] sizes, int padding, int atlasSize, List<Rect> results);
        public void Apply();
        public void Apply(bool updateMipmaps);
        //
        // 摘要:
        //     Actually apply all previous SetPixel and SetPixels changes.
        //
        // 参数:
        //   updateMipmaps:
        //     When set to true, mipmap levels are recalculated.
        //
        //   makeNoLongerReadable:
        //     When set to true, system memory copy of a texture is released.
        public void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable);
        //
        // 摘要:
        //     Resets the minimumMipmapLevel field.
        [FreeFunctionAttribute(Name = "GetTextureStreamingManager().ClearMinimumMipmapLevel", HasExplicitThis = true)]
        public void ClearMinimumMipmapLevel();
        //
        // 摘要:
        //     Resets the requestedMipmapLevel field.
        [FreeFunctionAttribute(Name = "GetTextureStreamingManager().ClearRequestedMipmapLevel", HasExplicitThis = true)]
        public void ClearRequestedMipmapLevel();
        //
        // 摘要:
        //     Compress texture at runtime to DXT/BCn or ETC formats.
        //
        // 参数:
        //   highQuality:
        public void Compress(bool highQuality);
        public Color GetPixel(int x, int y, int mipLevel);
        //
        // 摘要:
        //     Returns pixel color at coordinates (x, y).
        //
        // 参数:
        //   x:
        //
        //   y:
        public Color GetPixel(int x, int y);
        //
        // 摘要:
        //     Returns filtered pixel color at normalized coordinates (u, v).
        //
        // 参数:
        //   u:
        //
        //   v:
        public Color GetPixelBilinear(float u, float v);
        public Color GetPixelBilinear(float u, float v, int mipLevel);
        public NativeArray<T> GetPixelData<T>(int mipLevel) where T : struct;
        //
        // 摘要:
        //     Get a block of pixel colors.
        //
        // 参数:
        //   x:
        //     The x position of the pixel array to fetch.
        //
        //   y:
        //     The y position of the pixel array to fetch.
        //
        //   blockWidth:
        //     The width length of the pixel array to fetch.
        //
        //   blockHeight:
        //     The height length of the pixel array to fetch.
        //
        //   miplevel:
        //     The mipmap level to fetch the pixels. Defaults to zero, and is optional.
        //
        // 返回结果:
        //     The array of pixels in the texture that have been selected.
        [FreeFunctionAttribute("Texture2DScripting::GetPixels", HasExplicitThis = true, ThrowsException = true)]
        public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight, int miplevel);
        public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight);
        public Color[] GetPixels();
        //
        // 摘要:
        //     Get the pixel colors from the texture.
        //
        // 参数:
        //   miplevel:
        //     The mipmap level to fetch the pixels from. Defaults to zero.
        //
        // 返回结果:
        //     The array of all pixels in the mipmap level of the texture.
        public Color[] GetPixels(int miplevel);
        //
        // 摘要:
        //     Get a block of pixel colors in Color32 format.
        //
        // 参数:
        //   miplevel:
        [FreeFunctionAttribute("Texture2DScripting::GetPixels32", HasExplicitThis = true, ThrowsException = true)]
        public Color32[] GetPixels32(int miplevel);
        public Color32[] GetPixels32();
        public NativeArray<T> GetRawTextureData<T>() where T : struct;
        //
        // 摘要:
        //     Get raw data from a texture.
        //
        // 返回结果:
        //     Raw texture data as a byte array.
        [FreeFunctionAttribute("Texture2DScripting::GetRawTextureData", HasExplicitThis = true)]
        public byte[] GetRawTextureData();
        //
        // 摘要:
        //     Checks to see whether the mipmap level set by requestedMipmapLevel has finished
        //     loading.
        //
        // 返回结果:
        //     True if the mipmap level requested by requestedMipmapLevel has finished loading.
        [FreeFunctionAttribute(Name = "GetTextureStreamingManager().IsRequestedMipmapLevelLoaded", HasExplicitThis = true)]
        public bool IsRequestedMipmapLevelLoaded();
        public void LoadRawTextureData<T>(NativeArray<T> data) where T : struct;
        //
        // 摘要:
        //     Fills texture pixels with raw preformatted data.
        //
        // 参数:
        //   data:
        //     Raw data array to initialize texture pixels with.
        //
        //   size:
        //     Size of data in bytes.
        public void LoadRawTextureData(byte[] data);
        //
        // 摘要:
        //     Fills texture pixels with raw preformatted data.
        //
        // 参数:
        //   data:
        //     Raw data array to initialize texture pixels with.
        //
        //   size:
        //     Size of data in bytes.
        public void LoadRawTextureData(IntPtr data, int size);
        public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize);
        //
        // 摘要:
        //     Packs multiple Textures into a texture atlas.
        //
        // 参数:
        //   textures:
        //     Array of textures to pack into the atlas.
        //
        //   padding:
        //     Padding in pixels between the packed textures.
        //
        //   maximumAtlasSize:
        //     Maximum size of the resulting texture.
        //
        //   makeNoLongerReadable:
        //     Should the texture be marked as no longer readable?
        //
        // 返回结果:
        //     An array of rectangles containing the UV coordinates in the atlas for each input
        //     texture, or null if packing fails.
        [FreeFunctionAttribute("Texture2DScripting::PackTextures", HasExplicitThis = true)]
        public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize, bool makeNoLongerReadable);
        public Rect[] PackTextures(Texture2D[] textures, int padding);
        [ExcludeFromDocs]
        public void ReadPixels(Rect source, int destX, int destY);
        //
        // 摘要:
        //     Read pixels from screen into the saved texture data.
        //
        // 参数:
        //   source:
        //     Rectangular region of the view to read from. Pixels are read from current render
        //     target.
        //
        //   destX:
        //     Horizontal pixel position in the texture to place the pixels that are read.
        //
        //   destY:
        //     Vertical pixel position in the texture to place the pixels that are read.
        //
        //   recalculateMipMaps:
        //     Should the texture's mipmaps be recalculated after reading?
        public void ReadPixels(Rect source, int destX, int destY, [DefaultValue("true")] bool recalculateMipMaps);
        public bool Resize(int width, int height, GraphicsFormat format, bool hasMipMap);
        //
        // 摘要:
        //     Resizes the texture.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   format:
        //
        //   hasMipMap:
        public bool Resize(int width, int height, TextureFormat format, bool hasMipMap);
        //
        // 摘要:
        //     Resizes the texture.
        //
        // 参数:
        //   width:
        //
        //   height:
        public bool Resize(int width, int height);
        public void SetPixel(int x, int y, Color color, int mipLevel);
        //
        // 摘要:
        //     Sets pixel color at coordinates (x,y).
        //
        // 参数:
        //   x:
        //
        //   y:
        //
        //   color:
        public void SetPixel(int x, int y, Color color);
        public void SetPixelData<T>(NativeArray<T> data, int mipLevel, int sourceDataStartIndex = 0) where T : struct;
        public void SetPixelData<T>(T[] data, int mipLevel, int sourceDataStartIndex = 0);
        public void SetPixels(Color[] colors);
        //
        // 摘要:
        //     Set a block of pixel colors.
        //
        // 参数:
        //   colors:
        //     The array of pixel colours to assign (a 2D image flattened to a 1D array).
        //
        //   miplevel:
        //     The mip level of the texture to write to.
        public void SetPixels(Color[] colors, [DefaultValue("0")] int miplevel);
        public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors);
        //
        // 摘要:
        //     Set a block of pixel colors.
        //
        // 参数:
        //   x:
        //
        //   y:
        //
        //   blockWidth:
        //
        //   blockHeight:
        //
        //   colors:
        //
        //   miplevel:
        public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, [DefaultValue("0")] int miplevel);
        //
        // 摘要:
        //     Set a block of pixel colors.
        //
        // 参数:
        //   x:
        //
        //   y:
        //
        //   blockWidth:
        //
        //   blockHeight:
        //
        //   colors:
        //
        //   miplevel:
        public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, int miplevel);
        public void SetPixels32(Color32[] colors);
        //
        // 摘要:
        //     Set a block of pixel colors.
        //
        // 参数:
        //   colors:
        //
        //   miplevel:
        public void SetPixels32(Color32[] colors, int miplevel);
        public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors);
        //
        // 摘要:
        //     Updates Unity texture to use different native texture object.
        //
        // 参数:
        //   nativeTex:
        //     Native 2D texture object.
        [FreeFunctionAttribute("Texture2DScripting::UpdateExternalTexture", HasExplicitThis = true)]
        public void UpdateExternalTexture(IntPtr nativeTex);

        //
        // 摘要:
        //     Flags used to control the encoding to an EXR file.
        [Flags]
        public enum EXRFlags
        {
            //
            // 摘要:
            //     No flag. This will result in an uncompressed 16-bit float EXR file.
            None = 0,
            //
            // 摘要:
            //     The texture will be exported as a 32-bit float EXR file (default is 16-bit).
            OutputAsFloat = 1,
            //
            // 摘要:
            //     The texture will use the EXR ZIP compression format.
            CompressZIP = 2,
            //
            // 摘要:
            //     The texture will use RLE (Run Length Encoding) EXR compression format (similar
            //     to Targa RLE compression).
            CompressRLE = 4,
            //
            // 摘要:
            //     This texture will use Wavelet compression. This is best used for grainy images.
            CompressPIZ = 8
        }
    }
}

