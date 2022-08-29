# ==================================================================== #
#                 lua Garbage Collection
# ==================================================================== #

# 搜索: 2.5 – Garbage Collection
https://www.lua.org/manual/5.3/manual.html



# ----------------------------------------------#
#     文档翻译:  2.5 – Garbage Collection
# ----------------------------------------------#

Lua performs automatic memory management. This means that you do not have to worry about allocating memory for new objects or freeing it when the objects are no longer needed. 
Lua manages memory automatically by running a garbage collector to collect all dead objects (that is, objects that are no longer accessible from Lua). 
All memory used by Lua is subject to automatic management: strings, tables, userdata, functions, threads, internal structures, etc.


Lua implements an incremental mark-and-sweep collector. 
lua 使用两个 数 来控制它的 gc-周期: 

    (1) garbage-collector pause  
    (2) garbage-collector step multiplier

这两个值的单位都是 1/100; (当值为 100 时, 等于 100/100)

# (1) garbage-collector pause  
此值控制: "how long the collector waits before starting a new cycle"; 需要等待多久才会开启新的 gc周期;
此值越大, 越不激进:
-- 若为 100, 则每次不做等待就进入新的 gc周期
-- 若为 200, 则要等到 total memory 膨胀为原来的 2倍时, 才会进行新的 gc-周期;

# (2) garbage-collector step multiplier
此值控制: "the relative speed of the collector relative to memory allocation";

较大的值会使 收集器更加激进，but also increase the size of each incremental step.
不该使用小于 100 的值, 因为它会导致 收集器太慢, 最终导致 收集器永远无法完成一个周期;
默认值为 200, 意为: 收集器以 内存分配的 2倍速度来 运行 (收集)

若此值太大, (超过 程序能使用的最大内存的 1/10), the collector behaves like a stop-the-world collector. 
如果你再把 garbage-collector pause  设置为 200, 那么 收集器的行为就会类似 旧版 lua 的行为:
    每当 lua 使用的内存翻倍时, 执行一次完整的 gc;

可在 c代码中调用 lua_gc(), 或在 lua 中调用 collectgarbage() 来设置这两个值; 
还能使用这俩函数来直接操作 收集器: (如: 停止, 重启)



# ----------------------------------------------#
#     文档翻译:  2.5.1 – Garbage-Collection Metamethods
# ----------------------------------------------#

可为 table 和 userdata 设置 gc metamethod (元方法); 这些 元方法 也被成为 finalizers (终结器);
(tpr: 一个 obj 可以设置若干个 finalizer)

finalizer 允许你协调 lua 的gc 和 额外的 资源管理; ( 比如关闭: 文件, 网络和 数据库连接, 或释放你自己分配的内存 )

对一个需要在 gc 是被 终结的对象 (table 或 userdata), 你必须将其标记为 finalization; 
通过为这个对象 绑定一个 metatable, 并在 metatable 里设置一个 key 为 "__gc" 的字段, 以此来为这个 对象 标记为 finalization;

Note that if you set a metatable without a __gc field and later create that field in the metatable, the object will not be marked for finalization.

当一个被标记的 obj 变成了垃圾, 它不会立刻被 gc 回收; 相反, lua 会把它放入一个 list; 在收集完成后, lua 会遍历这个 list; 争对 list 中的每一个元素, lua 检查它的 "__gc" 元方法:
    如果它是一个函数, lua 调用它, 并把 obj 当作唯一的参数传递进去;
    如果它不是一个函数, lua 会 忽略它...

在每次 gc 周期的结尾, 那些标记为 finalization 的obj 的 终结器(多个) 会按照倒叙被调用; 
that is, the first finalizer to be called is the one associated with the object marked last in the program. The execution of each finalizer may occur at any point during the execution of the regular code.

因为被收集的 obj 必须任然被 finalizer 所使用, 该对象（以及只能通过它访问的其他对象）必须由 Lua 复活;
通常这个复活是暂时的, 且会在下一次 gc周期中释放这个 obj 的内存;

但是, 如果 finalizer 将这个 obj 存储在某个 全局位置 (比如存储为一个 global variable ), 那么这个复活就是长期的; 
甚至, 如果 finalizer 将那个 正在被终结的obj 再次标记为 finalization, 那么它的 finalizer 会在下一次 gc循环中被再次调用, 此时这个 obj 已经 unreachable (无法得到了)

