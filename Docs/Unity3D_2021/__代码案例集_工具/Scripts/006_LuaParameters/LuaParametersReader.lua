
---@class LuaParametersReader
local LuaParametersReader = Class('LuaParametersReader')

-- ========================================================

-- 方便地读取 c# LuaParameters 中的数据

---:
local Object = CS.UnityEngine.Object
local GameObject = CS.UnityEngine.GameObject
local Transform = CS.UnityEngine.Transform
local Quaternion = CS.UnityEngine.Quaternion


local Vector2 = CS.UnityEngine.Vector2
local Vector3 = CS.UnityEngine.Vector3
local Vector4 = CS.UnityEngine.Vector4
local Color = CS.UnityEngine.Color



local LuaParameters = CS.LuaParameters


-- =========================================== Static Functions ================================================ --

-- 一次读取一个 parameter:

---@return 数种类型之一: String, Int, Float, Vector2, Vector3, Vector4, Color
---@param comp_ Engine.Modules.LuaParameters
---@param key_ string 
function LuaParametersReader.ReadValue( comp_, key_ )
    assert( not isNull(comp_) )
    assert( (type(key_) == "string") and (#key_ > 0) )

    assert( not isNull( comp_.keyValueList) )
    local len = comp_.keyValueList.Count
    assert( len > 0 )

    local ret = nil
    for i=0, len-1 do
        local p = comp_.keyValueList[i] -- List
        if (not isNull(p)) and (p.key == key_) then 

            if      p.valueType == vType.String then 
                ret = p.stringValue

            elseif p.valueType == vType.Int  then
                ret = p.intValue

            elseif p.valueType == vType.Float  then
                ret = p.vector4Value.x

            elseif p.valueType == vType.Vector2  then
                ret = Vector2( p.vector4Value.x, p.vector4Value.y )

            elseif p.valueType == vType.Vector3  then
                ret = Vector3( p.vector4Value.x, p.vector4Value.y, p.vector4Value.z )

            elseif p.valueType == vType.Vector4  then
                ret = p.vector4Value

            elseif p.valueType == vType.Color  then
                ret = p:GetColorValue()
            else 
                assert( "没找到目标类型, 请检查代码" )
            end
            break
        end
    end
    assert( not isNull(ret) )
    return ret
end



return LuaParametersReader

