# ========================================================= #
#                          Lua Base
# ========================================================= #


# 参考手册
https://www.runoob.com/manual/lua53doc/

http://www.lua.org/manual/5.3/



# 15 分钟 学完 Lua
https://tylerneylon.com/a/learn-lua/


# 另一个快速浏览的 教程
https://zhuanlan.zhihu.com/p/76248759


# Lua 5.3 字节码引用 (虚拟机)
Lua 5.3 Bytecode Reference



# ==================================================== #
#          在线写代码
# ---------------------------------------------------- #
https://wiki.luatos.com/_static/luatos-emulator/lua.html



# ==================================================== #
#                      安装   [ mac ]
# ---------------------------------------------------- #

# ======== 方法一，homebrew ======
    brew install lua

# ======== 方法二，本地编译 [- 推荐 -] ======

# ==1== 下载 ==

    下载 Lua 5.3 安装包 from：
    https://www.lua.org/

# ==2==  编译 ==

    在 安装包更目录，执行： make
    -- 此时会跳出 一组平台名 列表。
    -- 比如在 mac 上，执行： make macosx

=   编译完成后，会在 /src/目录下，创建三个 新文件：
    -- lua  :  解释器
    -- luac :  编译器
    -- liblua.a : 库文件

=   为了检测 lua 是否 build 正确，执行： make test
    这将运行 解释器，并打印版本号


# ==3== 安装 ==

=   如果想要 安装到 操作系统默认路径
    执行 make install 
    -- 默认安装路径 定义在 makefile 文件中


=   如果想要安装到 当前目录（lua源代码root目录，.../lua-5.3.5/ ）
    [推荐]
    执行：make local
    会在 .../lua-5.3.5/ 目录下 新建一个目录 install/
    然后将 lua 安装进这个 install/ 目录中，结构如下：
=    bin:
        lua luac
=    include: （ include 下的一个 子目录 include ）
        lua.h luaconf.h lualib.h lauxlib.h lua.hpp
=    lib:
        liblua.a
=    man/man1:
        lua.1 luac.1

=  bin/, man/ 目录下的文件用于 运行 lua程序
=  include/, lib/ 目录下的文件用于 将 lua 嵌入到 C/C++ 程序中



# ==================================================== #
#                 运行 lua 小程序 
# ---------------------------------------------------- #

#--  制作一个 名为 xxx.lua 的文件。
#--  在头部写入：
    #!/usr/local/bin/lua
     从而设置 此脚本的 执行程序
     （就像 shell 一样）
    
#--  在文件所在目录中执行：
    chmod  u+x  xxx.lua
     
#--  执行：
    ./xxx.lua


# ==================================================== #
#                    语法
# ---------------------------------------------------- #

# ======  注释  ======
#     -- xxxx
      单行注释

# !!!!!!!
#     --[[  xxxx
#           xxxx
#     --]]  
      多行注释


# ======  标示符／变量名  ======
  不要使用 下划线+大字母 的名字,比如:
    _VERSION 
  这是 lua 保留字 的用法。

# ======  关键词  ======
    and
    break
    do
    else
    elseif
    end
    for
    function -- 由 C／Lua 编写的函数 
    if
    in
    local
    nil  -- 表示一个 空变量／无效值
    not
    or
    repeat
    return
    then
    true   -- type: boolean 0 也表示 true
    false  -- type: boolean
    until
    while

# ======  全局变量  ======

#--    新建的变量，默认为 全局变量
#--    一个 未初始化的 全局变量，值为 nil
#--    若想删除一个 全局变量，只需将其赋值为 nil
        这个变量 就好像从没被使用过一样
        当且仅当一个变量不等于 nil 时，这个变量 即被看做存在


