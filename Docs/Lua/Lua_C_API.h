/*
 * ========================= Lua_C_API.h ==========================
 *                          -- tpr --
 * ----------------------------------------------------------
 *  C 部分 API
 *   
 * ----------------------------
 */
#include <unistd.h> //- size_t
#include <stdarg.h> //- va_list


//---------------------------------------------------
// lua栈。
// 一个不透明的 struct，指向一个线程，通过这个线程，间接获得 lua解释器的 所有 state
// Lua library 是完全可重入的，它没有全局变量。
// 有关一个 state／状态机 的所有信息，都可通过这个 struct 来访问
// 库中所有函数的 首参数，就是一个 指向 lua_State 的指针（除了 lua_newstate函数。）
typedef struct lua_State lua_State;


//---------------------------------------------------
// lua state 使用的 内存分配函数 函数指针。
// 此 内存分配函数，必须提供类似 realloc 的功能，但不完全一样
// param: ud -- 不透明指针，
// param: ptr -- 指向一块 block 的指针，这块内存区域将被 allocated / reallocated / freed
// param: osize -- block 的旧尺寸／或
// param: nsize -- block 的新尺寸
typedef void * (*lua_Alloc) (void *ud,
                             void *ptr,
                             size_t osize,
                             size_t nsize);
    //- 当 ptr != NULL, osize 应该传入 block 的旧尺寸
    //- 当 ptr == NULL, osize 应写入 如下几项之一：
    //    LUA_TSTRING
    //    LUA_TTABLE
    //    LUA_TFUNCTION
    //    LUA_TUSERDATA
    //    LUA_TTHREAD 
    //  若 osize 不为以上之一，lua将分配内存做它用（未查明）

    //- 若 nsize 为 0。内存分配器必须表现得像个 free()。且返回 NULL
    //  若 nsize 非 0.内存分配器必须表现得像个 realloc()。
    //    此时，如果 内存分配器无法满足 调用者需求，将返回 NULL
    //    lua假定。若 osize>=nsize. 内存分配器将 永不失败。

    //---- 例子 -----
    // static void *l_alloc (void *ud, void *ptr, size_t osize, size_t nsize) {
    //     (void)ud;  (void)osize;
    //     if (nsize == 0) {
    //         free(ptr);
    //         return NULL;
    //     } else {
    //         return realloc(ptr, nsize);
    //     }
    // }


//---------------------------------------------------
//- 在一个新的独立的 state／虚拟栈中 创建一个 新线程。
//- param:f -- 内存分配函数。用来执行 lua中的一切内存分配
//- param:ud -- 每次调用本函数时，传递给 f 的一个 不透明指针
lua_State *lua_newstate (lua_Alloc f, void *ud);

    //-- return:
    //  若失败，返回 NULL (当无法创建新线程，或新虚拟栈，因为内存不足)
    //



//---------------------------------------------------
// 函数指针，被 lua_load 函数使用。每次需要 chunk 的另一块 piece时
// lua_load 就调用 lua_Reader，传入参数 data，
// reader 就 返回一个指针，指向 a block of memory with a new piece of the chunk
// 同时反向设置 参数size 的值为 block size。
// block 必须持续存在到 reader 函数下一次被调用
// 为了标记 chunk 的 end。reader必须返回 NULL，或者设置 size 为 0.
// 本函数可能返回 任何一块 值大于0 的 piece。
typedef const char * (*lua_Reader) (lua_State *L,
                                    void *data,
                                    size_t *size);


//---------------------------------------------------
// Loads a Lua chunk，但并不运行它。
// param: L --
// param: reader -- 用户提供的函数（指针），用来读取 chunk
// param: data -- 不透明值
// param: chunkname -- 给予 chunk 一个name，用于 error msg, debug info
// param: mode -- 类似 lua函数 load 中的参数 mode 的用法... 
//                不同之处在于，若输入值为NULL。等于输入 "bt" 

// 本函数会自动检测 目标chunk 是文本还是二进制文件，并用不同的方法加载它

// 本函数在内部使用 stack，所以 reader函数在 返回时 必须总是 保证 stack 没有被改动

// If the resulting function has upvalues, its first upvalue is set to 
// the value of the global environment stored at index LUA_RIDX_GLOBALS in the registry

