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
            --
            这只是一个 常数, 它的意思是:
            -1-
                如果 texture 是 array, 3D cubemap, 那么 "depthSlice = -1" 就意味着:
                    All depth-slices of the render resource are bound for rendering. 
            -2-
                如果 texture 不是 array, 3D cubemap, 那么系统将使用 "default slice" 去写入 depth 数据; 
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
                Temporary render texture name.
            nameID:
                调用: Shader.PropertyToID("_AAA_Tex"); 获得的, 
    
            tex:
                RenderTexture or Texture object to use.
            
            mipLevel:
                 MipLevel of the RenderTexture to use.
            
            cubeFace:
                Cubemap face of the Cubemap RenderTexture to use.
                默认值 Unknown 表示没有具体指定;
            
            depthSlice:
                Depth slice of the Array RenderTexture to use. 
                The symbolic constant "RenderTargetIdentifier.AllDepthSlices" indicates that 
                all slices should be bound for rendering. The default value is 0.
                ---
                此值默认写 0, 表示使用第一层 去 存储 depth 数据;
                如果设置为 -1, 那么将执行上文 "RenderTargetIdentifier.AllDepthSlices" 所表达的意思;(去查看它)
            
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

