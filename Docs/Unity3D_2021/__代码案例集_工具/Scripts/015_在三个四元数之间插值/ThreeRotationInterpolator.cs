using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


/*
    演示如何计算在 三个四元数之间的 插值
*/
public class ThreeRotationInterpolator : MonoBehaviour
{  
    public MeshRenderer MA, MB, MC, MP;
    Transform Atf,Btf,Ctf,Ptf;  
    Color colorA, colorB, colorC;



    void Start() 
    {
        Atf = MA.transform;
        Btf = MB.transform;
        Ctf = MC.transform;
        Ptf = MP.transform;
        colorA = MA.material.GetColor("_BaseColor");
        colorB = MB.material.GetColor("_BaseColor");
        colorC = MC.material.GetColor("_BaseColor");
    }

    void Update()  
    {  
        ColorLerp();
        DoRotationLerp();
    }

    
    void ColorLerp()  
    {  
        // ======== 计算 Barycentric Coordinates: wa, wb, wc: ========
        Vector3 a = Atf.position;
        Vector3 b = Btf.position;
        Vector3 c = Ctf.position;
        Vector3 p = Ptf.position;
        //计算距离 
        float distanceA = Vector3.Distance(p, a);  
        float distanceB = Vector3.Distance(p, b);  
        float distanceC = Vector3.Distance(p, c);  
        //计算权重（反距离）  
        float wa =1f / distanceA;  
        float wb =1f / distanceB;  
        float wc =1f / distanceC;  
        //wc = 0f;
        //归一化权重 
        float totalWeight = wa + wb + wc;  
        wa /= totalWeight;  
        wb /= totalWeight;  
        wc /= totalWeight;  
        // ======== 插值颜色: ========
        Color color = wa * colorA + wb * colorB + wc * colorC;  
        MP.material.SetColor("_BaseColor", color);
    }  


    void DpRotationLerp()  
    {
        Ptf.rotation = RotationLerp( Atf.rotation, Btf.rotation, Ctf.rotation, Atf.position, Btf.position, Ctf.position, Ptf.position );
    }


    // 三个四元数之间的 插值 (基于 重心权重)
    // !!! 这不是真正的 三个四元数的插值;  但它是我目前实践出来的最好的, 使用此法后, 当点p在穿过两个三角形的边界时, 并不会发生抖动;
    // 问题在于: 当p连续穿过数个三角形时, 你能明显发现, 每个三角形内部提供的 插值结果都是独立的; 并不具备宏观的连续性;
    // 这会导致 p 的旋转有点不均匀,  有点奇怪 (虽然没有抖动);  也许可以叠加别的算法来获得 更平滑的效果...
    Quaternion RotationLerp( Quaternion ra_, Quaternion rb_, Quaternion rc_, Vector3 a_, Vector3 b_, Vector3 c_, Vector3 p_ )  
    {
        // ======== 计算 Barycentric Coordinates: wa, wb, wc: ========
        float area0 = Area( a_, b_, c_ );
        float areaABP = Area( a_, b_, p_ );
        float areaBCP = Area( b_, c_, p_ );
        float areaCAP = Area( c_, a_, p_ );
        float wa = areaBCP / area0;
        float wb = areaCAP / area0;
        float wc = areaABP / area0;

        // 这不是真正的 对称的 算法, 但它至少在 p穿越三角形边界时 不会抖动...
        // 它至少 不精确地在三个 q 之间插值,  也许未来可以实践出更好的 插值方式;
        Quaternion rAB  = Quaternion.Slerp( ra_, rb_,  wb / (wa + wb) ); 
        Quaternion rr   = Quaternion.Slerp( rAB, rc_,  wc ); 
        return rr
    }

    float Area(Vector3 p1, Vector3 p2, Vector3 p3)  
    {  
        return Vector3.Cross(p2 - p1, p3 - p1).magnitude * 0.5f; 
    } 

}


