#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        摘要:
        Color or depth buffer part of a RenderTexture.

        A single RenderTexture object represents both color and depth buffers, 
        but many complex rendering algorithms require using 
        the same depth buffer with multiple color buffers or vice versa.
        --
        一个简单的 rendertexture 对象同时意味着一个 color buffer 和一个 depth buffer;

        但有些复杂的渲染算法需要使用:
            -- 一个 depth buffer 搭配 数个 color buffers
            -- 一个 color buffer 搭配 数个 depth buffers

        This class represents either a color or a depth buffer part of a RenderTexture.
        ---
        本类实例 要么表示一个 rendertexture 的 color buffer,
        要么表示它的 depth buffer;
    */
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    public struct RenderBuffer
    {

        /*
            摘要:
            Returns native RenderBuffer. 
            
            注意:
            this is not native Texture, but rather pointer to unity struct that can be used with native unity API. 
            Currently such API exists only on iOS.
        */
        [FreeFunctionAttribute(Name = "RenderBufferScripting::GetNativeRenderBufferPtr", HasExplicitThis = true)]
        public IntPtr GetNativeRenderBufferPtr();
    }
}

