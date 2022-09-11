#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
#endregion

/*
    在类似 List.Sort(), Array.Sort() 等排序算法中, 可传入一个 委托 / lambda 来定义 排序规则;
    此谓语的类型就是 本class;

    谓语规则:
        x is less than y.    --> ret < 0;
        x equals y.          --> ret   0;
        x is greater than y. --> ret > 0;

    默认排序, 即: 升序时, 谓语该写为:
        (a,b)=>a-b

    反之, 若想要逆序, 谓语写为:
        (a,b)=>b-a

        
*/

namespace System
{
    // T 为 逆变类型
    [__DynamicallyInvokableAttribute]
    public delegate int Comparison<in T>(T x, T y);
}

