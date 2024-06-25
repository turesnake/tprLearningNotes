#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     The Skinned Mesh filter.
    [NativeHeaderAttribute("Runtime/Graphics/Mesh/SkinnedMeshRenderer.h")]
    [RequiredByNativeCodeAttribute]
    public class SkinnedMeshRenderer : Renderer
    {
        public SkinnedMeshRenderer();

        /*
            摘要:
                The maximum number of bones per vertex that are taken into account during skinning.

                The maximum number of bones that affect a single vertex.

                The value can be either One Bone, Two Bones, Four Bones or Unlimited.

                This setting does not change the underlying mesh data; it only affects the number of bone weights that Unity uses when performing skinning. 
                This means that a mesh can have bone weight data that is unused due to this setting. You can change this value at runtime.

                You can set this value for all meshes in the project using QualitySettings.skinWeights. You can set the maximum number of bone weights that mesh data stores per vertex using ModelImporter.maxBonesPerVertex.

        */
        public SkinQuality quality { get; set; }
        //
        // 摘要:
        //     If enabled, the Skinned Mesh will be updated when offscreen. If disabled, this
        //     also disables updating animations.
        public bool updateWhenOffscreen { get; set; }
        //
        // 摘要:
        //     Forces the Skinned Mesh to recalculate its matricies when rendered
        public bool forceMatrixRecalculationPerRender { get; set; }
        public Transform rootBone { get; set; }
        //
        // 摘要:
        //     The bones used to skin the mesh.
        public Transform[] bones { get; set; }
        //
        // 摘要:
        //     The mesh used for skinning.
        [NativePropertyAttribute("Mesh")]
        public Mesh sharedMesh { get; set; }
        //
        // 摘要:
        //     Specifies whether skinned motion vectors should be used for this renderer.
        [NativePropertyAttribute("SkinnedMeshMotionVectors")]
        public bool skinnedMotionVectors { get; set; }
        //
        // 摘要:
        //     The intended target usage of the skinned mesh GPU vertex buffer.
        public GraphicsBuffer.Target vertexBufferTarget { get; set; }

        //
        // 摘要:
        //     Creates a snapshot of SkinnedMeshRenderer and stores it in mesh.
        //
        // 参数:
        //   mesh:
        //     A static mesh that will receive the snapshot of the skinned mesh.
        //
        //   useScale:
        //     Whether to use the SkinnedMeshRenderer's Transform scale when baking the Mesh.
        //     If this is true, Unity bakes the Mesh using the position, rotation, and scale
        //     values from the SkinnedMeshRenderer's Transform. If this is false, Unity bakes
        //     the Mesh using the position and rotation values from the SkinnedMeshRenderer's
        //     Transform, but without using the scale value from the SkinnedMeshRenderer's Transform.
        //     The default value is false.
        public void BakeMesh(Mesh mesh);
        //
        // 摘要:
        //     Creates a snapshot of SkinnedMeshRenderer and stores it in mesh.
        //
        // 参数:
        //   mesh:
        //     A static mesh that will receive the snapshot of the skinned mesh.
        //
        //   useScale:
        //     Whether to use the SkinnedMeshRenderer's Transform scale when baking the Mesh.
        //     If this is true, Unity bakes the Mesh using the position, rotation, and scale
        //     values from the SkinnedMeshRenderer's Transform. If this is false, Unity bakes
        //     the Mesh using the position and rotation values from the SkinnedMeshRenderer's
        //     Transform, but without using the scale value from the SkinnedMeshRenderer's Transform.
        //     The default value is false.
        public void BakeMesh([NotNullAttribute("NullExceptionObject")] Mesh mesh, bool useScale);
        //
        // 摘要:
        //     Returns the weight of a BlendShape for this Renderer.
        //
        // 参数:
        //   index:
        //     The index of the BlendShape whose weight you want to retrieve. Index must be
        //     smaller than the Mesh.blendShapeCount of the Mesh attached to this Renderer.
        //
        // 返回结果:
        //     The weight of the BlendShape.
        public float GetBlendShapeWeight(int index);
        //
        // 摘要:
        //     Retrieves a GraphicsBuffer that provides direct access to the GPU vertex buffer
        //     for this skinned mesh, for the previous frame.
        //
        // 返回结果:
        //     The skinned mesh vertex buffer as a GraphicsBuffer.
        public GraphicsBuffer GetPreviousVertexBuffer();
        //
        // 摘要:
        //     Retrieves a GraphicsBuffer that provides direct access to the GPU vertex buffer
        //     for this skinned mesh, for the current frame.
        //
        // 返回结果:
        //     The skinned mesh vertex buffer as a GraphicsBuffer.
        public GraphicsBuffer GetVertexBuffer();
        //
        // 摘要:
        //     Sets the weight of a BlendShape for this Renderer.
        //
        // 参数:
        //   index:
        //     The index of the BlendShape to modify. Index must be smaller than the Mesh.blendShapeCount
        //     of the Mesh attached to this Renderer.
        //
        //   value:
        //     The weight for this BlendShape.
        public void SetBlendShapeWeight(int index, float value);
    }
}

