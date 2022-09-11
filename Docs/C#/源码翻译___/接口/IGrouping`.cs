#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{


    // 协变类型;    
    public interface IGrouping<out TKey, out TElement> : IEnumerable<TElement>, IEnumerable
    {
        TKey Key { get; }
    }
}