# ======  数据类型  ======
#    一共 8 种：

    nil      -- 只有值 nil 属于该类
                表示一个无效值（在条件表达式中相当于false）

    boolean  -- 包含两个值：false 和 true
                只有 false 和 nil 代表 假, 剩余一切值都为 真

    number   -- integer -- int64
                float   -- 双精度浮点数 (类比 double )

    string   -- 字符串由一对双引号或单引号来表示

    function -- 由 C 或 Lua 编写的函数

    userdata -- 表示任意存储在变量中的C数据结构

    thread   -- 表示执行的独立线路，用于执行协同程序

    table    -- "关联数组"/associative arrays
                数组的索引可以是 数字 或者是 字符串
                table 的创建是通过 "构造表达式" 来完成，
                最简单构造表达式是 {}，用来创建一个空表

#    print( type( "koko" ) )
#    --> string
    通过 type() 函数 来测试 值的类型


# ----------------------------------------------#
#        值: NaN
# ----------------------------------------------#
Not a Number is a special value used to represent undefined or unrepresentable numerical results, such as 0/0;
一般在除 0 时出现;

# NaN 的类型为: number: float:

暂时没发现怎么 确认这个值...




# ----------------------------------------------#
#         type: userdata 
# ----------------------------------------------#
The type userdata is provided to allow arbitrary C data to be stored in Lua variables. This type corresponds to a block of raw memory and has no pre-defined operations in Lua, except assignment and identity test. However, by using metatables, the programmer can define operations for userdata values (see §2.8). Userdata values cannot be created or modified in Lua, only through the C API. This guarantees the integrity of data owned by the host program.
-------

这个类型是为了让 任意的 c数据 存储在一个 lua 变量中;
这个类型代表一个 生二进制 数据块, lua 不存在对它的 预定义操作; (但是 lua 可以为它 分配内存, 以及 身份验证)
但是, 通过使用 metatable, 程序员可定义对 userdata 类型变量的 操作;
不能在 lua 中创建 和 修改 userdata 变量, 只能通过 c api 来生成和改写;
这保证了 宿主程序对 这些数据的 完整拥有权;





# ----------------------------------------------#
#               位运算  位
# ----------------------------------------------#
Bitwise AND: &
Bitwise OR: |
Bitwise XOR: ~
Bitwise NOT (complement): ~
Bitwise left shift: <<
Bitwise right shift: >>
Arithmetic right shift: >>>



# ----------------------------------------------#
#           真 假
# ----------------------------------------------#
# 只有 false 和 nil 代表 假, 剩余一切值都为 真 !!!

比如, 0 就代表 真

# ----------------------------------------------#
#            and / or / not
# ----------------------------------------------#

# 原则上, and, or, not 其实符合常规语言中的 &&, ||, ! 操作;
# 但是, 这三个运算符返回的不是 bool 类型元素, 而是它的操作数:

#  and: 
    若第一操作数 是 false/nil, 返回第一操作数 (即 false/nil )。否则反而第二个

nil   and 13 --> nil
false and 13 --> false
7     and 13 --> 13

#  or:
    若第一操作数 不是 false/nil, 返回第一操作数。否则反而第二个

nil   or 13 --> 13
false or 13 --> 13
7     or 13 --> 7
0     or 13 --> 0


# 用法: (有点类似 三元运算符)
    a = 0
    print( a>1 and "yes" or "no" )

将返回 "no", 
如何分析:
首先运行 and 这一对, 因为 a>1 为假, 所以 and 这对返回 nil,
表达式变成了:
    nil or "no"
此处, "no" 为真, 所以最终返回 "no"

# 注意: 
    仔细分析可知:
        and true or false -- 是符合预期的
        and false or true -- 会返回 true....
    ---
    所以这个 三元运算符 也不会随意地写



# ----------------------------------------------#
#     类型转换 bool to string
# ----------------------------------------------#

local b = true

# -1-:  b and "true" or "false"
# -2-: tostring(b)




# ----------------------------------------------#
#     普通除法:  /
#     地板除:    //
# ----------------------------------------------#

