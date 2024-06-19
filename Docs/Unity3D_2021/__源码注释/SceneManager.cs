#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Events;
using UnityEngine.Internal;


namespace UnityEngine.SceneManagement
{
    //
    // 摘要:
    //     Scene management at run-time.
    [NativeHeaderAttribute("Runtime/Export/SceneManager/SceneManager.bindings.h")]
    [RequiredByNativeCodeAttribute]
    public class SceneManager
    {
        public SceneManager();

        //
        // 摘要:
        //     Number of Scenes in Build Settings.
        public static int sceneCountInBuildSettings { get; }
        //
        // 摘要:
        //     The total number of currently loaded Scenes.
        public static int sceneCount { get; }

        public static event UnityAction<Scene, Scene> activeSceneChanged;
        public static event UnityAction<Scene, LoadSceneMode> sceneLoaded;
        public static event UnityAction<Scene> sceneUnloaded;

        //
        // 摘要:
        //     Create an empty new Scene at runtime with the given name.
        //
        // 参数:
        //   sceneName:
        //     The name of the new Scene. It cannot be empty or null, or same as the name of
        //     the existing Scenes.
        //
        //   parameters:
        //     Various parameters used to create the Scene.
        //
        // 返回结果:
        //     A reference to the new Scene that was created, or an invalid Scene if creation
        //     failed.
        [NativeThrowsAttribute]
        [StaticAccessorAttribute("SceneManagerBindings", Bindings.StaticAccessorType.DoubleColon)]
        public static Scene CreateScene([NotNullAttribute("ArgumentNullException")] string sceneName, CreateSceneParameters parameters);
        //
        // 摘要:
        //     Create an empty new Scene at runtime with the given name.
        //
        // 参数:
        //   sceneName:
        //     The name of the new Scene. It cannot be empty or null, or same as the name of
        //     the existing Scenes.
        //
        //   parameters:
        //     Various parameters used to create the Scene.
        //
        // 返回结果:
        //     A reference to the new Scene that was created, or an invalid Scene if creation
        //     failed.
        public static Scene CreateScene(string sceneName);


        /*
            摘要:
                Gets the currently active Scene.
                !! 在非运行时, editor 代码中, 也能指向当前场景
            
            返回结果:
                The active Scene.
        */
        [StaticAccessorAttribute("SceneManagerBindings", Bindings.StaticAccessorType.DoubleColon)]
        public static Scene GetActiveScene();


        //
        // 摘要:
        //     Returns an array of all the Scenes currently open in the hierarchy.
        //
        // 返回结果:
        //     Array of Scenes in the Hierarchy.
        [Obsolete("Use SceneManager.sceneCount and SceneManager.GetSceneAt(int index) to loop the all scenes instead.")]
        public static Scene[] GetAllScenes();
        //
        // 摘要:
        //     Get the Scene at index in the SceneManager's list of loaded Scenes.
        //
        // 参数:
        //   index:
        //     Index of the Scene to get. Index must be greater than or equal to 0 and less
        //     than SceneManager.sceneCount.
        //
        // 返回结果:
        //     A reference to the Scene at the index specified.
        [NativeThrowsAttribute]
        [StaticAccessorAttribute("SceneManagerBindings", Bindings.StaticAccessorType.DoubleColon)]
        public static Scene GetSceneAt(int index);
        //
        // 摘要:
        //     Get a Scene struct from a build index.
        //
        // 参数:
        //   buildIndex:
        //     Build index as shown in the Build Settings window.
        //
        // 返回结果:
        //     A reference to the Scene, if valid. If not, an invalid Scene is returned.
        public static Scene GetSceneByBuildIndex(int buildIndex);
        //
        // 摘要:
        //     Searches through the Scenes loaded for a Scene with the given name.
        //
        // 参数:
        //   name:
        //     Name of Scene to find.
        //
        // 返回结果:
        //     A reference to the Scene, if valid. If not, an invalid Scene is returned.
        [StaticAccessorAttribute("SceneManagerBindings", Bindings.StaticAccessorType.DoubleColon)]
        public static Scene GetSceneByName(string name);
        //
        // 摘要:
        //     Searches all Scenes loaded for a Scene that has the given asset path.
        //
        // 参数:
        //   scenePath:
        //     Path of the Scene. Should be relative to the project folder. Like: "AssetsMyScenesMyScene.unity".
        //
        // 返回结果:
        //     A reference to the Scene, if valid. If not, an invalid Scene is returned.
        [StaticAccessorAttribute("SceneManagerBindings", Bindings.StaticAccessorType.DoubleColon)]
        public static Scene GetSceneByPath(string scenePath);

        //
        // 摘要:
        //     Loads the Scene by its name or index in Build Settings.
        //
        // 参数:
        //   sceneName:
        //     Name or path of the Scene to load.
        //
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to load.
        //
        //   mode:
        //     Allows you to specify whether or not to load the Scene additively. See SceneManagement.LoadSceneMode
        //     for more information about the options.
        public static void LoadScene(string sceneName, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode);

