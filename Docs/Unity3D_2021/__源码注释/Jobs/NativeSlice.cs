#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Internal;

namespace Unity.Collections;


/*
    可以从一个 NativeArray 上切出一块区域来
    
*/
//
// Summary:
//     Native Slice.
[DebuggerDisplay("Length = {Length}")]
[NativeContainerSupportsMinMaxWriteRestriction]
[NativeContainer]
[DebuggerTypeProxy(typeof(NativeSliceDebugView<>))]
public struct NativeSlice<T> : IEnumerable<T>, IEnumerable, IEquatable<NativeSlice<T>> where T : struct
{
    [ExcludeFromDocs]
    public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
    {
        private NativeSlice<T> m_Array;

        private int m_Index;

        public T Current => m_Array[m_Index];

        object IEnumerator.Current => Current;

        public Enumerator(ref NativeSlice<T> array)
        {
            m_Array = array;
            m_Index = -1;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            m_Index++;
            return m_Index < m_Array.Length;
        }

        public void Reset()
        {
            m_Index = -1;
        }
    }

    [NativeDisableUnsafePtrRestriction]
    internal unsafe byte* m_Buffer;

    internal int m_Stride;

    internal int m_Length;

    internal int m_MinIndex;

    internal int m_MaxIndex;

    internal AtomicSafetyHandle m_Safety;

    public unsafe T this[int index]
    {
        get
        {
            CheckReadIndex(index);
            return UnsafeUtility.ReadArrayElementWithStride<T>(m_Buffer, index, m_Stride);
        }
        [WriteAccessRequired]
        set
        {
            CheckWriteIndex(index);
            UnsafeUtility.WriteArrayElementWithStride(m_Buffer, index, m_Stride, value);
        }
    }

    public int Stride => m_Stride;

    public int Length => m_Length;

    public NativeSlice(NativeSlice<T> slice, int start)
        : this(slice, start, slice.Length - start)
    {
    }

    public unsafe NativeSlice(NativeSlice<T> slice, int start, int length)
    {
        if (start < 0)
        {
            throw new ArgumentOutOfRangeException("start", $"Slice start {start} < 0.");
        }

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException("length", $"Slice length {length} < 0.");
        }

        if (start + length > slice.Length)
        {
            throw new ArgumentException($"Slice start + length ({start + length}) range must be <= slice.Length ({slice.Length})");
        }

        if ((slice.m_MinIndex != 0 || slice.m_MaxIndex != slice.m_Length - 1) && (start < slice.m_MinIndex || slice.m_MaxIndex < start || slice.m_MaxIndex < start + length - 1))
        {
            throw new ArgumentException("Slice may not be used on a restricted range slice", "slice");
        }

