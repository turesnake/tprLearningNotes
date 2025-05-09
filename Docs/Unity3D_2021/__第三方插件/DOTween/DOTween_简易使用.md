# ========================================================= #
#              DOTween  简易使用
# ========================================================= #



# class:
local LoopType = CS.DG.Tweening.LoopType
local Ease = CS.DG.Tweening.Ease


# DO Tween
    tween: 在两者之间;
    所以 DOTween 的意思就是: 在两个值之间做点事;



https://dotween.demigiant.com/documentation.php



https://dotween.demigiant.com/





# =================================== #
#     充当 快速协程 来使用
# =================================== #
dotween 不是协程, 但是能实现 延时执行 的功能

    local sequence = DOTween.Sequence()
    sequence:Insert(0, sourceItemView.transform:DOLocalMove(targetPosition, 0.1))
    sequence:Insert(0, sourceItemView.transform:DOScale(0.3, 0.1))
    sequence:InsertCallback(0, function()
        printError("--0--")
    end)
    sequence:InsertCallback(0.1, function()
        printError("--1--")
    end)
    sequence:InsertCallback(0.3, function()
        printError("--3--")
    end)

可以像电影调度器一样, 设置在某个时间点 (参数1) 执行什么事情



# 下一帧执行:
DOVirtual.DelayedCall(0f, () => {  
    Debug.Log("下一帧执行");  
});  


# 延迟两秒执行:
DOVirtual.DelayedCall(2f, () => {  
    Debug.Log("2秒后执行此代码");  
}); 


# 在 sqquence 结束时调用:
sequence:OnComplete(function()
    newPiece:SetRootScale( 1.0 ) -- 确保一定变为1
    newPiece:SetIsReachInitPos(true)
end)

Sets a callback that will be fired the moment the tween reaches completion, all loops included.



# ------------------------------- #
#     将物体从 src 点移动到 dst 点
# ------------------------------- #

using DG.Tweening;

void Update()
{
    if( Input.GetKeyDown(KeyCode.K) )
    {
        sphereTF.position = srcTF.position;   // 先重置到 src 点
        //sphereTF.DOMove(dstTF.position, duration).SetEase(Ease.Linear);
        sphereTF.DOMove(dstTF.position, duration).SetEase(Ease.Linear).Play();  // 开始运动
    }
}
---
看起来就像 dotween 自己维护了一个 协程, 完成了后续运行过程;


# -1- 注意, (至少上述代码) 无法克服 帧率抖动
    在安卓机上, 目标帧率为 45 时, 实际帧率为 30,60,30,60... 反复抖动;
    ---
    此时的 dotween 运动也是抖动的,  这个需要找到方法;


# -2- 多出来的 .Play() 暂不明白;




# ------------------------------- #
#     延迟调用
# ------------------------------- #


DOVirtual.DelayedCall( 1f, ()=>{
    sphereTF.DOMove(dstTF.position, duration).SetEase(Ease.Linear).Play();
});
---
自动延迟一秒后调用;

参数-1- 为 0f 时, 表示在下一帧执行;


# ------------------------------- #
#     忽略 timescales 的影响
# ------------------------------- #

sphereTF.DOMoveX(1f,1f).SetUpdate(true);
---
是这里的 SetUpdate() 起作用



# ------------------------------- #
#     逆向运动 From()
# ------------------------------- #

DOTween 大部分操作的 默认顺序是 `To`, 也就是 src -> dst;

`From()` 则是反向运动;

比如:
-- sphereTF.DOScale( Vector3.one * 5f, 1f );            -- 从小变大
-- sphereTF.DOScale( Vector3.one * 5f, 1f ).From();     -- 从大变小

-- 可以用它实现一次 pingpong;


# ----------------------------------- #
#    tf.DOBlendableMoveBy()
# ----------------------------------- #

sphereTF.DOBlendableMoveBy( new Vector3( -1f, 0f, -1f ), 1f).SetEase(Ease.Linear).SetLoops(3, LoopType.Incremental);

---
让 sphereTF 基于当前pos, 在未来 1 秒内, 位移 Vector3( -1f, 0f, -1f ); 
并且设置这个位移过程是 线性的
并且这个过程重复 3 次, 每次都是增量模式 (表现就是朝着一个方向连续运动了 3 次)





# ----------------------------------- #
#         受 帧率 的影响
# ----------------------------------- #

4. 手动固定步控制
DOTween 可结合 UpdateType.Manual 手动更新，而不是依赖 Unity 的 Update，从而完全控制帧更新以提高一致性：
csharp
    DOTween.Init(false, true, LogBehaviour.Default);  
    DOTween.defaultUpdateType = UpdateType.Manual;  

    // 然后在自定义的更新中调用  
    void Update() {  
        DOTween.ManualUpdate(Time.deltaTime, Time.unscaledDeltaTime);  
    }  
5. 调试帧率稳定性
可以利用 Unity 的帧率显示工具（如 Application.targetFrameRate）强制保持帧率稳定，帮助识别是否是帧率波动导致的误差。




# ----------------------------------- #
#     DOTween.Kill( transform )
# ----------------------------------- #

杀死一个 transform 之前的所有 dotween 动画


# ------------------------------- #
#     sequence:SetTarget(tf)
# ------------------------------- #



绑定 sequence 的 tf

一个 sequence 某个时间内只能绑定一个 tf,
这样在别的代码里, 通过

DOTween.Kill( tf ) 就能删除这个 sequence





# ------------------------------- #
#   DOBlendableMoveBy()
# ------------------------------- #
# 有点类似 Lerp 的味道;

Tweens a Transform's position BY the given value (as if it was set to relative), in a way that allows other DOBlendableMove tweens to work together on the same target, instead than fight each other as multiple DOMove would do.

多个 DOMove() 同时改写一个 tf 会导致打架,  DOBlendableMoveBy 则能融合起来;




# ------------------------------- #
#      DOTween.ToArray()
# ------------------------------- #

将多个 Tweener 或 Sequence 实例整理为一个数组, 以便后续批处理它们;









