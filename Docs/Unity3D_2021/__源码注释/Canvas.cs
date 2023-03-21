#region 程序集 UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.UIModule.dll
#endregion

using System;

namespace UnityEngine
{
    //
    // 摘要:
    //     Element that can be used for screen rendering.
    [NativeClassAttribute("UI::Canvas")]
    [NativeHeaderAttribute("Modules/UI/UIStructs.h")]
    [NativeHeaderAttribute("Modules/UI/CanvasManager.h")]
    [NativeHeaderAttribute("Modules/UI/Canvas.h")]
    [RequireComponent(typeof(RectTransform))]
    public sealed class Canvas : Behaviour
    {
        public Canvas();

        //
        // 摘要:
        //     Override the sorting of canvas.
        public bool overrideSorting { get; set; }
        //
        // 摘要:
        //     Camera used for sizing the Canvas when in Screen Space - Camera. Also used as
        //     the Camera that events will be sent through for a World Space [[Canvas].
        [NativePropertyAttribute("Camera", false, Bindings.TargetType.Function)]
        public Camera worldCamera { get; set; }
        //
        // 摘要:
        //     Returns the canvas display size based on the selected render mode and target
        //     display.
        public Vector2 renderingDisplaySize { get; }


        /*
            Returns the Canvas closest to root, by checking through each parent and returning
            the last canvas found. If no other canvas is found then the canvas will return
            itself.
        */
        public Canvas rootCanvas { get; }

        //
        // 摘要:
        //     Name of the Canvas' sorting layer.
        public string sortingLayerName { get; set; }
        //
        // 摘要:
        //     Get or set the mask of additional shader channels to be used when creating the
        //     Canvas mesh.
        public AdditionalCanvasShaderChannels additionalShaderChannels { get; set; }
        //
        // 摘要:
        //     Cached calculated value based upon SortingLayerID.
        public int cachedSortingLayerValue { get; }
        //
        // 摘要:
        //     Unique ID of the Canvas' sorting layer.
        public int sortingLayerID { get; set; }
        //
        // 摘要:
        //     For Overlay mode, display index on which the UI canvas will appear.
        public int targetDisplay { get; set; }
        //
        // 摘要:
        //     Canvas' order within a sorting layer.
        public int sortingOrder { get; set; }
        //
        // 摘要:
        //     The render order in which the canvas is being emitted to the Scene. (Read Only)
        public int renderOrder { get; }
        //
        // 摘要:
        //     How far away from the camera is the Canvas generated.
        public float planeDistance { get; set; }
        //
        // 摘要:
        //     Force elements in the canvas to be aligned with pixels. Only applies with renderMode
        //     is Screen Space.
        public bool pixelPerfect { get; set; }


        /*
            Allows for nested canvases to override pixelPerfect settings inherited from parent canvases.
            
            如果我们先在目标 parent canvas 下创建一个 go, 然后再为这个 go 绑定一个 canvas 组件,
            那么这个 canvas 自动就是 "pixelPerfect - inherited" 状态的, 啥都不用改;
        */
        public bool overridePixelPerfect { get; set; }


        //
        // 摘要:
        //     The number of pixels per unit that is considered the default.
        public float referencePixelsPerUnit { get; set; }
        //
        // 摘要:
        //     Used to scale the entire canvas, while still making it fit the screen. Only applies
        //     with renderMode is Screen Space.
        public float scaleFactor { get; set; }
        //
        // 摘要:
        //     Get the render rect for the Canvas.
        public Rect pixelRect { get; }

        //
        // 摘要:
        //     Is this the root Canvas?
        public bool isRootCanvas { get; }

        //
        // 摘要:
        //     Is the Canvas in World or Overlay mode?
        public RenderMode renderMode { get; set; }
        //
        // 摘要:
        //     The normalized grid size that the canvas will split the renderable area into.
        [NativePropertyAttribute("SortingBucketNormalizedSize", false, Bindings.TargetType.Function)]
        public float normalizedSortingGridSize { get; set; }
        //
        // 摘要:
        //     The normalized grid size that the canvas will split the renderable area into.
        [NativePropertyAttribute("SortingBucketNormalizedSize", false, Bindings.TargetType.Function)]
        [Obsolete("Setting normalizedSize via a int is not supported. Please use normalizedSortingGridSize", false)]
        public int sortingGridNormalizedSize { get; set; }

        public static event WillRenderCanvases willRenderCanvases;
        public static event WillRenderCanvases preWillRenderCanvases;

        //
        // 摘要:
        //     Force all canvases to update their content.
        public static void ForceUpdateCanvases();
        //
        // 摘要:
        //     Returns the default material that can be used for rendering normal elements on
        //     the Canvas.
        [FreeFunctionAttribute("UI::GetDefaultUIMaterial")]
        public static Material GetDefaultCanvasMaterial();
        //
        // 摘要:
        //     Returns the default material that can be used for rendering text elements on
        //     the Canvas.
        [FreeFunctionAttribute("UI::GetDefaultUIMaterial")]
        [Obsolete("Shared default material now used for text and general UI elements, call Canvas.GetDefaultCanvasMaterial()", false)]
        public static Material GetDefaultCanvasTextMaterial();
        //
        // 摘要:
        //     Gets or generates the ETC1 Material.
        //
        // 返回结果:
        //     The generated ETC1 Material from the Canvas.
        [FreeFunctionAttribute("UI::GetETC1SupportedCanvasMaterial")]
        public static Material GetETC1SupportedCanvasMaterial();

        public delegate void WillRenderCanvases();
    }
}