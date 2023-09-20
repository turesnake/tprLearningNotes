#region 程序集 UnityEngine.AssetBundleModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AssetBundleModule.dll
#endregion


namespace UnityEngine
{
    /*
        Manifest for all the AssetBundles in the build.

            ===
            string manifestFilePath      = "Assets/OutAssetBundles/OutAssetBundles";     // 注意, 这个 abPath 不是 .manifests 后缀文件的, 也不是普通 ab 文件的, 是那个 root ab文件的
            AssetBundle assetBundle      = AssetBundle.LoadFromFile(manifestFilePath);
            AssetBundleManifest manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            ---
            像普通 ab包 那样将 .manifests 文件加载到内存,
            然后从中提取出 AssetBundleManifest 类型数据;

            更详细步骤:
            https://docs.unity3d.com/2021.3/Documentation/Manual/AssetBundles-Native.html
            !!! 注意, 不是任意一个 ab 文件都能通过 上述方法 访问到它的 manifests 信息, 必须去访问那个 root ab 文件的;


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

