# ================================================================ #
#            shader 编译优化技术
# ================================================================ #
主要记录 unity hlsl shader 中, 存在的各种 编译阶段会自动实现的 优化技术




# ---------------------------------------------- #
#     重复调用一个 函数, 会被自动优化
# ---------------------------------------------- #

void foo(){
    float3 color      = GetColor().rgb;
    float  smoothness = GetColor().a;
}

字面上, 这个函数调用了两次 GetColor(), 完全可以整合为一次调用.
但是这样写也是可以的, 因为 shader 编译器会识别出这个操作, 然后自动合并为一次 函数调用

Note that the SSE2 instruction set doesn't include a vectorized floor operation, 
so when limited to that instruction set you get four un-vectorized calls to a 
floor function instead, which is suboptimal.


# 更常见的是多次调用 tex2D() 等采样函数
    甚至将这些 采样函数写到不同的 函数中,
    或者写到一个函数内, 然后在不同地方 被调用很多次.
    这些都能被 编译器优化为 "只调用一次 tex2D()"



    