// 当加载 main chunks，this upvalue will be the _ENV variable
// Other upvalues are initialized with nil
//
//
int lua_load (lua_State *L,
              lua_Reader reader,
              void *data,
              const char *chunkname,
              const char *mode);

    //-- return:
    //  若返回 -- LUA_OK, (值为0)
    //      说明运行正确。
    //      并把 编译好的 chunk， 以 lua function 的形式
    //      push 到 lua栈中。

    //  若返回 -- LUA_ERRSYNTAX.
    //      说明在 预编译阶段 发生 syntax error。

    //  若返回 -- LUA_ERRMEM: 
    //      内存分配错误（内存不够）

    //  若返回 -- LUA_ERRGCMM
    //      说明 在运行一个 __gc metamethod 时发生错误
    //      与 被加载的 chunk 无关，是在 垃圾回收器中 发生的错误
    
    //-- 上述各个失败，也将把 error message，push 到 lua栈中。






//---------------------------------------------------
// Loads a string as a Lua chunk
// 使用  lua_load 来 加载 chunk，in the 以尾后0结尾的 string s
int luaL_loadstring (lua_State *L, const char *s);

    //-- return:
    //  返回 lua_load() 函数的返回值

    //- 和 lua_load() 一样，本函数只 加载 chunk，不运行它



//---------------------------------------------------
//  Calls a function.
//  使用规则：
//  -1- 确保目标函数 已经被 push 进 stack
//  -2- 然后，相关参数被 以 direct order push 进 stack（第一个参数先入栈）
//  -3- 最后，再来调用 lua_call。
// param: L
// param: nargs -- 参数个数
// param: nresults -- 返回值个数
//                    若为 LUA_MULTRET，表示 “接受所有 返回值”
void lua_call (lua_State *L, int nargs, int nresults);

    //- 目标函数 在 lua 中正式调用时，会把 stack 中的 函数变量，参数 都 pop 出来
    //  然后，函数运行结束后，会把 返回值 push 进 stack 中。（个数根据参数 nresults 来定 ）
    //  返回值入栈规则按照 direct order （第一个值先入栈）

    //- 在调用过程中发生的任何 error，都将 “向上传递” -- propagated upwards (with a longjmp)

    //- 情确保，在一系列 lua_call 流程后，将 stack 恢复到最初的状态。



//---------------------------------------------------
typedef int lua_KContext;  //- tmp
        //  type for continuation-function contexts
        //  它必须是个 numeric type：
        //   -- 当 intptr_t 是可获得的，此类型被定义为 intptr_t。（可以存储 指针）
        //   -- 否则，被定义为 ptrdiff_t
typedef int (*lua_KFunction) (lua_State *L, int status, lua_KContext ctx);
        //  Type for continuation functions

//---------------------------------------------------
//  和 lua_call 功能一样，但允许  the called function to yield
void lua_callk (lua_State *L,
                int nargs,
                int nresults,
                lua_KContext ctx,
                lua_KFunction k);


//---------------------------------------------------
//  "protected call"
//  Calls a function in protected mode   
//  -- 如果在 函数调用期间，没有发生 error，本函数和 lua_call 效果一样
//  -- 如果发生任何 error，本函数 catch the error。
//     pushes a single value on the stack (the error object)
//     and returns an error code。

// param: L
// param: nargs
// param: nresults
// param: msgh -- 若为0，放入 stack 中的 error object 会是  the original error object
//                否则，msgh is the stack index of a message handler
//
int lua_pcall (lua_State *L, int nargs, int nresults, int msgh);

    //- 和 lua_call 一样，本函数也会把 stack 中的 函数变量 和 参数都取出

    //-- return:
    //  若返回 -- LUA_OK  (值为0)
    //      说明运行正确。

    //  若返回 -- LUA_ERRRUN
    //      a runtime error

    //  若返回 -- LUA_ERRMEM: 
    //      内存分配错误（内存不够）
    //      此时，lua 不会调用 message handler

    //  若返回 -- LUA_ERRERR
    //      运行 message handler 时发生 error

    //  若返回 -- LUA_ERRGCMM
    //      在运行 a __gc metamethod 时发生 error。
    //      此时，lua 不会调用 message handler


//---------------------------------------------------
//  和 lua_pcall 功能一样，但允许  the called function to yield
int lua_pcallk (lua_State *L,
                int nargs,
                int nresults,
                int msgh,
                lua_KContext ctx,
                lua_KFunction k);


