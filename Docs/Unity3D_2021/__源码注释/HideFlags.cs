#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        Bit-mask that controls object destruction, saving and visibility in inspectors.
        ---
        按照这个描述, 这东西似乎只在 editor 平台中有效; 毕竟在真的 打包运行时, 也不存在 inspectors;


        Note: Setting hide flags to "DontSaveInEditor", "DontSaveInBuild" or "HideInHierarchy" 
        will internally cause the object to be removed from the Unity Scene, 
        removing it from its current physics scene as well (This includes both 2D and 3D physics scenes). 
        This will also cause the object to trigger its OnDisable() and OnEnable() calls.
        ---

        有个人说:
        Yes, it's actually only used inside the editor. Since this is the only place where assets / data is serialized / saved. 
        At runtime you can't "save" any assets or objects.
        The best example is the camera for the SceneView which is attached to an invisible gameobject (HideAndDontSave). 
        This gameobject is created when the sceneview is opened. Since it's a gameobject it is inside the current scene, 
        but it isn't saved. It's also used for many other editor resources like textures for the GUI.
        ---
        最好的案例是 点亮 sceneView 时的 场景, 此时 理论上会存在一个负责渲染 scene 窗口的 相机, 但我们其实没有在 scene 的 hierachy 中
        看到这个相机, 这是因为它被挂在一个 不可见的 gameobj 下方, 一起被隐藏了;

        而且当我们保存这个 scene 时, 这个相机也没有被存入 scene 中; 

        这是 本 enum 的真实用例;

        =========================================
        说到底就是, 如果我们在一个场景中, 使用 运行时脚本去创建 go, 在 editor 平台点击 play, 然后结束 play 后, 这个 go 可能会留在这个场景中;
        反复多次后, 场景中就留下一堆相同的 go;

        为避免此文件, 可将此 go 的 hideFlags 设置为 DontSave;  (然后也是无需去手动释放它的)
        然后就能规避此问题了;

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
