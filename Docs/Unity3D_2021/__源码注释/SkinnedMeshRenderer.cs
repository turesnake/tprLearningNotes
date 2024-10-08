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


        /*
            !!! compute shader 想要访问这个 mesh 时, 会用到本接口
            摘要:
                The intended target usage of the skinned mesh GPU vertex buffer.

                By default, skinned mesh renderer vertex buffers have GraphicsBuffer.Target.Vertex usage target. 
                If you want to access the vertex buffer from a compute shader, additional targets need to be requested, for example GraphicsBuffer.Target.Raw.

        */
        public GraphicsBuffer.Target vertexBufferTarget { get; set; }


        /*
            摘要:
                Creates a snapshot of SkinnedMeshRenderer and stores it in mesh.


                The snapshot is still computed even when updateWhenOffscreen is set to false and the skinned mesh object is currently offscreen.
                When this function is called the skinning process will always take place on the CPU, regardless of the GPU Skinning setting.
            
            参数:
            mesh:
                A static mesh that will receive the snapshot of the skinned mesh.
            
            useScale:
                Whether to use the SkinnedMeshRenderer's Transform scale when baking the Mesh.
                If this is true, Unity bakes the Mesh using the position, rotation, and scale
                values from the SkinnedMeshRenderer's Transform. If this is false, Unity bakes
                the Mesh using the position and rotation values from the SkinnedMeshRenderer's
                Transform, but without using the scale value from the SkinnedMeshRenderer's Transform.
                The default value is false.
        */
        public void BakeMesh(Mesh mesh);
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


        /*
            !!! compute shader
            摘要:
                Retrieves a GraphicsBuffer that provides direct access to the GPU vertex buffer
                for this skinned mesh, for the current frame.

                官方推荐每帧都调用
                !! 第一帧会反馈 null

                通常, 元素内涵:
                    float3 posOS;
                    float3 normalOS;
                    float4 tangentOS;
                    ---
                
                不会包含 float2 uv; 因为 uv 信息并不会逐帧变化, 不需要每一帧都携带; 而是可以到 sharedMesh 里去获取静态的 uv 信息;

            
            返回结果:
                The skinned mesh vertex buffer as a GraphicsBuffer.
        */
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

