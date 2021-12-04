# ================================================================//
#                       unity3d 使用技巧
# ================================================================//

本文主要记录 urp 官方文档 中记录的那些知识


# ----------------------------------------------#
#             名词翻译
# ----------------------------------------------#

- depth of field:aperture -- 景深中的孔径
	aperture 越小，镜头中模糊的区域越大

- tilt shift effect -- 移轴特效  
	移轴摄影：就是通过夸张的景深效果，将正式城市，拍出微缩模型效果的技术

- tone mapping      -- 色调映射
	一个将 HDR 转化为 LDR 的过程

- auto exposure     -- 自动曝光

- motion blur       -- 运动模糊/动态模糊
- shutter angle     -- 快门角度

- volumetric rendering -- 立体渲染
	用来表现云

- scattering color     -- 散射色
- Chromatic Aberration -- 色差
- Color Grading        -- 颜色分级
- Lens Distortion      -- 透镜畸变
- Vignette             -- 渐晕
- Bokeh Depth of Field -- 波基景深 / 焦外景深

- BRDF -- 双向反射分布函数
	bidirectional reflectance distribution function
- BSDF -- 双向散射分布函数
	Bidirectional scattering distribution function
- BSSRDF -- 双向散射表面反射率分布函数
	bidirectional surface scattering reflectance distribution function

- subsurface scattering -- 次表面散射
- lambertian reflection -- 朗伯反射/完全漫反射

- incident ray         -- 入射射线
- reflected ray        -- 反射射线

- clearcoat            -- 透明涂层
- clearcoat gloss      -- 清漆光泽
- radial shear         -- 径向剪切

- azimuth angle        -- 方位角

- phong shading        -- 冯氏着色
- gouraud shading      -- 高洛德着色
- flat shading         -- 平面着色

- fudge factor         -- 经验系数

- umbra and penumbra   -- 本影 和 半影

- omni light           -- 泛光灯
- swivel light         -- 旋转灯


# ----------------------------------------------#
#     可编程渲染管线 / scriptable render pipeline
# ----------------------------------------------#

------
如何将现有项目 升级为 usrp ？
	-1- window - package manager - Universal RP - 安装这个包
	-2- project面板：
		create - Rendering - Universal RP - pipeline Assert
	-3- edit - project settings - graphics:
		将第一条 scriptable RP settings 选项，配置为上面创建的文件
		---
		这样设置以后，场景中部分模型会变成粉红色，这是正常的

	-4- edit - render pipeline - universal RP - upgrade project materrials...
		然后在跳出面板中点选 执行
		就能实现转换
		---
		你会发现，部分 unity 自定义的材质实现了转换，剩余的好像仍然是 粉红色



# ----------------------------------------------#
#        Volume Profile 模块种类
# ----------------------------------------------#
-- Bloom
	荧光效果/光晕
	也能用来制作 镜头污渍 效果

-- Channel Mixer
	通道混合器

-- Chromatic Aberration
	色差
	能形成 抖音 的那种边缘溢色效果

-- Color Adjustments
	色彩调整

-- Color Curves
	颜色曲线

-- Depth of Field
	景深
	-1- Gaussian 高斯景深
		适合低端设备
	-2- Bokeh    波基景深 / 焦外景深
		适合高端设备

-- Film Grain
	胶片颗粒

-- Lens Distortion
	透镜畸变

-- Lift Gamma Gain
	一共三个模块，Lift, Gamma, Gain

-- Motion Blur
	运动模糊/动态模糊

-- Panini Projection
	帕尼尼投影
	一种比较平缓的 广角投影（鱼眼）

-- Shadows Midtones Highlights
	阴影，中间调，亮部


-- Split Toning
	色调分离
	具体图像中的明度值，对不同区域做颜色处理
	---
	比如将暗处统一为蓝紫色，亮处统一为橙黄色

-- Tone mapping
	色调映射
	一个将 HDR 转化为 LDR 的过程

-- Vignette
	在画面四周形成一圈渐隐的颜色，比如变暗了

-- White Balance
	白平衡
	控制整个环境中的色温，来规定：到底什么颜色才是基准白色



# ----------------------------------------------#
#           shaders
# ----------------------------------------------#
本质上 Lit 是最全的shader，剩余的都是lit 的简化版
也可以自定义 shader

-- Lit
	默认shader，最大最全
	实时渲染

-- Simple Lit
	不依赖 pbr，轻量化

-- Baked Lit
	非实时，只是用 baked lighting 以及简单的 全局光照GI

