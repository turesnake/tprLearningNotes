#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion


namespace System.Collections.Generic
{
    public class Queue<T> : 
                            IEnumerable<T>, 
                            IEnumerable, 
                            IReadOnlyCollection<T>, 
                            ICollection
    {
        public Queue();

        // 直接将一个现成容器里的全部元素, 复制到新的 queue 实例中, 同时构建这个新的 queue
        public Queue(IEnumerable<T> collection);

        public Queue(int capacity);

        public int Count { get; }

        public void Clear();
        public bool Contains(T item);

        // 将本 queue 的全部元素 复制到一个 array 中;
        public void CopyTo(T[] array, int arrayIndex);


        // 将队首元素 移除出 queue, 同时返回这个元素
        public T Dequeue();

        // 添加一个元素到 队尾;
        // queue 的内部存储结构类似 array, 元素数量超出 capacity 时需要做 扩容操作;
        public void Enqueue(T item);


        public Enumerator GetEnumerator();

        // Returns the object at the beginning of the Queue<T> without removing it.
        // 若 queue 内无元素, 调用本函数会 抛出异常
        public T Peek();


        public T[] ToArray();

        // Sets the capacity to the actual number of elements in the Queue<T>, 
        // if that number is less than 90 percent of current capacity.
        public void TrimExcess();


        public bool TryDequeue(out T result);
        public bool TryPeek(out T result);


        public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
        {
            public T Current { get; }

            public void Dispose();
            public bool MoveNext();
        }
    }
}
