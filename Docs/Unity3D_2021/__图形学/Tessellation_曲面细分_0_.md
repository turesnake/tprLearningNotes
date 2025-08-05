

#  catlike 详解 曲面细分 实现流程
https://catlikecoding.com/unity/tutorials/advanced-rendering/tessellation/


# 基于曲面细分 的体积云
https://walkingfat.com/%e5%9f%ba%e4%ba%8etessellation%e7%9a%84%e4%bd%93%e7%a7%af%e4%ba%91/



# ================================================ #
#           为什么用 曲面细分  Tessellation
# ================================================ #



# -1- 配合 置换贴图 / 法线贴图 / 高度贴图 / 位移贴图 来实现 "实"精细表面
因为新创建的顶点, 可以真的记录这些新信息;


# -1- 因为 VertexShader 中无法采样 texture2D / texture3D
还在测试能否在 曲面细分着色器中采样...



# -2- LOD 动态 细分
靠近相机的, 细分多点, 远离相机的, 关闭细分;
这要比整个模型都是高模 要好很多;
---
尤其是开放世界的 地景制作, 


# -3- 雪地里制作脚印






























