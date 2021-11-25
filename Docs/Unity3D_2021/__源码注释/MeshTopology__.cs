
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{

    /*
        摘要:
        Topology of Mesh faces.


        Normally meshes are composed of triangles (three vertex indices per face), 

        但有时你希望绘制一些复杂的东西, 比如用 lines 和 points 构成的;
        使用这种 topology 去创建 mesh, 并用它进行渲染 通常是最有效的方法。

    */
    public enum MeshTopology
    {
      
        //     Mesh is made from triangles.
        //   Each three indices in the mesh index buffer form a triangular face.
        Triangles = 0,


        /*
            Mesh is made from quads.

            Each four indices in the mesh index buffer form a quadrangular face. 
            注意, 在有些平台,  quad 是被模仿出来的, 所以改用 三角形是更高效的方法;
            Unless you really need quads, 
            for example if using DirectX 11 tessellation shaders that operate on quad patches.
        */
        Quads = 2,
        
        //     Mesh is made from lines.
        //   Each two indices in the mesh index buffer form a line.
        Lines = 3,
       
        //     Mesh is a line strip.  "带"
        //   First two indices form a line, and then each new index connects a new vertex to the existing line strip.
        LineStrip = 4,
        
        //     Mesh is made from points.
        //   In most of use cases, mesh index buffer should be "identity": 0, 1, 2, 3, 4, 5, ...
        Points = 5
    }
}

