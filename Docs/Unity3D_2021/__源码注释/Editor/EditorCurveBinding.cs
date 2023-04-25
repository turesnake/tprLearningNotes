#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;

namespace UnityEditor
{
    //
    // 摘要:
    //     Defines how a curve is attached to an object that it controls.
    [NativeTypeAttribute(UnityEngine.Bindings.CodegenOptions.Custom, "MonoEditorCurveBinding")]
    public struct EditorCurveBinding : IEquatable<EditorCurveBinding>
    {
        //
        // 摘要:
        //     The transform path of the object that is animated.
        public string path;
        //
        // 摘要:
        //     The name of the property to be animated.
        public string propertyName;

        public bool isPPtrCurve { get; }
        public bool isDiscreteCurve { get; }
        //
        // 摘要:
        //     The type of the property to be animated.
        public Type type { get; set; }

        //
        // 摘要:
        //     Creates a preconfigured binding for a curve where values should not be interpolated.
        //
        // 参数:
        //   inPath:
        //     The transform path to the object to animate.
        //
        //   inType:
        //     The type of the object to animate.
        //
        //   inPropertyName:
        //     The name of the property to animate on the object.
        public static EditorCurveBinding DiscreteCurve(string inPath, Type inType, string inPropertyName);
        //
        // 摘要:
        //     Creates a preconfigured binding for a float curve.
        //
        // 参数:
        //   inPath:
        //     The transform path to the object to animate.
        //
        //   inType:
        //     The type of the object to animate.
        //
        //   inPropertyName:
        //     The name of the property to animate on the object.
        public static EditorCurveBinding FloatCurve(string inPath, Type inType, string inPropertyName);
        //
        // 摘要:
        //     Creates a preconfigured binding for a curve that points to an Object.
        //
        // 参数:
        //   inPath:
        //     The transform path to the object to animate.
        //
        //   inType:
        //     The type of the object to animate.
        //
        //   inPropertyName:
        //     The name of the property to animate on the object.
        public static EditorCurveBinding PPtrCurve(string inPath, Type inType, string inPropertyName);
        public override bool Equals(object other);
        public bool Equals(EditorCurveBinding other);
        public override int GetHashCode();

        public static bool operator ==(EditorCurveBinding lhs, EditorCurveBinding rhs);
        public static bool operator !=(EditorCurveBinding lhs, EditorCurveBinding rhs);
    }
}

