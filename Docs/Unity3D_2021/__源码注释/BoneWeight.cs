#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Describes 4 skinning bone weights that affect a vertex in a mesh.
[Serializable]
[UsedByNativeCode]
public struct BoneWeight : IEquatable<BoneWeight>
{


    [SerializeField]
    private float m_Weight0;

    [SerializeField]
    private float m_Weight1;

    [SerializeField]
    private float m_Weight2;

    [SerializeField]
    private float m_Weight3;



    [SerializeField]
    private int m_BoneIndex0;

    [SerializeField]
    private int m_BoneIndex1;

    [SerializeField]
    private int m_BoneIndex2;

    [SerializeField]
    private int m_BoneIndex3;


    //
    // Summary:
    //     Skinning weight for first bone.
    public float weight0
    {
        get
        {
            return m_Weight0;
        }
        set
        {
            m_Weight0 = value;
        }
    }
    //
    // Summary:
    //     Skinning weight for second bone.
    public float weight1
    {
        get
        {
            return m_Weight1;
        }
        set
        {
            m_Weight1 = value;
        }
    }
    //
    // Summary:
    //     Skinning weight for third bone.
    public float weight2
    {
        get
        {
            return m_Weight2;
        }
        set
        {
            m_Weight2 = value;
        }
    }
    //
    // Summary:
    //     Skinning weight for fourth bone.
    public float weight3
    {
        get
        {
            return m_Weight3;
        }
        set
        {
            m_Weight3 = value;
        }
    }


    //
    // Summary:
    //     Index of first bone.
    public int boneIndex0
    {
        get
        {
            return m_BoneIndex0;
        }
        set
        {
            m_BoneIndex0 = value;
        }
    }
    //
    // Summary:
    //     Index of second bone.
    public int boneIndex1
    {
        get
        {
            return m_BoneIndex1;
        }
        set
        {
            m_BoneIndex1 = value;
        }
    }
    //
    // Summary:
    //     Index of third bone.
    public int boneIndex2
    {
        get
        {
            return m_BoneIndex2;
        }
        set
        {
            m_BoneIndex2 = value;
        }
    }
    //
    // Summary:
    //     Index of fourth bone.
    public int boneIndex3
    {
        get
        {
            return m_BoneIndex3;
        }
        set
        {
            m_BoneIndex3 = value;
        }
    }



    public override int GetHashCode()
    {
        return boneIndex0.GetHashCode() ^ (boneIndex1.GetHashCode() << 2) ^ (boneIndex2.GetHashCode() >> 2) ^ (boneIndex3.GetHashCode() >> 1) ^ (weight0.GetHashCode() << 5) ^ (weight1.GetHashCode() << 4) ^ (weight2.GetHashCode() >> 4) ^ (weight3.GetHashCode() >> 3);
    }


    public override bool Equals(object other)
    {
        return other is BoneWeight && Equals((BoneWeight)other);
    }

    public bool Equals(BoneWeight other)
    {
        return boneIndex0.Equals(other.boneIndex0) && boneIndex1.Equals(other.boneIndex1) && boneIndex2.Equals(other.boneIndex2) && boneIndex3.Equals(other.boneIndex3) && new Vector4(weight0, weight1, weight2, weight3).Equals(new Vector4(other.weight0, other.weight1, other.weight2, other.weight3));
    }


    public static bool operator ==(BoneWeight lhs, BoneWeight rhs)
    {
        return lhs.boneIndex0 == rhs.boneIndex0 && lhs.boneIndex1 == rhs.boneIndex1 && lhs.boneIndex2 == rhs.boneIndex2 && lhs.boneIndex3 == rhs.boneIndex3 && new Vector4(lhs.weight0, lhs.weight1, lhs.weight2, lhs.weight3) == new Vector4(rhs.weight0, rhs.weight1, rhs.weight2, rhs.weight3);
    }


    public static bool operator !=(BoneWeight lhs, BoneWeight rhs)
    {
        return !(lhs == rhs);
    }
}
