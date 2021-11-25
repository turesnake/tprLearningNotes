
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System.Collections.Generic;

namespace UnityEngine.SceneManagement
{
    /*
        摘要:
        Run-time data structure for *.unity file.
    */
    [NativeHeaderAttribute("Runtime/Export/SceneManager/Scene.bindings.h")]
    public struct Scene
    {
        public int handle { get; }


        
        //     Returns the relative path of the Scene. Like: "AssetsMyScenesMyScene.unity".
        public string path { get; }

        /*
            Returns the name of the Scene that is currently active in the game or app.

            本变量 returns a run-time, read-only, string value. 
            The name limits to 244 characters. 默认值为 "scene". 
            用户可在 游戏创建阶段 修改这个 name;

            文档给出了 详细丰富的 代码案例;
        */
        public string name { get; set; }


        //     Returns true if the Scene is loaded.
        public bool isLoaded { get; }


        /*
            Return the index of the Scene in the Build Settings.

            本值起始于 0, 最大为 "scene个数-1";

            如果一个 scene 没有被添加到 "Scenes in Build window" 中,
            这个 scene 也会被分配 idx, 不过起始于 "listNum+1";
            比如, 当前游戏中有 6 个 scene, 其中5个是添加到 "Scenes in Build window" 中的,
            有一个没有, 那么这个的idx 就从 6 号开始;

            If the Scene is loaded through an "AssetBundle", Scene.buildIndex returns -1.
        */
        public int buildIndex { get; }

        
        //     Returns true if the Scene is modifed.
        public bool isDirty { get; }

        /*
            The number of root transforms of this Scene.
            没看懂... 
        */
        public int rootCount { get; }


        public bool isSubScene { get; set; }


        public override bool Equals(object other);
        public override int GetHashCode();


        
        // 摘要:
        //     Returns all the root game objects in the Scene.
        //
        // 返回结果:
        //     An array of game objects.
        public GameObject[] GetRootGameObjects();
        public void GetRootGameObjects(List<GameObject> rootGameObjects);


        /*
            摘要:
            Whether this is a valid Scene. 
           
            如果你试图打开一个不存在的 scene, 比如调用 "EditorSceneManager.OpenScene()",
            那么返回的 scene.IsValid() 将会得到 false;
    
        */
        public bool IsValid();



        public static bool operator ==(Scene lhs, Scene rhs);
        public static bool operator !=(Scene lhs, Scene rhs);
    }
}

