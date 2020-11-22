using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 将 数据 传递给 rp

public class QuadHandle3 : MonoBehaviour
{

    Transform cameraTransform;
    Renderer rend;
    Material mat;

    // based on quadBasePos
    // xyz: pos
    // w:   radius
    Vector4[] ballPoses;


    int QuadBasePosId = Shader.PropertyToID( "_QuadBasePosWS" );
    int ballPosesId = Shader.PropertyToID( "_BallPosesWS" );

    bool isAnimOn = false;


    // Start is called before the first frame update
    void Start()
    {
        // --- 
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();

        rend = GetComponent<Renderer>();
        mat = rend.material;

        
        ballPoses = new Vector4[]{
            new Vector4( -4f, 0f, 0f, 0.3f ),
            new Vector4(  4f, 0f, 0f, 0.3f ),
            new Vector4(  2f, -3f, 0f, 0.3f )
        };
        

    }

    // Update is called once per frame
    void Update()
    {

        if( Input.GetKeyDown( KeyCode.K ) ){
            isAnimOn = true;
        }

        if( isAnimOn ){
        //ballPoses[0].w += 0.0002f;
        float velocity = 1.7f;
        ballPoses[0].x += 0.004f * velocity;
        ballPoses[1].x -= 0.003f * velocity;
        ballPoses[2].x -= 0.002f * velocity;
        ballPoses[2].y += 0.005f * velocity;
        }

        // send datas to gpu
        // implicit convert Vector3 to Vector4 
        mat.SetVector( QuadBasePosId, transform.position );
        mat.SetVectorArray( ballPosesId, ballPoses );

    }



}
