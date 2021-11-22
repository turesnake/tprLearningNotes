
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System.Collections.Generic;

namespace UnityEngine.SceneManagement
{
    //
    // 摘要:
    //     Run-time data structure for *.unity file.
    [NativeHeaderAttribute("Runtime/Export/SceneManager/Scene.bindings.h")]
    public struct Scene
    {
        public int handle { get; }
        //
        // 摘要:
        //     Returns the relative path of the Scene. Like: "AssetsMyScenesMyScene.unity".
        public string path { get; }
        //
        // 摘要:
        //     Returns the name of the Scene that is currently active in the game or app.
        public string name { get; set; }
        //
        // 摘要:
        //     Returns true if the Scene is loaded.
        public bool isLoaded { get; }
        //
        // 摘要:
        //     Return the index of the Scene in the Build Settings.
        public int buildIndex { get; }
        //
        // 摘要:
        //     Returns true if the Scene is modifed.
        public bool isDirty { get; }
        //
        // 摘要:
        //     The number of root transforms of this Scene.
        public int rootCount { get; }
        public bool isSubScene { get; set; }

        public override bool Equals(object other);
        public override int GetHashCode();
        //
        // 摘要:
        //     Returns all the root game objects in the Scene.
        //
        // 返回结果:
        //     An array of game objects.
        public GameObject[] GetRootGameObjects();
        public void GetRootGameObjects(List<GameObject> rootGameObjects);
        //
        // 摘要:
        //     Whether this is a valid Scene. A Scene may be invalid if, for example, you tried
        //     to open a Scene that does not exist. In this case, the Scene returned from EditorSceneManager.OpenScene
        //     would return False for IsValid.
        //
        // 返回结果:
        //     Whether this is a valid Scene.
        public bool IsValid();

        public static bool operator ==(Scene lhs, Scene rhs);
        public static bool operator !=(Scene lhs, Scene rhs);
    }
}

