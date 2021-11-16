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

        //
        // 摘要:
        //     Controls which sides of polygons should be culled (not drawn).
        public CullMode cullingMode { get; set; }
        //
        // 摘要:
        //     Enable clipping based on depth.
        public bool depthClip { get; set; }
        //
        // 摘要:
        //     Enables conservative rasterization. Before using check for support via SystemInfo.supportsConservativeRaster
        //     property.
        public bool conservative { get; set; }
        //
        // 摘要:
        //     Scales the minimum resolvable depth buffer value in the GPU's depth bias setting.
        public int offsetUnits { get; set; }
        //
        // 摘要:
        //     Scales the maximum Z slope in the GPU's depth bias setting.
        public float offsetFactor { get; set; }

        public bool Equals(RasterState other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(RasterState left, RasterState right);
        public static bool operator !=(RasterState left, RasterState right);
    }
}
