# ================================================================//
#           The Standard Query Operators  
# ================================================================//

The standard query operators are the methods that form the LINQ pattern. 
Most of these methods operate on sequences;

# sequences
    一个对象, 继承了 IEnumerable<T> 或 IQueryable<T>;

The standard query operators provide query capabilities including:
filtering, projection, aggregation, sorting and more.
过滤, 投影, 聚合, 排序...

除此之外, 还有少部分 函数, 能处理 不支持 IEnumerable<T> 或 IQueryable<T> 的对象


# 执行时间:
# -1- 返回单个值的, 立即执行
# -2- 返回 enumerable 对象的, 延迟到这个对象被访问时 才执行
    即: 当前语句只是一种 "声明了某种行为", 并不表示现在就要执行


# ----------------------------------- #
# IEnumerable 和 IQueryable 的区别 ?
IQueryable 是负责生成SQL语句的，但并不马上执行；
而 IEnumerable 是对任意类型的集合都能操作的，不限于是数据库还是一般的Array还是List。





# ============================================================== #
# 首次排序:
#       OrderBy             升序
#       OrderByDescending   降序
# -------------------------------------------------------------- #
# 为延迟执行
    直到返回值被 foreach 遍历, 或直接调用其 GetEnumerator(),
    此排序过程才被执行;

仅以 OrderBy 举例:
# -1- ----------------------------- #
OrderBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)

# 谓词: Func<TSource,TKey> keySelector
传入一个 查询元素实例, 返回一个 key值, 

# == array:
    int[] ints = {1,2,3,4,5};
    var q = ints.OrderBy( n=>n );

# == Dictional:
    Dictionary<int,string> map = new Dictionary<int,string>{
        {4,"aa"},
        {2,"bbb"}
    };
    var q = map.OrderBy( p=>p.Key );


# -2- ----------------------------- #
OrderBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)

新增了: IComparer<TKey> comparer
Defines a method that a type implements to compare two objects.
用来定义类型 TKey 的比较操作;

略...

# -------- #
# OrderBy 的返回值 还可调用 OrderBy/OrderByDescending
    此时, 后面定义的 排序方式, 将覆盖前面的排序方式
 
# OrderBy 的返回值 还可调用 ThenBy/ThenByDescending
    此时, 后面定义的 额外排序方式, 将在前面的排序基础上进行



# ============================================================== #
# 二次排序:
#       ThenBy             升序
#       ThenByDescending   降序
# -------------------------------------------------------------- #
在 OrderBy/OrderByDescending 后跟随的二次排序
可跟随很多个;

ThenBy<TSource,TKey>(IOrderedEnumerable<TSource>, Func<TSource,TKey>)
ThenBy<TSource,TKey>(IOrderedEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)

用法和 OrderBy 类似;

# ==:
    string[] ss = { 
        "k", "a", "rr", "bb"
    };
    var q = ss.OrderBy(e=>e.Length).ThenBy(e=>e);
# --
最终得到: { "a", "k", "bb", "rr" }

意为: 整体按照 字节数排序, 在此基础上, 相同字节的元素中, 按字母排序



# ============================================================== #
#       Reverse  反转
# -------------------------------------------------------------- #
# 为延迟执行...

Reverse<TSource> (this IEnumerable<TSource> source);

# ==:
    list.Reverse();
# --



# ============================================================== #
#       Distinct    去除序列中的重复项
#       DistinctBy
# -------------------------------------------------------------- #
# 为延迟执行...

去除序列中的重复项, 返回修改过的序列;
使用 default equality comparer: EqualityComparer<T>.Default 来比较,
因此, 被处理的元素类型, 必须继承 IEquatable<T> 接口'

Distinct<TSource> (this IEnumerable<TSource> source);
还有 comparer 版, 和 By 版, 皆略... 
# ==:
    list.Distinct();
# --



# ============================================================== #
#       Except    从序列 1 中,减去序列 2 中的元素
#       ExceptBy
# -------------------------------------------------------------- #
# 为延迟执行...

