#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion


namespace UnityEditor
{
    /*
    摘要:
        AssetBundle building map entry.

        This class is used with BuildPipeline.BuildAssetBundles() to specify the name of a bundle and the names of the assets that it will contain. 
        The array of AssetBundleBuild elements that is passed to the function is known as the "building map" 
        and serves as an alternative(替代品) to specifying the contents of bundles from the editor.
        ---
        本 数据结构 专用于 BuildPipeline.BuildAssetBundles(),
        主要包含两组信息:
        -- ab包 的名字
        -- 这个 ab包 包含的 assets 的名字; (其实是一组 相对path)


    */
    public struct AssetBundleBuild
    {
        //
        // 摘要:
        //     AssetBundle name.
        public string assetBundleName;
        //
        // 摘要:
        //     AssetBundle variant.
        public string assetBundleVariant;

        /*
            Asset names which belong to the given AssetBundle.
            Please use the asset path relative to the project folder, for example "Assets/MyPrefab.prefab".
            ---
            其实是个 相对path
        */
        public string[] assetNames;
        
        /*
            Addressable(可寻址) name used to load an asset.

            To provide custom addressable names for assets in the bundle, this array needs to be the same size as AssetBundleBuild.assetNames. 
            Each entry in this array will be matched to the asset in assetNames based on index. 
            If the string in a given index in addressableNames is empty, the value in assetNames at the same index is used instead (default behaviour).
            ---
            同一个 idx, 若本数字对应元素为空, 那就使用 assetNames 中的对应元素;
        */
        [NativeNameAttribute("nameOverrides")]
        public string[] addressableNames;
    }
}

