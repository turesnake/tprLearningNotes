using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

// 运行时动态切换 animator 中一个 state 里的 animation clip 

// 测试表明, 甚至支持在 "正在播放 state 002" 时, 现场更换 002 绑定的 animation clip
// 如果 002 是 loop 的, 会在下一次loop 时刷新为新的 clip


public class AnimationClipChanger : MonoBehaviour  
{  
    public Animator animator;  
    public AnimationClip newClip_a;  // clip 方案 1
    public AnimationClip newClip_b;  // clip 方案 2


    AnimatorOverrideController animatorOverrideController;  
    


    void Start()  
    {  
        Debug.Assert(animator);
        Debug.Assert(newClip_a);
        Debug.Assert(newClip_b);

        // 从Animator中获取当前的控制器  
        var originalController = animator.runtimeAnimatorController;  
        // 创建一个AnimatorOverrideController基于原来的控制器  
        animatorOverrideController = new AnimatorOverrideController(originalController);  
        animator.runtimeAnimatorController = animatorOverrideController;  
    }  


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeAnimationClip("002", newClip_a);

        }else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeAnimationClip("002", newClip_b);
        }
    }


    public void ChangeAnimationClip(string clipNameToReplace, AnimationClip newClip_)  
    {  
        // 获取当前Animator的OverrideClips  
        var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>> (animatorOverrideController.overridesCount);  
        animatorOverrideController.GetOverrides(overrides);  

        //var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>();


        // 查找并替换指定名称的动画片段  
        for (int i = 0; i < overrides.Count; i++)  
        {  
            //print("name = " + overrides[i].Key.name);
            if (overrides[i].Key.name == clipNameToReplace)  
            {  
                print("开始更换");
                overrides[i] = new KeyValuePair<AnimationClip, AnimationClip>(overrides[i].Key, newClip_);  
            }  
        }  
        // 设置新的覆盖  
        animatorOverrideController.ApplyOverrides(overrides);  
    }  
}


