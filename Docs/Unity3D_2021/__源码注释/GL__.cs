
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Internal;

namespace UnityEngine
{
    /*
        摘要:
        Low-level graphics library.

        使用此 class 来手动操作 active转换矩阵, 
        像着 "opengl immediate mode" 那样去 发出渲染指令,
        做一些 底层图形任务;

        注意:
        在绝大多数场合中, 调用 "Graphics.DrawMesh()" 或 "CommandBuffer" 都将比本 class 中的
        "immediate mode" 更加高效;

        GL immediate drawing 函数 使用 "current material" 中的那些配置信息,
        (参考 "Material.SetPass()" )

        这个 material 控制了渲染是如何执行的 ( blending, textures 等 )
        所以, 除非你在调用 GL 绘制函数之前, 显式地改写某些配置, 否则都将听从 material 的配置;

        反过来, 如果你在 GL 绘制函数代码中 改写了 绘制配置, 这些配置也会被设置回这个 material,
        所以你要清楚自己具体做了哪些事;

        GL 绘制指令 会被立即执行, 这意味着如果你在 update() 中调用这些函数, 它们会先于 camera rendering 执行;
        在它们被执行以后, camera rendering 会按照传统流程 先执行 screen clear 工作, 然后再绘制上自己的内容;
        这等于让之前的 GL 绘制调用失效了;

        所以, GL 绘制函数通常在: 一个绑定在 camera obj 的脚本的 "Camera.OnPostRender()" 中被调用, 
        或者在一个类似 "Camera.OnRenderImage()" 的 image effect function 体内调用;

        注意:
        本 class 主要用来额外地绘制一些 lines 或 三角形;
        不要指望用本 class 来绘制 mesh;

    */
    [NativeHeaderAttribute("Runtime/Camera/CameraUtil.h")]
    [NativeHeaderAttribute("Runtime/Camera/Camera.h")]
    [NativeHeaderAttribute("Runtime/GfxDevice/GfxDevice.h")]
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [StaticAccessorAttribute("GetGfxDevice()", Bindings.StaticAccessorType.Dot)]
    public sealed class GL
    {

        /*
            下面这组 mode 数值, 将被传递到 "GL.Begin()" 中当作参数, 如:
                GL.Begin(GL.TRIANGLES);

            不同的 mode, 会要求在 "GL.Begin()" 之后, 依次传入不同格式的 数据,
            具体内容在此未翻译, 可查看 原生文档;
        */
        //     Mode for Begin: draw triangles.
        public const int TRIANGLES = 4;
        //     Mode for Begin: draw triangle strip.
        public const int TRIANGLE_STRIP = 5;
        //     Mode for Begin: draw quads.
        public const int QUADS = 7;
        //     Mode for Begin: draw lines.
        public const int LINES = 1;
        //     Mode for Begin: draw line strip.
        public const int LINE_STRIP = 2;


        public GL();


        /*
            Controls whether "Linear-to-sRGB color conversion" is performed while rendering.

            只有当设置为 线性颜色空间时, 本变量才起作用;

            Typically when linear color space is used, non-HDR render textures are treated as sRGB data (i.e. "regular colors"), 
            and fragment shaders outputs are treated as linear color values. 
            So by default the fragment shader color value is converted into sRGB.
            --
            通常, 当选择了 linear 工作流, 类型为 non-HDR 的 render texture 一般会被认为是 sRGB 数据, (比如 "regular colors"), 
            而 frag shader 的输出值, 则是 线性颜色值,
            所以默认情况下, frag shader 的输出值会执行 linear->sRGB 转换;
            猜测:
                render texture 是 fs 的写入目的地, fs端输出的是 线性数据 (因为程序选用了 线性颜色空间)
                但 render texture 能容纳的数据确实 sRGB 数据,
                所以需要把 fs输出的数据, linear->sRGB 转换一下;

            但是, 如果你知道你的 fs 的输出数据就已经是 sRGB 模式了, 不再需要这道 linear->sRGB 转换了,
            你可使用本变量来 暂时关闭 这个 转换;

            注意:
            不是所有平台都支持本变量的功能 (关闭 linear->sRGB 转换功能);
            ( 通常, 移动端的 "tile based" GPU 不支持 )
            所有这被认为是 不得已而为之的 功能;

            最好的办法是: 在创建 render texture 时, 就设置为 linear 空间,
            然后就不需要 linear->sRGB 转换 了;
        */
        public static bool sRGBWrite { get; set; }



