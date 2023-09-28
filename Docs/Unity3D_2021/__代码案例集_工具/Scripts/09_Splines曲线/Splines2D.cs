using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;






// 静态曲线: Catmull-Rom, B-Spline [预计算版-高性能]
// 外部提供一串 vector2 点(顺序由外部维护), 然后拿一个 t:[0f,1f] 来获得中间曲线点


public class Splines2D
{

    public enum Type { 
        CatmullRom = 3,
        BSpline = 4 
    }

    public class CatmullRomNode
    {
        public float t = 0f; // [0f,1f]
        public Vector2 pos;
        public override string ToString()
        {
            return "pos:" + pos.ToString() + ", t:" + t;
        }
    }

    // 每段区间 预计算的参数 
    public class NodeParams 
    {
        public Vector2 a0, a1, a2, a3;
    }
    
    List<CatmullRomNode> catmullRomNodes = new List<CatmullRomNode>(); // totalNum+2 个
    List<NodeParams> preCalcNodeParams = new List<NodeParams>(); // totalNum 个


    public float min_t = 0f;
    public float max_t = 1f;

    Type type;


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


    public Splines2D( List<Vector2> nodes_, Type type_ )
    {
        Debug.Assert( nodes_.Count >= 3 );
        int totalNum = nodes_.Count;
        type = type_;

        Vector2 prefixPos = nodes_[0] + (nodes_[0] - nodes_[1]);
        Vector2 suffixPos = nodes_[totalNum-1] + (nodes_[totalNum-1] - nodes_[totalNum-2]);

        catmullRomNodes.Add( new CatmullRomNode(){ pos = prefixPos, t = -1 } ); // 这个的 t 值无需精确
        for( int i=0; i<totalNum; i++ )
        {
            catmullRomNodes.Add( new CatmullRomNode(){ pos = nodes_[i], t = i/(float)(totalNum-1) } );
        }
        catmullRomNodes.Add( new CatmullRomNode(){ pos = suffixPos, t = 2 } ); // 这个的 t 值无需精确

            // --- debug:
            Debug.Log( "----- catmullRomNodes: ------ min_t:" + min_t + ", max_t:" + max_t );
            foreach( var e in catmullRomNodes ) 
            {
                Debug.Log( e.ToString() );
            }
            Debug.Log( "--------" );


        // ======
        for( int i=1; i<catmullRomNodes.Count-2; i++ ) // l,r
        {
            preCalcNodeParams.Add( PreCalc(i) );
        }

    }


    // t_: [0f,1f] 映射到整条曲线
    public Vector2 Calc( float t_ )
    {
        int catmullRomNodesNum = catmullRomNodes.Count;

        Debug.Assert( t_ >= min_t && t_ <= max_t );


        for( int i=1; i<catmullRomNodesNum-2; i++ ) // l,r
        {
            var lNode = catmullRomNodes[i];
            var rNode = catmullRomNodes[i+1];
            if( t_ >= lNode.t && t_ < rNode.t ) 
            {
                return KK(i, t_);
            }
        }

        Debug.LogError( "一个也没找到, 有异常, t_= " + t_ );
        return Vector2.zero;
    }


    public Vector2 KK( int i_, float t_ )
    {
        t_= Remap( catmullRomNodes[i_].t, catmullRomNodes[i_+1].t, 0f, 1f, t_ );

        Debug.Log("i: " + i_ + ", t:" + t_);

        float t1 = t_;
        float t2 = t_*t_;
        float t3 = t_*t_*t_;

        var mtx = ChooseMatrix(type);

        var p = preCalcNodeParams[i_-1];
        return p.a0 + t1*p.a1 + t2*p.a2 + t3*p.a3;
    }




    public NodeParams PreCalc( int i_ )
    {
        Vector2 p0 = catmullRomNodes[i_-1].pos;
        Vector2 p1 = catmullRomNodes[i_  ].pos;
        Vector2 p2 = catmullRomNodes[i_+1].pos;
        Vector2 p3 = catmullRomNodes[i_+2].pos;

        var mtx = ChooseMatrix(type);

        Vector2 a0 =   mtx[0,0]*p0 + mtx[0,1]*p1 + mtx[0,2]*p2 + mtx[0,3]*p3 ;
        Vector2 a1 =   mtx[1,0]*p0 + mtx[1,1]*p1 + mtx[1,2]*p2 + mtx[1,3]*p3 ;
        Vector2 a2 =   mtx[2,0]*p0 + mtx[2,1]*p1 + mtx[2,2]*p2 + mtx[2,3]*p3 ;
        Vector2 a3 =   mtx[3,0]*p0 + mtx[3,1]*p1 + mtx[3,2]*p2 + mtx[3,3]*p3 ;

        return new NodeParams(){ a0=a0, a1=a1, a2=a2, a3=a3 };
    }


    static Matrix4x4 ChooseMatrix( Type type_ ) 
    {
        switch(type_)
        {
            case Type.CatmullRom:   return CatmullRomMatrix;
            case Type.BSpline:      return BSplineMatrix;
            default:
                Debug.LogError("参数类型异常: " + type_.ToString() );
                return CatmullRomMatrix;
        }
    }


     public static float Remap(float t1, float t2, float s1, float s2, float x)
    {
        return ((x - t1) / (t2 - t1) * (s2 - s1) + s1);
    }

}
