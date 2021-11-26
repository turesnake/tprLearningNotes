#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Identifies a RenderTexture for a Rendering.CommandBuffer.

        Render textures can be identified in a number of ways, 比如:
        -- a RenderTexture object,
        -- one of built-in render textures (BuiltinRenderTextureType), 
        -- a temporary render texture with a name (that was created using CommandBuffer.GetTemporaryRT).

        This struct serves as a way to identify them, 
        并且自带一组 隐式类型转换符, 以节省打字

    */
    public struct RenderTargetIdentifier /*RenderTargetIdentifier__*/
        : IEquatable<RenderTargetIdentifier>
    {
        /*
            摘要:
            All depth-slices of the render resource are bound for rendering. 
            For textures which are neither array nor 3D, the default slice is bound.

            为了渲染, render resource 的所有 depth-slices 都被绑定了;
            如果目标 texture 既不是 array, 也不是 3d, 则绑定 default slice;

            没看懂
        */
        public const int AllDepthSlices = -1;



        /*
            摘要:
            Creates a render target identifier.   构造函数

            RenderTargetIdentifier can be implicitly created from:
            -- a RenderTexture reference, 
            -- a Texture reference, 
            -- a BuiltinRenderTextureType, or a name.


            A RenderTargetIdentifier created from Texture reference is only valid 
            when passed to CommandBuffer.SetGlobalTexture()

        
            参数:
            type:
                Built-in temporary render texture type.
               这只是一个 enum 值
            
            name:
            nameID:
                Temporary render texture name.
    
            tex:
                RenderTexture or Texture object to use.
            
            mipLevel:
                 MipLevel of the RenderTexture to use.
            
            cubeFace:
                Cubemap face of the Cubemap RenderTexture to use.
                默认值 Unknown 表示没有具体指定;
            
            depthSlice:
                Depth slice of the Array RenderTexture to use. 

                上文中的本类常数: RenderTargetIdentifier.AllDepthSlices, 
                表明了: all slices should be bound for rendering;

                此参数默认值为 0;
            
            renderTargetIdentifier:
                An existing render target identifier.
        */
        public RenderTargetIdentifier(BuiltinRenderTextureType type);
        public RenderTargetIdentifier(string name);
        public RenderTargetIdentifier(Texture tex);
        public RenderTargetIdentifier(int nameID);
        public RenderTargetIdentifier(Texture tex, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0);
        public RenderTargetIdentifier(RenderTargetIdentifier renderTargetIdentifier, int mipLevel, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0);
        public RenderTargetIdentifier(RenderBuffer buf, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0);
        public RenderTargetIdentifier(string name, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0);
        public RenderTargetIdentifier(BuiltinRenderTextureType type, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0);
        public RenderTargetIdentifier(int nameID, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0);



        public bool Equals(RenderTargetIdentifier rhs);
        public override bool Equals(object obj);

        public override int GetHashCode();
        public override string ToString();

        public static bool operator ==(RenderTargetIdentifier lhs, RenderTargetIdentifier rhs);
        public static bool operator !=(RenderTargetIdentifier lhs, RenderTargetIdentifier rhs);

        public static implicit operator RenderTargetIdentifier(BuiltinRenderTextureType type);
        public static implicit operator RenderTargetIdentifier(string name);
        public static implicit operator RenderTargetIdentifier(int nameID);
        public static implicit operator RenderTargetIdentifier(Texture tex);
        public static implicit operator RenderTargetIdentifier(RenderBuffer buf);
    }
}

