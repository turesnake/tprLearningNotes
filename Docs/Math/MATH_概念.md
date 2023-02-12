[-MATH-概念-]


# -------------------------------------------------
# integer -- 整数 -- Z ：

	包括： 负整数，零，正整数。
	整数 是一个可数的 无限集合

# -----------------------------------------------
# natural number -- 自然数 -- N ：
	
	在 数论 中，常指 正整数
	在 集合论 和 计算机科学中，常指 非负整数( 0,1,2,3... )

	用于 计数 和 排序

	一个 可数的，无上界的 无穷集合

# -----------------------------------------------
# rational number -- 有理数 -- Q：

	在数学上，任何 能被表示为 两个整数比的数 (a/b,b!=0) 为 有理数

	有理数 的 小数部分 为有限 或 循环。

	
# -----------------------------------------------
# irrational number -- 无理数：

    也叫: 无限不循环小数。无法写作 a/b 的形式
	
	除了 有理数 之外的实数。

	无理数的小数位有无限个，且不循环。

	大部分 平方根，pi，e 为无理数



# -----------------------------------------------
# real number -- 实数 -- R：

	有理数 和 无理数 的总称。
	实数 可以直观地看作 小数 （有限或无限）
	实数 可以把 数轴 填满。

# -----------------------------------------------
# imaginary number -- 虚数：

	实数部分为0的 复数。

# -----------------------------------------------
# complex number -- 复数 -- C：

	实数 和 虚数 的总称。
	使任一 多项式方程 都有根


# -----------------------------------------------
# reciprocal -- 倒数：

	multiplicative inverse -- 乘法逆元

	当：y = 1 / x
	则：x ， y 互为 倒数。

	负倒数：
	当：y = -（1 / x）
	则：x ， y 互为 负倒数。

	0 没有 倒数 或 负倒数。

	一个 实数 的倒数和负倒数 是相反数。

# -----------------------------------------------
# derivative -- 导数：
	
	一个函数在某一点的导数 描述了这个函数在这一点的变化率。
	导数的本质是 通过 极限 的概念对函数进行局部的线性逼近。

	导数是函数的局部性质，不是所有函数都有导数，
	一个函数也不一定在 所有点都有导数


# -----------------------------------------------
# prime number -- 质数／素数：

	在大于1的自然数中，除了1和自身，无法被其他自然数 整除 的数。


# -----------------------------------------------
# measure -- 测度
    测度 是一个函数，它对一个给定 集合 的某些 子集 指定一个数，
    这个数可以比作大小、体积、概率等等。

    传统的积分是在区间上进行的，后来人们希望把积分推广到任意的集合上，就发展出测度的概念，
    它在数学分析和概率论有重要的地位。

# -----------------------------------------------
# codomain -- 上域：
    函数返回值 所在的域

# range -- 值域：
    值域 和 上域 的区别：
    the range is actually a subset of the codomain
    The codomain is a set of possible outputs, 
    while the range is the set of actual outputs
    
# domain -- 定义域：
    函数 input 所在的域: 


# -----------------------------------------------
# composition of function -- 复合函数


# -----------------------------------------------
# rational function -- 有理函数

    形如：p(x)/q(x)
    此处的 p,q 是 polynomial（多项式）



# -----------------------------------------------
# exponential -- 指数函数

    y = a^x; (a为常数，a>0, a!=1)


# -----------------------------------------------
# logarithm -- 对数函数

    y = log a x; (a>0, a!=1)
    a 是 对数的底数，
    x 是 真数， x 必须大于 0


# -----------------------------------------------
# interval -- 区间

connected interval -- 联通区间

closed -- 闭区间
open   -- 开区间
half open -- 半开区间


# -----------------------------------------------
# reciprocal  -- 取一个值的倒数，

    如 1/x

take reciprocal



# -----------------------------------------------
# polynomial -- 多项式

leading coefficient -- 首项系数
    多项式 最高位 x^N 的系数
    通常，它能决定 多项式的图，在 -inf, +inf 两个极限方向上的 趋势
    这个趋势，通常是由 leading coefficient 的 正负性 决定的



# -----------------------------------------------
# vertical asymptote -- 垂直渐进线

    参考 f(x) = 1/x 的图，它在 x=0 时，
    左侧极限是 -inf, 右侧极限是 +inf
    这两种就属于 垂直渐进线



# -----------------------------------------------
# horizontal asymptote -- 水平渐进线

right-hand horizontal asymptote --
    函数在 朝向 +inf 时，无限毕竟某值 

left-hand horizontal asymptote --
    函数在 朝向 -inf 时，无限毕竟某值 

