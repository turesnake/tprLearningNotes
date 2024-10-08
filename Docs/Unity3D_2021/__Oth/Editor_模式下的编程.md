# ================================================================ #
#                    unity3d  Editor 模式下的编程
# ================================================================ #



# ----------------------------------------------#
#      让函数成为一个 editor 模式的按钮
# ----------------------------------------------#
public class A : MonoBehaviour{

    [MenuItem("tpr/button1")]
    static void func1(){
        ...
    }
}
    通过上述实现，可以在 unity 界面中多出一个 tpr 菜单，
    里面有一个 “button1” 按钮
    在 app 非运行模式，点击这个按钮，就能调用这个 函数
    比如用来自动化地 配置 or 生成一些东西 



# ----------------------------------------------#
#      如何实现 “加号” 按钮 来增加容器元素 
# ----------------------------------------------#
...
目前来看，这似乎是一个 自定义的 界面，
那个 加号，其实是个 button。




# ----------------------------------------------#
#        scene 窗口 图形显示
# ----------------------------------------------#

void OnDrawGizmos()
{
    ...
}

就能实现



# ----------------------------------------------#
#      遍历一个 go 的所有 子gos
# ----------------------------------------------#

    foreach( TrackNode tNode in GetComponentsInChildren<TrackNode>())
    {
        ...    
    }

遍历这个 父go 下的所有 子gos (同时还包括这个 父go 自己), 若某元素包含 组件 TrackNode, 就把这个 go 收集起来;







# ----------------------------------------------#
#    如何在 scene 场景中选中一个物体, 然后右键选择一个功能来执行
# ----------------------------------------------#




# ----------------------------------------------#
#   如何获得 inspector 中 选中高亮的 对象 (比如一个变量)
# ----------------------------------------------#
https://answers.unity.com/questions/728071/inspector-current-highlighted-element.html




# ----------------------------------------------#
#     EditorGUILayout  如何控制一行的 前/中/后 空白空间
# ----------------------------------------------#

    EditorGUILayout.BeginHorizontal();

        GUILayout.FlexibleSpace(); // Fill Space Beginning

        .......

        GUILayout.FlexibleSpace(); // Fill Space End

        .......

        GUILayout.FlexibleSpace(); // Fill Space End


    EditorGUILayout.EndHorizontal();
    ----

它可以把 头部 或 尾部 空间留出来;
尤其是你希望设置一组 右对齐 '+','-' 按钮时;





# ----------------------------------------------#
#   如何 一键 运行当前场景
# ----------------------------------------------#


EditorApplication.ExecuteMenuItem("Edit/Play");




# ----------------------------------------------#
#   如何 将 场景中的一个 gameobj focus (高亮显示)
# ----------------------------------------------#

# -1-
    EditorGUIUtility.PingObject(newgo);
    ---
    这个效果 比 下面的好

# -2-
    Selection.activeGameObject = newgo;



# ----------------------------------------------#
#   在 Asset 中新建一个文件后(比如 json), 如何生成它的 meta 文件
# ----------------------------------------------#

// Refresh the AssetDatabase to create the meta file
AssetDatabase.Refresh();



# ----------------------------------------------#
#      打开一个 文件选择窗口,  目录选择窗口
# ----------------------------------------------#

# EditorUtility.OpenFilePanel()
# EditorUtility.OpenFolderPanel()


    ==== 例如:
    string SelectFile()
    {
        string dataPath = Application.dataPath;
        string selectedPath = EditorUtility.OpenFilePanel("Path", dataPath, "");
        if (!string.IsNullOrEmpty(selectedPath))
        {
            if (selectedPath.StartsWith(dataPath))
            {
                return "Assets/" + selectedPath.Substring(dataPath.Length + 1);
            }
            else
            {
                ShowNotification(new GUIContent("不能在Assets目录之外!"));
            }
        }
        return null;
    }


    string SelectFolder()
    {
        string dataPath = Application.dataPath;
        string selectedPath = EditorUtility.OpenFolderPanel("Path", dataPath, "");
        if (!string.IsNullOrEmpty(selectedPath))
        {
            if (selectedPath.StartsWith(dataPath))
            {
                return "Assets/" + selectedPath.Substring(dataPath.Length + 1);
            }
            else
            {
                ShowNotification(new GUIContent("不能在Assets目录之外!"));
            }
        }

        return null;
    }


# ----------------------------------------------#
#     找到一个 obj 的 path
# ----------------------------------------------#

AssetDatabase.GetAssetPath() 



# ----------------------------------------------#
#     让某个节点 在 编辑场景内 不可被选中
# ----------------------------------------------#

SceneVisibilityManager.instance.DisablePicking( vcam2, true );










