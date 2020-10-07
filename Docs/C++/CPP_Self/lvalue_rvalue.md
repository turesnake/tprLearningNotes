# =============================================== #
#            左值 右值 引用折叠 完美转发 
# ----------------------------------------------- #



每个表达式，只属于三种基本值类别中的一种：
- 纯右值 (prvalue)
- 亡值 (xvalue)
- 左值 (lvalue)

剩余两种类型，则是上述三种的 混合体

# =============================================== #
#               glvalue - 广义左值 (generalized)
A glvalue is an expression whose evaluation determines the identity of an object, bit-field, or function.
---
表达式求值，确定一个 obj/位域/函数 的个体
# ---------------- :




# =============================================== #
#                prvalue - 纯右值 (pure)
a prvalue (“pure” rvalue) is an expression whose evaluation either:
(1).computes the value of the operand of an operator (such prvalue has no result object),
(2).initializes an object or a bit-field (such prvalue is said to have a result object). With the exception of decltype, all class and array prvalues have a result object even if it is discarded. The result object may be a variable, an object created by new-expression, a temporary created by temporary materialization, or a member thereof;
---
求值符合下列之一的表达式：
- 计算某个运算符的操作数的值（这种纯右值没有结果对象）比如 x+5
- 初始化某个 obj/位域（这种 prvalue 被认为拥有一个 result-object。唯一的例外就是 decltype。所有 class 和 array prvalues 都拥有 result-object，即便它们被丢弃了）这个 result-object 也许是个 一个变量/一个由new创建的obj/一个由“临时量实质化”生成的临时量/或是它的一个成员
# ---------------- :



# =============================================== #
#                 xvalue - 亡值 (expiring)
an xvalue is a glvalue that denotes an object or bit-field whose resources can be reused;
---
代表其资源能够被重新使用的 obj/位域 的 广义左值（glvalue）
# --------- :

- 返回类型是 T&& 的函数调用/操作符重载。 比如 std::move(v)

- a[n]; 内建下标运算符。 它表示的值是 数组右值

- a.m; 一个类成员表达式。
    此时 a 是 &&
    且 m 必须是个 普通的成员变量（不是 static，也不是另一个变量的引用）
    这样，m 就会跟随 a，一起变成 将亡值

- a.*mp; 同上，此时 mp 是 类成员变量 指针
    当对这个指针解引用后，获得的值，类似上一条中的 m，也是一个将亡值

- a ? b : c; 
    某些情况下的 三目运算符 返回值

- 在临时量实质化后，任何指代临时对象的表达式

# --------- :







# =============================================== #
#                 lvalue - 左值
An lvalue is a glvalue that is not an xvalue.
---
不是 亡值（xvalue） 的 广义左值（glvalue）
# ---------------- :





# =============================================== #
#                 rvalue - 右值
An rvalue is a prvalue or an xvalue.
---
纯右值（prvalue） 或者 亡值（xvalue）
# ---------------- :








# =============================================== #
#            Temporary materialization  [C++17]
#            “临时量实质化” （隐式类型转换）
# ----------------------------------------------- #
任何一个 完整类型T 的 prvalue, 可以被转换为 T 的 xvalue
即：纯右值 可以被转换为 将亡值

这个转换，从 prvalue 中，初始化了一个 T类型的 临时对象。

如果是 T 是 class，或者 class数组，T必须拥有 可访问的，非delete 的 析构函数
---
# Struct S { int m; };
# int k = S().m;
在这个例子中，在 C++17 中， 类成员访问操作，需要一个 glvalue 作为它的对象。
所以，S() 这个 prvalue/纯右值，将会隐式地转换为一个 将亡值。

# --- 在以下情况下，会发生 “临时量实质化”: --- 
- when binding a reference to a prvalue;
    绑定引用到纯右值时

- when performing a member access on a class prvalue;
    在类纯右值上进行成员访问时

- when performing an array-to-pointer conversion (see above) or subscripting on an array prvalue;
    进行数组到指针转换（见上文）或在数组纯右值上使用下标时

- when initializing an object of type std::initializer_list<T> from a braced-init-list;
    以花括号初始化器列表初始化 std::initializer_list<T> 类型的对象时

- when typeid is applied to a prvalue (this is part of an unevaluated expression);
    对纯右值应用 typeid 时（这是不求值表达式的一部分）

- when sizeof is applied to a prvalue (this is part of an unevaluated expression);
    对纯右值应用 sizeof 时（这是不求值表达式的一部分）

- when a prvalue appears as a discarded-value expression.
    纯右值作为弃值表达式时

# Note that temporary materialization does not occur when initializing an object from a prvalue of the same type (by direct-initialization or copy-initialization): such object is initialized directly from the initializer. This ensures "guaranteed copy elision".
---
当 通过 直接初始化/复制初始化，从 prvalue 创建一个 对象时，“临时量实质化” 并不会发生。
这个新的 对象，会从 初始化器中，直接被初始化
这确保了 **|-Guaranteed_Copy_Elision/受保证的复制消除-|** 一定会被执行



# =============================================== #
#          左值引用 / 右值引用
# ----------------------------------------------- #
当作为 函数参数时：
- 若参数为 左值引用，接受: lvalue
- 若参数为 右值引用，接受: xvalue, prvalue 






# =============================================== #
#                万能引用
# ----------------------------------------------- #
在能出发 函数参数 deduc 机制时，使用如下格式，会让参数变成 万能引用

# template<typename T>
# void f( T&& param );

# int x;
# f(10);  // invoke f on rvalue
# f(x);   // invoke f on lvalue

在这个示例中，f(x); 调用时，T将被推导为 int&
函数展开为：
    void f( int& && param_ );
注意，此时，T 和 后面的 && 是独立的。
然后就会引发 **引用折叠**

















