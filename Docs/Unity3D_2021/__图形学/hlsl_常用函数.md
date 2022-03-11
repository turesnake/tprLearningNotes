# ======================================================= #
#             unity hlsl 常用函数
# ------------------------------------------------------- #


# ------------------ #
#     clip();
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
    vector 被自动执行了转置, 变成了 行向量 (躺着)
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
#   rsqrt
ret rsqrt (x);

- hlsl
Returns 1 / sqrt(x)

# ------------------ #
#   rcp
ret rcp (x);

- hlsl
    Calculates a fast, approximate, per-component reciprocal.
    计算一个 快速的近似的 逐分量的 倒数;



# ------------------ #
#   trunc
T trunc (T x);

- hlsl
返回 参数分量的 整数部分 （原参数是否被改变 ？？？ ）

# ------------------ #
#   frac
T frac (T x);

- hlsl
返回 参数分量的 小数部分 （原参数是否被改变 ？？？ ）

# ------------------ #
#   lerp
ret lerp ( x, y, s );

- hlsl
线性插值: x*(1-s) + y*s

Lerp is shorthand for linear interpolation




# ------------------ #
#   reflect
ret reflect(i, n);

- hlsl
计算反射向量: ret = i - 2 * n * dot(i n) .

注意, 参数 i 虽为 "入射向量", 但它必须朝向 受光点 (和图形学中的 "入射角" 是反向的)
而返回值向量, 方向背离 受光点 (符合图形学惯例)



# ------------------ #
#   saturate
ret saturate(x);
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
#   clamp
ret clamp( x, min, max );

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



# ------------------ #
#   sign
int sign(x)

    若参数 x<0,     ret -1;
    若参数 x==0,    ret 0;
    若参数 x>0,     ret 1;



# --------------------------- #
#    函数   Load
# --------------------------- #
https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-to-load?redirectedfrom=MSDN
# ------
Load() 和 Sample() 相似, 不过没有 samplestate 和 filter, 就是单纯访问一个 texel 中的数据;

# ------
    ret texture.Load(
        typeX Location,
        [typeX SampleIndex, ]  可选
        [typeX Offset ]        可选
    );

类型 typeX 可以为i:  int, int2, int3 or int4;

必须是一个 texture 对象来调用, (但不能是 TextureCube or TextureCubeArray);

参数:
-- Location:
    texture coord, 不是传统 uv 值[0,1], 而是基于像素的 [0,w], [0,h]
    基于 texture obj 的类型不同, 本参数的 类型也不同;

    the last component specifies the mipmap level. 
    但是在 urp 使用中, 发现也可以完全不写这个 mip 分量;

    比如: 如果要采样一个 2D texture, 本参数的前两个分量存储 coords 信息, 
    第三个分量存储 mipmap lvl 信息;

    如果这个参数的任何一个分量月结了, Load() 返回一个向量, 它的每个分量都为0;


-- SampleIndex:
    An sampling index.
    仅被用于 multi-sample textures.
    ---
    tpr:
        如果要多次采样,比如采样4次, 那么此参数传入的就是 {0,1,2,3} 这种 idx 值;
        也许 系统内部根据这个 idx 的值, 会按照一定规律自动微调 coords 信息, 从而采样出周边 texel 的值;




-- Offset:
    An offset applied to the texture coordinates before sampling. 
    基于 texture obj 的类型不同, 本参数的 类型也不同;
    需要是 static 值 ???
    ---
    如果对 multi-sample textures 使用了本参数, 那么也必须使用参数 SampleIndex;



具体调用: texture.Load( unCoord2, sampleIndex );




# --------------------------------------- #
#    类型   Texture2DMS<Entry, samples>
# --------------------------------------- #
https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/sm5-object-texture2dms
(但是这个文档提供的信息很有限;)

首先, 这是一个类型, 类似 c++ 中的 class, 它只能调用它能调用的成员函数;
比起 Texture2D, 本类型主要用于 "支持 MSAA 的 texture";

不能对 Texture2DMS 类型的对象调用任何 "Sample" 系列的函数, 因为 msaa texture 不支持滤波, 或任何 常规 texture 支持的操作;
只能对本类对象调用 "Load()", 一次获得一个 subsample, 在调用此函数期间, 需要传入 参数 texture coords (不是uv, 是像素为单位的), 和 参数 sampleIndex, 来指示自己这次调用, 获得那个 idx 的 subsample 值;


# ----- 声明: -----
例如:
    Texture2DMS<float, 8> textureA;

元素类型为 float, MSAA lvl 为 8, (每像素采样8次)

# ------ 采样: ------
Texture2DMS::Load( int2 unCoord2, int sampleIndex );

本函数的行为和上面的 "Load" 中描述的几乎一致;
区别就是:
-- 参数 unCoord2 只要两个分量, 不需要传入额外的 mip lvl 信息;
-- sampleIndex 区间 [0,7]; (如果使用上方的声明);







































