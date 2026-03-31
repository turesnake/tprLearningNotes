


# ------------------------------------- #
#            表面细分修改器
#             Subdivision
# ------------------------------------- #
https://www.bilibili.com/video/BV1zh411Y7LX?spm_id_from=333.788.videopod.episodes&vd_source=df0fa6bb68b75a198c4c3f59ce640962&p=56
---
右侧扳手 - add modifier - geometry - subdivision surface;
1-level 时可以把网格多细分一次, 依次递增;

# -- 如何显示 细分线框
-1- 主窗口右上角, 双圆 viewpot overlays: wireframe 勾选, 此时会显示线框, 但是是旧模型的
-2- 修改器界面中, 撤选 optimal display, 此时将显示实际上的所有线


# == 高级:
# -- use limit surface:
    能让计算出来的细分顶点放在完美曲线上,  建议开启

# -- uv smooth:
    当细分后, 如何映射到 uv 上的;
    具体看视频, 建议选择 all

# -- boundary smooth:
    若不希望边界顶点也被影响到, 建议设为 keep corners;

# -- use creases:
    使用折痕, 能保留原始模型的折痕信息, 建议开启, 看具体情况

# -- use custom normals
    使用自定义法线信息



# ------------------------------------- #
#           重构网格
#           remesh
# ------------------------------------- #
https://www.bilibili.com/video/BV1zh411Y7LX?spm_id_from=333.788.videopod.episodes&vd_source=df0fa6bb68b75a198c4c3f59ce640962&p=58
---
它默认处理有体积的模型, 不擅长处理 plane


# -- 这是 非修改器 版的 remesh, 有一些别的功能:
https://www.bilibili.com/video/BV1zh411Y7LX?spm_id_from=333.788.videopod.episodes&vd_source=df0fa6bb68b75a198c4c3f59ce640962&p=59

这个里面选择 四边形, 可以对开放模型, 也就是类似 plane 进行重构, 这是我们想要的







# ------------------------------------- #
#          降面修改器
#           Decimate
# ------------------------------------- #


---
很适合处理 plane 这种单个面/无体积的模型;
可通过算法得到低模

# == 四种模式:
    -- blocks: 生成类似体素的模型
    -- smooth: 生成平滑模型
    -- sharp: 保留锐边
    -- voxel:













