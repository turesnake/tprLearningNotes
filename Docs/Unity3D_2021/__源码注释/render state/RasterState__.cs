#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Values for the raster state.

        Use this with RenderStateBlock() and ScriptableRenderContext.DrawRenderers() 
        to override the GPU's render state.

        内容相当于 shader 中的:
            -- Conservative, 
            -- Cull, 
            -- ZClip, 
            -- Offset

    */
    public struct RasterState : IEquatable<RasterState>
    {
        //
        // 摘要:
        //     Default values for the raster state.
        public static readonly RasterState defaultValue;




        public RasterState(
            CullMode cullingMode = CullMode.Back, 
            int offsetUnits = 0, 
            float offsetFactor = 0, 
            bool depthClip = true
        );

        
        // 摘要:
        //     Controls which sides of polygons should be culled (not drawn).
        public CullMode cullingMode { get; set; }
        

        /*
            摘要:
            Enable clipping based on depth.
            猜测:
                ZClip True:
                    超出 near far 平面的 frags 全部被 "抛弃了" (不执行后续渲染工作)

                ZClip False:
                    超出的 frags, 深度值被 "贴" 回 near far 平面;
        */
        public bool depthClip { get; set; }


        /*
            摘要:
            Enables conservative rasterization.
            保守模式的光栅化

            "保守光栅化" 意味着, 只要这个像素 和 三角形沾边, 就判定此像素 属于 这个三角形.
        */
        public bool conservative { get; set; }



        /*
            Offset <factor>, <units> 中的 units 因子的值;
            ---
            units:
                Scales the minimum resolvable depth buffer value in the GPU's depth bias setting.

            factor:
                Scales the maximum Z slope in the GPU's depth bias setting.  
        */
        public int offsetUnits { get; set; }
        public float offsetFactor { get; set; }




        public bool Equals(RasterState other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(RasterState left, RasterState right);
        public static bool operator !=(RasterState left, RasterState right);
    }
}
