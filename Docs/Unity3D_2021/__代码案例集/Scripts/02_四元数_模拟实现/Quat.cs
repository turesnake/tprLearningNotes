using UnityEngine;

// 原作者: 知乎: nice time

public struct Quat
{
    public enum RotateOrder
    {
        XYZ,
        YXZ,
        ZXY,    // unity默认顺序
        XZY,
        YZX,
        ZYX
    }//旋转顺序 unity默认是ZXY

    public float x,y,z,w; // 实部 放后面

    public Quat(Quaternion Q):this(new Vector4(Q.x,Q.y,Q.z,Q.w)){}//把unity内置的四元数转换成我的四元数 用来调试用的

    public Quaternion Quaternion()
    {
        return new Quaternion(x,y,z,w);
    }//Debug测试用的

    public static Quat Identity=new Quat(0,0,0,1);
    public Vector3 xyz
    {
        get
        {
            return new Vector3(x,y,z);
            
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
        }
    }
    public  Quat(Vector4 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
        this.w = v.w;
    }
    public Quat(float x, float y, float z, float w) : this(new Vector4(x, y, z, w)) {}
    public Quat(Vector3 xyz, float W):this(new Vector4(xyz.x,xyz.y,xyz.z,W)){}
   
    public static Quat FromEular(Vector3 eular,RotateOrder order=RotateOrder.ZXY)
    {
        const float Deg2Rad =   Mathf.PI/(float)180;
        float Cx =Mathf.Cos(eular.x/2*Deg2Rad);
        float Cy =Mathf.Cos(eular.y/2*Deg2Rad);
        float Cz =Mathf.Cos(eular.z/2*Deg2Rad);
                                                                                                                                      
        float Sx =Mathf.Sin(eular.x/2*Deg2Rad);
        float Sy =Mathf.Sin(eular.y/2*Deg2Rad);
        float Sz =Mathf.Sin(eular.z/2*Deg2Rad);
        
        Quat qX=new Quat(Sx,0,0,Cx);
        Quat qY=new Quat(0,Sy,0,Cy);
        Quat qZ=new Quat(0,0,Sz,Cz);
        Quat result=Quat.Identity;
        switch (order)
        {
            case RotateOrder.XYZ:
                result=CreatQuatFromAxis(qZ,qY,qX);//旋转时自己的轴系也跟着旋转 要反着来
                break;
            case RotateOrder.XZY:
                result=CreatQuatFromAxis(qY,qZ,qX);
                break;
            case RotateOrder.YXZ:
                result=CreatQuatFromAxis(qZ,qX,qZ);
                break;
            case RotateOrder.YZX:
                result=CreatQuatFromAxis(qX,qZ,qY);
                break;
            case RotateOrder.ZXY:
                result=CreatQuatFromAxis(qY,qX,qZ);
                break;
            case RotateOrder.ZYX:
                result=CreatQuatFromAxis(qX,qY,qZ);
                break;
        }
        return result;
    }//欧拉角转四元数  unity默认旋转顺序是ZXY
    static Quat  CreatQuatFromAxis(Quat qx,Quat qy,Quat qz)
    {
        return qx*qy*qz;
    }
     public override string ToString()
     {
         return string.Format("{0} {1} {2} {3}",x,y,z,w);
     }
     public override bool Equals(object obj)
     {
         if (obj is Quat)
         {
             if ((Quat)obj==this)
             {
                 return true;
             }
         }
         return false;
     }

     
     // 其实就是两个 四元数 的常规的 乘法运算, 单却能实现 "旋转" 之上的 "旋转"
     public static Quat operator*(Quat q1,Quat q2)
     {
         // 实部
         float w = q1.w * q2.w - Vector3.Dot(q1.xyz, q2.xyz);
         // 虚部
         Vector3 xyz = q1.w * q2.xyz + q2.w * q1.xyz + Vector3.Cross(q1.xyz, q2.xyz);
         return new  Quat(xyz, w);
     }//重载乘法 Graßmann


     public static Quat operator*(Quat q1,Quaternion q2)
     {
         return q1*new Quat(q2);
     }//重载乘法 Graßmann

     public static Quat operator*(Quat q1,float scale)
     {
         return new  Quat(q1.xyz*scale, q1.w*scale);
     }//重载乘法 倍增


     public static Vector3 operator*(Quat q1,Vector3 dir)//重载乘法 某个轴绕四元数旋转后得到新方向
     {
         Quat qDir=new Quat(dir,0);
         Quat result = q1 * qDir * q1.Adjoint();//得保证q是规范化的
         return result.xyz;
     }


     public static Quat operator/(Quat q1,Quat q2)
     {
         return q1 * Inverted(q2);
     }//重载除法
     public static bool operator==(Quat q1, Quat q2)
     {
         if (q1.x == q2.x && q1.y == q2.y && q1.z == q2.z && q1.w == q2.w) return true;
         return false;
     }//重载等于
     public static bool operator!=(Quat q1, Quat q2)
     {
         if (q1.x != q2.x || q1.y != q2.y || q1.z != q2.z || q1.w != q2.w) return true;
         return false;
     }//重载不等于
     public static Quat operator +(Quat q1, Quat q2)
     {
         return new Quat(q1.xyz+q2.xyz,q1.w+q2.w);
     }//重载加法

