

# ================================================================//
#                     Cmake 案例 1 lib
# ================================================================//



#----- 项目 目录结构 ------

+-- main.c
+-- hello.c
+-- hello.h
+-- CMakeLists.txt
|
/-- build/
    |
    +-- hello         (可执行文件)
    +-- libhello.lib  (库)



#----- CMakeLists.txt -------

# project(HELLO)
        设置 工程名 （不是 最终 可执行文件名 ）
# set(LIB_SRC hello.c)
        声明变量 LIB_SRC 值为 hello.c
# set(APP_SRC main.c)
        声明变量 APP_SRC 值为 main.c
# add_library(libhello ${LIB_SRC})
        新建一个库：libhello，依赖的 源文件 在变量 LIB_SRC 中
# add_executable(hello ${APP_SRC})
        新建一个可执行文件：hello，依赖的 源文件 在变量 APP_SRC 中
# target_link_libraries(hello libhello)
        将 库 和 可执行文件 链接到一起。










