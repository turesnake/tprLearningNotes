# =============================================================== #
#                          Gradle
# =============================================================== #


# 推荐阅读此文:
https://developer.android.com/studio/build

https://developer.android.com/studio/build/building-cmdline



# ====================================== #
#       安装 windows 指令版:
# ====================================== #
https://gradle.org/install/

直接从 56 打包机上复制一份 gradle-6.9.2, 到本地 G盘;


# 配置环境变量:
---
    win 中搜素 "环境变量," 打开 "编辑系统环境变量" 窗口
---
    点选:  高级 -- 环境变量
---
    配置 系统变量: GRADLE_HOME
    指向 gradle 的解压的路径:   
        G:\_Tools__\gradle-6.9.2
---
    然后 path 环境变量里面加上: %GRADLE_HOME%\bin

---
    配置 系统变量: GRADLE_USER_HOME（可不配置）：
        这是自定义仓库（可以为 Maven 的仓库目录)
        比如:
            G:\gradle_repository





# ====================================== #
#      unity 的 build.gradle 文件在哪 ?
# ====================================== #

The `build.gradle` file in a Unity Android project is located in the `Assets/Plugins/Android` folder . If you don't see the `Android` folder, you can create it manually. 


# ====================================== #
#       AAR (Android Archive) 
# ====================================== #

An **AAR (Android Archive)** is a file format used to package an Android library project. It contains the compiled code and resources of the library, along with an Android manifest file and other metadata required by the build system. 

An AAR file can be added to an Android app project as a dependency, allowing the app to use the code and resources provided by the library. 

To create an AAR file, you can use the **Gradle build system**. The `com.android.library` plugin provides support for building Android libraries in Gradle. 
















































