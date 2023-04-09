#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     Contains information about a single sub-mesh of a Mesh.
    public struct SubMeshDescriptor
    {
        //
        // 摘要:
        //     Create a submesh descriptor.
        //
        // 参数:
        //   indexStart:
        //     Initial value for indexStart field.
        //
        //   indexCount:
        //     Initial value for indexCount field.
        //
        //   topology:
        //     Initial value for topology field.
        public SubMeshDescriptor(int indexStart, int indexCount, MeshTopology topology = MeshTopology.Triangles);

        //
        // 摘要:
        //     Bounding box of vertices in local space.
        public Bounds bounds { readonly get; set; }
        //
        // 摘要:
        //     Face topology of this sub-mesh.
        public MeshTopology topology { readonly get; set; }
        //
        // 摘要:
        //     Starting point inside the whole Mesh index buffer where the face index data is
        //     found.
        public int indexStart { readonly get; set; }
        //
        // 摘要:
        //     Index count for this sub-mesh face data.
        public int indexCount { readonly get; set; }
        //
        // 摘要:
        //     Offset that is added to each value in the index buffer, to compute the final
        //     vertex index.
        public int baseVertex { readonly get; set; }
        //
        // 摘要:
        //     First vertex in the index buffer for this sub-mesh.
        public int firstVertex { readonly get; set; }
        //
        // 摘要:
        //     Number of vertices used by the index buffer of this sub-mesh.
        public int vertexCount { readonly get; set; }

        public override string ToString();
    }
}