# ================================================================= #
#              安卓打包测试 bugs
# ================================================================= #



# ================================================== #
#       项目单场景打包, 报错:
#            vivo 应用程序安装异常 -25
# ================================================== #

# -25
INSTALL_FAILED_VERSION_DOWNGRADE   新包具有比目前安装的软件包的较旧版本的代码





# --------------------------------------------------- #
#   mainTemplate.gradle file is using the old aaptOptions noCompress property definition which does not include types defined by unityStreamingAssets constant
# --------------------------------------------------- #

一种方案是, 直接将 Asset - Plugins - Android - mainTemplate.gradle 文件删掉
让 unity 自己再新建一个





# --------------------------------------------------- #
#    Autoconnected Player "Autoconnected Player" IOException: Permission denied   
# --------------------------------------------------- #

自己搞了个测试包, 连上电脑, 运行程序后, unity editor console 中自动反复打印:

-1-     Autoconnected Player "Autoconnected Player" koko-[Log]: Create Instance
-2-     Autoconnected Player "Autoconnected Player" IOException: Permission denied 




# --------------------------------------------------- #
#      Failed to connect. Check if there is an app running on the correct device and it was built with Developer Mode enabled. 
# --------------------------------------------------- #

如果试图用 editor profiler 去连手机, 然后 unity console 上打印:

-1- Connecting directly to player (Ip=127.0.0.1 port=34999)
-2- Attempting to connect to player IP: 127.0.0.1, ports 34999-34999
-3- Connected to player IP: 127.0.0.1:34999
-4- Failed to connect. Check if there is an app running on the correct device and it was built with Developer Mode enabled. 
    In case of further issues you can enable the player connection diagnostic switch to get more information.

    ----
    这大概率是因为打包的时候 只勾选了 "Developmen Build", 没有勾选: "Autoconnected Profiler"

