//-------------------------------------------------------------
//  Type for C functions.
//  c函数指针，指向一个 c函数，这个c函数 将被 lua 调用。

//-- 一个c函数 想要被 lua 使用，必须符合特定的 制作规范。尤其是 参数和返回值的传递规则：
//  -- 先调用 lua_gettop，获得 stack 中元素个数。这些元素 就是 c函数的 参数
//     然后通过 lua_toXXX 系列函数，从 stack 中取出元素，到c函数中，然后使用这些 参数

//  -- 当主体内容执行完毕，要将返回值 传递给 lua 时。
//     将 返回值 按照 in direct order （第一个返回值先push）push 到 stack
//     最后，在 c函数中，return 返回值的 个数
//-- （被 lua 调用的 C函数，也能返回 多个 返回值）
typedef int (*lua_CFunction) (lua_State *L);

    //--- C函数 示范 ---
    // static int foo (lua_State *L) {
    //    int n = lua_gettop(L);    /* number of arguments */
    //    lua_Number sum = 0.0;
    //    int i;
    //    for (i = 1; i <= n; i++) {
    //      if (!lua_isnumber(L, i)) {
    //        lua_pushliteral(L, "incorrect argument");
    //        lua_error(L);
    //      }
    //      sum += lua_tonumber(L, i);
    //    }
    //    lua_pushnumber(L, sum/n);        /* first result */
    //    lua_pushnumber(L, sum);         /* second result */
    //    return 2;                   /* number of results */
    // }


//--------------------------------------------------------------
//                      lua_pushXXX 
//--------------------------------------------------------------
typedef double lua_Number; //- tmp
        //  The type of floats in Lua
        //  此类型默认为 double， 但可变为 a single float ／ a long double
        //  参见 LUA_FLOAT_TYPE in luaconf.h
typedef long long lua_Integer;
        //  The type of integers in Lua
        //  默认为 long long，／ i64. 但可变为 long ／ int
        //  参见 LUA_INT_TYPE in luaconf.h

//---- 在 C代码中， 将一个元素 push 到 stack ----
void lua_pushnil (lua_State *L);
void lua_pushboolean (lua_State *L, int b);
void lua_pushnumber (lua_State *L, lua_Number n);
void lua_pushinteger (lua_State *L, lua_Integer n);
const char *lua_pushlstring (lua_State *L, const char *s, size_t len);
    // 此版本的 参数s 指向的字符串 不需要 尾后0. （也不一定记载字符串，可以是二进制任意值）
    // lua 内部会 复制一份此 字符串，所以在本函数调用介绍后，可把 参数 s代表的字符串立即释放。
    // 参数s 可包含任何 二进制数据，包含0
    // 返回一指针，指向 lua 内部拷贝的 字符串。
const char *lua_pushstring (lua_State *L, const char *s);
    // s必须为 以尾后0结束的字符串。
    // 此函数通过 strlen 来计算 字符串s 的长度
    // 其他行为和 lua_pushlstring 一样

    // 如果 参数s 为 NULL， 会向 stack push nil，并且本函数最终返回 NULL

void lua_pushboolean (lua_State *L, int b);
void lua_pushcclosure (lua_State *L, lua_CFunction fn, int n);
    //  Pushes a new C closure
    //  压入一个 c函数，及其关联变量。本函数将创建一个 c闭包 （通畅给 lua 调用）

    //-- C Closures --
    //-  当一个 C函数被创建，它可能与一些 自由变量有关联。这种 c函数就是 c闭包
    //   这些被关联的 自由变量，就叫 upvalues。
    //   任何时候，c闭包被调用时，都能访问这些 upvalues
    //-  当这个 c闭包被调用，它的 upvalues 被设置于 specific pseudo-indices
    //   这些 pseudo-indices 被 宏lua_upvalueindex 创建
    //   第一个 upvalues 位于 lua_upvalueindex(1)
    //   如果访问一个 越界的 lua_upvalueindex(n)，将创建一个 “可访问但无效” 的index

    //-- 为了将一个 自由变量 与 c函数 绑定，
    //   首先，这些 变量 必须被 push 到 stack。（第一个变量先 push）
    //   然后调用 lua_pushcclosure，将 c函数 创建并push 到 stack
    //   参数n 表示 有多少个 关联变量。上限为 255

    //-- 若 参数n 为0. 此时将创建 a light C function
    //   也就是个一个简单的 函数指针，指向目标 c函数。
    //   在这种情况下，本函数永远不会 引起 内存 error

