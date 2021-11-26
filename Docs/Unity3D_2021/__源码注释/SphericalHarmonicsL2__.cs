#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Reflection;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Spherical harmonics up to the second order (3 bands, 9 coefficients).
        unity 将球谐用于 light probe 和 environment lighting.;

    */
    [DefaultMember("Item")]
    [NativeHeaderAttribute("Runtime/Export/Math/SphericalHarmonicsL2.bindings.h")]
    [UsedByNativeCodeAttribute]
    public struct SphericalHarmonicsL2 /*SphericalHarmonicsL2__*/
        : IEquatable<SphericalHarmonicsL2>
    {


        /*
            Access individual SH coefficients.

            使用两个下标来访问 具体的某个 球谐系数;
            --
                系数 rgb:   
                    [0,2] 只有三种
                系数 coefficient:
                    [0,8] 9种
        */
        public float this[int rgb, int coefficient] { get; set; }

        /*
            摘要:
            Add ambient lighting to probe data.

            如果球谐被用来计算 光照信息, 本函数可用来将 ambient light 添加进 probe data;

            tpr:
                为啥这个 ambient light 只有颜色信息 ? 没有方向 ?
                感觉就是一个 各方向都均等的 环境颜色;
        */
        public void AddAmbientLight(Color color);

        /*
            摘要:
            Add directional light(定向光) to probe data.
        
            如果球谐被用来计算 光照信息, 本函数可用来将一个 定向光 添加进 probe data;
            猜测:
                此处的 "directional light" 应该被翻译成 定向光, 而不是 平行光;
                因为一个 球谐探针 是一个点, 它没有体积, 不管是 平行光, point光, spot光,
                照到这个 探针上, 都可被简化为: 一个光照值, 和一个照射方向;

                也就是说, 本函数可以同时接收场景中的 平行光, point光, spot光;

                但是用这个方法来接受 environment cubemap 这种每个方向光照都不同的信息,
                可能不能直接用本函数来实现 ?

            参数:
            direction:
                平行光的方向
            color: 
                平行光的颜色
            intensity:
                平行光的强度
        */
        public void AddDirectionalLight(Vector3 direction, Color color, float intensity);


        
        // 摘要:
        //     Clears SH probe to zero.
        public void Clear();


        public override bool Equals(object other);
        public bool Equals(SphericalHarmonicsL2 other);


        /*
            针对参数 directions 中的每一个 方向向量(已经归一化的), 将其传入球谐, 解算出对应的一个 颜色值,
            将这个颜色值存入 参数 results 对应的位置中;

            directions 和 results 元素个数必须相等;

            参数:
            directions:
                Normalized directions for which the spherical harmonics are to be evaluated.
                里面的每一个 方向向量 都必须归一化
            
            results:
                 Output array for the evaluated values of the corresponding directions.
        */
        public void Evaluate(Vector3[] directions, Color[] results);



        public override int GetHashCode();

        public static SphericalHarmonicsL2 operator +(SphericalHarmonicsL2 lhs, SphericalHarmonicsL2 rhs);
        public static SphericalHarmonicsL2 operator *(SphericalHarmonicsL2 lhs, float rhs);
        public static SphericalHarmonicsL2 operator *(float lhs, SphericalHarmonicsL2 rhs);
        public static bool operator ==(SphericalHarmonicsL2 lhs, SphericalHarmonicsL2 rhs);
        public static bool operator !=(SphericalHarmonicsL2 lhs, SphericalHarmonicsL2 rhs);
    }
}

