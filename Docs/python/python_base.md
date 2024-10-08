# =============================================== #
#         pthon base
# =============================================== #


# Python in one page
https://dev.to/andredarcie/python-in-one-page-40bl




# -------------------------- #
#       print()
# -------------------------- #

# 打印一个 float:
    fa = 0.123
    bb = 666
    print( "fa = ", fa, ", bb = ", bb )




# -------------------------- #
#  本地变量 / 局部变量
#       global
# -------------------------- #

python 中不像 lua 一样存在 local 关键词;

# keyword: global
---:
    global_a = "abc"

    def Py2():
        global global_a
        global_a = "kkk"
---
在上面例子中, 通过 "global global_a", 就能在函数内拿到 全部变量 global_a 的引用;
而不是本地新建一个同名的 local 变量

# global 相关的 bug:
---:
x = 123
    def func():
        print(x)
        x = 444
---
上例会报错, 因为 py 在函数内找到了 local val 的声明, 所以它就不去外部找了, 但是这个声明的位置在 print() 调用之后;
所以 py 会报错:
    UnboundLocalError: local variable 'x' referenced before assignment


# keyword: nonlocal
---:
    def outer():
        vv = "outer--"

        def innr():
            nonlocal vv
            vv = "inter--"

        innr()
        print("vv = ", vv)
---:
Python also has the `nonlocal` keyword, which is used to work with variables inside nested functions. 
`nonlocal` allows you to assign values to a variable in an outer (but non-global) scope:

专用于嵌套函数, 假设外层函数声明了一个 局部变量 vv, 用 `nonlocal` 就能在内层函数内得到这个 变量的 引用


# for / if 语句中的作用域 导致的 bug:
---:
    for i in range(10):
        print("--inn i: ", i )

    print("out i = ", i )
---:
上例中, 外部的 print 可以打印出 i = 10;
py 中这个 i 不是局部变量, 而是一个 和 for语句在同一 作用域的变量 ....











