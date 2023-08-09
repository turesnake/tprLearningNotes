#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// D:\Unity_1_editors\2021.3.4f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
    /* 
        unity 自带的 int<->string id值,  用于两个 id 之间的比较 



        
    */
    //
    // Summary:
    //     Represents a string as an int for efficient lookup and comparison. Use this for
    //     common PropertyNames. Internally stores just an int to represent the string.
    //     A PropertyName can be created from a string but can not be converted back to
    //     a string. The same string always results in the same int representing that string.
    //     Thus this is a very efficient string representation in both memory and speed
    //     when all you need is comparison. PropertyName is serializable. ToString() is
    //     only implemented for debugging purposes in the editor it returns "theName:3737"
    //     in the player it returns "Unknown:3737".
    [UsedByNativeCode]
    public struct PropertyName : IEquatable<PropertyName>
    {
        //
        // Summary:
        //     Initializes the PropertyName using a string.
        //
        // Parameters:
        //   name:
        public PropertyName(string name);
        public PropertyName(PropertyName other);
        public PropertyName(int id);

        //
        // Summary:
        //     Indicates whether the specified PropertyName is an Empty string.
        //
        // Parameters:
        //   prop:
        public static bool IsNullOrEmpty(PropertyName prop);
        //
        // Summary:
        //     Determines whether this instance and a specified object, which must also be a
        //     PropertyName object, have the same value.
        //
        // Parameters:
        //   other:
        public override bool Equals(object other);
        public bool Equals(PropertyName other);
        //
        // Summary:
        //     Returns the hash code for this PropertyName.
        public override int GetHashCode();
        //
        // Summary:
        //     For debugging purposes only. Returns the string value representing the string
        //     in the Editor. Returns "UnityEngine.PropertyName" in the player.
        public override string ToString();

        public static bool operator ==(PropertyName lhs, PropertyName rhs);
        public static bool operator !=(PropertyName lhs, PropertyName rhs);

        public static implicit operator PropertyName(string name);
        public static implicit operator PropertyName(int id);
    }
}