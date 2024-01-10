# ================================================== #
#              Mosek   安装
# ================================================== #


https://docs.mosek.com/latest/cxxfusion/install-interface.html#testing-the-installation-and-compiling-examples



# -------------------------- #
#  需要满足以下条件:
-1- 电脑里安装 mosek 
-2- 把 .h 文件全部放到自己项目里
-3- 把 fusion64_10_1.lib, mosek64_10_1.lib 文件 链接到项目里 (cmake)
-4- 保持 mosek64_10_1.dll 动态库能全局访问



# --------------

win 上直接把 mosek 装到系统里;
据说要证书,  不知道是不是影响后面 .dll 的使用;

然后直接拿到 c 盘安装地址里的 mosek64_10_1.dll 文件;

现在假定装在 RootPath = C:\Program Files\Mosek\10.1\tools\platform\win64x86


# -1- 将 RootPath\h\ 里的所有 .h 文件放到自己项目的 头文件处, 
    这样才能在代码中访问到这些 h文件;

# -2- 把 QuadProgMosek.h 中的 #include <mosek.h> 改成 #include "mosek.h"

# -3- 把 RootPath\bin\mosek64_10_1.dll, fusion64_10_1.lib, mosek64_10_1.lib 文件, 放到自己项目中.
    我放在 deps\ 中;
    其实这个 .dll 文件不用拿过来的


# -4- 在 cmake 中写:
    target_link_libraries( emptyApp
                            fmt
                            ${CMAKE_CURRENT_SOURCE_DIR}/deps/fusion64_10_1.lib
                            ${CMAKE_CURRENT_SOURCE_DIR}/deps/mosek64_10_1.lib
                            )

# -5- 保证运行环境中能访问到 RootPath\bin\mosek64_10_1.dll
    比如配置好全局 Path


# -6- 运行程序,  可以看到能使用 mosek 代码了;









