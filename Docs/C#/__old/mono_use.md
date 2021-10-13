# ================================================================//
#                         mono 使用技巧
# ================================================================//
发现 .net core 的 CoreCLR 可以取代本文功能...



# ---------------------------------------------- #
#               mac path
# ---------------------------------------------- #
目前 iMac 上安装了3个版本的mono：
/Library/Frameworks/Mono.framework/Versions/5.20.1/lib/pkgconfig/mono-2.pc
/Library/Frameworks/Mono.framework/Versions/6.0.0/lib/pkgconfig/mono-2.pc
/Library/Frameworks/Xamarin.Mac.framework/Versions/5.8.0.0/lib/pkgconfig/mono-2.pc

在使用 vscode 编写 调用 mono库 的 c++项目时
可以让 vscode 自动加载 本系统的 mono lib path：
"includePath": [
   	...,
    "/Library/Frameworks/Mono.framework/Versions/5.20.1/include/mono-2.0"
],


# ---------------------------------------------- #
#              pkg-config
# ---------------------------------------------- #
有教程建议使用 pkg-config 来管理 第三方库的 路径和安装选项问题


# ---------------------------------------------- #
#                  msc
# ---------------------------------------------- #
一个旧版本 c# 编译器，官方推荐使用 csc 代替