使用 default equality comparer: EqualityComparer<T>.Default 来比较,
因此, 被处理的元素类型, 必须继承 IEquatable<T> 接口'


从序列 first 中, 减去序列 second 中的元素, 返回这个序列;


Except<TSource> (this IEnumerable<TSource> first, 
                IEnumerable<TSource> second);
还有 comparer 版, 和 By 版, 皆略...  


# ============================================================== #
#       Intersect       返回两序列的 交集 (公共部分)
#       IntersectBy
#       Union           返回两序列的 并集 ( 全部, 且元素不重复 )
#       UnionBy
#       Concat          连接两个序列
# -------------------------------------------------------------- #
# 为延迟执行...

# ------------ Intersect -------------- #
Intersect<TSource> (this IEnumerable<TSource> first, IEnumerable<TSource> second);
还有 comparer 版, 和 By 版, 皆略...


# ------------ Union -------------- #
Union<TSource> (this IEnumerable<TSource> first, IEnumerable<TSource> second);
还有 comparer 版, 和 By 版, 皆略...

功能上和 Concat 是不同的;

# ==:
    int[] list1 = { 1, 1, 2 };
    int[] list2 = { 2, 3 };
    var q = list1.Union( list2 );
# --
最后得到序列: { 1,2,3 }

可以看到, 两序列中元素不光被收集起来, 还去重了


# ------------ Concat -------------- #
Concat<TSource> (
    this IEnumerable<TSource>       first, 
    Generic.IEnumerable<TSource>    second
);

连接两个序列



# ============================================================== #
#       Where   用谓词筛选序列中的每个元素, 保留符合条件的
# -------------------------------------------------------------- #
# 为延迟执行...

Where<TSource> (this IEnumerable<TSource> source, Func<TSource,bool> predicate);

# ==:
    string[] strs = { "a", "aa", "aaa", "aaaaa" };
    var q = strs.Where( e => e.Length<3 );
# --


# -------------------------- #
Where<TSource> (this IEnumerable<TSource> source, Func<TSource,int,bool> predicate);

此版的谓词有两个参数: (1)元素, (2)元素的idx (0开始)

# ==:
    int[] nums = { 0, 30, 20, 15, 90, 85, 40, 75 };
    var q = nums.Where( (number,index) => number<=index*10 );
# --



# ============================================================== #
#       All         序列中全部元素, 都要满足条件, 才返回 true
#       Any         序列中只要有一个元素满足条件, 就返回 true
#       Contain     序列若含有某个元素, 即返回 true
# -------------------------------------------------------------- #

# -------------------- All --------------------- #
bool All<TSource> (this IEnumerable<TSource> source, Func<TSource,bool> predicate);

ret:
    序列全元素满足, 或者序列为空, 返回 true, 否则 false;

一旦某元素为 false, 整个遍历就会终止;


# -------------------- Any --------------------- #
bool Any<TSource> (this IEnumerable<TSource> source);

ret:
    只要序列包含元素, 就返回 true;


bool Any<TSource> (this IEnumerable<TSource> source, Func<TSource,bool> predicate);

这一版需要满足 谓词规定的条件;


# -------------------- Contain --------------------- #
bool Contains<TSource> (this IEnumerable<TSource> source, TSource value);
还有一个 comparer 版, 略...

若目标类型 TSource 实现了接口 ICollection<T>, 那么此类型实现的 Contains() 方法将被调用,
来计算出 本函数的结果, 
若没实现接口 ICollection<T>, 本函数将: 
determines whether source contains the specified element.

一旦找到符合的, 本函数即结束遍历;


# ============================================================== #
# 投影操作:
#       Select      
#       SelectMany
#       Zip
# -------------------------------------------------------------- #
# 为延迟执行...

# -------------------- Select  --------------------- #
Select<TSource,TResult> (this IEnumerable<TSource> source, Func<TSource,TResult> selector);
Select<TSource,TResult> (this IEnumerable<TSource> source, Func<TSource,int,TResult> selector);
版本2 多出来的 谓词参数是 元素的idx (0开始)

