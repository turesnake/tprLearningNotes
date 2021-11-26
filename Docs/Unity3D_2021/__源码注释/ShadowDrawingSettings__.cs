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
    public struct ShadowDrawingSettings /*ShadowDrawingSettings__*/
        : IEquatable<ShadowDrawingSettings>
    {

        /*
            摘要:
            Create a shadow settings object.
            
            参数:
            cullingResults:
                The cull results for this light.
                包含了 本次要处理的光源 的 cullingResults 数据;
            
            lightIndex:
                The light index.
                本次要处理的光源 的 idx
        */
        public ShadowDrawingSettings(CullingResults cullingResults, int lightIndex);


        // 摘要:
        //     Culling results to use.
        public CullingResults cullingResults { get; set; }
        
        // 摘要:
        //     The index of the shadow-casting light to be rendered.
        public int lightIndex { get; set; }

        /*
            若为 true, unity 会在 绘制shadow 的环节中,
            对比 每个物体(renderer) 的 Rendering Layer Mask, 
            和 每个 "执行shadow casting" 的光源的 Rendering Layer Mask,
            以此来决定 这个物体是否要被绘制到 shadowmap 上去;

            "Rendering Layer Mask" 是一个 srp 新增技术;
                具体信息可在笔记中 查找此关键词
        */
        public bool useRenderingLayerMaskTest { get; set; }
        

        // 摘要:
        //     The split data.
        public ShadowSplitData splitData { get; set; }


        /*
            摘要:
            Specifies the filter Unity applies to GameObjects that it renders in the shadow pass.

            ---
            很奇怪, 到底啥叫 "Static Shadow Caster tag" ?
            唯一找到的相似信息是:
            Renderer.staticShadowCaster: (一个bool值)
                具体信息查找此class 翻译文件;
            ------- 

            仅在 hdrp 中看过此变量 被使用

            enum:
            -- AllObjects:
                    Renders all GameObjects.
            -- DynamicOnly:
                    Only renders GameObjects that do not include the "Static Shadow Caster tag".
            -- StaticOnly:
                    Only renders GameObjects that include the "Static Shadow Caster tag".
        */
        public ShadowObjectsFilter objectsFilter { get; set; }


        public bool Equals(ShadowDrawingSettings other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(ShadowDrawingSettings left, ShadowDrawingSettings right);
        public static bool operator !=(ShadowDrawingSettings left, ShadowDrawingSettings right);
    }
}