void lua_pushcfunction (lua_State *L, lua_CFunction f);
    // 参数f 为一个普通c函数 的指针。
    // 本函数将 创建一个 lua变量（类型为 function）。并将此变量 压入 stack
    // 这个 函数变量 将被 lua 调用

    //-- 任何将被 lua 调用的 c函数，都需要遵循正确的 制作流程。
    //   来约定其 参数 和 返回值 的 传递方式
    //   参见 lua_CFunction

const char *lua_pushfstring (lua_State *L, const char *fmt, ...);
    // push 格式化的 string。类似 c中的 sprintf
    // 略 ...

void lua_pushglobaltable (lua_State *L);
    // Pushes the global environment onto the stacks

void lua_pushinteger (lua_State *L, lua_Integer n);
void lua_pushlightuserdata (lua_State *L, void *p);
    // Pushes a light userdata onto the stack
    // 未完...

const char *lua_pushliteral (lua_State *L, const char *s);
    //-- 宏，等同于 lua_pushstring
    //   只有在 参数s 为 literal string 是，才调用本函数

int lua_pushthread (lua_State *L);
    //  Pushes the thread represented by L onto the stack
    //  Returns 1 if this thread is the main thread of its state

void lua_pushvalue (lua_State *L, int index);
    // Pushes a copy of the element at the given index onto the stack

const char *lua_pushvfstring (lua_State *L,
                              const char *fmt,
                              va_list argp);
    //-- 等同于 lua_pushfstring. 
    //   区别在于，通过 va_list 来接受 可变参数


//---------------------------------------------------
//  扩充 stack，从而确保 stack 至少拥有 参数n 个 slots。
int lua_checkstack (lua_State *L, int n);

    //- 本函数永远不会 缩小 stack。如果满足 参数n 大的空间。
    //  本函数也不会去 缩小 stack

    //-- return:
    //  若 参数n 合规，本函数会扩充 stack，直到满足 参数n
    //  若 参数n 过大，比如超出 a fixed maximum size，或者无法进一步分配内存
    //      本函数会返回 0 （表示false）

//---------------------------------------------------
//  类似 lua_checkstack
//  如果扩容失败，会抛出指定的 错误信息 error message。
// param: L
// param: sz
// param: msg -- 构成 error message 的额外信息。
//               可输入 NULL，表示不传入 额外msg
void luaL_checkstack (lua_State *L, int sz, const char *msg);


//--------------------------------------------------------------
//                      lua_isXXX 
//--------------------------------------------------------------
//- 判断 stack 中 索引为 参数index 的元素，为目标类型。
int lua_isnil (lua_State *L, int index);  //- 若符合，返回 1，否则返回 0
int lua_isnone (lua_State *L, int index); //- 是否为 is not valid
int lua_isnoneornil (lua_State *L, int index); //- 是否为 is not valid / is nil
int lua_isboolean (lua_State *L, int index);
int lua_isnumber (lua_State *L, int index); //- is a number or a string convertible to a number
int lua_isinteger (lua_State *L, int index);

int lua_isstring (lua_State *L, int index); //-  is a string or a number 
                                            //   (which is always convertible to a string)
int lua_istable (lua_State *L, int index);
int lua_isthread (lua_State *L, int index);

int lua_iscfunction (lua_State *L, int index); //- 是否为 C function
int lua_isfunction (lua_State *L, int index); //- 是否为 function (C/Lua皆可)

int lua_isuserdata (lua_State *L, int index); //- is a userdata (either full or light)
int lua_islightuserdata (lua_State *L, int index); //- 是否为 a light userdata

int lua_isyieldable (lua_State *L); //- if the given coroutine can yield


//--------------------------------------------------------------
//                      lua_toXXX 
//--------------------------------------------------------------
// 从 stack 中提取一个 元素，到 C代码中。
// 即便 stack 中的元素 和调用函数指定的类型不匹配，调用这些函数也没问题
//
int lua_toboolean (lua_State *L, int index);
    //- 将 任意 lua值 转换为 C 中的 “bool值”
    //  -- 若元素为 false/nil, 本函数返回 0
    //  -- 否则，返回 1

    //- 如果你 只想要 stack 中的 bool元素，推荐先用 lua_isboolean 函数检查一下

