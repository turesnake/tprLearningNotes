# ================================================================ #
#                    unity3d 学习进度
# ================================================================ #



# --- 008 --- #
部分 shader 在 imac 中无法正常允许，需要到 pc 中调试
比如 geometric shader


# --- 009 --- #
光照衰减 纹理查找表： Lookup Table LUT 
去 manual 中学习这方面的知识


# --- 010 --- #
学习 ScriptableWizard 的使用


# --- 011 --- #
写个 shader，体验下 : SampleDebugFont() 这个函数 到底怎么用
在 Debug.hlsl 中 


# --- 012 --- #
在 win 平台 安装 RenderDoc


# --- 013 --- #
几种实现 brdf 的方法：
Cook-Torrance 库克-托伦斯
    貌似是表现最好的

Torrance-Sparrow 微面元模型


Ward Isotropic 
    据说 Ward 在表现 各向异性 材质时最好

microfacet distribution fit
    比 ward 更好的，表现 各向异性 的材质

Lafortune Lobe

GGX -- 法线分布函数 （Trowbridge-Reitz 法线分布函数）

Beckmann -- 法线分布函数



# --- 014 --- #
lele  chapter-18


# --- 015 --- #
什么叫做 lobe ？？？ 波瓣
（出现在 brdf 中）
一些材质使用 a single lobe 无法很好的表现
需要多个 lobe 才行



# --- 016 --- #
为什么 菲涅尔 公式中，要使用 sin值 
为什么是 sin ？？？
《Real-Time Rendering》p-319



# --- 018 --- #
ScriptableObject



# --- 019 --- #

