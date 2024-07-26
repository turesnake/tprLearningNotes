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





# =================================================== #
#        在 lua 中访问 marker 信息
# =================================================== #

# -1-: c# 端已经有一个继承 Marker 的class (如 Custom Marker), 内涵内容: string msg, 用来传参;

# -1-: timeline 里添加 轨道: Markers - Custom Marker Track,  取名为 "tpr_marker"

# -1-: 在 lua 代码里 init 阶段 一股脑拿到所有 markers 信息, 
    然后自己 update 中逐帧轮询:




    local isBindTrackAnimator = false
    for i = 0, trackAssets.Count - 1 do
        local track = trackAssets[i]
        if isNotNull(track) then
            if string.lower(track.name) == "animator" then
                ...
            end

            if string.lower(track.name) == "tpr_marker" then
                local markerNum = track:GetMarkerCount() 
                printError("markerNum = " .. tostring(markerNum))
                for i=0, markerNum-1 do 
                    local marker = track:GetMarker(i)
                    if isNotNull(marker) then 
                        printError("i:"..tostring(i).."; time = " ..tostring(marker.time).."; name = " .. tostring(marker.name))
                    end
                end
            end
            
        end
    end
    if isBindTrackAnimator ~= true then 
        printError("timeline track animator 绑定失败")
    end 





# -------------------------------------- #
#    timeline  和 animator 之间如何 淡入淡出
# -------------------------------------- #
选中一个 timeline 轨道片段, 
查看它的 inspector, 可以看到一个 ease in ease out 设置;
设置了就能和 animator 混合了;


























