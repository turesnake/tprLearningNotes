# ============================================================= #
#         Animancer  使用
# ============================================================= #


# 初级教程:
https://zhuanlan.zhihu.com/p/419991890

https://zhuanlan.zhihu.com/p/419996306

https://zhuanlan.zhihu.com/p/420297843

https://zhuanlan.zhihu.com/p/420369771



# ----------------------- #
#    lua 上的使用
# ----------------------- #


    local animancer = KTool.GetComponent(self._catGo, NamedAnimancerComponentType)
    local animancerState = animancer:TryPlay("touch1", 1.5)
    if not isNull(animancerState) then
        CoYield(animancerState.Length)
        if isNotNull(animancer) then
            animancer:TryPlay("idle")
        end
    end


# --- 下面这个可行
    if not isNull(animancerState) then
        animancerState.Events:SetEndAction(function()
            animancerState.Events:SetEndAction(nil)
            if endCallBack then
                endCallBack()
            end
        end)
    end





