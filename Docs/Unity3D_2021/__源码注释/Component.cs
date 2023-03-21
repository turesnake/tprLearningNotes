#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;
using UnityEngine.Internal;
using UnityEngineInternal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Base class for everything attached to GameObjects.
    [NativeClassAttribute("Unity::Component")]
    [NativeHeaderAttribute("Runtime/Export/Scripting/Component.bindings.h")]
    [RequiredByNativeCodeAttribute]
    public class Component : Object
    {
        public Component();

        //
        // 摘要:
        //     The ParticleSystem attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property particleSystem has been deprecated. Use GetComponent<ParticleSystem>() instead. (UnityUpgradable)", true)]
        public Component particleSystem { get; }
        //
        // 摘要:
        //     The Transform attached to this GameObject.
        public Transform transform { get; }
        //
        // 摘要:
        //     The game object this component is attached to. A component is always attached
        //     to a game object.
        public GameObject gameObject { get; }
        //
        // 摘要:
        //     The tag of this game object.
        public string tag { get; set; }
        //
        // 摘要:
        //     The Rigidbody attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property rigidbody has been deprecated. Use GetComponent<Rigidbody>() instead. (UnityUpgradable)", true)]
        public Component rigidbody { get; }
        //
        // 摘要:
        //     The Camera attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property camera has been deprecated. Use GetComponent<Camera>() instead. (UnityUpgradable)", true)]
        public Component camera { get; }
        //
        // 摘要:
        //     The Light attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property light has been deprecated. Use GetComponent<Light>() instead. (UnityUpgradable)", true)]
        public Component light { get; }
        //
        // 摘要:
        //     The Rigidbody2D that is attached to the Component's GameObject.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property rigidbody2D has been deprecated. Use GetComponent<Rigidbody2D>() instead. (UnityUpgradable)", true)]
        public Component rigidbody2D { get; }
        //
        // 摘要:
        //     The ConstantForce attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property constantForce has been deprecated. Use GetComponent<ConstantForce>() instead. (UnityUpgradable)", true)]
        public Component constantForce { get; }
        //
        // 摘要:
        //     The Renderer attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property renderer has been deprecated. Use GetComponent<Renderer>() instead. (UnityUpgradable)", true)]
        public Component renderer { get; }
        //
        // 摘要:
        //     The AudioSource attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property audio has been deprecated. Use GetComponent<AudioSource>() instead. (UnityUpgradable)", true)]
        public Component audio { get; }
        //
        // 摘要:
        //     The NetworkView attached to this GameObject (Read Only). (null if there is none
        //     attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property networkView has been deprecated. Use GetComponent<NetworkView>() instead. (UnityUpgradable)", true)]
        public Component networkView { get; }
        //
        // 摘要:
        //     The Collider attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property collider has been deprecated. Use GetComponent<Collider>() instead. (UnityUpgradable)", true)]
        public Component collider { get; }
        //
        // 摘要:
        //     The Collider2D component attached to the object.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property collider2D has been deprecated. Use GetComponent<Collider2D>() instead. (UnityUpgradable)", true)]
        public Component collider2D { get; }
        //
        // 摘要:
        //     The Animation attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property animation has been deprecated. Use GetComponent<Animation>() instead. (UnityUpgradable)", true)]
        public Component animation { get; }
        //
        // 摘要:
        //     The HingeJoint attached to this GameObject. (Null if there is none attached).
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property hingeJoint has been deprecated. Use GetComponent<HingeJoint>() instead. (UnityUpgradable)", true)]
        public Component hingeJoint { get; }

        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     or any of its children.
        //
        // 参数:
        //   methodName:
        //     Name of the method to call.
        //
        //   parameter:
        //     Optional parameter to pass to the method (can be any value).
        //
        //   options:
        //     Should an error be raised if the method does not exist for a given target object?
        [FreeFunctionAttribute("BroadcastMessage", HasExplicitThis = true)]
        public void BroadcastMessage(string methodName, [Internal.DefaultValue("null")] object parameter, [Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     or any of its children.
        //
        // 参数:
        //   methodName:
        //     Name of the method to call.
        //
        //   parameter:
        //     Optional parameter to pass to the method (can be any value).
        //
        //   options:
        //     Should an error be raised if the method does not exist for a given target object?
        public void BroadcastMessage(string methodName, SendMessageOptions options);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     or any of its children.
        //
        // 参数:
        //   methodName:
        //     Name of the method to call.
        //
        //   parameter:
        //     Optional parameter to pass to the method (can be any value).
        //
        //   options:
        //     Should an error be raised if the method does not exist for a given target object?
        [ExcludeFromDocs]
        public void BroadcastMessage(string methodName);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     or any of its children.
        //
        // 参数:
        //   methodName:
        //     Name of the method to call.
        //
        //   parameter:
        //     Optional parameter to pass to the method (can be any value).
        //
        //   options:
        //     Should an error be raised if the method does not exist for a given target object?
        [ExcludeFromDocs]
        public void BroadcastMessage(string methodName, object parameter);
        //
        // 摘要:
        //     Checks the GameObject's tag against the defined tag.
        //
        // 参数:
        //   tag:
        //     The tag to compare.
        //
        // 返回结果:
        //     Returns true if GameObject has same tag. Returns false otherwise.
        public bool CompareTag(string tag);
        //
        // 摘要:
        //     Returns the component of type if the GameObject has one attached.
        //
        // 参数:
        //   type:
        //     The type of Component to retrieve.
        //
        // 返回结果:
        //     A Component of the matching type, otherwise null if no Component is found.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponent(Type type);
        [SecuritySafeCritical]
        public T GetComponent<T>();
        //
        // 摘要:
        //     To improve the performance of your code, consider using GetComponent with a type
        //     instead of a string.
        //
        // 参数:
        //   type:
        //     The name of the type of Component to get.
        //
        // 返回结果:
        //     A Component of the matching type, otherwise null if no Component is found.
        [FreeFunctionAttribute(HasExplicitThis = true)]
        public Component GetComponent(string type);
        //
        // 摘要:
        //     Returns the Component of type in the GameObject or any of its children using
        //     depth first search.
        //
        // 参数:
        //   t:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //     Should Components on inactive GameObjects be included in the found set?
        //
        // 返回结果:
        //     A Component of the matching type, otherwise null if no Component is found.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInChildren(Type t, bool includeInactive);
        //
        // 摘要:
        //     Returns the Component of type in the GameObject or any of its children using
        //     depth first search.
        //
        // 参数:
        //   t:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //     Should Components on inactive GameObjects be included in the found set?
        //
        // 返回结果:
        //     A Component of the matching type, otherwise null if no Component is found.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInChildren(Type t);
        public T GetComponentInChildren<T>([Internal.DefaultValue("false")] bool includeInactive);
        [ExcludeFromDocs]
        public T GetComponentInChildren<T>();


        /*
                Returns the Component of type in the GameObject or any of its parents.
            
            参数:
            t:
                The type of Component to retrieve.
            
            includeInactive:
                Should Components on inactive GameObjects be included in the found set?
            
            返回结果:
                A Component of the matching type, otherwise null if no Component is found.
        */
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInParent(Type t, bool includeInactive);

        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInParent(Type t);
        public T GetComponentInParent<T>();
        public T GetComponentInParent<T>([Internal.DefaultValue("false")] bool includeInactive);



        //
        // 摘要:
        //     Returns all components of Type type in the GameObject.
        //
        // 参数:
        //   type:
        //     The type of Component to retrieve.
        public Component[] GetComponents(Type type);
        public void GetComponents(Type type, List<Component> results);
        public void GetComponents<T>(List<T> results);
        public T[] GetComponents<T>();
        public T[] GetComponentsInChildren<T>(bool includeInactive);
        //
        // 摘要:
        //     Returns all components of Type type in the GameObject or any of its children
        //     using depth first search. Works recursively.
        //
        // 参数:
        //   t:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //     Should Components on inactive GameObjects be included in the found set. includeInactive
        //     decides which children of the GameObject will be searched. The GameObject that
        //     you call GetComponentsInChildren on is always searched regardless. Default is
        //     false.
        public Component[] GetComponentsInChildren(Type t, bool includeInactive);
        [ExcludeFromDocs]
        public Component[] GetComponentsInChildren(Type t);
        public void GetComponentsInChildren<T>(List<T> results);
        public T[] GetComponentsInChildren<T>();
        public void GetComponentsInChildren<T>(bool includeInactive, List<T> result);
        public T[] GetComponentsInParent<T>();
        [ExcludeFromDocs]
        public Component[] GetComponentsInParent(Type t);
        public void GetComponentsInParent<T>(bool includeInactive, List<T> results);
        public T[] GetComponentsInParent<T>(bool includeInactive);
        //
        // 摘要:
        //     Returns all components of Type type in the GameObject or any of its parents.
        //
        // 参数:
        //   t:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //     Should inactive Components be included in the found set?
        public Component[] GetComponentsInParent(Type t, [Internal.DefaultValue("false")] bool includeInactive);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object.
        //
        // 参数:
        //   methodName:
        //     Name of the method to call.
        //
        //   value:
        //     Optional parameter for the method.
        //
        //   options:
        //     Should an error be raised if the target object doesn't implement the method for
        //     the message?
        public void SendMessage(string methodName, SendMessageOptions options);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object.
        //
        // 参数:
        //   methodName:
        //     Name of the method to call.
        //
        //   value:
        //     Optional parameter for the method.
        //
        //   options:
        //     Should an error be raised if the target object doesn't implement the method for
        //     the message?
        [FreeFunctionAttribute("SendMessage", HasExplicitThis = true)]
        public void SendMessage(string methodName, object value, SendMessageOptions options);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object.
        //
        // 参数:
        //   methodName:
        //     Name of the method to call.
        //
        //   value:
        //     Optional parameter for the method.
        //
        //   options:
        //     Should an error be raised if the target object doesn't implement the method for
        //     the message?
        public void SendMessage(string methodName);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object.
        //
        // 参数:
        //   methodName:
        //     Name of the method to call.
        //
        //   value:
        //     Optional parameter for the method.
        //
        //   options:
        //     Should an error be raised if the target object doesn't implement the method for
        //     the message?
        public void SendMessage(string methodName, object value);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     and on every ancestor of the behaviour.
        //
        // 参数:
        //   methodName:
        //     Name of method to call.
        //
        //   value:
        //     Optional parameter value for the method.
        //
        //   options:
        //     Should an error be raised if the method does not exist on the target object?
        [FreeFunctionAttribute(HasExplicitThis = true)]
        public void SendMessageUpwards(string methodName, [Internal.DefaultValue("null")] object value, [Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     and on every ancestor of the behaviour.
        //
        // 参数:
        //   methodName:
        //     Name of method to call.
        //
        //   value:
        //     Optional parameter value for the method.
        //
        //   options:
        //     Should an error be raised if the method does not exist on the target object?
        [ExcludeFromDocs]
        public void SendMessageUpwards(string methodName, object value);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     and on every ancestor of the behaviour.
        //
        // 参数:
        //   methodName:
        //     Name of method to call.
        //
        //   value:
        //     Optional parameter value for the method.
        //
        //   options:
        //     Should an error be raised if the method does not exist on the target object?
        [ExcludeFromDocs]
        public void SendMessageUpwards(string methodName);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     and on every ancestor of the behaviour.
        //
        // 参数:
        //   methodName:
        //     Name of method to call.
        //
        //   value:
        //     Optional parameter value for the method.
        //
        //   options:
        //     Should an error be raised if the method does not exist on the target object?
        public void SendMessageUpwards(string methodName, SendMessageOptions options);
        [SecuritySafeCritical]
        public bool TryGetComponent<T>(out T component);
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public bool TryGetComponent(Type type, out Component component);
    }
}