返回一个新序列, 此序列的每个元素, 是用原始序列对应idx元素 的部分信息 重组出来的;

# ==:
    int[] nums = {1,2,3};
    var q1 = nums.Select( x => x*x );
# --
返回: {1,4,9}

# ==:
    string[] strs = { "abs", "ddd", "kk", "mkok" } 
    var q2 = strs.Select(  
        (e,idx) =>
            new { idx, str = e.Substring(0, index) }
    );
# --
使用匿名类型来 规划 返回序列元素的 类型;


# -------------------- SelectMany --------------------- #
SelectMany<TSource,TCollection,TResult> (
    this IEnumerable<TSource>                   source, 
    Func<TSource,int,IEnumerable<TCollection>>  collectionSelector, 
    Func<TSource,TCollection,TResult>           resultSelector
);

# 类型: TSource         原始序列元素 的类型
# 类型: TCollection     中间获得的 "可遍历对象" 的类型
# 类型: TResult         最终返回的序列, 每个元素的类型

# 谓词: collectionSelector: 处理原始序列的每个元素(及其idx), 生成 "可遍历对象" 的实例
# 谓词: resultSelector :    处理每个 "中间态类型实例", 生成最终返回 类型实例

将原始序列中的每个元素, "投影"为一个 继承了 IEnumerable<T> 的对象 (一个"可遍历对象"),
然后将返回的 层次化的序列 展平, 最后再调用 谓词 resultSelector, 作用于展平后的序列中的每个元素,
在整个过程中, 会用到元素的idx;



SelectMany<TSource,TCollection,TResult> (
    this IEnumerable<TSource>               source, 
    Func<TSource,IEnumerable<TCollection>>  collectionSelector, 
    Func<TSource,TCollection,TResult>       resultSelector
);

# 区别: 谓词 collectionSelector 的参数少了一个 idx

# ==:
    class A{
        public string parent { get; set; }
        public List<string> childs { get; set; }
    }

    A[] ents = {
        new A { parent="Higa",         childs = new List<string> { "Scruffy", "Sam" } },
        new A { parent="Ashkenazi",    childs = new List<string> { "Walker", "Sugar" } },
        new A { parent="Price",        childs = new List<string> { "Scratches", "Diesel" } }
    };

    var query = ents.SelectMany(
        p => p.childs, 
        (parent, child) => new { parent, child }
    );
# --


SelectMany<TSource,TResult> (
        this IEnumerable<TSource> source, 
        Func<TSource,IEnumerable<TResult>> selector
);
# 区别: 展平后不需要再对每个元素执行一遍 谓词函数 resultSelector 了;


SelectMany<TSource,TResult> (
        this IEnumerable<TSource> source, 
        Func<TSource,int,IEnumerable<TResult>> selector);
# 区别: 谓词多了个参数: idx



# -------------------- Zip  --------------------- #
# 为延迟执行...
Zip<TFirst,TSecond,TResult> (
    this IEnumerable<TFirst>        first, 
    IEnumerable<TSecond>            second, 
    Func<TFirst,TSecond,TResult>    resultSelector
);

使用谓词将两个序列的 元素一一对应, 整合为一个新的元素, 存入新的序列并返回;

# ==:
    int[]       nums    = { 1, 2, 3, 4, 5, 6, 7 };
    string[]    words   = { "one", "two", "three" };

    var meg = nums.Zip(
        words, 
        (first,second) => first + "-" + second
    );
# --
得到序列: { "1-one", "2-two", "3-three" }

# 可以发现, 若两序列元素个数不相等, 那就按短的为准, 长序列多出来的部分直接不处理;


Zip<TFirst,TSecond> (
    this IEnumerable<TFirst>    first, 
    IEnumerable<TSecond>        second
);

# 区别: 只是简单 merge, 不需要做处理了

返回类型是: IEnumerable<ValueTuple<TFirst,TSecond>>




# ============================================================== #
# 分割数据:
#       Skip
#       SkipWhile
#       Take
#       TakeWhile
#       Chunk
# -------------------------------------------------------------- #


