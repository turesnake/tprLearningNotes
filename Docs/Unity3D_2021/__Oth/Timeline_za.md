# ===================================================================== #
#                  timeline  za
# ===================================================================== #


# -------------------------------------- #
#     运行时修改一个 PlayableDirector 中的 timelineAsset 的 相机 (CinemachineBrain)
# -------------------------------------- #

https://levelup.gitconnected.com/how-to-assign-a-cinemachine-brain-to-timeline-director-at-runtime-bea882d1af6f




# -------------------------------------- #
#    timeline + cinemachint
# -------------------------------------- #

# -1-
    新建空 go, 进入 timeline 面板, 点击 Create, 建立一个新的 timeline 文件, (保存到指定目录)
    ---
    这个操作会自动给目标 go 挂载一个 Playable Director 组件;

# -2-
    在 timeline 窗口左上角, 点击 + 号, 选择最下面的 cinamachine track,
    由此新建一个 轨道

# -1-
    新轨道的 头部槽中, 放入 cinamachine brain;

# -1-
    将各个 vcam 拖入轨道中,

# -1-

# -1-

# -1-

# -1-



# -------------------------------------- #
#    timeline + cinemachint  如何修改 Cinemachine Shot 里的 vcam
# -------------------------------------- #

比如, 一个 timeline 里用到了 角色相机,
但是这个 角色需要在 runtime 才会被加载出来, 在此之前, timeline 不知道自己要绑的相机是哪个;


https://forum.unity.com/threads/replace-cinemachine-shot-in-timeline-during-runtime.702977/


https://forum.unity.com/threads/replace-cinemachine-shot-in-timeline-during-runtime.702650/


https://forum.unity.com/threads/how-to-set-the-virtual-camera-in-a-cinemachineshot-from-code.497593/
































