#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Runtime.Serialization;

namespace System.Collections.Generic
{

    /*
        For a thread safe alternative to SortedSet<T>, see ImmutableSortedSet<T>

    */
    public class SortedSet<T> : 
                            ICollection<T>, 
                            IEnumerable<T>, 
                            IEnumerable, 
                            IReadOnlyCollection<T>, 
                            ISet<T>, 
                            ICollection, 
                            IDeserializationCallback, 
                            ISerializable
    {

        public SortedSet();
        public SortedSet(IComparer<T> comparer);
        public SortedSet(IEnumerable<T> collection);
        public SortedSet(IEnumerable<T> collection, IComparer<T> comparer);
        protected SortedSet(SerializationInfo info, StreamingContext context);


        public T Min { get; }
        public T Max { get; }
        public int Count { get; }
        public IComparer<T> Comparer { get; }

        public static IEqualityComparer<SortedSet<T>> CreateSetComparer();
        public static IEqualityComparer<SortedSet<T>> CreateSetComparer(IEqualityComparer<T> memberEqualityComparer);

        // 添加一个值,  返回是否已经添加成功;
        public bool Add(T item);
        public virtual void Clear();
        public virtual bool Contains(T item);

        public void CopyTo(T[] array, int index, int count);
        public void CopyTo(T[] array);
        public void CopyTo(T[] array, int index);

        // 从本容器中, 移除掉所有同样位于参数 other 中的元素; (不需要是同一个元素, 通过比大小函数得到相同 就可以了)
        // 如果某个元素位于 other 中, 但不位于本容器中, 则不处理这个元素; 
        public void ExceptWith(IEnumerable<T> other);


        public Enumerator GetEnumerator();

        /*
            从容器内得到 一段子序列, 最小最大值由参数指定 (包含这两个边界值), 返回的类型也是 SortedSet<T>;
            注意:
                返回的 子序列 并不是原始容器的一段 copy, 而仅仅是一个 操作窗口 (view) 或者说是浅拷贝;
            
            参数本身:
                不需要 和 传入本容器的某个参数是同一个实例; 只要能使用类似 IComparable<> 接口提供的比较函数 来比大小就可以了;
                因为本容器的 元素类型本身就要求支持这个功能, 所以是没问题的;
                具体来说就是, 可以写成:
                    set.GetViewBetween( new D(1), new D(2) );
                这种样子;

            ---
            由于本函数拿到的只是一个 操作窗口, 所以通过 本函数的返回值 去修改那些元素, 最终修改的是 原始容器里的 元素对象里的内容;
        */
        public virtual SortedSet<T> GetViewBetween(T lowerValue, T upperValue);

        // 和 ExceptWith 相反, 让本容器仅保留那些 同样存在于 other 中的元素; (不需要是同一个元素, 通过比大小函数得到相同 就可以了)
        public virtual void IntersectWith(IEnumerable<T> other);

        // 查明 本容器 是否为 参数 other 的真子集;
        public bool IsProperSubsetOf(IEnumerable<T> other);

        // 查明 本容器 是否为 参数 other 的真超集;
        public bool IsProperSupersetOf(IEnumerable<T> other);

        public bool IsSubsetOf(IEnumerable<T> other);
        public bool IsSupersetOf(IEnumerable<T> other);

        // 若本容器 和 参数other 至少共享一个元素(比大小函数得到相等就行), 本函数就返回 true;
        public bool Overlaps(IEnumerable<T> other);


        public bool Remove(T item);

        // 用谓语来绝对 移除掉哪些元素
        public int RemoveWhere(Predicate<T> match);

        // 反转
        public IEnumerable<T> Reverse();

        // 判断 本容器 是否和 other 拥有相同元素s; (比大小函数得到相等就行)
        public bool SetEquals(IEnumerable<T> other);

        // 有点绕, 看文档
        // 猜测是个 布尔运算关系
        public void SymmetricExceptWith(IEnumerable<T> other);


        // 查找目标对象, out 出找到的对象, 如果有的话;
        public bool TryGetValue(T equalValue, out T actualValue);

        // 有点绕, 看文档
        // 猜测是个 布尔运算关系
        public void UnionWith(IEnumerable<T> other);

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context);
        protected virtual void OnDeserialization(object sender);

        public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable, IDeserializationCallback, ISerializable
        {
            public T Current { get; }

            public void Dispose();
            public bool MoveNext();
        }
    }
}
