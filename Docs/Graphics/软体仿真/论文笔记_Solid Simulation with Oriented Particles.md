# =========================================================== #
#    论文笔记  Solid Simulation with Oriented Particles
# =========================================================== #


核心是 
    (1)Oriented Particles 版的 pbd
    (2)shape matching


# -------------------- #
#     两种方法如何组合
#    Implicit Shape Matching
# -------------------- #

# 说白了就是程序自动识别并配置的 shape matching groups;

# shape matching 在 xpbd 主流程内扮演一个 约束器 的功能, 
shape matching 提供 target pos 和 target orientation:
    group 内的每个质点基于自己的 stiffness 靠近 target pos;
    group main质点 的朝向, 则直接被改写为 shape matching 提供的 target orientation:

# shape matchin 自己的计算是不依赖 质点的朝向的, 所以这里 xpbd 质点的朝向信息, 可能更多是用来处理 mesh 问题 或进阶问题(比如扭曲阻力); 
这意味着在最开始, 我们也许不用处理 朝向信息;



This data structure is simulated by defining one shape matching group per particle. 
A group contains the corresponding particle and all the particles connected to it via a single edge. 
In sparse regions of the mesh, regular shape matching would become immediately unstable in this setting while in our case there are no limitations to the connectivity structure.

和传动的 Shape Matching 方法不同, 本方法不是将整个 物体当作单个 Shape Matching, 而是为每个 Oriented Particle, 准备一个专属的 Shape Matching group;
这个 group 中, 主体是本质点, 外加数条连线, 连接相邻的质点;

---------------------------------
After the prediction step, the solver iterates multiple times through all shape match constraints in a Gauss-Seidel type fashion. 
For each constraint the goal positions are computed using Eq. (4). 
All the particles of the group are then moved towards their goal position by the same fraction stiffness which mimics stiffness as in [M¨uller et al. 2006]. 
This stiffness can be specified per particle as Fig. 3(c) shows.


在 pbd 的(2)约束阶段, 遍历所有的 shape match group constraints数次, 使用 Gauss-Seidel 法;
通过 shape match 计算出本 group 里所有质点的 target pos 后, 每个点都朝向这个目标移动一段距离; (方法见对应论文:)
M¨ULLER, M., HENNIX, B. H. M., AND RATCLIFF, J. 2006. Position based dynamics. Proceedings ofVirtual Reality Interactions and Physical Simulations, 71–80.

每个质点都可以自定义自己的 stiffness 值;

------------------------------
In terms of orientation, we only update the orientation of the center particle by replacing it with the optimal rotation provided by shape matching.

Generalized shape matching, as we formulated it in Section 3, has a nice property: it only influences the orientation of the particle along the directions contained in the moment matrix A. 

Let us have a look at two extreme cases. If there is only one particle in the group, generalized shape matching will return the orientation of that particle (see Eq. (7)) so the solver does not change it as expected. 

If the number of particles in the group and their positions are such that they robustly span a 3D space, the new orientation of the particle is dominated by the orientation of the entire group. 

All situations in between smoothly interpolate these two cases. In case of a chain of particles, for instance, the orientations of the particles along the direction of the chain are determined by shape matching, while they can freely rotate about the axis along the chain.

争对每个 shape matching group, 我们用 shape matching 提供的 朝向信息, 去更新 group 中心质点的 四元数值;

通用 shape matching 有个优点, 它只会影响 沿着矩矩阵A包含的方向 的那些粒子;

下面看两个极端案例:
(1) 假设 group 中只有一个粒子, 运行 shape matching 只会返回这个粒子的 Ai 值, 所有 solver 不会改写这个唯一粒子的 朝向;
(2) group 中存在数个质点, 且它们的位置分散在 3d空间中, 那么核心质点的朝向取决于 group 的朝向;

其它情况则是上述两种情况的混合, 








# -------------------- #
#    Explicit Shape Matching
# -------------------- #

We also support additional explicit shape matching groups defined by the user which can cover arbitrary subsets of the particles in the mesh. 

The implicit shape matching as described above is not performed for particles in explicit groups. 

Their positions and orientations are controlled by the explicit group only. 

In contrast to implicit shape matching, all participating particles get the shape match rotation. 

This results in rigid components, as shown in several examples in Section 9. There is one exception: particles belonging to more than one explicit shape matching group are treated as nonoriented (i.e. the matrix Ai in Eq. (7) is set to zero for particle i). 

This allows us to model various joints as in the monster truck sample. Without this exception rotation information would propagate from one group to the other and prevent the wheels from rotating freely.

# 说白了就是用户 显式配置的 shape matching group;
这个我们可以未来去尝试下...



# -------------------- #
#  Stretching vs. Bending
# -------------------- #
Shape matching per node models both stretching and bending resistance at the same time. This is sufficient in many cases. 

If the artist wishes to specify them separately, we support regular PBD distance constraints on the edges as well. So in order to reduce bending resistance only, the shape match stiffness can be made small and the distance constraints activated. 

However, if the shape matching stiffness is set to zero, shape matching still has to be performed to update the orientations of the particles for collisions and skinning since the distance constraints only act on the positions.


原则上只要施加了 shape matching groups 约束, 就同时提供了 拉伸阻力 和 弯曲阻力;

如果用户想单独操作它们, 比如单独降低 弯曲阻力 (这样更容易弯曲, 但依然保持足够的形状维持), 可以降低 shape matching 系数, 然后再额外施加 pbd 风格的 distance constraints;

注意, 就算把 shape matching 影响降为 0 了, shape matching 运算也不能被省略, 因为直接它可以修改每个粒子的 朝向信息;



# ============================== #
#           todo
# ============================== #













