# ================================================================ #
#       Enumerator  Enumerable
#       IEnumerator IEnumerable
#       Iterator              
# ================================================================ #
推荐看 <<illustrated c# 7 5>> 19 章 英文版;


# ---------------------------------------------- #
#             Enumerable  可枚举类型
# ---------------------------------------------- #
int[], List<string> 就是一种 Enumerable 类型;

它们通常继承接口: IEnumerable, IEnumerable<T>

它们内置一个: GetEnumerator() 方法:
    IEnumerator GetEnumerator();
    IEnumerator<T> GetEnumerator();

它们可以被 foreach 直接遍历;


# ---------------------------------------------- #
#             Enumerator  枚举器
# ---------------------------------------------- #
也是一种类型, 通常继承接口: IEnumerator, IEnumerator<T>

它们可以由 Enumerable 类型的 GetEnumerator() 方法返回得到;

它们必须实现:
    Position;
    Current();
    MoveNext();
    Reset();


# ---------------------------------------------- #
#             Iterator  迭代器
# ---------------------------------------------- #
c# 2.0 之后的新玩具~

手动实现 Enumerator, Enumerable 也太麻烦了, 
Iterator 就是为了简化此工作 而诞生;

# --- Iterator Blocks ---
就是个代码块, 可以长这样:
    {
        yield return "aa";
        yield return "bb";
        yield return "cc";
    }

使用对人友好的语法来实现 "具体的迭代内容", 然后,这个 Iterator Blocks
会被 编译器 翻译为正式的 Enumerator, Enumerable 代码;

# === Iterator 既可以生成 Enumerator,  也可以生成 Enumerable
具体生成哪种, 全靠 返回类型 的定义;



# ---------------------------------------------- #
#      foreach 只检查 GetEnumerator() 方法
# ---------------------------------------------- #
一个实例, 只有携带 GetEnumerator() 方法, foreach 就能遍历它,
至于它是否继承 IEnumerable, IEnumerable<T>, foreach 不关心;





# ---------------------------------------------- #
#      使用 IEnumerator<T> 来遍历容器
# ---------------------------------------------- #


    List<int> myList = new List<int> { 1, 2, 3, 4, 5 };
    IEnumerator<int> enumerator = myList.GetEnumerator();

    while (enumerator.MoveNext())
    {
        int current = enumerator.Current;
        print( "-- " + current);
    }

# 尤其是某些 linq 返回的容器








