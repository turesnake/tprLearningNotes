// ======================================================================== //
//                Lua Debug C API
// ======================================================================== //

// 4.9 – The Debug Interface


// ------------ 下面这些定义是 tpr 自己随便写的, 目的仅为了消除 IDE 报错 ------------------- //
typedef struct lua_Hook_ { int a; } lua_Hook;
#define lua_State int
#define other int
#define LUA_IDSIZE 32

// ------------ 上面这些定义是 tpr 自己随便写的, 目的仅为了消除 IDE 报错 ------------------- //



typedef struct lua_Debug 
{
    int event;
    /*
        a reasonable name (合理名字) for the given function. Because functions in Lua are first-class values, 
        they do not have a fixed name: some functions can be the value of multiple global variables, 
        while others can be stored only in a table field. 
        The lua_getinfo() function checks how the function was called to find a suitable name. 
        If it cannot find a name, then name is set to NULL.
    */
    const char *name;           /* (n) */

    /*
        explains the name field. The value of namewhat can be "global", "local", "method", "field", "upvalue", or "" (the empty string), 
        according to how the function was called. (Lua uses the empty string when no other option seems to apply.)
    */
    const char *namewhat;       /* (n) */

    // -- the string "Lua" if the function is a Lua function, 
    // -- "C" if it is a C function, 
    // -- "main" if it is the main part of a chunk.
    const char *what;           /* (S) */

    /*
        the name of the chunk that created the function. If source starts with a '@', 
        it means that the function was defined in a file where the file name follows the '@'. 
        If source starts with a '=', the remainder of its contents describe the source in a user-dependent manner. 
        它的剩余内容以 用户定义的方式 来描述 source;

        Otherwise, the function was defined in a string where source is that string.
    */
    const char *source;         /* (S) */
        
    // the current line where the given function is executing. 
    // When no line information is available, currentline is set to -1.
    int currentline;            /* (l) */

    
    //    the line number where the definition of the function starts.
    int linedefined;            /* (S) */

    // the line number where the definition of the function ends.
    int lastlinedefined;        /* (S) */

    // the number of upvalues of the function.
    unsigned char nups;         /* (u) number of upvalues */

    // the number of fixed parameters of the function 可变参数函数 (always 0 for C functions).
    unsigned char nparams;      /* (u) number of parameters */

    // true if the function is a vararg function (always true for C functions).
    char isvararg;              /* (u) */

    // true if this function invocation was called by a tail call. 
    // In this case, the caller of this level is not in the stack.
    char istailcall;            /* (t) */

    /*
        a "printable" (可打印) version of source, to be used in error messages.
    */
    char short_src[LUA_IDSIZE]; /* (S) */
    /* private part */
    other fields
} lua_Debug;







// Returns the current hook function.
lua_Hook lua_gethook (lua_State *L);


// Returns the current hook count.
int lua_gethookcount (lua_State *L);


// Returns the current hook mask.
int lua_gethookmask (lua_State *L);


/*
    Gets information about a specific function or function invocation.

    To get information about a function invocation, 
    the parameter "ar" must be a valid activation record (激活记录) that was filled by a previous call to lua_getstack() or given as argument to a hook (see lua_Hook()).

    To get information about a function, you push it onto the stack and start the what string with the character '>'. 
    (In that case, lua_getinfo() pops the function from the top of the stack.) 
    For instance, to know in which line a function f was defined, you can write the following code:

        lua_Debug ar;
        lua_getglobal(L, "f");  // get global 'f'
        lua_getinfo(L, ">S", &ar);
        printf("%d\n", ar.linedefined);

    Each character in the string what selects some fields of the structure "ar" to be filled or a value to be pushed on the stack:

    'n': fills in the field name and namewhat;
    'S': fills in the fields source, short_src, linedefined, lastlinedefined, and what;
    'l': fills in the field currentline;
    't': fills in the field istailcall;
    'u': fills in the fields nups, nparams, and isvararg;
    'f': pushes onto the stack the function that is running at the given level;
    'L': pushes onto the stack a table whose indices are the numbers of the lines that are valid on the function. (A valid line is a line with some associated code, that is, a line where you can put a break point. Non-valid lines include empty lines and comments.)
    If this option is given together with option 'f', its table is pushed after the function.

    This function returns 0 on error (for instance, an invalid option in what).
*/
int lua_getinfo ( lua_State *L, const char *what, lua_Debug *ar );


/*
    Gets information about a local variable of a given activation record (激活记录) or a given function.

    访问 局部变量;

    In the first case, 
        the parameter "ar" must be a valid activation record that was filled by a previous call to lua_getstack() or given as argument to a hook (see lua_Hook). The index n selects which local variable to inspect; see debug.getlocal for details about variable indices and names.

        lua_getlocal() pushes the variable's value onto the stack and returns its name.

    In the second case, 
        "ar" must be NULL and the function to be inspected must be at the top of the stack. 
        In this case, only parameters of Lua functions are visible (as there is no information about what variables are active) 
        and no values are pushed onto the stack.

    Returns NULL (and pushes nothing) when the index is greater than the number of active local variables.
*/
const char *lua_getlocal (lua_State *L, const lua_Debug *ar, int n);


/*
    Gets information about the interpreter 解释器 runtime stack.

    This function fills parts of a lua_Debug structure with an identification of the activation record of the function executing at a given level. 
    Level 0 is the current running function, 
    whereas level n+1 is the function that has called level n (except for tail calls, which do not count on the stack). 
    
    When there are no errors, lua_getstack() returns 1; when called with a level greater than the stack depth, it returns 0.

*/
int lua_getstack (lua_State *L, int level, lua_Debug *ar);


