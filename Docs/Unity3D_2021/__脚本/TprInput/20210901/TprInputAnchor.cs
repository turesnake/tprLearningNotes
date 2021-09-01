using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
    TprInput 的伴随脚本, TprInput 会在运行时自动新建一个 临时go,
    然后为这个 临时go 绑定本脚本. 
    用户什么都不用做
*/

public class TprInputAnchor : MonoBehaviour
{
    private void Awake() {
        TprInput.anchorMove += move;
    }
    // Start is called before the first frame update

    public void move( Vector3 poseOff_ ){
        transform.position += poseOff_;
    }
}
