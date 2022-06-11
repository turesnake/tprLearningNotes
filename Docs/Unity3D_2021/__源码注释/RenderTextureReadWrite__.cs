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
                 
        上面这个过程就是 ""RenderTextureReadWrite.sRGB" read-write mode;
        =========

        当选择了 linear 工作流时, "RenderTextureReadWrite.Default" 就符合上文的 "sRGB" 的行为,
        当一个 render texture 被设置为 "RenderTextureReadWrite.Default",
        它的 RenderTexture.sRGB 通常为 true;

        ==========
        但是, 如果你的 render texture 包含 非颜色数据 (normals, velocities, other custom values),
        这些数据是 线性的, 他们在被写入和读取时, 不需要 sRGB<->linear 转换;

        这就是 "RenderTextureReadWrite.Linear" read-write mode;
        当一个 render texture 被设置为这个模式时, 它的 RenderTexture.sRGB 为 false;

        注意:
            有些 "RenderTextureFormat" 类型 始终认为自己存储的是 linear 数据, 也不执行任何 sRGB<->linear 转换,
            此时, 不管本 enum 被设置为何值, 他们都不会改变自己的行为;

            所有的 "HDR" (floating point) formats, 还有 Depth 类型, Shadowmap 类型, 都属于上述这种类型;
    */
    public enum RenderTextureReadWrite//RenderTextureReadWrite__
    {


        /*
            Default "color space conversion" based on "project settings";

            当 app 使用 Linear 工作流, 本变量等于下面的 sRGB   模式
            当 app 使用 gamma  工作流, 本变量等于下面的 Linear 模式;
            ---
            虽然这两句话看起来很拗口,  但是仔细想想很有道理:

            当使用了 Linear 工作量, 默认 render texture 是 sRGB 空间的, 那么确实需要执行 sRGB<->Linear 转换;

            当使用了 gamma 工作量, 此时所有的 render texture 一定都是 sRGB 空间的, 
                从 sRGB 到 sRGB, 当然不需要任何 转换,
                (只不过此时 "Linear" 这个名字有点不合适罢了)


            案例:
                如果我们希望新建一个 rt, 向其传入 线性数据, 而不是颜色值, 也就是: 像使用 normal map 那样去使用这个 rt;
                那么我们应该写:
                    rt = new RenderTexture( w, h, depth, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear );

                注意这最后的参数, 它是关键 !!!
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

