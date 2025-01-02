using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class DrawEllipse
{ 

    // 绘制一个椭圆线框;
    // 参数 center_, rotation_ 可以是一个 transform 的;
    public static void DrawEllipseWireframe( Vector3 center_, Quaternion rotation_, float radiusX_, float radiusZ_, int segmentsNum_ = 24 )  
    {  
        float angleStep = 360f / segmentsNum_;  
        Vector3 previousPoint = center_ + rotation_ * new Vector3(radiusX_, 0, 0); // 使用旋转  
        for (int i = 1; i <= segmentsNum_; i++)  
        {  
            float angle = i * angleStep * Mathf.Deg2Rad;  
            Vector3 newPoint = center_ + rotation_ * new Vector3(Mathf.Cos(angle) * radiusX_, 0, Mathf.Sin(angle) * radiusZ_); // 在local XZ 平面上绘制椭圆  
            Gizmos.DrawLine(previousPoint, newPoint);  
            previousPoint = newPoint;  
        }  
    }

}