# -------------------- Skip  --------------------- #
# 为延迟执行...
Skip<TSource> (this IEnumerable<TSource> source, int count);

跳过一段数据, 返回后半段组成的 序列;

若 count 大于 原始序列元素个数, 返回一个空的 IEnumerable<T> 实例
若 count <= 0, 返回整个原始序列;


# -------------------- SkipWhile --------------------- #
# 为延迟执行...
SkipWhile<TSource> (
    this IEnumerable<TSource>   source, 
    Func<TSource,int,bool>      predicate
);

SkipWhile<TSource> (
    this IEnumerable<TSource>   source, 
    Func<TSource,bool>          predicate
);

遍历每个元素, 若谓词计算得 true, 就抛弃这个元素, 返回剩下元素组成得 序列;

若所有元素都被抛弃, 返回一个空的 IEnumerable<T> 实例


# -------------------- Take --------------------- #
# 为延迟执行...
Take<TSource> (this IEnumerable<TSource> source, int count);

从头部开始数 count 个元素, 返回由它们组成的序列;

若 count 很大, 所有元素都会被返回
若 count <= 0, 原始序列不会被遍历, 返回一个空的 IEnumerable<T> 实例


# -------------------- TakeWhile --------------------- #
# 为延迟执行...
TakeWhile<TSource> (
    this IEnumerable<TSource> source, 
    Func<TSource,int,bool> predicate
);

TakeWhile<TSource> (
    this IEnumerable<TSource> source, 
    Func<TSource,bool> predicate
);

遍历每个元素, 若谓词计算得 true, 就保留这个元素, 将这些元素组成一个序列, 并返回它;



# -------------------- Chunk --------------------- #
Chunk<TSource> (this IEnumerable<TSource> source, int size);

参数 size 规定了一个 chunk 的最大值, 将原始序列拆分为很多个 chunk;
最后一个 chunk 的原始数据可能不足 size 个;

# 返回类型: IEnumerable<TSource[]
是个数组



# ============================================================== #
#       Join
#       GroupJoin
# -------------------------------------------------------------- #

# -------------------- Join --------------------- #
# 为延迟执行...
Join<TOuter,TInner,TKey,TResult> (
    this IEnumerable<TOuter>        outer, 
    IEnumerable<TInner>             inner, 
    Func<TOuter,TKey>               outerKeySelector, 
    Func<TInner,TKey>               innerKeySelector, 
    Func<TOuter,TInner,TResult>     resultSelector, 
    IEqualityComparer<TKey>?        comparer
);

Join<TOuter,TInner,TKey,TResult> (
    this IEnumerable<TOuter>        outer, 
    IEnumerable<TInner>             inner, 
    Func<TOuter,TKey>               outerKeySelector, 
    Func<TInner,TKey>               innerKeySelector, 
    Func<TOuter,TInner,TResult>     resultSelector
);

根据匹配键 关联两个序列的元素, 使用 comparer 或 Default 来比较两个元素;

...未完...


# -------------------- GroupJoin --------------------- #
# 为延迟执行...
GroupJoin<TOuter,TInner,TKey,TResult> (
    this IEnumerable<TOuter>                    outer, 
    IEnumerable<TInner>                         inner, 
    Func<TOuter,TKey>                           outerKeySelector, 
    Func<TInner,TKey>                           innerKeySelector, 
    Func<TOuter,IEnumerable<TInner>,TResult>    resultSelector
);

GroupJoin<TOuter,TInner,TKey,TResult> (
    this IEnumerable<TOuter>                    outer, 
    IEnumerable<TInner>                         inner, 
    Func<TOuter,TKey>                           outerKeySelector, 
    Func<TInner,TKey>                           innerKeySelector, 
    Func<TOuter,IEnumerable<TInner>,TResult>    resultSelector, 
    IEqualityComparer<TKey>?                    comparer
);

根据匹配键 关联两个序列的元素, 并产生 层次化的结果序列

...未完...


