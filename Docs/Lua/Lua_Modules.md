# ======================================================= #
#                  Lua Modules
# ======================================================= #
https://www.lua.org/manual/5.3/manual.html#pdf-require

模块加载;

It exports one function directly in the global environment: require(). Everything else is exported in a table "package".
lua 在全局环境中暴露了一个函数 require(); 剩余的所有东西都以 table: package 的形式提供; 


# ----------------------------------------------#
#    函数:  require()
# ----------------------------------------------#

# 建议查看这个文中的 介绍:
https://tylerneylon.com/a/learn-lua/

# 简易用法:
    首先创建一个 lua 文件: a/b/ko.lua

    然后若在另一个文件里 include 这个文件, 可以写: 
        require("a.b.ko")

# -- 注意, 不需要写后缀名 .lua

# -- 目录层次用 . 区分

# -- 调用 require 只会运行一次目标文件;
不管你在一个文件里重复调用多少次 require("ko"),  最终只会运行一次;

想要多次调用, 改用 dofile, load stream 等函数才行 (拼写可能有问题)

# -- require 会从 package.path 路径内查找 目标文件;


    require 实际上是调一个个的 loader 去加载，有一个成功就不再往下尝试，全失败则报文件找不到。 
    目前 xLua 除了原生的 loader 外，还添加了从  Resource 加载的 loader，需要注意的是因为 Resource 只支持有限的后缀，
    放 Resources 下的 lua 文件得加上 txt 后缀（见附带的例子）。

    建议的加载 Lua 脚本方式是：整个程序就一个 DoString("require 'main'")，然后在 main.lua 加载其它脚本（类似 lua 脚本的命令行执行：lua main.lua）。

    有童鞋会问：要是我的Lua文件是下载回来的，或者某个自定义的文件格式里头解压出来，或者需要解密等等，怎么办？问得好，xLua的自定义Loader可以满足这些需求。


# ------------------ 官方文档: ------------------------
本函数会先检查 table: package.loaded, 看看参数 "modname" 是否已经被加载了, 如果已经被加载, 则本函数直接返回存储在 package.loaded[modname] 中的值;
(tpr: 这个值好像就是一整个 文件里的内容...)
否则, it tries to find a loader for the module, 本函数会试图寻找一个 "用于 module 的 loader";


为了找到一个 loader, require() 被 "package.searchers" 序列所引导; 
通过修改这个 序列, 我们可以改写 require() 是如何查找一个 module 的;

下方说明基于 package.searchers 的默认配置: (而不是我们自定义的)

    首先, require() 查询 table元素: package.preload[modname], 若有值, 则这个值一定是个函数, 且它就是我们要找的 loader;
    若上面一个失败了,  就使用 存储在 package.path 中的 path 来查找一个 lua loader;
    若上面一个也失败了, 就用存储在 package.cpath 中的 path 去找;
    若上面一个也失败了, 就返回一个 all-in-one loader (一体化的 loader) (see package.searchers)

一旦找到了一个 loader, require() 调用这个 loader, 传入两个参数: (1)modname, (2)an extra value dependent on how it got the loader;
(If the loader came from a file, this extra value is the file name.)

如果调用这个 loader 返回任何 非-nil 值, (此时说明调用成功了) require() 将把返回值存入  package.loaded[modname];
If the loader does not return a non-nil value and has not assigned any value to package.loaded[modname], then require assigns true to this entry.
...
如果调用 loader 返回 nil(说明加载失败), 且此时 package.loaded[modname] 中为空, 那么会向 package.loaded[modname] 中存入 true;

不管怎样, require() 会返回 package.loaded[modname] 中存储的最终值;

tpr:
    也就是说, 调用 require() 如果加载失败, 这个函数会返回一个 true;

若在 load 和 run 一个 module 时发生任何 error, 或没有找到任何 loader, require() 函数会抛出一个 error;




# ----------------------------------------------#
#     string:  package.config
# ----------------------------------------------#
A string describing some compile-time configurations for packages. 
描述 package 的一些 编译时配置;

