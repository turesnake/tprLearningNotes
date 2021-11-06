# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ #
#   ld:
(sm4)

    ld[_aoffimmi(u,v,w)] 
        dest[.mask], 
        srcAddress[.swizzle], 
        srcResource[.swizzle]

是 sample 指令的简化版; 和 sample 不同, ld 指令可以从 buffer 采样数据; 在 fs 中, ld 还能从 multi-sample resources 中采样;

---
srcAddress:
    提供 texture coords 的集合, 形式为 unsigned integers;
    如果此值超出区间: [0...(#texels in dimension -1)], 将会触发 out-of-bounds 行为; 

    where ld returns 0 in all non-missing components of the format of the srcResource, and the default for missing components.

    ...待续...

























































