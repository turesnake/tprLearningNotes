#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using UnityEngine.Scripting;

namespace UnityEngine;



//
// Summary:
//     Describes a bone weight that affects a vertex in a mesh.
[Serializable]
[UsedByNativeCode]
public struct BoneWeight1 : IEquatable<BoneWeight1>
{
    [SerializeField]
    private float m_Weight;

    [SerializeField]
    private int m_BoneIndex;

    //
    // Summary:
    //     Skinning weight for bone.
    public float weight
    {
        get
        {
            return m_Weight;
        }
        set
        {
            m_Weight = value;
        }
    }

    //
    // Summary:
    //     Index of bone.
    public int boneIndex
    {
        get
        {
            return m_BoneIndex;
        }
        set
        {
            m_BoneIndex = value;
        }
    }

    public override bool Equals(object other)
    {
        return other is BoneWeight1 && Equals((BoneWeight1)other);
    }

    public bool Equals(BoneWeight1 other)
    {
        return boneIndex.Equals(other.boneIndex) && weight.Equals(other.weight);
    }

    public override int GetHashCode()
    {
        return boneIndex.GetHashCode() ^ weight.GetHashCode();
    }

    public static bool operator ==(BoneWeight1 lhs, BoneWeight1 rhs)
    {
        return lhs.boneIndex == rhs.boneIndex && lhs.weight == rhs.weight;
    }

    public static bool operator !=(BoneWeight1 lhs, BoneWeight1 rhs)
    {
        return !(lhs == rhs);
    }
}
