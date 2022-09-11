#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Collections.ObjectModel
{
    /*
        有点类似 Dictionary<>, 
    */
    [ComVisible(false)]
    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy("System.Collections.Generic.Mscorlib_KeyedCollectionDebugView<K, T>")]
    [DefaultMember("Item")]
    public abstract class KeyedCollection<TKey, TItem> : Collection<TItem>
    {
        protected KeyedCollection();
        protected KeyedCollection(IEqualityComparer<TKey> comparer);
        protected KeyedCollection(IEqualityComparer<TKey> comparer, int dictionaryCreationThreshold);

        public TItem this[TKey key] { get; }

        public IEqualityComparer<TKey> Comparer { get; }
        protected IDictionary<TKey, TItem> Dictionary { get; }

        public bool Contains(TKey key);
        public bool Remove(TKey key);
        public bool TryGetValue(TKey key, out TItem item);
        protected void ChangeItemKey(TItem item, TKey newKey);
        protected override void ClearItems();
        protected abstract TKey GetKeyForItem(TItem item);
        protected override void InsertItem(int index, TItem item);
        protected override void RemoveItem(int index);
        protected override void SetItem(int index, TItem item);
    }
}
