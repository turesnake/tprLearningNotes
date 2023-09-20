# ================================================== #
#           安卓 实机打包测试 za
# ================================================== #


测试手机 iqoo 开机密码: 432179



# ================================================== #
#   放在前面的:
#      20220522 正版 unity plus 2021.3.1 新的打包流程
# ================================================== #

因为不再是 盗版 unity, 所以可以直接在安装 editor 的时候安装 jdk 等配套设备, 
然后在:
    Preferences - External Toolds 

中, 无脑勾选所有的 sdk, jdk, ndk, gradle 直接使用 unity 现成的;

然后尝试进行安卓打包, 

# 如果打包再次出现 gradle 问题, 尝试看如下视频:
https://www.bilibili.com/video/BV1GY4y1Y7uB?spm_id_from=333.337.search-card.all.click

具体步骤为:
-1-
    上网站: https://tool.lu/ip
    在 "请输入IP或网站域名" 后面输入: dl.google.com
    然后复制下方的: IP 地址：比如: 220.181.174.225
    120.253.255.161

-2- 
    本机查找: C:\Windows\System32\drivers\etc 的 hosts 文件,
    在此文件尾部添加:
        220.181.174.225 dl.google.com
    这么一行
-3-
    再次打包, 会发现成功 !!!!!!!







# ================================================== #
#                实机打包 流程2
# ================================================== #


# --------------------------- #
# -1- 安装并设置 JDK
# --------------------------- #
使用此教程方法:
https://www.bilibili.com/video/av636239950?from=search&seid=11271291752060957577&spm_id_from=333.337.0.0

    搜索 "清华大学 tuna", 选择 "adpotOpenJDK" - "8" - "jdk" - "x64" - "windows" - "OpenJDK8U-jdk_x64_windows_hotspot_8u322b06.zip"
    下载它, 放到一个 目录中, 记下它的路劲:
        C:\Program Files\Java\jdk8u322-b06
    (此处一定要选择 jdk8, 因为 unity 目前只支持这个)

# 设置 系统变量
https://www.zhihu.com/question/275554493/answer/2328567215
    分别设置:
    JAVA_HOME: C:\Program Files\Java\jdk8u322-b06
    CLASSPATH:
    修改 path

# unity 中绑定 jdk 路径:
"preference" - "external tools" - "android"
手动配置 jdk 路径:
    C:\Program Files\Java\jdk8u322-b06




# --------------------------- #
# -2- 安装并设置 SDK NDK
# --------------------------- #

# 我们需要 android studio 才能得到 SDK NDK, 所有先安装 as:
教程:
-1-
https://zhuanlan.zhihu.com/p/456126708
-2-
https://www.jianshu.com/p/ab4a46c05f7c

差不多安装好了就行;

细节上还是看此视频:
https://www.bilibili.com/video/av636239950?from=search&seid=11271291752060957577&spm_id_from=333.337.0.0

# sdk build tools 要安装 30.0.3;

# ndk 要安装 21.3.6528147
(unity 中要求的)

安装上述视频的步骤, 找到 sdk, ndk 路径, 填入 unity 设置中;
(就在 jdk 设置的下面)


# --------------------------- #
# -3- 下载并设置 gradle !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
# --------------------------- #
最大的坑................................

根据 unity 官网显示, 2021.2 支持 6.1.1 版的 gradle;
所有, 直接到网址:
https://services.gradle.org/distributions/
下载:
    gradle-6.1.1-bin.zip

简单解压缩他, 放在一个目录中:
    E:\TOOLs_E\android_studio\gradles\gradle-6.1.1

将这个路径, 黏贴到 unity gradle 设置中:
(在: "preference" - "external tools" - "android")



# --------------------------- #
# -4-  Player settings 部分
# --------------------------- #

# "Company Name" 必须设置为 "com.funtoy.tpr" 这种形式
设置完后, 在下方的 "Other Settings" - "Identification"
中可看到 "Package Name" 被设置好了

# 设置 android 版本:
Player settings - other settings - Identification - "Minimum API Level"
设置为 "安卓 11"

还有下一行的 "target API Levle", 也一样是 "安卓11"

# 配置证书:
在 player settings - "publishing settings" 中, 
点击 "keystore manager" 按钮, 打开配置面板:

配置文件放在: D:\unity_keystore

配置内容:
    password: 123tpr

    Alias:   tpr_test (好像是 test_tpr )
    password: 123tpr

    然后点击 "add key" 按钮;


# 每次开启项目, 然后要打包时, 都需要到此界面 填写密码


# --------------------------- #
#   指定 opengl 或 vulkan
# --------------------------- #
player - other settings:

--
    先将 Auto Graphics API 取消勾选

--
    在下方的 Graphic APIs 中, 把需要的图形库, 拖到最上面;




# --------------------------- #
# -5-  打包
# --------------------------- #
file - build settings, 开始 build:

左侧选择 android, 然后点击右下角的 "switch..." 先切换到此方向;

"scenes/scene empty" 中清除掉所有 scene, 只加载需要测试的 scene
(可点击 "add open scenes")

不要勾选 "Export Project", 那个选项会导出一个 安卓项目文件夹,
然后需要到 android studio 中再打包为 apk 文件;
(现在我们搞定了 gradle 问题, 可以直接在 unity 中打包了)

