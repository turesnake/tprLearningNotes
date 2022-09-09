
#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Reflection;

namespace System.Collections.Generic
{
    [DefaultMember("Item")]
    public class SortedDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue>, ICollection, IDictionary
    {
        public SortedDictionary();
        public SortedDictionary(IComparer<TKey> comparer);
        public SortedDictionary(IDictionary<TKey, TValue> dictionary);
        public SortedDictionary(IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer);

        public TValue this[TKey key] { get; set; }

        public ValueCollection Values { get; }
        public KeyCollection Keys { get; }
        public IComparer<TKey> Comparer { get; }
        public int Count { get; }

        public void Add(TKey key, TValue value);
        public void Clear();
        public bool ContainsKey(TKey key);
        public bool ContainsValue(TValue value);
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index);
        public Enumerator GetEnumerator();
        public bool Remove(TKey key);
        public bool TryGetValue(TKey key, out TValue value);

        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
        {
            public KeyValuePair<TKey, TValue> Current { get; }

            public void Dispose();
            public bool MoveNext();
        }

        public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, IReadOnlyCollection<TKey>, ICollection
        {
            public KeyCollection(SortedDictionary<TKey, TValue> dictionary);

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
            public ValueCollection(SortedDictionary<TKey, TValue> dictionary);

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
