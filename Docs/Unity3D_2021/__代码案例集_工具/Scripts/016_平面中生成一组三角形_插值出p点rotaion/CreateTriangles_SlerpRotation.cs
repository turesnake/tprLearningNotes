using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GK;





/*
    在本节点 子层, 放置一堆 tf, 它们在 xz平面上; 代表 vertex, 每个都有自己的 rotation;
    点 p 是个运动的点;

    程序运行后, 通过 Delaunay 插件生成一组最优的 三角形; (相互邻接)

    -1- 基于三角形内 重心三元插值, 计算出 背景 rotation
    -2- 基于 p 最近点的 二元插值, 计算出 临近 rotation

    综合上述两个信息, 计算出 p 的 rotation;
*/
public class CreateTriangles_SlerpRotation : MonoBehaviour
{
    public class Triangle 
    {
        public int idx;
        public int ia,ib,ic; // 三个顶点的 idx; 逆时针;
        public Vector3 centerPos; // 重心点
    }


    public class Vertex 
    {
        public Transform tf;
        public float radius;
        public HashSet<int> nearbyVertexIdxs = new HashSet<int>(); // 相邻的 vertex idx;
    }

    // =============================
    public Transform Ptf; // 移动点

    public List<Vertex> vertexs = new List<Vertex>();
    public List<Triangle> triangles = new List<Triangle>();
    List<int> triangleIdxs;

    DelaunayCalculator delaunayCalculator = new DelaunayCalculator();

    int triangleNum;
    int closestVertexIdx;
    bool isOpen2 = true;
    

