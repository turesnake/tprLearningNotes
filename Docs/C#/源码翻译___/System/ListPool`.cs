#region 程序集 Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Unity.RenderPipelines.Core.Runtime.dll
#endregion

using System.Collections.Generic;

namespace UnityEngine.Rendering
{
    /*
        避免频繁的 new List<T>;
        而是循环利用 List<T> 实例; (注意, 是一个 List 实例)
    */
    public static class ListPool<T>
    {
        public static List<T> Get();
        public static ObjectPool<List<T>>.PooledObject Get(out List<T> value);
        public static void Release(List<T> toRelease);
    }
}

