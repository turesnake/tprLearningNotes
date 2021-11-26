#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        "LODGroup" (class) culling parameters.

        暂未看出它的用途,,,
    */
    public struct LODParameters : IEquatable<LODParameters>//LODParameters__
    {
        
        // 摘要:
        //     Indicates whether camera is orthographic.
        public bool isOrthographic { get; set; }
        

        // 摘要:
        //     Camera position.
        public Vector3 cameraPosition { get; set; }
        

        // 摘要:
        //     Camera's field of view.
        public float fieldOfView { get; set; }
        

        /*
            摘要:
            Orhographic camera size.
            camera 被设置为 正交后, inspector 上会多出来一个 Size 变量, 就是此处的值:
                "the vertical size of the camera view"
        */    
        public float orthoSize { get; set; }
        

        /*
            摘要:
            Rendering view height in pixels.
            猜测:
                camera 取景框 height 值 (pix为单位)
        */ 
        public int cameraPixelHeight { get; set; }




        public bool Equals(LODParameters other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(LODParameters left, LODParameters right);
        public static bool operator !=(LODParameters left, LODParameters right);
    }
}

