#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Types of data that you can encapsulate within a render texture.
        可以封装进 render texture 中的数据类型;

        猜测:
            render texture 是可能同时存储数种数据的, 比如 color, depth, stencil, 
            可以同时在同一个 render texture 中;

        使用本 enum, 可以从一个 render texture 中选择一种数据, 以便一个函数去访问这种数据;
    */
    public enum RenderTextureSubElement
    {
        
        // 摘要:
        //     Color element of a RenderTexture.
        Color = 0,
        
        // 摘要:
        //     The depth element of a RenderTexture.
        Depth = 1,
        
        /*
            摘要:
            The stencil element of a RenderTexture.

            可以访问一个 render texture 的 stencil 数据,
            在你创建这个 render texture 之前, 记得选择一种 目标平台支持的 "stencil format";

            想要访问到 stencil 数据, 必须设置正确的 存储通道;
            大部分平台都将此值存储在 r通道, dx11 将其存储在 g通道;

            若将 stencilFormat 设置为 R8_UInt, 你就需要使用 Load() 函数 从 texture 中读取数据;
            否则, 只有当 format 为 R8_UNorm 时, 你才可以对其使用 采样函数;

            当使用 MSAA RenderTextures, 你需要将 stencil texture 定义为相同的 MS Texture types;

            不能将 stencil buffer 绑定为 RWTexture. (可读可写 obj)

        */
        Stencil = 2,
        
        /*
            摘要:
            The Default element of a RenderTexture.

            如果 render texture 含有 color,(当然他还允许包含其它数据), 
                那么此时, 这个 default 就指向 color 数据;

            如果 render texture 仅仅含有 depth 数据, 那么这个 default 就指向 depth 数据;
        */
        Default = 3
    }
}
