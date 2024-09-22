using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// 将 unity inspector 中的参数从 c# 端传递到 lua端;
/// 在 Lua 端可直接用 LuaParametersReader.ReadValue() 来读取本实例体内的数据;
/// </summary>
public class LuaParameters : MonoBehaviour
{

    public enum Type 
    {
        String, Int, Float, Vector2, Vector3, Vector4, Color
    }

    [System.Serializable]
    public class Pair 
    {
        public string   key;
        public Type     valueType;
        public string   stringValue;
        public int      intValue;
        public Vector4  vector4Value; // 兼容 float, Vector2, Vector3, Vector4, Color(HDR)

        public Pair()
        {
            key = "";
            valueType = Type.String;
            ClearValues();
        }

        public Pair( Pair old_ ) 
        {
            key = old_.key;
            valueType = old_.valueType;
            stringValue = old_.stringValue;
            intValue = old_.intValue;
            vector4Value = old_.vector4Value;
        }

        public void ClearValues() 
        {
            stringValue = "";
            intValue = 0;
            vector4Value = Vector4.zero;
        }


        public static bool IsEqual( Pair a, Pair b )
        {
            return      a.key == b.key 
                    &&  a.valueType == b.valueType 
                    &&  a.stringValue == b.stringValue
                    &&  a.intValue == b.intValue 
                    &&  a.vector4Value == b.vector4Value;
        }


        // 弥补 lua 中不方便隐式类型转换的问题
        // 但其实 Color.rgba 和 Vector4.xyzw 是完全等值的, 直接在 lua 中硬设置也没问题...
        public Color GetColorValue() 
        {
            Debug.Assert( valueType == Type.Color );
            Color ret = vector4Value;
            return ret;
        }
    }

    public List<Pair> keyValueList = new List<Pair>();

}



