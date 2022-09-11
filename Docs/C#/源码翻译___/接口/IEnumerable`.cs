#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
#endregion


namespace System.Collections.Generic
{
    [__DynamicallyInvokableAttribute]
    [TypeDependencyAttribute("System.SZArrayHelper")]
    public interface IEnumerable<out T> : IEnumerable
    {
        [__DynamicallyInvokableAttribute]
        IEnumerator<T> GetEnumerator();
    }
}
