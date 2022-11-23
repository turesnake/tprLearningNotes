#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Base class for all entities in Unity Scenes.
    [ExcludeFromPreset]
    [NativeHeaderAttribute("Runtime/Export/Scripting/GameObject.bindings.h")]
    [UsedByNativeCodeAttribute]
    public sealed class GameObject //GameObject__RR
        : Object
    {
        //
        // 摘要:
        //     Creates a new game object, named name.
        //
        // 参数:
        //   name:
        //     The name that the GameObject is created with.
        //
        //   components:
        //     A list of Components to add to the GameObject on creation.
        public GameObject();
        //
        // 摘要:
        //     Creates a new game object, named name.
        //
        // 参数:
        //   name:
        //     The name that the GameObject is created with.
        //
        //   components:
        //     A list of Components to add to the GameObject on creation.
        public GameObject(string name);
        //
        // 摘要:
        //     Creates a new game object, named name.
        //
        // 参数:
        //   name:
        //     The name that the GameObject is created with.
        //
        //   components:
        //     A list of Components to add to the GameObject on creation.
        public GameObject(string name, params Type[] components);

        //
        // 摘要:
        //     The ParticleSystem attached to this GameObject (Read Only). (Null if there is
        //     none attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property particleSystem has been deprecated. Use GetComponent<ParticleSystem>() instead. (UnityUpgradable)", true)]
        // public Component particleSystem { get; }

        //
        // 摘要:
        //     The Transform attached to this GameObject.
        public Transform transform { get; }
        //
        // 摘要:
        //     The layer the GameObject is in.
        public int layer { get; set; }


        // [Obsolete("GameObject.active is obsolete. Use GameObject.SetActive(), GameObject.activeSelf or GameObject.activeInHierarchy.")]
        // public bool active { get; set; }


        //
        // 摘要:
        //     The local active state of this GameObject. (Read Only)
        public bool activeSelf { get; }
        //
        // 摘要:
        //     Defines whether the GameObject is active in the Scene.
        public bool activeInHierarchy { get; }
        //
        // 摘要:
        //     Gets and sets the GameObject's StaticEditorFlags.
        public bool isStatic { get; set; }
        //
        // 摘要:
        //     The tag of this game object.
        public string tag { get; set; }
        //
        // 摘要:
        //     Scene that the GameObject is part of.
        public Scene scene { get; }
        //
        // 摘要:
        //     Scene culling mask Unity uses to determine which scene to render the GameObject
        //     in.
        public ulong sceneCullingMask { get; }
        public GameObject gameObject { get; }

        //
        // 摘要:
        //     The Rigidbody2D component attached to this GameObject. (Read Only)
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property rigidbody2D has been deprecated. Use GetComponent<Rigidbody2D>() instead. (UnityUpgradable)", true)]
        // public Component rigidbody2D { get; }

        //
        // 摘要:
        //     The Camera attached to this GameObject (Read Only). (Null if there is none attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property camera has been deprecated. Use GetComponent<Camera>() instead. (UnityUpgradable)", true)]
        // public Component camera { get; }

        //
        // 摘要:
        //     The Light attached to this GameObject (Read Only). (Null if there is none attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property light has been deprecated. Use GetComponent<Light>() instead. (UnityUpgradable)", true)]
        // public Component light { get; }

        //
        // 摘要:
        //     The Animation attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property animation has been deprecated. Use GetComponent<Animation>() instead. (UnityUpgradable)", true)]
        // public Component animation { get; }

        //
        // 摘要:
        //     The ConstantForce attached to this GameObject (Read Only). (Null if there is
        //     none attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property constantForce has been deprecated. Use GetComponent<ConstantForce>() instead. (UnityUpgradable)", true)]
        // public Component constantForce { get; }

        //
        // 摘要:
        //     The Renderer attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property renderer has been deprecated. Use GetComponent<Renderer>() instead. (UnityUpgradable)", true)]
        // public Component renderer { get; }

        //
        // 摘要:
        //     The AudioSource attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property audio has been deprecated. Use GetComponent<AudioSource>() instead. (UnityUpgradable)", true)]
        // public Component audio { get; }
        //
        // 摘要:
        //     The NetworkView attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property networkView has been deprecated. Use GetComponent<NetworkView>() instead. (UnityUpgradable)", true)]
        // public Component networkView { get; }
        //
        // 摘要:
        //     The Collider attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property collider has been deprecated. Use GetComponent<Collider>() instead. (UnityUpgradable)", true)]
        // public Component collider { get; }
        //
        // 摘要:
        //     The Collider2D component attached to this object.
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property collider2D has been deprecated. Use GetComponent<Collider2D>() instead. (UnityUpgradable)", true)]
        // public Component collider2D { get; }
        //
        // 摘要:
        //     The Rigidbody attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property rigidbody has been deprecated. Use GetComponent<Rigidbody>() instead. (UnityUpgradable)", true)]
        // public Component rigidbody { get; }
        //
        // 摘要:
        //     The HingeJoint attached to this GameObject (Read Only). (Null if there is none
        //     attached).
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Property hingeJoint has been deprecated. Use GetComponent<HingeJoint>() instead. (UnityUpgradable)", true)]
        // public Component hingeJoint { get; }

        //
        // 摘要:
        //     Creates a game object with a primitive mesh renderer and appropriate collider.
        //
        // 参数:
        //   type:
        //     The type of primitive object to create.
        [FreeFunctionAttribute("GameObjectBindings::CreatePrimitive")]
        public static GameObject CreatePrimitive(PrimitiveType type);
        //
        // 摘要:
        //     Finds a GameObject by name and returns it.
        //
        // 参数:
        //   name:
        [FreeFunctionAttribute(Name = "GameObjectBindings::Find")]
        public static GameObject Find(string name);
        //
        // 摘要:
        //     Returns an array of active GameObjects tagged tag. Returns empty array if no
        //     GameObject was found.
        //
        // 参数:
        //   tag:
        //     The name of the tag to search GameObjects for.
        [FreeFunctionAttribute(Name = "GameObjectBindings::FindGameObjectsWithTag", ThrowsException = true)]
        public static GameObject[] FindGameObjectsWithTag(string tag);
        [FreeFunctionAttribute(Name = "GameObjectBindings::FindGameObjectWithTag", ThrowsException = true)]
        public static GameObject FindGameObjectWithTag(string tag);
        //
        // 摘要:
        //     Returns one active GameObject tagged tag. Returns null if no GameObject was found.
        //
        // 参数:
        //   tag:
        //     The tag to search for.
        public static GameObject FindWithTag(string tag);

        //
        // 摘要:
        //     Adds a component class named className to the game object.
        //
        // 参数:
        //   className:
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("GameObject.AddComponent with string argument has been deprecated. Use GameObject.AddComponent<T>() instead. (UnityUpgradable).", true)]
        // public Component AddComponent(string className);

        //
        // 摘要:
        //     Adds a component class of type componentType to the game object. C# Users can
        //     use a generic version.
        //
        // 参数:
        //   componentType:
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component AddComponent(Type componentType);
        public T AddComponent<T>() where T : Component;
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     or any of its children.
        //
        // 参数:
        //   methodName:
        //
        //   parameter:
        //
        //   options:
        [ExcludeFromDocs]
        public void BroadcastMessage(string methodName);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     or any of its children.
        //
        // 参数:
        //   methodName:
        //
        //   parameter:
        //
        //   options:
        [ExcludeFromDocs]
        public void BroadcastMessage(string methodName, object parameter);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     or any of its children.
        //
        // 参数:
        //   methodName:
        //
        //   parameter:
        //
        //   options:
        [FreeFunctionAttribute(Name = "Scripting::BroadcastScriptingMessage", HasExplicitThis = true)]
        public void BroadcastMessage(string methodName, [Internal.DefaultValue("null")] object parameter, [Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);
        //
        // 参数:
        //   methodName:
        //
        //   options:
        public void BroadcastMessage(string methodName, SendMessageOptions options);
        //
        // 摘要:
        //     Is this game object tagged with tag ?
        //
        // 参数:
        //   tag:
        //     The tag to compare.
        [FreeFunctionAttribute(Name = "GameObjectBindings::CompareTag", HasExplicitThis = true)]
        public bool CompareTag(string tag);
        //
        // 摘要:
        //     Returns the component with name type if the GameObject has one attached, null
        //     if it doesn't.
        //
        // 参数:
        //   type:
        //     The type of Component to retrieve.
        public Component GetComponent(string type);
        [SecuritySafeCritical]
        public T GetComponent<T>();
        //
        // 摘要:
        //     Returns the component of Type type if the game object has one attached, null
        //     if it doesn't.
        //
        // 参数:
        //   type:
        //     The type of Component to retrieve.
        [FreeFunctionAttribute(Name = "GameObjectBindings::GetComponentFromType", HasExplicitThis = true, ThrowsException = true)]
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponent(Type type);
        //
        // 摘要:
        //     Returns the component of Type type in the GameObject or any of its children using
        //     depth first search.
        //
        // 参数:
        //   type:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //
        // 返回结果:
        //     A component of the matching type, if found.
        [FreeFunctionAttribute(Name = "GameObjectBindings::GetComponentInChildren", HasExplicitThis = true, ThrowsException = true)]
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInChildren(Type type, bool includeInactive);
        [ExcludeFromDocs]
        public T GetComponentInChildren<T>();
        public T GetComponentInChildren<T>([Internal.DefaultValue("false")] bool includeInactive);
        //
        // 摘要:
        //     Returns the component of Type type in the GameObject or any of its children using
        //     depth first search.
        //
        // 参数:
        //   type:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //
        // 返回结果:
        //     A component of the matching type, if found.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInChildren(Type type);
        //
        // 摘要:
        //     Retrieves the component of Type type in the GameObject or any of its parents.
        //
        // 参数:
        //   type:
        //     Type of component to find.
        //
        //   includeInactive:
        //
        // 返回结果:
        //     Returns a component if a component matching the type is found. Returns null otherwise.
        [FreeFunctionAttribute(Name = "GameObjectBindings::GetComponentInParent", HasExplicitThis = true, ThrowsException = true)]
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInParent(Type type, bool includeInactive);
        //
        // 摘要:
        //     Retrieves the component of Type type in the GameObject or any of its parents.
        //
        // 参数:
        //   type:
        //     Type of component to find.
        //
        //   includeInactive:
        //
        // 返回结果:
        //     Returns a component if a component matching the type is found. Returns null otherwise.
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public Component GetComponentInParent(Type type);
        [ExcludeFromDocs]
        public T GetComponentInParent<T>();
        public T GetComponentInParent<T>([Internal.DefaultValue("false")] bool includeInactive);
        public void GetComponents<T>(List<T> results);
        //
        // 摘要:
        //     Returns all components of Type type in the GameObject.
        //
        // 参数:
        //   type:
        //     The type of component to retrieve.
        public Component[] GetComponents(Type type);
        public T[] GetComponents<T>();
        public void GetComponents(Type type, List<Component> results);


        /*
            遍历自己的所有 子孙 gos, 也包含 根go 自己; 
        */
        public void GetComponentsInChildren<T>(List<T> results);
        public T[] GetComponentsInChildren<T>();
        public void GetComponentsInChildren<T>(bool includeInactive, List<T> results);
        public T[] GetComponentsInChildren<T>(bool includeInactive);
        //
        // 摘要:
        //     Returns all components of Type type in the GameObject or any of its children.
        //
        // 参数:
        //   type:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //     Should Components on inactive GameObjects be included in the found set?
        public Component[] GetComponentsInChildren(Type type, [Internal.DefaultValue("false")] bool includeInactive);
        //
        // 摘要:
        //     Returns all components of Type type in the GameObject or any of its children.
        //
        // 参数:
        //   type:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //     Should Components on inactive GameObjects be included in the found set?
        [ExcludeFromDocs]
        public Component[] GetComponentsInChildren(Type type);





        public T[] GetComponentsInParent<T>();
        public void GetComponentsInParent<T>(bool includeInactive, List<T> results);
        public T[] GetComponentsInParent<T>(bool includeInactive);
        //
        // 摘要:
        //     Returns all components of Type type in the GameObject or any of its parents.
        //
        // 参数:
        //   type:
        //     The type of Component to retrieve.
        //
        //   includeInactive:
        //     Should inactive Components be included in the found set?
        public Component[] GetComponentsInParent(Type type, [Internal.DefaultValue("false")] bool includeInactive);
        [ExcludeFromDocs]
        public Component[] GetComponentsInParent(Type type);

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("gameObject.PlayAnimation is not supported anymore. Use animation.Play()", true)]
        // public void PlayAnimation(Object animation);

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("GameObject.SampleAnimation(AnimationClip, float) has been deprecated. Use AnimationClip.SampleAnimation(GameObject, float) instead (UnityUpgradable).", true)]
        // public void SampleAnimation(Object clip, float time);

        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object.
        //
        // 参数:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [ExcludeFromDocs]
        public void SendMessage(string methodName);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object.
        //
        // 参数:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [ExcludeFromDocs]
        public void SendMessage(string methodName, object value);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object.
        //
        // 参数:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [FreeFunctionAttribute(Name = "Scripting::SendScriptingMessage", HasExplicitThis = true)]
        public void SendMessage(string methodName, [Internal.DefaultValue("null")] object value, [Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);
        //
        // 参数:
        //   methodName:
        //
        //   options:
        public void SendMessage(string methodName, SendMessageOptions options);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     and on every ancestor of the behaviour.
        //
        // 参数:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [ExcludeFromDocs]
        public void SendMessageUpwards(string methodName);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     and on every ancestor of the behaviour.
        //
        // 参数:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [ExcludeFromDocs]
        public void SendMessageUpwards(string methodName, object value);
        //
        // 摘要:
        //     Calls the method named methodName on every MonoBehaviour in this game object
        //     and on every ancestor of the behaviour.
        //
        // 参数:
        //   methodName:
        //     The name of the method to call.
        //
        //   value:
        //     An optional parameter value to pass to the called method.
        //
        //   options:
        //     Should an error be raised if the method doesn't exist on the target object?
        [FreeFunctionAttribute(Name = "Scripting::SendScriptingMessageUpwards", HasExplicitThis = true)]
        public void SendMessageUpwards(string methodName, [Internal.DefaultValue("null")] object value, [Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);
        //
        // 参数:
        //   methodName:
        //
        //   options:
        public void SendMessageUpwards(string methodName, SendMessageOptions options);
        //
        // 摘要:
        //     ActivatesDeactivates the GameObject, depending on the given true or false/ value.
        //
        // 参数:
        //   value:
        //     Activate or deactivate the object, where true activates the GameObject and false
        //     deactivates the GameObject.
        [NativeMethodAttribute(Name = "SetSelfActive")]
        public void SetActive(bool value);


        // [NativeMethodAttribute(Name = "SetActiveRecursivelyDeprecated")]
        // [Obsolete("gameObject.SetActiveRecursively() is obsolete. Use GameObject.SetActive(), which is now inherited by children.")]
        // public void SetActiveRecursively(bool state);

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("gameObject.StopAnimation is not supported anymore. Use animation.Stop()", true)]
        // public void StopAnimation();



        /*
            Gets the component of the specified type, if it exists.
        */
        /// <param name="type">The type of component to retrieve.</param>
        /// <param name="component">The output argument that will contain the component or null.</param>
        /// <returns>Returns true if the component is found, false otherwise.</returns>
        public bool TryGetComponent(Type type, out Component component);
        [SecuritySafeCritical]
        public bool TryGetComponent<T>(out T component);
    }
}

