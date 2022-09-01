# ========================================================= #
#                          Lua_funcs
# ========================================================= #




# ================================ #
#           _G
# -------------------------------- #
一个全局变量，容纳 全局环境 ／ global environment
lua 自己不使用这些 变量。
改变这些变量 不会影响任何环境 ／ environment
反之亦然

当你不在变量前使用 local 关键字的时候，
这个变量会被放在 _G 这个全局表中。


# 说白了就是:
_G 是一个 table, 然后如果我们在代码中编写: k = 1  那么这个 k 其实就被申明到 _G 这个 table 中去了;




# ================================ #
#           _VERSION
# -------------------------------- #
一个全局变量, 存储一个字符串，表示lua版本
通常为 "Lua 5.3"



# ----------------------------------------------#
#                  闭包
# ----------------------------------------------#
https://blog.csdn.net/maximuszhou/article/details/44280109

# upvalue

# 上面这篇文章 写得非常好 !!!!!!!




# ================================ #
#      assert (v [, message])
# -------------------------------- #
Calls error if the value of its argument v is false (i.e., nil or false); otherwise, returns all its arguments. In case of error, message is the error object; when absent, it defaults to "assertion failed!"

若参数 v 为 nil 或 false, 则报错; 
否则, 返回它的 所有 参数;

参数 message 为出错信息 ／ error object
如果不设置，将使用默认值 “assertion failed!”



# ================================ #
#     error (message [, level])
# -------------------------------- #
终止 最后一个 受保护的函数调用／the last protected function called (?)
参数 message 为出错信息 ／ error object
本函数永远不 返回 ／ return

参数 level 指定了如何获得 error postion
level 默认为 1. 此时，error position 指向 error函数被调用的位置。
level = 2，则，error position 指向 “调用error的函数” 被调用的位置。
以此类推

level = 0。则阻止将 error position 添加到 error msg 中（不显示）


# ================================ #
#   load (chunk [, chunkname [, mode [, env]]])
# -------------------------------- #
Loads a chunk.

如果 参数chunk 是字符串，那么 最终chunk 就是这组字符串
如果 参数chunk 是个 function 类型数据，
    本函数将 不停地调用这个函数，来获得所有 chunk pieces
    每次调用 函数chunk，都必须返回一个 字符串，
    且这个 返回字符串，需要与 之前返回的字符串 相关联
    如果某次返回值是 空字符串，nil，或无返回值，
    标志着 函数chunk 调用的终止。

如果整个过程没有 句法error。 将编译好的 chunk，以 function的格式 返回。
否则，返回 nil，外加 error msg

如果最终获得的 function 拥有 upvalues.
第一个 upvalues 被设置为 参数env 的值。
如果 参数env 未设置，则将 第一个 upvalues 设置为 global environment。
剩余的 upvalues 被以 nil 初始化。

如果 load 的是 main chunk，返回的 function 总是拥有一个 upvalues：_ENV
然而，如果 load 的 二进制chunk 是由一个 function生成的， 那么 返回的function
可以拥有 任意数量的 upvalues。
所有的 upvalues 都是新鲜的，它们不与 其他任何 function 分享。

参数chunkname 被用于 error msg 和 debug info
如果此参数未设置，
    -- 如果参数chunk 为字符串，参数chunkname 被默认设置等于它
    -- 否则，参数chunkname 被默认设置为  "=(load)"

参数mode 是个字符串，
    -- "b"  -- only binary chunks
    -- "t"  -- only text chunks
    -- "bt" -- both binary and text (默认值)

lua 并不检测 二进制chunk 的连贯性(?)
怀有恶意的 二进制chunk，可以使 解释器崩溃。


# ================================ #
#    loadfile ([filename [, mode [, env]]])
# -------------------------------- #
与函数 load 相似。
不同在于，要么从 参数filename 处获得 chunk 来源
要么从 stdin 获得，



# ================================ #
#       dofile ([filename])
# -------------------------------- #
打开 目标文件，并将它的内容当作一个 lua chunk 来运行 
当没有参数时，本函数 执行 stdin 输入得 数据

返回值就是 目标chunk返回的 一切数据

本函数并不运行在 protected mode，
而是将自己运行期间的 error，统统返回给 dofile函数的 调用者


# ================================ #
#   setmetatable (table, metatable)
# -------------------------------- #
为 参数table 设置一个 元表，也就是 参数metatable 

