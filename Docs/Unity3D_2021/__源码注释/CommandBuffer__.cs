/*
    CommandBuffer
    简略笔记 

    commandbuffer 持有一组 rendering commands，这些 commands 可被设置在数个指定的节点上。
    在 camera rendering 期间：如：Camera.AddCommandBuffer()
        此函数通过 CameraEvent 来确定插入的 流程时间点

    在 light rendering 区间：如： Light.AddCommandBuffer()
        此函数通过 LightEvent 来确定插入的 流程时间点 
        （注意，它提供的插入点，和 CameraEvent 是不一样的）


    也可被直接“调用”，如： Graphics.ExecuteCommandBuffer() (个人猜测类似 submit() )

    (上面的函数 估计是被用于 built-in 管线)

    通常，cb 将被用来自定义 渲染管线。 

*/

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
    public class CommandBuffer : IDisposable//CommandBuffer__
    {
        
        // 摘要:
        //     Create a new empty command buffer.
        public CommandBuffer();

        ~CommandBuffer();


        // 摘要:
        //     Size of this command buffer in bytes (Read Only).
        public int sizeInBytes { get; }
        
        // 摘要:
        //     Name of this command buffer.
        public string name { get; set; }

        
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
        public void BeginSample(CustomSampler sampler);
        
        /*
            摘要:
                Add a "blit into a render texture" command.
                ---
                安排一个指令: 将 src 中的数据 复制到 dest 中; 
                在复制中途, 可使用 material - shader - pass 中的代码 来 "处理" 原始数据
            
            参数:
            source:
                Source texture or render target to blit from.
            dest:
                Destination to blit into.
            mat:
                Material to use.
            pass:
                Shader pass to use (default is -1, meaning "all passes").

            scale:
            offset:
                Scale / offset applied to the source texture coordinate.
                ---
                猜测这组针对 coords 的调整, 是针对 texture 中的每一个 texl 执行的;
            
            sourceDepthSlice:
                The texture array source slice to perform the blit from.
                如果 source 是一个 texture array, 用此 idx 选择倒是针对哪一层
            destDepthSlice:
                The texture array destination slice to perform the blit to.
                如果 dest 是一个 texture array, 用此 idx 选择倒是针对哪一层
        */
        public void Blit(Texture source, RenderTargetIdentifier dest, Vector2 scale, Vector2 offset);
        public void Blit(Texture source, RenderTargetIdentifier dest, Material mat);
        public void Blit(Texture source, RenderTargetIdentifier dest);
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest);
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Vector2 scale, Vector2 offset);
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Material mat);
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Material mat, int pass);
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, int sourceDepthSlice, int destDepthSlice);
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Vector2 scale, Vector2 offset, int sourceDepthSlice, int destDepthSlice);
        public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Material mat, int pass, int destDepthSlice);
        public void Blit(Texture source, RenderTargetIdentifier dest, Material mat, int pass);


        // 摘要:
        //     Adds a command to build the RayTracingAccelerationStructure to be used in a ray tracing dispatch.
        //
        // 参数:
        //   accelerationStructure:
        //     The RayTracingAccelerationStructure to be generated.
        public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure, Vector3 relativeOrigin);
        public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure);
        

        // 摘要:
        //     Clear all commands in the buffer.
        [NativeMethodAttribute("ClearCommands")]
        public void Clear();
        
        // 摘要:
        //     Clear random write targets for level pixel shaders.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::ClearRandomWriteTargets", HasExplicitThis = true, ThrowsException = true)]
        public void ClearRandomWriteTargets();

        
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
        public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor);

        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::ClearRenderTarget", HasExplicitThis = true)]
        public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth);
        
        /*
            摘要:
            Converts and copies a source texture to a destination texture with a different
            format or dimensions.
            ---
            可在不同格式,不同维度的 textures 之间进行转换和复制; 
            dest texture 的格式 必须是无压缩的, 并对应于当前设备上支持的 RenderTextureFormat 中的一种;

            src 中支持的格式: 2d, cubemap;
            dst 中支持的格式: 2d, cubemap, 2d array, cubemap array;

            本函数不支持从 cubemap 转换到 Texture2D, 也不支持 RenderTexures, (此时该用 Graphics.Blit )

            This function operates only on GPU-side data. Use Texture2D.ReadPixels to get the pixels from GPU to CPU.
            本函数仅处理 gpu端的数据, 

            鉴于 API 的限制, 本函数不被 DX9 和 Mac+OpenGL 支持; 有的平台则只支持一部分类型的转换;
            这是因为本函数在内部实现 依赖于 Graphics.CopyTexture 提供的功能;

            使用 SystemInfo.copyTextureSupport 来检测你的目标平台是否支持 你想要的 格式转换;
            更多兼容性信息, 见 Graphics.CopyTexture and  CopyTextureSupport.

            参数:
            src:        Source texture.
            dst:        Destination texture.
            srcElement: Source element (e.g. cubemap face). Set this to 0 for 2D source textures.
            dstElement: Destination element (e.g. cubemap face or texture array element).
        */
        public void ConvertTexture(RenderTargetIdentifier src, RenderTargetIdentifier dst);
        public void ConvertTexture(RenderTargetIdentifier src, int srcElement, RenderTargetIdentifier dst, int dstElement);

        /*
            摘要:
                Adds a command to copy ComputeBuffer or GraphicsBuffer counter value.
                ---
                counter value, 就是 buffer 中的 elements 的数量;

                本指令不能用于 LightEvent;
            
            参数:
            src:
                Append/consume buffer to copy the counter from.
            
            dst:
                A buffer to copy the counter to.
            
            dstOffsetBytes:
                Target byte offset in dst buffer.
        */
        public void CopyCounterValue(GraphicsBuffer src, ComputeBuffer dst, uint dstOffsetBytes);
        public void CopyCounterValue(GraphicsBuffer src, GraphicsBuffer dst, uint dstOffsetBytes);
        public void CopyCounterValue(ComputeBuffer src, GraphicsBuffer dst, uint dstOffsetBytes);
        public void CopyCounterValue(ComputeBuffer src, ComputeBuffer dst, uint dstOffsetBytes);
        

        /*
            摘要:
            Adds a command to copy a texture into another texture.
            
            src/dst 可以是: Textures, cubemaps, texture array layers or 3D texture depth slices

            src 和 dst 的 pix尺寸 必须是相同的, 复制工作不会执行额外的 scaling;

            texture 格式必须是 compatible 的(兼容,共用), 
            (比如, TextureFormat.ARGB32 and RenderTextureFormat.ARGB32 are compatible). 
            
            不同的 图形API 中, 兼容规则是不同的, 相同的格式永远可以复制;
            在类似 D3D11 这种平台, 你甚至可以在 "拥有相同 bit width 的格式" 之间执行复制
            (也就是, 只要两种格式占用的 bits 数量是相同的, 就能复制)

            如果本函数制定了 复制区域(也就是不是全 textue复制), 同时 src/dst 是有压缩的, 此时存在额外限制;
            比如, PVRTC 格式就不被支持, 因为它的压缩技术不是 block-based, 针对这类格式, 只能复制整个 texture,
            或者整层 map lvl; 
            如果某种压缩格式是 block-based, (比如 DXT, ETC), 目标区域的起始坐标 和 区域尺寸, 都必须是 block 尺寸的整数倍;
            (比如, 4 pixels for DXT)

            如果 src, dst 都被标记为 "readable",(即, 数据的拷贝版存在于 cpu内存中, 用于读写)
            此时, 数据将被复制到 系统内存 和 gpu 上 ???
            the data is copied in system memory as well as on the GPU.

            一些平台可能不支持所有类型的 texture 的复制,(比如, 从 render texture 复制到 regular texture)
            此时建议查看 CopyTextureSupport, SystemInfo.copyTextureSupport

            参数:
            src:    
            dst:   
                src/dst texture or identifier, see RenderTargetIdentifier.

            srcElement:
            dstElement:
                src/dst texture element (cubemap face, texture array layer or 3D texture depth slice).
                当对象为某一种 texture array 时, 使用此 idx 参数去指定到底使用哪一层
        
            srcMip: 
            dstMip: 
                src/dst texture mipmap level.

            srcX:   X coordinate of source texture region to copy (left side is zero).
            srcY:   Y coordinate of source texture region to copy (bottom is zero).
                src 中, 想要复制的 区域 的起始坐标;
        
            srcWidth:   Width of source texture region to copy.
            srcHeight:  Height of source texture region to copy.
                想要复制的 区域 的尺寸;
        
            dstX:   X coordinate of where to copy region in destination texture (left side is zero).
            dstY:   Y coordinate of where to copy region in destination texture (bottom is zero).
                dst 中, 想要放置的区域的 起始坐标;
        */
        public void CopyTexture(RenderTargetIdentifier src, int srcElement, int srcMip, RenderTargetIdentifier dst, int dstElement, int dstMip);
        public void CopyTexture(RenderTargetIdentifier src, RenderTargetIdentifier dst);
        public void CopyTexture(RenderTargetIdentifier src, int srcElement, RenderTargetIdentifier dst, int dstElement);
        public void CopyTexture(RenderTargetIdentifier src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, 
                                RenderTargetIdentifier dst, int dstElement, int dstMip, int dstX, int dstY);

        /*
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
        */
        public GraphicsFence CreateAsyncGraphicsFence(SynchronisationStage stage);
        public GraphicsFence CreateAsyncGraphicsFence();


        /*
        // 摘要:
        //     This functionality is deprecated, and should no longer be used. Please use CommandBuffer.CreateGraphicsFence.
        [Obsolete("CommandBuffer.CreateGPUFence has been deprecated. Use CreateGraphicsFence instead (UnityUpgradable) -> CreateAsyncGraphicsFence(*)", false)]
        public GPUFence CreateGPUFence(SynchronisationStage stage);
        [Obsolete("CommandBuffer.CreateGPUFence has been deprecated. Use CreateGraphicsFence instead (UnityUpgradable) -> CreateAsyncGraphicsFence()", false)]
        public GPUFence CreateGPUFence();
        */

        /*  
            创建一个 "GraphicsFence", 它将会在:
                在先于本次函数调用的: Blit, Clear, Draw, Dispatch or "Texture Copy" command 执行完毕后(在 gpu端),
            被 "passed";
            ( GraphicsFence 是一个 时间节点, "被 passed" 就是: 运行到这个时间节点了 )

            这些指令包含: 在本 GraphicsFence 创建之前就存在的, 位于本 commandbuffer 或别的 commandbuffer 的
            需要立即执行的 指令;

            有些平台无法区分 vs的结束点 和 fs的结束点, 在这样的平台上, 参数 stage 将失效, fence 的时间点被强制
            定在 fs结束点;

            对于那些不支持 "GraphicsFences" 功能的平台, 本函数也能被调用, 尽管这样做得到的 fence 不起任何作用,
            而且若对这个 fence 调用 "Graphics.WaitOnAsyncGraphicsFence()" 或 "CommandBuffer.WaitOnAsyncGraphicsFence()",
            也不会其任何作用;

            参数:
            fenceType:
                The type of GraphicsFence to create. 
                Currently the only supported value is "GraphicsFenceType.AsyncQueueSynchronization".

            stage:
                在有些平台, 在单个 draw call 的 vs的结束点 和 fs开始点 之间存在一段明显的间隙;
                可用本参数来设置 GraphicsFence 的时间节点, 要么在 vs的结束点, 要么在 fs的结束点;    
                If a "compute shader dispatch" was the last task submitted then this parameter is ignored.
        */
        public GraphicsFence CreateGraphicsFence(GraphicsFenceType fenceType, SynchronisationStageFlags stage);


        
        // 摘要:
        //     Add a command to disable the hardware scissor rectangle.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::DisableScissorRect", HasExplicitThis = true, ThrowsException = true)]
        public void DisableScissorRect();
        
        // 摘要:
        //     Adds a command to disable global shader keyword.
        // 参数:
        //   keyword:   Shader keyword to disable.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::DisableShaderKeyword", HasExplicitThis = true)]
        public void DisableShaderKeyword(string keyword);
        

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
        public void DispatchCompute(ComputeShader computeShader, int kernelIndex, GraphicsBuffer indirectBuffer, uint argsOffset);
        public void DispatchCompute(ComputeShader computeShader, int kernelIndex, ComputeBuffer indirectBuffer, uint argsOffset);
        


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

        /*
            摘要:
                Add a "draw mesh" command.
            参数:
            mesh:          Mesh to draw.
            matrix:        Transformation matrix to use.
            material:      Material to use.
            submeshIndex:  Which subset of the mesh to render.
            shaderPass:    Which pass of the shader to use (default is -1, which renders all passes).
            properties:
                Additional Material properties to apply onto the Material just before this Mesh
                is drawn. See MaterialPropertyBlock.
        */
        public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties);
        public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass);
        public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex);
        public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material);
        
        /*
            摘要:
                Adds a "draw mesh with instancing" command. 

                如果 Material.enableInstancing 失败, 本指令不会立即失败和 爆出exception,
                但是它会 log 一个 error, 然后跳过 rendering;

                如果当前平台不支持此指令, 会抛出 InvalidOperationException;
                (比如不支持 GPU instancing 的平台), 查看 SystemInfo.supportsInstancing

            参数:
            mesh:   The Mesh to draw.

            submeshIndex:
                Which subset of the mesh to draw. This only applies to meshes that are composed of several materials.

            material:   Material to use.

            shaderPass:
                Which pass of the shader to use, or -1 which renders all passes.
      
            matrices:   
                The array of object transformation matrices.

            count:
                The number of instances to be drawn.
        
            properties:
                Additional Material properties to apply onto the Material just before this Mesh
                is drawn. See MaterialPropertyBlock.
        */
        public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices);
        public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count);
        public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties);
        



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
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset);
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs);
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs);
        


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
        

        // 摘要:
        //     Adds a command onto the commandbuffer to draw the VR Device's occlusion mesh
        //     to the current render target.
        //
        // 参数:
        //   normalizedCamViewport:
        //     The viewport of the camera currently being rendered.
        public void DrawOcclusionMesh(RectInt normalizedCamViewport);
        

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
        public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount);
        public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount);
        public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount);
        public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, MaterialPropertyBlock properties);
        public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount);
        
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
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs);
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset);
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset);
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs);
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset);
        public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties);
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset);
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs);
        public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs);


        
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
        public void DrawRenderer(Renderer renderer, Material material);
        public void DrawRenderer(Renderer renderer, Material material, int submeshIndex);
        public void DrawRenderer(Renderer renderer, Material material, int submeshIndex, int shaderPass);
        

        // 摘要:
        //     Add a command to enable the hardware scissor rectangle.
        //
        // 参数:
        //   scissor:
        //     Viewport rectangle in pixel coordinates.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::EnableScissorRect", HasExplicitThis = true, ThrowsException = true)]
        public void EnableScissorRect(Rect scissor);
        

        // 摘要:
        //     Adds a command to enable global shader keyword.
        //
        // 参数:
        //   keyword:
        //     Shader keyword to enable.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::EnableShaderKeyword", HasExplicitThis = true)]
        public void EnableShaderKeyword(string keyword);
        

        // 摘要:
        //     Adds a command to end profile sampling.
        //
        // 参数:
        //   name:
        //     Name of the profile information used for sampling.
        //
        //   sampler:
        //     The CustomSampler that the CommandBuffer uses for sampling.
        public void EndSample(CustomSampler sampler);

        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::EndSample", HasExplicitThis = true)]
        public void EndSample(string name);

        /*
            摘要:
            Generate mipmap levels of a render texture.
            Use this function to manually re-generate mipmap levels of a render texture. 
            
            要求:
            The render texture has to have mipmaps (useMipMap set to true), 
            and automatic mip generation turned off (autoGenerateMips set to false).

            在有些平台,主要是 D3D9, there is no way to manually generate render texture mip levels; 
            in these cases this function does nothing.

            参数:
            rt:
                The render texture requiring mipmaps generation.
        */
        public void GenerateMips(RenderTexture rt);
        public void GenerateMips(RenderTargetIdentifier rt);


        /*
            Add a "get a temporary render texture" command.
            (很常用的指令): 申请一个 临时的 render target (即 texture)

            此指令创建一个指定的 temp render texture, 并将其设置为一个标记为为 nameID 的 global shader property;
            
            释放:
                请使用 ReleaseTemporaryRT() 来释放它, 参数传入相同的 nameID;
                在 camera 完成 rendering 后, 或者在 Graphics.ExecuteCommandBuffer() 被执行完毕后,
                任何没有被显式释放的 temp render texture, 都将被 removed;

            在得到一个 temp render texture 之后, 可调用 SetRenderTarget() 将其激活, 或调用 Blit();

            在 command buffer execution 执行期间, 你不需要显式的 保留 激活的 render targets,
            (current render targets are saved & restored afterwards).

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
                    gamma 还是 linear; 或者 Default
        
                antiAliasing:
                    Anti-aliasing (default is no anti-aliasing).
        
                enableRandomWrite:
                    Should random-write access into the texture be enabled (default is false).
        
                desc:
                    Use this RenderTextureDescriptor for the settings when creating the temporary
                    RenderTexture.
        
                memorylessMode:
                    Render texture memoryless mode. "无记忆模式"
                    -- None:    
                        The render texture is not memoryless.
                    -- Color: 
                        Render texture color pixels are memoryless when RenderTexture.antiAliasing is set to 1.
                    -- Depth: 
                        Render texture depth pixels are memoryless.
                    -- MSAA: 
                        Render texture color pixels are memoryless when RenderTexture.antiAliasing is set to 2, 4 or 8.
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
        
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode, bool useDynamicScale);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, GraphicsFormat format);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format);
        public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, GraphicsFormat format, int antiAliasing, bool enableRandomWrite, RenderTextureMemoryless memorylessMode);
        

        // 摘要:
        //     Add a "get a temporary render texture array" command.
        //
        // 参数:
        //   nameID:
        //     Shader property name for this texture.
        //
        //   width:
        //   height:
        //     Width/Height in pixels, or -1 for "camera pixel Width/height".
        //
        //   slices:
        //     Number of slices in texture array. 需要新建多少层;
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
        
        /*
            摘要:
            Increments the updateCount property of a Texture.
            更新计数;

            如果某个 command buffer 的执行 改修了一个 texture, 你可以通过追踪 Texture's updateCount
            的变化来获得这一信息;

            参数:
            dest:
                Increments the updateCount for this Texture. 目标 texture;
        */
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::IncrementUpdateCount", HasExplicitThis = true)]
        public void IncrementUpdateCount(RenderTargetIdentifier dest);
        

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
        
        
        /*
        [Obsolete("Use IssuePluginCustomTextureUpdateV2 to register TextureUpdate callbacks instead. Callbacks will be passed event IDs kUnityRenderingExtEventUpdateTextureBeginV2 or kUnityRenderingExtEventUpdateTextureEndV2, and data parameter of type UnityRenderingExtTextureUpdateParamsV2.", false)]
        public void IssuePluginCustomTextureUpdate(IntPtr callback, Texture targetTexture, uint userData);

        [Obsolete("Use IssuePluginCustomTextureUpdateV2 to register TextureUpdate callbacks instead. Callbacks will be passed event IDs kUnityRenderingExtEventUpdateTextureBeginV2 or kUnityRenderingExtEventUpdateTextureEndV2, and data parameter of type UnityRenderingExtTextureUpdateParamsV2.", false)]
        public void IssuePluginCustomTextureUpdateV1(IntPtr callback, Texture targetTexture, uint userData);
        */

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
        
        /*
            摘要:
            Add a "release a temporary render texture" command.

            在 camera 完成 rendering 后, 或者在 Graphics.ExecuteCommandBuffer() 被执行完毕后,
            任何没有被显式释放的 temp render texture, 都将被 removed;
 
            参数:
            nameID:
                Shader property name for this texture.
        */
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::ReleaseTemporaryRT", HasExplicitThis = true)]
        public void ReleaseTemporaryRT(int nameID);


        /*
            Adds an asynchonous GPU readback request command to the command buffer.
            异步GPU回读请求;
        */
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
        
        /*
            摘要:
            Force an antialiased render texture to be resolved.

            如果一个 抗锯齿 rt 设置了 bindTextureMS flag, (也就是让这个 rt 维持 multi-sampled texture 状态, 而不执行"解析")
            那么这个 rt 是不会被 "自动解析" 的;

            有时可使用此技术来在 管线的不同阶段, 同时拥有 解析的rt 和 未解析的rt;
        
            参数:
            rt:
                The antialiased render texture to resolve. 要解析的对象
            target:
                The render texture to resolve into. If set, the target render texture must have
                the same dimensions and format as the source.
                如果此参数被省略, rt 会被执行解析, 然后存到自己原来的位置上;
        */
        public void ResolveAntiAliasedSurface(RenderTexture rt, RenderTexture target = null);
        

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

        
        
        // 摘要:
        //     Adds a command to process a partial copy of data values from an array into the buffer.
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
        public void SetComputeBufferData<T>(ComputeBuffer buffer, NativeArray<T> data) where T : struct;

        [SecuritySafeCritical]
        public void SetComputeBufferData(ComputeBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count);
        [SecuritySafeCritical]
        public void SetComputeBufferData<T>(ComputeBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) where T : struct;
        [SecuritySafeCritical]
        public void SetComputeBufferData<T>(ComputeBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count) where T : struct;
        
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
        public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBuffer buffer);
        public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, ComputeBuffer buffer);
        public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBuffer buffer);
        

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
        public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, GraphicsBuffer buffer, int offset, int size);
        public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, ComputeBuffer buffer, int offset, int size);
        public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, ComputeBuffer buffer, int offset, int size);
        

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
        public void SetComputeFloatParam(ComputeShader computeShader, string name, float val);
        

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
        public void SetComputeFloatParams(ComputeShader computeShader, string name, params float[] values);
        

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
        public void SetComputeIntParam(ComputeShader computeShader, string name, int val);
        

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
        public void SetComputeIntParams(ComputeShader computeShader, int nameID, params int[] values);
        

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
        public void SetComputeMatrixArrayParam(ComputeShader computeShader, string name, Matrix4x4[] values);

        
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
        public void SetComputeMatrixParam(ComputeShader computeShader, string name, Matrix4x4 val);
        

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
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt);
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt);
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt, int mipLevel);
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element);
        public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element);
        

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
 
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetComputeVectorArrayParam", HasExplicitThis = true)]
        public void SetComputeVectorArrayParam([NotNullAttribute("ArgumentNullException")] ComputeShader computeShader, int nameID, Vector4[] values);
        

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

        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetComputeVectorParam", HasExplicitThis = true)]
        public void SetComputeVectorParam([NotNullAttribute("ArgumentNullException")] ComputeShader computeShader, int nameID, Vector4 val);
        
        /*
            摘要:
            Set flags describing the intention for how the command buffer will be executed.

            此指令只能对 空的 command buffer 调用, 要么对一个刚刚新建的 command buffer 调用,
            要么先对 command buffer 调用 Clear() 后再调用本函数;
            
            参数:
            flags:
                The flags to set.
                -- None: [默认]
                        对所有 Execution 都有效;
                -- AsyncCompute:
                        此 command buffer 只能用于 异步计算;
                        此时, 如果有不兼容的指令被加入到这个 command buffer 中时, 会抛出异常;
                        比如, 如果加入的指令 只能用于 渲染,
                        ---
                        参见 ScriptableRenderContext.ExecuteCommandBufferAsync 和 Graphics.ExecuteCommandBufferAsync.
        */
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetExecutionFlags", HasExplicitThis = true, ThrowsException = true)]
        public void SetExecutionFlags(CommandBufferExecutionFlags flags);

        /*
            摘要:
                Add a "set a global shader buffer property" command.
                此函数的效果, 等效于调用: Shader.SetGlobalBuffer()
            
            参数:
            nameID:
                The name ID of the property retrieved by Shader.PropertyToID.
            name:
                The name of the property.
            value:
                The buffer to set.
        */
        public void SetGlobalBuffer(string name, ComputeBuffer value);
        public void SetGlobalBuffer(int nameID, ComputeBuffer value);
        public void SetGlobalBuffer(string name, GraphicsBuffer value);
        public void SetGlobalBuffer(int nameID, GraphicsBuffer value);
        

        // 摘要:
        //     Add a "set global shader color property" command.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalColor", HasExplicitThis = true)]
        public void SetGlobalColor(int nameID, Color value);

        public void SetGlobalColor(string name, Color value);
        

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
        public void SetGlobalConstantBuffer(GraphicsBuffer buffer, int nameID, int offset, int size);
        public void SetGlobalConstantBuffer(GraphicsBuffer buffer, string name, int offset, int size);
        public void SetGlobalConstantBuffer(ComputeBuffer buffer, string name, int offset, int size);
        

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
        

        // 摘要:
        //     Add a "set global shader float property" command.
        public void SetGlobalFloat(string name, float value);

        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalFloat", HasExplicitThis = true)]
        public void SetGlobalFloat(int nameID, float value);
        
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

        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalFloatArray", HasExplicitThis = true, ThrowsException = true)]
        public void SetGlobalFloatArray(int nameID, float[] values);
        public void SetGlobalFloatArray(string propertyName, List<float> values);
        public void SetGlobalFloatArray(int nameID, List<float> values);
        

        // 摘要:
        //     Sets the given global integer property for all shaders.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalInt", HasExplicitThis = true)]
        public void SetGlobalInt(int nameID, int value);

        public void SetGlobalInt(string name, int value);


        // 摘要:
        //     Add a "set global shader matrix property" command.
        public void SetGlobalMatrix(string name, Matrix4x4 value);

        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalMatrix", HasExplicitThis = true)]
        public void SetGlobalMatrix(int nameID, Matrix4x4 value);


        

        // 摘要:
        //     Add a "set global shader matrix array property" command.
        public void SetGlobalMatrixArray(string propertyName, List<Matrix4x4> values);
        public void SetGlobalMatrixArray(string propertyName, Matrix4x4[] values);

        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalMatrixArray", HasExplicitThis = true, ThrowsException = true)]
        public void SetGlobalMatrixArray(int nameID, Matrix4x4[] values);
        public void SetGlobalMatrixArray(int nameID, List<Matrix4x4> values);
        
        // 摘要:
        //     Add a "set global shader texture property" command, referencing a RenderTexture.
        public void SetGlobalTexture(int nameID, RenderTargetIdentifier value, RenderTextureSubElement element);
        public void SetGlobalTexture(string name, RenderTargetIdentifier value, RenderTextureSubElement element);
        public void SetGlobalTexture(int nameID, RenderTargetIdentifier value);
        public void SetGlobalTexture(string name, RenderTargetIdentifier value);
        

        // 摘要:
        //     Add a "set global shader vector property" command.
        public void SetGlobalVector(string name, Vector4 value);

        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalVector", HasExplicitThis = true)]
        public void SetGlobalVector(int nameID, Vector4 value);



        // 摘要:
        //     Add a "set global shader vector array property" command.
        public void SetGlobalVectorArray(int nameID, List<Vector4> values);
        public void SetGlobalVectorArray(string propertyName, List<Vector4> values);

        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetGlobalVectorArray", HasExplicitThis = true, ThrowsException = true)]
        public void SetGlobalVectorArray(int nameID, Vector4[] values);
        public void SetGlobalVectorArray(string propertyName, Vector4[] values);
        

        // 摘要:
        //     Adds a command to multiply the instance count of every draw call by a specific multiplier.
        //     似乎是用于 VR 的;
        // 参数:
        //   multiplier:
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetInstanceMultiplier", HasExplicitThis = true)]
        public void SetInstanceMultiplier(uint multiplier);
        
        /*
            摘要:
                Add a "set invert culling" command to the buffer.
            参数:
            invertCulling:
                A boolean indicating whether to invert the backface culling (true) or not (false).
                ---
                默认是 Cull Back, 若参数为 true, 则执行翻转: Cull Front;
        */
        [NativeMethodAttribute("AddSetInvertCulling")]
        public void SetInvertCulling(bool invertCulling);
        

        // 摘要:
        //     Add a command to set the projection matrix.
        // 参数:
        //   proj:
        //     Projection (camera to clip space) matrix.
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetProjectionMatrix", HasExplicitThis = true, ThrowsException = true)]
        public void SetProjectionMatrix(Matrix4x4 proj);
        

        /*
            摘要:
            Set random write target for level pixel shaders.
            和  Graphics.SetRandomWriteTarget() 功能和限制相同; 

            在 Shader Model 4.5 或更高版本中, 在 frag shader 中可向某些 texture/buffers 的任意地址 写入数据;
            此行为在 UsingDX11GL3Features 链接中被称为 "unordered access views" (UAV); 
            (连接中未找到相关信息)

            这种 "random write targets" 的设置, 和 multiple render target 的设置是相似的:

            要么使用一个 render texture, 它的 enableRandomWrite flag 被开启,
            要么使用一个 ComputeBuffer 当作 target

            在不同平台之间, UAV 的索引方式是略有不同的; 
            在 DX11 中, 第一个有效的 UAV idx 是 "active render target" 的数量;
            (感觉就是在队列后面新分配一个 idx)
            所以在 单个 render target 的常见情况下, idx 会从 1 开始;

            使用 自动转换 hlsl shaders 的平台, 将会匹配此行为;

            However, with hand-written GLSL shaders the indexes will match the bindings.
             On PS4 the indexing starts always from 1 to match the most common case.

            这些 target 会一直存在, 直到你手动调用 Graphics.ClearRandomWriteTargets() 清除他们;
            在你的渲染完成之后, 最好调用上述函数; 

            如果你没这么做, 一些渲染问题会出现, 一些内置 unity 渲染 pass 会崩溃;
            
            参数:
            index:
                Index of the random write target in the shader.
            
            buffer:
                Buffer to set as the write target.
            
            preserveCounterValue:
                Whether to leave the append/consume counter value unchanged.
                是否保持 附加/消耗 计数器值 不变。
                --
                当设置一个 ComputeBuffer 时, 此参数表示是否让 counter value 保持不变
                若为 false, counter value 将被重置为 0 (也是默认行为)
            
            rt:
                RenderTargetIdentifier to set as the write target.
        */
        public void SetRandomWriteTarget(int index, GraphicsBuffer buffer, bool preserveCounterValue);
        public void SetRandomWriteTarget(int index, GraphicsBuffer buffer);
        public void SetRandomWriteTarget(int index, ComputeBuffer buffer, bool preserveCounterValue);
        public void SetRandomWriteTarget(int index, RenderTargetIdentifier rt);
        public void SetRandomWriteTarget(int index, ComputeBuffer buffer);
        

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
        public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure);
        

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
        public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer, int offset, int size);
        public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer, int offset, int size);
        public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer, int offset, int size);
        

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
        public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, int nameID, float val);
        

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
        public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, int nameID, params float[] values);
        

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
        public void SetRayTracingIntParam(RayTracingShader rayTracingShader, string name, int val);
        

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
        public void SetRayTracingIntParams(RayTracingShader rayTracingShader, int nameID, params int[] values);
        

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
        public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, string name, params Matrix4x4[] values);
        

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
        public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, string name, Matrix4x4 val);
        

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
        public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, int nameID, RenderTargetIdentifier rt);
        

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
        public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, string name, params Vector4[] values);
        

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
        public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, string name, Vector4 val);
        

        /*
            摘要:
            Add a "set active render target" command.

            可通过数种方式来获得一个 rt:
            -- a RenderTexture object
            -- a temporary render texture created with CommandBuffer.GetTemporaryRT()
            -- one of built-in temporary textures (BuiltinRenderTextureType)
            
            所有这些都通过一个 RenderTargetIdentifier struct 来表达; 
            它拥有一些 隐式转换运算符, 来节省打字时间;
            
            你不需要在 command buffer 执行期间 显式保留 active render targets;
            (current render targets are saved & restored afterwards).

            本函数包含大量重载, 需要一些额外的参数, 比如: mipLevel (int), cubemapFace;

            有的重载设置一个 single RenderTarget, 且没有显式设置 mipLevel, cubemapFace and depthSlice 参数时,
            将遵循 创建 RenderTargetIdentifier 时指定的 mipLevel、cubemapFace 和 depthSlice 值。

            除非另有指定，否则设置 MRT (multiple render targets) 的重载会将 mipLevel、cubemapFace 和 depthSlice
            设置为 0、Unknown 和 0。
            如果在参数中指定了这些信息, 那么这些信息将被用于 MRT 中的所有 render targets

            注意在 线性颜色空间中, 需要正确设置 sRGB<->Linear color conversion state;

            鉴于前一个渲染状态 和当前渲染状态 可能不同, 可在调用本函数之前, 或任何手动渲染之前, 调用 GL.sRGBWrite() 

            当前不支持 Rendering.RenderTargetIdentifier.Clear;
            应改为调用 CommandBuffer.ClearRenderTarget();  它有优化加成;

            参数:
            rt:
                Render target to set for both color & depth buffers.
            
            color:
                Render target to set as a color buffer.
            
            colors:
                Render targets to set as color buffers (MRT).
            
            depth:
                Render target to set as a depth buffer.
            
            mipLevel:
                The mip level of the render target to render into.
            
            cubemapFace:
                The cubemap face of a cubemap render target to render into.
            
            depthSlice:
                Slice of a 3D or array render target to set.
            
            loadAction:
                Load action that is used for color and depth/stencil buffers.
            
            storeAction:
                Store action that is used for color and depth/stencil buffers.
            
            colorLoadAction:
                Load action that is used for the color buffer.
            
            colorStoreAction:
                Store action that is used for the color buffer.
            
            depthLoadAction:
                Load action that is used for the depth/stencil buffer.
            
            depthStoreAction:
                Store action that is used for the depth/stencil buffer.
            
            binding: 没解释...
        */
        public void SetRenderTarget(RenderTargetBinding binding);
        public void SetRenderTarget(RenderTargetBinding binding, int mipLevel, CubemapFace cubemapFace, int depthSlice);
        public void SetRenderTarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace, int depthSlice);
        public void SetRenderTarget(RenderTargetIdentifier color, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depth, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction);
        public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace, int depthSlice);
        public void SetRenderTarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth);
        public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel);
        public void SetRenderTarget(RenderTargetIdentifier rt);
        public void SetRenderTarget(RenderTargetIdentifier rt, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction);
        public void SetRenderTarget(RenderTargetIdentifier rt, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction);
        public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace);
        public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel, CubemapFace cubemapFace);
        public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel);
        public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel, CubemapFace cubemapFace, int depthSlice);
        public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth);

        /*
            摘要:
            Add a "set shadow sampling mode" command.

            -- CompareDepths:
                默认选项, 此时 sampler 会做深度值比较, 然后返回 0 或 1, 表示 shadowmap 中对应的深度值 更小 或 更大;

            -- RawDepth:
                如果你希望能像访问 普通texture 那样去访问 shadowmap, 那就设置为 RawDepth;
                当 本个 command buffer 的最后一个指令被执行完毕后, Shadowmap's sampling mode 会被重置回默认配置;
                调用 SystemInfo.supportsRawShadowDepthSampling() 来检查本平台是否支持 RawDepth; 比如 DirectX9 就不支持;

            -- None:
                如果 texture 不是 shadowmap, 就用这个

            参数:
            shadowmap:
                Shadowmap render target to change the sampling mode on.
            
            mode:
                New sampling mode.
                更多信息参见另一个文件中的笔记
        */
        public void SetShadowSamplingMode(RenderTargetIdentifier shadowmap, ShadowSamplingMode mode);


        // 感觉 VR 相关;
        public void SetSinglePassStereo(SinglePassStereoMode mode);

        /*
            摘要:
            Add a command to set the view matrix.

            如果这个 view matrix 是你手动生成的, 比如用了 Matrix4x4.LookAt 的逆矩阵, 
            此时你需要对它的 z轴取反, 来符合 view-space 的 右手性质;
            比如:
                var lookMatrix = Matrix4x4.LookAt(tr.position, tr.position + tr.forward, tr.up);
                var scaleMatrix = Matrix4x4.TRS( Vector3.zero, Quaternion.identity, new Vector3(1, 1, -1));
                var viewMatrix = scaleMatrix * lookMatrix.inverse;
            
            参数:
            view:
                View (world to camera space) matrix.
        */
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetViewMatrix", HasExplicitThis = true, ThrowsException = true)]
        public void SetViewMatrix(Matrix4x4 view);


        /*
            摘要:
            Add a command to set the rendering viewport.
            默认情况下, 当 render target 被更改后, viewport 会被自动设置为 覆盖整个 rt;
            此时就需要用本函数来 人为改成想要的 区域;
            
            参数:
            pixelRect:
                Viewport rectangle in pixel coordinates.
        */
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetViewport", HasExplicitThis = true, ThrowsException = true)]
        public void SetViewport(Rect pixelRect);
        

        /*
            摘要:
            Add a command to set the view and projection matrices.

            截至 2021.1 版本, 此函数仅兼容 built-in 管线, 不兼容 srp三管线;


            和 SetViewMatrix() 类似, 如果 view matrix 是自己实现的, 需要注意 z轴反转问题;
            
            参数:
            view:
                View (world to camera space) matrix.
            
            proj:
                Projection (camera to clip space) matrix.
        */
        [FreeFunctionAttribute("RenderingCommandBuffer_Bindings::SetViewProjectionMatrices", HasExplicitThis = true, ThrowsException = true)]
        public void SetViewProjectionMatrices(Matrix4x4 view, Matrix4x4 proj);
        


        // 摘要:
        //     Adds an "AsyncGPUReadback.WaitAllRequests" command to the CommandBuffer.
        [NativeMethodAttribute("AddWaitAllAsyncReadbackRequests")]
        public void WaitAllAsyncReadbackRequests();

        
        /*
            摘要:
            Instructs the GPU to wait until the given GraphicsFence is passed.

            A GraphicsFence represents a point during GPU processing after a specific compute shader dispatch or draw call has completed. 
            ---
            一个 GraphicsFence 表示 "一个特定 computer shader dispatch" 或 "一个 draw call 执行完成后", GPU 处理期间的一个点...

            它被用来同步 "异步计算队列" 和 "图形渲染队列";
            
            参数:
            fence:
                在继续处理图形队列之前，GPU 将被指示等待的 GraphicsFence。
            
            stage:
                在某些平台上, 在单个 draw call 之内, 在 vs 结束到 fs 开始之前存在一段明显的间隙;
                本参数允许 在下一个 item 的 vs 或 fs开始执行之前, 执行一次等待 (插入一个 GraphicsFence )
                如果下一个要执行的 item 是 computer shader dispatch, 那么本参数将被忽略

        */
        public void WaitOnAsyncGraphicsFence(GraphicsFence fence, SynchronisationStageFlags stage);
        public void WaitOnAsyncGraphicsFence(GraphicsFence fence);
        public void WaitOnAsyncGraphicsFence(GraphicsFence fence, SynchronisationStage stage);
        
        

        /*
        // 摘要:
        //     This functionality is deprecated, and should no longer be used. Please use CommandBuffer.WaitOnAsyncGraphicsFence.
        //
        [Obsolete("CommandBuffer.WaitOnGPUFence has been deprecated. Use WaitOnGraphicsFence instead (UnityUpgradable) -> WaitOnAsyncGraphicsFence(*)", false)]
        public void WaitOnGPUFence(GPUFence fence, SynchronisationStage stage);
        [Obsolete("CommandBuffer.WaitOnGPUFence has been deprecated. Use WaitOnGraphicsFence instead (UnityUpgradable) -> WaitOnAsyncGraphicsFence(*)", false)]
        public void WaitOnGPUFence(GPUFence fence);
        */

    }
}