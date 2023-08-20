# ================================================================ #
#                        adb  za
# ================================================================ #


# ================================ #
#          安装 adb
# ================================ #

-1-
    到 https://adbshell.com/downloads
    下载 "adb kits" 包

-2-
    解压缩后, 里面有三个文件, (不含 readme文件 )
    将三个文件分别复制进:
    C:\Windows\System32
    C:\Windows\SysWOW64
    这两个目录中,
    安装完毕

-3- 
    到 cmd 中输入 adb, 可看见安装成功了;


# ================================ #
#        常规指令
# ================================ #


# -------------------- #
# adb version
    查看ADB版本：


# -------------------- #
# adb devices
    查看已连接的设备列表
    会显示:
        List of devices attached
        3051501048006CG device

    如果有多个设备连接的时候，会提示error:more than one device/emulator,
    比如手机和模拟器同时打开的时候，这时候使用adb devices查看列表，使用adb -s xx shell选择设备


# -------------------- #
# adb shell pm list packages -s

    列出系统应用的所有包名：

# adb shell pm list packages -3
    列出除了系统应用的第三方应用的包名





# ================================ #
#          adb logcat
# ================================ #

# 参考 -1-
https://developer.aliyun.com/article/666214


# -------------------- #
# adb logcat -c
    清空 adb 缓存


# -------------------- #
# adb logcat -s Unity
    打印 只有 unity 相关的 log;


# -------------------- #
# adb logcat -s Unity ActivityManager PackageManager dalvikvm DEBUG
    可以打印更详细的信息... 需要尝试


# -------------------- #
# adb logcat -d > logcat.txt
    将 log 输出到一个 文件内;


# -------------------- #
# adb logcat -e xxx
    使用 正则表达式 来筛选出需要打印的 log;
    比如:
        adb logcat -e <my-prefix>

    此时, 任何字符串内包含 "<my-prefix>" 的log, 都会被筛选出来;



# -------------------- #
#    在手机中新建目录
# -------------------- #
https://blog.csdn.net/u013168615/article/details/128448260

# adb shell mkdir /newfolder
    ---
    在手机根目录下新建目录 "newfolder"









