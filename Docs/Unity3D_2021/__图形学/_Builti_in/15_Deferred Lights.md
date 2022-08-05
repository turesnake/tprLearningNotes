# ================================================================ #
#               15 Deferred Lights
# ================================================================ #


# ================================ #
# Light Cookie
    就是给 光源 遮罩上一层 蒙版, 让光产生图案;


# ++++++++++++++++++++++++++++++++++++++++++++++ #
#          各种零碎的 源码值, 宏 的分析   (11.0 版)
# ---------------------------------------------- #

# ------------------------------:
# 宏集合: multi_compile_lightpass
    包含:
    POINT DIRECTIONAL SPOT POINT_COOKIE DIRECTIONAL_COOKIE 
    SHADOWS_DEPTH SHADOWS_SCREEN SHADOWS_CUBE SHADOWS_SOFT SHADOWS_SHADOWMASK 
    LIGHTMAP_SHADOW_MIXING. 

    包含了实时光照和阴影的 各种 keywords, 但没包含 light probes
    

# ------------------------------:
# unity_WorldToLight

    这是个 float4x4 矩阵, 能将 posWS 转换到 posLightSpace;

    注意, 平行光的 light-space 是正交投影空间, 使用此函数没啥特殊要求;

    spot光的 light-space 却不是正交投影空间, 因为需要在 spot light-space 
    中绘制一个 金字塔形的 3d模型, 且这个 模型 是要位于透视空间中的
    (和 ws 中的其它模型一样的 透视空间)
    
    此时需如下操作:    

        float4 uvCookie = mul(unity_WorldToLight, float4(posWS, 1));
		uvCookie.xy /= uvCookie.w;

    第一步结束时, uvCookie 还只是一个 "齐次 pos Light-Space";
    需要执行 除w 操作后, xy分量才变成可用的 uv值;
    (然后去采样 light cookie 之类的...)

    
# ------------------------------:
# 宏: UNITY_FAST_COHERENT_DYNAMIC_BRANCHING

    以下平台不支持此宏:
    shader target < 3.0, gles3, gles2, n3ds

    在至此此宏的平台上, 他们将支持 coherent dynamic branching 特性:
        猜测:
        当一个 wrap 中所有的 fragment, 其 条件判断式 都得到相同结果时(比如都选择A), 
        编译器和显卡能让这个 wrap 只执行 A分支, 彻底跳过 B分支;

# coherent
    指的是 变量在 wrap 中有 "相关性", "一致性";
    猜测就是 值相同;




# ------------------------------: 
# _LightTexture0

    存储 light-cookie 的 texture; 
    ---
    在 平行光, spot光 pass 中时, 这个变量是个 texture 2d;
    在 point光 pass 中时, 这个变量是个 cubemap;
    所以需要这样声明:

#if defined(POINT_COOKIE)
	samplerCUBE _LightTexture0; // point光
#else
	sampler2D _LightTexture0; // 平行光, spot光
#endif

# 采样注意:
    在 延迟渲染中, light-cookie 会引发一种 "白边/黑边" 的伪影;
    需要: "人为降低 mip lvl, 使用更高精度的 lvl" 来解决此问题;
    代码如下:

        attenuation *= tex2Dbias(_LightTexture0, float4(uvCookie,0,-8) ).w;
 




# ------------------------------:
# _LightTextureB0
2d texture lookup tables;

    存储基于 light distance 的光照衰减; 用于: spot光, point光;
    ---

    cg 文档指出, 当 point光 没有使用 light cookie 时, 这个衰减值被存储在
    _LightTexture0 中; 
    但是 catlike 的实现无视了这一点, 目前先以 catlike 为标准; 






# ++++++++++++++++++++++++++++++++++++++++++++++ #
#   矩阵: VS - WS:
#       UNITY_MATRIX_V
#       UNITY_MATRIX_I_V
#       unity_WorldToCamera
#       unity_CameraToWorld
# ---------------------------------------------- #


# ------------------------------:
#  UNITY_MATRIX_V

    UNITY_MATRIX_V == Camera.worldToCameraMatrix
    ----
    真正的 "world->camera" 矩阵


# ------------------------------:
#   unity_WorldToCamera

    unity_WorldToCamera == Matrix4x4(
        Camera.transform.position, 
        Camera.transform.rotation, 
        Vector3.one
    )
    (这不是构造函数, 这只是伪代码)
    ---
    没用过, 

    字面意思是说, 此矩阵仅仅将一个 posWS, 转换到 camera 子空间中去, (依然是 左手坐标系)
    而不是转换到 view-space 中去;


# ------------------------------:
#  unity_CameraToWorld (old)

    unity_CameraToWorld == Matrix4x4(
        Camera.transform.position, 
        Camera.transform.rotation, 
        Vector3.one
    ).inverse
    (这不是构造函数, 这只是伪代码)

# ==使用示范:
    float3 posWS = mul(unity_CameraToWorld, float4(posVS, 1)).xyz;

注意:
    矩阵 unity_CameraToWorld 依赖的参数 posVS, 不是那个 右手坐标系的 posVS (view-space)
    而是要先将其 z轴反转之后, 再传进来计算;
    ---

    这个矩阵被使用的次数不多了... 

#   bgolus 推荐改用 UNITY_MATRIX_I_V 来取代之;

#   但是 !!!!
    在 built-in 延迟渲染, 平行光的 光照pass 中,
    unity 只准备了 unity_CameraToWorld 的值;
    此时 UNITY_MATRIX_I_V 只是一个 单位矩阵, unity 压根就没写入数据;
    ---
    同样环境, spot光, point光 的 pass 中, UNITY_MATRIX_I_V 却被正确定义了....
    ---
    最好的实践就是多检查 frame debug 窗口....


# ------------------------------:
#  UNITY_MATRIX_I_V    (推荐使用)

    UNITY_MATRIX_I_V == Camera.cameraToWorldMatrix
    ---
    这是真正的 "camera -> world" 矩阵!!!!!
    它的 z 轴没有被反转!
    它默认的 view-space, 是一个 右手坐标系空间, 符合 unity 主设定!

    同上, 在使用时, 记得去 frame debug 窗口检查下 它是不是被unity 写入数据了...

    

































