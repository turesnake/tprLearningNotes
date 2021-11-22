#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{

    /*
        Color space conversion mode of a RenderTexture.

        当app使用 gamma 颜色空间时, 啥转换都不存在, 本enum 的值 也不起任何作用;

        当app使用 linear 颜色空间时,
        类型为 non-HDR 的 render texture 会被认为是 sRGB 数据, (比如 "regular colors"), 
        而 frag shader 的输出值, 则是 线性颜色值,

        -- fs输出的数据(linear) 将会执行 linear->sRGB 转换后, 再写入 render texture
            毕竟上面说了, 是 non-HDR render texture;

        -- 如果想从 render texture 中获取数据(采样), rt 也会自动执行 sRGB->linear 转换;
            然后这个 linear数据 再去被采样;
            毕竟代码端 工作在 linear 空间; 
                 
        上面这个过程就是 "sRGB read-write mode";
        =========

        







and the Default mode matches that when linear color space is used. 

When this mode is set on a render texture, RenderTexture.sRGB will return true.


    */
    public enum RenderTextureReadWrite
    {


        /*
            Default "color space conversion" based on "project settings";

            当 app 使用 Linear 颜色空间时, 本变量等于 sRGB   模式
            当 app 使用 gamma 颜色空间时,  本变量等于 Linear 模式;
        */
        Default = 0,

        /*
            Render texture contains linear (non-color) data; don't perform color conversions on it.


        */
        Linear = 1,

        /*
            Render texture contains sRGB (color) data, perform Linear<->sRGB conversions on it.
        */
        sRGB = 2
    }
}

