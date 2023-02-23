# ========================================================== #
#                 Curvy Splines 8
# ========================================================== #


# ------------------------- #
# CurvySpline (class)
相当于 brain


# ------------------------- #
# CurvySplineSegment (class)

虽然它指向一个 点, 但它其实负责这个点后面的一段曲线;

# 此组件的 inspector 界面上存在一组数据:
    Control Point Distance: 0                                   -- 本点到起点距离 (沿曲线积分得到)
    Spline Length: 3                                            -- 本曲线总长度 (曲线积分值)
    Control Point Relative Distance: 0 ( = Distance / Length)   -- 上面两值相除
    Control Point TF: 0                                         -- 本点在整条曲线内的 t值 (0f,1f) (total f 值)
    Segment Length: 1                                           -- 本点后面一段曲线的长度 (曲线积分)
    Segment Cache Points:2                                      -- 






