     public static Quat operator -(Quat q1, Quat q2)
     {
         return new Quat(q1.xyz-q2.xyz,q1.w-q2.w);
     }//重载减法

     public static Quat Inverted(Quat q)//求逆
     {
         float q2 =MagnitudeSqr(q);//q的模长的平方 如果是单位四元数 这里直接等于1
         Quat qAdjoint=Adjoint(q);
         return new Quat(qAdjoint.xyz/q2,qAdjoint.w/q2);//返回四元数的逆
     }

     public static float Dot(Quat q1, Quat q2)//四元数点乘的绝对值越大，代表其方向越相近。
     {
         return q1.x * q2.x + q1.y* q2.y + q1.z* q2.z + q1.w* q2.w;
         
     }

     public static Quat Adjoint(Quat q)//求共轭四元数
     {
         return new Quat(-q.xyz,q.w);
     }

     public Quat Adjoint()
     {
         return Adjoint(this);
     }//求共轭

     public Quat Invert()
     {
         return Inverted(this);
     }//求逆

    
     public static float MagnitudeSqr(Quat q)//模长平方
     {
         return Dot(q, q);// q.x*q.x+q.y*q.y+q.z*q.z+q.w*q.w;
     }

     public float MagnitudeSqr()//模长平方
     {
         float S=MagnitudeSqr(this);
         return S;
     }

     public float Magnitude()//模长
     {
         return Mathf.Sqrt(MagnitudeSqr());
     }

     public static  Quat Normalize(Quat q)
     {
         float Length=q.Magnitude();
         if ((double) Length > 9.99999974737875E-06)
         {
             Vector3 xyz = q.xyz / Length;
             float w = q.w / Length;
             return new Quat(xyz,w);
         }
         else
         {
             return Quat.Identity;
         }
     }//规范化

      public void Normalized()
     {
         Quat Q = Normalize(this);
         xyz = Q.xyz;
         w = Q.w;
     }

     public static Quat RotateAxisByAngle(float Angle, Vector3 axis) {
         float sin = Mathf.Sin(Angle/2*(Mathf.PI/180));
         float cos= Mathf.Cos(Angle/2*(Mathf.PI/180));
         return new Quat(sin*axis,cos);
     }//绕着某个轴转某个角度 换算成四元数

     public static Quat FromToRotation(Vector3 fromDirection,Vector3 toDirection)
     {
         if (fromDirection==Vector3.zero||toDirection==Vector3.zero)return Quat.Identity;
    
         fromDirection = fromDirection.normalized;
         toDirection = toDirection.normalized;
         if (fromDirection==toDirection)return Quat.Identity;
      
         Vector3 aixs = Vector3.Cross(fromDirection, toDirection);//叉乘的aixs的模长即为正弦值
         float sinThelta = aixs.magnitude;
         float cosThelta = Vector3.Dot(fromDirection, toDirection);
         float sinHalfThelta = Mathf.Sqrt((1 - cosThelta) / 2);//计算sin半角 可以避免cos半角的取正负号问题
         float cosHalfThelta = sinThelta / (2 * sinHalfThelta);
         aixs.Normalize();//规范化一下
         return new Quat(sinHalfThelta*aixs,cosHalfThelta);
     }//输入2个方向 转四元数

     public  void ToAngleAxis(out float angle, out Vector3 axis)
     {
         Normalized();
         float rad=Mathf.Acos(w) * 2;
         angle = rad * 180 / Mathf.PI;
         float sinHalfThlta = Mathf.Sin(rad / 2);
         axis=sinHalfThlta==0?new Vector3(1,0,0):xyz/sinHalfThlta;
     }//四元数转角度和轴向

     public static Quat Lerp(Quat quat1, Quat quat2, float t)//普通插值
     {
         t = Mathf.Clamp01(t);
         return Quat.Normalize(quat1*(1-t)+quat2*t);
     }

     public static Quat Slerp(Quat quat1, Quat quat2, float t)//球面插值
     {
         t = Mathf.Clamp01(t);
         float dot = Dot(quat1, quat2);
         if (dot<0) 
         {
             quat1 *= -1;//如果点乘为负 是钝角 说明走的是长的路径 其中任意一个取反即可
             dot = Dot(quat1, quat2);
         }
         float thelta = Mathf.Acos(dot);
         if((double)thelta < 9.99999974737875E-06 )//如果夹角太小
         {
             return Lerp(quat1, quat2, t);
         }
         else
         {
             float a = Mathf.Sin((1 - t) * thelta) / Mathf.Sin(thelta);
             float b =  Mathf.Sin( t * thelta) / Mathf.Sin(thelta);
             return quat1 * a + quat2 * b;
         }
     }

}