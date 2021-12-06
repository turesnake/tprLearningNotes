#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        Bit-mask that controls object destruction, saving and visibility in inspectors.

        Note: Setting hide flags to "DontSaveInEditor", "DontSaveInBuild" or "HideInHierarchy" 
        will internally cause the object to be removed from the Unity Scene, 
        removing it from its current physics scene as well (This includes both 2D and 3D physics scenes). 
        This will also cause the object to trigger its OnDisable() and OnEnable() calls.
    */
    [Flags]
    public enum HideFlags//HideFlags__
    {
        
        //     A normal, visible object. This is the default.
        None = 0,
        
        //     The object will not appear in the hierarchy.
        HideInHierarchy = 1,
        
        //     It is not possible to view it in the inspector.
        HideInInspector = 2,
        

        //     The object will not be saved to the Scene in the editor.
        // You must manually clear the object from memory using "DestroyImmediate()" to avoid memory leaks.
        DontSaveInEditor = 4,
        

        //     The object will not be editable in the inspector.
        NotEditable = 8,
        

        //     The object will not be saved when building a player.
        // You must manually clear the object from memory using "DestroyImmediate()" to avoid memory leaks.
        DontSaveInBuild = 16,
        
        //     The object will not be unloaded(卸载) by Resources.UnloadUnusedAssets.
        // You must manually clear the object from memory using "DestroyImmediate()" to avoid memory leaks.
        DontUnloadUnusedAsset = 32,
        
        //     The object will not be saved to the Scene. It will not be destroyed when a new Scene is loaded. 
        //     It is a shortcut for: HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor | HideFlags.DontUnloadUnusedAsset.
        //  You must manually clear the object from memory using "DestroyImmediate()" to avoid memory leaks.
        DontSave = 52,
        

        //  The GameObject is not shown in the Hierarchy, not saved to to Scenes, and not unloaded by "Resources.UnloadUnusedAssets()".
        //  This is most commonly used for GameObjects which are created by a script and are purely under the script's control.
        HideAndDontSave = 61
    }
}
