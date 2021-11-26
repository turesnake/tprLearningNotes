#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Ambient lighting mode.

        Unity can provide ambient lighting in several modes, 
        
        for example directional ambient with separate sky, 赤道 and ground colors, 
        比如, directional ambient (定向环境光), 分别来自 天空色, 赤道色, 地面色;
        
        or flat ambient with a single color.
        只有一个颜色;

    */
    public enum AmbientMode//AmbientMode__
    {
        
        //     Skybox-based or custom ambient lighting.
        //  Ambient color is calculated from the current skybox, or set manually.
        Skybox = 0,
        
        //   Trilight ambient lighting.
        //   Ambient is defined by three colors: "sky", "equator" and "ground".
        Trilight = 1,
        
        //     Flat ambient lighting.
        Flat = 3,
        
        //     Ambient lighting is defined by a custom cubemap.
        Custom = 4
    }
}

