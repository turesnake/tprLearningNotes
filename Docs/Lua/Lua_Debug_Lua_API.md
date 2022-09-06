# ======================================================================== #
#                Lua Debug Lua API
# ======================================================================== #

#  6.10 – The Debug Library


This library provides the functionality of the debug interface (§4.9) to Lua programs. 
You should exert care when using this library. -- 使用此库时应小心
Several of its functions violate basic assumptions 违反基本假设 about Lua code 
(e.g., 
    that variables local to a function cannot be accessed from outside; 
    that userdata metatables cannot be changed by Lua code; 
    that Lua programs do not crash
) 
and therefore can compromise otherwise secure code. 因此可能会损害其他安全代码
Moreover, some functions in this library may be slow.

All functions in this library are provided inside the "debug" table. 

All functions that operate over a thread have an optional first argument which is the thread to operate over. 
The default is always the current thread.


# debug.debug ()
Enters an interactive mode with the user, running each string that the user enters. 
进入 debug 交互模式, 之后会运行用户输入的 每一行 string;

Using simple commands and other debug facilities, the user can inspect global and local variables, change their values, evaluate expressions, and so on. 
---
通过使用简单的 commands 和其他工具, 用户可以 窥探 全局/局部 变量, 改写他们的值, 执行表达式, 等等;

A line containing only the word "cont" finishes this function, so that the caller continues its execution.
仅包含单词 cont 的行完成了此函数，以便调用者继续执行;

Note that commands for debug.debug() are not lexically nested within any function (没有词法嵌套在任何函数中) and so have no direct access to local variables.


# debug.gethook ([thread])
Returns the current hook settings of the thread, as three values: 
    -- the current hook function, 
    -- the current hook mask,
    -- the current hook count (as set by the debug.sethook() function).


# debug.getinfo ([thread,] f [, what])
Returns a table with information about a function. 

You can give the function directly or you can give a number as the value of f, which means the function running at level f of the call stack of the given thread: 
    level 0 is the current function (getinfo itself); 
    level 1 is the function that called getinfo (except for tail calls, which do not count on the stack); and so on. 
    
If "f" is a number larger than the number of active functions, then getinfo returns nil.
---
f 既可以是 函数, 也可以是一个 idx; 见上描述;

The returned table can contain all the fields returned by lua_getinfo(), 
with the string "what" describing which fields to fill in. 
The default for "what" is to get all information available, except the table of valid lines. 
If present (若存在), the option 'f' adds a field named "func" with the function itself. 
If present, the option 'L' adds a field named "activelines" with the table of valid lines.



举例:

    debug.getinfo(1,"n").name 
    
returns a name for the current function, if a reasonable name can be found, 
参数 1 表示 访问当前函数, 如果能找到 reasonable name (合适的名字), 将通过 字段 name 返回出来;


举例:
    
    debug.getinfo(print) 

returns a table with all available information about the print function.
直接返回一个 table, 是参数 print 的;


# debug.getlocal ([thread,] f, local)
This function returns the name and the value of the local variable with index local of the function at level f of the stack. This function accesses not only explicit local variables, but also parameters, temporaries, etc.

访问 局部变量; 
    不光能访问 local variable, 还能访问 参数, temporaries(临时对象 ?)

The first parameter or local variable has index 1, and so on, following the order that they are declared in the code, counting only the variables that are active in the current scope of the function. 
---
参数 和 局部变量 用正数, 从 1 开始; 顺序就是 它们在代码中 被声明的顺序;

Negative indices refer to vararg arguments; -1 is the first vararg argument. The function returns nil if there is no variable with the given index, and raises an error when called with a level out of range. (You can call debug.getinfo() to check whether the level is valid.)
---
负数 表示 可变参数, 


Variable names starting with '(' (open parenthesis) represent variables with no known names 
(internal variables such as loop control variables, and variables from chunks saved without debug information).


The parameter "f" may also be a function. In that case, getlocal() returns only the name of function parameters.


# debug.getmetatable (value)
Returns the metatable of the given value or nil if it does not have a metatable.


# debug.getregistry ()
Returns the registry table (注册表) (see §4.5).


# debug.getupvalue (f, up)
This function returns the name and the value of the upvalue with index up of the function f. The function returns nil if there is no upvalue with the given index.

Variable names starting with '(' (open parenthesis) represent variables with no known names (variables from chunks saved without debug information).


# debug.getuservalue (u)
Returns the Lua value associated to u. If u is not a full userdata, returns nil.


# debug.sethook ([thread,] hook, mask [, count])
Sets the given function as a hook. The string "mask" and the number "count" describe when the hook will be called. The string "mask" may have any combination of the following characters, with the given meaning:

'c': the hook is called every time Lua calls a function;
'r': the hook is called every time Lua returns from a function;
'l': the hook is called every time Lua enters a new line of code.

Moreover, with a "count" different from zero, the hook is called also after every "count" instructions.
---
tpr: 每隔 参数 "count" 个之类, hook 被调用一次;

# -- When called without arguments, debug.sethook() turns off the hook.

When the hook is called, its first argument is a string describing the event that has triggered its call: "call" (or "tail call"), "return", "line", and "count". 
For line events, the hook also gets the new line number as its second parameter. 
Inside a hook, you can call getinfo() with level 2 to get more information about the running function 
(level 0 is the getinfo function, and level 1 is the hook function).


# debug.setlocal ([thread,] level, local, value)
This function assigns the value "value" to the local variable with index "local" of the function at level level of the stack. 

设置 局部变量;

The function returns nil if there is no local variable with the given index, and raises an error when called with a level out of range. 
(You can call getinfo to check whether the level is valid.) Otherwise, it returns the name of the local variable.

See debug.getlocal for more information about variable indices and names.


# debug.setmetatable (value, table)
Sets the metatable for the given value to the given table (which can be nil). Returns value.

# debug.setupvalue (f, up, value)
This function assigns the value value to the upvalue with index up of the function f. The function returns nil if there is no upvalue with the given index. Otherwise, it returns the name of the upvalue.

# debug.setuservalue (udata, value)
Sets the given value as the Lua value associated to the given udata. udata must be a full userdata.

Returns udata.


# debug.traceback ([thread,] [message [, level]])
回溯

If "message" is present but is neither a string nor nil, this function returns "message" without further processing. 
---
若 参数 "message" 被设置了, 但它不是 string 或 nil, 本函数不做什么工作, 仅返回 "message" 本身;

Otherwise, it returns a string with a traceback of the call stack. The optional "message" string is appended at the beginning of the traceback. 
An optional "level" number tells at which level to start the traceback (default is 1, the function calling traceback).

返用调用堆栈的信息，message表示返回的头部加一段信息，level表示栈的层次，1表示调用debug.traceback那个函数，往上类推



# debug.upvalueid (f, n)
Returns a unique identifier (as a light userdata) for the upvalue numbered n from the given function.

These unique identifiers allow a program to check whether different closures share upvalues. Lua closures that share an upvalue (that is, that access a same external local variable) will return identical ids for those upvalue indices.



# debug.upvaluejoin (f1, n1, f2, n2)
Make the n1-th upvalue of the Lua closure f1 refer to the n2-th upvalue of the Lua closure f2.







