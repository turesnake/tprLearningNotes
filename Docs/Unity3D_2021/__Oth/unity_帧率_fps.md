# ============================================================================== #
#          unity  帧率  frameRate   fps
# ============================================================================== #



# 最直白的设置 预期帧率:
    Application.targetFrameRate = 30;








#  可以试试这个插件:
https://assetstore.unity.com/packages/tools/utilities/fps-free-framerate-independent-movements-226119




https://developer.android.com/games/develop/gameloops?hl=zh-cn


# ------------------------------------------- #
#            文档
# ------------------------------------------- #


# Application.targetFrameRate:
https://docs.unity3d.com/2021.3/Documentation/ScriptReference/Application-targetFrameRate.html


# gpt-3.5:
In Unity Android runtime, setting `Application.targetFrameRate = -1;` means that the application will run with an uncapped frame rate. (上不封顶的帧率)
By default, Unity tries to match the device's refresh rate, but by setting it to -1, you are allowing the application to render as many frames as possible. 
This can be useful if you want to prioritize performance over a consistent frame rate, but keep in mind that it may result in higher battery usage and potential overheating on some devices.





# ------------------------------------------- #
#      如何查看 设备当前 屏幕刷新率
# ------------------------------------------- #

Screen.currentResolution.refreshRate

    实测 安卓端有效



# ------------------------------------------- #
#             安卓  抖帧
# ------------------------------------------- #

在安卓 (红米) 上, 当 Application.targetFrameRate = -1 时, 机器会自己选择一个帧率 (目前看到 30);

然后当 手动设置 targetFrameRate 为 45, 60, 150 等其它帧率时,  机器会出现抖帧:
    就比如 目标为 60, 实现表现: 48, 72, 48, 72 ... 反复交替;


# 有时间确认:
    当去掉 CharacterController 或 vcam 时, 这个问题是否会改善 ?



# 这个问题 有时间要找到解法.....

    这个运行帧率和屏幕帧率不匹配导致的画面抖动也算是业界的老问题了
    所以Nvidia做了 G-Sync AMD做了 FreeSync 来解决这个问题
    手机上好像暂时还没办法……


# 有空读:
https://forum.unity.com/threads/disabling-v-sync-on-android.654181/


https://stackoverflow.com/questions/71506009/unity-problem-with-android-build-on-120hz-devices




# ------------------------------------------- #
#      -1-  update 和 屏幕刷新率 不同步
# ------------------------------------------- #
当 targetFrameRate 设置为  时,


可以开启 PlayerSettings.Android.optimizedFramePacing  来让 安卓平滑自己的帧率






# ------------------------------------------- #
#      -2-  帧抖动     judder
#      optimized frame pacing
# ------------------------------------------- #
当 targetFrameRate 设置为 60 时,
安卓手机 实际帧率不是 60, 而是: 48, 72, 48, 72 .... 交替出现;

# 平滑 安卓端机器的 帧率波动:
    PlayerSettings.Android.optimizedFramePacing = true;
    --
    也可以在 player settings - Resolution and Presentation - Optimized Frame Pacing 中勾选;






