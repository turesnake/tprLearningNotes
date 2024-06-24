# ================================================================ #
#                      maya <-> unity 项目桥接
# ================================================================ #


还需要完善的:
-1-
    uv 是否跟随导入

-2-
    骨骼动画如何跟随导入(简单的就行)


# ======================================= #
#               方案 1
# ======================================= #
https://www.youtube.com/watch?v=6ogqHJJR_5M&list=PLeUKbKrkDo85p1VDOFu-2oVLkv3j-PG--

-1-
    unity:
    在 Asset 中新建一个 "Meshes" 目录来容纳从 maya 传来的模型文件;

-2-
    maya:
    "文件" - "发送到 unity" - "设置 unity 项目"
    选中 unity项目 目录

-3-
    maya:
    --
        设置 "米":
            "窗口" - "设置/首选项" - "首选项" - "设置" - "工作单位"
            选择 "米"
    --
        设置 远平面:
            在 "大纲视图" 中找到 "persp" 相机, 打开右侧的 "属性编辑器"
            将 近平面 设置为 0.01
            将 远平面 设置为 100000

    -- 设置 时间帧:
             "窗口" - "设置/首选项" - "首选项" - "时间滑块":
            帧速率:         60fps
            最大播放速率:   60 fps x 1

    -- 记得点 "保存";
-4-
    maya:
    制作模型....
    (比如一个 cube)

-5-
    导出:
    ==
        选中要导出的物体,
    ==
        "文件" - "发送到 unity" - "选择" (此时会导出 选中的那些物体)
        --
            在 导出目录上, 找到 想要放入的 unity 目录;
        --
            为导出模型 设置名字, 比如 "mayaCube_01"
        --
            设置类型为 fbx
        --
            在选项中:
            -1-:
                找到 "文件类型特定选项" - "高级选项" - "单位":
                撤选 "自动", 将 "文件单位转化为" 设置为: "厘米";
                (此时, 比例因子 显示为 100)
            -2-:
                找到 "文件类型特定选项" - "包含" - "几何体"
                勾选 "平滑组"(smoothing Groups)
                (这会把那些 模型平滑组信息 也加进去)
                (感觉对游戏用处不大 ??? ...)
            -3-:
                找到 "文件类型特定选项" - "包含" - "动画"
                勾选 "动画"(Animation)

        
    ==
        点击 "导出当前选项"

-6-
    unity
    此时会在 Asset - Meshes 中看到导出成功的 模型 (一个 prefab)
    在它的 inspactor 中, 确保它的 "Model" - "Scale Factor" 值为 1;
    ---
    把这个 prefab 拖到场景中, 就能正确显示了;

    
# 通过此方案, 模型绑定的 uv 能一并传入 unity 中;



# ------------------------------------- #
# 如果带有动画:
https://www.bilibili.com/video/BV1va4y1p7Cm?spm_id_from=333.999.0.0

-7-
    unity:
    maya 会把动画一并发送给 unity, 文件类型为 Animation Clip,
    我们还需为它添加一个 avatar:
        先选中 导入的 prefab 文件, 在 inspector 中, 选择 Rig,
        在 Avatar Definition 中点击 "Create from this model",
        (若模型文件很大, 还需启用 "Optimize Game Objects", 这是一个优化动画的功能)
        最后点击 "apply";
    就能看到 prefab 文件内新增了一个 avatar 文件;

-8-
    若想 Animation Clip 循环播放:
    选中 clip, inspector 中点击 editor 打开它, 勾选 "Loop Time", 点击 "Apply";

-9-
    添加 Animator Controller:
        直接在 prefab 边上创建一个 Animator Controller,
        (controller 无法创建在 prefab 内部, 但可通过 前缀同名 的方式让两者放在一起)
    双击打开 controller 界面, 把 prefab 中 maya 传入的 clip 拖到 controller 中去;

-10-
    绑定 Animator Controller:
    点击 Hierarchy 中的 prefab 实例, 
    在 Animator 组件中, 绑定 Controller;


# 此时运行游戏, 可看到 动画彻底播放了;
    


# ======================================= #
#    一个模型 有多个 动画动作 该怎么办 ?
# ======================================= #
-1-
    在 maya 中, 将这个模型的所有 动作, 都做到同一个 动画片段里;
    (可以是紧密相连的, 只要直到每个 动作的 起始帧就行)

-2-
    按照上述流程导入到 unity 中去后, 默认情况下, 这个 prefab 只有一个 clip "take 001";
    此时可以选中 prefab, 查看它的 inspector, 上面将显示 "import settings"
    选择 "Animation" 面板, 在 "Clips" 栏中, 可以添加更多的 clips;
    然后手动 设置每一个 clip 的名字和 起始帧 (及更多参数)
    然后就搞定了 !!!


# 这个文件 提供了各种方案:
https://docs.unity3d.com/2021.2/Documentation/Manual/Splittinganimations.html





# ======================================= #
#    如何将 顶点的 weight 信息从 maya 传递到 unity
# ======================================= #











