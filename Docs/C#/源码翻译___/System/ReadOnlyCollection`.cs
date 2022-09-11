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
        用法-1-:
            本类仅仅是一个现存容器的 只读访问层, 本类实例 和 原始容器对象, 都指向同一个 堆中容器数据本体;
            比如通过调用 List<T>.AsReadOnly(); 获得本类实例;
            ---
            虽然无法通过 本类的 api 去改写容器元素, 但可通过原来的 List<T> 接口去改写容器元素;
            而且之后再通过本 api 去访问这个容器元素, 读取到的是改写后的值;


    */
    [ComVisible(false)]
    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy("System.Collections.Generic.Mscorlib_CollectionDebugView<T>")]
    [DefaultMember("Item")]
    public class ReadOnlyCollection<T> :
                                        ICollection<T>, 
                                        IEnumerable<T>, 
                                        IEnumerable, 
                                        IList<T>, 
                                        IReadOnlyCollection<T>, 
                                        IReadOnlyList<T>, 
                                        ICollection, 
                                        IList
    {

        public ReadOnlyCollection(IList<T> list);

        public T this[int index] { get; }

        public int Count { get; }
        protected IList<T> Items { get; }

        public bool Contains(T value);

        public void CopyTo(T[] array, int index);


        public IEnumerator<T> GetEnumerator();
        public int IndexOf(T value);
    }
}

