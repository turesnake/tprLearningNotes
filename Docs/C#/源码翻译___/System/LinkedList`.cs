#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Runtime.Serialization;

namespace System.Collections.Generic
{
    /*
        类似 双向队列 deque
    */
    public class LinkedList<T> : 
                                ICollection<T>, 
                                IEnumerable<T>, 
                                IEnumerable, 
                                IReadOnlyCollection<T>, 
                                ICollection, 
                                IDeserializationCallback, 
                                ISerializable
    {

        public LinkedList();
        public LinkedList(IEnumerable<T> collection);
        protected LinkedList(SerializationInfo info, StreamingContext context);


        public LinkedListNode<T> Last { get; }
        public LinkedListNode<T> First { get; }

        public int Count { get; }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode);
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value);

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode);
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value);

        public void AddFirst(LinkedListNode<T> node);
        public LinkedListNode<T> AddFirst(T value);

        public void AddLast(LinkedListNode<T> node);
        public LinkedListNode<T> AddLast(T value);

        public void Clear();

        public bool Contains(T value);

        public void CopyTo(T[] array, int index);

        public LinkedListNode<T> Find(T value);

        public LinkedListNode<T> FindLast(T value);


        public Enumerator GetEnumerator();
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
        public virtual void OnDeserialization(object sender);

        public void Remove(LinkedListNode<T> node);
        public bool Remove(T value);


        public void RemoveFirst();
        public void RemoveLast();


        public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable, IDeserializationCallback, ISerializable
        {
            public T Current { get; }

            public void Dispose();
            public bool MoveNext();
        }
    }
}