#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;

namespace System.Collections.Generic
{
    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy("System.Collections.Generic.Mscorlib_CollectionDebugView<T>")]
    [DefaultMember("Item")]
    public class List<T> // List__RR
        : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, 
        IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
    {

        public List();
        public List(IEnumerable<T> collection);
        public List(int capacity);


        public T this[int index] { get; set; }

        public int Count { get; }
        public int Capacity { get; set; }

        public void Add(T item);

        // 可用 AddRange 来在 list 尾后添加一组元素, 参数可以为 array;
        public void AddRange(IEnumerable<T> collection);

        /*
            Returns a read-only ReadOnlyCollection<T> wrapper for the current collection.
            return An object that acts as a read-only wrapper around the current List<T>.
            --
            只是将本容器 做一层包裹后返回(限制了写入权限), 这个过程没有复制容器中的数据;
            虽然无法通过 ReadOnlyCollection<T> 接口来改写容器数据, 但可通过原来的 List<T> 接口来改写;
            当这个改写发生后, ReadOnlyCollection<T> 接口 读取的是改写后的数据;
            ---
            也就是说说, ReadOnlyCollection<T> 仅仅是一个 "限制了写入权限" 的包裹层;
        */
        public ReadOnlyCollection<T> AsReadOnly();

        public int BinarySearch(int index, int count, T item, IComparer<T> comparer);
        public int BinarySearch(T item);
        public int BinarySearch(T item, IComparer<T> comparer);

        public void Clear();

        public bool Contains(T item);
        public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter);

        public void CopyTo(T[] array, int arrayIndex);
        public void CopyTo(T[] array);
        public void CopyTo(int index, T[] array, int arrayIndex, int count);

        public bool Exists(Predicate<T> match);

        public T Find(Predicate<T> match);
        public List<T> FindAll(Predicate<T> match);

        public int FindIndex(int startIndex, int count, Predicate<T> match);
        public int FindIndex(int startIndex, Predicate<T> match);
        public int FindIndex(Predicate<T> match);

        public T FindLast(Predicate<T> match);
        public int FindLastIndex(int startIndex, int count, Predicate<T> match);
        public int FindLastIndex(int startIndex, Predicate<T> match);
        public int FindLastIndex(Predicate<T> match);

        public void ForEach(Action<T> action);
        public Enumerator GetEnumerator();
        public List<T> GetRange(int index, int count);

        public int IndexOf(T item, int index, int count);
        public int IndexOf(T item, int index);
        public int IndexOf(T item);

        public void Insert(int index, T item);
        public void InsertRange(int index, IEnumerable<T> collection);

        public int LastIndexOf(T item);
        public int LastIndexOf(T item, int index);
        public int LastIndexOf(T item, int index, int count);

        public bool Remove(T item);

        // Removes all the elements that match the conditions defined by the specified predicate.
        // return:
        //      The number of elements removed from the List
        public int RemoveAll(Predicate<T> match);


        public void RemoveAt(int index);
        public void RemoveRange(int index, int count);

        public void Reverse(int index, int count);
        public void Reverse();

        public void Sort(Comparison<T> comparison);
        public void Sort(int index, int count, IComparer<T> comparer);
        public void Sort();
        public void Sort(IComparer<T> comparer);

        public T[] ToArray();

        /*
            假设当前 Capacity 是 8, 实际使用了 5, 调用 TrimExcess() 之后, Capacity 会被改为 5;
            用它来节省内存占用;
        */
        public void TrimExcess();



        public bool TrueForAll(Predicate<T> match);

        public struct Enumerator 
            : IEnumerator<T>, IEnumerator, IDisposable
        {
            public T Current { get; }

            public void Dispose();
            public bool MoveNext();
        }
    }
}

