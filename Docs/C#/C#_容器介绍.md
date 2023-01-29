# ====================================================== #
#      C# 各种容器 介绍
# ====================================================== #

c# 的容器数量很多, 接口类的数量也很多, 本文件做一个简单的 对照整理:

主要是能和 c++ 的常见容易 一一对应起来;



# Non-generic collections shouldn't be used
https://github.com/dotnet/platform-compat/blob/master/docs/DE0006.md


# C# 泛型容器
https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?redirectedfrom=MSDN&view=net-6.0



# ------------------------------- #
   数组:
#  c#:      Array
# ------------------------------- #
提供了各种 static 方法, 使用起来很方便
感觉比 c++ 的数组好用

# 自定义 数组内初始值
   int[] ary = new int[9];
   Array.Fill( ary, -1 );



# ------------------------------- #
   c++:     Vector<>
#  c#:      List<>
# ------------------------------- #
非常相似;




# ------------------------------- #
   键值对:
#  c#:      KeyValuePair<K,V>
# ------------------------------- #



# ------------------------------- #
   c++:     unordered_set<K>
#  c#:      HashSet<K>
# ------------------------------- #
始于 .NET Framework 4.6;

是个 set 容器, 元素不重复, 
是个 hash 容器, 元素无排序规则;


# ------------------------------- #
   c++:     set<K>
#  c#:      SortedSet<K>
# ------------------------------- #


# ------------------------------- #
   c++:     map<K,V>
#  c#:      SortedDictionary<K,V>
#  c#:      SortedList<K,V>          -- be implemented as an array of key/value pairs, sorted by the key
# ------------------------------- #
元素按照 K 升序排序;
本质是一颗 二叉搜索树; O(log n) 
它和 SortedList<> 很像;

    public class SortedDictionary<TKey, TValue> : 
        ICollection<KeyValuePair<TKey, TValue>>, 
        IEnumerable<KeyValuePair<TKey, TValue>>, 
        IEnumerable, 
        IDictionary<TKey, TValue>, 
        IReadOnlyCollection<KeyValuePair<TKey, TValue>>, 
        IReadOnlyDictionary<TKey, TValue>, 
        ICollection, 
        IDictionary

# 排序:
The SortedDictionary class is assigned a IComparer<T> when it is constructed, and this cannot be changed after the fact.
默认使用 Comparer<T>.Default;

https://stackoverflow.com/questions/931891/reverse-sorted-dictionary-in-net


# 两容器的检索效率都是   O(log n)
   
# 区别在于 内存占用, insert 和 remove 的耗时:

-- SortedList 占用内存更少;

-- 若想 insert,remove 任意数据(非排序数据), SortedDictionary 更快;
   SortedDictionary 耗时 O(log n)
   SortedList       耗时 O(n)

-- 若从一份已经排序好的数据里 一次性初始化一个容器, SortedList 更快;

-- 若想使用 idx 来直接访问 keys 或 vals, 则 SortedList 更快; 因为它体内的 keys 和 vals 本身就是一个数组...
   比如:
      string v = mySortedList.Values[3];



# 从上可知, SortedList 真的是一个 数组, SortedDictionary 真的是一个 map...





# ------------------------------- #
   c++:     unordered_map<K,V>
#  c#:      Dictionary<K,V>
# ------------------------------- #
元素彻底无序的, 用 foreach 访问时不会类似 c++ 容器那样至少有点顺序 (如果我没记错的话)

designed for high performance searches;

    public class Dictionary<TKey, TValue> : 
        ICollection<KeyValuePair<TKey, TValue>>, 
        IEnumerable<KeyValuePair<TKey, TValue>>, 
        IEnumerable, 
        IDictionary<TKey, TValue>, 
        IReadOnlyCollection<KeyValuePair<TKey, TValue>>, 
        IReadOnlyDictionary<TKey, TValue>, 
        ICollection, 
        IDictionary, 
        IDeserializationCallback, 
        ISerializable
    


# ------------------------------- #
#  c#:      ILookup<TKey,TElement>
# ------------------------------- #
System.Linq 的



# ------------------------------- #
   c++:     unordered_multimap<K,V>
#  c#:      Dictionary<K, List<V>>
#  c#:      ILookup<TKey,TElement>
#  c#:      Lookup<TKey,TElement>
# ------------------------------- #

# ---------------------:
# Dictionary<K, List<V>>
   说白了就是手动搭一个, 


# ---------:
# ILookup<>:
    int[][] nums= new int[][]{
        new int[]{ 1,1 },
        new int[]{ 5,1 },
        new int[]{ 2,1 },
        new int[]{ 5,2 },
    };

    ILookup<int, int> umap = nums.ToLookup(
        p => p[0],
        p => p[1]
    );
    ----

这样就构建了一个 hash 版的 multimap;

用 foreach 遍历 umap 得到元素 e, 类型为: IGrouping<int,int>
访问    e.key   可得到 key;
直接遍历 e 本体  可得到所有 values;

# -1- umap 中元素的排序是无序的, 
    用 foreach 访问得到的顺序也是无序的 (元素数量较少时, 和插入元素的次序一致)

# -2- 单个元素的 values 内的排序也是无序的;

# -3- 这个容器是 immutable (固定不变的), 一旦建成不能 添加 / 删除 元素, 不能改写 key...
#      感觉有点残废...




# ------------------------------- #
   c++:     multimap<K,V>
#  c#:      SortedDictionary<K, List<V>>
# ------------------------------- #
      说白了就是手动搭一个, 





# ------------------------------- #
   stack
#  c#:      Stack<T>
# ------------------------------- #



# ------------------------------- #
   c++:     queue<T>
#  c#:      Queue<T>
# ------------------------------- #




# ------------------------------- #
   c++:     deque<K,V>
#  c#:      LinkedList<T>
# ------------------------------- #



# ------------------------------- #
   大顶堆, 小顶堆
   最大堆,最小堆:
#  c#:      PriorityQueue<TElement,TPriority>
# ------------------------------- #
Implements an array-backed, quaternary min-heap.

.net 6,7 以上, 貌似现在的 unity 不支持 ?



# ============================================ #
#               反向迭代
# ============================================ #
使用 linq 的 Reverse() 扩展方法;

   foreach( var e in cap.Reverse() )
   {
      Debug.Log( e.Key + ", " + e.Value );
   }


# 经 tpr 实测, 支持的容器有:
   Dictionary<>
   SortedDictionary<>
   Array                -- 不是 Array 自带的那个函数
   SortedList<>
   HashSet<>
   SortedSet<>          -- 自带的函数
   

# 不支持的容器:
   List<>               -- 手动用 idx 倒叙遍历吧

