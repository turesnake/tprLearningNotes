#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion

using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace System
{
    /*
        看起来是用来方便的 获得一个 array 的一个片段; 得到一个 ArraySegment 不需要执行 array 的复制工作;



    */
    [DefaultMember("Item")]
    public readonly struct ArraySegment<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>
    {
        public ArraySegment(T[] array);
        public ArraySegment(T[] array, int offset, int count);

        public T this[int index] { get; set; }

        public static ArraySegment<T> Empty { get; }
        public int Offset { get; }
        public T[] Array { get; }
        public int Count { get; }

        public void CopyTo(T[] destination);
        public void CopyTo(T[] destination, int destinationIndex);
        public void CopyTo(ArraySegment<T> destination);
        public bool Equals(ArraySegment<T> obj);
        public override bool Equals(object obj);
        public Enumerator GetEnumerator();
        public override int GetHashCode();
        public ArraySegment<T> Slice(int index);
        public ArraySegment<T> Slice(int index, int count);
        public T[] ToArray();

        public static bool operator ==(ArraySegment<T> a, ArraySegment<T> b);
        public static bool operator !=(ArraySegment<T> a, ArraySegment<T> b);

        public static implicit operator ArraySegment<T>(T[] array);

        public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
        {
            public T Current { get; }

            public void Dispose();
            public bool MoveNext();
        }
    }
}