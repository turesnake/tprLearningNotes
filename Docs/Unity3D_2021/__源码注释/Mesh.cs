#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Internal;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     A class that allows you to create or modify meshes.
    [NativeHeaderAttribute("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
    [RequiredByNativeCodeAttribute]
    public sealed class Mesh : Object//Mesh__RR
    {
        //
        // 摘要:
        //     Creates an empty Mesh.
        [RequiredByNativeCodeAttribute]
        public Mesh();


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property Mesh.uv1 has been deprecated. Use Mesh.uv2 instead (UnityUpgradable) -> uv2", true)]
        public Vector2[] uv1 { get; set; }
        */

        //
        // 摘要:
        //     Format of the mesh index buffer data.
        public IndexFormat indexFormat { get; set; }
        //
        // 摘要:
        //     Gets the number of vertex buffers present in the Mesh. (Read Only)
        public int vertexBufferCount { get; }
        //
        // 摘要:
        //     Returns BlendShape count on this mesh.
        public int blendShapeCount { get; }
        //
        // 摘要:
        //     The bind poses. The bind pose at each index refers to the bone with the same
        //     index.
        [NativeNameAttribute("BindPosesFromScript")]
        public Matrix4x4[] bindposes { get; set; }
        //
        // 摘要:
        //     Returns true if the Mesh is read/write enabled, or false if it is not.
        public bool isReadable { get; }
        //
        // 摘要:
        //     Returns the number of vertices in the Mesh (Read Only).
        public int vertexCount { get; }
        //
        // 摘要:
        //     The number of sub-meshes inside the Mesh object.
        public int subMeshCount { get; set; }
        //
        // 摘要:
        //     The bounding volume of the Mesh.
        public Bounds bounds { get; set; }
        //
        // 摘要:
        //     Returns a copy of the vertex positions or assigns a new vertex positions array.
        public Vector3[] vertices { get; set; }
        //
        // 摘要:
        //     The normals of the Mesh.
        public Vector3[] normals { get; set; }
        //
        // 摘要:
        //     The tangents of the Mesh.
        public Vector4[] tangents { get; set; }
        //
        // 摘要:
        //     The base texture coordinates of the Mesh.
        public Vector2[] uv { get; set; }
        //
        // 摘要:
        //     The second texture coordinate set of the mesh, if present.
        public Vector2[] uv2 { get; set; }
        //
        // 摘要:
        //     The third texture coordinate set of the mesh, if present.
        public Vector2[] uv3 { get; set; }
        //
        // 摘要:
        //     The fourth texture coordinate set of the mesh, if present.
        public Vector2[] uv4 { get; set; }
        //
        // 摘要:
        //     The fifth texture coordinate set of the mesh, if present.
        public Vector2[] uv5 { get; set; }
        //
        // 摘要:
        //     The sixth texture coordinate set of the mesh, if present.
        public Vector2[] uv6 { get; set; }
        //
        // 摘要:
        //     The seventh texture coordinate set of the mesh, if present.
        public Vector2[] uv7 { get; set; }
        //
        // 摘要:
        //     The eighth texture coordinate set of the mesh, if present.
        public Vector2[] uv8 { get; set; }
        //
        // 摘要:
        //     Vertex colors of the Mesh.
        public Color[] colors { get; set; }
        //
        // 摘要:
        //     Vertex colors of the Mesh.
        public Color32[] colors32 { get; set; }
        //
        // 摘要:
        //     Returns the number of vertex attributes that the mesh has. (Read Only)
        public int vertexAttributeCount { get; }
        //
        // 摘要:
        //     An array containing all triangles in the Mesh.
        public int[] triangles { get; set; }

        //
        // 摘要:
        //     The BoneWeight for each vertex in the Mesh, which represents 4 bones per vertex.
        public BoneWeight[] boneWeights { get; set; }


        
        //
        // 摘要:
        //     Gets a snapshot of Mesh data for read-only access.
        //
        // 参数:
        //   mesh:
        //     The input mesh.
        //
        //   meshes:
        //     The input meshes.
        //
        // 返回结果:
        //     Returns a MeshDataArray containing read-only MeshData structs. See Mesh.MeshDataArray
        //     and Mesh.MeshData.
        public static MeshDataArray AcquireReadOnlyMeshData(Mesh[] meshes);
        public static MeshDataArray AcquireReadOnlyMeshData(List<Mesh> meshes);
        public static MeshDataArray AcquireReadOnlyMeshData(Mesh mesh);



        //
        // 摘要:
        //     Allocates data structures for Mesh creation using C# Jobs.
        //
        // 参数:
        //   meshCount:
        //     The amount of meshes that will be created.
        //
        // 返回结果:
        //     Returns a MeshDataArray containing writeable MeshData structs. See Mesh.MeshDataArray
        //     and Mesh.MeshData.
        public static MeshDataArray AllocateWritableMeshData(int meshCount);


        public static void ApplyAndDisposeWritableMeshData(MeshDataArray data, Mesh[] meshes, MeshUpdateFlags flags = MeshUpdateFlags.Default);
        public static void ApplyAndDisposeWritableMeshData(MeshDataArray data, Mesh mesh, MeshUpdateFlags flags = MeshUpdateFlags.Default);
        public static void ApplyAndDisposeWritableMeshData(MeshDataArray data, List<Mesh> meshes, MeshUpdateFlags flags = MeshUpdateFlags.Default);
        
        
        //
        // 摘要:
        //     Adds a new blend shape frame.
        //
        // 参数:
        //   shapeName:
        //     Name of the blend shape to add a frame to.
        //
        //   frameWeight:
        //     Weight for the frame being added.
        //
        //   deltaVertices:
        //     Delta vertices for the frame being added.
        //
        //   deltaNormals:
        //     Delta normals for the frame being added.
        //
        //   deltaTangents:
        //     Delta tangents for the frame being added.
        [FreeFunctionAttribute(Name = "AddBlendShapeFrameFromScript", HasExplicitThis = true, ThrowsException = true)]
        public void AddBlendShapeFrame(string shapeName, float frameWeight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents);
       
       

        //
        // 摘要:
        //     Clears all vertex data and all triangle indices.
        //
        // 参数:
        //   keepVertexLayout:
        //     True if the existing Mesh data layout should be preserved.
        public void Clear([Internal.DefaultValue("true")] bool keepVertexLayout);
        [ExcludeFromDocs]public void Clear();


        //
        // 摘要:
        //     Clears all blend shapes from Mesh.
        [FreeFunctionAttribute(Name = "MeshScripting::ClearBlendShapes", HasExplicitThis = true)]
        public void ClearBlendShapes();


        //
        // 摘要:
        //     Combines several Meshes into this Mesh.
        //
        // 参数:
        //   combine:
        //     Descriptions of the Meshes to combine.
        //
        //   mergeSubMeshes:
        //     Defines whether Meshes should be combined into a single sub-mesh.
        //
        //   useMatrices:
        //     Defines whether the transforms supplied in the CombineInstance array should be
        //     used or ignored.
        //
        //   hasLightmapData:
        public void CombineMeshes(
            CombineInstance[] combine, 
            [Internal.DefaultValue("true")] bool mergeSubMeshes, 
            [Internal.DefaultValue("true")] bool useMatrices, 
            [Internal.DefaultValue("false")] bool hasLightmapData);
        [ExcludeFromDocs]public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices);
        [ExcludeFromDocs]public void CombineMeshes(CombineInstance[] combine);
        [ExcludeFromDocs]public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes);
        
        
        //
        // 摘要:
        //     Gets the bone weights for the Mesh.
        //
        // 返回结果:
        //     Returns all non-zero bone weights for the Mesh, in vertex index order.
        public NativeArray<BoneWeight1> GetAllBoneWeights();

        
        /*
            Gets the base vertex index of the given sub-mesh.

            The base vertex can be used to achieve meshes that are larger than 65535 vertices while using 16 bit index buffers, 
            as long as each sub-mesh fits within its own 65535 vertex area. Alternatively, 32 bit index buffers can be used via indexFormat.
            ---
            只要每个 submesh 使用自己的 65535 个顶点空间, (每个顶点的 index 使用 16-bits 来存储); 然后再搭配使用 GetBaseVertex, 就能仅使用 16-bits 为单位,
            来存储 远远多于 65535 个的 总顶点数量;
            
            参数:
            submesh:
                The sub-mesh index. See subMeshCount.
            
            返回结果:
                The offset applied to all vertex indices of this sub-mesh.
        */
        public uint GetBaseVertex(int submesh);


        public void GetBindposes(List<Matrix4x4> bindposes);

        //
        // 摘要:
        //     Returns the frame count for a blend shape.
        //
        // 参数:
        //   shapeIndex:
        //     The shape index to get frame count from.
        [FreeFunctionAttribute(Name = "MeshScripting::GetBlendShapeFrameCount", HasExplicitThis = true, ThrowsException = true)]
        public int GetBlendShapeFrameCount(int shapeIndex);

        //
        // 摘要:
        //     Retreives deltaVertices, deltaNormals and deltaTangents of a blend shape frame.
        //
        // 参数:
        //   shapeIndex:
        //     The shape index of the frame.
        //
        //   frameIndex:
        //     The frame index to get the weight from.
        //
        //   deltaVertices:
        //     Delta vertices output array for the frame being retreived.
        //
        //   deltaNormals:
        //     Delta normals output array for the frame being retreived.
        //
        //   deltaTangents:
        //     Delta tangents output array for the frame being retreived.
        [FreeFunctionAttribute(Name = "GetBlendShapeFrameVerticesFromScript", HasExplicitThis = true, ThrowsException = true)]
        public void GetBlendShapeFrameVertices(int shapeIndex, int frameIndex, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents);
        
        //
        // 摘要:
        //     Returns the weight of a blend shape frame.
        //
        // 参数:
        //   shapeIndex:
        //     The shape index of the frame.
        //
        //   frameIndex:
        //     The frame index to get the weight from.
        [FreeFunctionAttribute(Name = "MeshScripting::GetBlendShapeFrameWeight", HasExplicitThis = true, ThrowsException = true)]
        public float GetBlendShapeFrameWeight(int shapeIndex, int frameIndex);

        //
        // 摘要:
        //     Returns index of BlendShape by given name.
        //
        // 参数:
        //   blendShapeName:
        [FreeFunctionAttribute(Name = "MeshScripting::GetBlendShapeIndex", HasExplicitThis = true, ThrowsException = true)]
        public int GetBlendShapeIndex(string blendShapeName);

        //
        // 摘要:
        //     Returns name of BlendShape by given index.
        //
        // 参数:
        //   shapeIndex:
        [FreeFunctionAttribute(Name = "MeshScripting::GetBlendShapeName", HasExplicitThis = true, ThrowsException = true)]
        public string GetBlendShapeName(int shapeIndex);


        //
        // 摘要:
        //     The number of non-zero bone weights for each vertex.
        //
        // 返回结果:
        //     Returns the number of non-zero bone weights for each vertex.
        public NativeArray<byte> GetBonesPerVertex();

        public void GetBoneWeights(List<BoneWeight> boneWeights);


        public void GetColors(List<Color> colors);
        public void GetColors(List<Color32> colors);

        //
        // 摘要:
        //     Gets the index count of the given sub-mesh.  --  顶点个数
        //     
        // 参数:
        //   submesh:
        public uint GetIndexCount(int submesh);

        /*
            Gets the starting index location within the Mesh's index buffer, for the given sub-mesh.

            得到 目标submesh的 第一个顶点在 index buffer 中的下标值;

            index buffer: 为每个顶点分配一个元素, 此元素记录 目标顶点在 vertex buffer 中的 首字节下标值; (大概)
            
            参数:
            submesh:
        */
        public uint GetIndexStart(int submesh);


        //
        // 摘要:
        //     Fetches the index list for the specified sub-mesh.
        //
        // 参数:
        //   submesh:
        //     The sub-mesh index. See subMeshCount.
        //
        //   applyBaseVertex:
        //     True (default value) will apply base vertex offset to returned indices.
        //
        // 返回结果:
        //     Array with face indices.
        [ExcludeFromDocs]
        public int[] GetIndices(int submesh);
        public void GetIndices(List<int> indices, int submesh, [Internal.DefaultValue("true")] bool applyBaseVertex);
        public void GetIndices(List<ushort> indices, int submesh, bool applyBaseVertex = true);
        public int[] GetIndices(int submesh, [Internal.DefaultValue("true")] bool applyBaseVertex);
        [ExcludeFromDocs]public void GetIndices(List<int> indices, int submesh);


        //
        // 摘要:
        //     Retrieves a native (underlying graphics API) pointer to the index buffer.
        //
        // 返回结果:
        //     Pointer to the underlying graphics API index buffer.
        [FreeFunctionAttribute(Name = "MeshScripting::GetNativeIndexBufferPtr", HasExplicitThis = true)]
        public IntPtr GetNativeIndexBufferPtr();

        //
        // 摘要:
        //     Retrieves a native (underlying graphics API) pointer to the vertex buffer.
        //
        // 参数:
        //   bufferIndex:
        //     Which vertex buffer to get (some Meshes might have more than one). See vertexBufferCount.
        //
        //   index:
        //
        // 返回结果:
        //     Pointer to the underlying graphics API vertex buffer.
        [FreeFunctionAttribute(Name = "MeshScripting::GetNativeVertexBufferPtr", HasExplicitThis = true)]
        [NativeThrowsAttribute]
        public IntPtr GetNativeVertexBufferPtr(int index);

        public void GetNormals(List<Vector3> normals);

        //
        // 摘要:
        //     Get information about a sub-mesh of the Mesh.
        //
        // 参数:
        //   index:
        //     Sub-mesh index. See subMeshCount. Out of range indices throw an exception.
        //
        // 返回结果:
        //     Sub-mesh data.
        [FreeFunctionAttribute("MeshScripting::GetSubMesh", HasExplicitThis = true, ThrowsException = true)]
        public SubMeshDescriptor GetSubMesh(int index);

        public void GetTangents(List<Vector4> tangents);

        //
        // 摘要:
        //     Gets the topology of a sub-mesh.
        //
        // 参数:
        //   submesh:
        public MeshTopology GetTopology(int submesh);

        //
        // 摘要:
        //     Fetches the triangle list for the specified sub-mesh on this object.
        //
        // 参数:
        //   triangles:
        //     A list of vertex indices to populate.
        //
        //   submesh:
        //     The sub-mesh index. See subMeshCount.
        //
        //   applyBaseVertex:
        //     True (default value) will apply base vertex offset to returned indices.
        public int[] GetTriangles(int submesh, [Internal.DefaultValue("true")] bool applyBaseVertex);
        public int[] GetTriangles(int submesh);
        public void GetTriangles(List<int> triangles, int submesh);
        public void GetTriangles(List<int> triangles, int submesh, [Internal.DefaultValue("true")] bool applyBaseVertex);
        public void GetTriangles(List<ushort> triangles, int submesh, bool applyBaseVertex = true);


        //
        // 摘要:
        //     The UV distribution metric can be used to calculate the desired mipmap level
        //     based on the position of the camera.
        //
        // 参数:
        //   uvSetIndex:
        //     UV set index to return the UV distibution metric for. 0 for first.
        //
        // 返回结果:
        //     Average of triangle area / uv area.
        [NativeMethodAttribute("GetMeshMetric")]
        public float GetUVDistributionMetric(int uvSetIndex);


        public void GetUVs(int channel, List<Vector4> uvs);
        public void GetUVs(int channel, List<Vector3> uvs);
        public void GetUVs(int channel, List<Vector2> uvs);


        //
        // 摘要:
        //     Returns information about a vertex attribute based on its index.
        //
        // 参数:
        //   index:
        //     The vertex attribute index (0 to vertexAttributeCount-1).
        //
        // 返回结果:
        //     Information about the vertex attribute.
        [FreeFunctionAttribute(Name = "MeshScripting::GetVertexAttributeByIndex", HasExplicitThis = true, ThrowsException = true)]
        public VertexAttributeDescriptor GetVertexAttribute(int index);


        //
        // 摘要:
        //     Get dimension of a specific vertex data attribute on this Mesh.
        //
        // 参数:
        //   attr:
        //     Vertex data attribute to check for.
        //
        // 返回结果:
        //     Dimensionality of the data attribute, or zero if it is not present.
        [FreeFunctionAttribute(Name = "MeshScripting::GetChannelDimension", HasExplicitThis = true)]
        public int GetVertexAttributeDimension(VertexAttribute attr);


        //
        // 摘要:
        //     Get format of a specific vertex data attribute on this Mesh.
        //
        // 参数:
        //   attr:
        //     Vertex data attribute to check for.
        //
        // 返回结果:
        //     Format of the data attribute.
        [FreeFunctionAttribute(Name = "MeshScripting::GetChannelFormat", HasExplicitThis = true)]
        public VertexAttributeFormat GetVertexAttributeFormat(VertexAttribute attr);


        
        //
        // 摘要:
        //     Get information about vertex attributes of a Mesh, without memory allocations.
        //
        // 参数:
        //   attributes:
        //     Collection of vertex attributes to receive the results.
        //
        // 返回结果:
        //     The number of vertex attributes returned in the attributes container.
        public int GetVertexAttributes(VertexAttributeDescriptor[] attributes);
        public int GetVertexAttributes(List<VertexAttributeDescriptor> attributes);
        //
        // 摘要:
        //     Get information about vertex attributes of a Mesh.
        //
        // 返回结果:
        //     Array of vertex attribute information.
        public VertexAttributeDescriptor[] GetVertexAttributes();


        public void GetVertices(List<Vector3> vertices);
        //
        // 摘要:
        //     Checks if a specific vertex data attribute exists on this Mesh.
        //
        // 参数:
        //   attr:
        //     Vertex data attribute to check for.
        //
        // 返回结果:
        //     Returns true if the data attribute is present in the mesh.
        [FreeFunctionAttribute(Name = "MeshScripting::HasChannel", HasExplicitThis = true)]
        public bool HasVertexAttribute(VertexAttribute attr);


        //
        // 摘要:
        //     Optimize mesh for frequent updates.
        public void MarkDynamic();

        //
        // 摘要:
        //     Notify Renderer components of mesh geometry change.
        [NativeMethodAttribute("MarkModified")]
        public void MarkModified();

        //
        // 摘要:
        //     Optimizes the Mesh data to improve rendering performance.
        public void Optimize();

        //
        // 摘要:
        //     Optimizes the geometry of the Mesh to improve rendering performance.
        public void OptimizeIndexBuffers();

        //
        // 摘要:
        //     Optimizes the vertices of the Mesh to improve rendering performance.
        public void OptimizeReorderVertexBuffer();

        

        //
        // 摘要:
        //     Recalculate the bounding volume of the Mesh from the vertices.
        //
        // 参数:
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void RecalculateBounds([Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        [ExcludeFromDocs]public void RecalculateBounds();


        
        //
        // 摘要:
        //     Recalculates the normals of the Mesh from the triangles and vertices.
        //
        // 参数:
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void RecalculateNormals([Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        [ExcludeFromDocs]public void RecalculateNormals();

        //
        // 摘要:
        //     Recalculates the tangents of the Mesh from the normals and texture coordinates.
        //
        // 参数:
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void RecalculateTangents([Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        [ExcludeFromDocs]public void RecalculateTangents();


        //
        // 摘要:
        //     Recalculates the UV distribution metric of the Mesh from the vertices and uv
        //     coordinates.
        //
        // 参数:
        //   uvSetIndex:
        //     The UV set index to set the UV distibution metric for. Use 0 for first index.
        //
        //   uvAreaThreshold:
        //     The minimum UV area to consider. The default value is 1e-9f.
        public void RecalculateUVDistributionMetric(int uvSetIndex, float uvAreaThreshold = 1E-09F);
        public void RecalculateUVDistributionMetrics(float uvAreaThreshold = 1E-09F);


        public void SetBoneWeights(NativeArray<byte> bonesPerVertex, NativeArray<BoneWeight1> weights);


        //
        // 摘要:
        //     Sets the per-vertex colors of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inColors:
        //     Per-vertex colors.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetColors(Color[] inColors, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        [ExcludeFromDocs]
        public void SetColors(List<Color> inColors, int start, int length);
        public void SetColors(List<Color> inColors, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Set the per-vertex colors of the Mesh.
        //
        // 参数:
        //   inColors:
        //     Per-vertex colors.
        public void SetColors(Color[] inColors);
        //
        // 摘要:
        //     Sets the per-vertex colors of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inColors:
        //     Per-vertex colors.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        [ExcludeFromDocs]
        public void SetColors(Color[] inColors, int start, int length);
        public void SetColors(List<Color> inColors);
        public void SetColors(List<Color32> inColors);
        //
        // 摘要:
        //     Sets the per-vertex colors of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inColors:
        //     Per-vertex colors.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetColors(Color32[] inColors, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        [ExcludeFromDocs]
        public void SetColors(List<Color32> inColors, int start, int length);
        public void SetColors(List<Color32> inColors, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Set the per-vertex colors of the Mesh.
        //
        // 参数:
        //   inColors:
        //     Per-vertex colors.
        public void SetColors(Color32[] inColors);
        public void SetColors<T>(NativeArray<T> inColors, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct;
        public void SetColors<T>(NativeArray<T> inColors) where T : struct;



        //
        // 摘要:
        //     Sets the per-vertex colors of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inColors:
        //     Per-vertex colors.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        [ExcludeFromDocs]
        public void SetColors(Color32[] inColors, int start, int length);
        [ExcludeFromDocs]
        public void SetColors<T>(NativeArray<T> inColors, int start, int length) where T : struct;



        public void SetIndexBufferData<T>(NativeArray<T> data, int dataStart, int meshBufferStart, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct;
        public void SetIndexBufferData<T>(List<T> data, int dataStart, int meshBufferStart, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct;
        public void SetIndexBufferData<T>(T[] data, int dataStart, int meshBufferStart, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct;
        
        
        //
        // 摘要:
        //     Sets the index buffer size and format.
        //
        // 参数:
        //   indexCount:
        //     Size of index buffer.
        //
        //   format:
        //     Format of the indices.
        [FreeFunctionAttribute(Name = "MeshScripting::SetIndexBufferParams", HasExplicitThis = true)]
        public void SetIndexBufferParams(int indexCount, IndexFormat format);


        //
        // 摘要:
        //     Sets the index buffer for the sub-mesh.
        //
        // 参数:
        //   indices:
        //     The array of indices that define the mesh faces.
        //
        //   topology:
        //     The topology of the Mesh, e.g: Triangles, Lines, Quads, Points, etc. See MeshTopology.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the indices. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the indices.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all vertex indices.
        public void SetIndices(int[] indices, MeshTopology topology, int submesh, [Internal.DefaultValue("true")] bool calculateBounds, [Internal.DefaultValue("0")] int baseVertex);
        //
        // 摘要:
        //     Sets the index buffer for the sub-mesh.
        //
        // 参数:
        //   indices:
        //     The array of indices that define the mesh faces.
        //
        //   topology:
        //     The topology of the Mesh, e.g: Triangles, Lines, Quads, Points, etc. See MeshTopology.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the indices. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the indices.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all vertex indices.
        [ExcludeFromDocs]
        public void SetIndices(int[] indices, MeshTopology topology, int submesh, bool calculateBounds);
        //
        // 摘要:
        //     Sets the index buffer for the sub-mesh.
        //
        // 参数:
        //   indices:
        //     The array of indices that define the mesh faces.
        //
        //   topology:
        //     The topology of the Mesh, e.g: Triangles, Lines, Quads, Points, etc. See MeshTopology.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the indices. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the indices.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all vertex indices.
        [ExcludeFromDocs]
        public void SetIndices(int[] indices, MeshTopology topology, int submesh);
        //
        // 摘要:
        //     Sets the index buffer of a sub-mesh, using a part of the input array.
        //
        // 参数:
        //   indices:
        //     The array of indices that define the mesh faces.
        //
        //   indicesStart:
        //     Index of the first element to take from the input array.
        //
        //   indicesLength:
        //     Number of elements to take from the input array.
        //
        //   topology:
        //     The topology of the Mesh, e.g: Triangles, Lines, Quads, Points, etc. See MeshTopology.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the indices. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the indices.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all vertex indices.
        public void SetIndices(int[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0);
        public void SetIndices(List<ushort> indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0);
        public void SetIndices<T>(NativeArray<T> indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0) where T : struct;
        //
        // 摘要:
        //     Sets the index buffer of a sub-mesh, using a part of the input array.
        //
        // 参数:
        //   indices:
        //     The array of indices that define the mesh faces.
        //
        //   indicesStart:
        //     Index of the first element to take from the input array.
        //
        //   indicesLength:
        //     Number of elements to take from the input array.
        //
        //   topology:
        //     The topology of the Mesh, e.g: Triangles, Lines, Quads, Points, etc. See MeshTopology.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the indices. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the indices.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all vertex indices.
        public void SetIndices(ushort[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0);
        public void SetIndices<T>(NativeArray<T> indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0) where T : struct;
        public void SetIndices(List<int> indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0);
        public void SetIndices(List<int> indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0);
        public void SetIndices(List<ushort> indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0);
        //
        // 摘要:
        //     Sets the index buffer for the sub-mesh.
        //
        // 参数:
        //   indices:
        //     The array of indices that define the mesh faces.
        //
        //   topology:
        //     The topology of the Mesh, e.g: Triangles, Lines, Quads, Points, etc. See MeshTopology.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the indices. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the indices.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all vertex indices.
        public void SetIndices(ushort[] indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0);
        
        
        
        public void SetNormals<T>(NativeArray<T> inNormals, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct;
        [ExcludeFromDocs]
        public void SetNormals<T>(NativeArray<T> inNormals, int start, int length) where T : struct;
        //
        // 摘要:
        //     Sets the vertex normals of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inNormals:
        //     Per-vertex normals.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        [ExcludeFromDocs]
        public void SetNormals(Vector3[] inNormals, int start, int length);
        //
        // 摘要:
        //     Sets the vertex normals of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inNormals:
        //     Per-vertex normals.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetNormals(Vector3[] inNormals, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Set the normals of the Mesh.
        //
        // 参数:
        //   inNormals:
        //     Per-vertex normals.
        public void SetNormals(Vector3[] inNormals);
        public void SetNormals(List<Vector3> inNormals, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        [ExcludeFromDocs]
        public void SetNormals(List<Vector3> inNormals, int start, int length);
        public void SetNormals(List<Vector3> inNormals);
        public void SetNormals<T>(NativeArray<T> inNormals) where T : struct;
        //
        // 摘要:
        //     Sets the information about a sub-mesh of the Mesh.
        //
        // 参数:
        //   index:
        //     Sub-mesh index. See subMeshCount. Out of range indices throw an exception.
        //
        //   desc:
        //     Sub-mesh data.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        [FreeFunctionAttribute("MeshScripting::SetSubMesh", HasExplicitThis = true, ThrowsException = true)]
        public void SetSubMesh(int index, SubMeshDescriptor desc, MeshUpdateFlags flags = MeshUpdateFlags.Default);


        public void SetSubMeshes(List<SubMeshDescriptor> desc, int start, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default);
        //
        // 摘要:
        //     Sets information defining all sub-meshes in this Mesh, replacing any existing
        //     sub-meshes.
        //
        // 参数:
        //   desc:
        //     An array or list of sub-mesh data descriptors.
        //
        //   start:
        //     Index of the first element to take from the array or list in desc.
        //
        //   count:
        //     Number of elements to take from the array or list in desc.
        //
        //   flags:
        //     (Optional) Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetSubMeshes(SubMeshDescriptor[] desc, MeshUpdateFlags flags = MeshUpdateFlags.Default);
        //
        // 摘要:
        //     Sets information defining all sub-meshes in this Mesh, replacing any existing
        //     sub-meshes.
        //
        // 参数:
        //   desc:
        //     An array or list of sub-mesh data descriptors.
        //
        //   start:
        //     Index of the first element to take from the array or list in desc.
        //
        //   count:
        //     Number of elements to take from the array or list in desc.
        //
        //   flags:
        //     (Optional) Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetSubMeshes(SubMeshDescriptor[] desc, int start, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default);
        public void SetSubMeshes<T>(NativeArray<T> desc, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct;
        public void SetSubMeshes<T>(NativeArray<T> desc, int start, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct;
        public void SetSubMeshes(List<SubMeshDescriptor> desc, MeshUpdateFlags flags = MeshUpdateFlags.Default);
        [ExcludeFromDocs]
        public void SetTangents<T>(NativeArray<T> inTangents, int start, int length) where T : struct;
        public void SetTangents<T>(NativeArray<T> inTangents, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct;
        
        
        //
        // 摘要:
        //     Sets the tangents of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inTangents:
        //     Per-vertex tangents.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        [ExcludeFromDocs]
        public void SetTangents(Vector4[] inTangents, int start, int length);
        //
        // 摘要:
        //     Set the tangents of the Mesh.
        //
        // 参数:
        //   inTangents:
        //     Per-vertex tangents.
        public void SetTangents(Vector4[] inTangents);
        public void SetTangents(List<Vector4> inTangents, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        [ExcludeFromDocs]
        public void SetTangents(List<Vector4> inTangents, int start, int length);
        public void SetTangents(List<Vector4> inTangents);
        public void SetTangents<T>(NativeArray<T> inTangents) where T : struct;
        //
        // 摘要:
        //     Sets the tangents of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inTangents:
        //     Per-vertex tangents.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetTangents(Vector4[] inTangents, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Sets the triangle list for the sub-mesh.
        //
        // 参数:
        //   triangles:
        //     The list of indices that define the triangles.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the triangles. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the triangles.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all triangle vertex indices.
        [ExcludeFromDocs]
        public void SetTriangles(int[] triangles, int submesh, bool calculateBounds);
        public void SetTriangles(List<ushort> triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds = true, int baseVertex = 0);
        //
        // 摘要:
        //     Sets the triangle list for the sub-mesh.
        //
        // 参数:
        //   triangles:
        //     The list of indices that define the triangles.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the triangles. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the triangles.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all triangle vertex indices.
        [ExcludeFromDocs]
        public void SetTriangles(int[] triangles, int submesh);
        //
        // 摘要:
        //     Sets the triangle list for the sub-mesh.
        //
        // 参数:
        //   triangles:
        //     The list of indices that define the triangles.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the triangles. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the triangles.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all triangle vertex indices.
        public void SetTriangles(int[] triangles, int submesh, [Internal.DefaultValue("true")] bool calculateBounds, [Internal.DefaultValue("0")] int baseVertex);
        //
        // 摘要:
        //     Sets the triangle list of the Mesh, using a part of the input array.
        //
        // 参数:
        //   triangles:
        //     The list of indices that define the triangles.
        //
        //   trianglesStart:
        //     Index of the first element to take from the input array.
        //
        //   trianglesLength:
        //     Number of elements to take from the input array.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the triangles. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the triangles.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all triangle vertex indices.
        public void SetTriangles(int[] triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds = true, int baseVertex = 0);
        //
        // 摘要:
        //     Sets the triangle list for the sub-mesh.
        //
        // 参数:
        //   triangles:
        //     The list of indices that define the triangles.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the triangles. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the triangles.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all triangle vertex indices.
        public void SetTriangles(ushort[] triangles, int submesh, bool calculateBounds = true, int baseVertex = 0);
        //
        // 摘要:
        //     Sets the triangle list of the Mesh, using a part of the input array.
        //
        // 参数:
        //   triangles:
        //     The list of indices that define the triangles.
        //
        //   trianglesStart:
        //     Index of the first element to take from the input array.
        //
        //   trianglesLength:
        //     Number of elements to take from the input array.
        //
        //   submesh:
        //     The sub-mesh to modify.
        //
        //   calculateBounds:
        //     Calculate the bounding box of the Mesh after setting the triangles. This is done
        //     by default. Use false when you want to use the existing bounding box and reduce
        //     the CPU cost of setting the triangles.
        //
        //   baseVertex:
        //     Optional vertex offset that is added to all triangle vertex indices.
        public void SetTriangles(ushort[] triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds = true, int baseVertex = 0);
        [ExcludeFromDocs]
        public void SetTriangles(List<int> triangles, int submesh);
        public void SetTriangles(List<int> triangles, int submesh, [Internal.DefaultValue("true")] bool calculateBounds, [Internal.DefaultValue("0")] int baseVertex);
        [ExcludeFromDocs]
        public void SetTriangles(List<int> triangles, int submesh, bool calculateBounds);
        public void SetTriangles(List<int> triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds = true, int baseVertex = 0);
        public void SetTriangles(List<ushort> triangles, int submesh, bool calculateBounds = true, int baseVertex = 0);



        public void SetUVs<T>(int channel, NativeArray<T> uvs, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct;
        [ExcludeFromDocs]
        public void SetUVs<T>(int channel, NativeArray<T> uvs, int start, int length) where T : struct;
        public void SetUVs<T>(int channel, NativeArray<T> uvs) where T : struct;
        //
        // 摘要:
        //     Sets the UVs of the Mesh, using a part of the input array.
        //
        // 参数:
        //   channel:
        //     The UV channel, in [0..7] range.
        //
        //   uvs:
        //     UVs to set for the given index.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetUVs(int channel, Vector4[] uvs, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Sets the UVs of the Mesh, using a part of the input array.
        //
        // 参数:
        //   channel:
        //     The UV channel, in [0..7] range.
        //
        //   uvs:
        //     UVs to set for the given index.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        [ExcludeFromDocs]
        public void SetUVs(int channel, Vector4[] uvs, int start, int length);
        //
        // 摘要:
        //     Sets the UVs of the Mesh, using a part of the input array.
        //
        // 参数:
        //   channel:
        //     The UV channel, in [0..7] range.
        //
        //   uvs:
        //     UVs to set for the given index.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetUVs(int channel, Vector3[] uvs, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Sets the UVs of the Mesh, using a part of the input array.
        //
        // 参数:
        //   channel:
        //     The UV channel, in [0..7] range.
        //
        //   uvs:
        //     UVs to set for the given index.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        [ExcludeFromDocs]
        public void SetUVs(int channel, Vector3[] uvs, int start, int length);
        //
        // 摘要:
        //     Sets the UVs of the Mesh, using a part of the input array.
        //
        // 参数:
        //   channel:
        //     The UV channel, in [0..7] range.
        //
        //   uvs:
        //     UVs to set for the given index.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetUVs(int channel, Vector2[] uvs, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        public void SetUVs(int channel, List<Vector4> uvs, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Sets the UVs of the Mesh, using a part of the input array.
        //
        // 参数:
        //   channel:
        //     The UV channel, in [0..7] range.
        //
        //   uvs:
        //     UVs to set for the given index.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        [ExcludeFromDocs]
        public void SetUVs(int channel, Vector2[] uvs, int start, int length);
        [ExcludeFromDocs]
        public void SetUVs(int channel, List<Vector4> uvs, int start, int length);
        //
        // 摘要:
        //     Sets the UVs of the Mesh.
        //
        // 参数:
        //   channel:
        //     The UV channel, in [0..7] range. Indices start at 0, which corresponds to uv.
        //     Note that 1 corresponds to uv2.
        //
        //   uvs:
        //     UVs to set for the given index.
        public void SetUVs(int channel, Vector3[] uvs);
        //
        // 摘要:
        //     Sets the UVs of the Mesh.
        //
        // 参数:
        //   channel:
        //     The UV channel, in [0..7] range. Indices start at 0, which corresponds to uv.
        //     Note that 1 corresponds to uv2.
        //
        //   uvs:
        //     UVs to set for the given index.
        public void SetUVs(int channel, Vector2[] uvs);
        public void SetUVs(int channel, List<Vector2> uvs);
        public void SetUVs(int channel, List<Vector3> uvs);
        public void SetUVs(int channel, List<Vector4> uvs);
        [ExcludeFromDocs]
        public void SetUVs(int channel, List<Vector2> uvs, int start, int length);
        public void SetUVs(int channel, List<Vector2> uvs, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        [ExcludeFromDocs]
        public void SetUVs(int channel, List<Vector3> uvs, int start, int length);
        public void SetUVs(int channel, List<Vector3> uvs, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Sets the UVs of the Mesh.
        //
        // 参数:
        //   channel:
        //     The UV channel, in [0..7] range. Indices start at 0, which corresponds to uv.
        //     Note that 1 corresponds to uv2.
        //
        //   uvs:
        //     UVs to set for the given index.
        public void SetUVs(int channel, Vector4[] uvs);



        public void SetVertexBufferData<T>(List<T> data, int dataStart, int meshBufferStart, int count, int stream = 0, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct;
        public void SetVertexBufferData<T>(NativeArray<T> data, int dataStart, int meshBufferStart, int count, int stream = 0, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct;
        public void SetVertexBufferData<T>(T[] data, int dataStart, int meshBufferStart, int count, int stream = 0, MeshUpdateFlags flags = MeshUpdateFlags.Default) where T : struct;
        
        
        //
        // 摘要:
        //     Sets the vertex buffer size and layout.
        //
        // 参数:
        //   vertexCount:
        //     The number of vertices in the Mesh.
        //
        //   attributes:
        //     Layout of the vertex data -- which attributes are present, their data types and
        //     so on.
        public void SetVertexBufferParams(int vertexCount, params VertexAttributeDescriptor[] attributes);
        public void SetVertexBufferParams(int vertexCount, NativeArray<VertexAttributeDescriptor> attributes);


        public void SetVertices<T>(NativeArray<T> inVertices) where T : struct;
        [ExcludeFromDocs]
        public void SetVertices(List<Vector3> inVertices, int start, int length);
        public void SetVertices(List<Vector3> inVertices, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Sets the vertex positions of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inVertices:
        //     Per-vertex positions.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        public void SetVertices(Vector3[] inVertices, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags);
        //
        // 摘要:
        //     Assigns a new vertex positions array.
        //
        // 参数:
        //   inVertices:
        //     Per-vertex positions.
        public void SetVertices(Vector3[] inVertices);
        //
        // 摘要:
        //     Sets the vertex positions of the Mesh, using a part of the input array.
        //
        // 参数:
        //   inVertices:
        //     Per-vertex positions.
        //
        //   start:
        //     Index of the first element to take from the input array.
        //
        //   length:
        //     Number of elements to take from the input array.
        //
        //   flags:
        //     Flags controlling the function behavior, see MeshUpdateFlags.
        [ExcludeFromDocs]
        public void SetVertices(Vector3[] inVertices, int start, int length);
        public void SetVertices<T>(NativeArray<T> inVertices, int start, int length, [Internal.DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags) where T : struct;
        [ExcludeFromDocs]
        public void SetVertices<T>(NativeArray<T> inVertices, int start, int length) where T : struct;
        public void SetVertices(List<Vector3> inVertices);


        /*
            Upload previously done Mesh modifications to the graphics API.

            When creating or modifying a Mesh from code (using "vertices", "normals", "triangles" etc. properties), 
            the Mesh data is internally marked as "modified" and is sent to the graphics API next time the Mesh is rendered.

            Call "UploadMeshData" to immediately send the modified data to the graphics API, to avoid a possible problem later. 
            Passing true in a "markNoLongerReadable" argument makes Mesh data not be readable from the script anymore, 
            and frees up system memory copy of the data.


        // 参数:
            markNoLongerReadable:
                Frees up system memory copy of mesh data when set to true.
                若参数传入 true, 就意味着脚本端未来再也无法 读取本 mesh 数据了, 这样就不需要将 mesh 数据时刻存储在 内存中了
        */
        public void UploadMeshData(bool markNoLongerReadable);


        //
        // 摘要:
        //     A struct containing Mesh data for C# Job System access.
        [NativeHeaderAttribute("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
        [StaticAccessorAttribute("MeshDataBindings", Bindings.StaticAccessorType.DoubleColon)]
        public struct MeshData
        {
            //
            // 摘要:
            //     The number of sub-meshes in the MeshData.
            public int subMeshCount { get; set; }
            //
            // 摘要:
            //     Gets the number of vertices in the MeshData. (Read Only)
            public int vertexCount { get; }
            //
            // 摘要:
            //     Gets the number of vertex buffers in the MeshData. (Read Only)
            public int vertexBufferCount { get; }
            //
            // 摘要:
            //     Gets the format of the index buffer data in the MeshData. (Read Only)
            public IndexFormat indexFormat { get; }

            public void GetColors(NativeArray<Color> outColors);
            public void GetColors(NativeArray<Color32> outColors);
            public NativeArray<T> GetIndexData<T>() where T : struct;
            public void GetIndices(NativeArray<ushort> outIndices, int submesh, [Internal.DefaultValue("true")] bool applyBaseVertex = true);
            public void GetIndices(NativeArray<int> outIndices, int submesh, [Internal.DefaultValue("true")] bool applyBaseVertex = true);
            public void GetNormals(NativeArray<Vector3> outNormals);
            //
            // 摘要:
            //     Gets data about a given sub-mesh in the MeshData.
            //
            // 参数:
            //   index:
            //     The index of the sub-mesh. See Mesh.MeshData.subMeshCount|subMeshCount. If you
            //     specify an out of range index, Unity throws an exception.
            //
            // 返回结果:
            //     Returns sub-mesh data.
            public SubMeshDescriptor GetSubMesh(int index);
            public void GetTangents(NativeArray<Vector4> outTangents);
            public void GetUVs(int channel, NativeArray<Vector3> outUVs);
            public void GetUVs(int channel, NativeArray<Vector4> outUVs);
            public void GetUVs(int channel, NativeArray<Vector2> outUVs);
            //
            // 摘要:
            //     Gets the dimension of a given vertex attribute in the MeshData.
            //
            // 参数:
            //   attr:
            //     The vertex attribute to get the dimension of.
            //
            // 返回结果:
            //     Returns the dimension of the vertex attribute. Returns 0 if the vertex attribute
            //     is not present.
            public int GetVertexAttributeDimension(VertexAttribute attr);
            //
            // 摘要:
            //     Gets the format of a given vertex attribute in the MeshData.
            //
            // 参数:
            //   attr:
            //     The vertex attribute to check the format of.
            //
            // 返回结果:
            //     Returns the format of the given vertex attribute.
            public VertexAttributeFormat GetVertexAttributeFormat(VertexAttribute attr);
            public NativeArray<T> GetVertexData<T>([Internal.DefaultValue("0")] int stream = 0) where T : struct;
            public void GetVertices(NativeArray<Vector3> outVertices);
            //
            // 摘要:
            //     Checks if a given vertex attribute exists in the MeshData.
            //
            // 参数:
            //   attr:
            //     The vertex attribute to check for.
            //
            // 返回结果:
            //     Returns true if the data attribute is present in the Mesh. Returns false if it
            //     is not.
            public bool HasVertexAttribute(VertexAttribute attr);
            //
            // 摘要:
            //     Sets the index buffer size and format of the Mesh that Unity creates from the
            //     MeshData.
            //
            // 参数:
            //   indexCount:
            //     The size of the index buffer.
            //
            //   format:
            //     The format of the indices.
            public void SetIndexBufferParams(int indexCount, IndexFormat format);
            //
            // 摘要:
            //     Sets the data for a sub-mesh of the Mesh that Unity creates from the MeshData.
            //
            // 参数:
            //   index:
            //     The index of the sub-mesh to set data for. See Mesh.MeshData.subMeshCount|subMeshCount.
            //     If you specify an out of range index, Unity throws an exception.
            //
            //   desc:
            //     Sub-mesh data.
            //
            //   flags:
            //     Flags controlling the function behavior. See MeshUpdateFlags.
            public void SetSubMesh(int index, SubMeshDescriptor desc, MeshUpdateFlags flags = MeshUpdateFlags.Default);
            public void SetVertexBufferParams(int vertexCount, NativeArray<VertexAttributeDescriptor> attributes);
            //
            // 摘要:
            //     Sets the vertex buffer size and layout of the Mesh that Unity creates from the
            //     MeshData.
            //
            // 参数:
            //   vertexCount:
            //     The number of vertices in the Mesh.
            //
            //   attributes:
            //     Layout of the vertex data: which attributes are present, their data types and
            //     so on.
            public void SetVertexBufferParams(int vertexCount, params VertexAttributeDescriptor[] attributes);
        }

        
        //
        // 摘要:
        //     An array of Mesh data snapshots for C# Job System access.
        [DefaultMember("Item")]
        [NativeContainer]
        [NativeContainerSupportsMinMaxWriteRestriction]
        [StaticAccessorAttribute("MeshDataArrayBindings", Bindings.StaticAccessorType.DoubleColon)]
        public struct MeshDataArray : IDisposable
        {
            public MeshData this[int index] { get; }

            //
            // 摘要:
            //     Number of Mesh data elements in the MeshDataArray.
            public int Length { get; }

            //
            // 摘要:
            //     Use this method to dispose of the MeshDataArray struct.
            public void Dispose();
        }
    }
}