# ============================================================== #
#       GroupBy
#       ToLookup
# -------------------------------------------------------------- #

# -------------------- GroupBy --------------------- #
IEnumerable<TResult>
GroupBy<TSource,TKey,TElement,TResult> (
    this IEnumerable<TSource>                   source, 
    Func<TSource,TKey>                          keySelector, 
    Func<TSource,TElement>                      elementSelector, 
    Func<TKey,IEnumerable<TElement>,TResult>    resultSelector, 
    IEqualityComparer<TKey>?                    comparer
);


IEnumerable<TResult> 
GroupBy<TSource,TKey,TElement,TResult> (
    this IEnumerable<TSource>                   source, 
    Func<TSource,TKey>                          keySelector, 
    Func<TSource,TElement>                      elementSelector, 
    Func<TKey,IEnumerable<TElement>,TResult>    resultSelector
);


IEnumerable<IGrouping<TKey,TElement>> 
GroupBy<TSource,TKey,TElement> (
    this IEnumerable<TSource>       source, 
    Func<TSource,TKey>              keySelector, 
    Func<TSource,TElement>          elementSelector
);


IEnumerable<IGrouping<TKey,TElement>> 
GroupBy<TSource,TKey,TElement> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    Func<TSource,TElement>      elementSelector, 
    IEqualityComparer<TKey>?    comparer
);


IEnumerable<TResult> 
GroupBy<TSource,TKey,TResult> (
    this IEnumerable<TSource>               source, 
    Func<TSource,TKey>                      keySelector, 
    Func<TKey,IEnumerable<TSource>,TResult> resultSelector, 
    IEqualityComparer<TKey>?                comparer
);


IEnumerable<TResult> 
GroupBy<TSource,TKey,TResult> (
    this IEnumerable<TSource>               source, 
    Func<TSource,TKey>                      keySelector, 
    Func<TKey,IEnumerable<TSource>,TResult> resultSelector
);


IEnumerable<IGrouping<TKey,TSource>> 
GroupBy<TSource,TKey> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector
);


IEnumerable<IGrouping<TKey,TSource>> 
GroupBy<TSource,TKey> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    IEqualityComparer<TKey>?    comparer
);

...未完...

# -------------------- ToLookup --------------------- #

ILookup<TKey,TElement> 
ToLookup<TSource,TKey,TElement> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    Func<TSource,TElement>      elementSelector
);

ILookup<TKey,TElement> 
ToLookup<TSource,TKey,TElement> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    Func<TSource,TElement>      elementSelector, 
    IEqualityComparer<TKey>?    comparer
);


ILookup<TKey,TSource> 
ToLookup<TSource,TKey> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector
);


ILookup<TKey,TSource> 
ToLookup<TSource,TKey> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    IEqualityComparer<TKey>?    comparer
);


# ============================================================== #
# 生成操作:
#       DefaultIfEmpty
#       Empty
#       Range
#       Repeat
# -------------------------------------------------------------- #


# -------------------- DefaultIfEmpty --------------------- #
# 为延迟执行...
IEnumerable<TSource> 
DefaultIfEmpty<TSource> (
    this IEnumerable<TSource>   source, 
    TSource                     defaultValue
);

IEnumerable<TSource?> 
DefaultIfEmpty<TSource> (
    this IEnumerable<TSource> source
);

如果目标序列是空的, 就返回一个 序列,里面只有一个元素, 这个元素的值要么使用 defaultValue 参数
设置的, 要么使用类型的 默认值;

# ==:
    List<int> nums = new List<int>();

    foreach( var e in nums.DefaultIfEmpty(77) ){
        ...
    }
# --
在此例中, 就算序列是空的, 也会遍历出一个 "默认值" 出来;

# This method can be used to produce a left outer join when 
# it is combined with the GroupJoin) method.



# -------------------- Empty --------------------- #
IEnumerable<TResult> 
Empty<TResult> ();

返回一个空的 IEnumerable<TResult> 实例, 如果用 foreach 遍历这个实例, 啥元素也访问不到;

