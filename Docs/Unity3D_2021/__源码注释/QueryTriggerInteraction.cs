#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion

namespace UnityEngine
{
    /*
        Overrides the global Physics.queriesHitTriggers.

        指定了当调用 各种 Physics.xxxCast() 函数时, 碰撞检测是否要响应那些 trigger collider;

    */
    public enum QueryTriggerInteraction
    {
        //
        // 摘要:
        //     Queries use the global Physics.queriesHitTriggers setting.
        UseGlobal = 0,
        //
        // 摘要:
        //     Queries never report Trigger hits.
        Ignore = 1,
        //
        // 摘要:
        //     Queries always report Trigger hits.
        Collide = 2
    }
}

