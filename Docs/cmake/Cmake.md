

# ================================================================//
#                          Cmake
# ================================================================//
一个 比 Makefile 更先进的 项目编译管理工具。


#--- 如何 安装 cmake ------
#-- mac
brew install cmake

# ============================= 内部构建 实例 ==================================#

#-- CMakeLists.txt
    项目中的 每个目录，都需要编写一个此名文件。

#-- 如果是 单目录项目，在 CMakeLists.txt 文件所在目录中
#-- 调用: cmake .  
#-- 来 构建项目

#-- 构建成功后，会自动创建：
    -- CMakeFiles/
    -- CMakeCache
    -- cmake_install.cmake
    -- Makefile
    等文件。

#-- 调用：make 
#-- 此时将生成 目录文件，比如 net.bin 文件 （需要用户自定义）

#-- ./net.bin
#-- 正式执行 程序。

# ============================= 外部构建 实例 ==================================#

#-- 额外准备一个 build 目录（可以在任何地方 ）

#-- 进入 build 目录后，执行 cmake  <CMakeLists.txt 所在的目录路径>

#-- 执行 make

#-- 执行 ./net.bin  来开启程序

# =============================================================================#
指令      -- 大小写无关
参数，变量 -- 识别大小写

#-- cmake_minimum_required (VERSION 2.8)
    指定 cmake 最小 版本号

# 注释
    注释行 使用 # 开头


#-- project(pjtname [CXX] [C] [Java])
    定义工程名称为 pjtname
    指定工程支持语言 [CXX] [C] [Java]
            也可以不写，默认情况表示 支持所有语言。
    隐式创建两个 变量：
        -- <pjtname>_BINARY_DIR
        -- <pjtname>_SOURCE_DIR
    系统还自带两个 变量：
        -- PROJECT_BINARY_DIR
        -- PROJECT_SOURCE_DIR
    其中：
        PROJECT_BINARY_DIR = <pjtname>_BINARY_DIR
            表示 二进制文件 的放置目录（输出目录）
        PROJECT_SOURCE_DIR = <pjtname>_SOURCE_DIR
            表示 源文件 存在目录 （源目录）
    推荐使用：
        -- PROJECT_BINARY_DIR
        -- PROJECT_SOURCE_DIR
        这两个变量。
    

#-- set(VAR [VALUE] [CACHE TYPE DOCSTRING [FORCE]])
    用来显式的 定义变量，比如：
    set(SRC_LIST main.c t1.c t2.c)    -- 用空格区分
    set(SRC_LIST main.c; t1.c; t2.c)  -- 用分号区分
    set(SRC_LIST "main.c")            -- 用了双引号
         定义了一个 列表。


#-- message([SEND_ERROR | STATUS | FATAL_ERROR] "message to display")
    向终端输出用户定义的信息，包含三种类型：
    -- SEND_ERROR   产生错误，生成过程被跳过
    -- STATUS       输出前缀为 '-' 的信息
    -- FATAL_ERROR  立即终止所有 cmake 过程。


#-- add_executable(project ${SRC_LIST})
    定义了 此工程会生成一个 名为 project 的 可执行文件
    相关的 源文件是 SRC_LIST 中 定义的 源文件列表。

#-- add_library( libhello ${LIB_SRC} )
    新建一个库：libhello，依赖的 源文件 在变量 LIB_SRC 中

#-- add_custom_target
    自定义目标

#-- add_dependencies ( target1 t2 t3 )
    目标 target1 依赖 t2 t3

#-- add_definitions ( "-Wall -ansi" )
    设置 编译预处理需要的 宏定义参数
    对应于 remove_definitions()

#-- add_subdirectory(source_dir [binary_dir] [EXCLUDE_FROM_ALL])
    向当前工程添加存放 源文件的 子目录。
    并可指定 中间二进制 和 目标二进制存放的位置
    EXCLUDE_FROM_ALL 意思是 将这个目录 从编译过程中排除
    例子：
        add_subdirectory(src  bin)
        定义了： 将 src 子目录 加入工程。
        并指定 编译输出（包含编译中间结果）路径为 bin目录（build/bin）
        （若不做此指定，编译结果 将存放于 build/src 目录）

#-- add_test ( )
    添加测试

#-- subdirs(dir1  dir2)
    可以一次添加多个 子目录
    即使是 外部编译，子目录体系仍然会被保存。
    ** 此 指令 不再被 推荐 **


#-- set(EXECUTABLE_OUTPUT_PATH ${PROJECT_BINARY_DIR}/bin)
    重新定义 EXECUTABLE_OUTPUT_PATH 变量
    来指定 最终生成的 可执行二进制文件的 路径: build/bin


#-- set(LIBRARY_OUTPUT_PATH ${PROJECT_BINARY_DIR}/lib)
    重新定义 LIBRARY_OUTPUT_PATH 变量
    来指定 最终共享库 的 路径: build/lib


