# ================================================================ #
#                    unity3d 学习进度
# ================================================================ #


# --- 001 --- #
# 什么是 binormal vector (副法线)
Tangent and binormal vectors are used for normal mapping. 
In Unity only the tangent vector is stored in vertices, 
and the binormal is derived from the normal and tangent values.


# --- 002 --- #
# 切线空间

每个 vertex，都有一个属于自己的 切线空间 坐标系。
此坐标系的 z轴，就是这个 vertex 的 法向量。
y轴 就是 此点所在 纹理空间 的 y轴
最后的 x轴 = Z向量 x Y向量；（顺序可能有误...）




# --- 003 --- #
# 透视/正交 时的 齐次裁剪空间
    以及，在这个空间内，定点 xyzw 四个值的含义



# 对 齐次裁剪空间 坐标系中的 顶点pos，做 透视除法
# 什么是 透视除法



# --- 004 --- #
 SV_POSION 上的值，到底是多少

 虽然从 shader 的角度看，这个 pos 参数好像是从 vs 中传出，然后传入 fs
 但其实中间还是进行了很多道转换。

 那么，从 vs 中出来时，这个 pos 是什么状态，
 进入 fs 时，这个 pos 又是什么状态。



# --- 005 --- #
在 srp 中，是否还存在 forward rendering path,Deferred Shading rendering path
这种概念 ？



# --- 006 --- #
为什么有些示例中，仅仅在 vs 中配置 顶点pos 的值，
最后在 实际呈现时，能反映到 fs 的每个像素上去
中间仅仅进行了 一次插值计算吗



# --- 007 --- #



