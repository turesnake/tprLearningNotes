
#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using System.ComponentModel;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Internal;

namespace UnityEditor
{
     
    /*
        摘要:
        AssetPostprocessor lets you hook into the import pipeline and run scripts prior or after importing assets.


        During model import the functions are called in the the following order:
        -- 
            "OnPreprocessModel()" is called at the very beginning 
                and you can override "ModelImporter" settings(a class) that are used for the whole model import process.
        --
            After Meshes and Materials are imported, the GameObjects hierarchy is created from the imported nodes. 
            Use "OnPostprocessMeshHierarchy()" to change the hierarchy. 
            Every GameObject that represents an imported node is given a corresponding MeshFilter, MeshRenderer, and MeshCollider component. 
            (每个表示导入节点的 GameObject 都被赋予了相应的 MeshFilter、MeshRenderer 和 MeshCollider 组件。)
            Before assigning a Material to the MeshRenderer, the "OnAssignMaterialModel()" function is invoked.
        --
            After GameObject has initialized MeshRenderers and "userdata" exists, 
            "OnPostprocessGameObjectWithUserProperties()" is called. 
            That happens before children GameObjects are generated.
        --
            If animation generation was not disabled at previous stages (see "ModelImporter.generateAnimations" ), 
            then SkinnedMesh and Animations are generated. 
            If possible Avatar is also created and GameObjecs hierarchy is optimized. 
            After that "OnPostprocessModel()" is called for the root GameObject.

        "OnPreprocessSpeedTree()" and "OnPostprocessSpeedTree()" are called on SpeedTree assets (.spm file) the same way 
        as "OnPreprocessModel()" and "OnPostprocessModel()", 
        except that the "AssetPostprocessor.assetImporter" type is "SpeedTreeImporter".

        In a production pipeline AssetPostprocessors should always be placed in pre-built dll's in the project instead of in scripts. 
        (在一个 production pipeline 中，那些 AssetPostprocessor 们应始终放置在项目中的 "预构建 dll" 中，而不是脚本中。)
        
        AssetPostprocessors change the output of imported assets, 
        thus a compile error in one of the scripts will lead to assets being imported differently. 
        This can be a severe issue when working in a production pipeline. 
        
        By using dll's for AssetPostprocessors you ensure that they can always be executed even if the scripts have compile errors. 
        This way you can override default values in the import settings or modify the imported data like textures or meshes.

    */
    public class AssetPostprocessor
    {
        public AssetPostprocessor();

        //
        // 摘要:
        //     The path name of the asset being imported.
        public string assetPath { get; set; }
        //
        // 摘要:
        //     The import context.
        public AssetImportContext context { get; }
        //
        // 摘要:
        //     Reference to the asset importer.
        public AssetImporter assetImporter { get; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("To set or get the preview, call EditorUtility.SetAssetPreview or AssetPreview.GetAssetPreview instead", true)]
        public Texture2D preview { get; set; }

        //
        // 摘要:
        //     Override the order in which importers are processed.
        public virtual int GetPostprocessOrder();
        //
        // 摘要:
        //     Returns the version of the asset postprocessor.
        public virtual uint GetVersion();
        //
        // 摘要:
        //     Logs an import error message to the console.
        //
        // 参数:
        //   warning:
        //
        //   context:
        [ExcludeFromDocs]
        public void LogError(string warning);
        //
        // 摘要:
        //     Logs an import error message to the console.
        //
        // 参数:
        //   warning:
        //
        //   context:
        public void LogError(string warning, [UnityEngine.Internal.DefaultValue("null")] UnityEngine.Object context);
        //
        // 摘要:
        //     Logs an import warning to the console.
        //
        // 参数:
        //   warning:
        //
        //   context:
        [ExcludeFromDocs]
        public void LogWarning(string warning);
        //
        // 摘要:
        //     Logs an import warning to the console.
        //
        // 参数:
        //   warning:
        //
        //   context:
        public void LogWarning(string warning, [UnityEngine.Internal.DefaultValue("null")] UnityEngine.Object context);
    }
}