lua_CFunction lua_tocfunction (lua_State *L, int index);
    //- 将 stack中的 指定元素，转变为一个 C函数
    //  如果 目标元素 不是 c函数，本函数将返回 NULL


lua_Integer lua_tointegerx (lua_State *L, int index, int *isnum);
    //- 读取 stack 中目标元素，将其转换为 一个 c int，并返回出来 
    //  目标元素 必须是 lua 中的 integer, number, string 类型。
    //  否则，本函数 返回 0

    //-- 如果 参数isnum 不为 NULL。此槽将被本函数写入一个 bool值（在c中通常是 1/0）
    //   来表示，本函数是否运行正确

lua_Integer lua_tointeger (lua_State *L, int index);
    //- 等同于 lua_tointegerx （参数 isnum 为 NULL）

const char *lua_tolstring (lua_State *L, int index, size_t *len);
    //- 读取 stack 中目标元素，将其转换为 一个 c字符串。
    //  目标元素 必须是 lua 的 string，number。
    //  否则，本函数返回 NULL。

    // 如果 目标元素 是 number，本函数会将其 转换为一个 c字符串。
    // This change confuses lua_next when lua_tolstring 
    // is applied to keys during a table traversal.

    //-- 本函数返回一个 字符串指针，指向的字符串 存储在 lua state 中。
    //   这个字符串 永远自备 尾后0. （但也能在 字符串体内包含其他0. 意味着可以表示任何二进制数）

    //-- 由于 lua 拥有 gc，无法保证 本函数的返回的 指针， 在 相关lua变量被移除后，仍然有效。

    //-- 如果 参数len 不为NULL，本函数将向 此槽写入 c字符串的 字节数， 

const char *lua_tostring (lua_State *L, int index);
    //-- 等同于 lua_tolstring，当 参数len 为 NULL

lua_Number lua_tonumberx (lua_State *L, int index, int *isnum);
    //  目标元素 必须是 lua 的 number, string(将被自动转换为 number)
    //  否则，本函数 返回0

    //-- 如果 参数isnum 不为 NULL。此槽将被本函数写入一个 bool值（在c中通常是 1/0）
    //   来表示，本函数是否运行正确

lua_Number lua_tonumber (lua_State *L, int index);
    //-- 等同于 lua_tonumberx（参数 isnum 为 NULL）

const void *lua_topointer (lua_State *L, int index);
    // 目标元素 必须是 lua 的 userdara, table, thread, function
    // 否则，本函数返回 NULL。

    //-- 不同 obj 返回不同的 指针，没有办法将指针 转换回 original value

    //-- 通常，本函数仅用于 hashing and debug information

lua_State *lua_tothread (lua_State *L, int index);
    // 目标元素 必须是 lua 的 thread.
    // 否则，本函数 返回 NULL

void *lua_touserdata (lua_State *L, int index);
    // 如果目标元素是 a full userdata，返回其 block address
    // 如果目标元素是 a light userdata，返回其 指针
    // 否则，本函数 返回 NULL


//-------------------------------------------------------------
// 宏，返回 当前运行的 函数的 第i个 upvalues 的 pseudo-index
// 输入 参数i，创建一个对应的 pseudo-index
int lua_upvalueindex (int i);


//-------------------------------------------------------------
// ...
int lua_next (lua_State *L, int index);


//-------------------------------------------------------------
// 返回 stack 中 参数index 指向的 元素 的 类型。
int lua_type (lua_State *L, int index);

    //-- return
    //   如果 参数index是 non-valid (but acceptable)，返回 LUA_TNONE
    //   LUA_TNIL (0)
    //   LUA_TNUMBER
    //   LUA_TBOOLEAN
    //   LUA_TSTRING
    //   LUA_TTABLE
    //   LUA_TFUNCTION
    //   LUA_TUSERDATA
    //   LUA_TTHREAD
    //   LUA_TLIGHTUSERDATA


//-------------------------------------------------------------
//-- 返回 stack 中栈顶元素的 idx值（最浅层的那个）
//   由于 lua 的起始元素 标号为1，所以，本函数的返回值，也可理解为：
//   “stack 中元素的 个数”
//--  如果 本函数返回 0，表示 stack 是空的
int lua_gettop (lua_State *L); 