# -----------------------------------------------
# indeterminate form -- 不定式


# -----------------------------------------------
# conjugate expressions -- 共轭表达式



# -----------------------------------------------
# rationalizing the denominator -- 分母有理化



# -----------------------------------------------
# Differentiability -- 可导性，可微性


# -----------------------------------------------
# intermediate value theorem -- 介值定理


# -----------------------------------------------
# scalar-valued function -- 多个参数单个返回值的函数

类似 f(x,y) = z
返回值必须是 一维的;



# -----------------------------------------------
#  gradient  -- 梯度
本质上是 "scalar-valued function" 的 一阶导函数
比如 f(x,y) 的一阶导函数;

只不过因为参数有多个, 最后 gradient 变成了一个 向量;
这个向量中的每个元素都是一个 函数, 是可以传入 point 求值的;


# -----------------------------------------------
# Hessian  -- 梯度的推广
本质上是 "scalar-valued function" 的 二阶导函数
也是 梯度 的 一阶导函数, 

因为 梯度是个 向量, 所以 Hessian 变成了一个 矩阵;
这个矩阵中的每个元素都是一个 函数, 是可以传入 point 求值的;


https://www.khanacademy.org/math/multivariable-calculus/applications-of-multivariable-derivatives/quadratic-approximations/a/the-hessian


# 有时候, "Hessian" 也被用来指代  "Hessian 矩阵的行列式"

# 观察可得, Hessian矩阵 对角线两侧的元素是线性对称的 (忘记叫啥术语了..)



# -----------------------------------------------
# 叉乘 的 模长
好像就是行列式的运算法则...



# -----------------------------------------------
#  多参数函数的 切平面

# tangent plane to a two-variable function's graph.
# The "local linearization" of f(x,y) at the point (x0,y0)

https://www.khanacademy.org/math/multivariable-calculus/applications-of-multivariable-derivatives/tangent-planes-and-local-linearization/a/tangent-planes

-1- 先学习如何用一个 函数来表达: 经过3d空间中一个点的 任意平面;

-2- 在此基础上, 计算出这个平面的 法线向量, 从而使得这个平面 与目标多参数函数 相切
	进而得到我们想要的 切平面



# -----------------------------------------------
# local linearization
目标函数 和 原函数 在同参数组的情况下 (x0,y0..) 求得的值也相同, 而且在这个点上 两函数的偏导数也相同
就称 目标函数 为 原函数的 local linearization

(例如上面的 切平面)
	当原函数为 2参数函数时, 它的 local linearization 就是它的 "切平面"

	随着 参数维度的升高 (参数变多), 这个 "切平面" 的视觉效果就不那么直观了;


https://www.khanacademy.org/math/multivariable-calculus/applications-of-multivariable-derivatives/tangent-planes-and-local-linearization/a/local-linearization



# -----------------------------------------------
# Quadratic approximation   - 二次近似

其实是 local linearization 的升级版, 不再是用一个 切平面去逼近点 (x0,y0), 而是用一个 二次方平面去逼近;

https://www.khanacademy.org/math/multivariable-calculus/applications-of-multivariable-derivatives/quadratic-approximations/a/quadratic-approximation




# -----------------------------------------------
# second partial derivative test   -  二阶偏导数检验

用来检测一个点是否为 saddle point (马鞍点)
此点的切平面为 f(x,y..) = 0, 且此点并不是 局部最低点 or 局部最高点

https://www.khanacademy.org/math/multivariable-calculus/applications-of-multivariable-derivatives/optimizing-multivariable-functions-videos/v/second-partial-derivative-test


# 更深一段的解释:
https://www.khanacademy.org/math/multivariable-calculus/applications-of-multivariable-derivatives/optimizing-multivariable-functions/a/reasoning-behind-the-second-partial-derivative-test



# -----------------------------------------------
# divergence  - 散度


# 深入解释了公式构成:
https://www.khanacademy.org/math/multivariable-calculus/multivariable-derivatives/divergence-and-curl-articles/a/intuition-for-divergence-formula

但是依然没有解释为啥只是 线性加法: a+b, 不是三角函数加法: sqrt(a^2+b^2)



# -----------------------------------------------
# 3D Curl   - 3D旋度
https://www.khanacademy.org/math/multivariable-calculus/multivariable-derivatives/divergence-and-curl-articles/a/curl




# -----------------------------------------------




# -----------------------------------------------



# -----------------------------------------------



# -----------------------------------------------



# -----------------------------------------------



# -----------------------------------------------




# -----------------------------------------------




# -----------------------------------------------



# -----------------------------------------------




# -----------------------------------------------



