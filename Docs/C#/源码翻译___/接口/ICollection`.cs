#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
#endregion


namespace System.Collections.Generic
{
    [__DynamicallyInvokableAttribute]
    [TypeDependencyAttribute("System.SZArrayHelper")]
    public interface ICollection<T> : IEnumerable<T>, IEnumerable
    {
        [__DynamicallyInvokableAttribute]
        int Count { get; }
        [__DynamicallyInvokableAttribute]
        bool IsReadOnly { get; }

        [__DynamicallyInvokableAttribute]
        void Add(T item);
        [__DynamicallyInvokableAttribute]
        void Clear();
        [__DynamicallyInvokableAttribute]
        bool Contains(T item);
        [__DynamicallyInvokableAttribute]
        void CopyTo(T[] array, int arrayIndex);
        [__DynamicallyInvokableAttribute]
        bool Remove(T item);
    }
}