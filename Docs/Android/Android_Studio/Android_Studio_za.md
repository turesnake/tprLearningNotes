# ================================================================ #
#               Android Studio  za
# ================================================================ #


# 如何设置 sdk
打开 file - settings
左侧, "Appearance & Behaviour" - "System Settings" - "Android SDK"
就能 进入面板




# -------------------------- #
#      bug 1
# -------------------------- #
A problem occurred evaluating project ':launcher'.
> Failed to apply plugin 'com.android.internal.application'.
   > The option 'android.enableR8' is deprecated.
     It was removed in version 7.0 of the Android Gradle plugin.
     Please remove it from `gradle.properties`.
# ---




# -------------------------- #
#     Android Studio 显示手机程序的 debug 信息
# -------------------------- #
将手机连接电脑, 打开 Android Studio, 点开中下角的 Logcat 窗口, 
打开程序, 就能看到 debug 信息;





# -------------------------- #
#    lua 本地改代码调试    old 
# -------------------------- #

Game/Main/XGraphicSetup.lua

手机上有个暗门

https://tool.oschina.net/encrypt?type=3




# -------------------------- #
#    lua 本地改代码调试  (新版)
# -------------------------- #

# 本方法仅适用于 国服:

# -1-
  本地修改 lua 代码, 然后点击 copy to streamasseets -> lua
  然后用 project 窗口搜索那个修改的 lua 字节码文件, 它以 .byte 结尾


# -2-
  打开安卓机内 com.funtoy ... 目录, 在 files - Product -> Lua -> Game
  内, 找到对应的 lua bytes 文件, 替换之

# -3- 
  在手机上重启游戏, 就能看到变化了












