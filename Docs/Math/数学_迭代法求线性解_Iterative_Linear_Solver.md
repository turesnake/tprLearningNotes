# ================================================================= #
#                     迭代法 求 线性解:
#                  Iterative Linear Solver
# ================================================================= #


# -----------------------------------------------
#       Introduction:

https://www.maa.org/press/periodicals/loci/joma/iterative-methods-for-solving-iaxi-ibi-introduction-to-the-iterative-methods

目标是求解 Ax = b   
	( A:矩阵; x:向量, 我们要求的值; b:常量向量 )

# 基本思路:
    假设最终解 x = (x1,x2,x3,x4)

    如果我们持有一组近似值: x2n, x3n, x4n, 那我们是可以基于这组值, 求出一个比 x1n 更加近似的新的 x1m 值的;

    使用这个思路, 每一轮迭代都能求出一圈 更加近似的 x 向量, 
    然后迭代多次后, 就能逼近真实解;

# 误差:
    判断迭代法是否到位的标准是检查误差, 就是上一轮的解 xn 和本轮解 xn+1 之间的误差;
    误差足够小了, 就看做足够接近了;

    但是这个办法不是绝对正确的, 比如 Newton’s Method, 它每次迭代后的误差会 忽大忽小



# -----------------------------------------------
#   	Jacobi's Method
#       Jacobi iteration method

一种迭代法来计算 线性解: Ax = b   
	( A:矩阵; x:向量, 我们要求的值; b:常量向量 )

https://www.maa.org/press/periodicals/loci/joma/iterative-methods-for-solving-iaxi-ibi-jacobis-method

大致思路:
	设计一个举证 M, 它是原矩阵 A 的 对角线矩阵, (只保留对角线元素)
	然后随便选取一个 x0 初始值, 比如 (0,0,0), 

	然后将 M 带入原公式 A 位置, x0放到 x位置, 

	然后使用 上文提到的方式去计算 新向量 x1;
	
	然后循环迭代吗, 每一轮求得得 xn 都会更加逼近我们要的真实解 x:


https://en.wikipedia.org/wiki/Jacobi_method
# 按照 wiki 解释, 本法好像适用于 "diagonally dominant system", (对角线元素占主导的矩阵)



# -----------------------------------------------
#       Gauss-Seidel Method

基于 Jacobi's Method 的一个改进:

在每轮迭代中, 如果我们计算出了 x1(n+1), 那么我们就没必要在本轮迭代内继续使用旧的 x1(n), 而是可以直接用上 x1(n+1) 去求解 x2(n+1), x3(n+1) ...

在这个方法中, 不再使用 对角线矩阵, 而使用 LU矩阵 (下矩阵,上矩阵)

# 本法的迭代速度要比 Jacobi's Method 更快
  

# Though it can be applied to any matrix with non-zero elements on the diagonals, 
# convergence is only guaranteed if the matrix is either strictly diagonally dominant, or symmetric and positive definite. 
    ----
    任何矩阵, 只要它的对角线上没有0, 都能使用本法;
    但在证明上, 它只保证 "严格对角线主导的矩阵" 或 "对称且正定的矩阵" 才能保证收敛
    ---
    但有时候, 就算上述条件不满足,  本法也能收敛


# 相比 Jacobi's Method, 本法更难被 并行化, 
    因为每一行允许都依赖上一行运算的结果

# 本法更适合 稀疏矩阵


# 在算法实现上, 因为不需要 完整的前一个向量 x了, 全程可以只用一个向量 x 来迭代;




# -----------------------------------------------



# -----------------------------------------------



# -----------------------------------------------



# -----------------------------------------------




# -----------------------------------------------




# -----------------------------------------------



# -----------------------------------------------

































