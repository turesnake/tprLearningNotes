# ======================================================================= #
#                lua  类型转换
# ======================================================================= #



# ----------------------------------------------#
#      类型转换 float -> int
# ----------------------------------------------#

# 此需求大多出现在: 一个 c# 函数需要 int 类型的参数, 在 lua 中怎么提供 int 类型的参数呢 ?

    math.floor()
    math.ceil()

在这两个函数的文档中, 写着:
    "Returns the largest integral value smaller than or equal to x."

实践表明, 此方法可以满足 c# int 类型参数 的需求;

# 四舍五入
lua 没有现成的 四舍五入 ( math.round ), 但是可以自己实现一个:

    math.floor( x + 0.5 )

之所以推荐用这个是因为有时候 一个 float值, 比如 1.0,  其实它在 lua 中可能为 0.999999,
此时直接用 math.floor 会出问题;




# ----------------------------------------------#
#      类型转换 float -> uint
# ----------------------------------------------#
暂未找到方法...




# --------------------------------------------------- #
#      文档翻译: 2.1 – Values and Types  (部分)
# --------------------------------------------------- #
...
number 类型使用两种 内置表达 (subtype):  integer 和 float (浮点数, 而不是指 32-bits 的 float);
Lua 对何时使用每种表示都有明确的规则, 但它也会根据需要在它们之间自动转换 (see 下方翻译的 §3.4.3); 

程序员 大部分时候可以主动忽略 这两个类型之间的区别; 或者假设完全控制每个数字的表达;
标准 lua 使用 64-bits 的 integer 和 double 类型; 但你也可编译 lua 来使用 32-bits 的 int 和 float 类型; 比如在用于嵌入式时 (See macro LUA_32BITS in file luaconf.h.)
...



# -- table 的 idx 类型问题:
The indexing of tables follows the definition of raw equality in the language. 

想要让 a[i] 和 a[j] 判定一致, 就必须要求 i 和 j 是 "raw equal" 的, (也就是, equal without metamethods);

比如, floats with integral values (带有整数的float) are equal to their respective integers (e.g., 1.0 == 1).
为避免歧义, any float with integral value (带有整数的float) used as a key is converted to its respective integer;

比如, 如果你写:

    a[2.0] = true

那么实际传入 table 的 idx 为 2; (一个整形值)


# --------------------------------------------------- #
#      文档翻译: 3.4.3 – Coercions and Conversions
# --------------------------------------------------- #

Lua 在运行时提供了一些类型和表示之间的一些自动转换;  
    -- 位运算 永远会将 float 转换为 integer;
    -- 求幂运算 和 浮点数除法 永远会把 integer 转换为 float;
    -- 其他的应用于 mixed numbers (integers and floats) 的数学运算, 会将 integer 转换为 float

以上这些被称为 usual rule (常规法则)

若有需要, C api 会在 integer 和 floats 之间自动转换;

Moreover, string concatenation accepts numbers as arguments, besides strings.
此外, 字符串连接符 会将 numbers 作为参数;

# --
当需要 number 时, lua 也会将 string 转换为 number 类型;

# --
当把 integer 转换为 floats 时, 如果能恰好找到一个和 integer 值对应的 floats 值, 那么就直接转换; 比如从 12 得到 12.0;
否则就得到 最近的 higher 或 lower 表达; (有的时候, 无法得到 1.0, 只能得到 0.9999999, 此时若想将一个 1 转换为 floats, 则只能得到 0.99999)

这种转换一定会成功; 

# --
The conversion from float to integer checks whether the float has an exact representation as an integer (that is, the float has an integral value and it is in the range of 
integer representation). If it does, that representation is the result. Otherwise, the conversion fails.


# --
The conversion from strings to numbers goes as follows: 
First, the string is converted to an integer or a float, following its syntax and the rules of the Lua lexer. 
(The string may have also leading and trailing spaces and a sign. 前部和尾部可能有空格, 或 正负符号) 

Then, the resulting number (float or integer) is converted to the type (float or integer) required by the context (e.g., the operation that forced the conversion).

All conversions from strings to numbers accept both a dot and the current locale mark as the radix character (基数字符). (The Lua lexer, however, accepts only a dot.)

# --
The conversion from numbers to strings uses a non-specified human-readable format. For complete control over how numbers are converted to strings, use the format function from the string library (see string.format).





