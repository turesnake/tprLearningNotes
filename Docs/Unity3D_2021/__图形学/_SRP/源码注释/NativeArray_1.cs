#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Internal;



namespace Unity.Collections
{

    /* 
        尽管 NativeArray 自己是 struct, 但它本质只是一个管理器, 真正的数据存储在 原生 c++ 代码负责的内存中. 
        而 NativeArray 自己记录了一些 和 <T> 类型相关的信息, 同时给 c# 托管代码 提供了安全访问这些 c++原生内存 的方式. 

        所以, 可以将一个NativeArray 变量 赋值给另一个 NativeArray 变量. 我猜它们应该是执行了 值复制 操作. 
        但因为实际复制的数据不大, 所以不存在性能问题. 

        分配的 NativeArray 资源, 是需要用户 手动释放的: Dispose(). 因这些资源无非被 c# CG 回收.  

    */ 

    // 摘要:
    //     A NativeArray exposes a buffer of native memory to managed code, making it possible
    //     to share data between managed and native without marshalling costs.

    [DebuggerDisplay("Length = {Length}")]
    [DebuggerTypeProxy(typeof(Collections.NativeArrayDebugView<>))]
    [DefaultMember("Item")]
    [NativeContainer]
    [NativeContainerSupportsDeallocateOnJobCompletion]
    [NativeContainerSupportsDeferredConvertListToArray]
    [NativeContainerSupportsMinMaxWriteRestriction]
    public struct NativeArray<T> : IDisposable, IEnumerable<T>, IEnumerable, IEquatable<NativeArray<T>> where T : struct
    {
        public NativeArray(T[] array, Allocator allocator);
        public NativeArray(NativeArray<T> array, Allocator allocator);
        public NativeArray(int length, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory);

        /* 
            索引器, 可用下标来快捷访问 各个 T元素. 
            注意: 返回的是 T的值, 而不是引用
        */
        public T this[int index] { get; set; }
        
        public bool IsCreated { get; } // 检查本 NativeArray 是否拥有一个 已经分配好了的原生内存buffer
        public int Length { get; } // 当前 原生buffer中, T元素的个数


        /*  
            copy from src to dst. 
        */
        public static void Copy(NativeArray<T> src, NativeArray<T> dst, int length);
        public static void Copy(ReadOnly src, NativeArray<T> dst, int length);
        public static void Copy(T[] src, NativeArray<T> dst, int length);
        public static void Copy(NativeArray<T> src, T[] dst, int length);
        public static void Copy(ReadOnly src, T[] dst, int length);
        public static void Copy(T[] src, int srcIndex, NativeArray<T> dst, int dstIndex, int length);
        public static void Copy(ReadOnly src, int srcIndex, NativeArray<T> dst, int dstIndex, int length);
        public static void Copy(NativeArray<T> src, T[] dst);
        public static void Copy(NativeArray<T> src, int srcIndex, T[] dst, int dstIndex, int length);
        public static void Copy(ReadOnly src, int srcIndex, T[] dst, int dstIndex, int length);
        public static void Copy(NativeArray<T> src, int srcIndex, NativeArray<T> dst, int dstIndex, int length);
        public static void Copy(T[] src, NativeArray<T> dst);
        public static void Copy(ReadOnly src, T[] dst);
        public static void Copy(NativeArray<T> src, NativeArray<T> dst);
        public static void Copy(ReadOnly src, NativeArray<T> dst);


        public ReadOnly AsReadOnly();


        [WriteAccessRequired]
        public void CopyFrom(T[] array);
        [WriteAccessRequired]
        public void CopyFrom(NativeArray<T> array);
        public void CopyTo(NativeArray<T> array);
        public void CopyTo(T[] array);

        // 手动调用来释放 分配的原生内存资源
        [WriteAccessRequired]
        public void Dispose();
        public JobHandle Dispose(JobHandle inputDeps);


        public override bool Equals(object obj);
        public bool Equals(NativeArray<T> other);
        public Enumerator GetEnumerator();
        public override int GetHashCode();


        /* 
            同参数给定了 目标subarray 的 起始位置和长度
            return A view into the array that aliases the original array. Cannot be disposed.
            返回的是 一个针对 原生c++数组 的别名的视图 (???).  无法被清除.

            感觉不是将一组数据 复制出来.

        */
        public NativeArray<T> GetSubArray(int start, int length);


        /* 
            将本容器控制的 原生内存, 解释为另一种 元素类型 U, 

            若未提供参数: expectedTypeSize, 则要求 T 和 U 两个类型的 内存字节数 相同
            若提供了此参数, 则允许 U 和 T 的 内存字节数不同, 同时也允许 目标内存段中, 存储的 U 类型元素的个数, 
            和原来的 T类型元素的个数 不同.  (不够精确)
        */
        public NativeArray<U> Reinterpret<U>() where U : struct;
        public NativeArray<U> Reinterpret<U>(int expectedTypeSize) where U : struct;

        /* 
            从参数指定的位置开始 重解释 和 读取数据, 将其作为不同的类型 U

            返回:
                被读取的 U类型的 数据  (这么看好像只读取了一个 U元素)
        */
        public U ReinterpretLoad<U>(int sourceIndex) where U : struct;

        /* 
            从参数指定的位置开始 重解释 和 存储数据, 将其作为不同的类型 U
            参数: destIndex -- 起始位置
            参数: data      -- 要存入的 U元素 (这么看好像也只存入了一个 U元素)
        */
        public void ReinterpretStore<U>(int destIndex, U data) where U : struct;


        /* 
            转换并返回一个 T[] Array, (猜测是返回一个 托管类型的数组)
        */
        public T[] ToArray();

        public static bool operator ==(NativeArray<T> left, NativeArray<T> right);
        public static bool operator !=(NativeArray<T> left, NativeArray<T> right);

        [ExcludeFromDocs]
        public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
        {
            public Enumerator(ref NativeArray<T> array);

            public T Current { get; }

            public void Dispose();
            public bool MoveNext();
            public void Reset();
        }
        //
        // 摘要:
        //     NativeArray interface constrained to read-only operation.
        [DebuggerDisplay("Length = {Length}")]
        [DebuggerTypeProxy(typeof(Collections.NativeArrayReadOnlyDebugView<>))]
        [DefaultMember("Item")]
        [NativeContainer]
        [NativeContainerIsReadOnly]
        public struct ReadOnly
        {
            public T this[int index] { get; }

            public int Length { get; }

            public void CopyTo(T[] array);
            public void CopyTo(NativeArray<T> array);
            public NativeArray<U>.ReadOnly Reinterpret<U>() where U : struct;
            public T[] ToArray();
        }
    }
}

