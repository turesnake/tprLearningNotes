#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System
{
    public abstract class Array : 
                                    ICollection, 
                                    IEnumerable, 
                                    IList, 
                                    IStructuralComparable, 
                                    IStructuralEquatable, 
                                    ICloneable
    {

        // Gets an object that can be used to synchronize access to the Array.
        // 多线程读写 时使用;
        public object SyncRoot { get; }

        // Gets a 64-bit integer that represents the total number of elements in all the dimensions of the Array.
        public long LongLength { get; }

        // Gets the total number of elements in all the dimensions of the Array.
        public int Length { get; }

        // Gets a value indicating whether access to the Array is synchronized (thread safe).
        public bool IsSynchronized { get; }

        public bool IsReadOnly { get; }

        // Gets a value indicating whether the Array has a fixed size.
        // 对于所有 array 数组 来说, 本值永远为 true;
        // 存在的意义是因为 接口: IList 需要;
        public bool IsFixedSize { get; }

        // 返回 维度值, 一维二维 这种;
        public int Rank { get; }

        public static ReadOnlyCollection<T> AsReadOnly<T>(T[] array);

        /*
            ------------------------------- BinarySearch ---------------------------------------
            调用本函数时, array 必须已经排序好了, 否则返回值不会是你想要的那个;

            返回:
                若找到, 返回目标元素的 idx;
                若没找到, 返回负值:
                    若 目标元素 小于 array 中的某些值,则:
                        the negative number returned is the bitwise complement of the index 
                        of the first element that is larger than value.
                        返回的负数是大于 value 的第一个元素的索引的按位补码;

                    若 目标元素 大于 array 中所有元素, 则:
                        the negative number returned is the bitwise complement of 
                        (the index of the last element plus 1).
                        返回的负数是（最后一个元素的索引加 1）的按位补码。
        */

        // 可指定 元素排序规则
        public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer);
        public static int BinarySearch<T>(T[] array, T value);
        public static int BinarySearch<T>(T[] array, int index, int length, T value);
        public static int BinarySearch(Array array, object value, IComparer comparer);
        public static int BinarySearch(Array array, object value);
        public static int BinarySearch(Array array, int index, int length, object value, IComparer comparer);
        public static int BinarySearch<T>(T[] array, int index, int length, T value, IComparer<T> comparer);
        public static int BinarySearch(Array array, int index, int length, object value);

        /*
            ----------------------------------------------------------------------
        */

        public static void Clear(Array array, int index, int length);

        /*
            将 src 的部分/全部元素 复制给 dst;
            Guarantees that all changes are undone if the copy does not succeed completely.
            万一复制操作没有成功, 所有更改都将撤销;

            Unlike Copy(), ConstrainedCopy() verifies the compatibility of the array types before performing any operation.

            多维数组之前的复制 规则有点复杂, 看文档...

            本函数的所有异常 都可 src, srcidx, dst, dstidx 的类型或边界有关;
        */
        public static void ConstrainedCopy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length);

        // Converts an array of one type to an array of another type.
        public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Converter<TInput, TOutput> converter);
        
        
        public static void Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length);
        public static void Copy(Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length);
        public static void Copy(Array sourceArray, Array destinationArray, int length);
        public static void Copy(Array sourceArray, Array destinationArray, long length);

        /*
            ----------------------------------------------------------------------
            新建一个 array 实例, 指定了 维度, 元素类型, 元素个数, 
            参数 length 是 元素个数!!! (实践验证)
        */
        public static Array CreateInstance(Type elementType, int length); // 一维
        public static Array CreateInstance(Type elementType, int length1, int length2); // 二维
        public static Array CreateInstance(Type elementType, int length1, int length2, int length3); // 三维
        public static Array CreateInstance(Type elementType, params int[] lengths); // 多维, 指定了每个维度的 length
        // lowerBounds:
        //      A one-dimensional array that contains the lower bound (starting index) of each dimension of the Array to create.
        public static Array CreateInstance(Type elementType, int[] lengths, int[] lowerBounds);
        public static Array CreateInstance(Type elementType, params long[] lengths);


        public static T[] Empty<T>();
        public static bool Exists<T>(T[] array, Predicate<T> match);


        /*
            自定义 数组 初始值:
            将一个数组的所有元素, 设为一个指定值 value;
                int[] ary = new int[9];
                Array.Fill( ary, -1 );

            !!!!!!!! 坑 !!!!!!!!!
            假设存在: 
                List<int>[] datas = new List<int>[9];

            不能写:
                Array.Fill( datas, new List<int>() );
            !!!!!!

            因为在这个过程中, 其实只创建了一个 List<int> 对象, 并将它的引用分发给了每一个 datas 的成员...
            在后续操作中, 操作 datas[0] 还是操作 datas[1], 其实都是在操作同一个对象.....

        */
        public static void Fill<T>(T[] array, T value);
        public static void Fill<T>(T[] array, T value, int startIndex, int count);


        public static T Find<T>(T[] array, Predicate<T> match);
        public static T[] FindAll<T>(T[] array, Predicate<T> match);
        public static int FindIndex<T>(T[] array, Predicate<T> match);
        public static int FindIndex<T>(T[] array, int startIndex, int count, Predicate<T> match);
        public static int FindIndex<T>(T[] array, int startIndex, Predicate<T> match);
        public static T FindLast<T>(T[] array, Predicate<T> match);
        public static int FindLastIndex<T>(T[] array, int startIndex, int count, Predicate<T> match);
        public static int FindLastIndex<T>(T[] array, int startIndex, Predicate<T> match);
        public static int FindLastIndex<T>(T[] array, Predicate<T> match);

        public static void ForEach<T>(T[] array, Action<T> action);

        /*
            -------------------------------------------------------------
            查找元素的 idx;
        */
        public static int IndexOf<T>(T[] array, T value, int startIndex, int count);
        public static int IndexOf<T>(T[] array, T value, int startIndex);
        public static int IndexOf(Array array, object value);
        public static int IndexOf(Array array, object value, int startIndex, int count);
        public static int IndexOf(Array array, object value, int startIndex);
        public static int IndexOf<T>(T[] array, T value);


        public static int LastIndexOf(Array array, object value, int startIndex);
        public static int LastIndexOf<T>(T[] array, T value, int startIndex, int count);
        public static int LastIndexOf<T>(T[] array, T value, int startIndex);
        public static int LastIndexOf<T>(T[] array, T value);
        public static int LastIndexOf(Array array, object value, int startIndex, int count);
        public static int LastIndexOf(Array array, object value);


        public static void Resize<T>(ref T[] array, int newSize);

        /*
            ---------------------------------------------------
            反转 array;
        */
        public static void Reverse<T>(T[] array, int index, int length);// 反转某一段
        public static void Reverse<T>(T[] array);
        public static void Reverse(Array array);
        public static void Reverse(Array array, int index, int length);


        /*
            -----------------------------------------------------------------------
        */
        public static void Sort<T>(T[] array, int index, int length, IComparer<T> comparer);
        public static void Sort<T>(T[] array, IComparer<T> comparer);
        public static void Sort(Array array);
        public static void Sort(Array keys, Array items);
        public static void Sort(Array keys, Array items, IComparer comparer);
        public static void Sort(Array keys, Array items, int index, int length);
        public static void Sort(Array keys, Array items, int index, int length, IComparer comparer);
        public static void Sort<T>(T[] array, int index, int length);
        public static void Sort(Array array, IComparer comparer);
        public static void Sort(Array array, int index, int length);
        public static void Sort<T>(T[] array, Comparison<T> comparison); // 谓语: 委托 / lambda 版
        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items);
        public static void Sort<T>(T[] array);
        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length);
        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length, IComparer<TKey> comparer);
        public static void Sort(Array array, int index, int length, IComparer comparer);
        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, IComparer<TKey> comparer);


        /*
            -----------------------------------------------------------------------
        */

        public static bool TrueForAll<T>(T[] array, Predicate<T> match);

        // Creates a shallow copy 浅拷贝 of the Array.
        // 就是只拷贝 array 里的浅层元素, 如果元素是引用, 不拷贝这个引用对应的 对象本身;
        public object Clone();

        public void CopyTo(Array array, long index);
        public void CopyTo(Array array, int index);


        public IEnumerator GetEnumerator();
        public int GetLength(int dimension);
        public long GetLongLength(int dimension);


        /*
            -----------------------------------------------------------------------
            仅能作用于 int[,] 这样的数组, int[] 这样的 一维数组也可以; int[][] 的话参数 dimension 只能传入0;

            假设一个数组:
                int[,] nums = {
                    {1,1},
                    {2,2},
                    {3,3}
                };

            传入参数 dimension: 0起始的 维度idx, 在此例中, 只能传入: 0, 1 (因为只有两维)
            本组函数返回这个 维度的 上下 idx 区间值:
                0维, 高维度:
                    nums.GetLowerBound(0) --> 0
                    nums.GetUpperBound(0) --> 2

                1维, 低维度:
                    nums.GetLowerBound(1) --> 0
                    nums.GetUpperBound(1) --> 1
                
                至于为啥 高维度 在前面, 暂时没搞明白...
        */
        public int GetLowerBound(int dimension);
        public int GetUpperBound(int dimension);


        /*
            -----------------------------------------------------------------------
            其实就是 用一组 idx 访问一个元素值;  的函数表达;
        */
        public object GetValue(long index1, long index2);
        public object GetValue(params long[] indices);
        public object GetValue(long index);
        public object GetValue(int index);
        public object GetValue(int index1, int index2);
        public object GetValue(int index1, int index2, int index3);
        public object GetValue(params int[] indices);
        public object GetValue(long index1, long index2, long index3);

        /*
            Initializes every element of the value-type Array by calling the parameterless constructor of the value type.
            ---
            无序为一个新建的 array 调用本函数;
            比如:
                int[] ary = new int[9];

            c# 和 c/c++ 不同, c# 中新建的数组, 每个元素自动初始化为默认值, int 就是 0;
        */
        public void Initialize();


        /*
            -----------------------------------------------------------------------
            其实就是 用一组 idx 设置一个元素值;  的函数表达;
        */
        public void SetValue(object value, long index1, long index2, long index3);
        public void SetValue(object value, long index);
        public void SetValue(object value, params int[] indices);
        public void SetValue(object value, int index1, int index2, int index3);
        public void SetValue(object value, int index1, int index2);
        public void SetValue(object value, int index);
        public void SetValue(object value, params long[] indices);
        public void SetValue(object value, long index1, long index2);
    }
}