        /*
            Should rendering be done in wireframe?

            开启此值之后, 后续的所有 物体的绘制都会受到影响(变成线框),
            直到你再次把本值设置为 false;

            在 unity editor 模式, 在 "repainting any window" (重新绘制任何窗口) 之前，
            本变量始终处于 false 状态;

            注意:
            有些平台, 比如 OpenGL ES, 不支持 wireframe 渲染;
        */
        public static bool wireframe { get; set; }


        /*
            摘要:
            Select whether to invert the backface culling (true) or not (false).

            若为 true:  Cull Front;
            若为 false: Cull Back;

            主要用途:
            渲染 镜子,水面的反射;
            因为渲染这些效果的 virtual camera 处于镜像位置, cull 模式也必须反转一下才行;
        */
        [NativePropertyAttribute("UserBackfaceMode")]
        public static bool invertCulling { get; set; }


        /*
            摘要:
            Gets or sets the modelview matrix.

            若读取本变量,将获得 模型矩阵 和 view矩阵的 乘积;
            若设置本变量, 会将 模型矩阵设置为 单位矩阵, 将 view矩阵设置为 参数 modelview;
            ~~~~
            这种修改矩阵的工作, 最好在 "GL.PushMatrix()" 和 "GL.PopMatrix()" 包围块内部执行;
        */
        public static Matrix4x4 modelview { get; set; }


        /*
            摘要:
            Begin drawing 3D primitives.

            在 opengl 中, 本函数等同于 glBegin(); 在别的平台,则有对应的函数或函数组合;

            在 GL.Begin() 和 GL.End() 之间, 可以调用:
                GL.Vertex()
                GL.Color()
                GL.TexCoord()
                或其它 "immediate mode drawing functions" (立即绘制函数)

            当你自己绘制图元时, 要小心 culling 操作; 
            基于程序所依赖的 图形API, culling rules 可能是不同的;
            在大部分情况下, 最安全的措施是在 shader 中设置: "Cull Off;" 指令;

        // 参数:
        //   mode:
        //     Primitives to draw: can be TRIANGLES, TRIANGLE_STRIP, QUADS or LINES.
        */
        [FreeFunctionAttribute("GLBegin", ThrowsException = true)]
        public static void Begin(int mode);


