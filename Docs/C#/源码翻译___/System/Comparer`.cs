#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion


namespace System.Collections.Generic
{
    /*

    */
    public abstract class Comparer<T> : 
                                    IComparer<T>, 
                                    IComparer
    {
        protected Comparer();

        public static Comparer<T> Default { get; }

        public static Comparer<T> Create(Comparison<T> comparison);


        // 抽象方法没有函数体只有函数签名;
        // 具体内容需要 Comparer<> 的派生类 去实现(必须实现)
        /*
            ret:
            x is less than y.    --> ret < 0;
            x equals y.          --> ret   0;
            x is greater than y. --> ret > 0;
            ----
            等同于:
                return (x-y);
        */
        public abstract int Compare(T x, T y);
    }
}