        [ExcludeFromDocs] public static void LoadScene(string sceneName);

        //
        // 摘要:
        //     Loads the Scene by its name or index in Build Settings.
        //
        // 参数:
        //   sceneName:
        //     Name or path of the Scene to load.
        //
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to load.
        //
        //   parameters:
        //     Various parameters used to load the Scene.
        //
        // 返回结果:
        //     A handle to the Scene being loaded.
        public static Scene LoadScene(string sceneName, LoadSceneParameters parameters);

        //
        // 摘要:
        //     Loads the Scene by its name or index in Build Settings.
        //
        // 参数:
        //   sceneName:
        //     Name or path of the Scene to load.
        //
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to load.
        //
        //   mode:
        //     Allows you to specify whether or not to load the Scene additively. See SceneManagement.LoadSceneMode
        //     for more information about the options.
        public static void LoadScene(int sceneBuildIndex, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode);
        [ExcludeFromDocs] public static void LoadScene(int sceneBuildIndex);

        //
        // 摘要:
        //     Loads the Scene by its name or index in Build Settings.
        //
        // 参数:
        //   sceneName:
        //     Name or path of the Scene to load.
        //
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to load.
        //
        //   parameters:
        //     Various parameters used to load the Scene.
        //
        // 返回结果:
        //     A handle to the Scene being loaded.
        public static Scene LoadScene(int sceneBuildIndex, LoadSceneParameters parameters);

        
        //
        // 摘要:
        //     Loads the Scene asynchronously in the background.
        //
        // 参数:
        //   sceneName:
        //     Name or path of the Scene to load.
        //
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to load.
        //
        //   mode:
        //     If LoadSceneMode.Single then all current Scenes will be unloaded before loading.
        //
        //   parameters:
        //     Struct that collects the various parameters into a single place except for the
        //     name and index.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation LoadSceneAsync(string sceneName, LoadSceneParameters parameters);
        [ExcludeFromDocs]
        public static AsyncOperation LoadSceneAsync(int sceneBuildIndex);
        //
        // 摘要:
        //     Loads the Scene asynchronously in the background.
        //
        // 参数:
        //   sceneName:
        //     Name or path of the Scene to load.
        //
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to load.
        //
        //   mode:
        //     If LoadSceneMode.Single then all current Scenes will be unloaded before loading.
        //
        //   parameters:
        //     Struct that collects the various parameters into a single place except for the
        //     name and index.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation LoadSceneAsync(string sceneName, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode);
        //
        // 摘要:
        //     Loads the Scene asynchronously in the background.
        //
        // 参数:
        //   sceneName:
        //     Name or path of the Scene to load.
        //
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to load.
        //
        //   mode:
        //     If LoadSceneMode.Single then all current Scenes will be unloaded before loading.
        //
        //   parameters:
        //     Struct that collects the various parameters into a single place except for the
        //     name and index.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation LoadSceneAsync(int sceneBuildIndex, LoadSceneParameters parameters);
        //
        // 摘要:
        //     Loads the Scene asynchronously in the background.
        //
        // 参数:
        //   sceneName:
        //     Name or path of the Scene to load.
        //
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to load.
        //
        //   mode:
        //     If LoadSceneMode.Single then all current Scenes will be unloaded before loading.
        //
        //   parameters:
        //     Struct that collects the various parameters into a single place except for the
        //     name and index.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation LoadSceneAsync(int sceneBuildIndex, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode);
        [ExcludeFromDocs]
        public static AsyncOperation LoadSceneAsync(string sceneName);
        //
        // 摘要:
        //     This will merge the source Scene into the destinationScene.
        //
        // 参数:
        //   sourceScene:
        //     The Scene that will be merged into the destination Scene.
        //
        //   destinationScene:
        //     Existing Scene to merge the source Scene into.
        [NativeThrowsAttribute]
        [StaticAccessorAttribute("SceneManagerBindings", Bindings.StaticAccessorType.DoubleColon)]
        public static void MergeScenes(Scene sourceScene, Scene destinationScene);
        //
        // 摘要:
        //     Move a GameObject from its current Scene to a new Scene.
        //
        // 参数:
        //   go:
        //     GameObject to move.
        //
        //   scene:
        //     Scene to move into.
        [NativeThrowsAttribute]
        [StaticAccessorAttribute("SceneManagerBindings", Bindings.StaticAccessorType.DoubleColon)]
        public static void MoveGameObjectToScene([NotNullAttribute("ArgumentNullException")] GameObject go, Scene scene);
        //
        // 摘要:
        //     Set the Scene to be active.
        //
        // 参数:
        //   scene:
        //     The Scene to be set.
        //
        // 返回结果:
        //     Returns false if the Scene is not loaded yet.
        [NativeThrowsAttribute]
        [StaticAccessorAttribute("SceneManagerBindings", Bindings.StaticAccessorType.DoubleColon)]
        public static bool SetActiveScene(Scene scene);
        //
        // 摘要:
        //     Destroys all GameObjects associated with the given Scene and removes the Scene
        //     from the SceneManager.
        //
        // 参数:
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to unload.
        //
        //   sceneName:
        //     Name or path of the Scene to unload.
        //
        //   scene:
        //     Scene to unload.
        //
        // 返回结果:
        //     Returns true if the Scene is unloaded.
        [Obsolete("Use SceneManager.UnloadSceneAsync. This function is not safe to use during triggers and under other circumstances. See Scripting reference for more details.")]
        public static bool UnloadScene(int sceneBuildIndex);
        //
        // 摘要:
        //     Destroys all GameObjects associated with the given Scene and removes the Scene
        //     from the SceneManager.
        //
        // 参数:
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to unload.
        //
        //   sceneName:
        //     Name or path of the Scene to unload.
        //
        //   scene:
        //     Scene to unload.
        //
        // 返回结果:
        //     Returns true if the Scene is unloaded.
        [Obsolete("Use SceneManager.UnloadSceneAsync. This function is not safe to use during triggers and under other circumstances. See Scripting reference for more details.")]
        public static bool UnloadScene(string sceneName);
        //
        // 摘要:
        //     Destroys all GameObjects associated with the given Scene and removes the Scene
        //     from the SceneManager.
        //
        // 参数:
        //   sceneBuildIndex:
        //     Index of the Scene in the Build Settings to unload.
        //
        //   sceneName:
        //     Name or path of the Scene to unload.
        //
        //   scene:
        //     Scene to unload.
        //
        // 返回结果:
        //     Returns true if the Scene is unloaded.
        [Obsolete("Use SceneManager.UnloadSceneAsync. This function is not safe to use during triggers and under other circumstances. See Scripting reference for more details.")]
        public static bool UnloadScene(Scene scene);
        //
        // 摘要:
        //     Destroys all GameObjects associated with the given Scene and removes the Scene
        //     from the SceneManager.
        //
        // 参数:
        //   sceneBuildIndex:
        //     Index of the Scene in BuildSettings.
        //
        //   sceneName:
        //     Name or path of the Scene to unload.
        //
        //   scene:
        //     Scene to unload.
        //
        //   options:
        //     Scene unloading options.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation UnloadSceneAsync(int sceneBuildIndex);
        //
        // 摘要:
        //     Destroys all GameObjects associated with the given Scene and removes the Scene
        //     from the SceneManager.
        //
        // 参数:
        //   sceneBuildIndex:
        //     Index of the Scene in BuildSettings.
        //
        //   sceneName:
        //     Name or path of the Scene to unload.
        //
        //   scene:
        //     Scene to unload.
        //
        //   options:
        //     Scene unloading options.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation UnloadSceneAsync(string sceneName);
        //
        // 摘要:
        //     Destroys all GameObjects associated with the given Scene and removes the Scene
        //     from the SceneManager.
        //
        // 参数:
        //   sceneBuildIndex:
        //     Index of the Scene in BuildSettings.
        //
        //   sceneName:
        //     Name or path of the Scene to unload.
        //
        //   scene:
        //     Scene to unload.
        //
        //   options:
        //     Scene unloading options.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation UnloadSceneAsync(Scene scene);
        //
        // 摘要:
        //     Destroys all GameObjects associated with the given Scene and removes the Scene
        //     from the SceneManager.
        //
        // 参数:
        //   sceneBuildIndex:
        //     Index of the Scene in BuildSettings.
        //
        //   sceneName:
        //     Name or path of the Scene to unload.
        //
        //   scene:
        //     Scene to unload.
        //
        //   options:
        //     Scene unloading options.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation UnloadSceneAsync(int sceneBuildIndex, UnloadSceneOptions options);
        //
        // 摘要:
        //     Destroys all GameObjects associated with the given Scene and removes the Scene
        //     from the SceneManager.
        //
        // 参数:
        //   sceneBuildIndex:
        //     Index of the Scene in BuildSettings.
        //
        //   sceneName:
        //     Name or path of the Scene to unload.
        //
        //   scene:
        //     Scene to unload.
        //
        //   options:
        //     Scene unloading options.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation UnloadSceneAsync(string sceneName, UnloadSceneOptions options);
        //
        // 摘要:
        //     Destroys all GameObjects associated with the given Scene and removes the Scene
        //     from the SceneManager.
        //
        // 参数:
        //   sceneBuildIndex:
        //     Index of the Scene in BuildSettings.
        //
        //   sceneName:
        //     Name or path of the Scene to unload.
        //
        //   scene:
        //     Scene to unload.
        //
        //   options:
        //     Scene unloading options.
        //
        // 返回结果:
        //     Use the AsyncOperation to determine if the operation has completed.
        public static AsyncOperation UnloadSceneAsync(Scene scene, UnloadSceneOptions options);
    }
}
