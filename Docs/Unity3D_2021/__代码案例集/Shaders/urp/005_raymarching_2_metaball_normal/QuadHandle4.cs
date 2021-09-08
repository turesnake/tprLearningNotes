using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 将 数据 传递给 rp

public class QuadHandle4 : MonoBehaviour
{

    Transform cameraTransform;
    Renderer rend;
    Material mat;

    // based on quadBasePos
    Vector3[] ballPoses;
    float[]   ballRadius;
    Vector4[] ballPosesOut; // 专门用来传输的


    int QuadBasePosId = Shader.PropertyToID( "_QuadBasePosWS" );
    int ballPosesId = Shader.PropertyToID( "_BallPosesWS" );


    // 不是 ben quad 的 transform，而是 quad 体内的虚拟空间的 
    // 用它来管理 quad 体内所有 虚拟物体的 旋转
    Transform quadSpaceTransform;
    


    bool isAnimOn = false;
    bool isRotateOn = false;

    Vector3 velocity1 = new Vector3(  3f, 0f, 0f );
    Vector3 velocity2 = new Vector3( -4f, 0f, 0f );
    Vector3 velocity3 = new Vector3( -1.5f, 4f, 0f );


    // Start is called before the first frame update
    void Start()
    {
        GameObject spaceObj = new GameObject();
        quadSpaceTransform = spaceObj.GetComponent<Transform>();

        // --- 
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();

        rend = GetComponent<Renderer>();
        mat = rend.material;

        
        ballPoses = new Vector3[]{
            new Vector3( -3f, 0f, 0f ),
            new Vector3(  3f, 0f, 0f ),
            new Vector3(  2f, -3f, 0f )
        };
        ballRadius = new float[]{
            2f, 4f, 3f
        };
        ballPosesOut = new Vector4[3];


    }

    // Update is called once per frame
    void Update()
    {        

        if( Input.GetKeyDown( KeyCode.K ) ){
            isAnimOn = isAnimOn ? false : true;
        }
        if( Input.GetKeyDown( KeyCode.L ) ){
            isRotateOn = isRotateOn ? false : true;
        }
        if( isAnimOn ){
            ballsAnim();
        }
        if( isRotateOn ){
            quadSpaceTransform.Rotate( new Vector3( 0.5f, -1f, 1f ), 0.15f, Space.World );
        }

        quadSpaceTransform.position = transform.position;
        for( int i=0; i<ballPoses.Length; i++ ){
            // MultiplyPoint3x4() 可以以较快的速度 处理 常规 3D转换
            // 但因为 参数缺少 w分量，所以此函数 不支持 projective transformation
            ballPosesOut[i] = quadSpaceTransform.localToWorldMatrix.MultiplyPoint3x4( ballPoses[i] );
            ballPosesOut[i].w = ballRadius[i]; // radius
        }
        
        // send datas to gpu
        // implicit convert Vector3 to Vector4 
        mat.SetVector( QuadBasePosId, transform.position );
        mat.SetVectorArray( ballPosesId, ballPosesOut );

    }

    bool outOfRange( ref Vector3 pos ){
        return (
            pos.x >= -4f && pos.x <= 4f &&
            pos.y >= -4f && pos.y <= 4f &&
            pos.z >= -4f && pos.z <= 4f
        );
    }


    void ballsAnim(){

        float velocity = 0.7f * Time.deltaTime;

        if( !outOfRange(ref ballPoses[0]) ){ velocity1 *= -1f; }
        if( !outOfRange(ref ballPoses[1]) ){ velocity2 *= -1f; }
        if( !outOfRange(ref ballPoses[2]) ){ velocity3 *= -1f; }

        ballPoses[0] += velocity1 * velocity;
        ballPoses[1] += velocity2 * velocity;
        ballPoses[2] += velocity3 * velocity;

    }



}
