#region Assembly UnityEngine.UnityWebRequestAssetBundleModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System;

namespace UnityEngine.Networking;

//
// Summary:
//     Helpers for downloading asset bundles using UnityWebRequest.
public static class UnityWebRequestAssetBundle
{
    //
    // Summary:
    //     Creates a UnityWebRequest optimized for downloading a Unity Asset Bundle via
    //     HTTP GET.
    //
    // Parameters:
    //   uri:
    //     The URI of the asset bundle to download.
    //
    //   crc:
    //     If nonzero, this number will be compared to the checksum of the downloaded asset
    //     bundle data. If the CRCs do not match, an error will be logged and the asset
    //     bundle will not be loaded. If set to zero, CRC checking will be skipped.
    //
    //   version:
    //     An integer version number, which will be compared to the cached version of the
    //     asset bundle to download. Increment this number to force Unity to redownload
    //     a cached asset bundle. Analogous to the version parameter for WWW.LoadFromCacheOrDownload.
    //
    //
    //   hash:
    //     A version hash. If this hash does not match the hash for the cached version of
    //     this asset bundle, the asset bundle will be redownloaded.
    //
    //   cachedAssetBundle:
    //     A structure used to download a given version of AssetBundle to a customized cache
    //     path.
    //
    // Returns:
    //     A UnityWebRequest configured to downloading a Unity Asset Bundle.
    public static UnityWebRequest GetAssetBundle(string uri)
    {
        return GetAssetBundle(uri, 0u);
    }


    public static UnityWebRequest GetAssetBundle(Uri uri)
    {
        return GetAssetBundle(uri, 0u);
    }


    public static UnityWebRequest GetAssetBundle(string uri, uint crc)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerAssetBundle(uri, crc), null);
    }


    public static UnityWebRequest GetAssetBundle(Uri uri, uint crc)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerAssetBundle(uri.AbsoluteUri, crc), null);
    }


    public static UnityWebRequest GetAssetBundle(string uri, uint version, uint crc)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerAssetBundle(uri, version, crc), null);
    }


    public static UnityWebRequest GetAssetBundle(Uri uri, uint version, uint crc)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerAssetBundle(uri.AbsoluteUri, version, crc), null);
    }


    public static UnityWebRequest GetAssetBundle(string uri, Hash128 hash, uint crc = 0u)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerAssetBundle(uri, hash, crc), null);
    }


    public static UnityWebRequest GetAssetBundle(Uri uri, Hash128 hash, uint crc = 0u)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerAssetBundle(uri.AbsoluteUri, hash, crc), null);
    }


    public static UnityWebRequest GetAssetBundle(string uri, CachedAssetBundle cachedAssetBundle, uint crc = 0u)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerAssetBundle(uri, cachedAssetBundle, crc), null);
    }


    public static UnityWebRequest GetAssetBundle(Uri uri, CachedAssetBundle cachedAssetBundle, uint crc = 0u)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerAssetBundle(uri.AbsoluteUri, cachedAssetBundle, crc), null);
    }
}