        /*
            摘要:
            Clear the current render buffer.

            This clears the screen or the active RenderTexture you are drawing into. 
            The cleared area is limited by the active viewport. 
            This operation might alter the model/view/projection matrices.

            在大部分情况下, camera 都会设置自己的 clear 配置, 
            你并不需要在这里手动配置 clear;

        // 参数:
        //   clearDepth:
        //     Should the depth buffer be cleared?
        //
        //   clearColor:
        //     Should the color buffer be cleared?
        //
        //   backgroundColor:
        //     The color to clear with, used only if clearColor is true.
        //
        //   depth:
        //     The depth to clear the z-buffer with, used only if clearDepth is true. The valid
        //     range is from 0 (near plane) to 1 (far plane). 
        
                The value is graphics API agnostic:
                the abstraction layer will convert the value to match the 
                convention of the current graphics API.
                ---
                这个参数 和 图形API 的那些约定无关; 抽象层会帮你处理好这些事;
                所以, 你只要简单地填入一些 [0,1] 区间的值就可以了
        */
        public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor, [DefaultValue("1.0f")] float depth);
        public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor);


        /*
            摘要:
            Clear the current render buffer with camera's skybox.
        
            This draws skybox into the screen or the active RenderTexture. 

            If the passed camera does not have custom Skybox component, 
            the global skybox from RenderSettings will be used.

        // 参数:
        //   clearDepth:
        //     Should the depth buffer be cleared?
        //
        //   camera:
        //     Camera to get "projection parameters" and skybox from.
        */
        [FreeFunctionAttribute("ClearWithSkybox")]
        public static void ClearWithSkybox(bool clearDepth, Camera camera);


        /*
            摘要:
            Sets current "vertex color".
        
            In OpenGL 本函数等同于 "glColor4f(c.r,c.g,c.b,c.a);"
            别的平台有类似的 函数 或 函数组;

            为了让 "逐顶点-颜色" 在不同的硬件上可靠地工作, 
            you have to use a shader that binds in the color channel. 
            See "BindChannels" 文件:
            https://docs.unity3d.com/2021.1/Documentation/Manual/SL-BindChannels.html

            本函数只能在  "GL.Begin()" and "GL.End()" 函数块体内被调用;
        */
        public static void Color(Color c);


        /*
            摘要:
            End drawing 3D primitives.

            In OpenGL this matches glEnd();
            别的平台则有对应的函数 或函数组合;
        */
        [FreeFunctionAttribute("GLEnd")]
        public static void End();



        /*
            摘要:
            Sends queued-up commands in the driver's command buffer to the GPU.
            --
            将 "驱动的 command buffer 中的" 排队指令, 发生给 gpu;

            When Direct3D 11 is the active graphics API, 
            本函数等同于 "ID3D11DeviceContext::Flush()";

            When Direct3D 12 is the active graphics API, 
            "pending command lists" are executed. 
            (执行 挂起的 command lists)

            When OpenGL is the active graphics API, 
            本函数等同于 "glFlush()";
        */
        public static void Flush();


        /*
            摘要:
            Compute "GPU projection matrix" from camera's projection matrix.
        
            在 unity 中, 投影矩阵遵从 opengl 习俗;
            但在有些平台上, 投影矩阵 会做微小调整, 以适应 原生 API 需求;

            使用本函数来计算 "最终的投影矩阵" 的样子;
            得到的值会和 shader 代码中的 "UNITY_MATRIX_P" 矩阵 一样;

            如果参数 renderIntoTexture 设为 true,
            在某些平台上，它会影响最终矩阵的外观。

        // 参数:
        //   proj:
        //     Source projection matrix.  源 投影矩阵
        //
        //   renderIntoTexture:
        //     Will this projection be used for rendering into a RenderTexture?
        //
        // 返回结果:
        //     "Adjusted projection matrix" for the current graphics API.
                调整后的投影矩阵
        */
        [FreeFunctionAttribute("GLGetGPUProjectionMatrix")]
        public static Matrix4x4 GetGPUProjectionMatrix(Matrix4x4 proj, bool renderIntoTexture);


        /*
            摘要:
            Invalidate the internally cached render state.
            --
            使 内部缓存的 render state 无效;

            This invalidates any cached render state tied to the active graphics API. 

            If for example a (native) plugin alters the render state settings 
            then Unity's rendering engine must be made aware of that.
            ---
            比方, 如果一个 原生插件 修改了 render state, 则必须让 unity 渲染引擎 知道这件事;
        */
        [FreeFunctionAttribute("GLInvalidateState")]
        public static void InvalidateState();


        /*
            摘要:
            Send a user-defined event to a native code plugin.
        
            如果平台允许, cpu核心数也允许, unity 中是可以实现 多线程渲染的;
            当启用了 多线程渲染, 渲染线程(执行 渲染commands的) 和 脚本线程 将彻底分离;
            因此, 你的 插件时不能 立即启动渲染的, 因为这可能会干扰 渲染线程当前正在执行的任务;

            为了支持从插件端发生各种渲染任务, 你应该在你的脚本端调用 本函数;
            这会导致 从渲染线程端 调用你的 原生插件;

            比如:
            如果你在 camera's "OnPostRender()" 函数实现体内调用 本函数, 那么你会在这个 camera 完成渲染工作后,
            立即得到一个 插件的 回调函数;

            这个得到的 callback 的格式必须为:
                void UNITY_INTERFACE_API UnityRenderingEvent(int eventId);

            建议查看:
            https://docs.unity3d.com/2021.1/Documentation/Manual/NativePluginInterface.html

        // 参数:
        //   callback:
        //     Native code callback to queue for Unity's renderer to invoke.
        //
        //   eventID:
        //     User defined id to send to the callback.
        */
        public static void IssuePluginEvent(IntPtr callback, int eventID);


        /*
        [NativeNameAttribute("InsertCustomMarker")]
        [Obsolete("IssuePluginEvent(eventID) is deprecated. Use IssuePluginEvent(callback, eventID) instead.", false)]
        public static void IssuePluginEvent(int eventID);
        */


        /*
            摘要:
            Load an identity into the current model and view matrices.

            将当前的 模型矩阵, view矩阵 设置为 单位矩阵;
            ~~~~
            这种修改矩阵的工作, 最好在 "GL.PushMatrix()" 和 "GL.PopMatrix()" 包围块内部执行;
        */
        [FreeFunctionAttribute("GLLoadIdentityScript")]
        public static void LoadIdentity();


        /*
            摘要:
            Helper function to set up an orthograhic projection.

            将 正交投影 加载到 projection matrix 中,
            将 模型矩阵, view矩阵 设置为 单位矩阵;

            生成的 投影 执行以下映射：
            -1-: x = [0,1]    -> [-1,1] (left..right)
            -2-: y = [0,1]    -> [-1,1] (bottom..top)
            -3-: z = [1,-100] -> [-1,1] (near..far)

            本函数等同于:

                GL.LoadIdentity(); // 将 模型矩阵, view矩阵 设置为 单位矩阵;
                var proj = Matrix4x4.Ortho(0, 1, 0, 1, -1, 100);
                GL.LoadProjectionMatrix(proj); // 设置 投影矩阵

            ~~~~
            这种修改矩阵的工作, 最好在 "GL.PushMatrix()" 和 "GL.PopMatrix()" 包围块内部执行;
        */
        [FreeFunctionAttribute("GLLoadOrthoScript")]
        public static void LoadOrtho();



        /*
            摘要:
            Setup a matrix for pixel-correct rendering.
            --
            猜测:
                "像素对齐" 的渲染;

            将 一个正交矩阵 传递给投影矩阵, 将模型矩阵, view矩阵设置为 单位矩阵,

            这个新设置投影矩阵, 能使得 pos 的 x,y分量 直接映射为 屏幕上的 像素的坐标;

            coord (0,0) 对应了当前 camera viewport 区域的 左下角;
            z分量, near plane 值为 1, far plane 值为 -100;

            ~~~~
            这种修改矩阵的工作, 最好在 "GL.PushMatrix()" 和 "GL.PopMatrix()" 包围块内部执行;

        // 参数:
        //   left:
        //   right:
        //   bottom:
        //   top:
                这组参数的用途, 不明.... 
        */
        public static void LoadPixelMatrix(float left, float right, float bottom, float top);

        [FreeFunctionAttribute("GLLoadPixelMatrixScript")]
        public static void LoadPixelMatrix();



        /*
            摘要:
            Load an arbitrary matrix to the current projection matrix.
        
            本函数只设置 投影矩阵, 不改写 模型矩阵, view矩阵;

            投影矩阵通常会将 绘制区域投影到如下 区间中, 这个区间是不受 API 影响的:
                1. x = -1..1 (left..right)
                2. y = -1..1 (bottom..top)
                3. z = -1..1 (near..far)

            unity 可能会将这个矩阵, 和一组额外的转换操作相结合, 以符合当前图形 APi 的要求;
            最终得到的 矩阵, 可通过 "GL.GetGPUProjectionMatrix()" 来查询;

            ~~~~
            这种修改矩阵的工作, 最好在 "GL.PushMatrix()" 和 "GL.PopMatrix()" 包围块内部执行;
        */
        [FreeFunctionAttribute("GLLoadProjectionMatrixScript")]
        public static void LoadProjectionMatrix(Matrix4x4 mat);


        /*
            摘要:
            Sets current texture coordinate (v.x,v.y,v.z) to the actual texture "unit".
        
            In OpenGL, 如果 multi-texturing 是可用的, 本函数等同于 "glMultiTexCoord()"
            在别的平台有类似函数;

            The Z component is used only when:
            -1- 你真正访问一个 cubemap (which you access with a vector coordinate, hence x,y & z).
                猜测 z分量被用来选择 cubemap 的某个面;
            -2- 你在 "projective texturing" (投影一个 texture),
                此时, x,y分量要除以 z分量, 得到最终的 coord;
                这主要用来实现 水母反射 或类似的东西;

            本函数只能在  "GL.Begin()" and "GL.End()" 函数块体内被调用;

        // 参数:
        //   unit:
                texture idx, 0 表示第一个
        //
        //   v:
        */
        public static void MultiTexCoord(int unit, Vector3 v);

        [NativeNameAttribute("ImmediateTexCoord")]
        public static void MultiTexCoord3(int unit, float x, float y, float z);


        /*
            摘要:
            Sets current texture coordinate (x,y) for the actual texture unit.

            In OpenGL, 如果 multi-texturing 是可用的, 本函数等同于 "glMultiTexCoord()"
            在别的平台有类似函数;

            本函数只能在  "GL.Begin()" and "GL.End()" 函数块体内被调用;
        
        // 参数:
        //   unit:
                texture idx, 0 表示第一个
        */
        public static void MultiTexCoord2(int unit, float x, float y);



        /*
            摘要:
            Sets the current model-matrix 模型矩阵 to the one specified.

            ~~~~
            这种修改矩阵的工作, 最好在 "GL.PushMatrix()" 和 "GL.PopMatrix()" 包围块内部执行;
        */
        [NativeNameAttribute("SetWorldMatrix")]
        public static void MultMatrix(Matrix4x4 m);



        /*
            摘要:
            Saves/Restores the model, view and projection matrices to the top of the matrix stack.

            "GL.PushMatrix()" and "GL.PopMatrix()" 要配合使用;

            -1 -在执行 GL 绘制函数之前, 调用 "GL.PushMatrix()", 将当前的 三个矩阵信息, 暂存到某个 stack 中;
            -2- 然后调用各种 GL 函数, 把 state 搞得乱七八糟;
            -3- 结束绘制后, 调用 "GL.PopMatrix()", 把之前的 三个矩阵信息, 又取回来装回去;
        */
        [FreeFunctionAttribute("GLPushMatrixScript")]
        public static void PushMatrix();

        [FreeFunctionAttribute("GLPopMatrixScript")]
        public static void PopMatrix();



        /*
        // 摘要:
        //     Resolves the render target for subsequent operations sampling from it.
        public static void RenderTargetBarrier();
        [NativeNameAttribute("SetUserBackfaceMode")]
        [Obsolete("SetRevertBackfacing(revertBackFaces) is deprecated. Use invertCulling property instead.", false)]
        public static void SetRevertBackfacing(bool revertBackFaces);
        */


        /*
            摘要:
            Sets current texture coordinate (v.x,v.y,v.z) for all texture units.

            在 opengl 中, 
            如果没开启 multi-texturing, 本函数等同于 "glTexCoord()"
            如果开启, 本函数等同于 "glMultiTexCoord()" 
            且都是针对所有 texture, (而不是具体某一个)
            别的平台有对应的函数;

            The Z component is used only when:
            -1- 你真正访问一个 cubemap (which you access with a vector coordinate, hence x,y & z).
                猜测 z分量被用来选择 cubemap 的某个面;
            -2- 你在 "projective texturing" (投影一个 texture),
                此时, x,y分量要除以 z分量, 得到最终的 coord;
                这主要用来实现 水母反射 或类似的东西;

            本函数只能在  "GL.Begin()" and "GL.End()" 函数块体内被调用;
        */
        public static void TexCoord(Vector3 v);

        [NativeNameAttribute("ImmediateTexCoordAll")]
        public static void TexCoord3(float x, float y, float z);


        /*
            摘要:
            Sets current texture coordinate (x,y) for all texture units.

            在 opengl 中, 
            如果没开启 multi-texturing, 本函数等同于 "glTexCoord()"
            如果开启, 本函数等同于 "glMultiTexCoord()" 
            且都是针对所有 texture, (而不是具体某一个)
            别的平台有对应的函数;

            本函数只能在  "GL.Begin()" and "GL.End()" 函数块体内被调用;
        */
        public static void TexCoord2(float x, float y);


        
        /*
            摘要:
            Submit a vertex.   提交一个顶点 pos;

            In OpenGL 本函数等同于 "glVertex3f(x,y,z);" 在别的平台,则有对应的函数或函数组合;
            本函数只能在  "GL.Begin()" and "GL.End()" 函数块体内被调用;
        */
        public static void Vertex(Vector3 v);
        [NativeNameAttribute("ImmediateVertex")]public static void Vertex3(float x, float y, float z);


        /*
            摘要:
            Set the rendering viewport.

            所有的渲染都被约束在 参数 pixelRect 指定的区域内;
            如果 Viewport 被改写, 渲染的内容会被拉伸;
        */
        [FreeFunctionAttribute("SetGLViewport")]
        public static void Viewport(Rect pixelRect);
    }
}