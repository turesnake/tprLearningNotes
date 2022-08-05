#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using UnityEngine.Internal;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     Compute Shader asset.
    [NativeHeaderAttribute("Runtime/Graphics/ShaderScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Shaders/ComputeShader.h")]
    [UsedByNativeCodeAttribute]
    public sealed class ComputeShader : Object
    {
        //
        // 摘要:
        //     An array containing the local shader keywords that are currently enabled for
        //     this compute shader.
        public LocalKeyword[] enabledKeywords { get; set; }
        //
        // 摘要:
        //     The local keyword space of this compute shader.
        public LocalKeywordSpace keywordSpace { get; }
        //
        // 摘要:
        //     An array containing names of the local shader keywords that are currently enabled
        //     for this compute shader.
        public string[] shaderKeywords { get; set; }

        public void DisableKeyword(in LocalKeyword keyword);
        //
        // 摘要:
        //     Disables a local shader keyword for this compute shader.
        //
        // 参数:
        //   keyword:
        //     The Rendering.LocalKeyword to disable.
        [FreeFunctionAttribute("ComputeShaderScripting::DisableKeyword", HasExplicitThis = true)]
        public void DisableKeyword(string keyword);



        /*
            Execute a compute shader.   执行一个 compute shader 的 kernel 函数;
            
            假设传入的参数为: ( kernelIndex, 5, 3, 2 )
            然后 numthreads 设置为 (10,8,7)
            那么则意味着:
                -----
                每个 threadGroup 内含有 10x8x7 个 thread;
                然后本次 Dispatch() 调用, 会一次性处理: 5x3x2 = 30 个 threadGroup;


            参数:
            kernelIndex:
                Which kernel to execute. A single compute shader asset can have multiple kernel
                entry points.
            
            threadGroupsX:
                Number of work groups in the X dimension.
            
            threadGroupsY:
                Number of work groups in the Y dimension.
            
            threadGroupsZ:
                Number of work groups in the Z dimension.
        */
        [NativeNameAttribute("DispatchComputeShader")]
        public void Dispatch(int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ);



        [ExcludeFromDocs]
        public void DispatchIndirect(int kernelIndex, GraphicsBuffer argsBuffer);
        //
        // 摘要:
        //     Execute a compute shader.
        //
        // 参数:
        //   kernelIndex:
        //     Which kernel to execute. A single compute shader asset can have multiple kernel
        //     entry points.
        //
        //   argsBuffer:
        //     Buffer with dispatch arguments.
        //
        //   argsOffset:
        //     The byte offset into the buffer, where the draw arguments start.
        public void DispatchIndirect(int kernelIndex, GraphicsBuffer argsBuffer, [DefaultValue("0")] uint argsOffset);
        [ExcludeFromDocs]
        public void DispatchIndirect(int kernelIndex, ComputeBuffer argsBuffer);
        //
        // 摘要:
        //     Execute a compute shader.
        //
        // 参数:
        //   kernelIndex:
        //     Which kernel to execute. A single compute shader asset can have multiple kernel
        //     entry points.
        //
        //   argsBuffer:
        //     Buffer with dispatch arguments.
        //
        //   argsOffset:
        //     The byte offset into the buffer, where the draw arguments start.
        public void DispatchIndirect(int kernelIndex, ComputeBuffer argsBuffer, [DefaultValue("0")] uint argsOffset);
        public void EnableKeyword(in LocalKeyword keyword);
        //
        // 摘要:
        //     Enables a local shader keyword for this compute shader.
        //
        // 参数:
        //   keyword:
        //     The Rendering.LocalKeyword to enable.
        [FreeFunctionAttribute("ComputeShaderScripting::EnableKeyword", HasExplicitThis = true)]
        public void EnableKeyword(string keyword);
        //
        // 摘要:
        //     Find ComputeShader kernel index.
        //
        // 参数:
        //   name:
        //     Name of kernel function.
        //
        // 返回结果:
        //     The Kernel index, or logs a "FindKernel failed" error message if the kernel is
        //     not found.
        [NativeMethodAttribute(Name = "ComputeShaderScripting::FindKernel", HasExplicitThis = true, IsFreeFunction = true, ThrowsException = true)]
        [RequiredByNativeCodeAttribute]
        public int FindKernel(string name);
        [NativeMethodAttribute(Name = "ComputeShaderScripting::GetKernelThreadGroupSizes", HasExplicitThis = true, IsFreeFunction = true, ThrowsException = true)]
        public void GetKernelThreadGroupSizes(int kernelIndex, out uint x, out uint y, out uint z);
        //
        // 摘要:
        //     Checks whether a shader contains a given kernel.
        //
        // 参数:
        //   name:
        //     The name of the kernel to look for.
        //
        // 返回结果:
        //     True if the kernel is found, false otherwise.
        [FreeFunctionAttribute(Name = "ComputeShaderScripting::HasKernel", HasExplicitThis = true)]
        public bool HasKernel(string name);
        //
        // 摘要:
        //     Checks whether a local shader keyword is enabled for this compute shader.
        //
        // 参数:
        //   keyword:
        //     The Rendering.LocalKeyword to check.
        //
        // 返回结果:
        //     Returns true if the given Rendering.LocalKeyword is enabled for this compute
        //     shader. Otherwise, returns false.
        [FreeFunctionAttribute("ComputeShaderScripting::IsKeywordEnabled", HasExplicitThis = true)]
        public bool IsKeywordEnabled(string keyword);
        public bool IsKeywordEnabled(in LocalKeyword keyword);
        //
        // 摘要:
        //     Allows you to check whether the current end user device supports the features
        //     required to run the specified compute shader kernel.
        //
        // 参数:
        //   kernelIndex:
        //     Which kernel to query.
        //
        // 返回结果:
        //     True if the specified compute kernel is able to run on the current end user device,
        //     false otherwise.
        [FreeFunctionAttribute("ComputeShaderScripting::IsSupported", HasExplicitThis = true)]
        public bool IsSupported(int kernelIndex);
        //
        // 摘要:
        //     Set a bool parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        public void SetBool(string name, bool val);
        //
        // 摘要:
        //     Set a bool parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        public void SetBool(int nameID, bool val);
        //
        // 摘要:
        //     Sets an input or output compute buffer.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the buffer is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   buffer:
        //     Buffer to set.
        public void SetBuffer(int kernelIndex, string name, GraphicsBuffer buffer);
        //
        // 摘要:
        //     Sets an input or output compute buffer.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the buffer is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   buffer:
        //     Buffer to set.
        public void SetBuffer(int kernelIndex, string name, ComputeBuffer buffer);
        //
        // 摘要:
        //     Sets an input or output compute buffer.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the buffer is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   buffer:
        //     Buffer to set.
        public void SetBuffer(int kernelIndex, int nameID, GraphicsBuffer buffer);
        //
        // 摘要:
        //     Sets an input or output compute buffer.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the buffer is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   buffer:
        //     Buffer to set.
        public void SetBuffer(int kernelIndex, int nameID, ComputeBuffer buffer);
        //
        // 摘要:
        //     Sets a ComputeBuffer or a GraphicsBuffer as a named constant buffer for the ComputeShader.
        //
        // 参数:
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the buffer to bind as constant buffer.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the ComputeBuffer to bind. Must be
        //     a multiple of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is
        //     0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetConstantBuffer(int nameID, ComputeBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Sets a ComputeBuffer or a GraphicsBuffer as a named constant buffer for the ComputeShader.
        //
        // 参数:
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the buffer to bind as constant buffer.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the ComputeBuffer to bind. Must be
        //     a multiple of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is
        //     0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetConstantBuffer(int nameID, GraphicsBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Sets a ComputeBuffer or a GraphicsBuffer as a named constant buffer for the ComputeShader.
        //
        // 参数:
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the buffer to bind as constant buffer.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the ComputeBuffer to bind. Must be
        //     a multiple of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is
        //     0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetConstantBuffer(string name, GraphicsBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Sets a ComputeBuffer or a GraphicsBuffer as a named constant buffer for the ComputeShader.
        //
        // 参数:
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the buffer to bind as constant buffer.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the ComputeBuffer to bind. Must be
        //     a multiple of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is
        //     0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetConstantBuffer(string name, ComputeBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Set a float parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        [FreeFunctionAttribute(Name = "ComputeShaderScripting::SetValue<float>", HasExplicitThis = true)]
        public void SetFloat(int nameID, float val);
        //
        // 摘要:
        //     Set a float parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        public void SetFloat(string name, float val);
        //
        // 摘要:
        //     Set multiple consecutive float parameters at once.
        //
        // 参数:
        //   name:
        //     Array variable name in the shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Value array to set.
        public void SetFloats(string name, params float[] values);
        //
        // 摘要:
        //     Set multiple consecutive float parameters at once.
        //
        // 参数:
        //   name:
        //     Array variable name in the shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Value array to set.
        public void SetFloats(int nameID, params float[] values);
        //
        // 摘要:
        //     Set an integer parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        [FreeFunctionAttribute(Name = "ComputeShaderScripting::SetValue<int>", HasExplicitThis = true)]
        public void SetInt(int nameID, int val);
        //
        // 摘要:
        //     Set an integer parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        public void SetInt(string name, int val);
        //
        // 摘要:
        //     Set multiple consecutive integer parameters at once.
        //
        // 参数:
        //   name:
        //     Array variable name in the shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Value array to set.
        public void SetInts(string name, params int[] values);
        //
        // 摘要:
        //     Set multiple consecutive integer parameters at once.
        //
        // 参数:
        //   name:
        //     Array variable name in the shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Value array to set.
        public void SetInts(int nameID, params int[] values);
        public void SetKeyword(in LocalKeyword keyword, bool value);
        //
        // 摘要:
        //     Set a Matrix parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        [FreeFunctionAttribute(Name = "ComputeShaderScripting::SetValue<Matrix4x4f>", HasExplicitThis = true)]
        public void SetMatrix(int nameID, Matrix4x4 val);
        //
        // 摘要:
        //     Set a Matrix parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        public void SetMatrix(string name, Matrix4x4 val);
        //
        // 摘要:
        //     Set a Matrix array parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Value to set.
        public void SetMatrixArray(string name, Matrix4x4[] values);
        //
        // 摘要:
        //     Set a Matrix array parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Value to set.
        [FreeFunctionAttribute(Name = "ComputeShaderScripting::SetArray<Matrix4x4f>", HasExplicitThis = true)]
        public void SetMatrixArray(int nameID, Matrix4x4[] values);
        //
        // 摘要:
        //     Set a texture parameter.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the texture is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   texture:
        //     Texture to set.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(int kernelIndex, int nameID, RenderTexture texture, int mipLevel, RenderTextureSubElement element);
        //
        // 摘要:
        //     Set a texture parameter.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the texture is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   texture:
        //     Texture to set.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        [NativeMethodAttribute(Name = "ComputeShaderScripting::SetTexture", HasExplicitThis = true, IsFreeFunction = true, ThrowsException = true)]
        public void SetTexture(int kernelIndex, int nameID, [NotNullAttribute("ArgumentNullException")] Texture texture, int mipLevel);
        //
        // 摘要:
        //     Set a texture parameter.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the texture is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   texture:
        //     Texture to set.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(int kernelIndex, string name, RenderTexture texture, int mipLevel, RenderTextureSubElement element);
        //
        // 摘要:
        //     Set a texture parameter.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the texture is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   texture:
        //     Texture to set.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(int kernelIndex, string name, Texture texture, int mipLevel);
        //
        // 摘要:
        //     Set a texture parameter.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the texture is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   texture:
        //     Texture to set.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(int kernelIndex, string name, Texture texture);
        //
        // 摘要:
        //     Set a texture parameter.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the texture is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   texture:
        //     Texture to set.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(int kernelIndex, int nameID, Texture texture);
        //
        // 摘要:
        //     Set a texture parameter from a global texture property.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the texture is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   globalTextureName:
        //     Global texture property to assign to shader.
        //
        //   globalTextureNameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        public void SetTextureFromGlobal(int kernelIndex, string name, string globalTextureName);
        //
        // 摘要:
        //     Set a texture parameter from a global texture property.
        //
        // 参数:
        //   kernelIndex:
        //     For which kernel the texture is being set. See FindKernel.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   globalTextureName:
        //     Global texture property to assign to shader.
        //
        //   globalTextureNameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        [NativeMethodAttribute(Name = "ComputeShaderScripting::SetTextureFromGlobal", HasExplicitThis = true, IsFreeFunction = true, ThrowsException = true)]
        public void SetTextureFromGlobal(int kernelIndex, int nameID, int globalTextureNameID);
        //
        // 摘要:
        //     Set a vector parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        [FreeFunctionAttribute(Name = "ComputeShaderScripting::SetValue<Vector4f>", HasExplicitThis = true)]
        public void SetVector(int nameID, Vector4 val);
        //
        // 摘要:
        //     Set a vector parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   val:
        //     Value to set.
        public void SetVector(string name, Vector4 val);
        //
        // 摘要:
        //     Set a vector array parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Value to set.
        [FreeFunctionAttribute(Name = "ComputeShaderScripting::SetArray<Vector4f>", HasExplicitThis = true)]
        public void SetVectorArray(int nameID, Vector4[] values);
        //
        // 摘要:
        //     Set a vector array parameter.
        //
        // 参数:
        //   name:
        //     Variable name in shader code.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Value to set.
        public void SetVectorArray(string name, Vector4[] values);
    }
}


