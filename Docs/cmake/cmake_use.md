# ================================================================//
#                         C# 使用技巧
# ================================================================//



# ---------------------------------------------- #
#      适合写在 cmake 配置文件中的 格式
# ---------------------------------------------- #
# -- 兼容 unix/win. 
# -- 关闭优化：O0
# -- 开启有限的 inline：Ob1

# -------- UNIX ----------
if( UNIX )
    set ( CMAKE_C_FLAGS                  "-O0"              CACHE STRING "regular mode: no optimize" FORCE )
    set ( CMAKE_C_FLAGS_DEBUG            "-O0 -g"           CACHE STRING "debug mode: no optimize" FORCE )
    set ( CMAKE_C_FLAGS_MINSIZEREL       "-O0 -DNDEBUG"     CACHE STRING "minSizeRel mode: no optimize" FORCE )
    set ( CMAKE_C_FLAGS_RELEASE          "-O0 -DNDEBUG"     CACHE STRING "release mode: no optimize" FORCE )
    set ( CMAKE_C_FLAGS_RELWITHDEBINFO   "-O0 -g -DNDEBUG"  CACHE STRING "relWithDebugInfo mode: no optimize" FORCE )

    set ( CMAKE_CXX_FLAGS                 "-O0"             CACHE STRING "regular mode: no optimize" FORCE )
    set ( CMAKE_CXX_FLAGS_DEBUG           "-O0 -g"          CACHE STRING "debug mode: no optimize" FORCE )
    set ( CMAKE_CXX_FLAGS_MINSIZEREL      "-O0 -DNDEBUG"    CACHE STRING "minSizeRel mode: no optimize" FORCE )
    set ( CMAKE_CXX_FLAGS_RELEASE         "-O0 -DNDEBUG"    CACHE STRING "release mode: no optimize" FORCE )
    set ( CMAKE_CXX_FLAGS_RELWITHDEBINFO  "-O0 -g -DNDEBUG" CACHE STRING "relWithDebugInfo mode: no optimize" FORCE )

# -------- WIN ----------
else()
    # do not have CMAKE_C_FLAGS;
    set ( CMAKE_C_FLAGS_DEBUG            "/MDd /Zi /Ob0 /Od /RTC1"   CACHE STRING "debug mode: no optimize" FORCE )
    set ( CMAKE_C_FLAGS_MINSIZEREL       "/MD /O0 /Ob1 /DNDEBUG"     CACHE STRING "minSizeRel mode: no optimize" FORCE )
    set ( CMAKE_C_FLAGS_RELEASE          "/MD /O0 /Ob1 /DNDEBUG"     CACHE STRING "release mode: no optimize" FORCE )
    set ( CMAKE_C_FLAGS_RELWITHDEBINFO   "/MD /Zi /O0 /Ob1 /DNDEBUG" CACHE STRING "relWithDebugInfo mode: no optimize" FORCE )

    # do not have CMAKE_CXX_FLAGS;
    set ( CMAKE_CXX_FLAGS_DEBUG            "/MDd /Zi /Ob0 /Od /RTC1"   CACHE STRING "debug mode: no optimize" FORCE )
    set ( CMAKE_CXX_FLAGS_MINSIZEREL       "/MD /O0 /Ob1 /DNDEBUG"     CACHE STRING "minSizeRel mode: no optimize" FORCE )
    set ( CMAKE_CXX_FLAGS_RELEASE          "/MD /O0 /Ob1 /DNDEBUG"     CACHE STRING "release mode: no optimize" FORCE )
    set ( CMAKE_CXX_FLAGS_RELWITHDEBINFO   "/MD /Zi /O0 /Ob1 /DNDEBUG" CACHE STRING "relWithDebugInfo mode: no optimize" FORCE )
endif( UNIX )



# ---------------------------------------------- #
#               win 优化选项
# ---------------------------------------------- #
--------------------------------------
debug  ----- /MDd /Zi /Ob0 /Od /RTC1
/MDd - make a debug multithreaded DLL
/Zi - generate “complete debugging information”, 
	like -g for clang/gcc
/Ob0 - no auto-inlining
/Od - no optimization (无优化)
/RTC1 - run-time checking: report when a variable 
	is used without being initialized, 
	and stack frame run-time error checking. 
	See their site for more details.

--------------------------------------
mini    ----- /MD /O1 /Ob1 /DNDEBUG 
/O1 - optimize for size
/Ob1 - only inline functions that are marked inline, 
	and C++ member functions defined in a class declaration
--------------------------------------
release ----- /MD /O2 /Ob2 /DNDEBUG
/MD - make a multithreaded DLL
/O2 - optimize for speed （基于速度的优化）
/Ob2 - let compiler inline freely （）

======================================
relWithDegInfo -- /MD /Zi /O2 /Ob1 /DNDEBUG
	---
	这些需要手动在 vs 中修改


推荐的选项(release)：
/MD /O0 /Ob1 /DNDEBUG


================================================


# ---------------------------------------------- #
#           所有选项 解释（几乎）
# ---------------------------------------------- #
/DFOO - define FOO in the preprocessor
/EHsc - catch C++ exceptions, 
		assume extern "C" functions never throw C++ exceptions
/GR - enable RTTI
/MD - make a multithreaded DLL
/MDd - make a debug multithreaded DLL
/O1 - optimize for size
/O2 - optimize for speed
/Ob0 - no auto-inlining
/Ob1 - only inline functions that are marked inline, 
		and C++ member functions defined in a class declaration
/Ob2 - let compiler inline freely
/Od - no optimization
/RTC1 - run-time checking: report when a variable is used 
		without being initialized, 
		and stack frame run-time error checking. 
		See their site for more details.
/W3 - use warning level 3 (out of 4), “production quality”
/Zi - generate “complete debugging information”, like -g for clang/gcc




# ---------------------------------------------- #
#               CMakeCache.txt
# ---------------------------------------------- #













# ---------------------------------------------- #
#               
# ---------------------------------------------- #




# ---------------------------------------------- #
#               
# ---------------------------------------------- #



# ---------------------------------------------- #
#               
# ---------------------------------------------- #




