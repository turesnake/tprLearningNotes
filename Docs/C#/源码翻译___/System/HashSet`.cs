#region 程序集 System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// System.Core.dll
#endregion

using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security;

namespace System.Collections.Generic
{
    /*
        就是 c++ 中的 unordered_set<> 容器

        ----------------- key -------------------------
        和 Dictionary 一样:
        需要实现一个 IEqualityComparer<TKey> 的比较器, 
        查看:
        https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1?view=net-7.0

    */
    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy("System.Collections.Generic.HashSetDebugView<T>")]
    public class HashSet<T> : 
                            ICollection<T>, 
                            IEnumerable<T>, 
                            IEnumerable, 
                            IReadOnlyCollection<T>, 
                            ISet<T>, 
                            IDeserializationCallback, 
                            ISerializable
    {
        public HashSet();
        public HashSet(IEnumerable<T> collection);
        public HashSet(IEqualityComparer<T> comparer);
        public HashSet(int capacity);
        public HashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer);
        public HashSet(int capacity, IEqualityComparer<T> comparer);
        protected HashSet(SerializationInfo info, StreamingContext context);

        public IEqualityComparer<T> Comparer { get; }
        public int Count { get; }

        public static IEqualityComparer<HashSet<T>> CreateSetComparer();

        // 若元素 item 已经存在, 返回 false;
        // 不停的插入元素会导致撞到 capacity, 此时的行为大致和 List 一样, 会自己扩容, 为避免反复扩容, 最好一开始就定好 capacity
        public bool Add(T item);

        public void Clear();
        public bool Contains(T item);
        public void CopyTo(T[] array, int arrayIndex);
        public void CopyTo(T[] array);
        public void CopyTo(T[] array, int arrayIndex, int count);
        public int EnsureCapacity(int capacity);
        public void ExceptWith(IEnumerable<T> other);
        public Enumerator GetEnumerator();
        [SecurityCritical]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
        public void IntersectWith(IEnumerable<T> other);
        public bool IsProperSubsetOf(IEnumerable<T> other);
        public bool IsProperSupersetOf(IEnumerable<T> other);
        public bool IsSubsetOf(IEnumerable<T> other);
        public bool IsSupersetOf(IEnumerable<T> other);
        public virtual void OnDeserialization(object sender);
        public bool Overlaps(IEnumerable<T> other);
        public bool Remove(T item);
        public int RemoveWhere(Predicate<T> match);
        public bool SetEquals(IEnumerable<T> other);
        public void SymmetricExceptWith(IEnumerable<T> other);
        public void TrimExcess();
        public bool TryGetValue(T equalValue, out T actualValue);
        public void UnionWith(IEnumerable<T> other);

        public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
        {
            public T Current { get; }

            public void Dispose();
            public bool MoveNext();
        }
    }
}