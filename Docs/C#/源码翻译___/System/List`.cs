#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;

namespace System.Collections.Generic
{
    /*



        List<T> 同时会用到 相等比较器 和 排序比较器: (equality comparer and an ordering comparer)
        -- equality comparer:
            用于:
                Contains()
                IndexOf()
                LastIndexOf() 
                Remove()
                ---
            The default equality comparer for type T is determined as follows. 
            If type T implements the IEquatable<T> generic interface, 
            then the equality comparer is the Equals(T) method of that interface; 
            otherwise, the default equality comparer is Object.Equals(Object).  (这会涉及装箱拆箱)

        -- ordering comparer:
            用于:
                BinarySearch()
                Sort()
                ---
            The default comparer for type T is determined as follows. 
            If type T implements the IComparable<T> generic interface, then the default comparer is the CompareTo(T) method of that interface; 
            otherwise, if type T implements the nongeneric IComparable interface(非泛型接口), then the default comparer is the CompareTo(Object) method of that interface. 
            If type T implements neither interface, then there is no default comparer, and a comparer or comparison delegate must be provided explicitly.




        ------- 为避免 装箱拆箱:
        Make certain the value type used for type T implements the IEquatable<T> generic interface. 
        If not, methods such as "Contains()" must call the Object.Equals(Object) method, which boxes the affected list element. 

        If the value type implements the "IComparable" interface and you own the source code, 
        also implement the "IComparable<T>" generic interface to prevent the "BinarySearch()" and "Sort()" methods from boxing list elements. 
        
        If you do not own the source code, pass an "IComparer<T"> object to the "BinarySearch()" and "Sort()" methods






    */
    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy("System.Collections.Generic.Mscorlib_CollectionDebugView<T>")]
    [DefaultMember("Item")]
    public class List<T> :
                            ICollection<T>, 
                            IEnumerable<T>, 
                            IEnumerable, 
                            IList<T>, 
                            IReadOnlyCollection<T>, 
                            IReadOnlyList<T>, 
                            ICollection, 
                            IList
    {

        public List();

        /*
            也可以直接从 array 对象上初始化:
                int[]     ary   = { 3,2,1,4 };
                List<int> list  = new List<int>( ary ); 

            这个过程会将 元素 从 collection 中复制到新的 list 中;
        */
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


        /*
            Converts the elements in the current List<T> to another type, and returns a list containing the converted elements.
            ---
            List<int> newList = ents.ConvertAll( x=>x.age );
            ---
            将原类型的 x.age 剥离出来, 制作成一个新数组, 省的写 linq 了;

        */
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


        /*
            将目标元素删除后, 后面所有元素都会往前移动一位. 
            所以可能存在 巨大开销

            若 list 中元素可任意调换顺序, 可用手动法来 "移除" 一个元素:

                int lastIndex = list.Count - 1;
                shapes[index] = shapes[lastIndex];
                shapes.RemoveAt(lastIndex);

            手动交换 目标元素 和 最后一个元素,
            再删除最后一个元素. 
        */
        public void RemoveAt(int index);
        public void RemoveRange(int index, int count);


        /*
            反转 list 中的元素的顺序;

            !!!! 注意 !!!!!
                IList<int> ary = new List<int>(){ 1,2,3 };
                ary.Reverse(); 
            上面这么调用并不能让 ary 体内元素翻转...

            https://stackoverflow.com/questions/4673136/why-does-ilist-reverse-not-work-like-list-reverse

            方法-1-:

                IList<int> oldList;
                ...
                var newList = (List<int>)oldList;
                newList.Reverse();
                ---
                此处的 newList 只是一个变量, 几乎没啥成本;
        */
        public void Reverse(int index, int count);
        public void Reverse();



        /* --------------------------------------------- //
            直接将 本list 内的元素进行排序, 
            
            Lambda:
                Comparison:
                例: 
                    ents.Sort( (x,y)=>{ return (x.age - y.age); } );
                    ---
                    此时会按照 x.age 从小到大排序;

            非 Lambda: 
                IComparer 的具体使用方式, 见 Array 内 Sort() 处注释;
        */
        public void Sort(Comparison<T> comparison); // lambda
        public void Sort();
        public void Sort(int index, int count, IComparer<T> comparer);
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

