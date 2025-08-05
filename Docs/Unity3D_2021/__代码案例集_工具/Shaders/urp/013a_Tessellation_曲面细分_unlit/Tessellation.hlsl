#ifndef TESSELLATION_UNLIT_INCLUDED
#define TESSELLATION_UNLIT_INCLUDED



// 内容 和 VertexData 基本一致
struct TessellationControlPoint 
{
	float4 vertex : INTERNALTESSPOS; // internal tess pos
	float3 normal : NORMAL;
	float4 tangent : TANGENT;
	float2 uv : TEXCOORD0;
	float2 uv1 : TEXCOORD1;
	float2 uv2 : TEXCOORD2;
};


/*
    曲面细分因子, 本质是个 vector4; 
    triangle 的 三条边上各细分几个顶点
    内部新增几个顶点;
*/
struct TessellationFactors 
{
    float edge[3] : SV_TessFactor;
    float inside : SV_InsideTessFactor;
};




/*
    ===========================================================
    开启 tessellation 之后, 流程上确实还需要一个 VS, 只是这个 VS 不需要再执行任何操作了, 变成了一个 空跑函数:
*/
TessellationControlPoint MyTessellationVertexProgram (VertexData v) 
{
	TessellationControlPoint p;
	p.vertex = v.vertex;
	p.normal = v.normal;
	p.tangent = v.tangent;
	p.uv = v.uv;
	p.uv1 = v.uv1;
	p.uv2 = v.uv2;
	return p;
}



// ============================= Hull ================================ // 


/* 
    LOD 运算,
    基于 三角形某个边长 + 这条边与camera的距离, 来决定在这条边上做多少细分;
*/
float TessellationEdgeFactor (float3 posWS0, float3 posWS1) 
{
    float edgeLength = distance(posWS0, posWS1);
    float3 edgeCenter = (posWS0 + posWS1) * 0.5;
    float viewDistance = distance(edgeCenter, _WorldSpaceCameraPos);
    return (edgeLength * _ScreenParams.y) / (_TessellationEdgeLength * viewDistance);
}



/* 
    一个三角形是一个 patch, 一个 patch 共用一个 TessellationFactors 实例; 本函数计算这个 factors;
    ---
    在 gpu 中, 不光 ConstantFunction() 会和 hull() 并行运算, 甚至本函数内每个 factor 的计算也会被并行化, 这取决于编译器;
    catlike: opengl 存在bug, 会导致 inside factor 计算错误, 按照目前写法可搞定;
*/
TessellationFactors MyPatchConstantFunction (InputPatch<TessellationControlPoint, 3> patch) 
{
    // posWS:
    float3 p0 = TransformObjectToWorld(patch[0].vertex.xyz).xyz;
    float3 p1 = TransformObjectToWorld(patch[1].vertex.xyz).xyz;
    float3 p2 = TransformObjectToWorld(patch[2].vertex.xyz).xyz;

    //---
	TessellationFactors f;
    f.edge[0] = TessellationEdgeFactor(p1, p2);
    f.edge[1] = TessellationEdgeFactor(p2, p0);
    f.edge[2] = TessellationEdgeFactor(p0, p1);

    // !! catlike: 为克服 opengl bug 而做的写法;
    f.inside =
	    (TessellationEdgeFactor(p1, p2) +
		 TessellationEdgeFactor(p2, p0) +
		 TessellationEdgeFactor(p0, p1)) * (1 / 3.0);

	return f;
}

/*
    tessellation control shader
    be invoked once per vertex in the patch
*/
[domain("tri")]
[outputcontrolpoints(3)] // outputting three control points per patch, one for each of the triangle's corners.
[outputtopology("triangle_cw")] // clockwise
[partitioning("integer")] // 细分因子的划分方式（Partitioning mode: "integer", "fractional_odd", "fractional_even"
[patchconstantfunc("MyPatchConstantFunction")] // how many parts the patch should be cut
TessellationControlPoint MyHullProgram ( 
    InputPatch<TessellationControlPoint, 3> patch,
    uint id : SV_OutputControlPointID 
) 
{
    return patch[id];
}



// ============================= Domain ================================ // 

/* 
    Domain 阶段 可采样, 但必须使用 LOD 系列的采样函数
*/
InterpolatorsVertex MyVertexProgram( VertexData i )
{
    InterpolatorsVertex o = (InterpolatorsVertex)0;
    o.uv = TRANSFORM_TEX( i.uv, _BaseMap );  

    float3 posOS = i.vertex.xyz;

    // ------ 用 noise3d 来演示 曲面细分后的 顶点动画: -------

    // 得到法线:
    VertexNormalInputs normalInput = GetVertexNormalInputs(i.normal, i.tangent);
    float3 normalWS = normalInput.normalWS;

    // 运动的 uv3d:
    float3 flowUV = i.vertex.xyz / _NoiseScale + _Time.x * _Move.xyz;

    // 采样 texture3D 得到随机 noise,
    float3 noise3D = SAMPLE_TEXTURE3D_LOD(_VolumeTex, sampler_VolumeTex, flowUV, 0).xyz; 
    posOS +=  normalWS * noise3D.x * _Amplitude;

    //-- 让顶点动起来:
    o.posHCS = TransformObjectToHClip( posOS );
    return o;
}


/*
    tessellation evaluation shader
    be invoked once per vertex and is provided the barycentric coordinates for it
*/
[domain("tri")]
InterpolatorsVertex MyDomainProgram (
    TessellationFactors factors,
	OutputPatch<TessellationControlPoint, 3> patch, // tgt vertex's triangle
    float3 barycentricCoordinates : SV_DomainLocation // to generate new vertex
) 
{
    VertexData data;

    #define MY_DOMAIN_PROGRAM_INTERPOLATE(fieldName) data.fieldName = \
		patch[0].fieldName * barycentricCoordinates.x + \
		patch[1].fieldName * barycentricCoordinates.y + \
		patch[2].fieldName * barycentricCoordinates.z;

	MY_DOMAIN_PROGRAM_INTERPOLATE(vertex)
    MY_DOMAIN_PROGRAM_INTERPOLATE(normal)
	MY_DOMAIN_PROGRAM_INTERPOLATE(tangent)
    data.normal = normalize(data.normal);
	MY_DOMAIN_PROGRAM_INTERPOLATE(uv)
	MY_DOMAIN_PROGRAM_INTERPOLATE(uv1)
	MY_DOMAIN_PROGRAM_INTERPOLATE(uv2)

    // !! 注意, 这里调用了 VS, 这是一个真正在起作用的 VS, 不是上面的 空流程VS,
    return MyVertexProgram(data);
}



/*
    =========================== Geometry ================================
    geometry shader:
    evaluate the result and generate the vertices of the final triangles

*/










#endif