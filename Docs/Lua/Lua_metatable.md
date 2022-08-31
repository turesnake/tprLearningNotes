# ======================================================================== #
#         lua metatable, Metamethods
# ======================================================================== #

# 搜索: 2.4 – Metatables and Metamethods
https://www.lua.org/manual/5.3/manual.html



# ----------------------------------------------#
#     元表 metatable  简单说明:
# ----------------------------------------------#
metatable 自己也是一个普通的 table, 但是它可以存放一些类似 运算符重载函数 之类的 元函数; 
然后这些 重载函数并不是服务于 metatable 自己的, 而是服务于另一个 普通 table:

    t = {a=15}
    mt = {
        __add = function(a,b)
            return a.a+b
        end
    }
    setmetatable(t,mt)   -- 为一个普通table: t 设置它的元表: mt

上例可看出, 元表 mt 定义了一个 加法重载, 然后绑定之后, t 的 加法运算就被更改了;


# table 和 userdata 可以自定义自己的 metatable, 但是 其他类型的 变量 不能自定义自己的 metatable;
    对于这些 其它类型 来说, 每个类型的实例, 都使用这个类型的 metatable;


# 数个 table 可以公用同一个 metatable

# 一个 metatable 也可以拥有自己的 metatable...



# ---
A metatable controls how an object behaves in arithmetic operations, bitwise operations, order comparisons, concatenation(字符串连接符), length operation, calls, and indexing. A metatable also can define a function to be called when a userdata or a table is garbage collected
---
定义了以下行为:
    -- 数学运输
    -- 位运算
    -- 次序比较
    -- 字符串连接符: ".."
    -- length() 函数
    -- calls
    -- idx 索引
    -- GC 时调用的函数


# 对于那些 一元操作符 来说, metamethod 其实也有两个参数, 不过第二个参数隐藏了, 它的值默认等于第一个参数
    这么设计是为了简化 lua 底层实现;
    ---
    这个设计未来可能会更改, 最好不要去用那个 默认的 第二参数;


# ----------------------------------------------#
#     metamethod 的常见类型:
# ----------------------------------------------#

# __add: 
    the addition (+) operation. If any operand for an addition is not a number (nor a string coercible(强制转换为) to a number), 
    Lua will try to call a metamethod. 
    First, Lua will check the first operand (even if it is valid). 
    If that operand does not define a metamethod for __add, then Lua will check the second operand. 
    If Lua can find a metamethod, it calls the metamethod with the two operands as arguments, and the result of the call (adjusted to one value) is the result of the operation. Otherwise, it raises an error.
    ---
    当加法 '+' 两侧的任一元素 不为 number (或可转换为 number 的 string) 时, 
    lua 会先后访问 左侧元素 和 右侧元素 是否带有 元方法: __add, 若能找到一个, 就使用这个函数来运算; 运算结果为一个值;
    若没能找到 __add, 就报错;

# __sub: 
    the subtraction (-) operation. Behavior similar to the addition operation.

# __mul: 
    the multiplication (*) operation. Behavior similar to the addition operation.

# __div: 
    the division (/) operation. Behavior similar to the addition operation.

# __mod:    
    the modulo (%) operation. Behavior similar to the addition operation.

# __pow:    
    the exponentiation (^) operation. Behavior similar to the addition operation.

# __unm: 
    the negation (unary -) operation. Behavior similar to the addition operation.
    取负, 一元运算符:

        __unm = function(t)
            return t.a+3
        end

    类似这么写就行了;

