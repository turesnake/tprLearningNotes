





# =================================================== #
#        在 lua 中访问 marker 信息
# =================================================== #

# -1-: c# 端已经有一个继承 Marker 的class, 内涵内容: string msg, 用来传参

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























