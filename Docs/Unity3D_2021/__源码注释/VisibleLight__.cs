#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        Holds data of a visible light.

        After "ScriptableRenderContext.Cull()" is done, 
        "CullingResults.visibleLights" will contain an array of lights that are visible.
        The visible light structure contains packed information for most commonly used Light variables, 
        and a VisibleLight.light reference to the Light component itself.



    */
    [UsedByNativeCodeAttribute]
    public struct VisibleLight //VisibleLight__
        : IEquatable<VisibleLight>
    {
        
        /*
            Accessor to Light component.  光源本光

            如果当前数据指向的光, 是粒子系统的光, 此变量会被设置为 null;
            可用这个规则来 识别是不是 粒子系统的光;
        */
        public Light light { get; }

        //  Light type. 
        //  enum: Spot, Directional, Point...
        public LightType lightType { get; set; }
        
        
        //  Light color multiplied by intensity.
        //  light color 乘以 intensity
        public Color finalColor { get; set; }

       
        //  Light's influence rectangle on screen.
        // 光的影响区域, 在屏幕上构成一个 矩阵;
        public Rect screenRect { get; set; }
        
        //     Light transformation matrix.
        public Matrix4x4 localToWorldMatrix { get; set; }
        

        //     Light range.  光的影响范围
        public float range { get; set; }
        
        
        /*
            Spot light angle.

            out 角度,
            inn 角度 可访问: "Light.innerSpotAngle"
        */
        public float spotAngle { get; set; }

       
        //     Light intersects near clipping plane.
        // 光的区域 是否和 近平面 相交
        public bool intersectsNearPlane { get; set; }
       

        //     Light intersects far clipping plane.
        // 光的区域 是否和 远平面 相交
        public bool intersectsFarPlane { get; set; }


        public bool Equals(VisibleLight other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(VisibleLight left, VisibleLight right);
        public static bool operator !=(VisibleLight left, VisibleLight right);
    }
}