如果 参数metatable 为 nil，则将移除 参数table 的元表
此时，如果 原来的 元表 拥有一个 __metatable 字段
将引发一个 error


# ================================ #
#    getmetatable (object)
# -------------------------------- #
获得 参数object 的元表
如果参数没有 元表，返回 nil。
否则，如果 参数obj 拥有一个 __metatable 字段，返回 相关联的变量
否则，返回 参数obj 的元表


# ================================ #
#      tostring (v)
# -------------------------------- #
参数v 可以为任何类型。并将它转换为 人类可读的形式。

如果 参数v 的元表 拥有 __tostring 字段（一个方法／函数），
本函数 将调用这个函数 来完成工作，将 参数v 作为参数传入 __tostring
然后把 __tostring 函数的返回值 当作 本函数自己的返回值 返回出来

本函数 常用于 print 函数的实现。

可向其传入任意 变量 (包括不存在的)

--
    若 v 不存在, 返回: "nil"
--
    若 v = 123, 返回: "123"
--
    若 v = "abc", 返回: abc"
--
    若 v = {...}, 返回: "table: 0xf7" (类似)




# ================================ #
#       print (···)
# -------------------------------- #
接受任何类型的参数，并将它们输出到 stdout。
通过 tostring函数，将每个参数 转换为 字符串
本函数不是用来做 格式化打印的（比如 c 中的 printf）
仅仅用于 快速显示 某些变量。比如用于 debug

正式的输出，可以使用 string.format ／ io.write




# ----------------------------------------------#
#    tonumber (e [, base])
# ----------------------------------------------#
http://www.lua.org/manual/5.1/manual.html#pdf-tonumber

Tries to convert its argument to a number. If the argument is already a number or a string convertible to a number, then tonumber returns this number; otherwise, it returns nil.

An optional argument specifies the base to interpret the numeral. The base may be any integer between 2 and 36, inclusive. In bases above 10, the letter 'A' (in either upper or lower case) represents 10, 'B' represents 11, and so forth, with 'Z' representing 35. In base 10 (the default), the number can have a decimal part, as well as an optional exponent part (see §2.1). In other bases, only unsigned integers are accepted.


试图将参数 转换为一个数字, 若参数本身就是数字, 或一个可被转换为数字的 string, 本函数将返回这个数字, 否则返回 nil;

有一个可选参数, 指定数字的 基数, 设置的范围可从 2~36, 默认为 10, 用 'A' 表示... 略







# ----------------------------------------------#
#       string.byte()
# ----------------------------------------------#
s = "1234"
n = string.byte( s, 2 );  -- 获得字符串的第二元素: '2' 的 ascii 码...


# lua 的字符串可以安全地存储 二进制流, 这些数据不会被改写





# ----------------------------------------------#
#     math.floor (x)
# ----------------------------------------------#

Returns the largest integer smaller than or equal to x.

返回 小于等于 参数 x 的最大的 整数


# ----------------------------------------------#
#     type (v)
# ----------------------------------------------#
Returns the type of its only argument, coded as a string. The possible results of this function are "nil" (a string, not the value nil), "number", "string", "boolean", "table", "function", "thread", and "userdata".

返回一个字符, 表示参数 v 的类型, 可能的返回值有:
    "nil", 
    "number", 
    "string", 
    "boolean", 
    "table", 
    "function", 
    "thread",
    "userdata"


# ----------------------------------------------#
#       select (index, ···)
# ----------------------------------------------#
If index is a number, returns all arguments after argument number index; a negative number indexes from the end (-1 is the last argument). Otherwise, index must be the string "#", and select returns the total number of extra arguments it received.

如果 index 是个数字， 那么返回参数中第 index 个之后的部分； 负的数字会从后向前索引（-1 指最后一个参数）。 
否则，index 必须是字符串 "#"， 此时 select 返回参数的个数。

--- 这个描述是不对的...

测试表明, 本函数会把 index 后的所有参数 都当成一个 array, 然后返回其中 第 index 个元素;
若 index 为 "#", 就返回 index 后所有参数的 个数 (一个数字);


# ----------------------------------------------#
#     setmetatable (table, metatable)
# ----------------------------------------------#
Sets the metatable for the given table. (To change the metatable of other types from Lua code, you must use the debug library (§6.10).) If metatable is nil, removes the metatable of the given table. If the original metatable has a __metatable field, raises an error.

