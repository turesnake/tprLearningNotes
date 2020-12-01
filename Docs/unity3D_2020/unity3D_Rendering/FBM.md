# ================================================================ #
#                     FBM  分形布朗运动
# ================================================================ #




# ---------------------------------------------- #
#           基础入门公式  [glsl]
# ---------------------------------------------- #
// Properties
const int octaves = 6;
float lacunarity = 2.248;
float gain = 0.716;       
//
// Initial values
float amplitude = 0.5;
float frequency = 1.;
//
// Loop of octaves
for (int i = 0; i < octaves; i++) {
	y += amplitude * noise(frequency*x);
	frequency *= lacunarity;
	amplitude *= gain;
}

# octaves
    八度
    说白了就是嵌套几层循环
    此值通常大于 3（或大于4）
    值越大，图形多出一级 更为微小的细节

# lacunarity
    间隙度   [1,+inf]
    每一次 fbm 循环，都会被 累乘进 frequency
    所以，它和 图形细节的 间隙密度有关
    值越大，会生成越多细节

# gain
    增益  [0,1]
    每一次 fbm 循环，都会被 累乘进 amplitude
    所以，它和 图形细节 的锯齿锐利度有关
    值越大，细节越锋利，且超 Y+ 方向生长

# frequency, amplitude
    由上文可知，每深入一层，
    frequency 会变得越来越大
    amplitude 会渐渐变小


# ---------------------------------------------- #
#       Ingo Quilez 介绍的 基础公式 [shadertoy]
# ---------------------------------------------- #
参见：
    https://iquilezles.org/www/articles/fbm/fbm.htm

float fbm( in vecN x, in float H )
{    
    float G = exp2(-H); // gain
    float f = 1.0;      // frequency
    float a = 1.0;      // amplitude

    float t = 0.0;      // ret val

    for( int i=0; i<numOctaves; i++ ){
        t += a*noise(f*x);
        f *= 2.0;
        a *= G;
    }

    return t;
}
# 参数 H 
# Hurst exponent, 赫斯特指数
观察: float G = exp2(-H);
    它返回 2 的 -H 次方。
    此曲线：
    exp2(0) = 1;
    exp2(1) = 0.5;
    exp2(2) = 0.25;
    之后 H 每增大1，结果就缩小一倍。

# H 该取什么值:
从上节可知，gain 的取值范围是 [0,1]
由此可知，参数 H 的合理取值范围是 [0, +inf], 通常为 [0,10]

但在 iq 的文中，推荐 H:[0,1], 此时 G:[1,0.5]

当 H=0.5, 此时 G=0.707107
    会生成一个 anisotropic self-similarity FBM
    [各项异性]
    即，在将这个图形放大的过程中，图形的 xy方向的比例会出现拉升，
    但在 放大倍率达到 2 倍时，确实又能获得 与原自身相似的图形。

当 H=1, 此时 G=0.5;
    会生成一个 isotropic self-similarity FBM
    [同项异性]
    在放大的过程中，原尺寸的图形 也保持等比例放大（而不会出现 xy 方向的拉升）


# lacunarity = 2.0
在这个实现中，间歇率 被设置为了定值: 2.0
（每次循环，frequency 都翻倍）


# Pink Noise
    H=0, G=1
    It sounds like rain

# Brown Noise
    H=1/2, G=sqrt(1/2)
    It does sound indeed deeper, like listening to rain again 
    but from inside your room with the window closed

# Yellow Noise ( iq 起的名字 )
    H=1, G=0.5
    图形学使用最广泛的 fbm