/*
    Gets information about the n-th upvalue of the closure at index funcindex. 
    It pushes the upvalue's value onto the stack and returns its name. 
    Returns NULL (and pushes nothing) when the index n is greater than the number of upvalues.

    For C functions, this function uses the empty string "" as a name for all upvalues. 
    (For Lua functions, upvalues are the external local variables that the function uses, and that are consequently included in its closure.)

    Upvalues have no particular order, as they are active through the whole function. They are numbered in an arbitrary order.

*/
const char *lua_getupvalue (lua_State *L, int funcindex, int n);


/*
    Type for debugging hook functions.

    这只是一个 lua hook 函数的 类型定义规范;

    Whenever a hook is called, its "ar" argument has its field "event" set to the specific event that triggered the hook. 
    ar 实例的结构体内, 字段 "event" 会被设置为: 触发本 hook 的特定的 event;

    Lua identifies these events with the following constants: 
        LUA_HOOKCALL, 
        LUA_HOOKRET, 
        LUA_HOOKTAILCALL, 
        LUA_HOOKLINE, 
        LUA_HOOKCOUNT. 
    
    Moreover, for line events, the field currentline is also set. -- "ar" 中的 currentline 字段也会被设置;
    To get the value of any other field in "ar", the hook must call lua_getinfo.

    For call events, event can be "LUA_HOOKCALL", the normal value, or "LUA_HOOKTAILCALL", for a tail call; in this case, there will be no corresponding return event.

    While Lua is running a hook, it disables other calls to hooks. 
    Therefore, if a hook calls back Lua to execute a function or a chunk, this execution occurs without any calls to hooks.
    ---
    因此，如果一个 hook 回调 Lua 来执行一个函数或一个块，这个执行发生时 将没有任何对 hooks 的调用;
    tpr: 猜测, 此时没有任何 其他 hook...

    Hook functions cannot have continuations, that is, they cannot call lua_yieldk, lua_pcallk, or lua_callk with a non-null k.
    不能内置 协程;

    Hook functions can yield under the following conditions: Only count and line events can yield; 
    to yield, a hook function must finish its execution calling lua_yield with nresults equal to zero (that is, with no values).

*/
typedef void (*lua_Hook) (lua_State *L, lua_Debug *ar);



/*
    Sets the debugging hook function.

    Argument f is the hook function. 
    
    参数 "mask" specifies on which events the hook will be called: 
        it is formed by a bitwise OR of the constants LUA_MASKCALL, LUA_MASKRET, LUA_MASKLINE, and LUA_MASKCOUNT. -- 多个值的 "位与"
        The count argument is only meaningful when the mask includes LUA_MASKCOUNT. For each event, the hook is called as explained below:

    The call hook: 
        is called when the interpreter 解释器 calls a function. 
        The hook is called just after Lua enters the new function, before the function gets its arguments.
        lua 刚进入那个函数, 在还没拿到 函数参数之前, 这个 hook 就被调用了;

    The return hook: 
        is called when the interpreter returns from a function. 
        The hook is called just before Lua leaves the function. There is no standard way to access the values to be returned by the function.
    
    The line hook: 
        is called when the interpreter is about to start the execution of a new line of code, 
        or when it jumps back in the code (even to the same line). 
        (This event only happens while Lua is executing a Lua function.)
    
    The count hook: 
        is called after the interpreter executes every "count" instructions. 
        (This event only happens while Lua is executing a Lua function.)
    
    A hook is disabled by setting mask to zero.
*/
void lua_sethook (lua_State *L, lua_Hook f, int mask, int count);


/*
    Sets the value of a local variable 局部变量 of a given activation record. 

    设置 局部变量;

    It assigns 分配 the value at the top of the stack to the variable and returns its name. 
    It also pops the value from the stack.
    ---
    将 栈顶元素 分配给 目标变量, 返回它的名字; 同时将这个 栈顶元素从 栈中 pop 掉;

    Returns NULL (and pops nothing) when the index is greater than the number of active local variables.

    Parameters "ar" and "n" are as in function lua_getlocal().
*/
const char *lua_setlocal (lua_State *L, const lua_Debug *ar, int n);


/*
    Sets the value of a closure's upvalue. 
    
    It assigns the value at the top of the stack to the upvalue and returns its name. It also pops the value from the stack.
    将 栈顶元素 分配给 目标 upvalue, 返回它的名字; 同时将这个 栈顶元素从 栈中 pop 掉;

    Returns NULL (and pops nothing) when the index n is greater than the number of upvalues.

    Parameters "funcindex" and "n" are as in function lua_getupvalue().
*/
const char *lua_setupvalue (lua_State *L, int funcindex, int n);


/*
    Returns a unique identifier for the upvalue numbered "n" from the closure at index "funcindex".

    将 idx 为 funcindex 的闭包的 idx 为 n 的 upvalue 的 "唯一id" 返回出来;

    These unique identifiers allow a program to check whether different closures share upvalues. 
    Lua closures that share an upvalue (that is, that access a same external local variable) will return identical ids for those upvalue indices.

    这些 唯一id 允许 lua 检测一个 upvalue 是不是被多个 闭包所共用;


    Parameters "funcindex" and "n" are as in function lua_getupvalue(), but "n" cannot be greater than the number of upvalues.
*/
void *lua_upvalueid (lua_State *L, int funcindex, int n);



/*
    Make the "n1"-th upvalue of the Lua closure at index "funcindex1" refer to the "n2"-th upvalue of the Lua closure at index "funcindex2".
*/
void lua_upvaluejoin (lua_State *L, int funcindex1, int n1,
                                    int funcindex2, int n2);