这个字符串是一系列 lines 的组合:
--1--
    The first line is the directory separator string. Default is '\' for Windows and '/' for all other systems.
    第一行: 目录分隔符, win中为 '\', 其他系统中为 '/';

--2--
    The second line is the character that separates templates in a path. Default is ';'
    第二行: 一个 path 中各个 templates 之间的 分隔符, 默认为 ';'

--3--
    The third line is the string that marks the substitution points in a template. Default is '?'.
    第三行: 在一个 template 中代表 目标变量的 替代符, 默认为 '?'

--4--
    The fourth line is a string that, in a path in Windows, is replaced by the executable's directory. Default is '!'.


--5--
    The fifth line is a mark to ignore all text after it when building the luaopen_ function name. Default is '-'.
    第五行: 一个符号, 在 module name 中, 一旦发现这个符号, 会把它以及它之后的所有 字符全部剔除, 
    默认为 '-'


# ----------------------------------------------#
#     path:  package.cpath
# ----------------------------------------------#
The path used by require() to search for a C loader.

Lua initializes the C path "package.cpath" in the same way it initializes the Lua path "package.path", 
using the environment variable LUA_CPATH_5_3, or the environment variable LUA_CPATH, or a default path defined in luaconf.h.
---
使用 环境变量 LUA_CPATH_5_3 中的值, 或 环境变量 LUA_CPATH 中的值, 或定义在 luaconf.h 中的一个默认值, 来初始化 package.cpath;




# ----------------------------------------------#
#     table:  package.loaded
# ----------------------------------------------#
A table used by require() to control which modules are already loaded. 

当你需要加载 "modname", 且 package.loaded[modname] 不为 false 时, require() 函数会直接返回 package.loaded[modname];

This variable is only a reference to the real table; assignments to this variable do not change the table used by require.
本变量: "package.loaded" 仅仅是那个真正 table 的引用, 对本变量的赋值 不会影响到 require() 所使用的那个 table;



# ----------------------------------------------#
#     函数:  package.loadlib(libname, funcname)
# ----------------------------------------------#
Dynamically links the host program with the C library libname.
---
将宿主app 和一个 c lib 动态链接起来;

如果参数 funcname 值为 '*', 则本函数只会将 目标 lib 链接起来, 把 lib 的 symbols 暴露出来, 以供其他动态链接库 使用;
否则, 他会在目标 lib 内查找名为 参数funcname 的函数, 并将这个函数 以 c函数的 形式 返回出来;
所以, 参数 funcname 必须符合 lua_CFunction 样式  (这个有待翻译)


This is a low-level function. It completely bypasses the package and module system. Unlike require, it does not perform any path searching and does not automatically adds extensions. libname must be the complete file name of the C library, including if necessary a path and an extension. 
funcname must be the exact name exported by the C library (which may depend on the C compiler and linker used).

这是一个底层函数, 它彻底绕开了 package 和 module 系统; 和 require() 函数不同, 它不执行任何 path 搜索, 也不自动添加任何 extensions (文件后缀名)
参数 libname 必须是 the complete file name of the C library, 包含一个完整的 path 和文件后缀名;
参数 funcname 必须是 c lib 外露的那个 名字 ( 具体格式由 c编译器 和 连接器 决定 )

本函数不是由 Standard C 提供的, 因此它仅被部分平台支持: (Windows, Linux, Mac OS X, Solaris, BSD, plus other Unix systems that support the "dlfcn" standard).


# ----------------------------------------------#
#     path:  package.path
# ----------------------------------------------#
The path used by require() to search for a Lua loader.

在最开始, lua 使用 环境变量 LUA_PATH_5_3 中的值, 或 环境变量 LUA_PATH 中的值, 或定义在 luaconf.h 中的一个默认值, 来初始化 package.cpath;

Any ";;" in the value of the environment variable is replaced by the default path.
环境变量 值中的任何 ";;" 都会被替换为  default path

# ----------------------------------------------#
#     table:  package.preload
# ----------------------------------------------#
A table to store loaders for specific modules (see 函数 require() ).

存储各个特定的 module 所对应的 loader;

