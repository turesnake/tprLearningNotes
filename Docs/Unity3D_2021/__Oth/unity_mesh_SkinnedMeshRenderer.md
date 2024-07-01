# ======================================================= #
#            Mesh SkinnedMeshRenderer  使用技巧
#                 蒙皮动画脚本
# ======================================================= #


# ----------------------------------- #
#   unity 在 2021.2 alpha 19 之后,
#   支持从 compute shader 直接访问 Mesh SkinnedMeshRenderer 的 buffer 信息
https://docs.google.com/document/d/1_YrJafo9_ZsFm4-8K2QlD0k3RgwZ_49tSA84paobfcY/edit#heading=h.cvw3aojqmyd2


# 目前在 2021.3 中可正常使用 Mesh.GetVertexBuffer(0) 功能;  
# 但尚未玩通 SkinnedMeshRenderer.GetVertexBuffer() 




https://forum.unity.com/threads/feedback-wanted-mesh-compute-shader-access.1096531/
里面聊到一些 SkinnedMeshRenderer 新 api 的使用细节



# In order to modify skinned mesh after skinning already happened, I did it in Camera.onPreRender callback. That one happens after skinning is already done, but before rendering started.





# ---------------------------------------- #
#             示范项目
#          MinimalCompute
# ---------------------------------------- #
https://github.com/cinight/MinimalCompute/tree/2021.2

它的 SkinnedMeshBuffer 示范至少证明, 2021.3 的 SkinnedMeshRenderer.GetVertexBuffer() 是有效的





# ====================================================== #
#      SkinnedMeshRenderer.GetVertexBuffer()  用法
# ====================================================== #


# !!!!!!  在 compute shader 中, 数据结构需为 ByteAddressBuffer
否则无法正确读取到数据... 要查下为啥




# ---------------------------------------- #
#        如何得到一个 动画中的 skinnedMesh 的 顶点信息
# ---------------------------------------- #

    public struct VE 
    {
        public Vector3 posOS;
        public Vector3 normalOS;
        public Vector4 tangentOS;
    }

    GraphicsBuffer vBuffer = skinnedMeshRenderer.GetVertexBuffer();
    if( vBuffer == null )
    {
        return;
    }
    VE[] array = new VE[vertexNum];
    vBuffer.GetData( array );

# 不能直接拿 skinnedMeshRenderer.sharedMesh 里的数据, 这些是静态的;












