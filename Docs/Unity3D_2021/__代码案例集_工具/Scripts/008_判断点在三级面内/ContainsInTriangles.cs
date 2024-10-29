using System.Collections.Generic;
using UnityEngine;


public class ContainsInTriangles
{

    

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



    // ==========================================================

    /*
        Check the point is inside polygons.
        判断一个点 是否在一个 mesh 所属的所有 三角面内;
        原为 live2d - CubismRaycaster.cs - ContainsInTriangles()
        似乎没有验证它的有效性
    */
    private bool ContainsInTriangles(Mesh mesh, Vector3 inputPosition)
    {
        for (var i = 0; i < mesh.triangles.Length; i+=3)
        {
            var vertexPosA = mesh.vertices[mesh.triangles[i]];
            var vertexPosB = mesh.vertices[mesh.triangles[i + 1]];
            var vertexPosC = mesh.vertices[mesh.triangles[i + 2]];

            var crossProduct1 =
                (vertexPosB.x - vertexPosA.x) * (inputPosition.y - vertexPosB.y) -
                (vertexPosB.y - vertexPosA.y) * (inputPosition.x - vertexPosB.x);
            var crossProduct2 =
                (vertexPosC.x - vertexPosB.x) * (inputPosition.y - vertexPosC.y) -
                (vertexPosC.y - vertexPosB.y) * (inputPosition.x - vertexPosC.x);
            var crossProduct3 =
                (vertexPosA.x - vertexPosC.x) * (inputPosition.y - vertexPosA.y) -
                (vertexPosA.y - vertexPosC.y) * (inputPosition.x - vertexPosA.x);

            if ((crossProduct1 > 0 && crossProduct2 > 0 && crossProduct3 > 0) ||
                (crossProduct1 < 0 && crossProduct2 < 0 && crossProduct3 < 0))
            {
                return true;
            }
        }
        return false;
    }


} 
