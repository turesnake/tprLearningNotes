#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Light probe interpolation type.

        插值类型;
    */
    public enum LightProbeUsage
    {
        
        // 摘要:
        //     Light Probes are not used. The Scene's "ambient probe" is provided to the shader.
        Off = 0,

        /*
            摘要:
            Simple light probe interpolation is used.

            如果场景中设置了 烘焙好的 lightprobes, 那就会在本物体所在的 posWS 处生成一个 插值出来的 lightprobe;
            (基于 四面体插值, 实际上存储的是一个 球谐数据 )

            针对 built-in shader, unity 会自动生成一个 uniform 变量;
            Surface shaders use this information automatically. 

            如果是自定义的 非Surface shader, 
            可以在 vs, fs 中使用  ShadeSH9(normalWS) 函数来访问本物体的那个 插值出来的lightprobe 数据,
            并计算出 对应方向的 颜色值;
        */
        BlendProbes = 1,


        /*
            摘要:
            Uses a 3D grid of interpolated light probes. LPPV

            LPPV 组件可以放在本go 体内, 也可以放在另一个 go体内, (然后绑定之);
            为了使用后者, 必须使用 inspector 中的 Proxy Volume Override" 槽来绑定
            那个携带了 LPPV 组件的go;

            Surface shaders use the information associated with the proxy volume automatically. 

            在自定义shader 中, 可在 fs 中使用 ShadeSHPerPixel() 函数来获得 本物体本frag 的 LPPV 信息;
        */
        UseProxyVolume = 2,


        /*
            摘要:
            The "light probe shader uniform values" are extracted from the "material property block" set on the renderer.

            Property:
                unity_SHAr, unity_SHAg, unity_SHAb, unity_SHBr, unity_SHBg, unity_SHBb and unity_SHC will 
            be set to zero if they are not part of the MaterialPropertyBlock.

            Property "unity_ProbesOcclusion" will be calculated as in normal lighting 
            if it is not part of the MaterialPropertyBlock.

            注意:
            使用别的 pos 的 lightprobe 将导致错误的 渲染结果;
            尤其是当 point光, spot光 这种 local lights 被使用时;

            This mode is more useful when drawing instanced objects with Graphics.DrawMeshInstanced(), 
            (就是 GPU Instancing 那个)

            where the light probe data is 预计算的 and provided as arrays.
        */
        CustomProvided = 4
    }
}

