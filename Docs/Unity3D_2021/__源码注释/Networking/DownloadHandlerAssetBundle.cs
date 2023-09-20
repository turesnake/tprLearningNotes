#region Assembly UnityEngine.UnityWebRequestAssetBundleModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Networking;

//
// Summary:
//     A DownloadHandler subclass specialized for downloading AssetBundles.
[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequestAssetBundle/Public/DownloadHandlerAssetBundle.h")]
public sealed class DownloadHandlerAssetBundle : DownloadHandler
{
    //
    // Summary:
    //     Returns the downloaded AssetBundle, or null. (Read Only)
    public extern AssetBundle assetBundle
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     If true, the AssetBundle will be loaded as part of the UnityWebRequest process.
    //     If false, the AssetBundle will be loaded on demand when accessing the DownloadHandlerAssetBundle.assetBundle
    //     property.
    public extern bool autoLoadAssetBundle
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeThrows]
        set;
    }

    //
    // Summary:
    //     Returns true if the data downloading portion of the operation is complete.
    public extern bool isDownloadComplete
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern IntPtr Create(DownloadHandlerAssetBundle obj, string url, uint crc);

    private static IntPtr CreateCached(DownloadHandlerAssetBundle obj, string url, string name, Hash128 hash, uint crc)
    {
        return CreateCached_Injected(obj, url, name, ref hash, crc);
    }

    private void InternalCreateAssetBundle(string url, uint crc)
    {
        m_Ptr = Create(this, url, crc);
    }

    private void InternalCreateAssetBundleCached(string url, string name, Hash128 hash, uint crc)
    {
        m_Ptr = CreateCached(this, url, name, hash, crc);
    }

    //
    // Summary:
    //     Standard constructor for non-cached asset bundles.
    //
    // Parameters:
    //   url:
    //     The nominal (pre-redirect) URL at which the asset bundle is located.
    //
    //   crc:
    //     A checksum to compare to the downloaded data for integrity checking, or zero
    //     to skip integrity checking.
    public DownloadHandlerAssetBundle(string url, uint crc)
    {
        InternalCreateAssetBundle(url, crc);
    }

    //
    // Summary:
    //     Simple versioned constructor. Caches downloaded asset bundles.
    //
    // Parameters:
    //   url:
    //     The nominal (pre-redirect) URL at which the asset bundle is located.
    //
    //   crc:
    //     A checksum to compare to the downloaded data for integrity checking, or zero
    //     to skip integrity checking.
    //
    //   version:
    //     Current version number of the asset bundle at url. Increment to redownload.
    public DownloadHandlerAssetBundle(string url, uint version, uint crc)
    {
        InternalCreateAssetBundleCached(url, "", new Hash128(0u, 0u, 0u, version), crc);
    }

    //
    // Summary:
    //     Versioned constructor. Caches downloaded asset bundles.
    //
    // Parameters:
    //   url:
    //     The nominal (pre-redirect) URL at which the asset bundle is located.
    //
    //   crc:
    //     A checksum to compare to the downloaded data for integrity checking, or zero
    //     to skip integrity checking.
    //
    //   hash:
    //     A hash object defining the version of the asset bundle.
    public DownloadHandlerAssetBundle(string url, Hash128 hash, uint crc)
    {
        InternalCreateAssetBundleCached(url, "", hash, crc);
    }

    //
    // Summary:
    //     Versioned constructor. Caches downloaded asset bundles to a customized cache
    //     path.
    //
    // Parameters:
    //   url:
    //     The nominal (pre-redirect) URL at which the asset bundle is located.
    //
    //   hash:
    //     A hash object defining the version of the asset bundle.
    //
    //   crc:
    //     A checksum to compare to the downloaded data for integrity checking, or zero
    //     to skip integrity checking.
    //
    //   cachedBundle:
    //     A structure used to download a given version of AssetBundle to a customized cache
    //     path.
    //
    //   name:
    //     AssetBundle name which is used as the customized cache path.
    public DownloadHandlerAssetBundle(string url, string name, Hash128 hash, uint crc)
    {
        InternalCreateAssetBundleCached(url, name, hash, crc);
    }

    //
    // Summary:
    //     Versioned constructor. Caches downloaded asset bundles to a customized cache
    //     path.
    //
    // Parameters:
    //   url:
    //     The nominal (pre-redirect) URL at which the asset bundle is located.
    //
    //   hash:
    //     A hash object defining the version of the asset bundle.
    //
    //   crc:
    //     A checksum to compare to the downloaded data for integrity checking, or zero
    //     to skip integrity checking.
    //
    //   cachedBundle:
    //     A structure used to download a given version of AssetBundle to a customized cache
    //     path.
    //
    //   name:
    //     AssetBundle name which is used as the customized cache path.
    public DownloadHandlerAssetBundle(string url, CachedAssetBundle cachedBundle, uint crc)
    {
        InternalCreateAssetBundleCached(url, cachedBundle.name, cachedBundle.hash, crc);
    }

    //
    // Summary:
    //     Not implemented. Throws <a href="https:msdn.microsoft.comen-uslibrarysystem.notsupportedexception">NotSupportedException<a>.
    //
    //
    // Returns:
    //     Not implemented.
    protected override byte[] GetData()
    {
        throw new NotSupportedException("Raw data access is not supported for asset bundles");
    }

    //
    // Summary:
    //     Not implemented. Throws <a href="https:msdn.microsoft.comen-uslibrarysystem.notsupportedexception">NotSupportedException<a>.
    //
    //
    // Returns:
    //     Not implemented.
    protected override string GetText()
    {
        throw new NotSupportedException("String access is not supported for asset bundles");
    }

    //
    // Summary:
    //     Returns the downloaded AssetBundle, or null.
    //
    // Parameters:
    //   www:
    //     A finished UnityWebRequest object with DownloadHandlerAssetBundle attached.
    //
    // Returns:
    //     The same as DownloadHandlerAssetBundle.assetBundle
    public static AssetBundle GetContent(UnityWebRequest www)
    {
        return DownloadHandler.GetCheckedDownloader<DownloadHandlerAssetBundle>(www).assetBundle;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern IntPtr CreateCached_Injected(DownloadHandlerAssetBundle obj, string url, string name, ref Hash128 hash, uint crc);
}



