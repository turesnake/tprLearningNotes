
# ----------------------------------------------------- #
#         2.6 – Coroutines
# ----------------------------------------------------- #

Lua supports coroutines, also called collaborative multithreading (协作多线程). 
A coroutine in Lua represents an independent thread of execution. Unlike threads in multithread systems, however, a coroutine only suspends its execution by explicitly calling a yield function.

You create a coroutine by calling "coroutine.create()". Its sole argument is a function that is the main function of the coroutine. The create function only creates a new coroutine and returns a handle to it (an object of type thread); it does not start the coroutine.


You execute a coroutine by calling "coroutine.resume()". When you first call coroutine.resume(), passing as its first argument a thread returned by coroutine.create(), the coroutine starts its execution by calling its main function. Extra arguments passed to coroutine.resume are passed as arguments to that function. After the coroutine starts running, it runs until it terminates or yields.



A coroutine can terminate its execution in two ways: normally, when its main function returns (explicitly or implicitly, after the last instruction); and abnormally (反常的), if there is an unprotected error. In case of normal termination, coroutine.resume() returns true, plus any values returned by the coroutine main function. In case of errors, coroutine.resume returns false plus an error object.


A coroutine yields by calling "coroutine.yield()". When a coroutine yields, the corresponding coroutine.resume returns immediately, even if the yield happens inside nested function calls (that is, not in the main function, but in a function directly or indirectly called by the main function). In the case of a yield, coroutine.resume also returns true, plus any values passed to "coroutine.yield()". The next time you resume the same coroutine, it continues its execution from the point where it yielded, with the call to coroutine.yield() returning any extra arguments passed to coroutine.resume().


Like coroutine.create(), the "coroutine.wrap()" function also creates a coroutine, but instead of returning the coroutine itself, it returns a function that, when called, resumes the coroutine. Any arguments passed to this function go as extra arguments to coroutine.resume. coroutine.wrap returns all the values returned by coroutine.resume, except the first one (the boolean error code). Unlike coroutine.resume, coroutine.wrap does not catch errors; any error is propagated to the caller.


As an example of how coroutines work, consider the following code:

     function foo (a)
       print("foo", a)
       return coroutine.yield(2*a)
     end
     
     co = coroutine.create(function (a,b)
           print("co-body", a, b)
           local r = foo(a+1)
           print("co-body", r)
           local r, s = coroutine.yield(a+b, a-b) -- 传入的参数将从 调用本 co 的resume() 函数处返回
           print("co-body", r, s)
           return b, "end"
     end)
     
     print("main", coroutine.resume(co, 1, 10))
     print("main", coroutine.resume(co, "r"))
     print("main", coroutine.resume(co, "x", "y"))
     print("main", coroutine.resume(co, "x", "y"))


When you run it, it produces the following output:

     co-body 1       10
     foo     2
     main    true    4

     co-body r
     main    true    11      -9

     co-body x       y
     main    true    10      end

     main    false   cannot resume dead coroutine


You can also create and manipulate coroutines through the C API: see functions lua_newthread(), lua_resume(), and lua_yield().



# ----------------------------------------------------- #
#                   API
#  6.2 – Coroutine Manipulation
# ----------------------------------------------------- #

This library comprises (包含) the operations to manipulate coroutines, which come inside the table coroutine. See §2.6 for a general description of coroutines.



# coroutine.create (f)
Creates a new coroutine, with body f. 
f must be a function. 
Returns this new coroutine, an object with type "thread".




# coroutine.isyieldable ()
Returns true when the running coroutine can yield.

A running coroutine is yieldable if it is not the main thread and it is not inside a non-yieldable C function.



# coroutine.resume (co [, val1, ···])
Starts or continues the execution of coroutine "co". 

The first time you resume a coroutine, it starts running its body. The values "val1, ..." are passed as the arguments to the body function. 
---
第一个参数是从 create() 返回的 thread handle, 后续参数传递给 协程执行的那个函数本身;


If the coroutine has yielded, resume restarts it; the values "val1, ..." are passed as the results from the yield.
---
为啥是 the results from the yield ?


If the coroutine runs without any errors, resume returns "true" plus any values passed to yield (when the coroutine yields) 
or any values returned by the body function (when the coroutine terminates). 

If there is any error, resume returns "false" plus the error message.


# 关于 resume() 的参数传递去那里, 见下方详细内容...



# coroutine.running ()
Returns the running coroutine plus a boolean, true when the running coroutine is the main one.



# coroutine.status (co)
Returns the status of coroutine co, as a string: 
"running", 
    if the coroutine is running (that is, it called status); 
"suspended", 
    if the coroutine is suspended in a call to yield, or if it has not started running yet; 
"normal" 
    if the coroutine is active but not running (that is, it has resumed another coroutine); and 
"dead" 
    if the coroutine has finished its body function, or if it has stopped with an error.



# coroutine.wrap (f)
Creates a new coroutine, with body f. 
f must be a function. Returns a function that resumes the coroutine each time it is called. 
---
f 是个函数, 它将返回一个函数, 每次调用这个返回的函数, 都会 resume 协程;

Any arguments passed to the function behave as the extra arguments to resume. 
Returns the same values returned by resume, except the first boolean. In case of error, propagates the error.




# coroutine.yield (···)
Suspends the execution of the calling coroutine. Any arguments to yield are passed as extra results to resume.
---
传入此 yield() 函数的参数, 将从 调用本 协程的 resume() 函数处返回;


# 关于 yield() 的参数传递去那里, 见下方详细内容...




# --------------------------------- #
#   resume() yield() 的参数和返回值问题
# --------------------------------- #
假设:

    co = coroutine.create(function (a,b)
        ...
        local r, s = coroutine.yield( "x", "y" )
    end)
     
    local x,y = coroutine.resume( co,  1,     10    )
    ...
    local m,n = coroutine.resume( co,  "001", "002" )

# 协程代码调用到 yield() 语句时, 会把 yield() 的参数, 传递给外边的 resume(), 当作 resume() 的返回值返回出去;
所以代码中的 x,y 将得到 "x","y";

# 然后协程会暂停下来, cpu 开始专心运行 主线程代码;

# 等到再次调用 resume() 时, 传入的两个参数 "001", "002", 将作为之前暂停处的 yield() 的返回值 返回到 协程代码中;


# 可以看到,  "resume() - yield()"  构成了一个 主线程 和 协程 的数据传递系统;































