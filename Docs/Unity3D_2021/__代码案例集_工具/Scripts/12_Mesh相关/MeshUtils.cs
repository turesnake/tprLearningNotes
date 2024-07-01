using UnityEngine;

public static class MeshUtils : MonoBehaviour
{



    /// <summary>
    /// 将贴图上标记为 validVertexColor_ 的顶点 保留 boneweights 信息, 剩余顶点的 boneweights 一律写为 { boneIndex = 0, weight = 1f };
    /// 以此让那些剩余顶点 不再跟随 蒙皮动画运动;
    ///  想要此法生效, 需要 0 号 bone 不参与任何实际动画;
    /// </summary>
    /// <param name="mesh_"> 通常是 skinnedMeshRenderer.sharedMesh </param>
    /// <param name="texture2D_"> 标记顶点信息的 2d贴图 </param>
    /// <param name="validVertexColor_"> 需要保留 蒙皮动画的顶点的颜色 </param>
    /// <param name="colorThreshold255_"> [0,255] 颜色rgb通道误差冗余 </param>
    /// <param name="alphaThreshold_"> [0f,1f] 颜色alpha通道误差冗余 </param>
    /// <returns></returns>
    public static Mesh ResetMeshBoneWeights( Mesh mesh_, Texture2D texture2D_, Color validVertexColor_, float colorThreshold255_ = 5f, float alphaThreshold_ = 0.05f ) 
    {   
        Mesh mesh = Object.Instantiate(mesh_);

        int vertexNum       = mesh.vertices.Length;
        var vertices        = mesh.vertices;
        var uvs             = mesh.uv;

        // ----- old:
        NativeArray<byte> originBonesPerVertex = mesh.GetBonesPerVertex(); // Get the number of bone weights per vertex
        NativeArray<BoneWeight1> originBoneWeights = mesh.GetAllBoneWeights(); // Get all the bone weights, in vertex index order
        
        // ----- new:
        byte[] bonesPerVertex = new byte[vertexNum];
        System.Array.Fill<byte>( bonesPerVertex, 0 );
        List<BoneWeight1> weightsList = new List<BoneWeight1>();
        //---
        var bonesIndex = 0; // 计数器

        // ============  ==============
        for( int i=0; i<uvs.Length; i++ )
        {
            var boneNumForThisVertex = originBonesPerVertex[i];
            var uv  = uvs[i];
            Color color = texture2D_.GetPixelBilinear( uv.x, uv.y );
            if( Tools.KTool.IsColorCloseEnough(color, validVertexColor_, colorThreshold255_, alphaThreshold_ ) ) // 跟随骨骼的顶点
            {
                for (var j = 0; j < boneNumForThisVertex; j++) 
                {
                    BoneWeight1  boneWeight = originBoneWeights[bonesIndex];
                    weightsList.Add( boneWeight );
                    bonesPerVertex[i]++;
                    bonesIndex++;
                }    
                // --- debug:
                // var tf =  GlobalUtils.CreatePrimitive( PrimitiveType.Sphere, null, new Vector3(0.1f,0.1f,0.1f), Color.yellow );
                // tf.position = vertices[i];            
            }
            else // 不跟随骨骼的顶点
            {
                // 手写一个:
                weightsList.Add( new BoneWeight1(){ boneIndex = 0, weight = 1f } );
                bonesPerVertex[i]++;
                // 只是过掉, 并不使用:
                for (var j = 0; j < boneNumForThisVertex; j++) 
                {
                    bonesIndex++;
                }
            }
        }

        //--- 
        var bonesPerVertexArray = new NativeArray<byte>(bonesPerVertex, Allocator.Temp);
        var weightsArray = new NativeArray<BoneWeight1>(weightsList.ToArray(), Allocator.Temp);
        mesh.SetBoneWeights(bonesPerVertexArray, weightsArray);
        return mesh;
    }


}
