#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Security;
using UnityEngine.Internal;
using UnityEngineInternal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Base class for all objects Unity can reference.
    [NativeHeaderAttribute("Runtime/GameCode/CloneObject.h")]
    [NativeHeaderAttribute("Runtime/SceneManager/SceneManager.h")]
    [NativeHeaderAttribute("Runtime/Export/Scripting/UnityEngineObject.bindings.h")]
    [RequiredByNativeCodeAttribute(GenerateProxy = true)]
    public class Object
    {
        public Object();

        //
        // 摘要:
        //     Should the object be hidden, saved with the Scene or modifiable by the user?
        public HideFlags hideFlags { get; set; }
        //
        // 摘要:
        //     The name of the object.
        public string name { get; set; }



        /*
            Removes a GameObject, component or asset.

 
            The object obj is destroyed immediately after the current Update loop, or t seconds from now if a time is specified. 
            If obj is a Component, this method removes the component from the GameObject and destroys it. 
            If obj is a GameObject, it destroys the GameObject, all its components and all transform children of the GameObject. 
            ---
            obj 会在本帧的 update loop 之后立刻被 destroy; (或指定的数秒后);

            Actual object destruction is always delayed until after the current Update loop, but is always done before rendering.
            ---
            真正的 销毁工作一定在本帧的 update loop 之后, 在本帧的 rendering 之前被执行;

            Note: When destroying MonoBehaviour scripts, OnDisable and OnDestroy are called before the script is removed.
            ---
            当销毁一个脚本时, 会在脚本被移除前 先调用 OnDisable(), 和 OnDestroy(), 

        //
        // 参数:
        //   obj:
        //     The object to destroy.
        //
        //   t:
        //     The optional amount of time to delay before destroying the object.
        */
        [NativeMethodAttribute(Name = "Scripting::DestroyObjectFromScripting", IsFreeFunction = true, ThrowsException = true)]
        public static void Destroy(Object obj, [DefaultValue("0.0F")] float t);
       
        [ExcludeFromDocs]
        public static void Destroy(Object obj);




        //
        // 摘要:
        //     Destroys the object obj immediately. You are strongly recommended to use Destroy
        //     instead.
        //
        // 参数:
        //   obj:
        //     Object to be destroyed.
        //
        //   allowDestroyingAssets:
        //     Set to true to allow assets to be destroyed.
        [ExcludeFromDocs]
        public static void DestroyImmediate(Object obj);
        //
        // 摘要:
        //     Destroys the object obj immediately. You are strongly recommended to use Destroy
        //     instead.
        //
        // 参数:
        //   obj:
        //     Object to be destroyed.
        //
        //   allowDestroyingAssets:
        //     Set to true to allow assets to be destroyed.
        [NativeMethodAttribute(Name = "Scripting::DestroyObjectFromScriptingImmediate", IsFreeFunction = true, ThrowsException = true)]
        public static void DestroyImmediate(Object obj, [DefaultValue("false")] bool allowDestroyingAssets);
        [Obsolete("use Object.Destroy instead.")]
        public static void DestroyObject(Object obj, [DefaultValue("0.0F")] float t);
        [ExcludeFromDocs]
        [Obsolete("use Object.Destroy instead.")]
        public static void DestroyObject(Object obj);
        //
        // 摘要:
        //     Do not destroy the target Object when loading a new Scene.
        //
        // 参数:
        //   target:
        //     An Object not destroyed on Scene change.
        [FreeFunctionAttribute("GetSceneManager().DontDestroyOnLoad", ThrowsException = true)]
        public static void DontDestroyOnLoad([NotNullAttribute("NullExceptionObject")] Object target);
        public static T FindObjectOfType<T>() where T : Object;
        public static T FindObjectOfType<T>(bool includeInactive) where T : Object;
        //
        // 摘要:
        //     Returns the first active loaded object of Type type.
        //
        // 参数:
        //   type:
        //     The type of object to find.
        //
        //   includeInactive:
        //
        // 返回结果:
        //     Object The first active loaded object that matches the specified type. It returns
        //     null if no Object matches the type.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public static Object FindObjectOfType(Type type);
        //
        // 摘要:
        //     Returns the first active loaded object of Type type.
        //
        // 参数:
        //   type:
        //     The type of object to find.
        //
        //   includeInactive:
        //
        // 返回结果:
        //     Object The first active loaded object that matches the specified type. It returns
        //     null if no Object matches the type.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public static Object FindObjectOfType(Type type, bool includeInactive);
        public static T[] FindObjectsOfType<T>() where T : Object;
        //
        // 摘要:
        //     Gets a list of all loaded objects of Type type.
        //
        // 参数:
        //   type:
        //     The type of object to find.
        //
        //   includeInactive:
        //     If true, components attached to inactive GameObjects are also included.
        //
        // 返回结果:
        //     The array of objects found matching the type specified.
        [FreeFunctionAttribute("UnityEngineObjectBindings::FindObjectsOfType")]
        [TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
        public static Object[] FindObjectsOfType(Type type, bool includeInactive);
        public static T[] FindObjectsOfType<T>(bool includeInactive) where T : Object;
        //
        // 摘要:
        //     Gets a list of all loaded objects of Type type.
        //
        // 参数:
        //   type:
        //     The type of object to find.
        //
        //   includeInactive:
        //     If true, components attached to inactive GameObjects are also included.
        //
        // 返回结果:
        //     The array of objects found matching the type specified.
        public static Object[] FindObjectsOfType(Type type);
        //
        // 摘要:
        //     Returns a list of all active and inactive loaded objects of Type type.
        //
        // 参数:
        //   type:
        //     The type of object to find.
        //
        // 返回结果:
        //     The array of objects found matching the type specified.
        [Obsolete("Please use Resources.FindObjectsOfTypeAll instead")]
        public static Object[] FindObjectsOfTypeAll(Type type);
        //
        // 摘要:
        //     Returns a list of all active and inactive loaded objects of Type type, including
        //     assets.
        //
        // 参数:
        //   type:
        //     The type of object or asset to find.
        //
        // 返回结果:
        //     The array of objects and assets found matching the type specified.
        [FreeFunctionAttribute("UnityEngineObjectBindings::FindObjectsOfTypeIncludingAssets")]
        [Obsolete("use Resources.FindObjectsOfTypeAll instead.")]
        public static Object[] FindObjectsOfTypeIncludingAssets(Type type);
        [Obsolete("warning use Object.FindObjectsOfType instead.")]
        public static Object[] FindSceneObjectsOfType(Type type);



        /*
            Clones the object original and returns the clone.

            --
                如果克隆一个组件, 则也会克隆这个组件所在的 gameobj
            --
                如果克隆的 go/组件 带有子gos, 则子gos 也会被递归克隆, 
                当消耗超出 内存栈的一半时, 抛出异常 InsufficientExecutionStackException;
            --
                若不设置 parent 参数, 则新go 的 parent 默认为 null;
                可设置参数 instantiateInWorldSpace 来指定参数 pos 是 OS 还是 WS;
            --
                若 origin go 是 disactive 的, 那么新建的 go 也保持 disactive;
                Additionally for the object and all child objects in the hierarchy, each of their Monobehaviours and Components 
                will have their Awake and OnEnable methods called only if they are active in the hierarchy at the time of this method call.

            --  
                These methods do not create a prefab connection to the new instantiated object. 
                Creating objects with a prefab connection can be achieved using "PrefabUtility.InstantiatePrefab()"
            
            参数:
            original:
                An existing object that you want to make a copy of.
            
            position:
                Position for the new object.
            
            rotation:
                Orientation of the new object.
            
            parent:
                Parent that will be assigned to the new object.
            
            instantiateInWorldSpace:
                When you assign a parent Object, pass true to position the new object directly
                in world space. Pass false to set the Object’s position relative to its new parent.
            
            返回结果:
                The instantiated clone.
        */
        public static T Instantiate<T>(T original, Transform parent) where T : Object;
        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);
        public static T Instantiate<T>(T original, Transform parent, bool worldPositionStays) where T : Object;

        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original);

        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);

        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace);
        public static T Instantiate<T>(T original) where T : Object;
        public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object;
        public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : Object;

        [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
        public static Object Instantiate(Object original, Transform parent);



        public override bool Equals(object other);
        public override int GetHashCode();
        //
        // 摘要:
        //     Gets the instance ID of the object.
        //
        // 返回结果:
        //     Returns the instance ID of the object. When used to call the origin object, this
        //     method returns a positive value. When used to call the instance object, this
        //     method returns a negative value.
        [SecuritySafeCritical]
        public int GetInstanceID();
        //
        // 摘要:
        //     Returns the name of the object.
        //
        // 返回结果:
        //     The name returned by ToString.
        public override string ToString();

        public static bool operator ==(Object x, Object y);
        public static bool operator !=(Object x, Object y);

        public static implicit operator bool(Object exists);
    }
}