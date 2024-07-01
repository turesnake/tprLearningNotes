using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Tools;




namespace CopySkinnedMeshRenderer
{




// [StructLayout(LayoutKind.Sequential)]
public struct VertexM
{
    public Vector4 pos;
}



/*



*/
public class CopySkinnedMeshRendererBH : MonoBehaviour
{

    public ComputeShader computeShader;
    public SkinnedMeshRenderer srcSkinnedMeshRenderer;
    public Transform srcBoneTF;

    // ------------------------------------------ 
    public Transform dstBoneTF;
    public Material dstMat;



    // ------------------------------------------ 
    int KernelIdx; // kernel idx

    ComputeBuffer vertexBuffer;

    int frameCount = 0;
    int vertexNum;


    // ------------------------------------------------------------

    static int _MeshVertexBuffer = Shader.PropertyToID("_MeshVertexBuffer"); 
    static int _VertexBuffer = Shader.PropertyToID("_VertexBuffer");  
    static int _SrcBoneLocalToWorldMatrix = Shader.PropertyToID("_SrcBoneLocalToWorldMatrix");
    static int _DstBoneMatrix = Shader.PropertyToID("_DstBoneMatrix");




    void Start()
    {
        Debug.Assert(computeShader);
        Debug.Assert( srcSkinnedMeshRenderer && srcBoneTF );
        Debug.Assert(dstBoneTF);

        vertexNum = srcSkinnedMeshRenderer.sharedMesh.vertices.Length;

        // Mark the vertex buffer as needing "Raw"
        // (ByteAddressBuffer, RWByteAddressBuffer in HLSL shaders) // !! 实测下来暂时只支持 ByteAddressBuffer
        srcSkinnedMeshRenderer.vertexBufferTarget |= GraphicsBuffer.Target.Raw;

        frameCount = 0;

        KernelIdx  = computeShader.FindKernel("CopyPos"); 
        Debug.Assert( KernelIdx >= 0 );
    }



    void LateUpdate()
    {
        // ===== CpuData2Gpu ======
        if( frameCount == 0 )
        {
            KTool.Release(vertexBuffer);
            vertexBuffer = new ComputeBuffer(vertexNum, (4 * 4) );

            VertexM[] m_vertex = new VertexM[vertexNum]; // struct, 自动装填内容了

            vertexBuffer.SetData(m_vertex);
            computeShader.SetBuffer(KernelIdx, _VertexBuffer, vertexBuffer);
        }

        // Get the vertex buffer of the Mesh, and set it up
        // as a buffer parameter to a compute shader.
        var meshVertexBuffer = srcSkinnedMeshRenderer.GetVertexBuffer();
        if( meshVertexBuffer == null )
        {
            Debug.LogError( "meshVertexBuffer == null" );
            return;
        }
    
        computeShader.SetBuffer(KernelIdx, _MeshVertexBuffer, meshVertexBuffer);
        computeShader.SetMatrix( _SrcBoneLocalToWorldMatrix, srcBoneTF.localToWorldMatrix );
        computeShader.SetMatrix( _DstBoneMatrix, dstBoneTF.localToWorldMatrix );

        // 
        computeShader.Dispatch( KernelIdx,  (vertexNum / 256)+1, 1, 1 );
        

        // ======
        dstMat.SetBuffer( _VertexBuffer, vertexBuffer );


        if(frameCount < 9999999)
        {
            frameCount++;
        }

        meshVertexBuffer.Release();
        meshVertexBuffer.Dispose();
    }

}

}