#-- include_directories ( ${PROJECT_SOURCE_DIR}/include )
    指定 依赖的 h文件所在 路径： <项目主目录>/include/

    include_directories("dir1" "dir2" ...)
        也可按此格式，设置多个 include 路径

#-- aux_source_directory ("sourcedir" variable)
    收集目录中的 文件名，并赋值给 变量


#-- target_link_libraries ( targetname lib1 lib2 ... )
    将 库 lib1 lib2 链接给 目标文件（或可执行文件）targetname


#-- link_libraries ( lib1 lib2 ... )
    设置所有 目标 需要链接的 库

#-- set_target_properties (libhello PROPERTIES OUTPUT_NAME "hello" )
    将 库 libhello 的输出名字改为 hello.lib

#-- install ( FILES "f1" "f2" DESTINATION)

#-- list ( APPEND|INSERT|LENGTH|GET|REMOVE_ITEM|REMOVE_AT|SORT ... )
    列表操作
    
#-- string ( TOUPPER|TOLOWER|LENGTH|SUBSTRING|REPLACE|REGEX ... )

#-- separate_arguments ( VAR )
    转换 空格分割的 字符串到 列表

#-- file ( WRITE|READ|APPEND|GLOB|GLOB_RECURSE|REMOVE|MAKE_DIRECTORY ... )
    文件操作

#-- fine_file
    注意 CMAKE_INCLUDE_PATH

#-- find_path
    注意 CMAKE_INCLUDE_PATH

#-- find_library
    注意 CMAKE_LIBRARY_PATH

#-- find_program

#-- find_package
    注意 CMAKE_MODULE_PATH

#-- exec_program ( bin [work_dir] ARGS <..> [OUTPUT_VARIABLE var] [RETURN_VALUE var] )
    执行外部程序

#-- option ( OPTION_VAR "description" [initial value] )
    例子：
    option( SWITCH_1 "option test: switch 1" OFF )
        创建选项 SWITCH_1，默认值为 on
        此值 会保存在 cache 文件中。
        如果想要在 源代码中也使用此变量（宏）。需要在 .h.in 文件中添加：
            #cmakedefine SWITCH_1
        这样，cmake 会自动生成 这个宏（如果设为 OFF，则是不生成）。


#========================= 常用变量 =================================#

# CMAKE_SOURCE_DIR
# PROJECT_SOUCE_DIR
# <projectname>_SOURCE_DIR
    这三个变量 指代的内容是一致的： 工程顶层目录
    
# CMAKE_BINARY_DIR
# PROJECT_BINARY_DIR
# <projectname>_BINARY_DIR
    这三个变量 指代的内容是一致的：工程编译发生的目录，（二进制文件生成的目录..

# CMAKE_CURRENT_SOURCE_DIR
    当前处理的 CMakeLists.txt 所在的 路径

# CMAKE_CURRENT_BINARY_DIR
    target 编译目录

# CMAKE_CURRENT_LIST_FILE
    输出 调用这个变量的 CMakeLists.txt 的完整路径

# CMAKE_BUILD_TYPE
    控制 Debug 和 Release 模式的构建
    例如：
    在 CMakeLists.txt 中写： set ( CMAKE_BUILD_TYPE Debug )


# CMAKE_C_FLAGS
    编译器参数
# CMAKE_CXX_FLAGS
    编译器参数

# CMAKE_INCLUDE_PATH

# CMAKE_LIBRARY_PATH

# CMAKE_MODULE_PATH

# CMAKE_INSTALL_PREFIX
    控制 make install 时，文件会安装到什么地方
    默认为 /usr/local 或 %PROGRAMFILES%

# BUILD_SHARED_LIBS

# CMAKE_MAJOR_VERSION
# CMAKE_MINOR_VERSION
    CMAKE 主次 版本号，比如 2.4.6 中的 2，4

# CMAKE_PATCH_VERSION
    CMAKE 补丁等级，比如 2.4.6 中的 6

# CMAKE_SYSTEM 
    系统名称，比如 Linux-2.6.22。 

# CMAKE_SYSTEM_NAME
    不包含版本的系统名，比如 Linux。

# CMAKE_SYSTEM_VERSION
    系统版本，比如 2.6.22。

# CMAKE_SYSTEM_PROCESSOR
    处理器名称，比如 i686。

# UNIX
    此变量 在 所有 类UNIX 平台为 ture。包括 macosx 和 cygwin
# WIN32
    此变量 在 所有 win32 平台为 true。 包括 cygwin

# ========================= 开关选项 option ============================#

# BUILD_SHARED_LIBS
    cmake 默认生成 静态库。
    设置：
        set ( BUILD_SHARED_LIBS ON )
    将 更改为 默认生成 动态库








