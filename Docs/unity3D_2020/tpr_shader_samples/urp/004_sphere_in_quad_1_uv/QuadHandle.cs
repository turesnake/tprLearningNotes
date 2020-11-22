using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 让 quad 始终面向 camera
// 同时，将 go相关信息，传递给 rp


public class QuadHandle : MonoBehaviour
{

    public float radius = 0.45f;

    Transform cameraTransform;
    Renderer rend;
    Material mat;

    // 不是 ben quad 的 transform，而是虚拟球 的 
    // 用它来管理 sphere 的 旋转
    Transform sphereTransform;


    int FlatMapRadiusId = Shader.PropertyToID( "_FlatMapRadius" );
    int CenterPosWSId = Shader.PropertyToID( "_CenterPosWS" );

    // quad sphere-coord
    int quadCoord_0_Id = Shader.PropertyToID( "_QuadCoord0" );// matrix-row-0
    int quadCoord_1_Id = Shader.PropertyToID( "_QuadCoord1" );// matrix-row-1
    int quadCoord_2_Id = Shader.PropertyToID( "_QuadCoord2" );// matrix-row-2


    // Start is called before the first frame update
    void Start()
    {

        GameObject sphereObj = new GameObject();
        sphereTransform = sphereObj.GetComponent<Transform>();

        // set origin dir
        // 虚拟球的 uv缝合线，会在 worldCoord:-x 方向上
        sphereTransform.LookAt( sphereTransform.position + Vector3.forward );

        // --- //
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();

        rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    // Update is called once per frame
    void Update()
    {

        // 让 虚拟球 旋转起来
        sphereTransform.Rotate( new Vector3( 1f, 0.4f, 0.8f ), 0.35f, Space.World );

        
        // 需要将 quad.mat.Render Face 设置为 Back, 才能看得见
        transform.LookAt( cameraTransform );

        // send datas to gpu
        mat.SetFloat( FlatMapRadiusId, radius );
        // implicit convert Vector3 to Vector4 
        mat.SetVector( CenterPosWSId, transform.position );

        // quad-sphere-coord
        Vector3 forward = Vector3.Cross(sphereTransform.right, sphereTransform.up).normalized;
        // 注意此处装填顺序
        Vector3 qc_0 = new Vector3( sphereTransform.right.x, forward.x, sphereTransform.up.x );
        Vector3 qc_1 = new Vector3( sphereTransform.right.y, forward.y, sphereTransform.up.y );
        Vector3 qc_2 = new Vector3( sphereTransform.right.z, forward.z, sphereTransform.up.z );

        mat.SetVector( quadCoord_0_Id,  qc_0 );
        mat.SetVector( quadCoord_1_Id,  qc_1 );
        mat.SetVector( quadCoord_2_Id,  qc_2 );

    }
}
