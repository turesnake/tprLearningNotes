# ================================================================ #
#           Standard shader 细节
# ================================================================ #
零散地整理一些 源码关键词 函数名 的信息;

推荐阅读:
    https://zhuanlan.zhihu.com/p/87932071




# ++++++++++++++++++++++++++++++++++++++++++++++ #
#  一些  shader variant keywords
# ++++++++++++++++++++++++++++++++++++++++++++++ #
想要细看这些 keyword 的定义, 可以去查找 StandardShaderGUI.cs 文件;
它定义了这些内容;


# _NORMALMAP:
    生成一个支持 法线贴图的 variant; (并且启用这个 keyword)

# _ALPHATEST_ON 
# _ALPHABLEND_ON 
# _ALPHAPREMULTIPLY_ON
    当 Rendering Mode 分别选择:
        Cutout
        Fade
        Transparent 
    时, 生成对应的 variant; (并且启用对应的那个唯一的 keyword)

# _EMISSION
    此 Variant 是否开关，与 _EmissionMap 这张贴图毫无关系，
    从 StandardShaderGUI 的代码中可以看到，其取决于GI的设置：
        bool shouldEmissionBeEnabled = 
            (material.globalIlluminationFlags & MaterialGlobalIlluminationFlags.EmissiveIsBlack) == 0;
        SetKeyword(material, "_EMISSION", shouldEmissionBeEnabled);

    即，该 variant 的开关与否取决于当前GI的设置，
    当GI的设定为：这个物件的自发光信息不会去影响 GI（lightmap系统）的时候，_EMISSION 会被打开，否则关闭。


# _METALLICGLOSSMAP
    当 WorkflowMode 为 Metallic，且使用了_MetallicGlossMap 的时候，这个宏会被打开，否则则关闭。

# _DETAIL_MULX2
    当使用了_DetailAlbedoMap 或者 _DetailNormalMap 的时候，这个宏会被打开，否则则关闭。

# _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
    此 variant 的开启与否, 取决于 smoothness 这个值被存储在哪张 texture 中;
    此选项可在 inspector: Smoothness 下一行的 Source 中选择:
        --- MetallicAlpha
        --- AlbedoAlpha
    从字面上看, 当选择存储在 albedo texture 中时, 此keyword 才会被开启...
    和文章中的描述相反;


# _SPECULARHIGHLIGHTS_OFF
# _GLOSSYREFLECTIONS_OFF
    文章作者无论在哪里，都没找到 Unity打开了它俩，
    所以，除非用户自己去打开，否则这个宏永远处于关闭状态，也就是个废了的ShaderVariant吧。

# _PARALLAXMAP
    当使用了_ParallaxMap 的时候，这个宏会被打开，否则则关闭。
    ---
    视差贴图，又称 高度贴图，法线贴图 的改进版，一个经常被忽略的高级功能。
    
    在观察边缘时, 视差贴图也能便显出高低;
    原理是根据该点的高度以及该点指向摄像机的向量，计算出一个 UV偏移，来影响之后的采样。

    而在这里，就是先取到该点到摄像机的向量。


# ++++++++++++++++++++++++++++++++++++++++++++++ #
#  struct VertexInput; 部分
# ++++++++++++++++++++++++++++++++++++++++++++++ #

# DYNAMICLIGHTMAP_ON:
    catlike:
        当需要使用 dynamic light map (realtime lightmap) 时, 
        unity 会挑选那个带有本 keyword 的 shader vatiant 来使用;
    ----
    Lucifer:
        对应 realtime GI，(就是那个好像要被废弃和重写的那个 实时GI... )

        当 realtime GI 打开的时候，该宏会被打开，同时会有最多两张用于表示 realtime GI lightmap 的贴图被赋值
        （此 LightMap 非彼 Lightmap，相信很多人从来没注意过这套realtime GI lightmap，下面会详细介绍），
        作为环境光的diffuse部分，参与渲染。

# _TANGENT_TO_WORLD:

    当 _NORMALMAP, DIRLIGHTMAP_COMBINED, _PARALLAXMAP 其中一个宏被打开的时候会被打开。
    原理也比较简单，就是 normalmap 那一套，这里也就不多说了。
    ---
    猜测和 切线空间 到 ws 的转换有关;

# UNITY_PASS_META
    主要用于 meta pass，用于烘焙 Lightmap、GI;


# ++++++++++++++++++++++++++++++++++++++++++++++ #
# "ForwardBase" vertex shader:
#   vertForwardBase (...);
# ++++++++++++++++++++++++++++++++++++++++++++++ #


