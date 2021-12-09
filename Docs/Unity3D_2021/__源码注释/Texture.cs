#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     Base class for Texture handling.
    [NativeHeaderAttribute("Runtime/Graphics/Texture.h")]
    [NativeHeaderAttribute("Runtime/Streaming/TextureStreamingManager.h")]
    [UsedByNativeCodeAttribute]
    public class Texture : Object//Texture__RR
    {
        //
        // 摘要:
        //     Can be used with Texture constructors that take a mip count to indicate that
        //     all mips should be generated. The value of this field is -1.
        public static readonly int GenerateAllMips;

        protected Texture();

        //
        // 摘要:
        //     Force streaming Textures to load all mipmap levels.
        public static bool streamingTextureForceLoadAll { get; set; }
        //
        // 摘要:
        //     Number of streaming Textures with mipmaps currently loading.
        public static ulong streamingTextureLoadingCount { get; }
        //
        // 摘要:
        //     Number of streaming Textures with outstanding mipmaps to be loaded.
        public static ulong streamingTexturePendingLoadCount { get; }
        //
        // 摘要:
        //     The number of non-streaming Textures in the scene. This includes instances of
        //     Texture2D and CubeMap Textures. This does not include any other Texture types,
        //     or 2D and CubeMap Textures that Unity creates internally.
        public static ulong nonStreamingTextureCount { get; }
        //
        // 摘要:
        //     Number of streaming Textures.
        public static ulong streamingTextureCount { get; }
        //
        // 摘要:
        //     Number of renderers registered with the Texture streaming system.
        public static ulong streamingRendererCount { get; }
        //
        // 摘要:
        //     How many times has a Texture been uploaded due to Texture mipmap streaming.
        public static ulong streamingMipmapUploadCount { get; }
        //
        // 摘要:
        //     The amount of memory Unity allocates for non-streaming Textures in the scene.
        //     This only includes instances of Texture2D and CubeMap Textures. This does not
        //     include any other Texture types, or 2D and CubeMap Textures that Unity creates
        //     internally.
        public static ulong nonStreamingTextureMemory { get; }
        //
        // 摘要:
        //     The amount of memory that all Textures in the scene use.
        public static ulong currentTextureMemory { get; }
        //
        // 摘要:
        //     The total amount of Texture memory that Unity allocates to the Textures in the
        //     scene after it applies the and finishes loading Textures. `targetTextureMemory`also
        //     takes mipmap streaming settings into account. This value only includes instances
        //     of Texture2D and CubeMap Textures. It does not include any other Texture types,
        //     or 2D and CubeMap Textures that Unity creates internally.
        public static ulong targetTextureMemory { get; }
        //
        // 摘要:
        //     The total size of the Textures, in bytes, that Unity loads if there were no other
        //     constraints. Before Unity loads any Textures, it applies the which reduces the
        //     loaded Texture resolution if the Texture sizes exceed its value. The `desiredTextureMemory`
        //     value takes into account the mipmap levels that Unity has requested or that you
        //     have set manually. For example, if Unity does not load a Texture at full resolution
        //     because it is far away or its requested mipmap level is greater than 0, Unity
        //     reduces the `desiredTextureMemory` value to match the total memory needed. The
        //     `desiredTextureMemory` value can be greater than the `targetTextureMemory` value.
        public static ulong desiredTextureMemory { get; }
        //
        // 摘要:
        //     The total amount of Texture memory that Unity would use if it loads all Textures
        //     at mipmap level 0. This is a theoretical value that does not take into account
        //     any input from the streaming system or any other input, for example when you
        //     set the`Texture2D.requestedMipmapLevel` manually. To see a Texture memory value
        //     that takes inputs into account, use `desiredTextureMemory`. `totalTextureMemory`
        //     only includes instances of Texture2D and CubeMap Textures. It does not include
        //     any other Texture types, or 2D and CubeMap Textures that Unity creates internally.
        public static ulong totalTextureMemory { get; }
        //
        // 摘要:
        //     This property forces the streaming Texture system to discard all unused mipmaps
        //     instead of caching them until the Texture is exceeded. This is useful when you
        //     profile or write tests to keep a predictable set of Textures in memory.
        public static bool streamingTextureDiscardUnusedMips { get; set; }
        //
        // 摘要:
        //     Allow Unity internals to perform Texture creation on any thread (rather than
        //     the dedicated render thread).
        public static bool allowThreadedTextureCreation { get; set; }
        [NativePropertyAttribute("GlobalMasterTextureLimit")]
        public static int masterTextureLimit { get; set; }
        [NativePropertyAttribute("AnisoLimit")]
        public static AnisotropicFiltering anisotropicFiltering { get; set; }

        /*
            Texture U coordinate wrapping mode.

            enum: Repeat, Clamp, Mirror, MirrorOnce;
        */
        public TextureWrapMode wrapModeU { get; set; }


        //
        // 摘要:
        //     How many mipmap levels are in this Texture (Read Only).
        public int mipmapCount { get; }
        //
        // 摘要:
        //     Returns the GraphicsFormat format or color format of a Texture object.
        public virtual GraphicsFormat graphicsFormat { get; }
        //
        // 摘要:
        //     Texture coordinate wrapping mode.
        public TextureWrapMode wrapMode { get; set; }
        //
        // 摘要:
        //     Height of the Texture in pixels. (Read Only)
        public virtual int height { get; set; }
        //
        // 摘要:
        //     Dimensionality (type) of the Texture (Read Only).
        public virtual TextureDimension dimension { get; set; }
        //
        // 摘要:
        //     Width of the Texture in pixels. (Read Only)
        public virtual int width { get; set; }
        //
        // 摘要:
        //     This counter is incremented when the Texture is updated.
        public uint updateCount { get; }
        public Vector2 texelSize { get; }
        //
        // 摘要:
        //     The mipmap bias of the Texture.
        public float mipMapBias { get; set; }
        //
        // 摘要:
        //     Defines the anisotropic filtering level of the Texture.
        public int anisoLevel { get; set; }
        //
        // 摘要:
        //     Returns true if the Read/Write Enabled checkbox was checked when the Texture
        //     was imported; otherwise returns false. For a dynamic Texture created from script,
        //     always returns true. For additional information, see TextureImporter.isReadable.
        public virtual bool isReadable { get; }
        //
        // 摘要:
        //     Texture W coordinate wrapping mode for Texture3D.
        public TextureWrapMode wrapModeW { get; set; }
        //
        // 摘要:
        //     Texture V coordinate wrapping mode.
        public TextureWrapMode wrapModeV { get; set; }
        //
        // 摘要:
        //     The hash value of the Texture.
        public Hash128 imageContentsHash { get; set; }

        /*
            Filtering mode of the Texture.

            enum: Point, Bilinear, Trilinear;
        */
        public FilterMode filterMode { get; set; }

        //
        // 摘要:
        //     Sets Anisotropic limits.
        //
        // 参数:
        //   forcedMin:
        //
        //   globalMax:
        [NativeNameAttribute("SetGlobalAnisoLimits")]
        public static void SetGlobalAnisotropicFilteringLimits(int forcedMin, int globalMax);
        //
        // 摘要:
        //     This function sets mipmap streaming debug properties on any materials that use
        //     this Texture through the mipmap streaming system.
        [FreeFunctionAttribute("GetTextureStreamingManager().SetStreamingTextureMaterialDebugProperties")]
        public static void SetStreamingTextureMaterialDebugProperties();

        /*
        [Obsolete("Use GetNativeTexturePtr instead.", false)]
        public int GetNativeTextureID();
        */


        //
        // 摘要:
        //     Retrieve a native (underlying graphics API) pointer to the Texture resource.
        //
        // 返回结果:
        //     Pointer to an underlying graphics API Texture resource.
        public IntPtr GetNativeTexturePtr();
        //
        // 摘要:
        //     Increment the update counter.
        public void IncrementUpdateCount();
    }
}