此函数常用来作为用户定义的 "空的可遍历对象", 传递给某个 库函数;

It can also be used to generate a neutral element for methods such as Union. 
还可用在 Union() 函数的参数中;


# -------------------- Range --------------------- #
# 为延迟执行...
IEnumerable<int> Range (int start, int count);

生成一个 int类型的 序列, 以 start 为开始值, 往后的元素依次累加, 一共 count 个;


# -------------------- Repeat --------------------- #
# 为延迟执行...
IEnumerable<TResult> 
Repeat<TResult> (TResult element, int count);

生成一个序列, 里面是 count 个元素: element;




# ============================================================== #
#       SequenceEqual
# -------------------------------------------------------------- #

判断两个序列 是否相等;
若两序列 元素个数相等, 且每个对应的元素也相等(使用指定的 判断方式)
则这两个序列 相等, 此时返回 true

若元素类型是自定义的, 这个类型需要继承 IEquatable<T>, 以便支持 元素之间的判断;

bool 
SequenceEqual<TSource> (
    this IEnumerable<TSource> first, 
    IEnumerable<TSource> second
);


bool 
SequenceEqual<TSource> (
    this IEnumerable<TSource>       first, 
    IEnumerable<TSource>            second, 
    IEqualityComparer<TSource>?     comparer
);


# ============================================================== #
# 元素操作:
#       ElementAt
#       ElementAtOrDefault
#       First
#       FirstOrDefault
#       Last
#       LastOrDefault
#       Single
#       SingleOrDefault
# -------------------------------------------------------------- #


# -------------------- ElementAt --------------------- #
TSource 
ElementAt<TSource> (
    this IEnumerable<TSource>   source, 
    int                         index
);

返回序列中指定 idx 位置的元素; (idx 以0开始)

若类型 TSource 实现了 IList<T>, 则返回指定idx 处的元素
否则, 返回 the specified element. (没看懂)

若 idx 越界, 返回异常;

# -------------------- ElementAtOrDefault --------------------- #
TSource? 
ElementAtOrDefault<TSource> (
    this IEnumerable<TSource>   source, 
    int                         index
);

若 idx 越界, 返回 default(TSource);

引用类型 和 可空类型的 default 值为 null;


# -------------------- First --------------------- #
TSource 
First<TSource> (
    this Generic.IEnumerable<TSource> source
);

返回序列的 第一个元素;

TSource 
First<TSource> (
    this IEnumerable<TSource>   source, 
    Func<TSource,bool>          predicate
);

有谓词版: 返回 符合谓词test 的 第一个元素; (谓词返回 true)

若所有元素都不符合test, 爆出异常 InvalidOperationException;
此时可改用: FirstOrDefault()

若序列 或 谓词 为null, 爆出异常 ArgumentNullException;

# -------------------- FirstOrDefault --------------------- #
TSource? 
FirstOrDefault<TSource> (
    this IEnumerable<TSource> source
);

TSource? 
FirstOrDefault<TSource> (
    this IEnumerable<TSource>   source, 
    Func<TSource,bool>          predicate
);      

若找不到合适的 第一个元素, 则返回 default(TSource);


# -------------------- Last --------------------- #
# -------------------- LastOrDefault --------------------- #
TSource 
Last<TSource> (
    this IEnumerable<TSource> source
);

TSource Last<TSource> (
    this IEnumerable<TSource>   source, 
    Func<TSource,bool>          predicate
);


TSource? 
LastOrDefault<TSource> (
    this IEnumerable<TSource> source
);

TSource? 
LastOrDefault<TSource> (
    this IEnumerable<TSource>   source, 
    Func<TSource,bool>           predicate
);

和 First 系列对应的;


# -------------------- Single --------------------- #
TSource 
Single<TSource> (
    this IEnumerable<TSource> source
);

返回序列中唯一一个元素, 如果序列为空,或元素多于一个, 爆出异常

TSource 
Single<TSource> (
    this IEnumerable<TSource>   source, 
    Func<TSource,bool>          predicate
);

