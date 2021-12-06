#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        This struct describes the methods to "sort objects" during rendering.

        按描述, 只与 "物体排序" 相关;
    */
    public struct SortingSettings //SortingSettings__
        : IEquatable<SortingSettings>
    {
        

        /*
            摘要:
            Create a sorting settings struct.
            
            参数:
            camera:
                camera.transparencySortMode (变量) 被用来选择使用下述某一种排序方式:
                    -- orthographic based sorting.
                    -- distance based sorting.

                在 Camera class 文件中有详细描述;
        */
        public SortingSettings(Camera camera);



        /*
            摘要:
            Used to calculate the distance to objects.

            结合 cameraPosition 一起使用, 
            用于 物体排序
        */
        public Matrix4x4 worldToCameraMatrix { get; set; }
        public Vector3 cameraPosition { get; set; }

        /*
            摘要:
            Used to calculate distance to objects, by comparing the positions of objects to this axis.

            当 camera.transparencySortMode (变量) 选择了 CustomAxis 时, 
            此模式所依赖的 axis 信息, 就在本值中设置;
            最终用于 物体排序

            还需结合上面的 worldToCameraMatrix, cameraPosition 一起使用
        */
        public Vector3 customAxis { get; set; }


        /*
            摘要:
            What kind of sorting to do while rendering.
    
            物体排序 用的规则; 具体信息见对应 class 的翻译文件
            
            此值默认为 None; (不对物体执行任何形式的 排序 )

            catlike srp 中显式地改写过此值;

            enum: "None, SortingLayer, RenderQueue... CommonOpaque, CommonTransparent";
        */
        public SortingCriteria criteria { get; set; }
        

        /*
            摘要:
            Type of sorting to use while rendering.

            猜测:
                这东西似乎和 camera.transparencySortMode 是重复概念, 只不过两者都有一个不同的 enum class;
                猜测是在 本类的 构造函数中, 从 camera 中获得排序信息后,
                转而存储在此变量中;
                    而且做了一定的简化处理; 种类更少了;

                既然如此, 通常我们无需直接改写此值;

                在 urp.11.0\Runtime\2D\Passes\Render2DLightingPass.cs 中见过此值被改写;

            enum:
            -- Perspective:
                    Objects will be sorted based on "distance from camera pos to the object center".
            -- Orthographic:
                    Objects will be sorted based on "distance along the camera's view direction".
            -- CustomAxis:
                    Objects are sorted based on "distance along a custom axis". 
        */
        public DistanceMetric distanceMetric { get; set; }



        public bool Equals(SortingSettings other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(SortingSettings left, SortingSettings right);
        public static bool operator !=(SortingSettings left, SortingSettings right);
    }
}
