#region Assembly UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Bindings;

namespace UnityEditor;

//
// Summary:
//     Representation of Script assets.
[NativeClass(null)]
[NativeType("Editor/Mono/MonoScript.bindings.h")]
[ExcludeFromPreset]
public class MonoScript : TextAsset
{
    //
    // Summary:
    //     Returns the System.Type object of the class implemented by this script.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Type GetClass();

    //
    // Summary:
    //     Returns the MonoScript object containing specified MonoBehaviour.
    //
    // Parameters:
    //   behaviour:
    //     The MonoBehaviour whose MonoScript should be returned.
    public static MonoScript FromMonoBehaviour(MonoBehaviour behaviour)
    {
        return FromScriptedObject(behaviour);
    }

    //
    // Summary:
    //     Returns the MonoScript object containing specified ScriptableObject.
    //
    // Parameters:
    //   scriptableObject:
    //     The ScriptableObject whose MonoScript should be returned.
    public static MonoScript FromScriptableObject(ScriptableObject scriptableObject)
    {
        return FromScriptedObject(scriptableObject);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    internal static extern MonoScript FromScriptedObject(UnityEngine.Object obj);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool GetScriptTypeWasJustCreatedFromComponentMenu();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void SetScriptTypeWasJustCreatedFromComponentMenu();

    public MonoScript()
        : base(CreateOptions.None, null)
    {
        Init_Internal(this);
    }

    internal void Init(string scriptContents, string className, string nameSpace, string assemblyName, bool isEditorScript)
    {
        Init(this, scriptContents, className, nameSpace, assemblyName, isEditorScript);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction("MonoScript_Init_Internal")]
    private static extern void Init_Internal([Writable] MonoScript script);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction("MonoScript_Init")]
    private static extern void Init([NotNull("NullExceptionObject")] MonoScript self, string scriptContents, string className, string nameSpace, string assemblyName, bool isEditorScript);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeName("GetAssemblyName")]
    internal extern string GetAssemblyName();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeName("GetNameSpace")]
    internal extern string GetNamespace();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeName("GetPropertiesHashString")]
    internal extern string GetPropertiesHashString();
}

