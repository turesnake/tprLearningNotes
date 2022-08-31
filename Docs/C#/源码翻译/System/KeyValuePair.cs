#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

namespace System.Collections.Generic
{
    /*
         Dictionary<> 的元素类型; foreach 时能得到;

    */
    public struct KeyValuePair<TKey, TValue>
    {
        public KeyValuePair(TKey key, TValue value);

        public TKey Key { get; }
        public TValue Value { get; }

        // 解构; 其实就是提取出 k 和 v;
        public void Deconstruct(out TKey key, out TValue value);
        public override string ToString();
    }
}

