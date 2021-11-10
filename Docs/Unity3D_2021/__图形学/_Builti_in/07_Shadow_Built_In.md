# ================================================================//
#                    Shadow Built-In
# ================================================================//

主要来自 catlike Built-In Rendering



# ++++++++++++++++++++++++++++++++++++++++++++++ #
#          各种零碎的 源码值, 宏 的分析   (11.0 版)
# ---------------------------------------------- #

# --------------------- #
# unityShadowCoord -- float
# unityShadowCoord2 -- float2
# unityShadowCoord3 -- float3
# unityShadowCoord4 -- float4
# unityShadowCoord4x4 -- float4x4
感觉就是普通的 变量类型


# --------------------- #
# float4 unity_LightShadowBias;
    x: 与 Light inspector: Bias 值关联: (测试结果)
        Bias = 0.00001 时,  x = - 0.000001 (无限小)
        Bias = 2 时,        x = - 0.01; (接近)

        在 d3d 中, x值是负的, (在 opengl 也许非负...)

    y:  为 spot, point 光源时, 值为 0; 
        为 平行光时, 值为 1;
        使用 y值作为筛选器:
            float c = lerp( a, b, unity_LightShadowBias.y);
        做二选一;

    z:  包含 用户定义的 normal offset 值, scaled by WS texel size.


# --------------------- #
# half4 _LightShadowData;

在: CGIncludes.11.0 中有详细注释;



# --------------------- #
# keyword: SHADOWS_DEPTH
    当渲染 平行光, spot光的 shadowmap(cube) 时, 
    unity 会去寻找一个 定义了此 keyword 的 shadow caster variant;

    shadow caster 和 receive 的 shader 都需要定义此 keyword

# --------------------- #
# keyword: SHADOWS_CUBE
    当渲染 点光源的 shadowmap(cube) 时, 
    unity 会去寻找一个 定义了此 keyword 的 shadow caster variant;

    shadow caster 和 receive 的 shader 都需要定义此 keyword


# --------------------- #
# keyword: SHADOWS_SCREEN
-- catlike:
    When the main directional light casts shadows, Unity will look for a shader variant 
    that has the SHADOWS_SCREEN keyword enabled.
    ---
    一个 平行光 的着色计算shader, 当它添加了 SHADOWS_SCREEN 后, 将增加一个 shader variant,
    这个 shader variant 就能支持 平行光 shadowmap 的运算
    (运算内容: receive shadow:
    拿着 posSS 去 shadowmap 中采样, 拿回来和自己的 depth map 做比较, 从而计算出 光照衰减值 )

--- bgolus:
    通常,在 pc 和主机平台, unity 使用 screen space deferred cascaded shadows 技术来计算 主平行光的 阴影;
    在 forward 和 deferred rendering 都是; 

    This means that the main directional light's shadows are cast on the scene's depth texture 
    nd not calculated on the geometry itself.

    如果你关闭了 cascade shadowmap, 或者所在平台不支持此技术, SHADOWS_SCREEN 将不会被定义
    ---
    但是这一描述并不绝对, 细节可查看:
    https://forum.unity.com/threads/what-does-shadows_screen-mean.568225/


# --------------------- #
# 宏: multi_compile_shadowcaster
    包含一组 keyword: SHADOWS_DEPTH SHADOWS_CUBE


# --------------------- #
# sampler2D _ShadowMapTexture;
    当定义了 keyword: SHADOWS_SCREEN, 编译器会自动新建 texture变量: _ShadowMapTexture,
    然后, unity 会把已经生成好的 screen-space shadows, 放到这个 texture 中;
    ---
    有趣的是, 只要执行:
        float attenuation = tex2D( _ShadowMapTexture, uv );

    就能直接获得 光照衰减值, 而无需进行 shadowmap 和 depth map 的比较啥的,
    这说明这一步比较, unity 已经自动完成了这些工作, 现在存储在  _ShadowMapTexture 中的就是衰减值;




# --------------------- #
# float4 ComputeScreenPos(float4 posCS);
    务必在 vertex shader 中调用之, 返回一个 posSS 半成品;
    在经过 vertex->frag 插值后, 对此值做运算:
        posSS.xy / posSS.w
    
    即可得到 完整版的 float2 posSS;
    ---
    这个半成品值的 zw 分量 未做任何处理, 仍保留着参数 posCS 中的值;


# +++++++++++++++ 阴影三剑客 ++++++++++++++++ #
#   SHADOW_COORDS       --> UNITY_SHADOW_COORDS
#   TRANSFER_SHADOW     --> UNITY_TRANSFER_SHADOW
#   SHADOW_ATTENUATION  --> 
# ------------------------------------------- #
unity 5.6 之后, light mode: Mixed 被做了改动, 同时改了一系列代码;
随之而来的就是, 为支持新的 Mixed mode, 需要将旧的宏 替换为 新宏;

三剑客只是老的称呼, 在 unity 5.6 之后的版本中, 实际使用的宏的数量将多于 3 个;



# ------------------------:
# SHADOW_COORDS(idx)        [old]
# UNITY_SHADOW_COORDS(idx)  [new]
+++
关于旧宏:
    根据不同平台, 是否渲染 shadow, 自动定义一个 float4/3 shadowCoordinates : TEXCOORD#;
    参数 idx 规定了 TEXCOORD... 后面的序号;
    
    如果不渲染阴影, 此宏 do nothing;