        m_MinIndex = 0;
        m_MaxIndex = length - 1;
        m_Safety = slice.m_Safety;
        m_Stride = slice.m_Stride;
        m_Buffer = slice.m_Buffer + m_Stride * start;
        m_Length = length;
    }

    public NativeSlice(NativeArray<T> array)
        : this(array, 0, array.Length)
    {
    }

    public NativeSlice(NativeArray<T> array, int start)
        : this(array, start, array.Length - start)
    {
    }

    public static implicit operator NativeSlice<T>(NativeArray<T> array)
    {
        return new NativeSlice<T>(array);
    }

    public unsafe NativeSlice(NativeArray<T> array, int start, int length)
    {
        if (start < 0)
        {
            throw new ArgumentOutOfRangeException("start", $"Slice start {start} < 0.");
        }

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException("length", $"Slice length {length} < 0.");
        }

        if (start + length > array.Length)
        {
            throw new ArgumentException($"Slice start + length ({start + length}) range must be <= array.Length ({array.Length})");
        }

        if ((array.m_MinIndex != 0 || array.m_MaxIndex != array.m_Length - 1) && (start < array.m_MinIndex || array.m_MaxIndex < start || array.m_MaxIndex < start + length - 1))
        {
            throw new ArgumentException("Slice may not be used on a restricted range array", "array");
        }

        if (start + length < 0)
        {
            throw new ArgumentException("Slice start + length ({start + length}) causes an integer overflow");
        }

        m_MinIndex = 0;
        m_MaxIndex = length - 1;
        m_Safety = array.m_Safety;
        m_Stride = UnsafeUtility.SizeOf<T>();
        byte* buffer = (byte*)array.m_Buffer + m_Stride * start;
        m_Buffer = buffer;
        m_Length = length;
    }

    public unsafe NativeSlice<U> SliceConvert<U>() where U : struct
    {
        int num = UnsafeUtility.SizeOf<U>();
        NativeSlice<U> result = default(NativeSlice<U>);
        result.m_Buffer = m_Buffer;
        result.m_Stride = num;
        result.m_Length = m_Length * m_Stride / num;
        if (m_Stride != UnsafeUtility.SizeOf<T>())
        {
            throw new InvalidOperationException("SliceConvert requires that stride matches the size of the source type");
        }

        if (m_MinIndex != 0 || m_MaxIndex != m_Length - 1)
        {
            throw new InvalidOperationException("SliceConvert may not be used on a restricted range array");
        }

        if (m_Stride * m_Length % num != 0)
        {
            throw new InvalidOperationException("SliceConvert requires that Length * sizeof(T) is a multiple of sizeof(U).");
        }

        result.m_MinIndex = 0;
        result.m_MaxIndex = result.m_Length - 1;
        result.m_Safety = m_Safety;
        return result;
    }

    public unsafe NativeSlice<U> SliceWithStride<U>(int offset) where U : struct
    {
        NativeSlice<U> result = default(NativeSlice<U>);
        result.m_Buffer = m_Buffer + offset;
        result.m_Stride = m_Stride;
        result.m_Length = m_Length;
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException("offset", "SliceWithStride offset must be >= 0");
        }

        if (offset + UnsafeUtility.SizeOf<U>() > UnsafeUtility.SizeOf<T>())
        {
            throw new ArgumentException("SliceWithStride sizeof(U) + offset must be <= sizeof(T)", "offset");
        }

        result.m_MinIndex = m_MinIndex;
        result.m_MaxIndex = m_MaxIndex;
        result.m_Safety = m_Safety;
        return result;
    }

    public NativeSlice<U> SliceWithStride<U>() where U : struct
    {
        return SliceWithStride<U>(0);
    }

    [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
    private unsafe void CheckReadIndex(int index)
    {
        if (index < m_MinIndex || index > m_MaxIndex)
        {
            FailOutOfRangeError(index);
        }

        int* ptr = (int*)(void*)m_Safety.versionNode;
        if (m_Safety.version != (*ptr & -7))
        {
            AtomicSafetyHandle.CheckReadAndThrowNoEarlyOut(m_Safety);
        }
    }

    [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
    private unsafe void CheckWriteIndex(int index)
    {
        if (index < m_MinIndex || index > m_MaxIndex)
        {
            FailOutOfRangeError(index);
        }

        int* ptr = (int*)(void*)m_Safety.versionNode;
        if (m_Safety.version != (*ptr & -6))
        {
            AtomicSafetyHandle.CheckWriteAndThrowNoEarlyOut(m_Safety);
        }
    }

    [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
    private void FailOutOfRangeError(int index)
    {
        if (index < Length && (m_MinIndex != 0 || m_MaxIndex != Length - 1))
        {
            throw new IndexOutOfRangeException($"Index {index} is out of restricted IJobParallelFor range [{m_MinIndex}...{m_MaxIndex}] in ReadWriteBuffer.\n" + "ReadWriteBuffers are restricted to only read & write the element at the job index. You can use double buffering strategies to avoid race conditions due to reading & writing in parallel to the same elements from a job.");
        }

        throw new IndexOutOfRangeException($"Index {index} is out of range of '{Length}' Length.");
    }

    [WriteAccessRequired]
    public unsafe void CopyFrom(NativeSlice<T> slice)
    {
        if (Length != slice.Length)
        {
            throw new ArgumentException($"slice.Length ({slice.Length}) does not match the Length of this instance ({Length}).", "slice");
        }

        UnsafeUtility.MemCpyStride(this.GetUnsafePtr(), Stride, slice.GetUnsafeReadOnlyPtr(), slice.Stride, UnsafeUtility.SizeOf<T>(), m_Length);
    }

    [WriteAccessRequired]
    public unsafe void CopyFrom(T[] array)
    {
        if (Length != array.Length)
        {
            throw new ArgumentException($"array.Length ({array.Length}) does not match the Length of this instance ({Length}).", "array");
        }

        GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
        IntPtr intPtr = gCHandle.AddrOfPinnedObject();
        int num = UnsafeUtility.SizeOf<T>();
        UnsafeUtility.MemCpyStride(this.GetUnsafePtr(), Stride, (void*)intPtr, num, num, m_Length);
        gCHandle.Free();
    }

    public unsafe void CopyTo(NativeArray<T> array)
    {
        if (Length != array.Length)
        {
            throw new ArgumentException($"array.Length ({array.Length}) does not match the Length of this instance ({Length}).", "array");
        }

        int num = UnsafeUtility.SizeOf<T>();
        UnsafeUtility.MemCpyStride(array.GetUnsafePtr(), num, this.GetUnsafeReadOnlyPtr(), Stride, num, m_Length);
    }

    public unsafe void CopyTo(T[] array)
    {
        if (Length != array.Length)
        {
            throw new ArgumentException($"array.Length ({array.Length}) does not match the Length of this instance ({Length}).", "array");
        }

        GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
        IntPtr intPtr = gCHandle.AddrOfPinnedObject();
        int num = UnsafeUtility.SizeOf<T>();
        UnsafeUtility.MemCpyStride((void*)intPtr, num, this.GetUnsafeReadOnlyPtr(), Stride, num, m_Length);
        gCHandle.Free();
    }

    public T[] ToArray()
    {
        T[] array = new T[Length];
        CopyTo(array);
        return array;
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(ref this);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new Enumerator(ref this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public unsafe bool Equals(NativeSlice<T> other)
    {
        return m_Buffer == other.m_Buffer && m_Stride == other.m_Stride && m_Length == other.m_Length;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        return obj is NativeSlice<T> && Equals((NativeSlice<T>)obj);
    }

    public unsafe override int GetHashCode()
    {
        int num = (int)m_Buffer;
        num = (num * 397) ^ m_Stride;
        return (num * 397) ^ m_Length;
    }

    public static bool operator ==(NativeSlice<T> left, NativeSlice<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NativeSlice<T> left, NativeSlice<T> right)
    {
        return !left.Equals(right);
    }
}