直接点击 build 打包成 xxx.apk 文件;


# --------------------------- #
# -6- 安装到 安卓实机
# --------------------------- #
--
    将 安卓手机 连接电脑
--
    将 apk 所在文件夹(通常里面还有一个 json 文件, 不知是否有用) 完整的拖动到 安卓 存储卡上
--
    打开手机系统, 找到 "文件管理" app, 在里面找到 目标 app, 选择安装它;
--
    完工;




# ================================================== #
#         真机  profiler 测试
# ================================================== #

# -0- 确保 手机开启 开发者模式, 然后 开启 usb 调试模式


# -1- 首先, 查找 vivo 手机 ip 地址:
    设置 - 系统管理 - 关于手机 - 状态信息 - ip地址;

    比如得到: 192.168.3.19

    黑鲨:
    192.168.2.110

    192.168.31.30
    
    ( 设置 - 我的设备 - 全部参数 - 状态信息 )

# -2- 确保电脑安装和配置好 adb


# -3- 终端/cmd 输入:
    adb disconnect
        ---
        断联一切

    adb tcpip 5555
        ---
        让 adb 监听端口 5555

    adb connect 192.168.3.19
        ---
        正式连接手机

        mi11 的则是: adb connect 192.168.2.9

        adb connect 192.168.2.65

        红米 note 12t pro:
            adb connect 192.168.2.120
            




# -4- 确保电脑上只打开一个 unity editor, 进入 profiler
    左上角 play mode 一栏 选择 安卓设备的;

# 手机上运行游戏, 然后 editor 中开启 profiler 记录按钮, 
    可以查看下是否能录取到 帧数据;




# ------------------------ #
#   安卓机器锁帧 如何解除
# ------------------------ #
# vivo IQOO:
进入 打电话功能, 输入 "*#558#", 会自动跳转到一个界面, 
选择 "品质验证测试" - "品质测试" - "LCM类测试" - "LCM帧率切换" - 选择 120hz, 然后点击执行

就行了;

(每次测试前都要这么搞一遍...)





# ------------------------------------------ #
#   build 界面: autoconnect profiler 选项
# ------------------------------------------ #

# new bing:
When this setting is enabled, the Unity Editor bakes its IP address into the built Player during the build process. 
When you start the Player, it attempts to connect to the Profiler in the Editor located at the baked IP address. 
If you additionally enable the Deep Profiling Support setting, Unity performs Deep Profiling when the built Player starts, 
which means that the Profiler profiles every part of your code, and not just code timings explicitly wrapped in ProfilerMarkers¹. 


To set up Autoconnect Profiler, you need to enable the Development Build setting in Build Settings and select your application's target platform. 
When you enable this setting, two settings related to the Profiler become available: Autoconnect Profiler and Deep Profiling Support¹. 

If you have already selected the Autoconnect Profiler checkbox in Build Settings, the profiler should connect automatically to your application on its target release platform 
when you attach your device to your network or directly to your computer via cable². 

I hope this helps!

Source: Conversation with Bing, 2023/9/18
(1) Unity - Manual: Profiling your application. https://docs.unity3d.com/Manual/profiler-profiling-applications.html.
(2) Unity - Manual: Connect the profiler to UWP. https://docs.unity3d.com/Manual/windowsstore-profiler.html.
(3) Autoconnect Profiler for Unity Pro. https://forum.unity.com/threads/autoconnect-profiler-for-unity-pro.275909/.
(4) Unity - Manual: Profiling your application. https://docs.unity3d.com/2019.3/Documentation/Manual/profiler-profiling-applications.html.
(5) Unity - Manual: Profiler overview. https://docs.unity3d.com/Manual/Profiler.html.

# ---- 简单总结:
开启 autoconnect profiler 后, 只要练到电脑的手机上的 app 一运行, unity editor 就能自动连接并获得数据了;




# ------------------------------------------ #
#   build 界面: Script Debugging 选项
# ------------------------------------------ #

# new bing:
When this setting is enabled, it includes **scripting debug symbols** and allows you to debug script code running in a Unity Player. 
You can use a debugger to inspect your source code while your application is running. Unity supports several code editors to debug C# code, including Visual Studio, Visual Studio for Mac, JetBrains Rider, and Visual Studio Code¹. 

If you want to debug your application using Visual Studio or JetBrains Rider, you need to attach the debugger to the Unity Editor or Unity Player. To do this, you need to select the **Wait For Managed Debugger** checkbox in Build Settings. This will make the Player wait for a debugger to be attached before it executes any script code¹.

I hope this helps! Let me know if there's anything else I can help you with.

说白了就是支持各 编辑器 debug; 



# ------------------------------------------ #
#   build 界面: eep Profiling Support 选项
# ------------------------------------------ #

# new bing:
When this setting is enabled, the Unity Profiler profiles every function call in your application, not just code timings explicitly wrapped in ProfilerMarkers ³⁵. 
This is useful to get deep profiling information on your application's start-up times, but it adds a small amount of overhead to your build ³. 

To enable Deep Profiling Support, you need to select the **Development Build** checkbox in Build Settings. Once you have enabled this option, the **Deep Profiling Support** checkbox will become available ¹³. 

# 可以打出更细腻夸张的 性能信息, 



