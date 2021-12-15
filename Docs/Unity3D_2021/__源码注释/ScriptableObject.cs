#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        A class you can derive from if you want to create objects that don't need to
        be attached to game objects.





    */
    [ExtensionOfNativeClassAttribute]
    [NativeClassAttribute(null)]
    [NativeHeaderAttribute("Runtime/Mono/MonoBehaviour.h")]
    [RequiredByNativeCodeAttribute]
    public class ScriptableObject//ScriptableObject__RR
        : Object
    {
        public ScriptableObject();

        /*
            摘要:
            Creates an instance of a scriptable object.
        
            关于 "ScriptableObject"  的更多信息, 可查看另一个文件;

            To easily create a ScriptableObject instance 
            that is bound to a .asset file via the Editor user interface, 
            consider using "CreateAssetMenuAttribute" (class)

        // 参数:
        //   className:
        //     The type of the ScriptableObject to create, as the name of the type.
        //
        //   type:
        //     The type of the ScriptableObject to create, as a System.Type instance.
        //
        // 返回结果:
        //     The created ScriptableObject.
        */
        public static ScriptableObject CreateInstance(string className);
        public static ScriptableObject CreateInstance(Type type);
        public static T CreateInstance<T>() where T : ScriptableObject;

        /*
        [NativeConditionalAttribute("ENABLE_MONO")]
        [Obsolete("Use EditorUtility.SetDirty instead")]
        public void SetDirty();
        */

    }
}