-- Unlit
	彻底不想使用光照


# ----------------------------------------------#
#                skybox
# ----------------------------------------------#
-- assert 目录中，新建一个 mat，
	在 inspector 面板中
	将其顶部的 shader，设置为 skybox 中的一种
	---
	可以使用外部的 贴图素材
	也可以选择 procedural 来自动生成 
	---
	甚至还可以借助 Reflection Probe 来生成一个skybox
	具体为，先在一个场景中搭建好效果，然后用 反射探针+bake 来烘培一张贴图
	最后在 skybox - Cubemap 中，使用这张贴图
	这算是定制性最强的方法了

-- 然后在 Lighting 面板 - Environment 
    将其绑定到 skybox 链接上



# ----------------------------------------------#
#          Material - workflow mode
# ----------------------------------------------#
==1== Specular Mode
	可以看作是更为通用的模式，推荐使用
	重要参数：
	- specular map: 可以是贴图，或颜色
	- smoothness:   表面光滑度，越光滑，反射的景物越清晰 

==2== Metallic Mode
	倚重一个参数 Metallic，它的 specular 信息会被自己计算
	重要参数：
	- Metallic: 可以是贴图，或颜色
		记录材质 “有多像金属”，越像金属，反射的环境色越多，自身固有色越少
		当值为1时，全部反射环境色
	- smoothness:   表面光滑度，越光滑，反射的景物越清晰 

	CatLike 教程第三课: Directional Lights 中, 教授的就是 Metallic Mode


# keyword:  _SPECULAR_SETUP
通常会见到这个指令:

    #pragma shader_feature_local_fragment _SPECULAR_SETUP

它将为这个 shader 创造两种 variants, 分别支持 Specular setup 和 Metallic setup

# shader_feature_local_fragment
	是在 shader_feature 的基础上, 添加了 "_local" 和 "_fragment";
	前者表示 局部 keyword,
	后者表示 这个 局部keyword 仅在 fragment-shader 中起效;
		类似的后缀有: _vertex, _fragment, _hull, _domain, _geometry, or _raytracing


# ----------------------------------------------#
#           Material - 半透明
# ----------------------------------------------#
当选择半透明后，Blend Mode 有4种选择：
- alpha
	通过 基础色的 alpha 值来模拟半透明。适合表现云

- premultiply
	表现与 alpha 相似，但额外保留了 reflections 和 高光
	适合表现 玻璃

- additive
	在原有表面上，额外增加一层材质，适合表现 全息图

- multiply
	在此区域底色基础上，叠加一个颜色，整体显色会比较暗，
	适合表现 有色玻璃



# ----------------------------------------------#
#    Mesh Renderer 和 
#    Skinned Mesh Renderer 的区别
# ----------------------------------------------#
Skinned Mesh Renderer 专门用于 骨骼动画
所以，一个没有设置 bone 的模型，只会触发 Mesh Renderer

---
	在导入 fbx 文件时，如果unity 发现此模型绑定了bone，
	将自动创建 Skinned Mesh Renderer 组件
	如果发现没有bone，
	将自动创建一对: Mesh Filter + Mesh Renderer 组件。



# ----------------------------------------------#
#         如何只渲染 阴影，不渲染 模型
# ----------------------------------------------#
在 Mesh Renderer / Skinned Mesh Renderer 组件中
将 Cast Shadows 设置为 Shadows Only。



# ----------------------------------------------#
#     全局光照 / Global illumination (GI)
# ----------------------------------------------#
unity 含有两种 GI：
	-- Baked GI
	-- Realtime GI



# ----------------------------------------------#
#             如何制作 体积云
# ----------------------------------------------#

volumetric fog/mist/cloud -- 体积云/雾

car exhaust -- 汽车尾气
steam smoke -- 蒸汽机蒸汽
Fire Extinguisher -- 灭火器，这个插件，对发动机尾气的模仿最好

ray marching -- 光线步进

======== 制作思路
从喷口喷出时，应该用 粒子系统制作。
喷出之后，形成慢慢飘动的云雾。



# ----------------------------------------------#
#     如何将数据，从 cpu 传入 gpu
# ----------------------------------------------#

# -- 1 -- 
    Shader.SetGlobalFloat()
    ---
    可以设置 全局态的 properties，
    每个 shader 都能访问到它

# -- 2 --   
    Material.SetFloat()
    Material.GetFloat()
    ---
    与 特定的 shader 进行通信，传输 property


# -- 3 --
    ScriptableRendererFeature
    ---
    更复杂，更高级的 控制方式









