
# ================================================================ #
#                    Cmake手册 精简版
# ================================================================ #
https://www.zybuluo.com/khan-lau/note/254724
    -- 源资料地址。


# -------------------------------------#
#               变量
# -------------------------------------#

# cmake --help-variable-list
    键入此指令，可以陈列 cmake 的所有变量。
    （也许我们可以制作一个 shell 脚本 来 收集所有这些变量的 信息）

# cmake --help-variable < variable_name >
    显示 单个 cmake 变量的 说明

#-- 使用 shell 脚本： cmake_valiable.sh 
#-- 生成 同目录 文件： cmake_valiable_out.md
    可以直接 查看 此文件 来获得 所有 cmake 变量的信息。

    目前 此文件 列出的只是 教材中提到的 51 个变量
    实际有更多。




# ------------------------------------- #
#       command ／ 指令 ／ 函数
# ------------------------------------- #

# cmake --help-command-list
    罗列 cmake 支持的 全部 cmd／指令。

# cmake --help-command <CMD>
    显示 单个 CMD／指令 的说明






# cmake --help 
#    获得一下 提示（不全）：
# -----------------------------------------
Options
  -C <initial-cache>           = Pre-load a script to populate the cache.
  -D <var>[:<type>]=<value>    = Create a cmake cache entry.
  -U <globbing_expr>           = Remove matching entries from CMake cache.
  -G <generator-name>          = Specify a build system generator.
  -T <toolset-name>            = Specify toolset name if supported by
                                 generator.
  -A <platform-name>           = Specify platform name if supported by
                                 generator.
  -Wdev                        = Enable developer warnings.
  -Wno-dev                     = Suppress developer warnings.
  -Werror=dev                  = Make developer warnings errors.
  -Wno-error=dev               = Make developer warnings not errors.
  -Wdeprecated                 = Enable deprecation warnings.
  -Wno-deprecated              = Suppress deprecation warnings.
  -Werror=deprecated           = Make deprecated macro and function warnings
                                 errors.
  -Wno-error=deprecated        = Make deprecated macro and function warnings
                                 not errors.
  -E                           = CMake command mode.
  -L[A][H]                     = List non-advanced cached variables.
  --build <dir>                = Build a CMake-generated project binary tree.
  -N                           = View mode only.
  -P <file>                    = Process script mode.
  --find-package               = Run in pkg-config like mode.
  --graphviz=[file]            = Generate graphviz of dependencies, see
                                 CMakeGraphVizOptions.cmake for more.
  --system-information [file]  = Dump information about this system.
  --debug-trycompile           = Do not delete the try_compile build tree.
                                 Only useful on one try_compile at a time.
  --debug-output               = Put cmake in a debug mode.
  --trace                      = Put cmake in trace mode.
  --trace-expand               = Put cmake in trace mode with variable
                                 expansion.
  --trace-source=<file>        = Trace only this CMake file/module.  Multiple
                                 options allowed.
  --warn-uninitialized         = Warn about uninitialized values.
  --warn-unused-vars           = Warn about unused variables.
  --no-warn-unused-cli         = Don't warn about command line options.
  --check-system-vars          = Find problems with variable usage in system
                                 files.
  --help,-help,-usage,-h,-H,/? = Print usage information and exit.
  --version,-version,/V [<f>]  = Print version number and exit.

  --help-full [<f>]            = Print all help manuals and exit.
  --help-manual <man> [<f>]    = Print one help manual and exit.
  --help-manual-list [<f>]     = List help manuals available and exit.

  --help-command <cmd> [<f>]   = Print help for one command and exit.
  --help-command-list [<f>]    = List commands with help available and exit.
  --help-commands [<f>]        = Print cmake-commands manual and exit.

  --help-module <mod> [<f>]    = Print help for one module and exit.
  --help-module-list [<f>]     = List modules with help available and exit.
  --help-modules [<f>]         = Print cmake-modules manual and exit.

  --help-policy <cmp> [<f>]    = Print help for one policy and exit.
  --help-policy-list [<f>]     = List policies with help available and exit.
  --help-policies [<f>]        = Print cmake-policies manual and exit.

  --help-property <prop> [<f>] = Print help for one property and exit.
  --help-property-list [<f>]   = List properties with help available and exit.
  --help-properties [<f>]      = Print cmake-properties manual and exit.

  --help-variable var [<f>]    = Print help for one variable and exit.
  --help-variable-list [<f>]   = List variables with help available and exit.
  --help-variables [<f>]       = Print cmake-variables manual and exit.