This function returns table.




# ----------------------------------------------#
#       table.pack (···)
# ----------------------------------------------#
Returns a new table with all arguments stored into keys 1, 2, etc. and with a field "n" with the total number of arguments. Note that the resulting table may not be a sequence.
---

将 ... 中的所有参数 打包进一个 table 中, 然后为这个 table 添加一个成员: n, 记录所有元素的个数; (不包含n自己)
最终返回的 table 可能不是一个 sequence, 



# ----------------------------------------------#
#      table.unpack (list [, i [, j]])
# ----------------------------------------------#
Returns the elements from the given list. This function is equivalent to:

     return list[i], list[i+1], ···, list[j]

By default, i is 1 and j is #list.
---

把一个 table 解包, 返回一堆离散的元素; 不能用一个变量 去接本函数的返回值, 那样只会接到 一堆返回值中的第一个;
应该是:

    t = {1,2,3}
    k1,k2,k3 = table.unpack( t, 1,3 )
    ---

得到结果:
    k1 = 1
    k2 = 2
    k3 = 3

# 据说 unpack 有 gc



# ----------------------------------------------#
#        string.rep (s, n [, sep])
# ----------------------------------------------#
Returns a string that is the concatenation of n copies of the string s separated by the string sep. The default value for sep is the empty string (that is, no separator). Returns the empty string if n is not positive.
(Note that it is very easy to exhaust the memory of your machine with a single call to this function.)
---
将 n 个 s (string) 串联起来, 中间用分隔符 sep 相连, 最终获得一个 string, 并返回它;

参数 sep 默认为 "";

若参数 n <= 0, 则本函数返回 "";

# 注意:
本函数很容易导致 内存耗尽;


# ----------------------------------------------#
#          next (table [, index])
# ----------------------------------------------#
Allows a program to traverse all fields of a table. Its first argument is a table and its second argument is an index in this table. next returns the next index of the table and its associated value. When called with nil as its second argument, next returns an initial index and its associated value. When called with the last index, or with nil in an empty table, next returns nil. If the second argument is absent (缺席), then it is interpreted as nil. In particular, you can use next(t) to check whether a table is empty.

The order in which the indices are enumerated is not specified, even for numeric indices. (To traverse a table in numerical order, use a numerical for.)

The behavior of next is undefined if, during the traversal, you assign any value to a non-existent field in the table. You may however modify existing fields. In particular, you may clear existing fields.
# ------
允许 一个程序 来遍历 table 的所有字段。
参数 table 是个表, 参数 index 是这个表的一个 idx; 

--
    若参数 index 为 nil, 且参数 table 有限, 则本函数返回 table 的第一个元素;
--
    若参数 index 为 一个 table 的最后一个 idx, 或 table 自己为 nil, 则本函数返回 nil;
--
    若参数 index 没有设置, 则系统会默认 index 为 nil;

# 一个常见的使用是 next(t) 以此来检测 t 是否为空:
    -- 若 t 不是 table, 编译器报错
    -- 若 t 为 table, 且为空, 返回 nil
    -- 若 t 为 table, 且不为空, 则返回 一组 非 nil 值;(至少返回的 pair 中, 第一个元素不是 nil)

# 注意:
index 遍历的顺序 是未定义的, (在 网络lua平台测试时, 它是倒的...) 

# 在调用 next() 遍历期间, 你往 table 的任何 "non-existent field" 分配值 都将导致 未定义行为;



# ----------------------------------------------#
#            pairs (t)
# ----------------------------------------------#
If t has a metamethod __pairs, calls it with t as argument and returns the first three results from the call.

Otherwise, returns three values: the next function, the table t, and nil, so that the construction

     for k,v in pairs(t) do body end
will iterate over all key–value pairs of table t.

See function next() for the caveats警告 of modifying the table during its traversal.


# ----------------------------------------------#
#    string.find (s, pattern [, init [, plain]])
# ----------------------------------------------#
Looks for the first match of pattern (see §6.4.1) in the string s. If it finds a match, then find() returns the indices of s where this occurrence starts and ends; otherwise, it returns nil. A third, optional numeric argument init specifies where to start the search; its default value is 1 and can be negative. A value of true as a fourth, optional argument plain turns off the pattern matching facilities, so the function does a plain "find substring" operation, with no characters in pattern being considered magic. Note that if plain is given, then init must be given as well.

