#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    //
    // 摘要:
    //     Bit-mask that controls object destruction, saving and visibility in inspectors.
    [Flags]
    public enum HideFlags//HideFlags__
    {
        //
        // 摘要:
        //     A normal, visible object. This is the default.
        None = 0,
        //
        // 摘要:
        //     The object will not appear in the hierarchy.
        HideInHierarchy = 1,
        //
        // 摘要:
        //     It is not possible to view it in the inspector.
        HideInInspector = 2,
        //
        // 摘要:
        //     The object will not be saved to the Scene in the editor.
        DontSaveInEditor = 4,
        //
        // 摘要:
        //     The object will not be editable in the inspector.
        NotEditable = 8,
        //
        // 摘要:
        //     The object will not be saved when building a player.
        DontSaveInBuild = 16,
        //
        // 摘要:
        //     The object will not be unloaded by Resources.UnloadUnusedAssets.
        DontUnloadUnusedAsset = 32,
        //
        // 摘要:
        //     The object will not be saved to the Scene. It will not be destroyed when a new
        //     Scene is loaded. It is a shortcut for HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor
        //     | HideFlags.DontUnloadUnusedAsset.
        DontSave = 52,
        //
        // 摘要:
        //     The GameObject is not shown in the Hierarchy, not saved to to Scenes, and not
        //     unloaded by Resources.UnloadUnusedAssets.
        HideAndDontSave = 61
    }
}
