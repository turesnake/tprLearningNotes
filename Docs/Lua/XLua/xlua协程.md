# ===================================================== #
#        xlua 中的协程
# ===================================================== #



# util.cs_generator(...)
    

# --------------------------- #
#      lua 中的 协程
# --------------------------- #
https://zhuanlan.zhihu.com/p/47573713

Lua 中的协程和 unity 协程的区别，最大的就是其不是抢占式的执行，
也就是说不会被主动执行类似 MoveNext 这样的操作，而是需要我们去主动激发执行，就像上一个例子一样，自己去 tick 这样的操作。


Lua 中协程关键的三个 API:

    coroutine.create()/wrap: 构建一个协程, wrap构建结果为函数，create为thread类型对象

    coroutine.resume(): 执行一次类似MoveNext的操作

    coroutine.yield(): 将协程挂起
========================
案例:
    local func1 = function(a, b)
        for i = 1, 5 do
            print(i, a, b)
            coroutine.yield()
        end
    end

    co1 = coroutine.create(func1)
    coroutine.resume(co1, 1, 2)  -- 此时会输出 1， 1，2 然后挂起
    coroutine.resume(co1, 3, 4)  -- 此时将上次挂起的协程恢复执行一次，输出：2, 1, 2 所以新传入的参数3，4是无效的


tpr: 也就是说, 在 lua 版协程中, 新建一个协程, 然后每调用一次 resume(), 就会向下执行到一处 yield 处;


# --------------------------- #
#      xlua 中的 协程
# --------------------------- #

来看看 xlua 开源出来的 util 中对协程的使用示例又是怎么结合 lua 的协程，在 lua 端构建也给协程，
让 c# 端也可以获取这个实例，从而添加到 unity 端的主线程中去触发 update。

看: 
    cs_coroutine.lua 
    util.lua  -- cs_generator() 函数
文件;


代码很短，不过思路很清晰，首先构建一个 table, 其中的 key 对应一个 function，然后修改去元表的 _index 方法，
其中包含了 MoveNext 函数的实现，也包含了 Reset 函数的实现，不过这儿的 Reset 和 IEnumerator 的不一样，
这儿是调用 coroutine.wrap 来生成一个协程。这样 c# 端获取到这个 generator 的 handleID 后，
后面每帧 update 回来都会执行一次 MoveNext，如果都执行完了，这时候会 return move_end，表明协程都执行完了，
返回 false 给 c# 端清空该协程的 handleID.


# --------------------------- #
# 在 xlua 的 lua 代码中直接使用协程:

    local cs_coroutine = require('XLua.cs_coroutine')

    -- 开始一个协程:
    co = cs_coroutine.start(function()
        ...
    end)

    ...

    -- 终止一个协程:
    cs_coroutine.stop(co)