If the pattern has captures, then in a successful match the captured values are also returned, after the two indices.
# -----

从字符串 s 中找到第一个匹配 pattern 的 idx;

如果找到, 返回两个值, 分别是在 s 中找到的 第一个匹配项的 首字母 和 尾字母 的 idx;

参数3: init: 从这个 idx开始搜索; 默认为 1; 可为 负值; 

参数4: 若为 true, 参数 pattern 将不再支持 "模式匹配", 而退化为一个 普通的 子字符串;
# 注意, 若想传入参数 4, 则必须也传入参数 3;

若参数 4 启用 "模式匹配", 则最后的返回值有 3 个, 第 3 个为: 被捕捉到的和 pattern 匹配的那个 具体的 字符串;



# ----------------------------------------------#
#     string.sub (s, i [, j])
# ----------------------------------------------#
Returns the substring of s that starts at i and continues until j; i and j can be negative. If j is absent, then it is assumed to be equal to -1 (which is the same as the string length). In particular, the call string.sub(s,1,j) returns a prefix of s with length j, and string.sub(s, -i) (for a positive i) returns a suffix of s with length i.
If, after the translation of negative indices, i is less than 1, it is corrected to 1. If j is greater than the string length, it is corrected to that length. If, after these corrections, i is greater than j, the function returns the empty string.
-----

总之就是尽可能返回一个 s 的子字符串, 实在不行 (i>j) 时, 返回 "";


# ----------------------------------------------#
#     string.lower (s)
# ----------------------------------------------#
Receives a string and returns a copy of this string with all uppercase letters changed to lowercase. All other characters are left unchanged. The definition of what an uppercase letter is depends on the current locale.
---
将字符串中所有 大写改成 小写, 返回修改后的 字符串了;

原参数串 不被改写;



# ----------------------------------------------#
#    string.byte (s [, i [, j]])
# ----------------------------------------------#
Returns the internal numeric codes of the characters s[i], s[i+1], ..., s[j]. The default value for i is 1; the default value for j is i. These indices are corrected following the same rules of function string.sub.
Numeric codes are not necessarily portable across platforms.



# ----------------------------------------------#
#     pcall (f [, arg1, ···])
# ----------------------------------------------#
在保护模式下调用 函数 f;

Calls function "f" with the given arguments in protected mode. 

This means that any error inside f is not propagated (传播); instead, pcall catches the error and returns a status code. 
Its first result is the status code (a boolean), which is true if the call succeeds without errors. 
In such case, pcall also returns all results from the call, after this first result. 
In case of any error, pcall returns false plus the error message.

如果调用函数 f 出错:
    第一个返回值 为 false;
    第二个返回值 为 error message;

如果调用函数 f 没出错:
    第一个返回值 为 true;
    后续数个返回值为 函数 f 的返回值;

# 案例:
    local function test(a)
        if a == 2 then
            error("test error")
        end
        return true
    end
    local ok, ret = pcall(test, 1)      --> true    true
    local ok, ret = pcall(test, 2)      --> false   test.lua:5: test error


# ----------------------------------------------#
#    xpcall (f, msgh [, arg1, ···])
# ----------------------------------------------#
This function is similar to pcall(), except that it sets a new message handler msgh.
---
额外传入一个参数 message handler: msgh

pcall() 有时候并不能满足要求，比如我们想知道错误是在哪里发生的，那么就要用 xpcall() 来实现：

# 案例:
    local function msghander(msg)
        print(msg)
        print(debug.traceback())
    end
    local ok, ret = xpcall(test, msghander, 1)      --> true    true
    local ok, ret = xpcall(test, msghander, 2)      --> false   nil

    ---
    test.lua:5: test error
    stack traceback:
        test.lua:11: in function <test.lua:9>
        [C]: in function 'error'
        test.lua:5: in function <test.lua:3>
        [C]: in function 'xpcall'
        test.lua:14: in main chunk
        [C]: in ?


# ----------------------------------------------#
#    tostring (v)
# ----------------------------------------------#
Receives a value of any type and converts it to a string in a human-readable format. 
(For complete control of how numbers are converted, use string.format.)

If the metatable of v has a "__tostring" field, then tostring() calls the corresponding value with v as argument, 
and uses the result of the call as its result.
---
可使用 元方法 "__tostring" 来重载 tostring() 的功能;

# 这是一种将 obj 序列化的方式;
