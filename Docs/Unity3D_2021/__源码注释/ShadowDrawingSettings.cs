#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Settings for ScriptableRenderContext.DrawShadows();

        描述了: which shadow light to render (lightIndex) with what split settings (splitData).


    */
    [UsedByNativeCodeAttribute]
    public struct ShadowDrawingSettings : IEquatable<ShadowDrawingSettings>
    {
        //
        // 摘要:
        //     Create a shadow settings object.
        //
        // 参数:
        //   cullResults:
        //     The cull results for this light.
        //
        //   lightIndex:
        //     The light index.
        //
        //   cullingResults:
        public ShadowDrawingSettings(CullingResults cullingResults, int lightIndex);

        //
        // 摘要:
        //     Culling results to use.
        public CullingResults cullingResults { get; set; }
        //
        // 摘要:
        //     The index of the shadow-casting light to be rendered.
        public int lightIndex { get; set; }
        //
        // 摘要:
        //     Set this to true to make Unity filter Renderers during shadow rendering. Unity
        //     filters Renderers based on the Rendering Layer Mask of the Renderer itself, and
        //     the Rendering Layer Mask of each shadow casting Light.
        public bool useRenderingLayerMaskTest { get; set; }
        //
        // 摘要:
        //     The split data.
        public ShadowSplitData splitData { get; set; }
        //
        // 摘要:
        //     Specifies the filter Unity applies to GameObjects that it renders in the shadow
        //     pass.
        public ShadowObjectsFilter objectsFilter { get; set; }

        public bool Equals(ShadowDrawingSettings other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(ShadowDrawingSettings left, ShadowDrawingSettings right);
        public static bool operator !=(ShadowDrawingSettings left, ShadowDrawingSettings right);
    }
}