返回序列中和谓词匹配的 单独一个元素, 如果没有元素匹配, 或多于一个匹配, 爆出异常;
(只要匹配的只有一个就行, 元素有很多个是没问题的)


# -------------------- SingleOrDefault --------------------- #
TSource? 
SingleOrDefault<TSource> (
    this IEnumerable<TSource> source
);

TSource? 
SingleOrDefault<TSource> (
    this IEnumerable<TSource>   source, 
    Func<TSource,bool>          predicate
);

不符合时不会爆出异常, 而是返回 default(TSource);




# ============================================================== #
# 转换数据类型
#       AsEnumerable
#       AsQueryable
#       Cast
#       OfType
#       ToArray
#       ToDictionary
#       ToList
#       ToLookup
# -------------------------------------------------------------- #



# -------------------- AsEnumerable --------------------- #
IEnumerable<TSource> 
AsEnumerable<TSource> (
    this IEnumerable<TSource> source
);

在编译时, 将一个 "实现了 IEnumerable<T> 的类型", 转换为 IEnumerable<T> 本身;

比如, 可用来: 不使用此类型自定义的一些方法, 而是直接使用 IEnumerable<T> 的原版方法;


# -------------------- AsQueryable --------------------- #
暂略...


# -------------------- Cast --------------------- #
# 为延迟执行...
IEnumerable<TResult> 
Cast<TResult> (
    this IEnumerable source
);

将一个继承了 IEnumerable 的元素, 转换为 指定类型 IEnumerable<TResult>;

比如, 可将 ArrayList 转换为 IEnumerable<string> 之类的



# -------------------- OfType --------------------- #
# 为延迟执行...
IEnumerable<TResult>
OfType<TResult> (this IEnumerable source);

原始序列中, 只有能被转换为目标类型的 元素, 才会被保留; 返回修改过的序列

# 此函数是少数可作用于 the collection that hash non-parameterized type,
# 比如 ArrayList;
# 反过来, 本函数不用用于 继承于 IEnumerable<T> 的容器


# -------------------- ToArray --------------------- #
# 为立即执行
TSource[] 
ToArray<TSource> (
    this IEnumerable<TSource> source
);

从 IEnumerable<TSource> 序列中, 生成一个 array 并返回;


# -------------------- ToDictionary --------------------- #
Dictionary<TKey,TElement> 
ToDictionary<TSource,TKey,TElement> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    Func<TSource,TElement>      elementSelector
);


Dictionary<TKey,TElement> 
ToDictionary<TSource,TKey,TElement> (
    this IEnumerable<TSource> source, 
    Func<TSource,TKey> keySelector, 
    Func<TSource,TElement> elementSelector, 
    IEqualityComparer<TKey>? comparer
);

Dictionary<TKey,TSource> 
ToDictionary<TSource,TKey> (
    this IEnumerable<TSource> source, 
    Func<TSource,TKey> keySelector
);

# 这一版中, pair.value 类型为 TSource

Dictionary<TKey,TSource> 
ToDictionary<TSource,TKey> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    IEqualityComparer<TKey>?    comparer
);


# -------------------- ToList --------------------- #
List<TSource> 
ToList<TSource> (
    this IEnumerable<TSource> source
);


# -------------------- ToLookup --------------------- #
ILookup<TKey,TElement> 
ToLookup<TSource,TKey,TElement> (
    this IEnumerable<TSource>       source, 
    Func<TSource,TKey>              keySelector, 
    Func<TSource,TElement>          elementSelector
);

Lookup 容器的 value 也是个容器, 可存储一组元素;

将原始序列的元素 装填进去的时候, 还是原来的类似 ToDictionary 的操作,
但在 Lookup 内部, 如果两次 insert, key值相同, 那么它们的 pair.value 会被放到一个 容器里
(都被一个 key 索引到)



ILookup<TKey,TElement> 
ToLookup<TSource,TKey,TElement> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    Func<TSource,TElement>      elementSelector, 
    IEqualityComparer<TKey>?    comparer
);