# ---------------------------------- #
# UNITY_TRANSFER_LIGHTING (...);
#define UNITY_TRANSFER_LIGHTING( a, coord ) COMPUTE_LIGHT_COORDS(a) UNITY_TRANSFER_SHADOW(a, coord)

    -----
    Lucifer 原文:
    阴影计算，这里主要是去计算采样阴影贴图时所需要的 texture coord;
    
要分如下4种情况处理：
-1- 
    SHADOWS_SHADOWMASK，
    即, 若使用了 Shadowmask，那么问题就简单了，阴影直接从 SHADOWS_SHADOWMASK 这张贴图获取即可，
    所以需要做的就是获取该像素点在 shadowmask 贴图上的 texture coord，即代码：
        a._ShadowCoord.xy = coord * unity_LightmapST.xy + unity_LightmapST.zw;
-2-
    UNITY_NO_SCREENSPACE_SHADOWS，
    也就是没有打开 ScreenSpaceShadowmap，那么我们就需要直接从 Shadowmap 中获取Shadow信息，
    也就是需要先将该像素点转移到光源空间，即代码：
        a._ShadowCoord = mul( unity_WorldToShadow[0], mul( unity_ObjectToWorld, v.vertex ) );
-3-
    如果打开了ScreenSpaceShadowMap，
    那么就简单了，阴影直接从 SSSM 这张贴图获取即可，而这个贴图的纹理坐标也就是屏幕空间，
    通过代码获取该点的屏幕空间坐标即可，即代码：
        a._ShadowCoord = ComputeScreenPos(a.pos);
-4-
    SHADOWS_CUBE，
    也就是说当前光照为 point光 的时候，那么对应的纹理坐标为3d的，即代码：
        a._ShadowCoord.xyz = mul(unity_ObjectToWorld, v.vertex).xyz - _LightPositionRange.xyz;
    =====









# ---------------------------------- #
# VertexGIForward (...):
o.ambientOrLightmapUV = VertexGIForward( v, posWorld, normalWorld );

    是更有意思的 GI，共分4种情况:
-1-
    LIGHTMAP_ON，
    也就是当前绘制的物件打开了 LightMap static，且场景中有光源的属性为 Mixed 或者 Baked，
    且已经进行了光照烘焙，生成了若干张 LightMap。在这种情况下，我们认为影响该物件的间接光 diffuse 部分
    是由 Lightmap 提供，所以需要获取到该像素点对应的 lightmap 中的信息，而该点对应的 lightmap 中的
    纹理坐标 也就是大家熟知的 2U，加上大家熟知的纹理坐标计算公式，即代码：
        ambientOrLightmapUV.xy = v.uv1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
-2-
    UNITY_SHOULD_SAMPLE_SH，
    当以上所描述的情况都没有发生，即：
        要么物件没有打开 LighMap static，
        要么场景中没有 Mixed/Baked 的光源，
        要么还没有进行光照烘焙。
    我们就会认为影响该物件的 间接光 diffuse 部分来自于 球谐光照。
-3-
    VERTEXLIGHT_ON，
    当 UNITY_SHOULD_SAMPLE_SH 被打开，且场景中有可以影响到该物件的顶点光源的时候。这个宏会被打开，
    根据最基本的 NdoL 公式，计算出最多四展顶点光源对该点的影响，与同上球谐得到的结果相加，作为影响该物件的
    间接光diffuse部分。
-4-
    DYNAMICLIGHTMAP_ON，
    正如上文中提到的，如果打开了 realtime GI，该宏会被打开，同时会有最多两张用于表示 realtime GI lightmap 
    的贴图被赋值，作为环境光的diffuse部分，参与渲染。那么，在这里，就要生成对应 realtime GI lightmap 的纹理坐标了，
    即代码：
        ambientOrLightmapUV.zw = v.uv2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;



# ++++++++++++++++++++++++++++++++++++++++++++++ #
# "ForwardBase" frag shader:
#   fragForwardBaseInternal (...);
# ++++++++++++++++++++++++++++++++++++++++++++++ #


# ---------------------------------- #
# UNITY_APPLY_DITHER_CROSSFADE( i.pos.xy );

    LOD group相关，这个特别容易被忽略，个人觉得这个功能确实弊大于利。

    用法是：当物件被添加了LOD group，且 Fade Mode 选择“Cross Fade”，这个宏会被打开。
    然后会根据物件在屏幕空间的坐标，做一定的运算后去采样 _DitherMaskLOD2D 贴图，根据采样的alpha通道，进行alpha test。
    所以，作用也就是随着越来越远，最终消失。

    然而想要实现这个功能的办法很多，这里还用到了传说中的 alpha test，
    不管硬件使用的优化方案是 early Z 还是隐藏面消除，都会被disable。
    所以如果用 LOD group 的话，Fade Mode尽量还是不要选择 “Cross Fade” 吧。
    

