#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Reflection;

namespace System.Collections.Generic
{
    [DefaultMember("Item")]
    public class SortedList<TKey, TValue> : 
                                        ICollection<KeyValuePair<TKey, TValue>>, 
                                        IEnumerable<KeyValuePair<TKey, TValue>>, 
                                        IEnumerable, 
                                        IDictionary<TKey, TValue>, 
                                        IReadOnlyCollection<KeyValuePair<TKey, TValue>>, 
                                        IReadOnlyDictionary<TKey, TValue>, 
                                        ICollection, 
                                        IDictionary
    {
        
        public SortedList();
        public SortedList(IComparer<TKey> comparer);
        public SortedList(IDictionary<TKey, TValue> dictionary);
        public SortedList(int capacity);
        public SortedList(IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer);
        public SortedList(int capacity, IComparer<TKey> comparer);


        public TValue this[TKey key] { get; set; }

        public int Count { get; }
        public IComparer<TKey> Comparer { get; }
        public int Capacity { get; set; }


        /*
            可通过:
                string v = mySortedList.Keys[3];
            直接访问;
            因为在 SortedList 体内, Keys 本来就是一个数组, 所以
        */
        public IList<TKey> Keys { get; }
        public IList<TValue> Values { get; }


        public void Add(TKey key, TValue value);


        public void Clear();


        public bool ContainsKey(TKey key);


        public bool ContainsValue(TValue value);


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();


        public int IndexOfKey(TKey key);


        public int IndexOfValue(TValue value);


        public bool Remove(TKey key);


        public void RemoveAt(int index);


        public void TrimExcess();


        public bool TryGetValue(TKey key, out TValue value);
    }
}