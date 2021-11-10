# ================================================================ #
#    Realtime Global Illumination using Enlighten
# ================================================================ #

至少在 2021.2 版本之后, Enlighten 这个 "实时GI" 技术又回归了...
本质上它是一个 第三方库;

以下仅对 官方文档 中的部分内容做翻译;


# ----------------------------------------------------------- #
#   How Enlighten Realtime Global Illumination works
enlighten 将场景分割为很多小的 surface patches, 并确定这些 patches 之间彼此可见的程度;
(以上这些实在 烘焙阶段 执行的)

在运行时, enlighten 使用这些预计算的 可见性信息 来估算 实时光线在场景中 是如何反弹的; 将计算的结果存储在 一组 lightmap 中, 并使用这些数据来实现 间接光照;

因为更新这些 lightmaps 需要大量计算, 所以每一次计算流程都需要分摊到数帧中去执行; 


# ----------------------------------------------------------- #
#   Light Probes and Enlighten Realtime Global Illumination
当开启 enlighten, light probes 的行为会变得不一样;

为了回应光源在运行时的变化, light probe 也会在运行时不停地执行采样;

当关闭了场景中地 enlighten, light probes 将只使用烘焙好的信息;
且也不会响应 运行时的 动态光源变化;


# ----------------------------------------------------------- #
#   Shadows and Enlighten Realtime Global Illumination
...

enlighten 也会实现 软阴影, 除非那个场景很小 (?)
这个阴影 通常比较粗颗粒度;


# ----------------------------------------------------------- #
#   Performance considerations
启用 enlighten 会增加内存消耗, 即便你将它和 烘焙的GI 一起使用时也是;

因为 enlighten 要对 lightmap 和 light probe 做额外的采样, 所以shader 运算量上也会增加;


# ----------------------------------------------------------- #
#   Optimizing Enlighten Realtime Global Illumination
如果 enlighten 不能很快相应 光线的变化, 有几种方法可以解决这个问题:
--
    降低 "实时lightmap" 的分辨率;
--
    在 quality setting 窗口中增加 "实时GI" 占用的 CPU 算力比例
    "CPU Usage";
    此法的缺点就是, 其它系统占用 cpu 的比重就降低了; 所以要根据项目做权衡; 
    这是一个 逐场景 设置;

# ----------------------------------------------------------- #
#   Disabling the default environment contribution
默认情况下, unity 会自动生成一个 ambient probe 和一个 default Reflection Probe 来确保环境光能影响场景, 

要在 "没有手动创建 lightmap 和 light probe 的场景或物体的光照结果" 中禁用环境贡献，请禁用 default Reflection Probe
 and the ambient probe.

 更多信息可查看: 
 https://docs.unity3d.com/2021.2/Documentation/Manual/using-skymanager.html#disableskymanager 








































































