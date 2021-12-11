#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Settings for ScriptableRenderContext.DrawRenderers()

        描述了:
        -- how to sort visible objects (sortingSettings)
        -- which shader passes to use (shaderPassName).
    */
    public struct DrawingSettings : IEquatable<DrawingSettings>//DrawingSettings__
    {
        
        
        //     The maxiumum number of passes that can be rendered in 1 DrawRenderers call.
        public static readonly int maxShaderPasses;


        /*
            摘要:
            Create a draw settings struct.
            
            参数:
            shaderPassName:
                Shader pass to use.
        
             sortingSettings:
                Describes the methods to sort objects during rendering.
                仅涉及 "物体排序"
                具体信息可见 对应 class 翻译文件;
        */
        public DrawingSettings(ShaderTagId shaderPassName, SortingSettings sortingSettings);


        /*
            摘要:
            Configures what light should be used as main light.

            若不设置此值, 将选择 "可见的最亮的 平行光" 为 main light;
            它将被用于执行 针对 main light 的  "逐物体-光" 的 culling 操作
            
        */
        public int mainLightIndex { get; set; }


        /*
            摘要:
            How to sort objects during rendering.
            猜测:
                估计是从 构造函数 那得到的 配置信息;
        */
        public SortingSettings sortingSettings { get; set; }


        /*
            摘要:
            What kind of per-object data to setup during rendering.

            渲染时要 setup 哪些 "逐物体" 数据;
            具体信息见 此enum 翻译文件
        */
        public PerObjectData perObjectData { get; set; }



        /*
            摘要:
            Controls whether dynamic batching is enabled.

            默认关闭, 因为 dynamic batching 在  nulti-pass shader 中存在问题;
            也不建议开启
        */
        public bool enableDynamicBatching { get; set; }


        /*
            摘要:
            Controls whether instancing is enabled.

            默认开启, 即 GPU Instancing
        */
        public bool enableInstancing { get; set; }


        // 摘要:
        //     Sets the Material to use for all drawers that would render in this group.
        public Material overrideMaterial { get; set; }

        
        // 摘要:
        //     Selects which pass of the override material to use.
        public int overrideMaterialPassIndex { get; set; }



        public bool Equals(DrawingSettings other);
        public override bool Equals(object obj);
        public override int GetHashCode();


        
        // 摘要:
        //     Get the shader passes that this draw call can render.
        //
        // 参数:
        //   index:
        //     Index of the shader pass to use.
        public ShaderTagId GetShaderPassName(int index);

        
        /*
            Set the shader passes that this draw call can render.
            可以反复调用, 设置很多个
        */
        // 参数:
        //   index:
        //     Index of the shader pass to use.
        //
        //   shaderPassName:
        //     Name of the shader pass.
        public void SetShaderPassName(int index, ShaderTagId shaderPassName);
        
        

        public static bool operator ==(DrawingSettings left, DrawingSettings right);
        public static bool operator !=(DrawingSettings left, DrawingSettings right);


        [CompilerGenerated]
        [UnsafeValueType]
        public struct <shaderPassNames>e__FixedBuffer
        {
            public int FixedElementField;
        }
        
    }
}

