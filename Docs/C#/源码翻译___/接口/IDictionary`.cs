
#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Reflection;

namespace System.Collections.Generic
{
    [DefaultMember("Item")]
    public interface IDictionary<TKey, TValue> : 
                                                ICollection<KeyValuePair<TKey, TValue>>, 
                                                IEnumerable<KeyValuePair<TKey, TValue>>, 
                                                IEnumerable
    {
        TValue this[TKey key] { get; set; }

        ICollection<TKey> Keys { get; }
        ICollection<TValue> Values { get; }

        void Add(TKey key, TValue value);
        bool ContainsKey(TKey key);
        bool Remove(TKey key);
        bool TryGetValue(TKey key, out TValue value);
    }
}
