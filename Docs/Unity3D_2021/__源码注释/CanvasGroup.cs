#region 程序集 UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.UIModule.dll
#endregion


namespace UnityEngine
{

    /*
        A Canvas placable element that can be used to modify children Alpha, Raycasting, Enabled state.

        -- 让所有子元素 淡入淡出
        -- 让所有子元素 失活 (按钮无法点击)
        -- 让所有子元素 不接收 射线碰撞检测
        -- 可以用本 canvasGroup 的配置参数, 屏蔽所有上层的 canvasGroup 配置参数;

    */
    [NativeClassAttribute("UI::CanvasGroup")]
    [NativeHeaderAttribute("Modules/UI/CanvasGroup.h")]
    public sealed class CanvasGroup : Behaviour, ICanvasRaycastFilter
    {
        public CanvasGroup();

        //
        // 摘要:
        //     Set the alpha of the group.
        [NativePropertyAttribute("Alpha", false, Bindings.TargetType.Function)]
        public float alpha { get; set; }

        /*
            Is the group interactable (are the elements beneath the group enabled).

            子元素是否支持交互, 比如按钮可以按下;

        */
        [NativePropertyAttribute("Interactable", false, Bindings.TargetType.Function)]
        public bool interactable { get; set; }



        /*
            Does this group block raycasting (allow collision).

            是否屏蔽射线检测, 若屏蔽, 按钮之类的也无法起效;
        */
        [NativePropertyAttribute("BlocksRaycasts", false, Bindings.TargetType.Function)]
        public bool blocksRaycasts { get; set; }


        /*
            Should the group ignore parent groups?
            If set to true the group will ignore any parent group settings.

            用来屏蔽 上层 canvasGroup 的设置;
            若开启, 上层 group 的所有操作都会被本层的设置值 所覆盖;
        */
        [NativePropertyAttribute("IgnoreParentGroups", false, Bindings.TargetType.Function)]
        public bool ignoreParentGroups { get; set; }


        //
        // 摘要:
        //     Returns true if the Group allows raycasts.
        //
        // 参数:
        //   sp:  猜测时 screen-position
        //
        //   eventCamera:
        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera);
    }
}