    void Start()
    {
        Debug.Assert(Ptf!=null);
        // 收集 vertex:
        List<Vector2> pos2es = new List<Vector2>();
        var nodes = transform.GetComponentsInChildren<Node>(false);
        foreach( var e in nodes ) 
        {
            var tf = e.transform;
            var pos = tf.position;
            pos.y = 0f;

            // !!! 要检查 pos 是否重合...
            tf.position = pos;
            vertexs.Add( new Vertex(){tf=tf, radius=0.01f} );
            pos2es.Add( new Vector2( pos.x, pos.z ) );
        }


        // 生成 三角形信息;  逆时针三角形
        DelaunayTriangulation ret = delaunayCalculator.CalculateTriangulation( pos2es );
        triangleIdxs = ret.Triangles;
        Debug.Assert(triangleIdxs.Count%3==0);
        triangleNum = triangleIdxs.Count/3;
        Print_TriangleIdxs();

    
        // 记录 每个三角形的信息:
        for( int trii=0; trii<triangleNum; trii++ )
        {
            // 三个顶点 idx
            int ia = triangleIdxs[trii*3+0];
            int ib = triangleIdxs[trii*3+1];
            int ic = triangleIdxs[trii*3+2];
            Vector3 centerPos = (vertexs[ia].tf.position + vertexs[ib].tf.position + vertexs[ic].tf.position)/3f;
            var newTri = new Triangle(){ idx = trii, ia=ia, ib=ib, ic=ic, centerPos=centerPos };
            triangles.Add( newTri );

            vertexs[ia].nearbyVertexIdxs.Add( ib ); // 允许重复
            vertexs[ia].nearbyVertexIdxs.Add( ic ); // 允许重复
            vertexs[ib].nearbyVertexIdxs.Add( ia ); // 允许重复
            vertexs[ib].nearbyVertexIdxs.Add( ic ); // 允许重复
            vertexs[ic].nearbyVertexIdxs.Add( ia ); // 允许重复
            vertexs[ic].nearbyVertexIdxs.Add( ib ); // 允许重复
        }

        // 计算每个顶点的 有效半径:
        for( int i=0; i<vertexs.Count; i++ )
        {
            Vector3 vtPos = vertexs[i].tf.position;
            float minLen = 9999999f;
            float totalLen = 0f;
            foreach( var vtIdx in vertexs[i].nearbyVertexIdxs ) 
            {
                float len = (vertexs[vtIdx].tf.position - vtPos).magnitude;
                totalLen += len;
                minLen = Mathf.Min( minLen, len );
            }
            vertexs[i].radius = minLen * 0.5f;
        }

        // 找出最近的 vertex:
        closestVertexIdx = -1;
        float closestLen = 9999999f;
        for( int i=0; i<vertexs.Count; i++ )
        {
            float len = (Ptf.position-vertexs[i].tf.position).magnitude;
            if( len < closestLen  ) 
            {
                closestLen = len;
                closestVertexIdx = i;
            }
        }
        Debug.Assert( closestVertexIdx >= 0 );

        // 用最近点的 rotaion 来赋值 Ptf;
        Ptf.rotation = vertexs[closestVertexIdx].tf.rotation;
    }

    
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Alpha2) )
        {
            isOpen2 = ! isOpen2;
            print("isOpen2 = " + isOpen2);
        }

        closestVertexIdx = -1;
        float closestLen = 9999999f;
        for( int i=0; i<vertexs.Count; i++ )
        {
            float len = (Ptf.position-vertexs[i].tf.position).magnitude;
            if( len < closestLen  ) 
            {
                closestLen = len;
                closestVertexIdx = i;
            }
        }
        Debug.Assert( closestVertexIdx >= 0 );

        // ======
        for( int i=0; i<triangleNum; i++ )
        {
            var tri = triangles[i];
            int ia = tri.ia;
            int ib = tri.ib;
            int ic = tri.ic;
            if( IsInsideTriangle( vertexs[ia].tf.position, vertexs[ib].tf.position, vertexs[ic].tf.position, Ptf.position ) )
            {
                // 背景 roataion:
                Quaternion backgroundRotation =RotationLerp(    vertexs[ia].tf.rotation, vertexs[ib].tf.rotation, vertexs[ic].tf.rotation, 
                                                vertexs[ia].tf.position, vertexs[ib].tf.position, vertexs[ic].tf.position, Ptf.position);

                // 让 背景 rot 的影响变得迟钝; 当 p 快速穿过时, 不会因立即响应而出现强烈波动; 当 p 停留在某地后, 会慢慢更上 backgroundRotation;
                Quaternion rot = Quaternion.Slerp( Ptf.rotation, backgroundRotation, 0.1f );

                // 当 p 足够接近某个 vt 时, 会受到它的强烈影响;
                if(isOpen2)
                {
                    var closestVertex = vertexs[closestVertexIdx];
                    float t = 1f - Mathf.Clamp01((Ptf.position-closestVertex.tf.position).magnitude / closestVertex.radius);
                    rot = Quaternion.Slerp( rot, closestVertex.tf.rotation, t );
                }
                Ptf.rotation = rot;
                break;
            }
        }
    }


    // ===================== 三角形内检测 ====================
    
    // 假定: 4点共面, abc一定是个三角形; 
    // 判断一个点 是否在一个三角形内; (等号: p在边线上也返回 true)
    bool IsInsideTriangle( Vector3 a_, Vector3 b_, Vector3 c_, Vector3 p_ )
    {
        float crossABAP = CrossProduct2D( b_-a_, p_-a_ );  
        float crossBCBP = CrossProduct2D( c_-b_, p_-b_ );  
        float crossCACP = CrossProduct2D( a_-c_, p_-c_ );
        // Check if all cross products have the same sign  
        bool hasSameSign = (crossABAP >= 0 && crossBCBP >= 0 && crossCACP >= 0) ||  
                           (crossABAP <= 0 && crossBCBP <= 0 && crossCACP <= 0);  
        return hasSameSign;
    }
    float CrossProduct2D(Vector3 v1, Vector3 v2)  
    {  
        // Calculate the 2D cross product (z-component only)  
        return v1.x * v2.z - v1.z * v2.x;  
    }  


    // ===================== 旋转值 插值 ====================   
 
    Quaternion RotationLerp( Quaternion ra_, Quaternion rb_, Quaternion rc_, Vector3 a_, Vector3 b_, Vector3 c_, Vector3 p_ )  
    {
        // ======== 计算 Barycentric Coordinates: wa, wb, wc: ========
        float area0 = Area( a_, b_, c_ );
        float areaABP = Area( a_, b_, p_ );
        float areaBCP = Area( b_, c_, p_ );
        float areaCAP = Area( c_, a_, p_ );
        float wa = areaBCP / area0;
        float wb = areaCAP / area0;
        float wc = areaABP / area0;

        // 这不是真正的 对称的 算法, 但它至少在 p穿越三角形边界时 不会抖动...
        Quaternion rAB  = Quaternion.Slerp( ra_, rb_,  wb / (wa + wb) ); 
        Quaternion rr   = Quaternion.Slerp( rAB, rc_,  wc ); 
        return rr;
    }
    float Area(Vector3 p1, Vector3 p2, Vector3 p3)  
    {  
        return Vector3.Cross(p2 - p1, p3 - p1).magnitude * 0.5f; 
    }  



    // ===================== debug ====================

    void Print_TriangleIdxs() 
    {
        print("=== triangleIdxs ===");
        for( int trii=0; trii<triangleNum; trii++ )
        {
            // 三角形三个顶点的 idx
            int ia = triangleIdxs[trii*3+0];
            int ib = triangleIdxs[trii*3+1];
            int ic = triangleIdxs[trii*3+2]; 
            string ss =  ia + ", " + ib + ", " + ic;
            print(ss);
        }
    }



    void OnDrawGizmos()  
    { 
        if( Application.isPlaying == false) 
        {
            return;
        }

        Gizmos.color = Color.white;
        for( int i=0; i<triangleNum; i++ )
        {
            var tri = triangles[i];
            Gizmos.color = Color.white;
            Gizmos.DrawLine( vertexs[tri.ia].tf.position, vertexs[tri.ib].tf.position ); 
            Gizmos.DrawLine( vertexs[tri.ib].tf.position, vertexs[tri.ic].tf.position ); 
            Gizmos.DrawLine( vertexs[tri.ia].tf.position, vertexs[tri.ic].tf.position ); 

            Gizmos.color = new Color( 0,0,0, 0.4f );
            Gizmos.DrawSphere( tri.centerPos, 0.03f );

        }

        Gizmos.color = new Color( 0,0,0, 0.2f );
        for( int i=0; i<vertexs.Count; i++ ) 
        {
            Gizmos.DrawSphere( vertexs[i].tf.position, vertexs[i].radius );
        }

        if(closestVertexIdx >= 0) 
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere( vertexs[closestVertexIdx].tf.position, 0.03f );
        }
    }
    
}



