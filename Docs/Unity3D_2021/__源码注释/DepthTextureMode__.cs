#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        Depth texture generation mode for Camera.

        flags 可以组合;

        请在笔记中查看: "Cameras and depth textures"
    */
    [Flags]
    public enum DepthTextureMode//DepthTextureMode__
    {


        //     Do not generate depth texture (Default).
        None = 0,

        /*
            Generate a depth texture.

            Will generate a "screen-space depth texture" as seen from this camera. 

            texture 会采用 "RenderTextureFormat.Depth" format, 
            并被设置为 "_CameraDepthTexture" global shader property;
        */
        Depth = 1,

        /*
            Generate a depth + normals texture.

            Will generate a screen-space depth and view-space-normals texture as seen from this camera. 

            texture 会采用 "RenderTextureFormat.ARGB32" format;
            并被设置为 "_CameraDepthNormalsTexture"  global shader property;


            -- view-space-normals 会被编码进 R&G 通道, 
            -- depth 被编码进 B&A 通道; 

            Normals are encoded using Stereographic projection, 
            depth is 16 bit value packed into two 8 bit channels.
        */
        DepthNormals = 2,


        /*
            摘要:
            Specifies whether motion vectors should be rendered (if possible).

            ==
                When set, the camera renders another pass (after opaque but before Image Effects): 

                -- First, a full screen pass is rendered to reconstruct(重建) screen-space motion from the camera movement, 
                -- then, any moving objects have a custom pass to render their object-specific motion. 

                The buffer uses the "RenderTextureFormat.RGHalf" format, 
                (所以只有支持这个 format 的平台 才会实现本模式)

            ==
                Motion vectors capture the "per-pixel, screen-space motion of objects" from one frame to the next. 
                Use this velocity to reconstruct(重建) previous positions, 
                以此来计算 motion blur 或 TAA;

            ==
                to access the generated motion vectors, you can simple read the texture sampler: 

                    sampler2D_half _CameraMotionVectorsTexture 
                    
                in any opaque Image Effect.
        */
        MotionVectors = 4
    }
}

