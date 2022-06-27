#region 程序集 UnityEngine.AssetBundleModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AssetBundleModule.dll
#endregion


namespace UnityEngine
{
    /*
        Contains information about compression methods, compression levels and block sizes 
        that are supported by Asset Bundle compression at build time and recompression at runtime.

        Custom versions of this struct for building and recompressing Asset Bundles are currently not available, 
        so the internal parameters are read-only. 
        You can currently select one of three supported BuildCompression types for compressing AssetBundles during builds (LZ4, LZMA and Uncompressed) 
        and there are two supported recompression methods for runtime (LZ4Runtime and UncompressedRuntime).
        ---
        三种 build 阶段 压缩 ab包 的模式:
            -1- LZ4
            -2- LZMA
            -3- Uncompressed

        两种 运行时 再压缩 模式:
            -1- LZ4Runtime
            -2- UncompressedRuntime
    */
    [UsedByNativeCodeAttribute]
    public struct BuildCompression
    {

        /*
            Uncompressed Asset Bundle.
            Uncompressed Asset Bundles are large, but are the fastest to access once downloaded. Uncompressed bundles are 16-byte aligned.

            This BuildCompression is only supported for building Asset Bundles and is not available for recompression at runtime. 
            Use UncompressedRuntime for recompression.
        */
        public static readonly BuildCompression Uncompressed;


        /*
            LZ4HC "Chunk Based" Compression.

            LZ4HC (LZ4 High Compression) compression results in smaller compressed file sizes than LZ4 and larger compressed file sizes than LZMA, 
            but does not require the entire bundle to be decompressed before use like LZMA. 
            LZ4(HC) is a “chunk-based” algorithm, and therefore when objects are loaded from an LZ4(HC)-compressed bundle, 
            only the corresponding chunks for that object are decompressed. 

            This occurs on-the-fly, meaning there are no wait times for the entire bundle to be decompressed before use. 
            ---
            这是即时发生的，这意味着整个 ab包 在使用前无需等待解压缩。

            The LZ4 Format was introduced in Unity 5.3 and was unavailable in prior versions. (5.3 之前的 unity 不能使用)

            This BuildCompression is only supported for building Asset Bundles and is not available for recompression at runtime. Use LZ4Runtime for runtime recompression.
            ---
            只能在 ab包的 build 阶段选用此模式, 在 ab包的 "再压缩" 阶段, 应该改用 "LZ4Runtime" 模式;
        */
        public static readonly BuildCompression LZ4;

        /*
            LZMA Compression.

            LZMA-Compressed bundles give the smallest possible download size, 
            but have relatively slow decompression resulting in higher apparent load times and greater memory use at runtime.

            This BuildCompression is only supported for building Asset Bundles and is not available for recompression at runtime.
        */
        public static readonly BuildCompression LZMA;

        /*
            Uncompressed Asset Bundle.
            Uncompressed Asset Bundles are large, but are the fastest to access once downloaded. Uncompressed bundles are 16-byte aligned.

            This BuildCompression is only supported for recompressing Asset Bundles at runtime and is not available for building Asset Bundles. 
            Use Uncompressed for building Asset Bundles.
        */
        public static readonly BuildCompression UncompressedRuntime;


        /*
            LZ4 Compression for runtime recompression.

            LZ4 compression results in larger compressed file sizes than LZ4HC and LZMA, but does not require the entire bundle to be decompressed before use. 
            LZ4 is a “chunk-based” algorithm, and therefore when objects are loaded from an LZ4-compressed bundle, 
            only the corresponding chunks for that object are decompressed. 
            This occurs on-the-fly, meaning there are no wait times for the entire bundle to be decompressed before use. 
            The LZ4 Format was introduced in Unity 5.3 and was unavailable in prior versions.

            This BuildCompression is only supported for recompressing Asset Bundles at runtime and is not available for building Asset Bundles. 
            Use LZ4 for building Asset Bundles.
            ---
            只能在 ab包的 "再压缩" 阶段 选用此模式, 在 ab包的 "build" 阶段, 应该改用 "LZ4" 模式;
        */
        public static readonly BuildCompression LZ4Runtime;



        public CompressionType compression { get; }
        public CompressionLevel level { get; }
        public uint blockSize { get; }
        
        //
        // 摘要:
        //     Enable asset bundle protection.
        public bool enableProtect { get; }
    }
}

