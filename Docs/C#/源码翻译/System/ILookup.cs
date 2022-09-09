#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Collections;
using System.Collections.Generic;
using System.Reflection;


/*
    想要获得一个 unordered_multimap, 需要用 ToLookup() 函数去实现,
    参见: "C#_容器介绍.md" 文件;
*/


namespace System.Linq
{
    [DefaultMember("Item")]
    public interface ILookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>, IEnumerable
    {
        IEnumerable<TElement> this[TKey key] { get; }

        int Count { get; }

        bool Contains(TKey key);
    }
}

