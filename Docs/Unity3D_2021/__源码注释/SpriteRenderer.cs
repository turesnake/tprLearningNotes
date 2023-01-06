#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using UnityEngine.Events;

namespace UnityEngine
{
    //
    // 摘要:
    //     Renders a Sprite for 2D graphics.
    [NativeTypeAttribute("Runtime/Graphics/Mesh/SpriteRenderer.h")]
    [RequireComponent(typeof(Transform))]
    public sealed class SpriteRenderer : Renderer
    {
        public SpriteRenderer();

        //
        // 摘要:
        //     The Sprite to render.
        public Sprite sprite { get; set; }
        //
        // 摘要:
        //     The current draw mode of the Sprite Renderer.
        public SpriteDrawMode drawMode { get; set; }
        //
        // 摘要:
        //     Property to set/get the size to render when the SpriteRenderer.drawMode is set
        //     to SpriteDrawMode.Sliced.
        public Vector2 size { get; set; }
        //
        // 摘要:
        //     The current threshold for Sprite Renderer tiling.
        public float adaptiveModeThreshold { get; set; }
        //
        // 摘要:
        //     The current tile mode of the Sprite Renderer.
        public SpriteTileMode tileMode { get; set; }
        //
        // 摘要:
        //     Rendering color for the Sprite graphic.
        public Color color { get; set; }
        //
        // 摘要:
        //     Specifies how the sprite interacts with the masks.
        public SpriteMaskInteraction maskInteraction { get; set; }
        //
        // 摘要:
        //     Flips the sprite on the X axis.
        public bool flipX { get; set; }
        //
        // 摘要:
        //     Flips the sprite on the Y axis.
        public bool flipY { get; set; }
        //
        // 摘要:
        //     Determines the position of the Sprite used for sorting the SpriteRenderer.
        public SpriteSortPoint spriteSortPoint { get; set; }

        public void RegisterSpriteChangeCallback(UnityAction<SpriteRenderer> callback);
        public void UnregisterSpriteChangeCallback(UnityAction<SpriteRenderer> callback);
    }
}