using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    通用版的 Catmull-Rom, B-Spline 曲线; 可平滑各种用户自定义数据;
    用户自定义一个 数据类型 T, 它需要继承 ISplinesData<T>;

    此版本 实现了 预计算, 适合静态曲线, 运行时基于 t 值算平滑值 成本很低;

    https://www.youtube.com/watch?v=jvPPXbo87ds&list=PLeUKbKrkDo84cfuiE1UG_3K-ALVOA6b4L
    目前支持两种曲线:
    --  Catmull-Rom:    可穿过每个节点, 已经很平滑了, 但在运动速度上没有 B-Spline 平滑
    --  B-Spline        不能保证穿过每个节点, 但不管是形状还是运动速度, 都是最平滑的

    本类生成的是一条单一的 曲线线段, t:[0f,1f], 外部只需传入一个匀速递增的 t值, 就能遇到曲线上对应点的数据;
    ( 哪怕初始参数 nodes_ 的节点分布并不均匀, Catmull-Rom 和  B-Spline 也能让 t值对应点的运动速度足够平滑 )
*/


// 被平滑的数据 的基类
public interface ISplinesData<T>
{
    T Add(T a);
    T Add(T a, T b, T c);
    T Minus(T a);
    T Scale(float s);
}


public enum SplinesType 
{ 
    CatmullRom = 3,
    BSpline = 4 
}


// 曲线工具本体:
public class SplinesGeneric<T> 
                                where T:ISplinesData<T>, new()
{
    
    class CurveNode
    {
        public float t = 0f; // [0f,1f]
        public T data;
        public override string ToString()
        {
            return "data:" + data.ToString() + ", t:" + t;
        }
    }

    // 每段区间 预计算的参数 
    class NodeParams 
    {
        public T a0, a1, a2, a3;
    }
    
    List<CurveNode> curveNodes = new List<CurveNode>(); // totalNum+2 个
    List<NodeParams> preCalcNodeParams = new List<NodeParams>(); // totalNum 个


    public float min_t = 0f;
    public float max_t = 1f;

    SplinesType splinesType;


    static Matrix4x4 CatmullRomMatrix = new Matrix4x4(
        new Vector4(  0,  2,  0,  0  ) * 0.5f,
        new Vector4( -1,  0,  1,  0  ) * 0.5f,
        new Vector4(  2, -5,  4, -1 )  * 0.5f,
        new Vector4( -1,  3, -3,  1 )  * 0.5f
    ).transpose;

    static Matrix4x4 BSplineMatrix = new Matrix4x4(
        new Vector4(  1,  4,  1,  0  ) / 6f,
        new Vector4( -3,  0,  3,  0  ) / 6f,
        new Vector4(  3, -6,  3,  0 )  / 6f,
        new Vector4( -1,  3, -3,  1 )  / 6f
    ).transpose;


    public SplinesGeneric( List<T> nodes_, SplinesType splinesType_ )
    {
        Debug.Assert( nodes_.Count >= 3 );
        int totalNum = nodes_.Count;
        splinesType = splinesType_;

        T prefixData = nodes_[0].Add(  nodes_[0].Minus(nodes_[1]) );    // 额外的 前面一个点
        T suffixData = nodes_[totalNum-1].Add( nodes_[totalNum-1].Minus(nodes_[totalNum-2]) );  // 额外的 后面一个点

        curveNodes.Add( new CurveNode(){ data = prefixData, t = -1 } ); // 这个的 t 值无需精确
        for( int i=0; i<totalNum; i++ )
        {
            curveNodes.Add( new CurveNode(){ data = nodes_[i], t = i/(float)(totalNum-1) } );
        }
        curveNodes.Add( new CurveNode(){ data = suffixData, t = 2 } ); // 这个的 t 值无需精确

            // --- debug:
            // Debug.Log( "----- curveNodes: ------ min_t:" + min_t + ", max_t:" + max_t );
            // foreach( var e in curveNodes ) 
            // {
            //     Debug.Log( e.ToString() );
            // }
            // Debug.Log( "--------" );

        // ======
        for( int i=1; i<curveNodes.Count-2; i++ ) // l,r
        {
            preCalcNodeParams.Add( PreCalc(i) );
        }
    }


    // t_: [0f,1f] 映射到整条曲线
    public T Calc( float t_ )
    {
        Debug.Assert( t_ >= min_t && t_ <= max_t );

        int catmullRomNodesNum = curveNodes.Count;
        for( int i=1; i<catmullRomNodesNum-2; i++ ) // l,r
        {
            var lNode = curveNodes[i];
            var rNode = curveNodes[i+1];
            if( t_ >= lNode.t && t_ < rNode.t ) 
            {
                return DoCalc(i, t_);
            }
        }

        Debug.LogError( "一个也没找到, 有异常, t_= " + t_ );
        return new T();
    }

 
    public T DoCalc( int i_, float t_ )
    {
        t_= Remap( curveNodes[i_].t, curveNodes[i_+1].t, 0f, 1f, t_ );

        Debug.Log("i: " + i_ + ", t:" + t_);

        float t1 = t_;
        float t2 = t_*t_;
        float t3 = t_*t_*t_;

        var p = preCalcNodeParams[i_-1];
        return p.a0.Add(  p.a1.Scale(t1),  p.a2.Scale(t2),  p.a3.Scale(t3) );
    }


    NodeParams PreCalc( int i_ )
    {
        T p0 = curveNodes[i_-1].data;
        T p1 = curveNodes[i_  ].data;
        T p2 = curveNodes[i_+1].data;
        T p3 = curveNodes[i_+2].data;

        var mtx = ChooseMatrix(splinesType);
        T a0 =   p0.Scale(mtx[0,0]).Add(  p1.Scale(mtx[0,1]),  p2.Scale(mtx[0,2]),  p3.Scale(mtx[0,3]) );
        T a1 =   p0.Scale(mtx[1,0]).Add(  p1.Scale(mtx[1,1]),  p2.Scale(mtx[1,2]),  p3.Scale(mtx[1,3]) );
        T a2 =   p0.Scale(mtx[2,0]).Add(  p1.Scale(mtx[2,1]),  p2.Scale(mtx[2,2]),  p3.Scale(mtx[2,3]) );
        T a3 =   p0.Scale(mtx[3,0]).Add(  p1.Scale(mtx[3,1]),  p2.Scale(mtx[3,2]),  p3.Scale(mtx[3,3]) );
        return new NodeParams(){ a0=a0, a1=a1, a2=a2, a3=a3 };
    }


    static Matrix4x4 ChooseMatrix( SplinesType splinesType_ ) 
    {
        switch(splinesType_)
        {
            case SplinesType.CatmullRom:   return CatmullRomMatrix;
            case SplinesType.BSpline:      return BSplineMatrix;
            default:
                Debug.LogError("参数类型异常: " + splinesType_.ToString() );
                return CatmullRomMatrix;
        }
    }


    public static float Remap(float t1, float t2, float s1, float s2, float x)
    {
        return ((x - t1) / (t2 - t1) * (s2 - s1) + s1);
    }

}
