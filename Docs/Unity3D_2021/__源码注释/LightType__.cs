#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    //
    // 摘要:
    //     The type of a Light.
    public enum LightType//LightType__
    {
        //
        // 摘要:
        //     The light is a spot light.
        Spot = 0,
        //
        // 摘要:
        //     The light is a directional light.
        Directional = 1,
        //
        // 摘要:
        //     The light is a point light.
        Point = 2,
        Area = 3,
        //
        // 摘要:
        //     The light is a rectangle shaped area light. It affects only baked lightmaps and
        //     lightprobes.
        Rectangle = 3,
        //
        // 摘要:
        //     The light is a disc shaped area light. It affects only baked lightmaps and lightprobes.
        Disc = 4
    }
}
