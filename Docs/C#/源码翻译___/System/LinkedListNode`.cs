#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion


namespace System.Collections.Generic
{
    public sealed class LinkedListNode<T>
    {
        public LinkedListNode(T value);

        public LinkedList<T> List { get; }
        public LinkedListNode<T> Next { get; }
        public LinkedListNode<T> Previous { get; }
        public T Value { get; set; }
    }
}