# ------------------------:
# TRANSFER_SHADOW(idx)                  [old]
# UNITY_TRANSFER_SHADOW(idx, v.uv1)     [new]
+++
关于旧宏:
    就是在 vertex shader 中计算一个 posSS 的半成品;

    -1- 平行光 cascade shadowmap 中:
        a._ShadowCoord = ComputeScreenPos(a.pos);        

    -2- Spot light shadows:
        a._ShadowCoord = mul (unity_WorldToShadow[0], mul(unity_ObjectToWorld,v.vertex));

    -3- Point light shadows:
        a._ShadowCoord.xyz = mul(unity_ObjectToWorld, v.vertex).xyz - _LightPositionRange.xyz;

    -4- no shadow:
        空

+++
关于新宏:
    添加了一个参数: 
    ---
    unity 5.6 以后, 只会将 "screen-space coordinates for directional shadows" 放入 v->f 插值器中;
    ( 平行光的 shadowmap )

    从现在开始, point光, spot光的 shadow coords 都在 frag shader 中被计算; 
    新消息是, 在某些情景中, lightmap coords 也被用于 shadowmask 
    (挺合理, 毕竟 lightmap 和 shadowmask 共用同一套 uv值 )

    为了支持这些变动, 我们需要向新宏 再传入一个参数: v.uv1; 即 顶点的 lightmap coord 信息 (2号uv)

# UNITY_INITIALIZE_OUTPUT():
    在做出如上两个 宏的更换后, 会跳出新的 编译错误, 这是因为 UNITY_SHADOW_COORDS 宏会在某些情况下错误地生成
    一个本不需要的 插值变量 (被 v->f 插值); 

    在 standard shader 中, 这个编译错误不会出现, 我们模仿 standard 的方式去处理此问题:

        Interpolators MyVertexProgram (VertexData v) {
            Interpolators i;
            UNITY_INITIALIZE_OUTPUT(Interpolators, i);
            …
        }
    
    按照源码, 此宏只是在需要的情景下, 简单地将实例 i 中的变量全部设置为 0;
    剩余情景下, 则什么也不做;



# ------------------------:
# SHADOW_ATTENUATION
    采样 _ShadowMapTexture, 计算光照衰减值;

    spot光, point光 都等同于: 
        UnitySampleShadowmap(a._ShadowCoord)

    未开启shadow, 则返回 1 


# ------------------------:
# UNITY_LIGHT_ATTENUATION( destName, input, worldPos )
参数:
    destName:   户自定义一个变量名, 一般为 "attenuation"
                    一个 光照衰减值, 宏内部会 声明这个变量, 并计算出它的值;
                    如果启用了 阴影技术, 这个衰减值 也会表现阴影;

    input:      frag shader 输入参数; 若不想计算阴影, 可传入 0

    worldPos:   本 fragment 的 posWS
    ---
    不同的光源有不同的实现;
    内部可能会使用到 SHADOW_ATTENUATION;

注意:
    在 unity 5.6 之后, 此宏的内容已经被改动;
    若在自定义 shader 中使用此宏, 且 主平行光的 light mode 为 Mixed 的话, 可能无法支持 shadow fade 功能;
    (就是在 shadow 达到 shadow distance 距离后, 会突然消失, 而不是渐渐消失)

    ---
    这是因为:
    本宏的部分实际已经高度绑定了 standard shader 的剩余代码, 为了性能考虑, 它将部分代码,
    比如计算 shadow fade 值, 移到了别的更深的函数中去;

    当 HANDLE_SHADOWS_BLENDING_IN_GI 被定义时, 也就是在 "主平行光为 Mixed 模式" 这个pass 中:
    本宏的实现中, 就会跳过 shadow fade 的计算;
    我们需要手动补上这段后, shadow fade 才能正常显示;
    具体补充方式, 见 catlike - rendering 17 - 1.3 节;
        (其实就是手动计算一个 shadow fade 值, 然后累加到 本宏已经 计算的 attenuation 上去)

    -------
    同时, 针对 point光, spot光:
    此宏主动计算了 shadow fade, 
    如果有 shadwomask ,甚至主动采样了 shadowmask,
    一步到位地计算好了最终形态的 shadow attenuation;
    
    在处理这两种光源时, 我们后续不需要做什么操作;
    

# -- 宏: HANDLE_SHADOWS_BLENDING_IN_GI
    若同时定义了 SHADOWS_SCREEN 和 LIGHTMAP_ON, 此宏将被定义为 1;
    (即: 同时开启了 -1-: 平行光 cascade shadowmap, -2- lightmap )
    (而这恰恰就是将 主平行光设置为 Mixed mode 之后的情况)
    

 
    
# --------------------- #
# 宏: SHADOWS_NATIVE
    除了 GLES2.0 以外的所有平台都支持 built-in shadow 比较 sampler;
    它们都会定义此 宏;

    在 GLES2.0 中, 那些开启了 UNITY_ENABLE_NATIVE_SHADOW_LOOKUPS 的平台, 也会定义此宏

   
# --------------------- #
# UnitySampleShadowmap(...)
-- spot光:
    fixed UnitySampleShadowmap (float4 shadowCoord)

-- point光:
    half UnitySampleShadowmap (float3 vec)



# --------------------- #
# UnityEncodeCubeShadowDepth(...)
# UnityDecodeCubeShadowDepth()

unity 选择使用 float cube map 来存储一个 深度值,
如果某平台不支持这个技术, unity 将被迫把这个 深度值(float) 转码为一个 RGBA 4通道中,
(然后访问的时候还得再解码 提取出来)

这对函数就是用来干这个的;

 






















