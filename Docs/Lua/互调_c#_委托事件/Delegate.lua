print('启动了Lua')

function init()
	print("执行了Lua的全局方法init")--无参数的方法
	CreatUnityObj()
end

function CreatUnityObj()
	local delegate_TPR= CS.Delegate_TPR()
	--单独增加一个委托并且，回调了funCallBack方法
	delegate_TPR:AddAction(funCallBack)
	

    -- lua 调用 c# 的委托
	local actionString10 = delegate_TPR.actionString10
	actionString10('Lua输入了actionString10')

	actionString10 = actionString10 + delegate_TPR.actionString11 + delegate_TPR.actionString12
	actionString10('Lua调用了委托链')
	
	actionString10 = actionString10 - delegate_TPR.actionString11
	actionString10('Lua删除了一个委托链中的11')
end


function funCallBack(arg)
	print('funCallBack:',arg)
end


