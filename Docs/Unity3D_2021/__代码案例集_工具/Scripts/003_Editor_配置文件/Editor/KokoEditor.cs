using UnityEngine;
using UnityEditor;
using System.IO;



[CustomEditor(typeof(Koko))]
public partial class KokoEditor : Editor 
{

    static int fileNameSuffix = 0; // 创建的文件的序号

    KokoData cachedProfile;
    Editor cachedProfileEditor;
    SerializedProperty koData;
    static GUIStyle boxStyle;


    void OnEnable() 
    {
        koData = serializedObject.FindProperty("koData");
    }


    public override void OnInspectorGUI() 
    {
        if (boxStyle == null) {
            boxStyle = new GUIStyle(GUI.skin.box);
            boxStyle.padding = new RectOffset(15, 10, 5, 5);
        }

        // 始终开放 KokoData 的绑定接口, 允许用户更换 KokoData 文件;
        base.OnInspectorGUI();
        
        if (koData.objectReferenceValue != null) 
        {
            if (cachedProfile != koData.objectReferenceValue) {
                cachedProfile = null;
            }
            if (cachedProfile == null) {
                cachedProfile = (KokoData)koData.objectReferenceValue;
                cachedProfileEditor = CreateEditor(koData.objectReferenceValue);
            }
            // Drawing the koData editor
            EditorGUILayout.BeginVertical(boxStyle);
            cachedProfileEditor.OnInspectorGUI();
            EditorGUILayout.EndVertical();
        } 
        else 
        {
            // 按钮上方的信息栏, 
            EditorGUILayout.HelpBox("Create or assign a fog koData.", MessageType.Info);
            if (GUILayout.Button("新建一个 KokoData 配置文件")) {
                CreateFogProfile();
            }
        }

        serializedObject.ApplyModifiedProperties();
    }


    void CreateFogProfile() 
    {
        string path = "Assets"; 

        KokoData fp = CreateInstance<KokoData>();
        fp.name = "New Volumetric Fog Profile_" + fileNameSuffix.ToString();
        fileNameSuffix++;
        AssetDatabase.CreateAsset(fp, path + "/" + fp.name + ".asset");
        AssetDatabase.SaveAssets();
        koData.objectReferenceValue = fp;
        EditorGUIUtility.PingObject(fp); // 让这个资源文件在 Assets 中高亮显示;
    }


}

