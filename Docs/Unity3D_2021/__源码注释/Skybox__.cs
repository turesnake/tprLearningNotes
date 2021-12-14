#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
   
    /*
        A script interface for the "skybox component".
        The skybox class has only the material property.
        ---
        可以在 camera go 上绑定一个 "skybox component";
        然后用此组件来覆写 默认的 skybox material;

        built-in, urp 支持, hdrp 不支持;
    */
    [NativeHeaderAttribute("Runtime/Camera/Skybox.h")]
    public sealed class Skybox//Skybox__
        : Behaviour
    {
        public Skybox();

        
        //     The material used by the skybox.
        // Note that unlike "Renderer.material", 
        // this returns a "shared material reference" and not a "unique duplicate".
        public Material material { get; set; }
    }
}

