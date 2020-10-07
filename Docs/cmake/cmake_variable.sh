#!/bin/bash

#-----------------------------------------#
#  利用  cmake --help-variable < variable_name > 命令
#  批量查看 所有 cmake 变量的 说明。
#  并且记录到 一个文件中：
#
#-----------------------------------------#

#-- 输出文件
#-- 和 本sh文件 同目录。
outfile=cmake_variable_out.md


#-- cmake 变量数组
ary=(
    CMAKE_AR 
    CMAKE_BINARY_DIR
    CMAKE_BUILD_TOOL
    CMAKE_CACHEFILE_DIR
    CMAKE_CACHE_MAJOR_VERSION
    CMAKE_CACHE_MINOR_VERSION
    CMAKE_CACHE_PATCH_VERSION
    CMAKE_CFG_INTDIR
    CMAKE_COMMAND
    CMAKE_CROSSCOMPILING
    CMAKE_CTEST_COMMAND
    CMAKE_CURRENT_BINARY_DIR
    CMAKE_CURRENT_LIST_DIR
    CMAKE_CURRENT_LIST_FILE
    CMAKE_CURRENT_LIST_LINE
    CMAKE_CURRENT_SOURCE_DIR
    CMAKE_DL_LIBS
    CMAKE_EDIT_COMMAND
    CMAKE_EXECUTABLE_SUFFIX
    CMAKE_EXTRA_GENERATOR
    CMAKE_EXTRA_SHARED_LIBRARY_SUFFIXES
    CMAKE_GENERATOR
    CMAKE_HOME_DIRECTORY
    CMAKE_IMPORT_LIBRARY_PREFIX
    CMAKE_IMPORT_LIBRARY_SUFFIX
    CMAKE_LINK_LIBRARY_SUFFIX
    CMAKE_MAJOR_VERSION
    CMAKE_MAKE_PROGRAM
    CMAKE_MINOR_VERSION
    CMAKE_PARENT_LIST_FILE
    CMAKE_PATCH_VERSION
    CMAKE_PROJECT_NAME
    CMAKE_RANLIB
    CMAKE_ROOT
    CMAKE_SHARED_LIBRARY_PREFIX
    CMAKE_SHARED_LIBRARY_SUFFIX
    CMAKE_SHARED_MODULE_PREFIX
    CMAKE_SHARED_MODULE_SUFFIX
    CMAKE_SIZEOF_VOID_P
    CMAKE_SKIP_RPATH
    CMAKE_SOURCE_DIR
    CMAKE_STANDARD_LIBRARIES
    CMAKE_STATIC_LIBRARY_PREFIX
    CMAKE_STATIC_LIBRARY_SUFFIX
    CMAKE_TWEAK_VERSION
    CMAKE_USING_VC_FREE_TOOLS
    CMAKE_VERBOSE_MAKEFILE
    CMAKE_VERSION
    PROJECT_BINARY_DIR
    PROJECT_NAME
    PROJECT_SOURCE_DIR
)

#-- 数组元素个数
size=${#ary[*]}

#--- terminal 头部 ---
# -e 用来要求 对 转义字符 进行替换，否则将原样打印。
echo -e "\n|-------------- cmake variable start -----------------|\n\n"

#-- 在 terminal 打印 cmake 变量个数 --
echo -e "num of cmake variables is: ${size}.\n"


#---- 输出文件头部 -----
echo -e "### +++++ cmake variable info +++++ ###\n\n" | cat > ${outfile}

#-- 将 cmake 变量个数 写入 输出文件 --
echo -e "num of cmake variables is: ${size}.\n" | cat >> ${outfile}

for ((i=0;i<${size};i++));
do
    idx=$(expr ${i} + 1)
    echo -e "\n\n#=========================#\n#+++ ${idx} +++\n#----------" | cat >> ${outfile}

    cmake --help-variable ${ary[i]} | cat >> ${outfile}
    
done


echo -e "\n||| ---- END ---- |||\n" | cat >> ${outfile}


# -e 用来要求 对 转义字符 进行替换，否则将原样打印。
echo -e "|-------------- cmake variable done  -----------------|\n"







