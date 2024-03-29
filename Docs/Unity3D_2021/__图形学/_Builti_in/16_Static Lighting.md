# ================================================================ #
#               16 Static Lighting
# ================================================================ #




# ++++++++++++++++++++++++++++++++++++++++++++++ #
#          各种零碎的 源码值, 宏 的分析   (11.0 版)
# ---------------------------------------------- #


# ------------------------------:
# unity_Lightmap
# unity_LightmapST;
一个 texture, 和它得 _ST 信息;

    存储了 lightmap 信息; 
    注意 unity_LightmapST, 他不是 "_ST" 后缀;
    所以不能使用:

        i.lightmapUV = TRANSFORM_TEX(v.uv1, unity_Lightmap);

    来获得 lightmap 的 uv 值;. 只能写为:    

        i.lightmapUV = v.uv1 * unity_LightmapST.xy + unity_LightmapST.zw;

采样方式:

    indirectLight.diffuse = DecodeLightmap(
		UNITY_SAMPLE_TEX2D(unity_Lightmap, i.lightmapUV)
	);





# ++++++++++++++++++++++++++++++++++++++++++++++ #
#      lightmap 细节
# ---------------------------------------------- #
lightmap 由 unity 自己生成, 用户自定义的 shader 需要遵守一些细节:


# ----------------------- #
#  transparent 模式:
若某个物体的 material 是 transparent 模式, lightmap系统将只识别
名为 _Color 的 albedo颜色 和名为 _MainTex 的 texturre 的 alpha 通道;

所以对应的 material property 必须取这两个名字;

# ----------------------- #
#  cutout 模式:
若为 cutout 模式, lightmap系统将只识别名为 _Cutoff 这个 分解值;
必须取这个名字;



# ----------------------- #
# 相关文件:
    UnityStandardMeta.cginc  // standard shader 即调用此处 vs, fs 函数
    UnityMetaPass.cginc






# ----------------------- #
# Directional Mode:
启用了 Directional Mode 之后, unity 会去寻找所用的 shader 的:
"同时开启了 LIGHTMAP_ON 和 DIRLIGHTMAP_COMBINED 这两个 keywords 的 variant"

如果是在 前向渲染的 base pass 中, 通常可用:
    #pragma multi_compile_fwdbase
来一并包含它们;

如果是在 延迟渲染 的 "Deferred" pass 中, 可用:
    #pragma multi_compile_prepassfinal
来一并包含它们;


# multi_compile_prepassfinal:
    包含以下 keywords:
        LIGHTMAP_ON DIRLIGHTMAP_COMBINED DYNAMICLIGHTMAP_ON UNITY_HDR_ON 
        SHADOWS_SHADOWMASK LIGHTPROBE_SH. 

    它还编译了 不包含以上所有 keyword 的 variants   
    These variants are needed by PassType.LightPrePassFinal and PassType.Deferred.

    ---
    这个名字中的 prepass final 是啥意思:
    这是个历史问题, 涉及到 unity 4 之前的 legacy deferred lighting 管线;
    在此不展开


# ----------------------- #
# lightmap 中存储的内容:
lightmap 本质还是 texture, 只不过是场景中很多个 静态物体的 texture 的大集合;
单独针对某一个静态物体的话,
lightmap 中存储的就是, 这个静态物体表面的某个点上, 所受到的 "间接光漫反射部分"

即, 只要正确且简单地从 lightmap 中采样, 获得的数据, 就是这个 frag 的 "间接光漫反射部分";


# ----------------------- #
# 第二张贴图: Directional map 中的信息:
这张图的每个 texel, 都存储一个 方向向量(代模长)
代表了 静态物体表面的这个点上, 他所收到的 四面八方的 间接光漫反射光 中, 强度最大的那个方向,
其模长表示: 这个主方向的光,占据总体光的百分比;

提起了两张贴图的数据后, 可用 DecodeDirectionalLightmap(...) 来计算精确的 "间接光漫反射部分";

    使用此法可以表达 物体的法线贴图信息;
    
此法本身使用 "半兰伯特公式" 来计算最终的 "间接光漫反射部分":

# 半兰伯特公式:
     = lightColor * diffuseColor * ( dot(Normal,LightDir) * 0.5 + 0.5)



     











