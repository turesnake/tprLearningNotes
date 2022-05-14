# ================================================== #
#           安卓 实机测试 za
# ================================================== #


测试手机 iqoo 开机密码: 432179


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
#               杂乱的 bug
# ================================================== #



# -----
mainTemplate.gradle file is using the old aaptOptions noCompress property definition which does not include types defined by unityStreamingAssets constant

一种方案是, 直接将 Asset - Plugins - Android - mainTemplate.gradle 文件删掉
让 unity 自己再新建一个




# ================================================== #
#         真机  profiler 测试
# ================================================== #

# -1- 首先, 查找 vivo 手机 ip 地址:
    设置 - 系统管理 - 关于手机 - 状态信息 - ip地址;

    比如得到: 192.168.3.19

# -2- 确保电脑安装和配置好 adb


# -3- 终端/cmd 输入:
    adb tcpip 5555
        ---
        让 adb 监听端口 5555

    adb connect 192.168.3.19
        ---
        正式连接手机

        mi11 的则是: adb connect 192.168.2.9


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









