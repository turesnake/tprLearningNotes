using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    一个特别适合观察物体 的 位移旋转系统
    --------
    相机会围绕 锚点物体 "tprInputAnchor" 做视角旋转 (类似MH)
    此脚本 可挂载于 任意 obj 上. (通常会直接挂载到 main camera 上)

    思路:
    --- anchorGO ---
    一个临时 emptyGO, 
    位移操作会直接作用于它,再由它 带动跟随的 proxyGO 发生位移. 
    旋转操作 则是以此点为 "观察目标",  proxyGO 围着它旋转.
    anchorGO.localRotation 会朝向 camera 观察的方向. camera 再始终看向它

    ----- 关于 rotation ----//
    不知道其中包含的 rotation 操作，是否可用 四元数操作 来代替
    目前的实现 比较直观. 

    目前为止，暂时还不会引发欧拉角的问题

    ----- 20220511 更新 -----
    现在直接将本脚本挂载到任意一个 camera 上即可运行;
    若挂载到 非 camera go 上, 则需要手动绑定一下 目标 camera;
*/
public class TprInput : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    Transform  anchorTransform;

    const float pitchDegree  = 100f;// 俯仰 基础速率
    const float yawDegree    = 60f;// 偏航 基础速率
    const float moveSpeed    = 6f;// 位移 基础速率


    [SerializeField, Range(0.1f, 20f)]
        float anchorRadius = 5.0f;// 观察点 距 相机的距离(米). 若此值变小, 会接近第一人称体验

    [SerializeField, Range(0.05f, 5f)]
        float moveRatio = 1f; // 位移速率 倍率修正

    [SerializeField, Range(0.1f, 4f)] 
        float rotateRaio = 1.0f; // 旋转速率 倍率修正

    bool isError = false;


    void Start()
    {
        Debug.Log( "tprInput: Start" );

        isError = false;
        // === camera === //
        if ( cameraTransform == null ) 
        {
            bool idFind = transform.TryGetComponent<Camera>( out var tgtCam );
            if( idFind == false ){
                Debug.LogWarning("TprInput: 需要绑定 cameraTransform, 或把本文件直接绑定到目标 camera 上去");
                isError = true;
                return;
            }
            // 说明本脚本当前挂载的 go, 就是一个 camera go;
            cameraTransform = transform;
        }

        // === Anchor === //
        GameObject anchorGo = new GameObject( "tprInputAnchor" );
        anchorTransform = anchorGo.transform;
        anchorTransform.position = cameraTransform.position + cameraTransform.forward * anchorRadius;
        anchorTransform.rotation = cameraTransform.rotation; // hard bind
    }

    // 目前仅支持 键盘输入
    void Update(){

        if( isError ){
            Debug.LogWarning("TprInput: 需要绑定 cameraTransform, 或把本文件直接绑定到目标 camera 上去");
            return;
        }

        //===== 与 MH 同原理的 位移系统 =====//
        // camera 以 anchor 为锚点旋转 
        // 位移坐标系 以 camera 当前方向 为准
        // 角色 anchor 的朝向，会自动对齐到 位移方向
        
        if( !Input.anyKey ){ 
            return; 
        }

        float deltaTime = Time.deltaTime;

        //--- move ---//
        bool m_forward = Input.GetKey( KeyCode.W );
        bool m_back    = Input.GetKey( KeyCode.S );
        bool m_left    = Input.GetKey( KeyCode.A );
        bool m_right   = Input.GetKey( KeyCode.D );
        bool m_up      = Input.GetKey( KeyCode.E );
        bool m_down    = Input.GetKey( KeyCode.Q );

        bool isAnyMoveKey = m_forward || m_back || m_left || m_right || m_up || m_down;
        if( isAnyMoveKey ){

            Vector3 moveOff = new Vector3();
            // 此处的 上下前后，是基于 camera_local_coord 的
            // 所以不能单独累加 x，z 方向的值
            // 最后还要清理掉 y 方向的分量
            if( m_forward ){        moveOff += cameraTransform.forward.normalized;
            }else if( m_back ){     moveOff -= cameraTransform.forward.normalized;
            }
            if( m_left ){           moveOff -= cameraTransform.right.normalized;
            }else if( m_right ){    moveOff += cameraTransform.right.normalized;
            }
            moveOff.y = 0;// MUST
            //--- 单独处理 y 方向的分量 ---
            if( m_up ){             moveOff.y += 1f;
            }else if( m_down ){     moveOff.y -= 1f;
            }
            //---//
            anchorTransform.position += moveOff.normalized * moveSpeed * moveRatio * deltaTime;
        }

        //--- 摄像机视角 ---//
        // 以 anchor 为轴心旋转(俯仰，偏航)
        bool r_up       = Input.GetKey( KeyCode.UpArrow );
        bool r_down     = Input.GetKey( KeyCode.DownArrow );
        bool r_left     = Input.GetKey( KeyCode.LeftArrow );
        bool r_right    = Input.GetKey( KeyCode.RightArrow );

        bool isAnyRotateKey = r_up || r_down || r_left || r_right;
        if( isAnyRotateKey ){
            // pitch 
            if( r_left ){       anchorTransform.Rotate( Vector3.up,  pitchDegree * rotateRaio * deltaTime, Space.World );
            }else if( r_right ){anchorTransform.Rotate( Vector3.up, -pitchDegree * rotateRaio * deltaTime, Space.World );
            }
            // yaw
            float upAngle = anchorTransform.localEulerAngles.x;
            if( upAngle>=180.0f ){ upAngle -= 360.0f; }
                // 起初，角度分布在 [0,90],[270,360] 两个区间中
                // 通过一步减法，将角度 合并到 [ -90, 90 ] 这个区间
                // 为了防止越过 pole 后，整个摄像机翻转
                // 我们规定 up-down 旋转的上下界为 [-85,85] 
                // ---
                // 此处限制并不完备, 如果单帧旋转角度过大, 完全可以"越"过整个 极坐标禁区, 转到对面的有效区去
                // 目前的限制方式就是 约束 rotateRaio 的取值区间; 实际使用中尚可接受
            if( r_up && upAngle>-80.0f ){         
                anchorTransform.Rotate( Vector3.right, -yawDegree * rotateRaio * deltaTime, Space.Self );
            }else if( r_down && upAngle<80.0f ){ 
                anchorTransform.Rotate( Vector3.right,  yawDegree * rotateRaio * deltaTime, Space.Self );
            }
        }

        // ===== set camera ===== //
        cameraTransform.position = anchorTransform.position - anchorTransform.forward * anchorRadius;
        cameraTransform.LookAt( anchorTransform );
    }
}