//-------------------------------------------------------------
// 接受任何 参数index（包含0），将 stack 的栈顶指针 指向 此index
// 如果，参数index 的值大于 原有 栈顶index，则对 stack 扩容。新增的 元素统统填 nil
// 如果 参数index 变小了，则对 stack 缩容。
// 如果 参数index 为0. 则将 stack 彻底清空
void lua_settop (lua_State *L, int index);
    //- 也可以使用 负数index。


//-------------------------------------------------------------
//  #define lua_pop(L,n) lua_settop( L, -(n)-1 )
//  从栈顶 弹出 参数n 个元素
void lua_pop (lua_State *L, int n);

//-------------------------------------------------------------
// 将 stack 中，idx处元素 到 栈顶 这段区域内的元素， 回环旋转 n个位置
//  以 数组 {1,2,3,4} 为例：
// 当 参数n 为正数，则 朝向栈顶方向 回环旋转
//     比如说，n=1。
//      -- 首先，区域中所有元素，向 栈顶（右侧）移动 n=1 位。
//      -- 然后，右侧溢出的数据，回环填入 左侧空缺。
//      {4,1,2,3}
// 当 参数n 为负数，则 朝向栈底方向 回环旋转
//     比如说，n=1。
//      -- 首先，区域中所有元素，向 栈底（左侧）移动 n=1 位。
//      -- 然后，左侧溢出的数据，回环填入 右侧空缺。
//      {2,3,4,1}
//-- 本函数是很多 函数的实现者，比如 lua_remove, lua_insert
// 此函数不能用于 pseudo-index。因为 pseudo-index 不是实际上的 stack position
void lua_rotate (lua_State *L, int idx, int n);


//-------------------------------------------------------------
// 将 参数index 指向的 stack 元素移除。并将 它上方的元素下移。来填满这个间隙。
// 这个函数实际是 通过 lua_rotate 实现的:
// #define lua_remove(L,idx) (lua_rotate(L,(idx),-1), lua_pop(L,1))
// 此函数不能用于 pseudo-index。因为 pseudo-index 不是实际上的 stack position
void lua_remove (lua_State *L, int index);


//-------------------------------------------------------------
// 将 栈顶元素 插入到 参数index 指向的位置
// 整个操作完成后，原来的 栈顶元素 不再位于栈顶。
// 原来 参数index 位置处的元素（及其上面的所有元素）都将上移
// 这个函数实际是 通过 lua_rotate 实现的:
//  #define lua_insert(L,idx) lua_rotate(L,(idx),1)
// 此函数不能用于 pseudo-index。因为 pseudo-index 不是实际上的 stack position
void lua_insert (lua_State *L, int index);


//-------------------------------------------------------------
// 将 栈顶元素 复制一份，到 参数index 指向的位置。
// 然后 pop 掉这个 栈顶元素（从而实现 “replace” ）
void lua_replace (lua_State *L, int index);


//-------------------------------------------------------------
// 将 参数fromidx 处的元素，复制一份，到 参数toidx处
// 参数fromidx 处的原有元素 将被覆盖
// 参数toidx 处的原有元素，不变
void lua_copy (lua_State *L, int fromidx, int toidx);



