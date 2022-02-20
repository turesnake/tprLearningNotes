#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace UnityEditor
{
    /*
        Base class from which asset importers for specific asset types derive.
        特定资产类型的资产导入器从中派生的基类。
    */   
    [ExcludeFromObjectFactory]
    [NativeHeaderAttribute("Editor/Src/AssetPipeline/AssetImporter.h")]
    [NativeHeaderAttribute("Editor/Src/AssetPipeline/AssetImporter.bindings.h")]
    [Preserve]
    [UsedByNativeCodeAttribute]
    public class AssetImporter//AssetImporter__
        : UnityEngine.Object
    {
        public AssetImporter();

       
        //     The path name of the asset for this importer. (Read Only)
        [NativeNameAttribute("AssetPathName")]
        public string assetPath { get; }

        
        //     The value is true when no meta file is provided with the imported asset.
        // 当导入的资产没有提供 元文件 时，该值为 true。
        public bool importSettingsMissing { get; }

        // tpr: 时间戳
        public ulong assetTimeStamp { get; }


        /*
            Get or set any user data.

            this can be useful during asset post processing if you want to associate eg. a model 
            with an auxillary(辅助的) xml file to control some parts of the importing 
            or you can put your xml data directly in to the userData field.
        */
        public string userData { get; set; }


        
        //     Get or set the AssetBundle name.
        public string assetBundleName { get; set; }


        /*
            Get or set the AssetBundle variant.

            AssetBundle variant is combined with the "AssetImporter.assetBundleName" 
            as the file extension to generate the full AssetBundle name.

            AssetBundle variant is used to achieve virtual assets via AssetBundle. 
            AssetBundles which have the same AssetBundle name but different AssetBundle variants 
            will have the same internal IDs. 
            
            So they can be switched out arbitrarily with AssetBundles of different variants.

            Please make sure the assets exactly match in variant AssetBundles.
        */
        public string assetBundleVariant { get; set; }



        /*
            Retrieves the asset importer for the asset at path.

            See Also: "ModelImporter", "TextureImporter", "AudioImporter" .
        
            参数:
            path:
        */
        [FreeFunctionAttribute("FindAssetImporterAtAssetPath")]
        public static AssetImporter GetAtPath(string path);


        /*
            Map a sub-asset from an imported asset (such as an FBX file) to an external Asset of the same type.

            Apply changes by writing the metadata and reimporting the Asset. 
            Instances of the Asset automatically use the mapped object once you have reimported the Asset.

            If the type of the external asset does not match the type of the sub-asset, or if the reference is null, 
            instances of the Asset will continue to use the internal asset without producing an error.
        */
        public void AddRemap(SourceAssetIdentifier identifier, UnityEngine.Object externalObject);


        /*
            Gets a copy of the external object map used by the AssetImporter.

            Changing the map does not affect the state of the AssetImporter.

            See Also: AssetImporter.AddRemap, AssetImporter.RemoveRemap.
        
            返回结果:
                The map between a sub-asset and an external Asset.
        */
        public Dictionary<SourceAssetIdentifier, UnityEngine.Object> GetExternalObjectMap();


        /*
            Removes an item from the map of external objects.

            Apply changes by writing the metadata and reimporting the Asset.

            The external Asset referenced in the map is not affected in any way by this method.
        */
        public bool RemoveRemap(SourceAssetIdentifier identifier);


        /*
            Save asset importer settings if asset importer is dirty.
            Under the hood this calls AssetDatabase.ImportAsset. See Also: EditorUtility.SetDirty.
        */
        public void SaveAndReimport();
        

        //     Set the AssetBundle name and variant.
        //
        // 参数:
        //   assetBundleName:
        //     AssetBundle name.
        //
        //   assetBundleVariant:
        //     AssetBundle variant.
        [NativeNameAttribute("SetAssetBundleName")]
        public void SetAssetBundleNameAndVariant(string assetBundleName, string assetBundleVariant);

        
        // 摘要:
        //     Checks if the AssetImporter supports remapping the given asset type.
        //
        // 参数:
        //   type:
        //     The type of asset to check.
        //
        // 返回结果:
        //     Returns true if the importer supports remapping the given type. Otherwise, returns false.
        [FreeFunctionAttribute("AssetImporterBindings::SupportsRemappedAssetType", HasExplicitThis = true, IsThreadSafe = true)]
        public bool SupportsRemappedAssetType(Type type);



        //
        // 摘要:
        //     Represents a unique identifier for a sub-asset embedded in an imported Asset (such as an FBX file).
        [NativeTypeAttribute(UnityEngine.Bindings.CodegenOptions.Custom, "MonoSourceAssetIdentifier")]
        public struct SourceAssetIdentifier
        {
            
            //     The type of the Asset.
            public Type type;
            
            //     The name of the Asset.
            public string name;

            //  构造函数
            //     Constructs a SourceAssetIdentifier.
            //
            // 参数:
            //   asset:
            //     The the sub-asset embedded in the imported Asset.
            //
            //   type:
            //     The type of the sub-asset embedded in the imported Asset.
            //
            //   name:
            //     The name of the sub-asset embedded in the imported Asset.
            public SourceAssetIdentifier(UnityEngine.Object asset);
            public SourceAssetIdentifier(Type type, string name);
        }
    }
}

