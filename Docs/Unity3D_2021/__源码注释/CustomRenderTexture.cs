#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     Custom Render Textures are an extension to Render Textures, enabling you to render
    //     directly to the Texture using a Shader.
    [NativeHeaderAttribute("Runtime/Graphics/CustomRenderTexture.h")]
    [UsedByNativeCodeAttribute]
    public sealed class CustomRenderTexture : RenderTexture
    {
        //
        // 摘要:
        //     Create a new Custom Render Texture.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   format:
        //
        //   readWrite:
        public CustomRenderTexture(int width, int height);
        public CustomRenderTexture(int width, int height, GraphicsFormat format);
        //
        // 摘要:
        //     Create a new Custom Render Texture.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   format:
        //
        //   readWrite:
        public CustomRenderTexture(int width, int height, RenderTextureFormat format);
        public CustomRenderTexture(int width, int height, DefaultFormat defaultFormat);
        //
        // 摘要:
        //     Create a new Custom Render Texture.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   format:
        //
        //   readWrite:
        public CustomRenderTexture(int width, int height, RenderTextureFormat format, RenderTextureReadWrite readWrite);

        //
        // 摘要:
        //     If true, the Custom Render Texture is double buffered so that you can access
        //     it during its own update. otherwise the Custom Render Texture will be not be
        //     double buffered.
        public bool doubleBuffered { get; set; }
        //
        // 摘要:
        //     Bitfield that allows to enable or disable update on each of the cubemap faces.
        //     Order from least significant bit is +X, -X, +Y, -Y, +Z, -Z.
        public uint cubemapFaceMask { get; set; }
        //
        // 摘要:
        //     Shader Pass used to update the Custom Render Texture.
        public int shaderPass { get; set; }
        //
        // 摘要:
        //     Space in which the update zones are expressed (Normalized or Pixel space).
        public CustomRenderTextureUpdateZoneSpace updateZoneSpace { get; set; }
        //
        // 摘要:
        //     Specify how the texture should be initialized.
        public CustomRenderTextureUpdateMode initializationMode { get; set; }
        //
        // 摘要:
        //     Specify how the texture should be updated.
        public CustomRenderTextureUpdateMode updateMode { get; set; }
        //
        // 摘要:
        //     Color with which the Custom Render Texture is initialized. This parameter will
        //     be ignored if an initializationMaterial is set.
        public Color initializationColor { get; set; }
        //
        // 摘要:
        //     Specify if the texture should be initialized with a Texture and a Color or a
        //     Material.
        public CustomRenderTextureInitializationSource initializationSource { get; set; }
        //
        // 摘要:
        //     Texture with which the Custom Render Texture is initialized (multiplied by the
        //     initialization color). This parameter will be ignored if an initializationMaterial
        //     is set.
        public Texture initializationTexture { get; set; }
        //
        // 摘要:
        //     Period in seconds at which real-time textures are updated (0.0 will update every
        //     frame).
        public float updatePeriod { get; set; }
        //
        // 摘要:
        //     Material with which the content of the Custom Render Texture is updated.
        public Material material { get; set; }
        //
        // 摘要:
        //     If true, Update zones will wrap around the border of the Custom Render Texture.
        //     Otherwise, Update zones will be clamped at the border of the Custom Render Texture.
        public bool wrapUpdateZones { get; set; }
        //
        // 摘要:
        //     Material with which the Custom Render Texture is initialized. Initialization
        //     texture and color are ignored if this parameter is set.
        public Material initializationMaterial { get; set; }

        //
        // 摘要:
        //     Clear all Update Zones.
        public void ClearUpdateZones();
        //
        // 摘要:
        //     Updates the internal RenderTexture that a CustomRenderTexture uses for double
        //     buffering, so that it matches the size and format of the CustomRenderRexture.
        public void EnsureDoubleBufferConsistency();
        //
        // 摘要:
        //     Gets the RenderTexture that this CustomRenderTexture uses for double buffering.
        //
        // 返回结果:
        //     If CustomRenderTexture. doubleBuffered is true, this returns the RenderTexture
        //     that this CustomRenderTexture uses for double buffering. If CustomRenderTexture.
        //     doubleBuffered is false, this returns null.
        [FreeFunctionAttribute(Name = "CustomRenderTextureScripting::GetDoubleBufferRenderTexture", HasExplicitThis = true)]
        public RenderTexture GetDoubleBufferRenderTexture();
        public void GetUpdateZones(List<CustomRenderTextureUpdateZone> updateZones);
        //
        // 摘要:
        //     Triggers an initialization of the Custom Render Texture.
        public void Initialize();
        //
        // 摘要:
        //     Setup the list of Update Zones for the Custom Render Texture.
        //
        // 参数:
        //   updateZones:
        public void SetUpdateZones(CustomRenderTextureUpdateZone[] updateZones);
        public void Update();
        //
        // 摘要:
        //     Triggers the update of the Custom Render Texture.
        //
        // 参数:
        //   count:
        //     Number of upate pass to perform.
        public void Update(int count);
    }
}
