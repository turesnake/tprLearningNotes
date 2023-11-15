# ==================================================== #
#               Cinemachine  用法
# ==================================================== #

https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineUsing.html


# --------------------------- #
#   body
# --------------------------- #
to specify how to move it in the Scene


# --------------------------- #
#   aim
# --------------------------- #
to specify how to rotate it.



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




# ----------------------------------- #
#    vcam 的 优先级 
# ----------------------------------- #

vcam.Priority




# ----------------------------------- #
#    如何得知 当前 vcam 是否为 live 相机 (正在被使用的那个相机)
# ----------------------------------- #

bool isLive = CinemachineCore.Instance.IsLive(vcam);

# 假设从 vcam1 转换到 vcam2, 历时 1 秒;
-1-
    转换开始前:
        vcam1 live = true
        vcam1 live = false
-2- 
    转换中:
        vcam1 live = true
        vcam1 live = true
-3-
    转换完成时:
        vcam1 live = false
        vcam1 live = true
    ---------------------------

# --- 如果转换模式为 cut,  
    那么上一帧还是 { true, false } 
    下一帧就变成了 { false, true }



# ============================================= #
#        Body: 3rd Person Follow
# ============================================= #

Cinemachine3rdPersonFollow.cs

# Damping:
    The responsiveness of the camera in tracking the target. Each axis can have its own setting. 
    The value is the approximate time it takes the camera to catch up to the target's new position. 
    Small numbers make the camera more responsive. Larger numbers make the camera respond more slowly.
    ---
    object-space 的三个轴值, 代表在三个轴方向上, 分别花费 多少秒 来让 vcam 运动到目标位置;
    若全设 0, 则 vcam 将和预定位置 完全同步;
    ---
    y轴值可以适当设一个, 这样当角色被地面石头绊到时,  相机不会上下抖动;

    ===
    z值 最好为 0, 这样当角色前进时, 相机不会前后抖动;


# Rig - Shoulder Offset:
    越肩模式, 一般全为 0

# Rig - Vertical Arm Length
    Vertical offset of the hand in relation to the shoulder. 
    Arm length affects the follow target's screen position when the camera rotates vertically.

# Rig - Camera Side
    Specifies which shoulder the camera is on (left, right, or somewhere in-between).

# Rig - Camera Distance
    Specifies the distance from the hand to the camera.

# Obstacles - Camera Collision Filter
    Specifies which layers will be included or excluded from collision resolution.
    ---
    相机碰撞 层管理

# Obstacles - Ignore Tag
    Obstacles with this tag will be ignored by collision resolution. 
    It is recommended to set this field to the target's tag.

# Obstacles - Camera Radius
    Specifies how close the camera can get to collidable obstacles without adjusting its position.
    ---
    指定相机 在不调整其位置的情况下 可以接近 可碰撞障碍物 的距离。

# Obstacles - Damping Into Collision
    Specifies how gradually the camera moves to correct for an occlusion. 
    Higher numbers move the camera more gradually.
    ----
    指定相机移动以校正遮挡的逐渐程度。数字越大，相机移动的速度就越缓慢。

# Obstacles - Damping From Collision
    Specifies how gradually the camera returns to its normal position after having been corrected by the built-in collision resolution system. 
    Higher numbers move the camera more gradually back to normal.
    ---
    指定相机在经过内置碰撞解决系统纠正后如何逐渐恢复到正常位置。数字越大，相机就越逐渐恢复正常。






# ----------------------------------- #
#   如何修改 brain 的 默认 blend 模式
# ----------------------------------- #

// Set the blend mode to "Cube"
cinemachineBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;





# ----------------------------------- #
#    如何知道 brain 当前帧 是否在 blend 两个 vcams
# ----------------------------------- #

# CinemachineBrain.IsBlending

    if (cinemachineBrain.IsBlending && 
        (cinemachineBrain.ActiveVirtualCamera == cameraA || cinemachineBrain.ActiveVirtualCamera == cameraB))
    {
        Debug.Log("Blending between Camera A and Camera B");
    }








