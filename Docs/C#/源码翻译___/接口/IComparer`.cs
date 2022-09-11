#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
#endregion

namespace System.Collections.Generic
{
    /*
        官方建议:
        It is recommended to derive from Comparer<T> instead of implementing IComparer<T>.
    */
    [__DynamicallyInvokableAttribute]
    public interface IComparer<in T>
    {
        /*
            ret:
            x is less than y.    --> ret < 0;
            x equals y.          --> ret   0;
            x is greater than y. --> ret > 0;
            ----
            等同于:
                return (x-y);
        */
        [__DynamicallyInvokableAttribute]
        int Compare(T x, T y);
    }
}