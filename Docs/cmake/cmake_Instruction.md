cmke

===== instruction ==============

cmake_minimum_required( VERSION 2.8 )
	-- 对 cmake 最低版本的 要求


project ( Demo )
	-- 指定 项目名称为 Demo


add_subdirectory ( math )
	-- 添加 math 子目录
		这个 子目录 也要配置自己的 CMakeLists.txt 文件


target_link_libraries ( Demo MathFunctions )
	-- 说明 可执行文件 Demo，需要链接一个 名为 MathFunctions的链接库。
		这个链接库 通常由 子目录的CMakeLists.txt 文件来配置


configure_file (
	"${PROJECT_SOURCE_DIR}/config.h.in"
	"${PROJECT_SOURCE_DIR}/config.h"
	)
	-- cmake 会 在制定目录添加一个 名为 config.h 的配置头文件
		需要的信息会从 config.h.in 中获取
	-- ${PROJECT_SOURCE_DIR}／ 表示 项目源文件目录
	-- PROJECT_SOURCE_DIR 是 cmake 内置变量


install ( TARGETS t DESTINATION d )
install ( FILES f.h DESTINATION  d )
	-- 



include ( ${CMAKE_ROOT}/Modules/CheckFunctionExists.cmake )
	-- 顶层 CMakeLists 文件使用
	-- 在文件中添加 CheckFunctionExists.cmake 宏



check_function_exists ( pow HAVE_POW )
	-- 调用 命令测试链接器 查看是否能在 链接阶段赚到 pow 函数
	-- HAVE_POW 这个宏变量 需要在 config.h.in 文件中预定义：
		#cmakedefine HAVE_POW
	-- 最后在实际代码中，使用宏：
		#ifdef HAVE_POW
			//-- use pow function
		#else
			//-- use other function
		#endif



add_executable ( Demo main.c suba.c )
add_executable ( Demo ${DIR_SRCS} )
	-- 将指定的数个 源文件 编译为一个名为 Demo 的可执行文件



aux_source_directory ( <dir> <variable> )
aux_source_directory ( . DIR_SRCS )
	-- 查找指定目录 “<variable>” 下的所有源文件
		然后将这些 源文件 存进 指定变量名 "DIR_SRCS"




include ( CPack )
	-- 如果在之前使用了 CPack，
	-- 那么在 顶层 CMakeLists.txt 文件尾部 一定要添加这句


================================= CPack ====================================


















//-- end --