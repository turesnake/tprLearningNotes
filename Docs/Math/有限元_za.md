# =================================================================== #
#        有限元   za
# =================================================================== #

# -------------------------- #
# finite element method
# The linear finite element method (FEM)



# -------------------------- #
# The finite volume method (FVM)



# -------------------------- #
# FEM 和 FVM 的区别: (gpt)
The finite element method (FEM) and the finite volume method (FVM) are both numerical techniques used for solving partial differential equations (PDEs) in various fields of engineering and science. While they share some similarities, they differ in their fundamental principles and approaches. Here's a brief overview of the key differences between the two methods:

# -1- Discretization approach:
    FEM:
        In FEM, the domain of interest is divided into smaller geometric elements (triangles, quadrilaterals, tetrahedra, etc.). The primary focus is on the spatial discretization of the domain, where the PDEs are approximated by piecewise-defined functions within each element.

    FVM: 
        FVM divides the domain into control volumes or cells, usually structured or unstructured grids. The emphasis is on the volume discretization, where the PDEs are approximated by evaluating fluxes across the control volume boundaries.

# -2- Variables and equations:
    FEM: 
        In FEM, the primary variables of interest (such as displacements, temperatures, or pressures) are often interpolated using basis functions defined over each element. The PDEs are typically transformed into a weak form using variational principles, resulting in a set of algebraic equations to solve.
    FVM: 
        FVM focuses on the conservation(守恒) of quantities within each control volume. The PDEs are often expressed in a conservative form, ensuring the balance of the conserved quantity across the control volume boundaries. The equations are then integrated over each control volume to obtain discrete equations.

# -3- Solution methodology:
    FEM: 
        FEM relies on solving a global system of algebraic equations that result from the discretization process. Various techniques like direct solvers or iterative methods are used to solve the system and obtain the approximate solution.
    FVM: 
        FVM typically utilizes a cell-centered approach, where the unknowns are associated with the control volumes. The resulting discrete equations are usually in the form of a system of algebraic equations, which are solved using methods like the SIMPLE algorithm or other techniques suitable for the specific problem.

# -4- Conservation(守恒) properties:
    FEM: 
        FEM generally provides a good representation of local phenomena within each element, but it may not inherently satisfy global conservation(守恒) properties. Conservation(守恒) of quantities needs to be enforced separately if required by the problem.
    FVM: 
        FVM inherently satisfies conservation(守恒) properties due to its formulation based on control volume integration. The method automatically conserves quantities such as mass, momentum, and energy.

Both methods have their strengths and weaknesses and are suitable for different types of problems. FEM is often used for problems with complex geometries and irregular boundaries, while FVM is well-suited for problems involving conservation(守恒) laws and flow simulations. The choice between FEM and FVM depends on the specific requirements and nature of the problem being solved.




# ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ #
#         需要学
# ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ #

# 复习 散度, 旋度, 拉普拉斯算子



# 将矩阵正定化, 半正定化


# 了解 matrix norm 这个运算







# +++++++++++++++++++++++++++++++++ #
#          todo
# +++++++++++++++++++++++++++++++++ #


# ------------ #
# Matrix calculus
当一个求导运算的 分母是个 矩阵时, 该怎么算
    https://en.wikipedia.org/wiki/Matrix_calculus


# the derivative of a scalar by a matrix:
    函数返回标量, 它的参数是个矩阵
    ---
    https://math.stackexchange.com/questions/3743777/why-do-we-need-scalar-by-matrix-derivative




























