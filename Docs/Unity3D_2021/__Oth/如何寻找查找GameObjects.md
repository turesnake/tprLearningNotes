# ===================================================== #
#        如何查找 GameObjects
# ===================================================== #


# -------------------------------------------- #
#       GameObject.Find()
# -------------------------------------------- #
https://docs.unity3d.com/2021.3/Documentation/ScriptReference/GameObject.Find.html

# public static GameObject Find(string name);

--  若参数为 "Dog":
    它会在所有运行时场景中, 查找第一个符合要求的 active的 go, 并返回之;
    注意:
        这个查找可能是嵌套的(递归深入);

    查找顺序:
        实践发现, 顺序符合 gameobj 被创建的顺序;
        假设先后创建 3 个 Dog, 第一个在 root 层, 第二个在嵌套层, 第三个在 root 层;
        那么会先找到第一个;
        若把第一个 disactive, 则会返回第二个 (哪怕第二个在嵌套层)


# --  若参数为 "/Dog":
    则只会找 root 层的 gos;

    此时函数的行为是 非递归的;

#   若存在数个场景, 则会在每个场景的 root 层查找目标;



--  若参数为 "/KKK/Dog":
    则会先从 root 查找 KKK, 再在 KKK 子层查找 Dog;


# 在 Awake() 和 Start() 阶段都可使用   GameObject.Find() 来查找目标对象





# -------------------------------------------- #
#             Transform.Find()
# -------------------------------------------- #

    public Transform Find(string n);

--  若参数为 "Dog": 
    在本 transform 的子层查找目标 go, 
    !!!
    就算这个 go 是 disactive 的, 也能被找到 (和 GameObject.Find() 存在区别)

    不会递归查找, 若没在子层找到, 直接返回 null


--  若参数为 "Dog": 
    本函数行为会和 GameObject.Find() 有点像, 去全局 root 层查找...


--  若参数为 "pp/Dog": 
    去自己的 子层查找 pp, 再去 pp子层查找 Dog



# -------------------------------------------- #
#      在 runtime, 遍历一个场景的 所有 顶层 gameobjs
# -------------------------------------------- #

# Scene.GetRootGameObjects() 

    // Find the scene by name
    Scene targetScene = SceneManager.GetSceneByName("a");

    // Check if the scene is valid and loaded
    if (targetScene.IsValid() && targetScene.isLoaded)
    {
        // Get all root GameObjects in the scene
        GameObject[] rootObjects = targetScene.GetRootGameObjects();

        // Loop through each root GameObject and its children
        foreach (GameObject rootObject in rootObjects)
        {
            // Do something with the GameObject
            Debug.Log("Found GameObject in scene 'a': " + rootObject.name);
        }
    }
    else
    {
        Debug.Log("Scene 'a' is not loaded or does not exist.");
    }




# -------------------------------------------- #
#       如何找到 场景中的 inactive 的 go
# -------------------------------------------- #


# -1-: 找到场景中所有携带了 component: TT 的 go, 包含 inactive 的
    var allTTs = UnityEngine.Object.FindObjectsOfType<TT>(true);
    ---
    然后在其中继续查找;


# UnityEngine.Object.FindObjectOfType()

Returns the first active loaded object of Type type.




# === 有效代码:
# 可在 非运行状态下执行
public static GameObject FindGameObjectByPath(string path)
{
    string[] parts = path.Split('/');
    if (parts.Length == 0)
    {
        return null;
    }

    // 从场景根节点遍历查找
    Transform current = null;
    GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

    foreach (GameObject rootObject in rootObjects)
    {
        if (rootObject.name == parts[0])
        {
            current = rootObject.transform;
            break;
        }
    }

    // 递归查找子对象
    for (int i = 1; i < parts.Length; i++)
    {
        if (current == null)
        {
            return null;
        }
        current = current.Find(parts[i]);
    }
    return current ? current.gameObject : null;
}



# ---
这个函数 FindGameObjectByPath 将根据提供的路径递归查找场景中的 GameObject。注意事项如下：

path 变量中指定的路径中，各个部分必须用 / 分隔。
该函数假设路径的根节点是场景中的一个根对象。
如果找不到对象，函数将返回 null。
你可以将这个函数放在你的任何脚本中，并在需要查找 GameObject 时调用它。











