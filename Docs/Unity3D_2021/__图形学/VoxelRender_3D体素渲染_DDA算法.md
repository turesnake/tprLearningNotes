

# ----------------------------------- #
#        如何遍历一个 3d 体素buffer
# ----------------------------------- #

通常在 compute shader kernel 中进行这个渲染工作, 因为能借助 kernel 的很多 threadgroup 加速功能, 比如 tile, 常规 shader 不支持;

3d 体素数据 通常存储在一个 RWTexture3D<float4> _VoxelRT;
    3dtexture 比 1D主序buffer 有更好的空间命中, 显卡硬件专门为 3dtexture 做了优化;

遍历算法为 3D DDA;



# 体素百科
https://voxel.wiki/


# 推荐小实现:
https://www.shadertoy.com/view/lfyGRW









































