#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System.Collections.Generic;

namespace UnityEngine.Rendering
{
    /*
        Defines a series of commands and settings that describes how Unity renders a frame.
    */
    public abstract class RenderPipeline//RenderPipeline__
    {
        protected RenderPipeline();


        // Returns true when the "RenderPipeline" is invalid or destroyed.
        // You should not call methods on a disposed RenderPipeline.
        public bool disposed { get; }



        /*
            ----------------------------------- 回调函数 触发者 ----------------------------------------:
            在 "RenderPipeline 的派生类" 实现的 "RenderPipeline.Render()" 实现体内, 调用本函数,
            所有绑定到委托 "RenderPipelineManager.beginContextRendering" 和 "RenderPipelineManager.beginFrameRendering"
            上的 callbacks, 都会被触发调用;
            (查看 urp 中, 对本函数的调用)
        */
        protected static void BeginContextRendering(ScriptableRenderContext context, List<Camera> cameras);
        // 同上, 调用委托 "RenderPipelineManager.endContextRendering" 和 "RenderPipelineManager.endFrameRendering" 的 callbacks;
        protected static void EndContextRendering(ScriptableRenderContext context, List<Camera> cameras);



        // -------------------------------------- 回调函数 触发者 -------------------------------------:
        // 建议改用 "xxxContextRendering()" 系列, 本组函数会引发 堆内存分配(不推荐行为); 本组函数存在的目的是为了向下兼容
        protected static void BeginFrameRendering(ScriptableRenderContext context, Camera[] cameras);
        protected static void EndFrameRendering(ScriptableRenderContext context, Camera[] cameras);
        



        /*
            ----------------------------------- 回调函数 触发者 ----------------------------------------:
            同上上上, 
            所有绑定到委托 "RenderPipelineManager.beginCameraRendering" 上的 callbacks, 都会被触发调用;
        */
        protected static void BeginCameraRendering(ScriptableRenderContext context, Camera camera);
        // 同上, 所有绑定到委托 "RenderPipelineManager.endCameraRendering" 上的 callbacks, 都会被触发调用;
        protected static void EndCameraRendering(ScriptableRenderContext context, Camera camera);
        


        
        protected virtual void Dispose(bool disposing);


        /*
            Executes RenderRequests submitted using "Camera.SubmitRenderRequests()".

            用户实现本函数的 函数体;
            当用户调用 "Camera.SubmitRenderRequests()" 时, unity 会调用本函数;

            如果用户在 自定义 "RenderPipeline" 派生类中, 实现了 本函数的函数体, 
            Unity updates the RenderTexture assigned to the results property of each RenderRequest with the requested data.

            如果用户没有实现 本函数的函数体, unity 啥也不做;
            it performs a no-op, and every RenderRequests remains in the same state.

            如果你在实现一个 custom srp, 你必须保证, 要按照设计的要求实现本函数体, 否则就彻底不要实现它;
            ---
            观察发现, urp, hdrp 都未实现本函数体
        */
        protected virtual void ProcessRenderRequests(
            ScriptableRenderContext context, Camera camera, List<Camera.RenderRequest> renderRequests);
        
        

        /*
            Entry point method that defines custom rendering for this RenderPipeline.

            每个 "RenderPipeline" 派生类 都要实现此函数;

            Unity calls this method automatically. In a standalone application, Unity calls this method once per frame 
            to render the main view, and once per frame for "each manual call to "Camera.Render()" ".
            在每一帧中, 每当用户手动调用一次  "Camera.Render", 本函数就会被调用一次;
            
            
            In the Unity Editor, Unity calls this method once per frame for each "Scene view" or "Game view" that is visible, 
            once per frame if if the "Scene camera preview" is visible, and once per frame for "each manual call to "Camera.Render()" ".
        */
        protected virtual void Render(ScriptableRenderContext context, List<Camera> cameras);

        // 和上个函数几乎一致, 区别在于 本函数会引发 堆内存分配 (不推荐的), 所以应该改用上一个函数;
        // 具体改用方式, 参考 urp 中的实现;
        protected abstract void Render(ScriptableRenderContext context, Camera[] cameras);


        
    }
}

