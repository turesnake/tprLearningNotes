# ================================================================//
#                      Coroutines
# ================================================================//


Coroutines 可以让一段代码在 若干帧内 逐次执行.

在 Coroutines 函数内, 每一帧都执行一部分代码, 然后停下来退回到 上层函数中, 去执行别的代码, 直到下一帧再次调用这个 Coroutines 函数, 此时接着上一帧的进度, 再执行一部分代码.

# ==:
    IEnumerator Fade()
    {
        Color c = renderer.material.color;
        
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            c.a = f;
            renderer.material.color = c;
            yield return null;
        }
    }
# --
此代码能逐渐降低物体的 半透明度
如何使用此函数:
# ==:
    void Update()
    {
        StartCoroutine(Fade());
    }
# --

使用 yield return null; 可在下一帧 继续运行代码; 
使用 yield return new WaitForSeconds(.1f); 可在一定时间后;


注意:
可使用 StopCoroutine() 和 StopAllCoroutines() 来停止一个 Coroutine,
此外, 如果这个 Coroutine 被实现在一个 mono脚本中, 而这个脚本绑定的 go 已经 disactive 了, 此 Coroutine 也会停止. 注意, 就算后来重新激活 go, 这个 Coroutine 也不会再自动 继续之前的工作; 
调用 Destroy(e); (e为 monobehaviour实例) 能直接触发 OnDisable(), 它能处理 Coroutine, 有效地将之停止; 最终, 在一帧地结束时, 会调用 OnDestroy()


通过设置 enabled 为 false, 将一个 monobahaviour 设为 disabling, 这不能停止一个 Coroutine















