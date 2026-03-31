

# =========================================== #
#           如何用 blender 烘焙各种贴图
# =========================================== #

https://www.bilibili.com/video/BV1514y167zh/?spm_id_from=333.337.search-card.all.click&vd_source=df0fa6bb68b75a198c4c3f59ce640962





# =========================================== #
#        用高模烘焙低模的 法线贴图
# =========================================== #

# -- 一个教程:
https://www.bilibili.com/video/BV1dwbtzdEju/?spm_id_from=333.337.search-card.all.click&vd_source=df0fa6bb68b75a198c4c3f59ce640962
但是按照这个方式生成的法线贴图, 颜色不对

# -- 还介绍了烘培其它贴图
https://www.bilibili.com/video/BV1t8KNzfE6z/?spm_id_from=333.337.search-card.all.click&vd_source=df0fa6bb68b75a198c4c3f59ce640962


https://www.bilibili.com/video/BV1CZ421a7Dk/?spm_id_from=333.337.search-card.all.click&vd_source=df0fa6bb68b75a198c4c3f59ce640962


# == 流程:
准备好高低模型, 摆放在一起;

-1- 为低模展uv;

-1- 选中低模, 在 shader 窗口中为它新建一个材质球, 再新建一个 image texture 节点;
    在 image texture 中新建一个贴图文件, 撤选 alpha, 其它不改;

-1- 先选高模, 再 clt 选低模, 确认在 shader窗口选中那个 image texture 节点;

-1- 右侧选择 render 窗口栏, 渲染引擎选 cycles,
    选 gpu (这个随意)
    Bake 区, 类型选 normal, space 保留默认的 tangent, 下面几个参数默认;
    --
    勾选: selected to active, 这是用来烘培高低模的,
    -- extrusion 挤出:设置高低模之间 高度差, 可设置 0.1m;
    -- Max Ray Distance: 这个保持默认的 0m, 表示无限制, 否则会出问题
    ==
    点击bake,

-1- 到 image editor 窗口可看到烘焙好的 法线贴图, 下面是导出:

-1- 保存:
    点击 image editor 窗口右上角 image - save as;
    注意, 这里保留默认的 color space: sRGB 不变, 直接保存文件;
    可看到法线贴图颜色是正确的;
    ---
    (和之前某些流程做法不一样)



































