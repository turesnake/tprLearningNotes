#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Specifies which parts of the render state that is overriden.

        各个 flags 可以组合起来使用
    */
    [Flags]
    public enum RenderStateMask
    {
        
        // 摘要:
        //     No render states are overridden.
        Nothing = 0,
        
        // 摘要:
        //     When set, the blend state is overridden.
        Blend = 1,
        
        // 摘要:
        //     When set, the raster state is overridden.
        Raster = 2,
        
        // 摘要:
        //     When set, the depth state is overridden.
        Depth = 4,
        
        // 摘要:
        //     When set, the stencil state and reference value is overridden.
        Stencil = 8,

        
        // 摘要:
        //     When set, all render states are overridden.
        Everything = 15
    }
}
