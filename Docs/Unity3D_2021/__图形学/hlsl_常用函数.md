# ======================================================= #
#             unity hlsl 常用函数
# ------------------------------------------------------- #


# ------------------ #
#     clip()
仅在 frag shader 中调用的函数, 立即终止渲染此 fragment

    clip( alpha - 0.5 );

    若此 frag 透明度小于 0.5; 终止渲染它;


# ------------------ #
#      归一化函数
# real3 SafeNormalize (float3 inVec);
- Common.hlsl [core]
就是普通的 normalize 的 safe 版
规避了 除零 问题. 比如当 参数向量的模长很小, 或干脆就是零向量时. 

当参数向量的模长非常小时, 本函数将模长强制设置为 FLT_MIN, (最小浮点数). 一个很小,但不为0数.
然后执行 模长除法. 返回单位向量.

如果参数为 零向量, 这个函数不会引发 除零 问题, 最终返回的向量, 仍为零向量.


# ret normalize (x);
- hlsl
在这种最原版的实现中，当 向量长度==0，返回的结果是 indefinite




# ------------------ #
#  标量/向量/矩阵 乘法
#   ret mul(x,y)
使用 矩阵数学 来执行乘法,

若参数 x 为向量, 它必须为 行向量 (左乘)
若参数 y 为向量, 它必须为 列向量 (右乘)

# 参数 x, y 可为 标量/向量/矩阵 中的一种
微软 hlsl 文档给出了详细解释.
此处只贴出几种重要的


# -- mul( matrix, vector )  右乘
    最主流的用法
    此时的矩阵, 就是我们预期的 列矩阵 (没做任何变化)


# -- mul( vector, matrix )  左乘
    vector 被自定执行了转置, 变成了 行向量 (躺着)
    此时的矩阵, 依然是我们预期的 列矩阵 (没做任何变化)

    有时会使用:
        mul( V, M的逆矩阵 ) 
    来代替:
        mul( M的逆转置矩阵, V )

    因为前者更简单, 只需准备好 原变换矩阵的 逆矩阵即可, 不需要再准备 逆转置矩阵.
    这一技巧被用于 非统一缩放时的 法线 的空间变换.



# ------------------ #
# int   asint   ( T x );
# float asfloat ( T x );
- hlsl
Interprets the bit pattern of x as an integer / floating-point
不是简单的 cast 操作

# ------------------ #
# ret rsqrt (x);
- hlsl
Returns 1 / sqrt(x)

# ------------------ #
# ret rcp (x);
- hlsl


# ------------------ #
# T trunc (T x);
- hlsl
返回 参数分量的 整数部分 （原参数是否被改变 ？？？ ）
# T frac (T x);
- hlsl
返回 参数分量的 小数部分 （原参数是否被改变 ？？？ ）

# ------------------ #
# ret lerp ( x, y, s );
- hlsl
线性插值: x*(1-s) + y*s

Lerp is shorthand for linear interpolation




# ------------------ #
# ret reflect(i, n);
- hlsl
计算反射向量: ret = i - 2 * n * dot(i n) .

注意, 参数 i 虽为 "入射向量", 但它必须朝向 受光点 (和图形学中的 "入射角" 是反向的)
而返回值向量, 方向背离 受光点 (符合图形学惯例)



# ------------------ #
# ret saturate(x);
Clamps the specified value within the range of 0 to 1.




# ------------------ #
#  max(a,b);

max( -inf, -inf )   -> -inf;
max( -inf, F )      -> F;
max( -inf, +inf )   -> +inf;
max( -inf, NaN )    -> -inf;
max( F, F )         -> F;
max( F, +inf )      -> +inf;
max( F, NaN )       -> F;    
max( +inf, +inf )   -> +inf;
max( +inf, NaN )    -> +inf;
max( NaN, NaN )     -> NaN;
-----------
注:
    F: 合理区间内的 有限实数,(也就是普通值)

# 遭遇参数为 "除零"
    除零将导致 NaN, 纵观上表, 如果一个参数为 NaN, 另一个非 NaN,
    则返回的一定是另一个参数;
    ---
    所有, 只要保证只有一个参数会出现 除零, 那么最终一定会返回一个 非NaN 值;
    ---
    若两参数都为 NaN, 则返回 NaN



# ------------------ #
#  min(a,b);

min( -inf, -inf )   -> -inf;
min( -inf, F )      -> -inf;
min( -inf, +inf )   -> -inf;
min( -inf, NaN )    -> -inf;
min( F, F )         -> F;
min( F, +inf )      -> F;
min( F, Nan )       -> F;
min( +inf, +inf )   -> +inf;
min( +inf, NaN )    -> +inf;
min( NaN, NaN )     -> NaN;
-----------
注:
    F: 合理区间内的 有限实数,(也就是普通值)

# 遭遇参数为 "除零"
    除零将导致 NaN, 纵观上表, 如果一个参数为 NaN, 另一个非 NaN,
    则返回的一定是另一个参数;
    ---
    所有, 只要保证只有一个参数会出现 除零, 那么最终一定会返回一个 非NaN 值;
    ---
    若两参数都为 NaN, 则返回 NaN




# ------------------ #
# ret clamp( x, min, max );

    将参数 x, 约束在 min, max 之间;
 

# ------------------ #
# tex2Dlod
float4 tex2Dlod( sampler2D s, float4 t);

    Samples a 2D texture with mipmaps. 
    The mipmap LOD is specified in t.w.
    ------

    使用 t.xy 去对 s (一个 2d mipmap texture)进行采样, 
    同时, t.w 指定了使用的 lvl 层级, 

    比如 t.w=2.5, 意味着需要采样 lvl=2 和 3 两层, 
    然后根据设置的 filter mode, 采用不同的混合器 去混合这两个值;

# ------------------ #
# tex2Dbias
float4 tex2Dbias( sampler2D s, float4 t);

    Samples a 2D texture after biasing the mip level by t.w.
    ------

    使用 t.xy 去对 s (一个 2d mipmap texture)进行采样, 
    同时使用 t.w 去对 已经计算出来的 mip lvl 值 做偏移;

    比如, t.w=2.5, 意味着不管你在这个 fragment 中计算出来的 lvl 值是多少,
    都要再累加一个 2.5, 然后再去采样和混合;

    偏移值为正数, 最后选用的 mip 层就会更模糊,
    偏移值为负数, 则更清晰;

    此处 tex2D 选用的 mip lvl 是通过 ddx,ddy 之类的工具 自动算出来的;










