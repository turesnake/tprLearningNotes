using System.Collections.Generic;
using UnityEngine;


public class ContainsInTriangles
{

    /*
        Check the point is inside polygons.

        判断一个点 是否在一个 mesh 所属的所有 三角面内;


        原为 live2d - CubismRaycaster.cs - ContainsInTriangles()

    */
    private bool ContainsInTriangles(Mesh mesh, Vector3 inputPosition)
    {
        for (var i = 0; i < mesh.triangles.Length; i+=3)
        {
            var vertexPositionA = mesh.vertices[mesh.triangles[i]];
            var vertexPositionB = mesh.vertices[mesh.triangles[i + 1]];
            var vertexPositionC = mesh.vertices[mesh.triangles[i + 2]];

            var crossProduct1 =
                (vertexPositionB.x - vertexPositionA.x) * (inputPosition.y - vertexPositionB.y) -
                (vertexPositionB.y - vertexPositionA.y) * (inputPosition.x - vertexPositionB.x);
            var crossProduct2 =
                (vertexPositionC.x - vertexPositionB.x) * (inputPosition.y - vertexPositionC.y) -
                (vertexPositionC.y - vertexPositionB.y) * (inputPosition.x - vertexPositionC.x);
            var crossProduct3 =
                (vertexPositionA.x - vertexPositionC.x) * (inputPosition.y - vertexPositionA.y) -
                (vertexPositionA.y - vertexPositionC.y) * (inputPosition.x - vertexPositionA.x);

            if ((crossProduct1 > 0 && crossProduct2 > 0 && crossProduct3 > 0) ||
                (crossProduct1 < 0 && crossProduct2 < 0 && crossProduct3 < 0))
            {
                return true;
            }
        }
        return false;
    }


} 
