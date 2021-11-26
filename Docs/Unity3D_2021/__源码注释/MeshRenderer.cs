#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     Renders meshes inserted by the MeshFilter or TextMesh.
    [NativeHeaderAttribute("Runtime/Graphics/Mesh/MeshRenderer.h")]
    public class MeshRenderer : Renderer//MeshRenderer__RR
    {
        public MeshRenderer();

        //
        // 摘要:
        //     Vertex attributes in this mesh will override or add attributes of the primary
        //     mesh in the MeshRenderer.
        public Mesh additionalVertexStreams { get; set; }
        //
        // 摘要:
        //     Vertex attributes in this mesh will override or add attributes of the primary
        //     mesh and the additionalVertexStreams in the MeshRenderer.
        public Mesh enlightenVertexStream { get; set; }
        //
        // 摘要:
        //     Index of the first sub-mesh to use from the Mesh associated with this MeshRenderer
        //     (Read Only).
        public int subMeshStartIndex { get; }
        //
        // 摘要:
        //     Specifies the relative lightmap resolution of this object. (Editor only)
        public float scaleInLightmap { get; set; }
        //
        // 摘要:
        //     Determines how the object will receive global illumination. (Editor only)
        public ReceiveGI receiveGI { get; set; }
        //
        // 摘要:
        //     When enabled, seams in baked lightmaps will get smoothed. (Editor only)
        public bool stitchLightmapSeams { get; set; }
    }
}

