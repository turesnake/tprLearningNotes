using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;




public static class SubmeshedCombiner
{

    [MenuItem("Tools/美术工具/合并一个FBX文件内的所有_Submehes")]
    public static void CombineAllSubmeshes()
    {
        // --- 确保用户选择了正确对象:
        if(     Selection.activeObject == null 
            ||  (Selection.activeObject is Mesh) == false
        ){
            UnityEditor.EditorUtility.DisplayDialog( "Error", "请选择一个 FBX 文件下层的 mesh 文件", "OK" );
            return;
        }

        Mesh mesh = (Mesh)Selection.activeObject;
        mesh.SetTriangles(mesh.triangles, 0); // 把所有三角形放入 submesh 0
        mesh.subMeshCount = 1; // 删除多余 submesh 
    }

}
