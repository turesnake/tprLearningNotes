# ========================================================= #
#              DOTween  简易使用
# ========================================================= #


# DO Tween
    tween: 在两者之间;
    所以 DOTween 的意思就是: 在两个值之间做点事;



https://dotween.demigiant.com/documentation.php




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




# ----------------------------------- #
#    Transform.DOBlendableMoveBy()
# ----------------------------------- #

sphereTF.DOBlendableMoveBy( new Vector3( -1f, 0f, -1f ), 1f).SetEase(Ease.Linear).SetLoops(3, LoopType.Incremental);

---
让 sphereTF 基于当前pos, 在未来 1 秒内, 位移 Vector3( -1f, 0f, -1f ); 
并且设置这个位移过程是 线性的
并且这个过程重复 3 次, 每次都是增量模式 (表现就是朝着一个方向连续运动了 3 次)



















