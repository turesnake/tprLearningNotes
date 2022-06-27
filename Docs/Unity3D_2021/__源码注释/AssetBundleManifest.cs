#region 程序集 UnityEngine.AssetBundleModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AssetBundleModule.dll
#endregion


namespace UnityEngine
{
    /*
        Manifest for all the AssetBundles in the build.

            ===
            AssetBundle assetBundle = AssetBundle.LoadFromFile(manifestFilePath);
            AssetBundleManifest manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            ---
            像普通 ab包 那样将 .manifests 文件加载到内存,
            然后从中提取出 AssetBundleManifest 类型数据;


    */
    [NativeHeaderAttribute("Modules/AssetBundle/Public/AssetBundleManifest.h")]
    public class AssetBundleManifest : Object
    {
        

        //     Get all the AssetBundles in the manifest.
        //
        // 返回结果:
        //     An array of asset bundle names.
        [NativeMethodAttribute("GetAllAssetBundles")]
        public string[] GetAllAssetBundles();
        
        
        //     Get all the AssetBundles with variant in the manifest.
        //
        // 返回结果:
        //     An array of asset bundle names.
        [NativeMethodAttribute("GetAllAssetBundlesWithVariant")]
        public string[] GetAllAssetBundlesWithVariant();

        
        //     Get all the dependent AssetBundles for the given AssetBundle.
        //
        // 参数:
        //   assetBundleName:
        //     Name of the asset bundle.
        [NativeMethodAttribute("GetAllDependencies")]
        public string[] GetAllDependencies(string assetBundleName);


        //     Get the hash for the given AssetBundle.
        //
        // 参数:
        //   assetBundleName:
        //     Name of the asset bundle.
        //
        // 返回结果:
        //     The 128-bit hash for the asset bundle.
        [NativeMethodAttribute("GetAssetBundleHash")]
        public Hash128 GetAssetBundleHash(string assetBundleName);


        //     Get the direct dependent AssetBundles for the given AssetBundle.
        //
        // 参数:
        //   assetBundleName:
        //     Name of the asset bundle.
        //
        // 返回结果:
        //     Array of asset bundle names this asset bundle depends on.
        [NativeMethodAttribute("GetDirectDependencies")]
        public string[] GetDirectDependencies(string assetBundleName);
    }
}

