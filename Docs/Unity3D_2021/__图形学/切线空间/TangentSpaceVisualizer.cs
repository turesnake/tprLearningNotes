using UnityEngine;


// 在 Scene 窗口中显示 mesh 的每个顶点的 切线空间 信息

public class TangentSpaceVisualizer : MonoBehaviour 
{

    public float offset = 0.01f;
	public float scale = 0.06f;

	void OnDrawGizmos () 
    {
        MeshFilter filter = GetComponent<MeshFilter>();
		if (filter) {
			Mesh mesh = filter.sharedMesh;
			if (mesh) {
				ShowTangentSpace(mesh);
			}
		}
	}

    void ShowTangentSpace (Mesh mesh) 
    {
        Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
        Vector4[] tangents = mesh.tangents;
		for (int i = 0; i < vertices.Length; i++) {
			ShowTangentSpace(
				transform.TransformPoint(vertices[i]),//os->ws
				transform.TransformDirection(normals[i]),
                transform.TransformDirection(tangents[i]),
                tangents[i].w
			);
		}
	}

    void ShowTangentSpace (
        Vector3 vertex, Vector3 normal, Vector3 tangent, float binormalSign
    ){
        // normal - 绿
        vertex += normal * offset;
		Gizmos.color = Color.green;
		Gizmos.DrawLine(vertex, vertex + normal* scale);
        // tangent - 红
        Gizmos.color = Color.red;
		Gizmos.DrawLine(vertex, vertex + tangent * scale);
        // binormal - 蓝
        Vector3 binormal = Vector3.Cross(normal, tangent) * binormalSign;
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(vertex, vertex + binormal * scale);
	}




}

