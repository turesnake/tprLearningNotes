// CommandBuffer
// 简略笔记 

// commandbuffer 持有一组 rendering commands，这些 commands 可被设置在数个指定的节点上。
// 在 camera rendering 期间：如：Camera.AddCommandBuffer()
//       此函数通过 CameraEvent 来确定插入的 流程时间点

// 在 light rendering 区间：如： Light.AddCommandBuffer()
//       此函数通过 LightEvent 来确定插入的 流程时间点 
//      （注意，它提供的插入点，和 CameraEvent 是不一样的）


// 也可被直接“调用”，如： Graphics.ExecuteCommandBuffer() （个人猜测类似 submit() ）

// （上面的函数 估计是被用于 built-in 管线）

// 通常，cb 将被用来自定义 渲染管线。 


#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.Security;
using Unity.Collections;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Profiling;

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     List of graphics commands to execute.
    [NativeHeaderAttribute("Runtime/Shaders/ComputeShader.h")]
    [NativeHeaderAttribute("Runtime/Export/Graphics/RenderingCommandBuffer.bindings.h")]
    [NativeHeaderAttribute("Runtime/Shaders/RayTracingShader.h")]
    [NativeTypeAttribute("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
    [UsedByNativeCodeAttribute]
    public class CommandBuffer : IDisposable
    {
        //
        // 摘要:
        //     Create a new empty command buffer.
        public CommandBuffer();

        ~CommandBuffer();

        //
        // 摘要:
        //     Size of this command buffer in bytes (Read Only).
        public int sizeInBytes { get; }
        //
        // 摘要:
        //     Name of this command buffer.
        public string name { get; set; }

        //
        // 摘要:
        //     Adds a command to begin profile sampling.
        //
        // 参数:
        //   name:
        //     Name of the profile information used for sampling.
        //
        //   sampler:
        //     The CustomSampler that the CommandBuffer uses for sampling.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::BeginSample", HasExplicitThis = true)]
        public void BeginSample(string name);

        //
        // 摘要:
        //     Adds a command to begin profile sampling.
        //
        // 参数:
        //   name:
        //     Name of the profile information used for sampling.
        //
        //   sampler:
        //     The CustomSampler that the CommandBuffer uses for sampling.
        public void BeginSample(CustomSampler sampler);
        
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(Texture source, RenderTargetIdentifier dest, Vector2 scale, Vector2 offset);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(Texture source, RenderTargetIdentifier dest, Material mat);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(Texture source, RenderTargetIdentifier dest);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Vector2 scale, Vector2 offset);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Material mat);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Material mat, int pass);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, int sourceDepthSlice, int destDepthSlice);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Vector2 scale, Vector2 offset, int sourceDepthSlice, int destDepthSlice);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Material mat, int pass, int destDepthSlice);
        //
        // 摘要:
        //     Add a "blit into a render texture" command.
        //
        // 参数:
        //   source:
        //     Source texture or render target to blit from.
        //
        //   dest:
        //     Destination to blit into.
        //
        //   mat:
        //     Material to use.
        //
        //   pass:
        //     Shader pass to use (default is -1, meaning "all passes").
        //
        //   scale:
        //     Scale applied to the source texture coordinate.
        //
        //   offset:
        //     Offset applied to the source texture coordinate.
        //
        //   sourceDepthSlice:
        //     The texture array source slice to perform the blit from.
        //
        //   destDepthSlice:
        //     The texture array destination slice to perform the blit to.
        public void Blit(Texture source, RenderTargetIdentifier dest, Material mat, int pass);
        public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure, Vector3 relativeOrigin);
        //
        // 摘要:
        //     Adds a command to build the RayTracingAccelerationStructure to be used in a ray
        //     tracing dispatch.
        //
        // 参数:
        //   accelerationStructure:
        //     The RayTracingAccelerationStructure to be generated.
        public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure);
        //
        // 摘要:
        //     Clear all commands in the buffer.
        [NativeMethodAttribute("ClearCommands")]
        public void Clear();
        //
        // 摘要:
        //     Clear random write targets for level pixel shaders.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::ClearRandomWriteTargets", HasExplicitThis = true, ThrowsException = true)]
        public void ClearRandomWriteTargets();
        public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor);
        //
        // 摘要:
        //     Adds a "clear render target" command.
        //
        // 参数:
        //   clearDepth:
        //     Should clear depth buffer?
        //
        //   clearColor:
        //     Should clear color buffer?
        //
        //   backgroundColor:
        //     Color to clear with.
        //
        //   depth:
        //     Depth to clear with (default is 1.0).
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::ClearRenderTarget", HasExplicitThis = true)]
        public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth);
        //
        // 摘要:
        //     Converts and copies a source texture to a destination texture with a different
        //     format or dimensions.
        //
        // 参数:
        //   src:
        //     Source texture.
        //
        //   dst:
        //     Destination texture.
        //
        //   srcElement:
        //     Source element (e.g. cubemap face). Set this to 0 for 2D source textures.
        //
        //   dstElement:
        //     Destination element (e.g. cubemap face or texture array element).
        public void ConvertTexture(RenderTargetIdentifier src, RenderTargetIdentifier dst);
        //
        // 摘要:
        //     Converts and copies a source texture to a destination texture with a different
        //     format or dimensions.
        //
        // 参数:
        //   src:
        //     Source texture.
        //
        //   dst:
        //     Destination texture.
        //
        //   srcElement:
        //     Source element (e.g. cubemap face). Set this to 0 for 2D source textures.
        //
        //   dstElement:
        //     Destination element (e.g. cubemap face or texture array element).
        public void ConvertTexture(RenderTargetIdentifier src, int srcElement, RenderTargetIdentifier dst, int dstElement);
        //
        // 摘要:
        //     Adds a command to copy ComputeBuffer or GraphicsBuffer counter value.
        //
        // 参数:
        //   src:
        //     Append/consume buffer to copy the counter from.
        //
        //   dst:
        //     A buffer to copy the counter to.
        //
        //   dstOffsetBytes:
        //     Target byte offset in dst buffer.
        public void CopyCounterValue(GraphicsBuffer src, ComputeBuffer dst, uint dstOffsetBytes);
        //
        // 摘要:
        //     Adds a command to copy ComputeBuffer or GraphicsBuffer counter value.
        //
        // 参数:
        //   src:
        //     Append/consume buffer to copy the counter from.
        //
        //   dst:
        //     A buffer to copy the counter to.
        //
        //   dstOffsetBytes:
        //     Target byte offset in dst buffer.
        public void CopyCounterValue(GraphicsBuffer src, GraphicsBuffer dst, uint dstOffsetBytes);
        //
        // 摘要:
        //     Adds a command to copy ComputeBuffer or GraphicsBuffer counter value.
        //
        // 参数:
        //   src:
        //     Append/consume buffer to copy the counter from.
        //
        //   dst:
        //     A buffer to copy the counter to.
        //
        //   dstOffsetBytes:
        //     Target byte offset in dst buffer.
        public void CopyCounterValue(ComputeBuffer src, GraphicsBuffer dst, uint dstOffsetBytes);
        //
        // 摘要:
        //     Adds a command to copy ComputeBuffer or GraphicsBuffer counter value.
        //
        // 参数:
        //   src:
        //     Append/consume buffer to copy the counter from.
        //
        //   dst:
        //     A buffer to copy the counter to.
        //
        //   dstOffsetBytes:
        //     Target byte offset in dst buffer.
        public void CopyCounterValue(ComputeBuffer src, ComputeBuffer dst, uint dstOffsetBytes);
        //
        // 摘要:
        //     Adds a command to copy a texture into another texture.
        //
        // 参数:
        //   src:
        //     Source texture or identifier, see RenderTargetIdentifier.
        //
        //   dst:
        //     Destination texture or identifier, see RenderTargetIdentifier.
        //
        //   srcElement:
        //     Source texture element (cubemap face, texture array layer or 3D texture depth
        //     slice).
        //
        //   srcMip:
        //     Source texture mipmap level.
        //
        //   dstElement:
        //     Destination texture element (cubemap face, texture array layer or 3D texture
        //     depth slice).
        //
        //   dstMip:
        //     Destination texture mipmap level.
        //
        //   srcX:
        //     X coordinate of source texture region to copy (left side is zero).
        //
        //   srcY:
        //     Y coordinate of source texture region to copy (bottom is zero).
        //
        //   srcWidth:
        //     Width of source texture region to copy.
        //
        //   srcHeight:
        //     Height of source texture region to copy.
        //
        //   dstX:
        //     X coordinate of where to copy region in destination texture (left side is zero).
        //
        //   dstY:
        //     Y coordinate of where to copy region in destination texture (bottom is zero).
        public void CopyTexture(RenderTargetIdentifier src, int srcElement, int srcMip, RenderTargetIdentifier dst, int dstElement, int dstMip);
        //
        // 摘要:
        //     Adds a command to copy a texture into another texture.
        //
        // 参数:
        //   src:
        //     Source texture or identifier, see RenderTargetIdentifier.
        //
        //   dst:
        //     Destination texture or identifier, see RenderTargetIdentifier.
        //
        //   srcElement:
        //     Source texture element (cubemap face, texture array layer or 3D texture depth
        //     slice).
        //
        //   srcMip:
        //     Source texture mipmap level.
        //
        //   dstElement:
        //     Destination texture element (cubemap face, texture array layer or 3D texture
        //     depth slice).
        //
        //   dstMip:
        //     Destination texture mipmap level.
        //
        //   srcX:
        //     X coordinate of source texture region to copy (left side is zero).
        //
        //   srcY:
        //     Y coordinate of source texture region to copy (bottom is zero).
        //
        //   srcWidth:
        //     Width of source texture region to copy.
        //
        //   srcHeight:
        //     Height of source texture region to copy.
        //
        //   dstX:
        //     X coordinate of where to copy region in destination texture (left side is zero).
        //
        //   dstY:
        //     Y coordinate of where to copy region in destination texture (bottom is zero).
        public void CopyTexture(RenderTargetIdentifier src, RenderTargetIdentifier dst);
        //
        // 摘要:
        //     Adds a command to copy a texture into another texture.
        //
        // 参数:
        //   src:
        //     Source texture or identifier, see RenderTargetIdentifier.
        //
        //   dst:
        //     Destination texture or identifier, see RenderTargetIdentifier.
        //
        //   srcElement:
        //     Source texture element (cubemap face, texture array layer or 3D texture depth
        //     slice).
        //
        //   srcMip:
        //     Source texture mipmap level.
        //
        //   dstElement:
        //     Destination texture element (cubemap face, texture array layer or 3D texture
        //     depth slice).
        //
        //   dstMip:
        //     Destination texture mipmap level.
        //
        //   srcX:
        //     X coordinate of source texture region to copy (left side is zero).
        //
        //   srcY:
        //     Y coordinate of source texture region to copy (bottom is zero).
        //
        //   srcWidth:
        //     Width of source texture region to copy.
        //
        //   srcHeight:
        //     Height of source texture region to copy.
        //
        //   dstX:
        //     X coordinate of where to copy region in destination texture (left side is zero).
        //
        //   dstY:
        //     Y coordinate of where to copy region in destination texture (bottom is zero).
        public void CopyTexture(RenderTargetIdentifier src, int srcElement, RenderTargetIdentifier dst, int dstElement);
        //
        // 摘要:
        //     Adds a command to copy a texture into another texture.
        //
        // 参数:
        //   src:
        //     Source texture or identifier, see RenderTargetIdentifier.
        //
        //   dst:
        //     Destination texture or identifier, see RenderTargetIdentifier.
        //
        //   srcElement:
        //     Source texture element (cubemap face, texture array layer or 3D texture depth
        //     slice).
        //
        //   srcMip:
        //     Source texture mipmap level.
        //
        //   dstElement:
        //     Destination texture element (cubemap face, texture array layer or 3D texture
        //     depth slice).
        //
        //   dstMip:
        //     Destination texture mipmap level.
        //
        //   srcX:
        //     X coordinate of source texture region to copy (left side is zero).
        //
        //   srcY:
        //     Y coordinate of source texture region to copy (bottom is zero).
        //
        //   srcWidth:
        //     Width of source texture region to copy.
        //
        //   srcHeight:
        //     Height of source texture region to copy.
        //
        //   dstX:
        //     X coordinate of where to copy region in destination texture (left side is zero).
        //
        //   dstY:
        //     Y coordinate of where to copy region in destination texture (bottom is zero).
        public void CopyTexture(RenderTargetIdentifier src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, RenderTargetIdentifier dst, int dstElement, int dstMip, int dstX, int dstY);
        //
        // 摘要:
        //     Shortcut for calling GommandBuffer.CreateGraphicsFence with GraphicsFenceType.AsyncQueueSynchronization
        //     as the first parameter.
        //
        // 参数:
        //   stage:
        //     The synchronization stage. See Graphics.CreateGraphicsFence.
        //
        // 返回结果:
        //     Returns a new GraphicsFence.
        public GraphicsFence CreateAsyncGraphicsFence(SynchronisationStage stage);
        //
        // 摘要:
        //     Shortcut for calling GommandBuffer.CreateGraphicsFence with GraphicsFenceType.AsyncQueueSynchronization
        //     as the first parameter.
        //
        // 参数:
        //   stage:
        //     The synchronization stage. See Graphics.CreateGraphicsFence.
        //
        // 返回结果:
        //     Returns a new GraphicsFence.
        public GraphicsFence CreateAsyncGraphicsFence();
        //
        // 摘要:
        //     This functionality is deprecated, and should no longer be used. Please use CommandBuffer.CreateGraphicsFence.
        //
        // 参数:
        //   stage:
        [Obsolete("CommandBuffer.CreateGPUFence has been deprecated. Use CreateGraphicsFence instead (UnityUpgradable) -> CreateAsyncGraphicsFence(*)", false)]
        public GPUFence CreateGPUFence(SynchronisationStage stage);
        [Obsolete("CommandBuffer.CreateGPUFence has been deprecated. Use CreateGraphicsFence instead (UnityUpgradable) -> CreateAsyncGraphicsFence()", false)]
        public GPUFence CreateGPUFence();
        public GraphicsFence CreateGraphicsFence(GraphicsFenceType fenceType, SynchronisationStageFlags stage);
        //
        // 摘要:
        //     Add a command to disable the hardware scissor rectangle.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::DisableScissorRect", HasExplicitThis = true, ThrowsException = true)]
        public void DisableScissorRect();
        //
        // 摘要:
        //     Adds a command to disable global shader keyword.
        //
        // 参数:
        //   keyword:
        //     Shader keyword to disable.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::DisableShaderKeyword", HasExplicitThis = true)]
        public void DisableShaderKeyword(string keyword);
        //
        // 摘要:
        //     Add a command to execute a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to execute.
        //
        //   kernelIndex:
        //     Kernel index to execute, see ComputeShader.FindKernel.
        //
        //   threadGroupsX:
        //     Number of work groups in the X dimension.
        //
        //   threadGroupsY:
        //     Number of work groups in the Y dimension.
        //
        //   threadGroupsZ:
        //     Number of work groups in the Z dimension.
        //
        //   indirectBuffer:
        //     ComputeBuffer with dispatch arguments.
        //
        //   argsOffset:
        //     Byte offset indicating the location of the dispatch arguments in the buffer.
        public void DispatchCompute(ComputeShader computeShader, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ);
        //
        // 摘要:
        //     Add a command to execute a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to execute.
        //
        //   kernelIndex:
        //     Kernel index to execute, see ComputeShader.FindKernel.
        //
        //   threadGroupsX:
        //     Number of work groups in the X dimension.
        //
        //   threadGroupsY:
        //     Number of work groups in the Y dimension.
        //
        //   threadGroupsZ:
        //     Number of work groups in the Z dimension.
        //
        //   indirectBuffer:
        //     ComputeBuffer with dispatch arguments.
        //
        //   argsOffset:
        //     Byte offset indicating the location of the dispatch arguments in the buffer.
        public void DispatchCompute(ComputeShader computeShader, int kernelIndex, GraphicsBuffer indirectBuffer, uint argsOffset);
        //
        // 摘要:
        //     Add a command to execute a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to execute.
        //
        //   kernelIndex:
        //     Kernel index to execute, see ComputeShader.FindKernel.
        //
        //   threadGroupsX:
        //     Number of work groups in the X dimension.
        //
        //   threadGroupsY:
        //     Number of work groups in the Y dimension.
        //
        //   threadGroupsZ:
        //     Number of work groups in the Z dimension.
        //
        //   indirectBuffer:
        //     ComputeBuffer with dispatch arguments.
        //
        //   argsOffset:
        //     Byte offset indicating the location of the dispatch arguments in the buffer.
        public void DispatchCompute(ComputeShader computeShader, int kernelIndex, ComputeBuffer indirectBuffer, uint argsOffset);
        //
        // 摘要:
        //     Adds a command to execute a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to execute.
        //
        //   rayGenName:
        //     The name of the ray generation shader.
        //
        //   width:
        //     The width of the ray generation shader thread grid.
        //
        //   height:
        //     The height of the ray generation shader thread grid.
        //
        //   depth:
        //     The depth of the ray generation shader thread grid.
        //
        //   camera:
        //     Optional parameter used to setup camera-related built-in shader variables.
        public void DispatchRays(RayTracingShader rayTracingShader, string rayGenName, uint width, uint height, uint depth, Camera camera = null);
        public void Dispose();
        //
        // 摘要:
        //     Add a "draw mesh" command.
        //
        // 参数:
        //   mesh:
        //     Mesh to draw.
        //
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   submeshIndex:
        //     Which subset of the mesh to render.
        //
        //   shaderPass:
        //     Which pass of the shader to use (default is -1, which renders all passes).
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties);
        public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass);
        public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex);
        public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material);
        //
        // 摘要:
        //     Adds a "draw mesh with instancing" command. The command will not immediately
        //     fail and throw an exception if Material.enableInstancing is false, but it will
        //     log an error and skips rendering each time the command is being executed if such
        //     a condition is detected. InvalidOperationException will be thrown if the current
        //     platform doesn't support this API (i.e. if GPU instancing is not available).
        //     See SystemInfo.supportsInstancing.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   matrices:
        //     The array of object transformation matrices.
        //
        //   count:
        //     The number of instances to be drawn.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices);
        //
        // 摘要:
        //     Adds a "draw mesh with instancing" command. The command will not immediately
        //     fail and throw an exception if Material.enableInstancing is false, but it will
        //     log an error and skips rendering each time the command is being executed if such
        //     a condition is detected. InvalidOperationException will be thrown if the current
        //     platform doesn't support this API (i.e. if GPU instancing is not available).
        //     See SystemInfo.supportsInstancing.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   matrices:
        //     The array of object transformation matrices.
        //
        //   count:
        //     The number of instances to be drawn.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count);
        //
        // 摘要:
        //     Adds a "draw mesh with instancing" command. The command will not immediately
        //     fail and throw an exception if Material.enableInstancing is false, but it will
        //     log an error and skips rendering each time the command is being executed if such
        //     a condition is detected. InvalidOperationException will be thrown if the current
        //     platform doesn't support this API (i.e. if GPU instancing is not available).
        //     See SystemInfo.supportsInstancing.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   matrices:
        //     The array of object transformation matrices.
        //
        //   count:
        //     The number of instances to be drawn.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties);
        //
        // 摘要:
        //     Add a "draw mesh with indirect instancing" command.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     The GPU buffer containing the arguments for how many instances of this mesh to
        //     draw.
        //
        //   argsOffset:
        //     The byte offset into the buffer, where the draw arguments start.
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset);
        //
        // 摘要:
        //     Add a "draw mesh with indirect instancing" command.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     The GPU buffer containing the arguments for how many instances of this mesh to
        //     draw.
        //
        //   argsOffset:
        //     The byte offset into the buffer, where the draw arguments start.
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset);
        //
        // 摘要:
        //     Add a "draw mesh with indirect instancing" command.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     The GPU buffer containing the arguments for how many instances of this mesh to
        //     draw.
        //
        //   argsOffset:
        //     The byte offset into the buffer, where the draw arguments start.
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        //
        // 摘要:
        //     Add a "draw mesh with indirect instancing" command.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     The GPU buffer containing the arguments for how many instances of this mesh to
        //     draw.
        //
        //   argsOffset:
        //     The byte offset into the buffer, where the draw arguments start.
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs);
        //
        // 摘要:
        //     Add a "draw mesh with indirect instancing" command.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     The GPU buffer containing the arguments for how many instances of this mesh to
        //     draw.
        //
        //   argsOffset:
        //     The byte offset into the buffer, where the draw arguments start.
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        //
        // 摘要:
        //     Add a "draw mesh with indirect instancing" command.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     The GPU buffer containing the arguments for how many instances of this mesh to
        //     draw.
        //
        //   argsOffset:
        //     The byte offset into the buffer, where the draw arguments start.
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs);
        //
        // 摘要:
        //     Add a "draw mesh with instancing" command. Draw a mesh using Procedural Instancing.
        //     This is similar to Graphics.DrawMeshInstancedIndirect, except that when the instance
        //     count is known from script, it can be supplied directly using this method, rather
        //     than via a ComputeBuffer. If Material.enableInstancing is false, the command
        //     logs an error and skips rendering each time the command is executed; the command
        //     does not immediately fail and throw an exception. InvalidOperationException will
        //     be thrown if the current platform doesn't support this API (for example, if GPU
        //     instancing is not available). See SystemInfo.supportsInstancing.
        //
        // 参数:
        //   mesh:
        //     The Mesh to draw.
        //
        //   submeshIndex:
        //     Which subset of the mesh to draw. This only applies to meshes that are composed
        //     of several materials.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use, or -1 which renders all passes.
        //
        //   count:
        //     The number of instances to be drawn.
        //
        //   properties:
        //     Additional Material properties to apply onto the Material just before this Mesh
        //     is drawn. See MaterialPropertyBlock.
        public void DrawMeshInstancedProcedural(Mesh mesh, int submeshIndex, Material material, int shaderPass, int count, MaterialPropertyBlock properties = null);
        //
        // 摘要:
        //     Adds a command onto the commandbuffer to draw the VR Device's occlusion mesh
        //     to the current render target.
        //
        // 参数:
        //   normalizedCamViewport:
        //     The viewport of the camera currently being rendered.
        public void DrawOcclusionMesh(RectInt normalizedCamViewport);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   vertexCount:
        //     Vertex count to render.
        //
        //   instanceCount:
        //     Instance count to render.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount, MaterialPropertyBlock properties);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   indexCount:
        //     Index count to render.
        //
        //   instanceCount:
        //     Instance count to render.
        //
        //   indexBuffer:
        //     The index buffer used to submit vertices to the GPU.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   vertexCount:
        //     Vertex count to render.
        //
        //   instanceCount:
        //     Instance count to render.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   vertexCount:
        //     Vertex count to render.
        //
        //   instanceCount:
        //     Instance count to render.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   indexCount:
        //     Index count to render.
        //
        //   instanceCount:
        //     Instance count to render.
        //
        //   indexBuffer:
        //     The index buffer used to submit vertices to the GPU.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, MaterialPropertyBlock properties);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   indexCount:
        //     Index count to render.
        //
        //   instanceCount:
        //     Instance count to render.
        //
        //   indexBuffer:
        //     The index buffer used to submit vertices to the GPU.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.
        //
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.
        //
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.
        //
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.
        //
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.
        //
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   indexBuffer:
        //     Index buffer used to submit vertices to the GPU.
        //
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs);
        //
        // 摘要:
        //     Add a "draw procedural geometry" command.
        //
        // 参数:
        //   matrix:
        //     Transformation matrix to use.
        //
        //   material:
        //     Material to use.
        //
        //   shaderPass:
        //     Which pass of the shader to use (or -1 for all passes).
        //
        //   topology:
        //     Topology of the procedural geometry.
        //
        //   properties:
        //     Additional material properties to apply just before rendering. See MaterialPropertyBlock.
        //
        //   bufferWithArgs:
        //     Buffer with draw arguments.
        //
        //   argsOffset:
        //     Byte offset where in the buffer the draw arguments are.
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs);
        public void DrawRenderer(Renderer renderer, Material material);
        public void DrawRenderer(Renderer renderer, Material material, int submeshIndex);
        //
        // 摘要:
        //     Add a "draw renderer" command.
        //
        // 参数:
        //   renderer:
        //     Renderer to draw.
        //
        //   material:
        //     Material to use.
        //
        //   submeshIndex:
        //     Which subset of the mesh to render.
        //
        //   shaderPass:
        //     Which pass of the shader to use (default is -1, which renders all passes).
        public void DrawRenderer(Renderer renderer, Material material, int submeshIndex, int shaderPass);
        //
        // 摘要:
        //     Add a command to enable the hardware scissor rectangle.
        //
        // 参数:
        //   scissor:
        //     Viewport rectangle in pixel coordinates.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::EnableScissorRect", HasExplicitThis = true, ThrowsException = true)]
        public void EnableScissorRect(Rect scissor);
        //
        // 摘要:
        //     Adds a command to enable global shader keyword.
        //
        // 参数:
        //   keyword:
        //     Shader keyword to enable.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::EnableShaderKeyword", HasExplicitThis = true)]
        public void EnableShaderKeyword(string keyword);
        //
        // 摘要:
        //     Adds a command to begin profile sampling.
        //
        // 参数:
        //   name:
        //     Name of the profile information used for sampling.
        //
        //   sampler:
        //     The CustomSampler that the CommandBuffer uses for sampling.
        public void EndSample(CustomSampler sampler);
        //
        // 摘要:
        //     Adds a command to begin profile sampling.
        //
        // 参数:
        //   name:
        //     Name of the profile information used for sampling.
        //
        //   sampler:
        //     The CustomSampler that the CommandBuffer uses for sampling.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::EndSample", HasExplicitThis = true)]
        public void EndSample(string name);
        //
        // 摘要:
        //     Generate mipmap levels of a render texture.
        //
        // 参数:
        //   rt:
        //     The render texture requiring mipmaps generation.
        public void GenerateMips(RenderTexture rt);
        //
        // 摘要:
        //     Generate mipmap levels of a render texture.
        //
        // 参数:
        //   rt:
        //     The render texture requiring mipmaps generation.
        public void GenerateMips(RenderTargetIdentifier rt);


        /*
            Add a "get a temporary render texture" command.
            (很常用的指令): 申请一个 临时的 render target (即 texture)
            参数:
                nameID:
                    Shader property name for this texture.        
                    通常是调用: Shader.PropertyToID("_AAA_Tex"); 获得的, 
                    这是一个由 unity 分配的 texture property 的 id号

                width, height:
                    Width / height in pixels, or -1 for "camera pixel width".
                    想要分配的 rt 的尺寸. 

                depthBuffer:
                    Depth buffer bits (0, 16 or 24).
                    如果你要分配的 rt, 用不到 深度数据, 可直接写 0 
                    (猜测就是不分配了)

                filter:
                    Texture filtering mode (default is Point).

                format:
                    Format of the render texture (default is ARGB32).
        
                readWrite:
                    Color space conversion mode.
        
                antiAliasing:
                    Anti-aliasing (default is no anti-aliasing).
        
                enableRandomWrite:
                    Should random-write access into the texture be enabled (default is false).
        
                desc:
                    Use this RenderTextureDescriptor for the settings when creating the temporary
                    RenderTexture.
        
                memorylessMode:
                    Render texture memoryless mode.
        */
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, GraphicsFormat format, int antiAliasing, bool enableRandomWrite);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, GraphicsFormat format, int antiAliasing);
        
        public void GetTemporaryRT(int nameID, RenderTextureDescriptor desc, FilterMode filter);
        public void GetTemporaryRT(int nameID, int width, int height);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite);
        public void GetTemporaryRT(int nameID, RenderTextureDescriptor desc);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing);
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::GetTemporaryRT", HasExplicitThis = true)]
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, GraphicsFormat format, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode, bool useDynamicScale);
        //
        // 摘要:
        //     Add a "get a temporary render texture" command.
        //
        // 参数:
        //   nameID:
        //     Shader property name for this texture.
        //
        //   width:
        //     Width in pixels, or -1 for "camera pixel width".
        //
        //   height:
        //     Height in pixels, or -1 for "camera pixel height".
        //
        //   depthBuffer:
        //     Depth buffer bits (0, 16 or 24).
        //
        //   filter:
        //     Texture filtering mode (default is Point).
        //
        //   format:
        //     Format of the render texture (default is ARGB32).
        //
        //   readWrite:
        //     Color space conversion mode.
        //
        //   antiAliasing:
        //     Anti-aliasing (default is no anti-aliasing).
        //
        //   enableRandomWrite:
        //     Should random-write access into the texture be enabled (default is false).
        //
        //   desc:
        //     Use this RenderTextureDescriptor for the settings when creating the temporary
        //     RenderTexture.
        //
        //   memorylessMode:
        //     Render texture memoryless mode.
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode, bool useDynamicScale);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, GraphicsFormat format);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, GraphicsFormat format, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode);
        //
        // 摘要:
        //     Add a "get a temporary render texture array" command.
        //
        // 参数:
        //   nameID:
        //     Shader property name for this texture.
        //
        //   width:
        //     Width in pixels, or -1 for "camera pixel width".
        //
        //   height:
        //     Height in pixels, or -1 for "camera pixel height".
        //
        //   slices:
        //     Number of slices in texture array.
        //
        //   depthBuffer:
        //     Depth buffer bits (0, 16 or 24).
        //
        //   filter:
        //     Texture filtering mode (default is Point).
        //
        //   format:
        //     Format of the render texture (default is ARGB32).
        //
        //   readWrite:
        //     Color space conversion mode.
        //
        //   antiAliasing:
        //     Anti-aliasing (default is no anti-aliasing).
        //
        //   enableRandomWrite:
        //     Should random-write access into the texture be enabled (default is false).
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite);
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer, FilterMode filter, GraphicsFormat format, int antiAliasing);
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer, FilterMode filter, GraphicsFormat format);
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing);
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite);
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer, FilterMode filter, RenderTextureFormat format);
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer, FilterMode filter);
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer);
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices);
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer, FilterMode filter, GraphicsFormat format, int antiAliasing, bool enableRandomWrite);
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::GetTemporaryRTArray", HasExplicitThis = true)]
        public void GetTemporaryRTArray(int nameID, int width, int height, int slices, int depthBuffer, FilterMode filter, GraphicsFormat format, int antiAliasing, bool enableRandomWrite, bool useDynamicScale);
        //
        // 摘要:
        //     Increments the updateCount property of a Texture.
        //
        // 参数:
        //   dest:
        //     Increments the updateCount for this Texture.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::IncrementUpdateCount", HasExplicitThis = true)]
        public void IncrementUpdateCount(RenderTargetIdentifier dest);
        //
        // 摘要:
        //     Send a user-defined blit event to a native code plugin.
        //
        // 参数:
        //   callback:
        //     Native code callback to queue for Unity's renderer to invoke.
        //
        //   command:
        //     User defined command id to send to the callback.
        //
        //   source:
        //     Source render target.
        //
        //   dest:
        //     Destination render target.
        //
        //   commandParam:
        //     User data command parameters.
        //
        //   commandFlags:
        //     User data command flags.
        public void IssuePluginCustomBlit(IntPtr callback, uint command, RenderTargetIdentifier source, RenderTargetIdentifier dest, uint commandParam, uint commandFlags);
        //
        // 摘要:
        //     Deprecated. Use CommandBuffer.IssuePluginCustomTextureUpdateV2 instead.
        //
        // 参数:
        //   callback:
        //     Native code callback to queue for Unity's renderer to invoke.
        //
        //   targetTexture:
        //     Texture resource to be updated.
        //
        //   userData:
        //     User data to send to the native plugin.
        [Obsolete("Use IssuePluginCustomTextureUpdateV2 to register TextureUpdate callbacks instead. Callbacks will be passed event IDs kUnityRenderingExtEventUpdateTextureBeginV2 or kUnityRenderingExtEventUpdateTextureEndV2, and data parameter of type UnityRenderingExtTextureUpdateParamsV2.", false)]
        public void IssuePluginCustomTextureUpdate(IntPtr callback, Texture targetTexture, uint userData);
        //
        // 摘要:
        //     Deprecated. Use CommandBuffer.IssuePluginCustomTextureUpdateV2 instead.
        //
        // 参数:
        //   callback:
        //     Native code callback to queue for Unity's renderer to invoke.
        //
        //   targetTexture:
        //     Texture resource to be updated.
        //
        //   userData:
        //     User data to send to the native plugin.
        [Obsolete("Use IssuePluginCustomTextureUpdateV2 to register TextureUpdate callbacks instead. Callbacks will be passed event IDs kUnityRenderingExtEventUpdateTextureBeginV2 or kUnityRenderingExtEventUpdateTextureEndV2, and data parameter of type UnityRenderingExtTextureUpdateParamsV2.", false)]
        public void IssuePluginCustomTextureUpdateV1(IntPtr callback, Texture targetTexture, uint userData);
        //
        // 摘要:
        //     Send a texture update event to a native code plugin.
        //
        // 参数:
        //   callback:
        //     Native code callback to queue for Unity's renderer to invoke.
        //
        //   targetTexture:
        //     Texture resource to be updated.
        //
        //   userData:
        //     User data to send to the native plugin.
        public void IssuePluginCustomTextureUpdateV2(IntPtr callback, Texture targetTexture, uint userData);
        //
        // 摘要:
        //     Send a user-defined event to a native code plugin.
        //
        // 参数:
        //   callback:
        //     Native code callback to queue for Unity's renderer to invoke.
        //
        //   eventID:
        //     User defined id to send to the callback.
        public void IssuePluginEvent(IntPtr callback, int eventID);
        //
        // 摘要:
        //     Send a user-defined event to a native code plugin with custom data.
        //
        // 参数:
        //   callback:
        //     Native code callback to queue for Unity's renderer to invoke.
        //
        //   data:
        //     Custom data to pass to the native plugin callback.
        //
        //   eventID:
        //     Built in or user defined id to send to the callback.
        public void IssuePluginEventAndData(IntPtr callback, int eventID, IntPtr data);
        public void ProcessVTFeedback(RenderTargetIdentifier rt, IntPtr resolver, int slice, int x, int width, int y, int height, int mip);
        public void Release();
        //
        // 摘要:
        //     Add a "release a temporary render texture" command.
        //
        // 参数:
        //   nameID:
        //     Shader property name for this texture.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::ReleaseTemporaryRT", HasExplicitThis = true)]
        public void ReleaseTemporaryRT(int nameID);
        public void RequestAsyncReadback(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(Texture src, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(Texture src, int mipIndex, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(Texture src, int mipIndex, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadback(Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback);
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        public void RequestAsyncReadbackIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, Action<AsyncGPUReadbackRequest> callback) where T : struct;
        //
        // 摘要:
        //     Force an antialiased render texture to be resolved.
        //
        // 参数:
        //   rt:
        //     The antialiased render texture to resolve.
        //
        //   target:
        //     The render texture to resolve into. If set, the target render texture must have
        //     the same dimensions and format as the source.
        public void ResolveAntiAliasedSurface(RenderTexture rt, RenderTexture target = null);
        //
        // 摘要:
        //     Adds a command to set the counter value of append/consume buffer.
        //
        // 参数:
        //   buffer:
        //     The destination buffer.
        //
        //   counterValue:
        //     Value of the append/consume counter.
        [FreeFunctionAttribute(Name = "RenderingCommandBuffer_Bindings::InternalSetComputeBufferCounterValue", HasExplicitThis = true)]
        public void SetComputeBufferCounterValue([NotNullAttribute("ArgumentNullException")] ComputeBuffer buffer, uint counterValue);
        [SecuritySafeCritical]
        public void SetComputeBufferData<T>(ComputeBuffer buffer, NativeArray<T> data) where T : struct;
        //
        // 摘要:
        //     Adds a command to process a partial copy of data values from an array into the
        //     buffer.
        //
        // 参数:
        //   buffer:
        //     The destination buffer.
        //
        //   data:
        //     Array of values to fill the buffer.
        //
        //   managedBufferStartIndex:
        //     The first element index in data to copy to the compute buffer.
        //
        //   graphicsBufferStartIndex:
        //     The first element index in compute buffer to receive the data.
        //
        //   count:
        //     The number of elements to copy.
        //
        //   nativeBufferStartIndex:
        //     The first element index in data to copy to the compute buffer.
        [SecuritySafeCritical]
        public void SetComputeBufferData(ComputeBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count);
        [SecuritySafeCritical]
        public void SetComputeBufferData<T>(ComputeBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) where T : struct;
        [SecuritySafeCritical]
        public void SetComputeBufferData<T>(ComputeBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count) where T : struct;
        //
        // 摘要:
        //     Adds a command to set the buffer with values from an array.
        //
        // 参数:
        //   buffer:
        //     The destination buffer.
        //
        //   data:
        //     Array of values to fill the buffer.
        [SecuritySafeCritical]
        public void SetComputeBufferData(ComputeBuffer buffer, Array data);
        [SecuritySafeCritical]
        public void SetComputeBufferData<T>(ComputeBuffer buffer, List<T> data) where T : struct;
        //
        // 摘要:
        //     Adds a command to set an input or output buffer parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the buffer is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   buffer:
        //     Buffer to set.
        public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, ComputeBuffer buffer);
        //
        // 摘要:
        //     Adds a command to set an input or output buffer parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the buffer is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   buffer:
        //     Buffer to set.
        public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBuffer buffer);
        //
        // 摘要:
        //     Adds a command to set an input or output buffer parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the buffer is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   buffer:
        //     Buffer to set.
        public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, ComputeBuffer buffer);
        //
        // 摘要:
        //     Adds a command to set an input or output buffer parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the buffer is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the buffer variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   buffer:
        //     Buffer to set.
        public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBuffer buffer);
        //
        // 摘要:
        //     Adds a command to set a constant buffer on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     The ComputeShader to set parameter for.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the constant buffer in shaders code.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, GraphicsBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Adds a command to set a constant buffer on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     The ComputeShader to set parameter for.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the constant buffer in shaders code.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, GraphicsBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Adds a command to set a constant buffer on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     The ComputeShader to set parameter for.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the constant buffer in shaders code.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, ComputeBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Adds a command to set a constant buffer on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     The ComputeShader to set parameter for.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the constant buffer in shaders code.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, ComputeBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Adds a command to set a float parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetComputeFloatParam", HasExplicitThis = true)]
        public void SetComputeFloatParam([NotNullAttribute("ArgumentNullException")] ComputeShader computeShader, int nameID, float val);
        //
        // 摘要:
        //     Adds a command to set a float parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetComputeFloatParam(ComputeShader computeShader, string name, float val);
        //
        // 摘要:
        //     Adds a command to set multiple consecutive float parameters on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Values to set.
        public void SetComputeFloatParams(ComputeShader computeShader, int nameID, params float[] values);
        //
        // 摘要:
        //     Adds a command to set multiple consecutive float parameters on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Values to set.
        public void SetComputeFloatParams(ComputeShader computeShader, string name, params float[] values);
        //
        // 摘要:
        //     Adds a command to set an integer parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetComputeIntParam", HasExplicitThis = true)]
        public void SetComputeIntParam([NotNullAttribute("ArgumentNullException")] ComputeShader computeShader, int nameID, int val);
        //
        // 摘要:
        //     Adds a command to set an integer parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetComputeIntParam(ComputeShader computeShader, string name, int val);
        //
        // 摘要:
        //     Adds a command to set multiple consecutive integer parameters on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Values to set.
        public void SetComputeIntParams(ComputeShader computeShader, string name, params int[] values);
        //
        // 摘要:
        //     Adds a command to set multiple consecutive integer parameters on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Values to set.
        public void SetComputeIntParams(ComputeShader computeShader, int nameID, params int[] values);
        //
        // 摘要:
        //     Adds a command to set a matrix array parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Value to set.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetComputeMatrixArrayParam", HasExplicitThis = true)]
        public void SetComputeMatrixArrayParam([NotNullAttribute("ArgumentNullException")] ComputeShader computeShader, int nameID, Matrix4x4[] values);
        //
        // 摘要:
        //     Adds a command to set a matrix array parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Value to set.
        public void SetComputeMatrixArrayParam(ComputeShader computeShader, string name, Matrix4x4[] values);
        //
        // 摘要:
        //     Adds a command to set a matrix parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetComputeMatrixParam", HasExplicitThis = true)]
        public void SetComputeMatrixParam([NotNullAttribute("ArgumentNullException")] ComputeShader computeShader, int nameID, Matrix4x4 val);
        //
        // 摘要:
        //     Adds a command to set a matrix parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetComputeMatrixParam(ComputeShader computeShader, string name, Matrix4x4 val);
        //
        // 摘要:
        //     Adds a command to set a texture parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the texture is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the texture variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   rt:
        //     Texture value or identifier to set, see RenderTargetIdentifier.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt, int mipLevel);
        //
        // 摘要:
        //     Adds a command to set a texture parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the texture is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the texture variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   rt:
        //     Texture value or identifier to set, see RenderTargetIdentifier.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt);
        //
        // 摘要:
        //     Adds a command to set a texture parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the texture is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the texture variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   rt:
        //     Texture value or identifier to set, see RenderTargetIdentifier.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt);
        //
        // 摘要:
        //     Adds a command to set a texture parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the texture is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the texture variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   rt:
        //     Texture value or identifier to set, see RenderTargetIdentifier.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt, int mipLevel);
        //
        // 摘要:
        //     Adds a command to set a texture parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the texture is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the texture variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   rt:
        //     Texture value or identifier to set, see RenderTargetIdentifier.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element);
        //
        // 摘要:
        //     Adds a command to set a texture parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   kernelIndex:
        //     Which kernel the texture is being set for. See ComputeShader.FindKernel.
        //
        //   name:
        //     Name of the texture variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   rt:
        //     Texture value or identifier to set, see RenderTargetIdentifier.
        //
        //   mipLevel:
        //     Optional mipmap level of the read-write texture.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element);
        //
        // 摘要:
        //     Adds a command to set a vector array parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Property name.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Value to set.
        public void SetComputeVectorArrayParam(ComputeShader computeShader, string name, Vector4[] values);
        //
        // 摘要:
        //     Adds a command to set a vector array parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Property name.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Value to set.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetComputeVectorArrayParam", HasExplicitThis = true)]
        public void SetComputeVectorArrayParam([NotNullAttribute("ArgumentNullException")] ComputeShader computeShader, int nameID, Vector4[] values);
        //
        // 摘要:
        //     Adds a command to set a vector parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetComputeVectorParam(ComputeShader computeShader, string name, Vector4 val);
        //
        // 摘要:
        //     Adds a command to set a vector parameter on a ComputeShader.
        //
        // 参数:
        //   computeShader:
        //     ComputeShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetComputeVectorParam", HasExplicitThis = true)]
        public void SetComputeVectorParam([NotNullAttribute("ArgumentNullException")] ComputeShader computeShader, int nameID, Vector4 val);
        //
        // 摘要:
        //     Set flags describing the intention for how the command buffer will be executed.
        //
        // 参数:
        //   flags:
        //     The flags to set.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetExecutionFlags", HasExplicitThis = true, ThrowsException = true)]
        public void SetExecutionFlags(CommandBufferExecutionFlags flags);
        //
        // 摘要:
        //     Add a "set global shader buffer property" command.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   value:
        //     The buffer to set.
        public void SetGlobalBuffer(string name, ComputeBuffer value);
        //
        // 摘要:
        //     Add a "set global shader buffer property" command.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   value:
        //     The buffer to set.
        public void SetGlobalBuffer(int nameID, ComputeBuffer value);
        //
        // 摘要:
        //     Add a "set global shader buffer property" command.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   value:
        //     The buffer to set.
        public void SetGlobalBuffer(string name, GraphicsBuffer value);
        //
        // 摘要:
        //     Add a "set global shader buffer property" command.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   value:
        //     The buffer to set.
        public void SetGlobalBuffer(int nameID, GraphicsBuffer value);
        //
        // 摘要:
        //     Add a "set global shader color property" command.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalColor", HasExplicitThis = true)]
        public void SetGlobalColor(int nameID, Color value);
        //
        // 摘要:
        //     Add a "set global shader color property" command.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        public void SetGlobalColor(string name, Color value);
        //
        // 摘要:
        //     Add a command to bind a global constant buffer.
        //
        // 参数:
        //   nameID:
        //     The name ID of the constant buffer retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the constant buffer to override.
        //
        //   buffer:
        //     The buffer to bind.
        //
        //   offset:
        //     Offset from the start of the buffer in bytes.
        //
        //   size:
        //     Size in bytes of the area to bind.
        public void SetGlobalConstantBuffer(ComputeBuffer buffer, int nameID, int offset, int size);
        //
        // 摘要:
        //     Add a command to bind a global constant buffer.
        //
        // 参数:
        //   nameID:
        //     The name ID of the constant buffer retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the constant buffer to override.
        //
        //   buffer:
        //     The buffer to bind.
        //
        //   offset:
        //     Offset from the start of the buffer in bytes.
        //
        //   size:
        //     Size in bytes of the area to bind.
        public void SetGlobalConstantBuffer(GraphicsBuffer buffer, int nameID, int offset, int size);
        //
        // 摘要:
        //     Add a command to bind a global constant buffer.
        //
        // 参数:
        //   nameID:
        //     The name ID of the constant buffer retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the constant buffer to override.
        //
        //   buffer:
        //     The buffer to bind.
        //
        //   offset:
        //     Offset from the start of the buffer in bytes.
        //
        //   size:
        //     Size in bytes of the area to bind.
        public void SetGlobalConstantBuffer(GraphicsBuffer buffer, string name, int offset, int size);
        //
        // 摘要:
        //     Add a command to bind a global constant buffer.
        //
        // 参数:
        //   nameID:
        //     The name ID of the constant buffer retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the constant buffer to override.
        //
        //   buffer:
        //     The buffer to bind.
        //
        //   offset:
        //     Offset from the start of the buffer in bytes.
        //
        //   size:
        //     Size in bytes of the area to bind.
        public void SetGlobalConstantBuffer(ComputeBuffer buffer, string name, int offset, int size);
        //
        // 摘要:
        //     Add a command to set global depth bias.
        //
        // 参数:
        //   bias:
        //     Constant depth bias.
        //
        //   slopeBias:
        //     Slope-dependent depth bias.
        [NativeMethodAttribute("AddSetGlobalDepthBias")]
        public void SetGlobalDepthBias(float bias, float slopeBias);
        //
        // 摘要:
        //     Add a "set global shader float property" command.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        public void SetGlobalFloat(string name, float value);
        //
        // 摘要:
        //     Add a "set global shader float property" command.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalFloat", HasExplicitThis = true)]
        public void SetGlobalFloat(int nameID, float value);
        //
        // 摘要:
        //     Add a "set global shader float array property" command.
        //
        // 参数:
        //   propertyName:
        //
        //   values:
        //
        //   nameID:
        public void SetGlobalFloatArray(string propertyName, float[] values);
        //
        // 摘要:
        //     Add a "set global shader float array property" command.
        //
        // 参数:
        //   propertyName:
        //
        //   values:
        //
        //   nameID:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalFloatArray", HasExplicitThis = true, ThrowsException = true)]
        public void SetGlobalFloatArray(int nameID, float[] values);
        public void SetGlobalFloatArray(string propertyName, List<float> values);
        public void SetGlobalFloatArray(int nameID, List<float> values);
        //
        // 摘要:
        //     Sets the given global integer property for all shaders.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalInt", HasExplicitThis = true)]
        public void SetGlobalInt(int nameID, int value);
        //
        // 摘要:
        //     Sets the given global integer property for all shaders.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        public void SetGlobalInt(string name, int value);
        //
        // 摘要:
        //     Add a "set global shader matrix property" command.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        public void SetGlobalMatrix(string name, Matrix4x4 value);
        //
        // 摘要:
        //     Add a "set global shader matrix property" command.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalMatrix", HasExplicitThis = true)]
        public void SetGlobalMatrix(int nameID, Matrix4x4 value);
        public void SetGlobalMatrixArray(string propertyName, List<Matrix4x4> values);
        //
        // 摘要:
        //     Add a "set global shader matrix array property" command.
        //
        // 参数:
        //   propertyName:
        //
        //   values:
        //
        //   nameID:
        public void SetGlobalMatrixArray(string propertyName, Matrix4x4[] values);
        //
        // 摘要:
        //     Add a "set global shader matrix array property" command.
        //
        // 参数:
        //   propertyName:
        //
        //   values:
        //
        //   nameID:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalMatrixArray", HasExplicitThis = true, ThrowsException = true)]
        public void SetGlobalMatrixArray(int nameID, Matrix4x4[] values);
        public void SetGlobalMatrixArray(int nameID, List<Matrix4x4> values);
        //
        // 摘要:
        //     Add a "set global shader texture property" command, referencing a RenderTexture.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        //
        //   element:
        public void SetGlobalTexture(int nameID, RenderTargetIdentifier value, RenderTextureSubElement element);
        //
        // 摘要:
        //     Add a "set global shader texture property" command, referencing a RenderTexture.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        //
        //   element:
        public void SetGlobalTexture(string name, RenderTargetIdentifier value, RenderTextureSubElement element);
        //
        // 摘要:
        //     Add a "set global shader texture property" command, referencing a RenderTexture.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        //
        //   element:
        public void SetGlobalTexture(int nameID, RenderTargetIdentifier value);
        //
        // 摘要:
        //     Add a "set global shader texture property" command, referencing a RenderTexture.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        //
        //   element:
        public void SetGlobalTexture(string name, RenderTargetIdentifier value);
        //
        // 摘要:
        //     Add a "set global shader vector property" command.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        public void SetGlobalVector(string name, Vector4 value);
        //
        // 摘要:
        //     Add a "set global shader vector property" command.
        //
        // 参数:
        //   name:
        //
        //   value:
        //
        //   nameID:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalVector", HasExplicitThis = true)]
        public void SetGlobalVector(int nameID, Vector4 value);
        public void SetGlobalVectorArray(int nameID, List<Vector4> values);
        public void SetGlobalVectorArray(string propertyName, List<Vector4> values);
        //
        // 摘要:
        //     Add a "set global shader vector array property" command.
        //
        // 参数:
        //   propertyName:
        //
        //   values:
        //
        //   nameID:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalVectorArray", HasExplicitThis = true, ThrowsException = true)]
        public void SetGlobalVectorArray(int nameID, Vector4[] values);
        //
        // 摘要:
        //     Add a "set global shader vector array property" command.
        //
        // 参数:
        //   propertyName:
        //
        //   values:
        //
        //   nameID:
        public void SetGlobalVectorArray(string propertyName, Vector4[] values);
        //
        // 摘要:
        //     Adds a command to multiply the instance count of every draw call by a specific
        //     multiplier.
        //
        // 参数:
        //   multiplier:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetInstanceMultiplier", HasExplicitThis = true)]
        public void SetInstanceMultiplier(uint multiplier);
        //
        // 摘要:
        //     Add a "set invert culling" command to the buffer.
        //
        // 参数:
        //   invertCulling:
        //     A boolean indicating whether to invert the backface culling (true) or not (false).
        [NativeMethodAttribute("AddSetInvertCulling")]
        public void SetInvertCulling(bool invertCulling);
        //
        // 摘要:
        //     Add a command to set the projection matrix.
        //
        // 参数:
        //   proj:
        //     Projection (camera to clip space) matrix.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetProjectionMatrix", HasExplicitThis = true, ThrowsException = true)]
        public void SetProjectionMatrix(Matrix4x4 proj);
        //
        // 摘要:
        //     Set random write target for level pixel shaders.
        //
        // 参数:
        //   index:
        //     Index of the random write target in the shader.
        //
        //   buffer:
        //     Buffer to set as the write target.
        //
        //   preserveCounterValue:
        //     Whether to leave the append/consume counter value unchanged.
        //
        //   rt:
        //     RenderTargetIdentifier to set as the write target.
        public void SetRandomWriteTarget(int index, GraphicsBuffer buffer, bool preserveCounterValue);
        //
        // 摘要:
        //     Set random write target for level pixel shaders.
        //
        // 参数:
        //   index:
        //     Index of the random write target in the shader.
        //
        //   buffer:
        //     Buffer to set as the write target.
        //
        //   preserveCounterValue:
        //     Whether to leave the append/consume counter value unchanged.
        //
        //   rt:
        //     RenderTargetIdentifier to set as the write target.
        public void SetRandomWriteTarget(int index, GraphicsBuffer buffer);
        //
        // 摘要:
        //     Set random write target for level pixel shaders.
        //
        // 参数:
        //   index:
        //     Index of the random write target in the shader.
        //
        //   buffer:
        //     Buffer to set as the write target.
        //
        //   preserveCounterValue:
        //     Whether to leave the append/consume counter value unchanged.
        //
        //   rt:
        //     RenderTargetIdentifier to set as the write target.
        public void SetRandomWriteTarget(int index, ComputeBuffer buffer, bool preserveCounterValue);
        //
        // 摘要:
        //     Set random write target for level pixel shaders.
        //
        // 参数:
        //   index:
        //     Index of the random write target in the shader.
        //
        //   buffer:
        //     Buffer to set as the write target.
        //
        //   preserveCounterValue:
        //     Whether to leave the append/consume counter value unchanged.
        //
        //   rt:
        //     RenderTargetIdentifier to set as the write target.
        public void SetRandomWriteTarget(int index, RenderTargetIdentifier rt);
        //
        // 摘要:
        //     Set random write target for level pixel shaders.
        //
        // 参数:
        //   index:
        //     Index of the random write target in the shader.
        //
        //   buffer:
        //     Buffer to set as the write target.
        //
        //   preserveCounterValue:
        //     Whether to leave the append/consume counter value unchanged.
        //
        //   rt:
        //     RenderTargetIdentifier to set as the write target.
        public void SetRandomWriteTarget(int index, ComputeBuffer buffer);
        //
        // 摘要:
        //     Adds a command to set the RayTracingAccelerationStructure to be used with the
        //     RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     The RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the RayTracingAccelerationStructure in shader coder.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   rayTracingAccelerationStructure:
        //     The RayTracingAccelerationStructure to be used.
        public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, int nameID, RayTracingAccelerationStructure rayTracingAccelerationStructure);
        //
        // 摘要:
        //     Adds a command to set the RayTracingAccelerationStructure to be used with the
        //     RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     The RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the RayTracingAccelerationStructure in shader coder.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   rayTracingAccelerationStructure:
        //     The RayTracingAccelerationStructure to be used.
        public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure);
        //
        // 摘要:
        //     Adds a command to set an input or output buffer parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     The RayTracingShader to set parameter for.
        //
        //   name:
        //     The name of the constant buffer in shader code.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   buffer:
        //     Buffer to set.
        public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer);
        //
        // 摘要:
        //     Adds a command to set an input or output buffer parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     The RayTracingShader to set parameter for.
        //
        //   name:
        //     The name of the constant buffer in shader code.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   buffer:
        //     Buffer to set.
        public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer);
        //
        // 摘要:
        //     Adds a command to set a constant buffer on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     The RayTracingShader to set parameter for.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the constant buffer in shader code.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Adds a command to set a constant buffer on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     The RayTracingShader to set parameter for.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the constant buffer in shader code.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Adds a command to set a constant buffer on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     The RayTracingShader to set parameter for.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the constant buffer in shader code.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Adds a command to set a constant buffer on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     The RayTracingShader to set parameter for.
        //
        //   nameID:
        //     The ID of the property name for the constant buffer in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   name:
        //     The name of the constant buffer in shader code.
        //
        //   buffer:
        //     The buffer to bind as constant buffer.
        //
        //   offset:
        //     The offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer, int offset, int size);
        //
        // 摘要:
        //     Adds a command to set a float parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, string name, float val);
        //
        // 摘要:
        //     Adds a command to set a float parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, int nameID, float val);
        //
        // 摘要:
        //     Adds a command to set multiple consecutive float parameters on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Values to set.
        public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, string name, params float[] values);
        //
        // 摘要:
        //     Adds a command to set multiple consecutive float parameters on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Values to set.
        public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, int nameID, params float[] values);
        //
        // 摘要:
        //     Adds a command to set an integer parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetRayTracingIntParam(RayTracingShader rayTracingShader, int nameID, int val);
        //
        // 摘要:
        //     Adds a command to set an integer parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetRayTracingIntParam(RayTracingShader rayTracingShader, string name, int val);
        //
        // 摘要:
        //     Adds a command to set multiple consecutive integer parameters on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Values to set.
        public void SetRayTracingIntParams(RayTracingShader rayTracingShader, string name, params int[] values);
        //
        // 摘要:
        //     Adds a command to set multiple consecutive integer parameters on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Values to set.
        public void SetRayTracingIntParams(RayTracingShader rayTracingShader, int nameID, params int[] values);
        //
        // 摘要:
        //     Adds a command to set a matrix array parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Value to set.
        public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, int nameID, params Matrix4x4[] values);
        //
        // 摘要:
        //     Adds a command to set a matrix array parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Value to set.
        public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, string name, params Matrix4x4[] values);
        //
        // 摘要:
        //     Adds a command to set a matrix parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, int nameID, Matrix4x4 val);
        //
        // 摘要:
        //     Adds a command to set a matrix parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, string name, Matrix4x4 val);
        //
        // 摘要:
        //     Adds a command to select which Shader Pass to use when executing ray/geometry
        //     intersection shaders.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   passName:
        //     The Shader Pass to use when executing ray tracing shaders.
        [NativeMethodAttribute("AddSetRayTracingShaderPass")]
        public void SetRayTracingShaderPass([NotNullAttribute("ArgumentNullException")] RayTracingShader rayTracingShader, string passName);
        //
        // 摘要:
        //     Adds a command to set a texture parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the texture variable in shader code.
        //
        //   nameID:
        //     The ID of the property name for the texture in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   rt:
        //     Texture value or identifier to set, see RenderTargetIdentifier.
        public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, string name, RenderTargetIdentifier rt);
        //
        // 摘要:
        //     Adds a command to set a texture parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the texture variable in shader code.
        //
        //   nameID:
        //     The ID of the property name for the texture in shader code. Use Shader.PropertyToID
        //     to get this ID.
        //
        //   rt:
        //     Texture value or identifier to set, see RenderTargetIdentifier.
        public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, int nameID, RenderTargetIdentifier rt);
        //
        // 摘要:
        //     Adds a command to set a vector array parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Property name.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Value to set.
        public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, int nameID, params Vector4[] values);
        //
        // 摘要:
        //     Adds a command to set a vector array parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Property name.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Value to set.
        public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, string name, params Vector4[] values);
        //
        // 摘要:
        //     Adds a command to set a vector parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, int nameID, Vector4 val);
        //
        // 摘要:
        //     Adds a command to set a vector parameter on a RayTracingShader.
        //
        // 参数:
        //   rayTracingShader:
        //     RayTracingShader to set parameter for.
        //
        //   name:
        //     Name of the variable in shader code.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   val:
        //     Value to set.
        public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, string name, Vector4 val);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetBinding binding);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetBinding binding, int mipLevel, CubemapFace cubemapFace, int depthSlice);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace, int depthSlice);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier color, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depth, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace, int depthSlice);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier rt);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier rt, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier rt, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel, CubemapFace cubemapFace);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel, CubemapFace cubemapFace, int depthSlice);
        //
        // 摘要:
        //     Add a "set active render target" command.
        //
        // 参数:
        //   rt:
        //     Render target to set for both color & depth buffers.
        //
        //   color:
        //     Render target to set as a color buffer.
        //
        //   colors:
        //     Render targets to set as color buffers (MRT).
        //
        //   depth:
        //     Render target to set as a depth buffer.
        //
        //   mipLevel:
        //     The mip level of the render target to render into.
        //
        //   cubemapFace:
        //     The cubemap face of a cubemap render target to render into.
        //
        //   depthSlice:
        //     Slice of a 3D or array render target to set.
        //
        //   loadAction:
        //     Load action that is used for color and depth/stencil buffers.
        //
        //   storeAction:
        //     Store action that is used for color and depth/stencil buffers.
        //
        //   colorLoadAction:
        //     Load action that is used for the color buffer.
        //
        //   colorStoreAction:
        //     Store action that is used for the color buffer.
        //
        //   depthLoadAction:
        //     Load action that is used for the depth/stencil buffer.
        //
        //   depthStoreAction:
        //     Store action that is used for the depth/stencil buffer.
        //
        //   binding:
        public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth);
        //
        // 摘要:
        //     Add a "set shadow sampling mode" command.
        //
        // 参数:
        //   shadowmap:
        //     Shadowmap render target to change the sampling mode on.
        //
        //   mode:
        //     New sampling mode.
        public void SetShadowSamplingMode(RenderTargetIdentifier shadowmap, ShadowSamplingMode mode);
        public void SetSinglePassStereo(SinglePassStereoMode mode);
        //
        // 摘要:
        //     Add a command to set the view matrix.
        //
        // 参数:
        //   view:
        //     View (world to camera space) matrix.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetViewMatrix", HasExplicitThis = true, ThrowsException = true)]
        public void SetViewMatrix(Matrix4x4 view);
        //
        // 摘要:
        //     Add a command to set the rendering viewport.
        //
        // 参数:
        //   pixelRect:
        //     Viewport rectangle in pixel coordinates.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetViewport", HasExplicitThis = true, ThrowsException = true)]
        public void SetViewport(Rect pixelRect);
        //
        // 摘要:
        //     Add a command to set the view and projection matrices.
        //
        // 参数:
        //   view:
        //     View (world to camera space) matrix.
        //
        //   proj:
        //     Projection (camera to clip space) matrix.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetViewProjectionMatrices", HasExplicitThis = true, ThrowsException = true)]
        public void SetViewProjectionMatrices(Matrix4x4 view, Matrix4x4 proj);
        //
        // 摘要:
        //     Adds an "AsyncGPUReadback.WaitAllRequests" command to the CommandBuffer.
        [NativeMethodAttribute("AddWaitAllAsyncReadbackRequests")]
        public void WaitAllAsyncReadbackRequests();
        public void WaitOnAsyncGraphicsFence(GraphicsFence fence, SynchronisationStageFlags stage);
        //
        // 摘要:
        //     Instructs the GPU to wait until the given GraphicsFence is passed.
        //
        // 参数:
        //   fence:
        //     The GraphicsFence that the GPU will be instructed to wait upon before proceeding
        //     with its processing of the graphics queue.
        //
        //   stage:
        //     On some platforms there is a significant gap between the vertex processing completing
        //     and the pixel processing beginning for a given draw call. This parameter allows
        //     for a requested wait to be made before the next item's vertex or pixel processing
        //     begins. If a compute shader dispatch is the next item to be submitted then this
        //     parameter is ignored.
        public void WaitOnAsyncGraphicsFence(GraphicsFence fence);
        //
        // 摘要:
        //     Instructs the GPU to wait until the given GraphicsFence is passed.
        //
        // 参数:
        //   fence:
        //     The GraphicsFence that the GPU will be instructed to wait upon before proceeding
        //     with its processing of the graphics queue.
        //
        //   stage:
        //     On some platforms there is a significant gap between the vertex processing completing
        //     and the pixel processing beginning for a given draw call. This parameter allows
        //     for a requested wait to be made before the next item's vertex or pixel processing
        //     begins. If a compute shader dispatch is the next item to be submitted then this
        //     parameter is ignored.
        public void WaitOnAsyncGraphicsFence(GraphicsFence fence, SynchronisationStage stage);
        //
        // 摘要:
        //     This functionality is deprecated, and should no longer be used. Please use CommandBuffer.WaitOnAsyncGraphicsFence.
        //
        // 参数:
        //   fence:
        //     The GPUFence that the GPU will be instructed to wait upon.
        //
        //   stage:
        //     On some platforms there is a significant gap between the vertex processing completing
        //     and the pixel processing completing for a given draw call. This parameter allows
        //     for requested wait to be before the next items vertex or pixel processing begins.
        //     Some platforms can not differentiate between the start of vertex and pixel processing,
        //     these platforms will wait before the next items vertex processing. If a compute
        //     shader dispatch is the next item to be submitted then this parameter is ignored.
        [Obsolete("CommandBuffer.WaitOnGPUFence has been deprecated. Use WaitOnGraphicsFence instead (UnityUpgradable) -> WaitOnAsyncGraphicsFence(*)", false)]
        public void WaitOnGPUFence(GPUFence fence, SynchronisationStage stage);
        [Obsolete("CommandBuffer.WaitOnGPUFence has been deprecated. Use WaitOnGraphicsFence instead (UnityUpgradable) -> WaitOnAsyncGraphicsFence(*)", false)]
        public void WaitOnGPUFence(GPUFence fence);
    }
}