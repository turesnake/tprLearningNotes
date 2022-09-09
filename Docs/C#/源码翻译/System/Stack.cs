
#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion




namespace System.Collections.Generic
{
    public class Stack<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection
    {
        public Stack();
        public Stack(IEnumerable<T> collection);
        public Stack(int capacity);

        public int Count { get; }

        public void Clear();
        public bool Contains(T item);
        public void CopyTo(T[] array, int arrayIndex);
        public Enumerator GetEnumerator();
        public T Peek();

        // 和正统 Pop 不同, 这个 pop 直接返回那个元素;
        public T Pop();
        public void Push(T item);
        public T[] ToArray();
        public void TrimExcess();
        public bool TryPeek(out T result);
        public bool TryPop(out T result);

        public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
        {
            public T Current { get; }

            public void Dispose();
            public bool MoveNext();
        }
    }
}

