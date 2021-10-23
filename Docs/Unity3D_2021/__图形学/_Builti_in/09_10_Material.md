# ================================================================//
#                    Material
# ================================================================//



# ++++++++++++++++++++++++++++++++++++++++++++++ #
#      向 material 写入 keyword
# ---------------------------------------------- #

    catlike 是在 custom material GUI class 中设置 keywords 的,
    不知在别的位置是否也可行

# 声明:
Material.EnableKeyword( string keyword );
Material.DisableKeyword( string keyword );



# 检查 keyword 是否被开启:
bool Material.IsKeywordEnabled( string keyword );



# ++++++++++++++++++++++++++++++++++++++++++++++ #
#      查看 material 当前写入的 keywords
# ---------------------------------------------- #
将 inspector 模式从 Normal 改为 Debug;

然后查看 Shader Keywords 一栏

若有多个 keywords, 会在这一栏中 连续显示, 甚至会超出行显示范围,
需要复制取出后到 txt 中查看才行...




# ++++++++++++++++++++++++++++++++++++++++++++++ #
#    将 Metallic Map 和 Smoothness Map 存储到一张 texture 中
# ---------------------------------------------- #

通常, R通道存储 Metallic 信息,
    A通道存储 Smoothness 信息,
    (GB通道无要求, 一般也会写入 Metallic 信息, 所以整张图是黑白灰色的)

这样做是为了配合 DXT5 压缩存储技术, 在 DXT5 技术中, RGB 和 A 是分开压缩的;

在 standard material 中, 这张联合 texture, 会被传入  Metallic map 中去;
catlike 也选择这样做;
(这也是为什么, Smoothness 位置不存在 texture 绑定接口)




# ++++++++++++++++++++++++++++++++++++++++++++++ #
#    将 Smoothness Map 整合进 Albedo map 中去 (A通道)
# ---------------------------------------------- #

对于全实心物体来说,  Albedo map 的 A通道是无用的,
如果恰好这个 material 并不需要 Metallic map (而是改用全局统一的 Metallic 值)

那么此时, 就可把 smoothness map, 放进 Albedo map 的 alpha通道中;

standard shader 也支持这个操作;

material inspector 中存在一个选项: Source, 可以在两种模式中二选一



# ++++++++++++++++++++++++++++++++++++++++++++++ #
#           Occlusion Map
# ---------------------------------------------- #

法线贴图是无法表达 纹理细节的阴影的, Occlusion Map 可以适当弥补这个缺陷

texel 存储一个灰度值 [0,1], 其代表的含义仍然是 "光线衰减值", "光照通过量";
0 表示完全遮蔽, 1 表示光线彻底通过;

这个值存储在 G通道中;

但是它的效果是比较微弱的, 不可能表达明确的阴影, 而是只能让 凹坑内的亮区 变得暗一些;

standard shader 和 catlike 都选择只让 Occlusion Map 影响 简洁光( 镜反部分,漫反射部分 都影响 )



# ++++++++++++++++++++++++++++++++++++++++++++++ #
#  将三种贴图信息, 整合到一张 texture 中:
#       Metallic Map   (R)  
#       Occlusion Map  (G)
#       Smoothness Map (A)
# ---------------------------------------------- #

按照 DXT5 的压缩规范, metallic 和 occlusion 信息会被压缩到同一个渐变值中,
这因为着这两个 map 的画质会降低, 不过这种画质降低 是不容易看出来的;



# ++++++++++++++++++++++++++++++++++++++++++++++ #
#        Detail Mask Map
# ---------------------------------------------- #

选择是否使用 detail map 信息的 mask map;
存储在 A通道;



