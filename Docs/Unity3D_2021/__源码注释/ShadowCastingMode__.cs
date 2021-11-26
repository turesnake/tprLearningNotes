#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        How shadows are cast from this object.

        本物体设置的, 自己是如何贡献给 shader caster 的
    */
    public enum ShadowCastingMode//ShadowCastingMode__
    {
        /*
            摘要:
            No shadows are cast from this object.
            不将自己贡献给 shadowmap
        */
        Off = 0,

        /*
            摘要:
            Shadows are cast from this object.

            物体的 shader 使用啥 cull mode (Cull Back 这种), 本物体的 shadercaster pass 就用一样的;

            这往往意味着, 有些 单面物体,比如 Plane, Quad, 因为它们的 默认 shader 的 cull 设置为: Cull Back,
            然后它们的 shadercaster pass 也沿用这个设置; 导致当 光线是从这些物体的 后面照射过来时,
            它们不会产生投影;

            此时就要改用 TwoSided 模式;
        */
        On = 1,

        /*
            摘要:
            Shadows are cast from this object, treating it as two-sided.

            上上文的 On 模式中所述, 本模式适用于 单面物体;
        */
        TwoSided = 2,


        /*
            摘要:
            Object casts shadows, but is otherwise invisible in the Scene.

            物体自己不可见, 但物体的阴影可见;
        */
        ShadowsOnly = 3
    }
}

