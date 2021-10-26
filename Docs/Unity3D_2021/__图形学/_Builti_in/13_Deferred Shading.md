# ================================================================//
#               13 Deferred Shading
# ================================================================//


# -- 只有在 gpu 支持向 multiple render targets 写入数据时, 此平台才支持 延迟渲染;
所以要为 延迟渲染 pass 添加指令:

    #pragma exclude_renderers nomrt

此指令含义为: 如果目标平台不支持 multiple render targets, 就停止编译本 shader pass
nomrt: 看起来像是: "no multiple render targets"




# -- 如何进入 延迟渲染模式:
先修改 project settings - Graphic - 某个 Tiers,比如 High - Rendering Path;
再修改 inspector: camera - Rendering Path;

(但是好像只修改 camera 也能行 ??? )


# -- 对光源的支持:
每个灯都是 逐像素的, 也都能影响任何一个物体, 不受到 Pixel Light Count 的限制;



# -- inspector: camera - HDR:
    如果此项选择 off, 则在延迟渲染过程中, 使用 LDR 来存储光照信息, 此时会采用 ARGB32 texture 格式,
    这个数值存储空间显然是不够的, 所以 unity 选择在 延迟渲染的过程中, 将这个颜色值 进行 log编码,
    使得它拥有更大的 动态区间, 然后在最后一个pass 中, 将这些值再解码回 常规的颜色值;

    所以此时, Frame Debug 中看到的 颜色都是反向色;
    ---
    如果开启 HDR, 则不会存在这个 编码解码过程, 整个 延迟渲染过程中, 都使用 HDR 值记录颜色;
    此时使用 ARGBHalf 格式;

    



# --------------------- #
#  G-Buffers:
    需要 4 张 texture, 每个像素, LDR模式存储 160-bits信息, HDR模式存储 192-bits信息

    可在 scene 窗口中查看 gbuffer 信息, 左上角显示模式中, 分别为:
    albedo, specular, smoothness, normal

    也可在 Frame Debug 界面中, 找到: RenderDeferred.GBuffer 区域, 
    这里记录了 gbuffer 的信息, 可在右侧 RenderTarget 中查看, 
    RT0, RT1, RT2, RT3, Depth,  
    以及各个 gbuffer 的  rgba 通道信息;




# ++++++++++++++++++++++++++++++++++++++++++++++ #
#        G-Buffers 中用到的几种 texture 存储格式:
# ---------------------------------------------- #

# ARGB32:
    每通道 8-bits;

# ARGB2101010:
    a通道 2-bits, rgb通道各 10-bits;
    通常用来存储 高精度的 rgb值, 比如 法线信息, 然后把 a通道闲置;

# ARGBHalf:
    每通道 16-bits, 共 64-bits;
    常用于 HDR 模式;




# ++++++++++++++++++++++++++++++++++++++++++++++ #
#          各种零碎的 源码值, 宏 的分析   (11.0 版)
# ---------------------------------------------- #