#define LUA_IDSIZE 1024 //-tmp
//-------------------------------------------------------------
//- 一个用来容纳 某个 函数／激活态记录 的数段信息的 数据结构。
//  lua_getstack函数 只装填这个 结构中的 private部分，用于后续使用
//  剩余部分，通过调用 lua_getinfo 来写入
typedef struct lua_Debug {
    int event;
    const char *name;           /* (n) */
            // 给定function 的 一个 合理的 name
            // 由于 lua 中的 函数 是 一类成员，它们没有 固定名字:
            // -- 某些函数 可以是 数个全局变量的 值。
            // -- 某些函数 只存储在 一个 table 的作用域内部。
            //  lua_getinfo 函数 检测 一个函数是如何被 调用的，来找到 合适的名字。
            //  如果 lua_getinfo 函数无法找到 名字，就将 本字段 设置为 NULL
    const char *namewhat;       /* (n) */
            // 解释 name 字段，根据 function 是怎么被调用的，可以为:
            // -- "global"
            // -- "local"
            // -- "method"
            // -- "field"
            // -- "upvalue"
            // -- "" (空字符串, when no other option seems to apply. )
    const char *what;           /* (S) */
            // -- 若为 "lua" -- function 为 lua函数
            // -- 若为 "c"   -- function 为 c函数
            // -- 若为 "main" -- function 为 一个 chunk 的 main part
    const char *source;         /* (S) */
            // 创建 function 的 chunk 的 name。
            // -- 如果 source 以 '@' 开头，意味着 目标function 被定义在一个 文件中，
            // 这个文件名 就是 source 中 '@' 后的那部分字符串
            // -- 如果，source 以 '=' 开头，source的后部分字符串 描述 source 在一个
            // user-dependent manner。
            // -- 如果都不是，说明 function 被直接定义在 source 这个字符串内
    int currentline;            /* (l) */
            // 给定function 的 当前执行行 的 行号。
            // 如果没有 行信息提供，此字段 被设置为 -1
    int linedefined;            /* (S) */
            // 函数定义部分 起始行 的 行号
    int lastlinedefined;        /* (S) */
            // 函数定义部分 结尾行 的 行号
    unsigned char nups;         /* (u) number of upvalues */
            // 目标function 的 upvalues 的数量
    unsigned char nparams;      /* (u) number of parameters */
            // 目标function 的 固定参数 的数量
            // 若 function 为 c函数，此字段永远为 0
    char isvararg;              /* (u) */
            // true -- 如果 目标function 是 可变参数函数
            // 若 function 为 c函数，此字段永远为 true
    char istailcall;            /* (t) */
            // true  -- 如果 目标function 被 尾调用
            //          此时，，目标function 的调用者 不在 stack 中。
            // false
    char short_src[LUA_IDSIZE]; /* (S) */
            // source 的 "printable" version。用于 error msg

    /* private part */
    //other fields
} lua_Debug;



//-------------------------------------------------------------
// 获得 解释器运行时 stack 的 信息。
// 此函数 会向 lua_Debug 结构 填入部分数据：
// 通过对一个 “在 参数level 运行的function” 的 活跃态记录的 鉴别。
// param: L
// param: level -- 0 表示 当前运行函数，1表示 当前函数被调用的那个函数，以此类推。
//                 尾调用函数除外：which do not count on the stack
// param: ar --
int lua_getstack (lua_State *L, int level, lua_Debug *ar);

    //- return
    //  若无错误，返回 1
    //  若本函数被一个 大于 stack深度 的 level调用，返回 0 (?)
    

//-------------------------------------------------------------
// 获得 特定 函数／函数调用 的 信息。
// 参数ar 必须是一个 有效的活跃态记录，且在此之前 被 lua_getstack函数 填充
// 或 被一个 hook 以 参数的形式给予 （参见 -- lua_Hook ）

// 为了获得一个函数的信息，我们将 它 push 到 stack，然后在 参数what 中 输入一个 '>'开头的字符串
// 此时，lua_getinfo 将从 栈顶 pop 出 目标function。

// -- 参数what 以 '>'开头，后跟如下字符：
// -- 'n' 填充 name，namewhat
// -- 'S' 填充 source, short_src, linedefined, lastlinedefined, what
// -- 'l' 填充 currentline
// -- 't' 填充 istailcall
// -- 'u' 填充 nups, nparams, isvararg
// -- 'f' 填充 将给定level 运行的 function push到 stack
// -- 'L' 填充 将一个 table push到 stack。这个 table 的 索引，
//        是 函数的有效行 的行号（空行，注释行 是无效的）

//-- If this option is given together with option 'f', 
//   its table is pushed after the function.
int lua_getinfo (lua_State *L, const char *what, lua_Debug *ar);

    //- This function returns 0 on error 
    //- (for instance, an invalid option in what).


//-------------------------------------------------------------
// 获得一个 给定的活跃态记录／给定function 的 local变量 的 信息。
// -- 给定的活跃态记录:
//    参数ar 必须是一个 有效的活跃态记录，且已经被 lua_getstack函数填充。
//    或被一个 hook 以 参数的形式 给予。
//    参数n 是个索引，决定 哪个 local变量 将被检测 
//    (参见 debug.getlocal，获知 variable indices and names 的细节 )
//    本函数 将 变量的值 push 到 stack，然后 返回它的 name

// -- 给定function:
//    参数ar 必须为 NULL，被检测的function 必须在 栈顶。
//    此时，只有 lua函数 的 参数 是visible的。（此时没有信息 可知哪个变量是 active的 ）
//    以及，没有 值 被 push 到 stack。
//    如果 参数n 大于 active local变量 的数量，本函数返回 NULL（且 push nothing）
const char *lua_getlocal (lua_State *L, const lua_Debug *ar, int n);






