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
# Hessian  -- (梯度的推广)
本质上是 "scalar-valued function" 的 二阶导函数
也是 梯度 的 一阶导函数, 

因为 梯度是个 向量, 所以 Hessian 变成了一个 矩阵;
这个矩阵中的每个元素都是一个 函数, 是可以传入 point 求值的;


https://www.khanacademy.org/math/multivariable-calculus/applications-of-multivariable-derivatives/quadratic-approximations/a/the-hessian


# 有时候, "Hessian" 也被用来指代  "Hessian 矩阵的行列式"

# 观察可得, Hessian矩阵 对角线两侧的元素是线性对称的 (忘记叫啥术语了..)

# 求 min/max 值:
	在 f(x) 函数中, 如果某点处的 二阶导数为正, 表示曲线在此点为 开口向上的弧 (碗), 如果恰好此时 一阶导数为0, 则此点为一个 min 值;
	反之还有 二阶导数为负 的情况...

	---
	这可以推广到 Hessian 矩阵上, 因为 Hessian 是 f(x,y,...) 的 二阶导数;
	但是要用到 det(Hessian), 就是它的 行列式值;

	若 det(Hessian) > 0, (且此点的 一阶导数(梯度)为0向量), 则此点要么是 min 要么是 max;
		若 det(Hessian) 的对角线元素都为正, 说明此点为 min
		若 det(Hessian) 的对角线元素都为负, 说明此点为 max
		---
		这里的对角线元素恰好是 d(f)^2/dx^2, d(f)^2/dy^2 ...
	
	若 det(Hessian) < 0, (且此点的 一阶导数(梯度)为0向量), 则此点为 马鞍点

	若 det(Hessian) == 0, 此时还需更多信息才能做判断


# 涉及:
--	对称矩阵(方阵) 的 determinant (det(H)) 的分析

-- 正定矩阵 里的 (x^t A x > 0) 这个规则很像	






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
#  spectral radius  - 谱半径

https://www.youtube.com/watch?v=K-yDVqijSYw

一个矩阵的所有 eigenvalues 组成的集合, 叫做: spectrum of matrix A  -- (矩阵的光谱)

这其中, 最大的那个绝对值, 就是 矩阵的 谱半径; (它一定是个 非负数)

如果一个矩阵的 谱半径 小于1, 说明这个矩阵在把原空间缩小; 在解线性系统时常用到, 用来收敛 




# -----------------------------------------------
#    explicit euler    显式积分
#    implicit euler    隐式积分

https://zhuanlan.zhihu.com/p/479327351

# 显式积分 
	无法估计步长对精度的影响, 如果步长设置得太小, 会导致迭代次数过多

# 隐式积分 
	能很好解决 显式积分 的问题, 而且更稳定, 有时候就算物理错误了, 依然能保持稳定...
	--
	缺点就是求解困难;




# -----------------------------------------------
# Conjugate Gradient 

# https://www.youtube.com/watch?v=NzOwaimDYog   -- Steepest Descend Method
# https://www.youtube.com/watch?v=h4cG8jLGmKg   -- Conjugate Gradient Method
# https://www.youtube.com/watch?v=zjzOYL4fhrQ   -- Preconditioned Conjugate Gradient Descent (ILU)




# -----------------------------------------------
#  complex derivative
#  复数 的 导数

https://www.youtube.com/watch?v=b8_3PFjiJvY


 



# -----------------------------------------------
# Conformal Map

https://www.youtube.com/watch?v=48aerHs9wL0



# -----------------------------------------------
# Variational Calculus

	寻找一个 function 的最值解, 它的解是一个 path or function
	---
	和微分方程不同, 微分方程 虽然也求最值解, 但是它的解是一个 值; (而不是一个方程)



brachistochrone problem - 最速降线问题

Euler-Lagrange equations


# 非常好的解释:
https://www.youtube.com/watch?v=VCHFCXgYdvY


# -----------------------------------------------
#     Verlet integration

gpt-3.5:
Verlet integration is a numerical method used to solve equations of motion in physics and engineering. 

The Verlet integration step refers to the process of updating the position and velocity of a particle or system at each time step using the Verlet integration algorithm. 

This algorithm is often used in molecular dynamics(分子动力) simulations and other simulations of physical systems. It is known for its accuracy and stability in simulating the behavior of complex systems over time.

感觉啥也没讲






# -----------------------------------------------
#          Cosserat rods

感觉是一种描述 绳子的方法;

https://www.cosseratrods.org/cosserat_rods/theory/


Cosserat rods are a generalization of Kirchhoff rods, which model 1-d, slender rods incorporating only bend and twist. 
Cosserat rods add the ability to consider stretching and shearing, allowing all the possible modes of deformation of the system to be considered.


Kirchhoff rods 是一种只包含 弯曲和扭曲的 绳的 数学模型;
Cosserat rods 在此基础上增加了 拉伸 和 剪切;



# -----------------------------------------------



