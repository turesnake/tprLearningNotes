#region Assembly UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

namespace UnityEditor;

//
// Summary:
//     Enum indicating the type of Prefab Asset, such as Regular, Model and Variant.
public enum PrefabAssetType
{
    //
    // Summary:
    //     The object being queried is not part of a Prefab at all.
    NotAPrefab,
    
    //
    // Summary:
    //     The object being queried is part of a regular Prefab.
    Regular,

    /*
        Summary:
            The object being queried is part of a Model Prefab.

        new bing:
            A Model Prefab is a game object that is created from an FBX file or any other 3D modeling tool imported into your project
    */
    Model,

    //
    // Summary:
    //     The object being queried is part of a Prefab Variant.
    Variant,

    //
    // Summary:
    //     The object being queried is part of a Prefab instance, but because the asset
    //     is missing the actual type of Prefab can’t be determined.
    MissingAsset
}