# ---------------------------------- #
# FRAGMENT_SETUP(s)

    首先，先根据是否有 视差贴图，计算出最终版本的 UV信息，
    然后获取 alpha值，并根据是否打开了 Alpha Test，进行 clip，这些都比较简单。

    下面就是比较复杂的物件PBS信息计算，这里就要区分standard的三大工作流了，
    本文章选择使用了 Metallic 工作流，两种SmoothnessMapChannel ，我们选择了SpecularMetallicAlpha。
    
    所以，在这里，我们先根据刚才得到的 UV信息，从 _MetallicGlossMap 贴图的 r通道和 a通道 中获取到 金属度值 和 smooth值。
    
    获取了物件的 金属度 和 粗糙度 并没有实际意义，因为我们知道 PBS 所需要的是物件的 diffuseColor 和 specColor，
    从而能够跟光照的 diffuse 部分和 specular 部分通过 BRDF 得到最终的 PBR 渲染结果的。
    所以，下面，我们要去获取物件的d iffuseColor 和 specColor。
    specColor很简单，就是根据 金属度的高低，直接从 unity_ColorSpaceDielectricSpec 和 albedo中进行插值。
    可以想象，当金属度为1的时候，物件的 specColor 就是物件本身的albedo，这个没问题，比如黄金的specColor是黄色，
    白银的specColor是白色，就是这个道理。
    而金属度为0的时候，specColor 就是 unity_ColorSpaceDielectricSpec，在linear空间就是 half4(0.04, 0.04, 0.04, 1.0 - 0.04)，
    也就是几乎没有，这个也可以理解，毕竟非金属的东西，主要都是diffuseColor。

    diffuseColor也很简单，albedo * （1 - metallic） * unity_ColorSpaceDielectricSpec.a。
    我们知道linear空间下，unity_ColorSpaceDielectricSpec.a 为0.96，那么纯金属的diffuseColor为0，
    非金属的diffuseColor约等于albedo，这个也就很容易理解了。


# ---------------------------------- #
# FragmentGI :
UnityGI gi = FragmentGI (s, occlusion, i.ambientOrLightmapUV, atten, mainLight);

    计算 GI，因为前面准备好了物件的PBS信息、直接光照信息，那么在这里，就是在准备间接光照信息。
    而间接光照信息分为两部分，diffuse 和 sepcuar。
        diffuse部分，来自于 lightmap/SH，
        specular部分，来自于 reflectionProbe/skybox。

    准备了一些变量后，直接进入核心代码
    UnityGlobalIllumination (d, occlusion, s.normalWorld, g);
    首先，先计算间接光照的diffuse部分，分为3种情况
    -1-
        UNITY_SHOULD_SAMPLE_SH，
        也就是物件没有使用Lightmap，则间接光的diffuse部分直接从球谐光照获取。
    -2-
        LIGHTMAP_ON，
        物件使用了lightmap，则间接光的 diffuse部分 从lightmap中获取。
        其中如果开启了DIRLIGHTMAP_COMBINED，也就是说LightMap的DirectionMode为Directional，
        则就会多一张包含了光照方向的光照贴图，然后在计算间接光的diffuse的时候会进行一次NdoL操作，
        这样的结果也就更加准确。其实，用户还可以根据自己的需要充分利用这张光照方向贴图，比如进行高光的计算。
    -3-
        DYNAMICLIGHTMAP_ON，
        也就是打开了 realtime GI，这样的话，又会多一套realtime GI lightmap，计算方式同上，
        计算的结果也将加入间接光照的 diffuse部分

    之后，会再乘以得到的 AO，可以看到, standard shader 的 AO 并不影响直接光照，而只影响间接光照。

    下面是间接光照的specular部分：
    specular部分就相对简单了，来源就是 reflectionprobe或者skybox，
    需要注意的只有三点：
    -1-
        我们会该点的 光滑度 计算出一个 mip等级; 绝对清晰就是说mipmap趋于0 (使用尺寸最大的那一层)，
    -2-

        不管是 反射探针 还是 skybox，其本质上它使用的是 cubemap，保存它周围的环境信息。
        可以使用 box projection 来获得 精确反射;
        也就是打开了这里的宏 UNITY_SPECCUBE_BOX_PROJECTION
    -3-
        如果打开了blend，则会打开宏 UNITY_SPECCUBE_BLENDING，也就会采样2个cubemap的信息，进行blend。
    
    之后，还是会再乘以得到的AO，所以间接光照完全受到了AO的影响。到这里，间接光部分也就全部结束了。


















