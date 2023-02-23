# ========================================================= #
#         Dreamteck Splines 曲线工具
# ========================================================= #



# 本工具的 t 值 (percent, )




# ------------------------------------- #
#       SplineComputer    (class)
# ------------------------------------- #
类似于 brain;



# ------------------------------------- #
#       SplinePoint    (class)
# ------------------------------------- #

一条 Spline 上的各个关键点



# ------------------------------------- #
#       SplineFollower    (class)
# ------------------------------------- #
可以沿着 Spline 运动的实例;


# followMode 设置为 Uniform, 可以匀速运动;
    此时, follow speed 表示一秒通过的 轨道距离;

# followMode 设置为 Time,
    此时, Follow Duration 表示通过整段曲线的 时长, 此时的运动不是匀速的, 
    在通过较短的 segment 时速度会变慢;

# follow
    勾选会, 运行时会自动 沿着轨道运动, 这不是我们想要的...




# !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! #
#         如何用代码匀速运动
# ------------------------------------- #

    IEnumerator Move2() 
    {
        isMoving = true;
        for( float t = 0f; t<=1.0f;  t += speed * Time.deltaTime )
        {
            double travel = computer.Travel(0.0, splineLength * t, Spline.Direction.Forward); // t 值
            Vector3 pos = computer.EvaluatePosition(travel);
            transform.position = pos;
            yield return null;
        }
        isMoving = false;
    }

用户手动计算 t, 一个 [0f,1f] 区间值, 
然后用 computer.Travel() 将它映射为内部的一个 t值: travel
然后再用 computer.EvaluatePosition() 计算出物理 pos;



# ------------------------------------- #
#       SplineUser    (class)
# ------------------------------------- #

"曲线使用者"

这是个基类












# +++++++++++++++++++++++++++++++++ #

# 目前好像不是匀速运动, 在经过长度较短的 segment 时, 运动速度会变慢 
    感觉不是全局匀速的...






