# __idiv:   
    the floor division (//) operation. Behavior similar to the addition operation.
    地板除

# __band: 
    the bitwise AND (&) operation. Behavior similar to the addition operation, except that Lua will try a metamethod if any operand is neither an integer nor a value coercible to an integer (see §3.4.3).

# __bor: 
    the bitwise OR (|) operation. Behavior similar to the bitwise AND operation.

# __bxor: 
    the bitwise exclusive OR (binary ~) operation. Behavior similar to the bitwise AND operation.

# __bnot: 
    the bitwise NOT (unary ~) operation. Behavior similar to the bitwise AND operation.

# __shl: 
    the bitwise left shift (<<) operation. Behavior similar to the bitwise AND operation.

# __shr: 
    the bitwise right shift (>>) operation. Behavior similar to the bitwise AND operation.

# __concat: 
    the concatenation (..) operation. Behavior similar to the addition operation, except that Lua will try a metamethod if any operand is neither a string nor a number (which is always coercible to a string).
    ---
    字符串连接符;

    当 ".." 连接符的左右元素 既不是 string 也不是 number 时, lua 就会从这两个元素里查找 __concat 元函数;

# __len: 
    the length (#) operation. If the object is not a string, Lua will try its metamethod. If there is a metamethod, Lua calls it with the object as argument, and the result of the call (always adjusted to one value) is the result of the operation. If there is no metamethod but the object is a table, then Lua uses the table length operation (see §3.4.7). Otherwise, Lua raises an error.
    ---
    当访问 #dog 时
        -- 若 dog 为 string, 直接获得字符个数; (不调用本函数)
        -- 若 dog 不是 string:
            -- 若 dog 含有 元函数: __len, 直接调用来获得 元素个数;
            -- 若没有 __len, 但 dog 是一个 table, 则用 table length operation 来获得 元素个数
            -- 若没有 __len, 且 dog 不是 table,  直接报错;

# __eq: 
    the equal (==) operation. Behavior similar to the addition operation, except that Lua will try a metamethod only when the values being compared are either both tables or both full userdata and they are not primitively equal. The result of the call is always converted to a boolean.
    ---


# __lt: 
    the less than (<) operation. Behavior similar to the addition operation, except that Lua will try a metamethod only when the values being compared are neither both numbers nor both strings. The result of the call is always converted to a boolean.

# __le: 
    the less equal (<=) operation. Unlike other operations, the less-equal operation can use two different events. First, Lua looks for the __le metamethod in both operands, like in the less than operation. If it cannot find such a metamethod, then it will try the __lt metamethod, assuming that a <= b is equivalent to not (b < a). As with the other comparison operators, the result is always a boolean. (This use of the __lt event can be removed in future versions; it is also slower than a real __le metamethod.)

# __index: 
    The indexing access operation table[key]. This event happens when table is not a table or when key is not present in table. The metamethod is looked up in table.
    Despite the name, the metamethod for this event can be either a function or a table. If it is a function, it is called with table and key as arguments, and the result of the call (adjusted to one value) is the result of the operation. If it is a table, the final result is the result of indexing this table with key. (This indexing is regular, not raw, and therefore can trigger another metamethod.)
    ---
    当参数 table 不是 table 类型, 或 参数 key 在 table 中不存在, 就会调用本函数;

    __index 既可以是个 函数, 也可以是个 table:
        -- 若为 函数:
            正常调用;

        -- 若为 table:
            就用 key 来访问这个 table, 返回得到的值;

    代码示范:
        函数版:
            __index = function( t, key ) 
                local ot = {
                    a = 101, 
                    b = 102
                }
                return ot[key]
            end

        table版:
            __index = {
                a = 101,
                b = 122
            }

    注意:
        对 __index 的访问, 不光可以是: table[key], 还可以是: table.key;  (后者更常见)


# __newindex: 
    The indexing assignment table[key] = value. Like the index event, this event happens when table is not a table or when key is not present in table. The metamethod is looked up in table.

    Like with indexing, the metamethod for this event can be either a function or a table. If it is a function, it is called with table, key, and value as arguments. If it is a table, Lua does an indexing assignment to this table with the same key and value. (This assignment is regular, not raw, and therefore can trigger another metamethod.)

    Whenever there is a __newindex metamethod, Lua does not perform the primitive assignment. (If necessary, the metamethod itself can call rawset to do the assignment.)
    ---
    依据索引来分配一个新元素:
    例如:
        table[key] = value
    
    如果 table 中已经有 key 指向的元素, 那么此句仅执行 val 修改操作;
    如果没有 key 这个原始, 或者 参数 table 不是一个 table 类型, lua 就会来查找和调用 __newindex 函数;

    和上面的 __index 一样, __newindex 也可以是一个 函数 或 table;
        若为一个 table:
            那么将直接向这个 table 分配一个新元素;



# __call: 
    The call operation func(args). This event happens when Lua tries to call a non-function value (that is, func is not a function). The metamethod is looked up in func. 
    If present, the metamethod is called with func as its first argument, followed by the arguments of the original call (args). 
    All results of the call are the result of the operation. (This is the only metamethod that allows multiple results.)
    ---
    当编写了:
        func(args)

    且 func 不是一个函数时, lua 就会查找这个 func 的 元函数 __call; 
    此时, 调用 __call 的参数为 ( func, args ) -- 此处 args 可为数个参数
    此时, 调用 __call 得到的返回值(可能为多个), 就是 func(args) 的返回值;

    这是唯一一个可以返回 多个返回值的 元函数;

# __gc:
    查找: 2.5.1 – Garbage-Collection Metamethods


# metatabe 本身也是一个 常规 table, 也能包含除上述 元素 以外的任何元素;





# ----------------------------------------------#
#     rawget (table, index)
# ----------------------------------------------#
Gets the real value of table[index], without invoking the __index metamethod. table must be a table; index may be any value.

不在调用 __index 元表函数, 而是直接访问 table 的目标元素;
参数 table 必须为 table 类型


# ----------------------------------------------#
#     getmetatable (object)
# ----------------------------------------------#
If object does not have a metatable, returns nil. Otherwise, if the object's metatable has a __metatable field, returns the associated value. Otherwise, returns the metatable of the given object.

-- 如果参数 object 没有 metatable, 直接返回 nil;

-- 如果有 metatable, 且这个 metatable 存在 __metatable 字段, 则返回这个值;
-- 如果有 metatable, 但这个 metatable 没有 __metatable 字段, 则直接返回这个 metatable

# tpr: 感觉有点递归...


# ----------------------------------------------#
#      rawset (table, index, value)
# ----------------------------------------------#
Sets the real value of table[index] to value, without invoking the __newindex metamethod.

-- 参数 table must be a table, 
-- 参数 index any value different from nil and NaN, 
-- and 参数 value any Lua value.

This function returns table.









