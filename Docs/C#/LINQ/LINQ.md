# ================================================================ #
#              LINQ   
# ================================================================ #


# c# 同时提供 "Query syntax" 和 "Method syntax", 两者在性能上是等价的
    如果你使用 "Query syntax", 编译器会自动将其转换为 "Method syntax";

# "Query syntax" 和 "Method syntax" 可在同一次查询中 混合使用;
    反正就是编译器都看得懂



# ---------------------------------------------- #
#      什么是 join 语句
# ---------------------------------------------- #

# ==:
    class A
    {
        int     age;
        string  name;
    }

    class B
    {
        int     age;
        string  parent;
    }

    A[] aas = new A[]{...};
    B[] bbs = new B[]{...};

    var query = 
        from a in aas
        join b in bbs on b.age equals a.age 
        where b.parent == "Dog"
        select a.name;
# --
代码中的两种类型: A, B 各不相同, 但它们有个共同点, 都有 int age;

join 语句可以 "合并这两个 array", 它将生产一个新 array, 其中的元素
拥有一个新的类型, 这个新类型包含 A,B 的所有 元素成员:
{
    int     age;
    string  name;
    string  parent;
}

而且, 这句 join 还做了次筛选, 具体步骤为:
它从 aas 中取出一个元素 a, 拿着 a.age, 去 bbs 中和每个 b 逐个对比, 只要 b.age == a.age 
就算是找到一个, 然后就会建立一个 新元素(新类型的)
本质上是个 双层循环 的查找;

最后, join 语句生成的新的 array, 还要接受下方的 where 语句的筛选...




