print( 12//5 )  -- 得到 2


# 注意 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
# '/' 是普通除法, 就算传入两个 int 值, 它也能给你除一个 float 出来...


# ----------------------------------------------#
#     取模:  %
# ----------------------------------------------#

# 也能作用于 浮点数:
    local a = 12345.6789
    local b = a % 100       
    print( "b = " .. b )    -- 45.6789



# ----------------------------------------------#
#     不等于: ~= 
# ----------------------------------------------#
注意, 不是用 != 来表达;

# ----------------------------------------------#
#     两个字符串的连接 ..
# ----------------------------------------------#
a = "ko"
b = "12"
c = a..b

用 ".." 来连接两个字符串; 注意, 也可写成 "a .. b" (允许存在空格)


# ----------------------------------------------#
#     分支判断 if:
# ----------------------------------------------#

    if a>1 then
        -- do a
    elseif a>0 then
        -- do b
    else
        -- do c
    end


# ----------------------------------------------#
#     for 循环
# ----------------------------------------------#

# -1- 常规理解的循环, 每回合 i 加 1:
    for i=1,10 do
        -- something
    end

# -2- 指定步长版, 每回合 i 加 2:
    for i=1,10,2 do
        -- something
    end


# 不允许在 for 循环内对 i 这个值进行修改 !!!!!
    如果你修改了 i, 那句话会被 lua 强制改为: local i = "..."
    等于给你新建了一个本地变量 i, 还是无法影响循环使用的那个 i;

# 可以使用 break;



# ----------------------------------------------#
#     while 循环
# ----------------------------------------------#
    local n = 10
    while n>0 do
        n = n -1      -- lua 中没有 "n--" 这种自减操作符
    end




# ----------------------------------------------#
#  字符串 数值 转换
#     tostring
#     tonumber
# ----------------------------------------------#
a = tostring(10)   -- 得到字符串 "10"

b = tonumber("10")  -- 得到数值: 10

# 如果 转换失败, 则返回 nil;


# ----------------------------------------------#
#  获得字符串长度: #
# ----------------------------------------------#
a = "123"
b = #a      -- 得到数值: 3

# -- "#" 也可用来获取一个 table 的元素个数
    t = {1,2,3}
    print( #t )


# !!!!! 注意, 如果 table 是字典, 比如: t = {a="a1",b="b1"}
    #t 将获得 0 ....

    此时只能用 pairs(t) 老老实实遍历这个 t 来获得长度;

    项目中可直接使用 table.count(t) 来获得 (就是用了上面的原理)


# ----------------------------------------------#
#     # 和 string.len(s) 的区别
# ----------------------------------------------#
当用于 string 时, 两个操作时等价的, 都能得到 string 的字节数;

但是 # 可获得任意 table 的连续元素个数; (若中间有空洞, 则在第一个空洞位置被中断, 只得到前面部分的元素个数)

# 若使用 string.len 去访问一个 普通 table 的元素个数, 将报错;




# ----------------------------------------------#
#         长字符串 [[ koko ]]
# ----------------------------------------------#

longstr = [[
a
bb
"koko"
ccc
]]

print(longstr)

#   通过 [[ ... ]] 来实现一个跨越多行的 长字符串
#   优点：
#   -1- 内部的所有符号可以原样打印，比如 " 这种，不会自动转意
#   [[后面如果紧跟着一个 '\n' 符，这个 换行符将被忽略。

#   是记载字符串的 理想方式。

# ------
#   如果在这个字符串内部也有 [ ] 怎么办？

longstr = [===[
a
b
[c]
d
e
]===]

#   首位界符中的等号数量一定要相符。
#   并且避免在 字符串中 再出现 相同的 符号



# ----------------------------------------------#
#     func{table_a} = func( {table_a} )
#     func{a,b,c} = func( {a,b,c} )
# ----------------------------------------------#
   当参数为一个 表，表构造器时，可以省略 函数调用的 小括号




# ----------------------------------------------#
#   函数的声明 function
# ----------------------------------------------#

# -1- 函数名放后面
    function Foo(...)
        -- func body
    end

# -2- 函数名放前面
    Foo = function(...)
        -- func body
    end

# 返回值
-1-
    若函数没写 return 语句, 则默认返回 nil
-2-
    return ...
    可以一次返回多个值, 比如: return a,b,c
    多个返回值, 可以配合 多重赋值语句



# ----------------------------------------------#
#   函数的 可选参数
# ----------------------------------------------#

    Boo( a,[, b, [, c]] )

此处的 b, c 就是可选参数;




# ----------------------------------------------#
#   table   (数组风格的)
# ----------------------------------------------#

# -1-:
    a = { 1, "koko", {}, function() end }

上面这个 table 里可以存任何类型的数据, 甚至一个函数

# 访问的时候, 下标从 1 开始数;
    a[1]

# 如果下标越界,比如 a[99], 则返回 nil

# ------
# 单独对 table 一个元素进行赋值:
    a = {1,2}
    a[99] = "koko"
    print(a[98])   -- 得到: nil
    print(a[99])   -- 得到: "koko"


# ----------------------------------------------#
#  table 元素 value 为 nil
# ----------------------------------------------#

    t = {
        a = 1,
        b = nil,
        c = 3,
    }

    for k,_ in pairs(t) do 
        print( k,_ )
    end
    -----

    print( t["a"] )  -- !!! 注意这里写入 key 的格式
    -----

注意观察, 元素 b 的值为 nil, 此时用 for去遍历 t, 将直接跳过 b 这个元素;

# 利用这个特征, 可以让很多代码 被简化;


# 依赖 元方法: __pairs



# ----------------------------------------------#
#   table  rehash
# ----------------------------------------------#

具体实现参考:
https://zhuanlan.zhihu.com/p/97830462


当我们把一个新键值赋给 表 时，若 数组 和 哈希表 已经满了，则会触发一次 rehash; 再哈希 的代价是高昂的;
首先会在内存中分配一个新的长度的数组, 然后将所有记录再全部哈希一遍, 将原来的记录转移到新数组中;
新哈希表的长度是最接近于所有元素数目的 2的乘方;

从上面可以看出来，表的赋值所需要付出的代价是由表的初始大小与表最后的规模来决定的。

　　于是我们可以这么来做：

　　如果我们以：

　　　　a = {}

　　来创建一个初始表，这个表的大小首先为0，当我们往表中插入数据时，如果表内已经满了，则将触发一次 rehash，lua将新创建一个更大的表，直至表再次填满。
　　如果在程序运行期间去做这个工作，我们将需要付出更多的时间与性能的代价，于是我们可以这么做：

　　如果可以预期表内将有3个元素，则在创建表的时候就填充表的大小，譬如：

　　　　a = {1,1,1}

　　这样将使表的填充效率成倍的提升。





# ----------------------------------------------#
#  获得 table 长度: #
# ----------------------------------------------#
    a = {1,2}
    a[99] = "koko"
    print( #a )    -- 最终得到: 2, 因为虽然存在 [99] 元素, 但从第3个元素开始断了, 程序不再往下查找;


# ----------------------------------------------#
#   table.insert( tableA, element)
# ----------------------------------------------#

# -- table.insert( tableA, element)
    在尾后 插入一个元素

# -- table.insert( tableA, 2, element)
    在 第二个元素位置插入, 原来的 2号元素后移


#  table.remove( tableA, 2 )
    移除 table 中的 2 号元素;
    并将移除的这个元素 返回出去


# ----------------------------------------------#
#  从数组型 table 中删除元素 remove()
# ----------------------------------------------#

    tbl = {1, 2, 2, 3, 4, 5}
    
    -- 倒序遍历：在for循环中进行删除的正确遍历方式
    for i = #tbl, 1, -1 do
        if tbl[i] == 2 then
            table.remove(tbl, i)
        end
    end
    print(unpack(tbl))
    -- 1   3   4   5






# ----------------------------------------------#
#   table   ( key-value 风格的 )
# ----------------------------------------------#
    tb = {
        a = 1
        b = "ko"
        c = {}
    }

    print( tb["a"] )  -- 可以发现是用 key 去搜索值的;
    print( tb.a )     -- 另一种访问方式, 

# 还可以再添加元素:

    tb[",,."] = 12      -- 添加了一个元素
    print( tb[",,."] )  -- 得到: 12


# 另一种声明方式:
    tb = {
        ["kk"] = 99
    }

    这个方法等价于在内部写: 
        kk = 99

    这个方法的好处是, key 这个字符串的约束会更少, 比如可以写成:

        [".kk"] = 99

    也是正确的, 此时可用 tb[".kk"] 去正确访问它... 

    使用这个方法, key 还可以用的更花: 
        u = 
        {
            ['@!#'] = 'qbert', 
            [{}]    = 1729,      ---- 这么写是错的.... 访问它会得到 nil;
            [6.28]  = 'tau'
        }
        print( u[6.28] )  -- prints "tau"
        ---





# ----------------------------------------------#
#    迭代器-1-: ipairs   (适合迭代 数字下标的 table)
# ----------------------------------------------#

# 手动编写迭代:
    t = {"a","b","c"}

    for i=1, #t do
        print( i, t[i] )
    end

# ipairs:

    for i,j in ipairs(t) do
        print( i, j )
    end
    ---
    把 下标 i 给 i, 把 t[i] 给 j;

# 缺点, 如果这个 table 下标不连续, 比如
t = {1,2}
t[9] = 9;

此时使用 ipairs 只能遍历前面 2 个元素, 到第三个就终止了, [9] 元素会被丢失;

# 此时可改用 pairs 迭代器:


#  ipairs 是 "无迭代器" 版本, 理论上性能更优秀;




# ----------------------------------------------#
#    迭代器-2-: pairs   (同时适合 数字下标的 table, 和 key-value 格式的 table)
# ----------------------------------------------#
    t = {
        a = "1"
        b = "2"
        c = "3"
    }
    for i,j in pairs(t) do
        print( i, j )
    end

# 不管 table 内放了什么元素, 都能完整迭代完

# pairs 内部依赖一个 next() 函数




# ----------------------------------------------#
#         table Add 元素
# ----------------------------------------------#

t = {}

t[#t+1] = 1
t[#t+1] = 2
t[#t+1] = 2

用这个格式可以在尾后添加新元素;



# ----------------------------------------------#
#      面向对象
# ----------------------------------------------#

# 一个语法糖: " 冒号 : "
    t = {
        a = 0,
        add = function(tab, sum)
            tab.a = tab.a + sum
        end
    }

    t.add(t,10)   -- 常规写法
    t:add(10)     -- 面向对象写法


# 用上述语法糖, 实现 lua 的 面向对象:
https://www.bilibili.com/video/BV1WR4y1E7ud?p=7 第7课

bag = {}
bagmt = {
    put = function(t,item)   -- 放入一个元素
        table.insert( t.items, item )
    end,
    take = function(t)       -- 取出一个元素
        return table.remove( t.items, item )
    end,
    list = function(t)       -- 将所有元素连成一个 string, 中间用 ',' 分隔;
        return table.concat( t.items, "," )
    end,
    clear = function(t,item)   -- 清空表
        t.items = {}
    end,

}
bagmt["__index"] = bagmt   -- 这样一来,当 bag 中找不到目标元素时, 就会到 bagmt 中去找

function bag.new()
    -- 为每个新实例准备一个专属于它的 table: t 
    local t = {
        items = {}
    }
    setmetatable(t,bagmt)
    return t
end
-------

local b = bag.new()  -- 现在可用 new() 新建很多个实例了
b:put("apple1")
b:put("apple2")
print( b:list() )



# 另一种 oop 方法声明方式:

    function metatable:Foo(key) 
        ... self ...
    end

注意,在此方法中, 不用 '.' 改用 ':', 
且隐藏首参数;
然后在函数体内, 可直接访问 self, (把它当首参数来访问)




# ----------------------------------------------#
#      协程
# ----------------------------------------------#

建议直接使用 xlua 版的, 项目里的那种写法




# ----------------------------------------------#
#   查看 lua 版本
#      _VERSION
# ----------------------------------------------#

    print( "lua 版: ".._VERSION )

目前项目为 5.4



# ----------------------------------------------#
#      Log
#      Debug
#      console 打印信息
# ----------------------------------------------#

# -- 常规信息:
    print("koko"..intVal.."; ")

# -- error:
    printError("此处有错误: %s; 错误完毕", debug.traceback())
    ---
    好吧, 这个貌似是项目自己封装的...



# ----------------------------------------------#
#      lua 特殊的 访问权限管理
# ----------------------------------------------#

https://zhuanlan.zhihu.com/p/76248759
# 案例:
    local function New()
        local obj = {       -- 这就是要创建的对象
            _data1 = 1,     -- 假设这是内部数据
            _data2 = 2,     -- 这是外部可修改的数据
        }
        return {            -- 这是返回的接口table
            get_data2 = function() return obj._data2 end,
            set_data2 = function(value) obj._data2 = value end,
        }
    end

    local outObj = New()
    outObj.set_data2( 100 )
    print( outObj.get_data2() )     --> 100
    -------------------

和 c系列语言不用, 此处真正的 instance 是函数体内的 local obj; 它拥有 私有变量 _data1 和 公共变量 _data2;

函数 New() 返回的其实是一个 代理obj; 在这个阶段, 那个真正的 obj 变成了 upvalues;
返回的 代理obj 则只提供安全的 访问接口;



# ----------------------------------------------#
#     环境 和 全局环境
#     _G
#     _ENV
# ----------------------------------------------#

# 2.2 – Environments and the Global Environment 翻译:
https://www.lua.org/manual/5.3/manual.html


正如将在 §3.2 and §3.3.3 中要讲的, 

any reference to a free name (that is, a name not bound to any declaration) var is syntactically translated to _ENV.var.
一个 free name var, 比如写了一个 a=9 , 那么这个 a 实际上是 _ENV.a

Moreover, every chunk is compiled in the scope of an external local variable named _ENV (see §3.3.2), 
so _ENV itself is never a free name in a chunk.
此外，每个块都在名为 _ENV 的外部局部变量的范围内编译（参见 §3.3.2），因此 _ENV 本身绝不是块中的自由名称。

尽管存在 "external _ENV variable" 和 "free names" 的称号, _ENV 其实是个完全 常规的 name;

特别是, 你可以用这个 变量名 去定义新的 变量 和 参数;

Each reference to a free name uses the _ENV that is visible at that point in the program, following the usual visibility rules of Lua (see §3.5).

# Any table used as the value of _ENV is called an environment.

Lua keeps a distinguished environment called the global environment. This value is kept at a special index in the C registry (see §4.5). 
In Lua, the global variable _G is initialized with this same value. ( _G is never used internally. )


When Lua loads a chunk, the default value for its _ENV upvalue is the global environment (see load() ). 
Therefore, by default, free names in Lua code refer to entries in the global environment (and, therefore, they are also called global variables).
 
而且, 所以 标准库 都会被加载进 global environment, 并且那里的一些函数在 global environment 中运行;

你可调用 load() 和 loadfile() 加载一个 chunk 到一个不同的 环境中去;
(In C, you have to load the chunk and then change the value of its first upvalue.)
在 c 中, 你需要加载那个 chunk, 然后修改它的第一个 upvalue



# ----------------------------------------------#
#    设置 lua 局部变量的 属性   [5.4 新功能]
# ----------------------------------------------#
https://zhuanlan.zhihu.com/p/137588708

# ----- 1 ------:
#  <const>

    local a <const> = 4
    local b = a + 7
    print(b)

有点类似 静态语言中的 常量变量, 就是能在编译阶段, 将 变量a 直接替换为 4;

# ----- 2 ------:
#  <close>
类似 c++ 的 RAII:
这个 变量在离开自己的作用域后, 会被立刻 release;

close 变量 (To-be-closed Variables) 需要和 close 元方法 结合使用，
在变量超出作用域时，会调用变量的 close 元方法;





# ----------------------------------------------#
#    限制 小数点  后位数
# ----------------------------------------------#

local num = 3.14159
local formattedNum = string.format("%.2f", num)



# ----------------------------------------------#
#    os.time()
# ----------------------------------------------#

在 Lua 中，os.time() 函数返回的是自 1970 年 1 月 1 日（UTC）以来经过的秒数，这个时间点通常被称为“Unix 时间戳”或“Epoch 时间”。
在你的例子中，t = 1738485289 表示自这个起点以来的秒数。






