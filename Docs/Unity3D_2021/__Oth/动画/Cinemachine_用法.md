# ==================================================== #
#               Cinemachine  用法
# ==================================================== #



# --------------------------- #
#   虚拟相机 切换速度
# --------------------------- #
在场景中简单地 开启关闭某个 虚拟相机, 就能完成两个相机之间的 切换;

想要修改这个过度速度, 找到 Cinamachine Brain 组件 - "Default Blend"
    这一行最右侧, 有个 秒数 输入框, 设置小值来提高速度;

# 在 "Default Blend" 下方有个 "Custom Blends" 
    可以手动定制不同的虚拟相机的 切换模式;
    非常细腻实用;



# --------------------------- #
#   角色在相机中偏左偏右时, 会导致 运动方向 偏航
#   free look camera 
#        配合 Binding Mode = Simple Follow With World Up
#        配合 Aim- Screen x 偏移
# --------------------------- #

手动实现一个 角色控制, 使用 free look camera + Binding Mode = Simple Follow With World Up 模式,
此时如果将 Aim- Screen x 值远离 0.5, 
会导致 角色位于 画面的 左侧 或 右侧;

此时 角色的 forward 向量 和 camera 的 forward 向量 是不在一个轴线上的;

如果此时通过 camera forward 来驱动 角色向前运动, 会发现 角色会偏航;

# 最简解法:
    在 角色控制代码中, 直接修正读取到的 camera forward 向量, 向左向右旋转一个角度后使用;
    一般能直接解决此问题;



# ----------------------------------- #
#     得到当前 正在使用的 CinemachineBrain
# ----------------------------------- #

var brain = CinemachineCore.Instance.GetActiveBrain(0);


# ----------------------------------- #
#     得到当前 正在使用的 虚拟相机
# ----------------------------------- #

cinemachineBrain.ActiveVirtualCamera



# ----------------------------------- #
#   freelook 相机的三个 rigs  
# ----------------------------------- #

    CinemachineFreeLook vcam;
    CinemachineOrbitalTransposer[] orbital = new CinemachineOrbitalTransposer[3];
    CinemachineVirtualCamera[] rigs = new CinemachineVirtualCamera[3];
    CinemachineComposer[] composers = new CinemachineComposer[3];

    for (int i = 0; i < 3; ++i)
    {
        rigs[i] = vcam.GetRig(i);
        orbital[i] = rigs[i].GetCinemachineComponent<CinemachineOrbitalTransposer>();
        composers[i] = rigs[i].GetCinemachineComponent<CinemachineComposer>();
    }


#  打印得到: 三个 rig, 名字分别为 TopRig, MiddleRig, BottomRig, 
    且它们的 pos, 就位于 freelook 同位置;



# ----------------------------------- #
#     2D VCam
# ----------------------------------- #

其实就是传统的 VCam, 改了两个配置:
    body 选择了 Framing Transposer
    Aim 选择了 Do Nothing -- (毕竟是 2d cam, 不需要对齐啥)


# Body -- X/Y/Z Damping:
    值越小, 相机跟随 follow 的速度越快, 比如设置为 0.5


















