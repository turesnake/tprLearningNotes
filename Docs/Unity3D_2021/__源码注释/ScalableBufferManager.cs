#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    /*
        Scales render textures to support dynamic resolution if the target platform/graphics API supports it.
        ---
        The ScalableBufferManager handles the scaling of any render textures that you have marked to be DynamicallyScalable, 
        when "ResizeBuffers" is called. 
        All render textures marked as DynamicallyScalable are scaled by a width and height scale factor, 
        the reason the scale is controlled through a scale factor and not with a specific width and height value 
        is because different render textures will be different sizes but will want to be scaled by a common factor.
    
    
    */
    [NativeHeaderAttribute("Runtime/GfxDevice/ScalableBufferManager.h")]
    [StaticAccessorAttribute("ScalableBufferManager::GetInstance()", Bindings.StaticAccessorType.Dot)]
    public static class ScalableBufferManager//ScalableBufferManager__RR
    {
        /*
            Width scale factor to control dynamic resolution.

            This is a scale factor between epsilon(无穷小值) and 1.0 
            that is applied to the width of all render textures that you have marked as DynamicallyScalable.
            ---
            任何被标记为 DynamicallyScalable 的 render texture, 都将使用本值 来修正自己的 width 分辨率;
        */
        public static float widthScaleFactor { get; }

        /*
            Height scale factor to control dynamic resolution.

            This is a scale factor between epsilon(无穷小值) and 1.0 
            that is applied to the height of all render textures that you have marked as DynamicallyScalable.
        */
        public static float heightScaleFactor { get; }


        /*
            Function to resize all buffers marked as DynamicallyScalable.
            
            Takes in new width and height scale and stores and applies it to all render textures marked as DynamicallyScalable. 
            Note that the scale is applied to the render textures original dimensions 
            so a scale factor of 1.0 will always be the full dimensions for the specified render target, etc.

            The Vulkan implementation only supports discrete(离散) scale factors in the range between 0.25 and 1.0 in steps of 0.05 
            and only uniform scaling is supported. 
            Unity automatically selects the closest supported scale factors. 
            You can access the selected scale factors using "ScalableBufferManager.widthScaleFactor" 
            and "ScalableBufferManager.heightScaleFactor"

        // 参数:
        //   widthScale:
        //     New scale factor for the width the ScalableBufferManager will use to resize all
        //     render textures the user marked as DynamicallyScalable, has to be some value
        //     greater than 0.0 and less than or equal to 1.0.
        //
        //   heightScale:
        //     New scale factor for the height the ScalableBufferManager will use to resize
        //     all render textures the user marked as DynamicallyScalable, has to be some value
        //     greater than 0.0 and less than or equal to 1.0.
        */
        public static void ResizeBuffers(float widthScale, float heightScale);
    }
}

