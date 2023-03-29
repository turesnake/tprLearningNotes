using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(LuaParameters))]
public class LuaParametersInspector : UnityEditor.Editor
{

    
    GUIStyle GreenFont;
    GUIStyle RedFont;

    GUIContent valueGUIContent = new GUIContent("Value:");

    HashSet<string> keys = new HashSet<string>();


    private void OnEnable()
    {
        GreenFont = new GUIStyle();
        GreenFont.fontStyle = FontStyle.Bold;
        GreenFont.fontSize = 11;
        GreenFont.normal.textColor = Color.green;
        RedFont = new GUIStyle();
        RedFont.fontStyle = FontStyle.Bold;
        RedFont.fontSize = 11;
        RedFont.normal.textColor = Color.red;
    }


    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        var entity = target as LuaParameters;
        
        if (entity.keyValueList == null || entity.keyValueList.Count == 0)
        {
            if (GUILayout.Button("Add New Element"))
            {
                if (entity.keyValueList == null)
                {
                    entity.keyValueList = new List<LuaParameters.Pair>();
                }

                entity.keyValueList.Add(new LuaParameters.Pair());
            }
        }
        else
        {
            bool isDirty = false;
            keys.Clear();
            
            for (var j = entity.keyValueList.Count - 1; j >= 0; j--)
            {
                EditorGUILayout.Separator();
                GUILayout.Button("", GUILayout.Height(2)); // 一条分割线
                //---:
                
                var pair = entity.keyValueList[j];
                LuaParameters.Pair oldPiar = new LuaParameters.Pair( pair ); // deep copy

                //---:
                EditorGUILayout.BeginHorizontal();

                    pair.valueType = (LuaParameters.Type)EditorGUILayout.EnumPopup( "value-Type", pair.valueType );
                    
                    EditorGUILayout.Space();
                    if (GUILayout.Button("+"))
                    {
                        Undo.RecordObject(target, "Insert");
                        entity.keyValueList.Insert(j, new LuaParameters.Pair());
                    }
                    if (GUILayout.Button("-"))
                    {
                        Undo.RecordObject(target, "Remove");
                        entity.keyValueList.RemoveAt(j);
                    }

                EditorGUILayout.EndHorizontal();


                // 当用户切换类型时, 主动重置所有值, 可选
                if(pair.valueType != oldPiar.valueType) 
                {
                    pair.ClearValues();
                }                

                pair.key = EditorGUILayout.TextField("Key:", pair.key);

                switch( pair.valueType ) 
                {
                    case LuaParameters.Type.String:
                        pair.stringValue      = EditorGUILayout.TextField( valueGUIContent, pair.stringValue );
                        break;

                    case LuaParameters.Type.Int:
                        pair.intValue        = EditorGUILayout.IntField( valueGUIContent, pair.intValue );
                        break;

                    case LuaParameters.Type.Float:
                        pair.vector4Value.x      = EditorGUILayout.FloatField( valueGUIContent, pair.vector4Value.x );
                        break;

                    case LuaParameters.Type.Vector2:
                        Vector2 ret2      = EditorGUILayout.Vector2Field( valueGUIContent, (Vector2)pair.vector4Value );
                        pair.vector4Value.x = ret2.x;
                        pair.vector4Value.y = ret2.y;
                        break;

                    case LuaParameters.Type.Vector3:
                        Vector3 ret3      = EditorGUILayout.Vector3Field( valueGUIContent, (Vector3)pair.vector4Value );
                        pair.vector4Value.x = ret3.x;
                        pair.vector4Value.y = ret3.y;
                        pair.vector4Value.z = ret3.z;
                        break;
                        
                    case LuaParameters.Type.Vector4:
                        pair.vector4Value      = EditorGUILayout.Vector4Field( valueGUIContent, pair.vector4Value );
                        break;

                    case LuaParameters.Type.Color:
                        pair.vector4Value      = (Vector4)EditorGUILayout.ColorField( valueGUIContent, (Color)pair.vector4Value, true, true, true );
                        break;

                    default: 
                        break;
                }


                //-------:
                if( pair.key == null || pair.key.Length == 0 ) 
                {
                    EditorGUILayout.LabelField( "警告: Key 不能为空",RedFont );
                }
                else  
                {
                    if( keys.Contains( pair.key ) == true ) 
                    {
                        EditorGUILayout.LabelField( "警告: Key 不能重复",RedFont );
                    }
                    else 
                    {
                        keys.Add(pair.key);
                    }
                }


                isDirty |= (LuaParameters.Pair.IsEqual( oldPiar, pair ) == false);
            }

            if(isDirty) 
            {
                EditorUtility.SetDirty( entity ); 
            }

        }

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "GUI Change Check");
        }
    }

}



