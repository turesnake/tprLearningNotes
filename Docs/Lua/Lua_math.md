# ================================================================== #
#                    lua math
# ================================================================== #


# 搜索: 6.7 – Mathematical Functions
https://www.lua.org/manual/5.3/manual.html#3.5


在下面注释中, 如果标注了 "integer/float", 说明这个函数的 返回值 和 参数同类型; (传入 integer 就返回 integer, 传入 floats 就返回 floats (或 mixed) )

三个 Rounding functions (四舍五入函数) ( math.ceil, math.floor, and math.modf ) return an integer when the result fits in the range of an integer, or a float otherwise.
---
一般在 值非常大时, 比如 1000000000000, 才会变成 float


# math.abs (x)
    Returns the absolute value of x. (integer/float)

# math.acos (x)
    Returns the arc cosine of x (in radians).

# math.asin (x)
    Returns the arc sine of x (in radians).

# math.atan (y [, x])
    Returns the arc tangent of y/x (in radians), but uses the signs of both arguments to find the quadrant of the result. 
    (It also handles correctly the case of x being zero.)
    ---
    就算 x值传入 0, 本函数也能正确处理;
    tpr:
        测试表明, 当 x=0, 本函数返回值始终为: 1.5707963267949,  也就是 90度; 符合 x=0 时的设计;

    The default value for x is 1, so that the call math.atan(y) returns the arc tangent of y.
    ---


# math.ceil (x)
    Returns the smallest integral value larger than or equal to x.
    ---
    返回值 如果位于 "range of an integer" 区间内, 那么就是 integer 类型, 否则为 float 类型 (猜测是值非常大时)
    
    可用 math.type() 去验证:

        if math.type(val) == "integer" then 
            ...
        end


# math.cos (x)
    Returns the cosine of x (assumed to be in radians).

# math.deg (x)
    Converts the angle x from radians to degrees.

# math.exp (x)
    Returns the value ex (where e is the base of natural logarithms).

# math.floor (x)
    Returns the largest integral value smaller than or equal to x.
    ---
    和 math.ceil() 相似的规则;



# math.fmod (x, y)
    Returns the remainder of the division of x by y that rounds the quotient towards zero. (integer/float)
    ---
    求商, 像 0 靠拢;
    ---
        math.fmod( 3,   2 ) 得到: 1     -- integer
        math.fmod( 3.0, 2 ) 得到: 1.0   -- float

    如果 参数 y=0, 返回 NaN


# math.huge
    The float value HUGE_VAL, a value larger than any other numeric value.
    --
    打印出来得到: Infinity


# math.log (x [, base])
    Returns the logarithm of x in the given base. The default for base is e (so that the function returns the natural logarithm of x).


# math.max (x, ···)
    Returns the argument with the maximum value, according to the Lua operator <. (integer/float)


# math.maxinteger
    An integer with the maximum value for an integer.
    math.min (x, ···)
    Returns the argument with the minimum value, according to the Lua operator <. (integer/float)
    ---

    参数列表 可以传入很多个值;


# math.mininteger
    An integer with the minimum value for an integer.
    ---

    参数列表 可以传入很多个值;
    
# math.modf (x)
    Returns the integral part of x and the fractional part of x. Its second result is always a float.
    ---
    返回两个值, 一个类型为 integer, 一个类型为 float;
    


# math.pi
    The value of π.


# math.rad (x)
    Converts the angle x from degrees to radians.


# math.random ([m [, n]])
    When called without arguments, returns a pseudo-random float with uniform distribution in the range [0,1). When called with two integers m and n, math.random returns a pseudo-random integer with uniform distribution in the range [m, n]. (The value n-m cannot be negative and must fit in a Lua integer.) The call math.random(n) is equivalent to math.random(1,n).

    This function is an interface to the underling pseudo-random generator function provided by C.

# math.randomseed (x)
    Sets x as the "seed" for the pseudo-random generator: equal seeds produce equal sequences of numbers.

# math.sin (x)
    Returns the sine of x (assumed to be in radians).

# math.sqrt (x)
    Returns the square root of x. (You can also use the expression x^0.5 to compute this value.)

# math.tan (x)
    Returns the tangent of x (assumed to be in radians).

# math.tointeger (x)
    If the value x is convertible to an integer, returns that integer. Otherwise, returns nil.
    ---

    如果传入 12.1 这种, 会得到 nil...


# math.type (x)
    Returns "integer" if x is an integer, "float" if it is a float, or nil if x is not a number.
    ---
    貌似挺实用的;


# math.ult (m, n)
    Returns a boolean, true if and only if integer m is below integer n when they are compared as unsigned integers.























