
# ----------------------- #
#    核心 hlsl 代码:
# ----------------------- #
float field = 0;
//---
foreach vt:
{
    float dist = length(pos - vt.pos);   // 到该 metaball 圆心的距离
    minDistance = min(minDistance, dist);

    if (dist < vt.z) {
        float t = 1.0 - dist / vt.z;     // 把距离归一化到 [0,1]
        field += vt.w * t * t;           // 二次核：越靠近圆心，贡献越大
    }
}
//----
if (field < _Threshold) {
    //... 绘制出来
}


# 基于 “有限支撑二次核（quadratic kernel）”

# vt.z：
    该 metaball 的影响半径, 多远距离的粒子之间会相互连接
    这个值也关系到 2d grid cell 的划分细度;

# vt.w：
    该 metaball 的强度/权重 
    

# _Threthold：
    场值阈值，用来把连续的“场”转为可见区域（iso-surface/等值线）。当 field ≥ _Threshold 判定为“内部/显示”，否则“外部/不显示”。





























