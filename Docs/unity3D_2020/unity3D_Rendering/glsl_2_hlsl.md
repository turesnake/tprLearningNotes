# ================================================================ #
#                    glsl to hlsl
# ================================================================ #





# ---------------------------------------------- #
#                  step
# ---------------------------------------------- #
# glsl hlsl is same:
    ret step( y, x);
    ---
    return (x[i] < y[i]) ? 0.0 : 1.0;
    假设 x,y 是 vector,matrix, 则返回值也是对应的类型
    针对每个分量做 独立的比较




# ---------------------------------------------- #
#              smoothstep
# ---------------------------------------------- #
# glsl hlsl is same:
    ret smoothstep(min, max, x)
    ---
    Returns 0 if x is less than min; 
    1 if x is greater than max; 
    otherwise, a value between 0 and 1 if x is in the range [min, max].
    ---
    注意，返回值区间是 [0,1]
    参数 min，max 只是用来和 参数 x 相互作用的 





