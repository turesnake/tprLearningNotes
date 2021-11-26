#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    /*
        Fog mode to use.

        具体介绍查看 catlike rendering 教程
    */
    public enum FogMode//FogMode__
    {
        /*
            Linear fog.
        */
        Linear = 1,

        /*
            Exponential fog.
        */
        Exponential = 2,

        /*
            Exponential squared fog (default).
        */
        ExponentialSquared = 3
    }
}

