#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Determine in which order objects are renderered.

        值越小的, 越先被渲染;

        值得区间需要位于: [0,5000]

        和:
        -- Material.renderQueue, 
        -- Shader.renderQueue, 
        -- subshader tags.
        都是同一个概念;
    */
    public enum RenderQueue
    {
        
        // 摘要:
        //     This render queue is rendered before any others.
        Background = 1000,
        
        // 摘要:
        //     Opaque geometry uses this queue.
        Geometry = 2000,
        
        // 摘要:
        //     Alpha tested geometry uses this queue. (就是 Cutout 模式的物体)
        AlphaTest = 2450,
        

        /*
            摘要:
            Last render queue that is considered "opaque".

            在区间 [0, GeometryLast] 内的物体都被当作是 "不透明物体";
            (这部分物体放在一起, 以减少 render state 的改变, 以便各种 合并优化措施, 比如 GPU Instancing)

            在区间 [GeometryLast+1, 5000] 的物体都被看作是 "半透明物体",
            (它们将被执行 从后到前 的排序)
        */
        GeometryLast = 2500,

        /*
            摘要:
            This render queue is rendered after Geometry and AlphaTest, in back-to-front order.

            不会写入 depth buffer;
            比如 玻璃, 粒子效果 等;
        */
        Transparent = 3000,


        /*
            摘要:
            This render queue is meant for overlay effects. (额外叠加的效果)

            比如 镜头光晕;
        */
        Overlay = 4000
    }
}

