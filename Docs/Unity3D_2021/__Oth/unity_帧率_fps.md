# ============================================================================== #
#          unity  帧率  frameRate   fps
# ============================================================================== #



# 最直白的设置 预期帧率:
    Application.targetFrameRate = 30;


#  可以试试这个插件:
# 让物体的运动 不受到 帧率的影响
https://assetstore.unity.com/packages/tools/utilities/fps-free-framerate-independent-movements-226119


https://developer.android.com/games/develop/gameloops?hl=zh-cn



# ------------------------------------------- #
#   各种关系: Update(), 协程, UniTask, FixedUpdate(), InvokeRepeating() !!!!!!!!!!
# ------------------------------------------- #

# --- Update() 系列:
Update() 受到 Application.targetFrameRate (和 Time.timeScale) 的影响 

协程 则是在 Update() 中轮询;

所以当 Update() 设置帧率过低时, 协程的行为也会受到影响;


# --- FixedUpdate() 系列:
    
FixedUpdate 受到 Time.fixedDeltaTime (和 Time.timeScale) 的影响;

InvokeRepeating 则是在 FixedUpdate 中轮询;  (测试发现)

所以当 FixedUpdate() 设置帧率过低时, InvokeRepeating 的行为也会受到影响;




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
#      帧率不稳定时, 跟踪一个运动 obj 的 lerp 方法
# ------------------------------------------- #

https://forum.unity.com/threads/how-to-smooth-damp-towards-a-moving-target-without-causing-jitter-in-the-movement.130920/



// oldSelfPos_ is the follower's old position, oldTgtPos_ is the target's old position, newTgtPos_ is the target's new position, t is the elapsed time, and k is the lerp rate
public static Vector3 SuperSmoothLerp(Vector3 oldSelfPos_, Vector3 oldTgtPos_, Vector3 newTgtPos_, float deltaTime_, float k)
{
    float kt = k * deltaTime_;
    Vector3 f = oldSelfPos_ - oldTgtPos_ + (newTgtPos_ - oldTgtPos_) / kt;
    return newTgtPos_ - (newTgtPos_ - oldTgtPos_) / kt + f * Mathf.Exp( - kt);
}





# =================================================================== #
#                   帧率波动
#              optimized frame pacing    -- (安卓)
# =================================================================== #
当 targetFrameRate 设置为 60 时,
安卓手机 实际帧率不是 60, 而是: 48, 72, 48, 72 .... 交替出现;


# an uneven frame pace -- 不均匀的帧速度
# performance stutters -- 卡顿
# micropauses -- 微停顿
# screen tearing -- 画面撕裂


# 安卓平台 永远自动地开启了 V-sync, 但它只能克服 画面撕裂, 无法克服 帧率抖动


# 这可能是 unity 的 bug:
    https://issuetracker.unity3d.com/issues/android-time-dot-deltatime-is-not-stable-when-the-targetframerate-to-the-refresh-can-not-rate-divided-by-an-integer



# Unity: Optimized Frame Pacing for Smooth Gameplay
    https://thegamedev.guru/unity-performance/optimized-frame-pacing-smooth-gameplay/


# 安卓 Swappy 库
    安卓自带的库, 用来实现 frame pacing 功能;
    This library chooses the best frame to display on your screen depending on how early — or how late— you are delivering your frames.

    This library is designed to take advantage of the different refresh rates of your Android devices. 
    Some mobile screens support 90 Hz and beyond nowadays.

#  安卓官方介绍:
    https://developer.android.com/games/sdk/frame-pacing


# ------------- optimizedFramePacing -------------------
    支持: on Unity 2019.2+.

#    PlayerSettings.Android.optimizedFramePacing = true;
    --
#    也可以在 player settings - Resolution and Presentation - Optimized Frame Pacing 中勾选;



# ue4 描述:
Frame Pacing is a system that restricts an application to rendering frames at a lower framerate than a device's native refresh rate. 
This enables the application to prioritize consistency and stability in rendering, providing for a smoother user experience compared with letting the framerate run uncapped.





# =================================================================== #
#                   帧率波动
#              optimized frame pacing    -- (IOS)
# =================================================================== #

# https://blog.csdn.net/leonwei/article/details/130954679
对于 IOS 系统，直接通过系统提供的 MtlDrawable 上的 (void)presentAfterMinimumDuration 函数实现。

当一帧结束时，我们用这个函数做 prensent，presentAfterMinimumDuration 即指的是我们期待的帧率，他会在一些情况下自动为我们阻塞住当前的 cpu，控制我们的提交节奏，例如等待前一帧 GPU 处理完，或者对其到合适的提交点。



https://developer.apple.com/library/archive/documentation/3DDrawing/Conceptual/MTLBestPracticesGuide/FrameRate.html


https://developer.apple.com/documentation/quartzcore/cadisplaylink/1648421-preferredframespersecond


# ios 15+ 设置最小最大的期望刷新率
https://developer.apple.com/documentation/quartzcore/cadisplaylink/3875343-preferredframeraterange






# =================================================================== #
#                   帧率波动
#              optimized frame pacing    -- (Windows)
# =================================================================== #

# https://blog.csdn.net/leonwei/article/details/130954679
至于 windows 系统上的 DX，也是依靠 IDXGISwapChain::Present（ UINT SyncInterval,UINT Flags） 这个方法完成的。

这里面的 syncinterval 是垂直同步间隔，flags 则是一些策略。DX 上这个 syncinterval 的概念同移动端不太一样。首先这个 syncinterval 可以为0，意味着不管垂直同步，
即随时都能提交，并交换给 frontbuffer，哪怕 frontbuffer 正在被读取刷新，屏幕可能撕裂，但是手机上不会出现，例如 android 上，因为 surface flinger 的存在时一定不会存在所谓的不开垂直同步的。
如果 syncinterval 为非 0 的值 n，意味着至少距上次间隔 n 次垂直同步将画面刷新上去。


目前看来 实机包 帧率 不抖, 先不管 

# 个人猜测:
pc 原生就是支持各种帧率, 所以不需用 抖动来实现; 所以可能没有这个问题;













