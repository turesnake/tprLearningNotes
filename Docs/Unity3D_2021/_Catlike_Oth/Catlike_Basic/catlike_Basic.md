



# -------------------------------------- #
#          update()
# -------------------------------------- #
update 帧率 并不和 显示器帧率同步. 就算开启 VSync, 显示器帧率被锁死为 60fps
update 的帧率 仍可以为任意值. 



# -------------------------------------- #
#       vector 之间执行 线性插值 
#       vector 之间执行 smoothstep 插值
# -------------------------------------- #

    Vector3 outVal = Vector3.Lerp( vecA, vecB, progress );

# -- 对上式做简单改造, 就能实现 smoothstep 插值:

    Vector3 outVal = Vector3.Lerp( vecA, vecB, SmoothStep(0f, 1f, progress) );

非常机智的做法. 此外, 上式的 Lerp 和 SmoothStep 两函数都执行了 clamp[0,1] 操作, 可以省略掉一个:

    Vector3 outVal = Vector3.LerpUnclamped( vecA, vecB, SmoothStep(0f, 1f, progress) );



# -------------------------------------- #
#          DrawMeshInstancedIndirect
# -------------------------------------- #
is useful for when you do not know how many instances to draw on the CPU side 
and instead provide that information with a compute shader via a buffer.




# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#           MaterialPropertyBlock:
#           逐 instance 的 material properties
# ---------------------------------------------------------------- #

在 06 Jobs 一章 3.5 小节. 
当调用:

    for (int i = 0; i < matricesBuffers.Length; i++) {
		ComputeBuffer buffer = matricesBuffers[i];
		buffer.SetData(matrices[i]); // Set the buffer with values from an array.

		material.SetBuffer(matricesId, buffer);
		Graphics.DrawMeshInstancedProcedural(
			mesh, 
			0, 		// submesh idx
			material, 
			bounds, // AABB
			buffer.count // 要画几个 instances
		);
	}

时, 会出现 material 配置错误的现象: 所有 instance 使用的 matrix, 都变成了最后一次设置的 matrix.
这是因为 这些 设置函数, 都是延迟执行的, 当真的调用 draw call 时, 后续写入的数据, 覆盖了之前写入的数据.
(主要是围绕例子中的 SetBuffer() 这句话 )

解决方案就是改用 MaterialPropertyBlock:

    for (int i = 0; i < matricesBuffers.Length; i++) {
		ComputeBuffer buffer = matricesBuffers[i];
		buffer.SetData(matrices[i]); // Set the buffer with values from an array.

		propertyBlock.SetBuffer(matricesId, buffer);
		Graphics.DrawMeshInstancedProcedural(
			mesh, 
			0, 		// submesh idx
			material, 
			bounds, // AABB
			buffer.count, // 要画几个 instances
			propertyBlock
		);
	}

matrices 先被写入 MaterialPropertyBlock 中, 然后在被上交. 

这将使 Unity 复制 propertyBlock当时的配置, 并将其用于当前这一条绘制命令，用它覆盖 material 设置的数据. 




# -------------------------------------- #
#   DrawMeshInstancedProcedural() 参数中的 Bounds
# -------------------------------------- #
一个 AABB 盒, 此绘制指令会一次性将一个 mesh 绘制很多份, 
可将这些绘制的 instances 看作一个整体, 它们需要一个 cull 检测边界. 这个边界由 bounds 提供

超出这个边界的 物体,可能会被 cull (但在实践中, 我从没观察到过这种 cull )