This variable is only a reference to the real table; assignments to this variable do not change the table used by require.
本变量只是 真正 table 的一个引用..


# ----------------------------------------------#
#     table:  package.searchers
# ----------------------------------------------#
A table used by require() to control how to load modules.

本 table 中的每个元素 都是一个 searcher function; 当寻找一个 module 时, require() 使用它的唯一参数 "modname" 以升序来逐个调用每一个 searchers 函数;
每次 searcher 函数调用 可能会返回返回:
    { 另一个函数, 一个 module loader; 一个额外的值, 这个值会被传入上面的 loader 函数; }
也可能返回:
    一个字符串, 来解释为什么没有找到 module, (此字符串可能为 nil, 如果没啥可说的话)



Lua initializes this table with four searcher functions.

# lua 在初始化阶段, 会向这个 table 填入 4 个 searcher functions;
--1--
    The first searcher simply looks for a loader in the package.preload table.
    第一个 searcher 函数, 会在 table: package.preload 中查找 loader;


--2--
    The second searcher looks for a loader as a Lua library
    使用存储在 package.path 中的 path
    具体介绍 见函数: package.searchpath()

--3--
    The third searcher looks for a loader as a C library, 
    使用存储在 变量 package.cpath 中的 path;
    具体介绍 见函数: package.searchpath()

    例如, if the C path is the string:

        "./?.so;./?.dll;/usr/local/?/init.so"

    此时查找 module "foo", 会试图 依次 打开文件:
        ./foo.so, 
        ./foo.dll, 
        /usr/local/foo/init.so
    
    
    Once it finds a C library, this searcher first uses a dynamic link facility to link the application with the library. 
    Then it tries to find a C function inside the library to be used as the loader. 
    ---
    一旦它找到一个 C library, searcher 会首先使用一个 动态链接工具 来将这个 lib 和 app 链接到一起; 
    然后它试图在 lib 内找到一个 被用作 loader 的 c函数;

    这个 c函数的名字格式为:  "luaopen_" 后面串联一个 module name,(里面的每一个 '.' 被替换成 '_' )
    如果 module name 里包含 hyphen ('-'), 则这个 module name 中,第一个 '-' 及其后面的所有字符 都会被剔除;

    举例:
        如果 module 值为: "a.b.c-v2.1", 则 c函数名为: "luaopen_a_b_c"
    
--4--
    The fourth searcher tries an all-in-one loader. 
    第四个 searcher 尝试使用一体式加载器。

    It searches the C path for a library for the root name of the given module. 
    For instance, when requiring a.b.c, it will search for a C library for a. 
    If found, it looks into it for an open function for the submodule; 
    in our example, that would be luaopen_a_b_c. 
    With this facility, a package can pack several C submodules into one single library, with each submodule keeping its original open function.

All searchers except the first one (preload) return as the extra value the file name where the module was found, as returned by package.searchpath. The first searcher returns no extra value.
当目标 module 被找到时, 二三四种方法都会将 file name 当作一个额外值, 以 package.searchpath() 的返回值 返回出来;
第一种方法不返回 额外的值;



# ----------------------------------------------#
#     函数:  package.searchpath (name, path [, sep [, rep]])
# ----------------------------------------------#
Searches for the given name in the given path.

path 是一个 string, 包含一系列 templates, 之间由 ';' 分隔; 
对于每个 template, 系统会用 参数 module name 替换 template 中的 '?' 符, 使用 当前平台支持的目录分割符,(比如'\','/') 替换 template 中的 '.';
and then tries to open the resulting file name.
然后试图打开这个 文件;


比如, if the path is the string:

     "./?.lua;./?.lc;/usr/local/?/init.lua"

此时若用 name = "foo.a" 来调用 searchpath() 函数, 那么系统将试图按顺序打开:
    ./foo/a.lua 
    ./foo/a.lc
    /usr/local/foo/a/init.lua

如果本函数找到第一个能打开的文件, 那就用 read mode 打开它,然后 close 它, 然后返回它的 the resulting name;
如果没能成功打开任何一个文件, 就返回一个 nil, 外加 error messages; (This error message lists all file names it tried to open.)



