# ========================================================= #
#                线性代数    za
# ========================================================= #




#  佐治亚理工的交互线性代数教材
    https://textbooks.math.gatech.edu/ila/matrix-multiplication.html


# ----------------------------------------------#
#           叉积 叉乘 的方向
# ----------------------------------------------#
永远遵循所在坐标系的: XxY=Z, YxZ=X, ZxX=Y

左手坐标系, 右手坐标系 都满足



# ------------------------------------ #
#   行列式(值) 
#   determinant
# ------------------------------------ #

# det(A) 本质描述的是: A 所描述的空间线性变换, 让 面积/体积 变大了多少倍;
    如果 det(A) = 2, 说明 新坐标系比原坐标系 大了 2倍;
    ---
    这也能解释, 为啥 det(A) = 0, 意味着 A 不可逆:
        因为 A 导致了原空间的坍缩, 坍缩后的空间是无法再 转换回来的;

    如果 det(A) 为负数, 表示原空间被翻转了;


# -1- det(I) = 1

# -2- 如果交换 A 的两个行(row) 一次, det(A) 的值正负反转一次;


# -3- ...

# -4- 如果 A 有两行(row) 相同, 则 det(A) = 0
    其实就是 A 空间存在坍缩, 变扁了;

# -7- 如果 A 是 L 或 U (三角形矩阵) 
    则 det(A) = 所有对角线元素的乘积  (简单推导可得)


# -9- det(AB) = det(A)det(B)



# det(A^-1) = 1/det(A)
    毕竟空间被 A 拉伸后, 还得再复原回去;



# ------------------------------------ #
#     rank
# ------------------------------------ #

如果 A 将原空间压缩为一个 r2 空间, 则 rank = 2;

# full rank
    如果 A 没有导致空间坍缩, 就成转换后的空间为 full rank;



# ------------------------------------ #
#      矩阵 是否 可逆
# ------------------------------------ #

# -1-
    想要 可逆, A 首先必须是 方阵举证, m=n


# -2 easy- 
    如果 det(A) != 0, 说明 A 可逆;
    (请查看 上文 行列式中的解释)


# -2-
    如果 Ax=0 有非零解, 说明 A 能将某个 非零向量 x 转换为 0 向量;
    但是没有 A^-1 向量有能力将 0向量 转换回 x向量,
    所以此时 A 不可逆;

    这也意味着, A 的 colume space 必须是满的, 或, A 的 null space 必须为 零向量;

    或者说, A矩阵不能造成 空间的坍缩; 一旦空间探索了, 是没办法找到一个 A^-1 来讲空间复原的;








# ------------------------------------ #
#    置换矩阵
#    permutation
# ------------------------------------ #

在 I 的基础上, 随机切换行的顺序, 就得到了 置换矩阵 P

PA => K 
    得到的矩阵 K,  就是将 A 的行(row) 切换顺序后得到的;


# p^-1 = p^T 



# ------------------------------------ #
#    共轭转置
#    conjugate transpose
# ------------------------------------ #






# ------------------------------------ #
#    正定矩阵
#    positive definite
# ------------------------------------ #

A symmetric matrix is positive-definite if it satisfies the following conditions:

All eigenvalues of the matrix are positive (greater than zero).
The matrix is Hermitian, meaning it is equal to its own conjugate transpose.

满足如下条件, 这个矩阵就是正定的:

(1) 它是个 对称的 方阵矩阵;             A symmetric matrix
(2) 它的所有的 eigenvalues 都大于0;     All eigenvalues of the matrix are positive (greater than zero).
(3) The matrix is Hermitian, meaning it is equal to its own conjugate transpose(共轭转置).






































