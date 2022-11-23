
#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Reflection;
using System.Runtime.Serialization;

/*
    ----------------- 得到所有 value 组成的 List<> ------------------
        Dictionary<int, B> dic; // 然后往 dic 里塞很多值
        ...
        new List<B>(dic.Values);
    
    直接就能获得所有 values 组成的 List<>, 无需手动遍历;


    ----------------- key -------------------------
    需要实现一个 IEqualityComparer<TKey> 的比较器, 
    查看:
    https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1?view=net-7.0
    

*/

namespace System.Collections.Generic
{
    [DefaultMember("Item")]
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
    {
        public Dictionary();
        public Dictionary(IDictionary<TKey, TValue> dictionary);
        public Dictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection);
        public Dictionary(IEqualityComparer<TKey> comparer);
        public Dictionary(int capacity);
        public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer);
        public Dictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer);
        public Dictionary(int capacity, IEqualityComparer<TKey> comparer);
        protected Dictionary(SerializationInfo info, StreamingContext context);

        public TValue this[TKey key] { get; set; }

        public KeyCollection Keys { get; }
        public ValueCollection Values { get; }
        public IEqualityComparer<TKey> Comparer { get; }
        public int Count { get; }

        // key 已经存在时, 抛出异常: ArgumentException
        public void Add(TKey key, TValue value);
        public void Clear();
        public bool ContainsKey(TKey key);
        public bool ContainsValue(TValue value);
        public int EnsureCapacity(int capacity);
        public Enumerator GetEnumerator();
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
        public virtual void OnDeserialization(object sender);
        public bool Remove(TKey key, out TValue value);
        public bool Remove(TKey key);

        
        //  Sets the capacity of this dictionary to what it would be 
        // if it had been originally initialized with all its entries.
        public void TrimExcess();

        // Sets the capacity of this dictionary to hold up a specified number of entries 
        // without any further expansion of its backing storage.
        public void TrimExcess(int capacity);

        // 若 key 已存在, 本函数啥也不做, 直接返回 false;  否则返回 true
        public bool TryAdd(TKey key, TValue value);


        /*
            使用本函数来 安全地访问元素, 若用 dic[k], 且元素不存在, 则会报错;
            访问不到的话, out 参数值为 null
        */
        public bool TryGetValue(TKey key, out TValue value);

        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
        {
            public KeyValuePair<TKey, TValue> Current { get; }

            public void Dispose();
            public bool MoveNext();
        }

        public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, IReadOnlyCollection<TKey>, ICollection
        {
            public KeyCollection(Dictionary<TKey, TValue> dictionary);

            public int Count { get; }

            public void CopyTo(TKey[] array, int index);
            public Enumerator GetEnumerator();

            public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
            {
                public TKey Current { get; }

                public void Dispose();
                public bool MoveNext();
            }
        }
        public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, IReadOnlyCollection<TValue>, ICollection
        {
            public ValueCollection(Dictionary<TKey, TValue> dictionary);

            public int Count { get; }

            public void CopyTo(TValue[] array, int index);
            public Enumerator GetEnumerator();

            public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
            {
                public TValue Current { get; }

                public void Dispose();
                public bool MoveNext();
            }
        }
    }
}