ILookup<TKey,TSource> 
ToLookup<TSource,TKey> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector
);

# 此版, pair.value 类型为 TSource;


ILookup<TKey,TSource> 
ToLookup<TSource,TKey> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    IEqualityComparer<TKey>?    comparer
);


# ============================================================== #
# 聚合操作:
#       Aggregate
#       Average
#       Count
#       LongCount
#       Max
#       Min
#       MaxBy
#       MinBy
#       Sum
# -------------------------------------------------------------- #

# -------------------- Aggregate --------------------- #
TResult 
Aggregate<TSource,TAccumulate,TResult> (
    this IEnumerable<TSource>             source, 
    TAccumulate                           seed,          // 用来初始化 accumulator
    Func<TAccumulate,TSource,TAccumulate> func,          // 作用于每个元素的 累加器函数
    Func<TAccumulate,TResult>             resultSelector //将最终累加器值,转换为返回值的函数
);

首先, 用 seed 初始化一个 累加器函数 func, 然后遍历原始序列, 将序列的每个元素传入
累加器函数 中, 每遍历一个元素, func 都会被调用一次, 
这么一圈走完后, 累加器中会留有一个具体的值,
再使用函数 resultSelector 去处理这个 累加器中的值, 最终将处理结果 返回出来;

可以看到, 虽然有一个名为 "累加器" 的东西, 其实他就是一个函数, 还是我们自己定义的

范例:
# ==:
    string[] strs = { "a", "aa", "ccc", "1234567", "kk" };

    string longestName = strs.Aggregate(
        "bb",
        (longest, next) => next.Length > longest.Length ? next : longest,
        fruit => fruit.ToUpper()
    );
# --
最终, longestName = "1234567";

这段代码 先手握 "bb", 然后拿它去对比 原始序列中的每一个元素, 保留 长度最长的那个,
最后对筛选出来的元素, 全部换成 大写字母, 返回;


TAccumulate 
Aggregate<TSource,TAccumulate> (
    this IEnumerable<TSource>               source, 
    TAccumulate                             seed, 
    Func<TAccumulate,TSource,TAccumulate>   func
);


TSource 
Aggregate<TSource> (
    this IEnumerable<TSource>       source, 
    Func<TSource,TSource,TSource>   func
);



# -------------------- Average --------------------- #
float  Average (this IEnumerable<float> source);
float? Average (this IEnumerable<float?> source);
还有很多 变种.....

求序列的平均值



# -------------------- Count --------------------- #
# -------------------- LongCount --------------------- #
int Count<TSource> (this IEnumerable<TSource> source);

统计序列中元素个数

int Count<TSource> (this IEnumerable<TSource> source, Func<TSource,bool> predicate);

统计序列中, 满足谓词的元素的个数

long LongCount<TSource> (this IEnumerable<TSource> source);
long LongCount<TSource> (this IEnumerable<TSource> source, Func<TSource,bool> predicate);


# -------------------- Max --------------------- #
float?      Max (this IEnumerable<float?> source);
decimal     Max (this IEnumerable<decimal> source);
double      Max (this IEnumerable<double> source);
int         Max (this IEnumerable<int> source);
long        Max (this IEnumerable<long> source);
decimal?    Max (this IEnumerable<decimal?> source);
double?     Max (this IEnumerable<double?> source);
int?        Max (this IEnumerable<int?> source);
....还有很多...

返回最大值

# -------------------- Min --------------------- #
返回最小值



# -------------------- MaxBy --------------------- #
TSource? 
MaxBy<TSource,TKey> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector, 
    IComparer<TKey>?            comparer
);

TSource? 
MaxBy<TSource,TKey> (
    this IEnumerable<TSource>   source, 
    Func<TSource,TKey>          keySelector
);

不是直接比较 序列元素, 而是比较一个 key, 这个 key 由 keySelector 函数来提供;

# -------------------- MinBy --------------------- #


# -------------------- Sum --------------------- #
double Sum (this IEnumerable<double> source);

求和

