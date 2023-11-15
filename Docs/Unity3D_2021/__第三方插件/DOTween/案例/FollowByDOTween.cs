using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using DG.Tweening;
 


// 当帧率不稳定时, 此方法依然会抖; 
public class FollowByDOTween : MonoBehaviour
{
	public Transform target; // Target to follow
    public Transform smoothFollowTF; // 存在的目的是为了让 cameraTF 可以和 target 保持 y 轴距离
    public Transform cameraTF;
	Vector3 targetLastPos;
	Tweener tween;
 
	void Start()
	{
        Debug.Assert( target && smoothFollowTF && cameraTF );

		// First create the "move to target" tween and store it as a Tweener.
		// In this case I'm also setting autoKill to FALSE so the tween can go on forever
		// (otherwise it will stop executing if it reaches the target)
		tween = smoothFollowTF.DOMove(target.position, 0.5f).SetAutoKill(false);


		// Store the target's last position, so it can be used to know if it changes
		// (to prevent changing the tween if nothing actually changes)
		targetLastPos = target.position;
	}
 
	void Update()
	{
		// Use an Update routine to change the tween's endValue each frame
		// so that it updates to the target's position if that changed
		if (targetLastPos == target.position)
        {
            return;
        } 

		// Add a Restart in the end, so that if the tween was completed it will play again
		tween.ChangeEndValue(target.position, true).Restart();
		targetLastPos = target.position;

        CameraFollowSmooth();
	}


    void CameraFollowSmooth()
    {
        cameraTF.position = new Vector3(
            smoothFollowTF.position.x,
            cameraTF.position.y,
            smoothFollowTF.position.z
        );
    }
}

