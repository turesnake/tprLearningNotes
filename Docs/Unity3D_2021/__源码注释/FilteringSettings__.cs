#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Internal;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        A struct that represents filtering settings for "ScriptableRenderContext.DrawRenderers()"

        本类描述了, 如何过滤 DrawRenderers() 获得的那组 物体, 只有其中的一部分 最终会被执行渲染;
    */
    public struct FilteringSettings : IEquatable<FilteringSettings>//FilteringSettings__
    {

        /*
            若不向此 构造函数传入任何参数, 会生成一个 empth 实例, 它的所有成员值 都被设为 0;
            然后你得手动设置每一个成员值;

            默认的成员值, 都意为 不执行某种 过滤;

            参数:
            renderQueueRange:   写入本类的 同名变量中;
            layerMask:          写入本类的 同名变量中;
            renderingLayerMask: 写入本类的 同名变量中;

            excludeMotionVectorObjects:
                写入本类的 同名变量中;

                本参数若为 1, 将  excludeMotionVectorObjects 设为 true; 
                若为 0, 则设置为 false;
        */
        public FilteringSettings(
            // 这个 renderQueueRange 的语句 看起来很混乱, 测试表明如果 调用者不输入此参数, 此值将会是 null, 而不是 all;
            // 此时, range 为 [0,0]
            [DefaultValue("RenderQueueRange.all")] RenderQueueRange? renderQueueRange = null, 
            int layerMask = -1, 
            uint renderingLayerMask = uint.MaxValue, // 默认 支持所有 layer
            int excludeMotionVectorObjects = 0       // 默认不开启
        );


        /*
            Creates a FilteringSettings struct that contains default values for all properties.
            With these default values, Unity does not perform any filtering.

            默认配置 就是不做任何过滤工作;
        */
        public static FilteringSettings defaultValue { get; }


        /*
            哪个物体的 Material.renderQueue 值位于此 range 范围内(包含边界), 这个物体就会被渲染;

            这个 range 信息应该是 构造函数中传入的, 也可事后手动改写;
            如果构造函数中不传入, 事后也不额外设置, 那么这个 range 就是 [0,0] 
        */
        public RenderQueueRange renderQueueRange { get; set; }

        /*
            Unity renders objects whose GameObject.layer value is enabled in this bit mask.
            如果一个物体的 GameObject.layer 和这个 变量 AND 计算后不为 0, 这个物体会被渲染;
            (当然还要经受住 其它方式的过滤 )
        */
        public int layerMask { get; set; }


        /*
            Unity renders objects whose "Renderer.renderingLayerMask"(变量) value is enabled in this bit mask.

            Renderer.renderingLayerMask (一个变量):
                在 srp管线中, 不光有 物体的 GameObject.layer, 
                还可以为物体额外设置一个 rendering-specific layer mask;

                毕竟通用的那个 GameObject.layer 包含的 功能太多了;
                而这个新的 layer mask 专门用于 渲染;
        */
        public uint renderingLayerMask { get; set; }



        /*
            摘要:
            Determines if Unity excludes GameObjects that are in motion from rendering. 
            
            如果一个 go 被证明 "正在发生位移运动", 这个物体就会被剔除出 渲染;
            本变量 就是来开启这个功能的;

            为啥要这个功能... 目前还不知道;

            如何得知一个物体是否 "正在发生位移运动":
                如果一个 go 的 materail 中有一个 active Motion Vector pass,
                或者这个 go -> Mesh Renderer -> Motion Vectors 被设置为 Per Object Motion,
                那么这个 go 就启动了 Motion Vector;

                猜测:
                    然后能通过这个 Motion Vector, 来判断这个 物体是否在运动

            For Unity to exclude a GameObject from rendering, the GameObject must have moved 
            since the last frame. To exclude a GameObject manually, enable a Motion Vector pass.

            这个变量很含糊, 需要更多信息... 
        */
        public bool excludeMotionVectorObjects { get; set; }


        /*
            摘要:
            Unity renders objects whose SortingLayer.value value is within range specified
            by this Rendering.SortingLayerRange.

            SortingLayer 被用于 2D 系统, 比如 sprites 的排序;
        */
        public SortingLayerRange sortingLayerRange { get; set; }



        public bool Equals(FilteringSettings other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(FilteringSettings left, FilteringSettings right);
        public static bool operator !=(FilteringSettings left, FilteringSettings right);
    }
}

