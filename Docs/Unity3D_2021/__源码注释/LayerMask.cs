#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    /*
        Specifies Layers to use in a Physics.Raycast.



        
    */
    [NativeClassAttribute("BitField", "struct BitField;")]
    [NativeHeaderAttribute("Runtime/BaseClasses/TagManager.h")]
    [NativeHeaderAttribute("Runtime/BaseClasses/BitField.h")]
    [RequiredByNativeCodeAttribute(Optional = true, GenerateProxy = true)]
    public struct LayerMask//LayerMask__RR
    {
        //
        // 摘要:
        //     Converts a layer mask value to an integer value.
        public int value { get; set; }

        //
        // 摘要:
        //     Given a set of layer names as defined by either a Builtin or a User Layer in
        //     the, returns the equivalent layer mask for all of them.
        //
        // 参数:
        //   layerNames:
        //     List of layer names to convert to a layer mask.
        //
        // 返回结果:
        //     The layer mask created from the layerNames.
        public static int GetMask(params string[] layerNames);
        //
        // 摘要:
        //     Given a layer number, returns the name of the layer as defined in either a Builtin
        //     or a User Layer in the.
        //
        // 参数:
        //   layer:
        [NativeMethodAttribute("LayerToString")]
        [StaticAccessorAttribute("GetTagManager()", Bindings.StaticAccessorType.Dot)]
        public static string LayerToName(int layer);
        //
        // 摘要:
        //     Given a layer name, returns the layer index as defined by either a Builtin or
        //     a User Layer in the.
        //
        // 参数:
        //   layerName:
        [NativeMethodAttribute("StringToLayer")]
        [StaticAccessorAttribute("GetTagManager()", Bindings.StaticAccessorType.Dot)]
        public static int NameToLayer(string layerName);

        public static implicit operator int(LayerMask mask);
        public static implicit operator LayerMask(int intVal);
    }
}

