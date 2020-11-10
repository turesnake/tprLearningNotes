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


# --- 012 --- #
在 win 平台 安装 RenderDoc


# --- 013 --- #
brdf 学习：
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
阅读 manual: Occlusion culling

阅读 manual: Shadow
    RTR chapter 7: shadows

# --- 019 --- #
shadowCaster pass 几大疑问：
- shadow map 是哪里被新建的，哪里被写入的，哪里被传输进 gpu 的

- sample shadow map，采样出来的是一个 float 值
    它到底代表什么意思 ？



# --- 019 --- #
各种实际应用中的矩阵，是怎么推导出来的



# --- 020 --- #
《RTR》p-226:
    平面表达式：π:n·x+d=0
    这是啥意思



# --- 022 --- #
阅读 API: Plane



# --- 023 --- #
有关矩阵的 奇怪用法：
    fenglele: transform normalDir from tangent-space to WS


# --- 024 --- #
urp 中，是如何实现 normaldir tangent-space to WS 转换的 ？

urp 中 是否有用到 tengent 
    是如何使用的


# --- 025 --- #
彻底证实 positionSTS.xyz 的取值范围 是否是 [0,1]
目前这只是一个 猜测




# --- 027 --- #



