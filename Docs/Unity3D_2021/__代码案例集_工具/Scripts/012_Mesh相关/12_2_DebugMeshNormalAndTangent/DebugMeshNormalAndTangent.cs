using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace GameDebug 
{


/*
    在 scene 窗口中显示一个正在播放动画的 SkinnedMeshRenderer 的每个顶点的 法线 和 切线方向;
    ---
    但是如果在 动画之后, 又在 shader 中改写了 顶点信息, 此时用本函数是看不到 最新顶点的 法线信息的; (可能要上 gpu instancing ?)
*/
public class DebugMeshNormalAndTangent : MonoBehaviour
{

    // SkinnedMeshRenderer.GetVertexBuffer() 得到的数据结构
    public struct BufferVertexData 
    {
        public Vector3 posOS;
        public Vector3 normalOS;
        public Vector4 tangentOS;
    }

    public SkinnedMeshRenderer srcSkinnedMeshRenderer;
    
    void Start()
    {
        Debug.Assert( srcSkinnedMeshRenderer );
        var mesh = srcSkinnedMeshRenderer.sharedMesh;
        Debug.Log( "vertex num = " + mesh.vertices.Length );
        Debug.Log( "normals num = " + mesh.normals.Length );
        Debug.Assert( mesh.normals.Length == mesh.tangents.Length );
        Debug.Assert( mesh.vertices.Length == mesh.normals.Length );
   }


    void Update()
    {
    }


    void OnDrawGizmos()
    {
        var mesh = srcSkinnedMeshRenderer.sharedMesh;
        int vertexNum = mesh.vertices.Length;

        GraphicsBuffer vBuffer = srcSkinnedMeshRenderer.GetVertexBuffer();
        if( vBuffer == null )
        {
            return;
        }
        BufferVertexData[] array = new BufferVertexData[vertexNum];
        vBuffer.GetData( array );

        for( int i=0; i<vertexNum; i++ )
        {
            var e = array[i];
            Vector3 posOS = e.posOS;
            Vector3 normal = e.normalOS;
            Vector4 tangent = e.tangentOS;
            Vector3 tangent3 = new Vector3( tangent.x, tangent.y, tangent.z );
            Gizmos.color = Color.green;
            Gizmos.DrawLine( posOS, posOS + normal * 0.2f );
            Gizmos.color = Color.red;
            Gizmos.DrawLine( posOS, posOS + tangent3 * 0.2f );
        }        
    }

}

} 
