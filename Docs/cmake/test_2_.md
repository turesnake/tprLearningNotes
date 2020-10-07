

# ================================================================//
#               Cmake 案例 2 一个更为完善的 目录结构
# ================================================================//


#----- 项目 目录结构 ------


+-- CMakeLists.txt   (主)
|
+-- include/
|    |
|    +-- hello.h
|
+-- src/
|    |
|    +-- main.c
|    /-- CMakeLists.txt  （次）
|
+-- libhello/
|    |
|    +-- hello.c
|    /-- CMakeLists.txt  （次）
|
/-- build/
    |
    +-- bin/
    |    |
    |    +-- hello    (可执行文件)
    +-- lib/
    |    |
    |    +-- hello.lib  (库)


#------- 项目主 CMakeLists.txt -------

# project (HELLO)
        设置 工程名 （不是 最终 可执行文件名 ）
# add_subdirectory (src)
# add_subdirectory (libhello)
        去 子目录 src/libhello 中寻找 CMakeLists.txt 子文件
        两个 子 CMakeLists.txt 执行的 中间产物，将分别放在 
        build/src  build/libhello  目录中。
        （至于最终产物，如果什么都不设置，也将放在这两个 目录里）
        （但是，我们在 没个 子 CMakeLists.txt 文件中，更改了 最终产物的 放置地点）


#---------- 目录 src 中的 CMakeLists.txt ----------

# include_directories (${PROJECT_SOURCE_DIR}/include)
        指定 依赖的 h文件所在 路径 /include 
# set (APP_SRC main.c)
        声明变量 APP_SRC 值为 main.c
# set (EXECUTABLE_OUTPUT_PATH ${PROJECT_BINARY_DIR}/bin)
        更改 项目最终生成的 可执行二进制文件 的放置目录：
        build/bin 
# add_executable (doit ${APP_SRC})
        新建一个可执行文件：doit，依赖的 源文件 在变量 APP_SRC 中
# target_link_libraries(doit libhello)
        将 库 链接给 可执行文件

#---------- 目录 libhello 中的 CMakeLists.txt ----------

# include_directories (${PROJECT_SOURCE_DIR}/include)
        指定 依赖的 h文件所在 路径 /include 
# set (LIB_SRC hello.c)
        声明变量 LIB_SRC 值为 hello.c
# add_library (libhello ${LIB_SRC})
        新建一个库：libhello，依赖的 源文件 在变量 LIB_SRC 中
# set (LIBRARY_OUTPUT_PATH ${PROJECT_BINARY_DIR}/lib)
        更改 库 最终生成的 库文件 的放置目录：
        build/lib
# set_target_properties (libhello PROPERTIES OUTPUT_NAME "hello" )
        将 库 libhello 的输出名字改为 hello.lib