In any case, the object memory is freed only in a GC cycle where the object is unreachable and not marked for finalization.


当你调用类似 lua_close 关闭了一个 state, lua 调用所有被标记为 finalization 的 obj 的 finalizers; (以这些 finalizers 入栈的倒叙的顺序)

If any finalizer marks objects for collection during that phase, these marks have no effect.



# ----------------------------------------------#
#     文档翻译:  2.5.2 – Weak Tables
# ----------------------------------------------#
一个 weak table 是一个 table, 它的元素都是 weak reference (弱引用);
gc 会忽略一个 弱引用; 

换句话说, 如果一个 obj 只被一个 弱引用 所引用时, gc 会把它当成垃圾收走;


A weak table can have weak keys, weak values, or both. 
A table with weak values allows the collection of its values, but prevents the collection of its keys.
A table with both weak keys and weak values allows the collection of both keys and values. 

在任何情况下, 只要一个 pair 的 key 或 value 被gc, 那么这个 pair 就会被清出 table;


The weakness of a table is controlled by the "__mode" field of its metatable. 
-- If the "__mode" field is a string containing the character 'k', the keys in the table are weak. 
-- If "__mode" contains 'v', the values in the table are weak.

----
拥有 弱key 和 强val 的 table, 被称为 ephemeron table (蜉蝣表); 
在它的里面, 只有当它的 key 是 reachable 时, 对应的 value 才被认为是 reachable 的;
特别的, 如果一个 key 的唯一引用来自于它的 value, 那么这个 pair 就会被移除; 

对一个 table 的任何 强弱性 的修改, 都只会在下一次 gc周期中生效; 
特别的, 就算你把 table 的某方面改为 强属性了, 本次gc 还是会照旧处理'

只有具有 显式构造 的对象才会从弱表中删除; 值, 比如 number, 或轻量级的 c函数, 不受 gc 的约束, 所有不会被从 weak table 中移除 (除非它们关联的 value 被收集了);
尽管 strings 受到 gc 的约束, 但它们没有 显式构造, 因此不会从 weak table 中移除;


Resurrected objects (that is, objects being finalized and objects accessible only through objects being finalized) have a special behavior in weak tables. 
---
被复活的 obj (也就是说，对象正在被终结，并且对象只能通过正在终结的对象访问) 在 weak table 中拥有一个特殊的行为:
    They are removed from weak values before running their finalizers, 
    but are removed from weak keys only in the next collection after running their finalizers, when such objects are actually freed.
    ---
    在运行它们的 finalizers 之前, 它们会从 weak value 中被移除;
    但需要在运行了它们的 finalizers 之后, 才会在下一次 gc周期中, 从 weak keys 中移除它们;

    This behavior allows the finalizer to access properties associated with the object through weak tables.


If a weak table is among the resurrected objects in a collection cycle, it may not be properly cleared until the next cycle.
---
如果一个弱表在一个回收周期中的复活对象中，它可能要到下一个周期才能正确清除。











# ----------------------------------------------#
#      collectgarbage ([opt [, arg]])
# ----------------------------------------------#
This function is a generic interface to the garbage collector. It performs different functions according to its first argument, opt:

是 gc 的一个 常规接口函数, 基于它 首个参数的值, 具备不同的行为:

# "collect": 
    performs a full garbage-collection cycle. This is the default option.
# "stop": 
    stops automatic execution of the garbage collector. The collector will run only when explicitly invoked, until a call to "restart" it.
# "restart": 
    restarts automatic execution of the garbage collector.
# "count": 
    returns the total memory in use by Lua in Kbytes. The value has a fractional part(小数), so that it multiplied by 1024 gives the exact number of bytes in use by Lua (except for overflows).

# "step": 
    performs a garbage-collection step. The step "size" is controlled by arg. With a zero value, the collector will perform one basic (indivisible) step. For non-zero values, the collector will perform as if that amount of memory (in KBytes) had been allocated by Lua. Returns true if the step finished a collection cycle.

# "setpause": 
    sets arg as the new value for the pause of the collector (see §2.5). Returns the previous value for pause.

# "setstepmul": 
    sets arg as the new value for the step multiplier of the collector (see §2.5). Returns the previous value for step.

# "isrunning": 
    returns a boolean that tells whether the collector is running (i.e., not stopped).

























