#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Reflection;

namespace System.Collections.Generic
{
    /*
        Represents a read-only collection of elements that can be accessed by index.
        ---
        被 List<>, ReadOnlyCollection<> 继承;

        


    */
    [DefaultMember("Item")]
    public interface IReadOnlyList<out T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        T this[int index] { get; }
    }
}
