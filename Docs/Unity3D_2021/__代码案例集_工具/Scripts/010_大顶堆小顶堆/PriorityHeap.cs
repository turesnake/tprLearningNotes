using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Tools
{



// 大顶堆/小顶堆 元素接口:
public interface IHeapNode<T>
{
    // 大顶堆: self > b
    // 小顶堆: b > self
    bool BigThan(T b); 

    // 大顶堆: 返回最小值
    // 小顶堆: 返回最大值
    T MaxValue();
}



// 大顶堆/小顶堆
// 无法保证 同权重元素之间的顺序
class PriorityHeap<T> 
                where T:IHeapNode<T>
{
    List<T> heap = new List<T>();

    public PriorityHeap( List<T> datas_ ) 
    {
        if( datas_ == null || datas_.Count == 0 )
        {
            return;
        }
        heap.Add( datas_[0] );
        for( int i=1; i<datas_.Count; i++ )
        {
            Add(datas_[i]);
        }
    } 

    public int GetNum() 
    {
        return heap.Count;
    }

    public void Add( T val ) 
    {
        heap.Add(val);
        int n = heap.Count-1;
        int p = (n-1)/2;

        while( n>0 && heap[n].BigThan(heap[p]) ) 
        {
            (heap[p], heap[n]) = (heap[n], heap[p]); //swap 
            n = p;
            p = (n-1)/2;
        }
    }

    public T PeekTop() 
    {
        Debug.Assert( GetNum() > 0 );
        return heap[0];
    }

    public T PopTop() 
    {
        Debug.Assert( GetNum() > 0 );
        //---
        int idx = heap.Count-1;
        (heap[0], heap[idx]) = (heap[idx], heap[0]); //swap

        var retCache = heap[idx];
        heap.RemoveAt( idx );
        idx--;// new tail ent

        int n = 0;
        int l;
        int r;
        while( 2*n < idx )
        {
            l = 2*n+1;
            r = 2*n+2;
            T lv = (l<=idx) ? heap[l] : heap[l].MaxValue();
            T rv = (r<=idx) ? heap[r] : heap[l].MaxValue();
            int tgt = (lv.BigThan(rv)) ? l : r; 
            //---
            if( !(heap[tgt].BigThan(heap[n])) ) // heap[n] >= heap[tgt]
            {
                break;
            }
            (heap[n], heap[tgt]) = (heap[tgt], heap[n]);
            n = tgt;
        }
        return retCache;
    }
}

}

