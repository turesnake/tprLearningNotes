

# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#                    Color Adjustments  
# ---------------------------------------------------------------- #
部分原文翻译:

针对 传统照片,影像的 Color Adjustments 通常有三个步骤
-1-  color correction.
     目的是将画面调节成 人眼直接观察对象时 所能得到的效果
     这一步时用来弥补 拍摄设备的不足的

-2- color grading
    将画面调出 想要的氛围和视觉效果
    这一步和 写实,还原真实效果 无关, 和画面的情感效果有关.

-3- toneMapping
    将 HDR 颜色映射到 LDR 区间

# 上述的 1,2 两步, 被合称为 color grading.


如果只对原始 rt 执行 tonemapping, 画面会泛白,失去颜色感 
ACES 人为地增加了明暗对比度, 
所以 catlike 选择在 neutral tonemapping 基础上搭建 color grading



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#                    LUT
# ---------------------------------------------------------------- #
部分原文翻译:

对屏幕上每一个像素点 执行 post processing 成本很高. 
另一种方法是, 将 color grading 烘焙进一个 look up table, 然后在使用时对其进行采样. 

这个 LUT 通常是个 32x32x32 的 3D texture. 填充它,采样它的速度 是非常快的. 
URP 和 HDRP 都是用此技术. 


原始的 LUT 是个固定数据, 它存储了 "所有的 LDR 颜色".
x轴 red   [0,1]
y轴 greed [0,1] 
z轴 blue  [0,1] (在 2D LUT 中为很多层)


# LUT 技术的思路就是:
    与其对着一张 framebuffer 进行很多道 post-processing,
    不如对一组 "所有颜色值" 进行很多道 post-processing,
    最后对着 framebuffer 中的每个 frag, 访问那个被修改了很多次的 LUT,

具体可查找:
    GetLutStripValue();
    ApplyLut2D();








