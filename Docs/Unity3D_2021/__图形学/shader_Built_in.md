# ================================================================ #
#            shader Built-in 知识整理
# ================================================================ #
多数来源于 catlike: Rendering 教程




# ---------------------------------------------- #
#   光源类型相关的 宏:
#   DIRECTIONAL
#   DIRECTIONAL_COOKIE
#   POINT
#   SPOT
#   POINT_NOATT (这是干啥的..., 字面猜测是: 无衰减)
#   POINT_COOKIE
# ---------------------------------------------- #
由 unity 自己定义, 每执行某个 光照pass 时, 其使用的光源的相关宏就会被定义,
通过这些宏, 光照代码就知道自己正在处理 什么类型的光源;

想要使用这些 宏, 还需要再 shader 中通过:
    #pragma multi_compile DIRECTIONAL POINT

# 也可用 #pragma multi_compile_fwdadd 一次性包含以下宏:
#    POINT, DIRECTIONAL, SPOT, POINT_COOKIE, DIRECTIONAL_COOKIE.

定义好这些关键字的 variants;

_COOKIE 后缀的指的就是可以给光源增加一层 mask层, 制造类似剪影的效果


# DIRECTIONAL_COOKIE
如果为一个 平行光 增加一个 cookie, 则这个平行光将必须由 
"LightMode" = "ForwardAdd" 的 pass 渲染, 而不能由主 pass 渲染,
哪怕整个场景中只有这一盏 平行光; 

而且这个 "ForwardAdd" pass 中, 需要实现对应的 variant:
    #pragma multi_compile ... DIRECTIONAL_COOKIE ...




# ---------------------------------------------- #
#     宏函数: UNITY_BRDF_PBS(...) 
# ---------------------------------------------- #
内置 pbs 光照计算, 

内置多个版本, 支持不同性能的平台,最差时会退化为 Blinn-Phong;



# ---------------------------------------------- #
#     宏函数: UNITY_LIGHT_ATTENUATION(...)
# ---------------------------------------------- #
内置 光源衰减值 计算;
支持各种光源;

# 参数: destName
    用户可以自定义一个名字,比如 attenuation, 宏内会新建一个此名字的变量,
    存储本次计算出来的 衰减值

# 参数: input
    用来计算阴影值, 不想生成阴影时, 可传入 0;

# 参数: worldPos







