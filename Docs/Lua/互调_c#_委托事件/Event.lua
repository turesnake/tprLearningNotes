


print('启动了Lua')


function init()
	print("执行了Lua的全局方法init")--无参数的方法
	CreatUnityObj()
end


function CreatUnityObj()

	local event_TPR = CS.Event_TPR()
	
	--添加和移除事件的时候应该使用以下的方式
	--object:event("+", delegate)
	--object:event("-", delegate)
	event_TPR:Events("+",event_TPR.action1)
	event_TPR:Events("+",event_TPR.action2)
	event_TPR:Events("+",luaFunction)
	
	
	--注意在Lua中不能通过以下方式来触发事件: eventClass:Events()
	--触发事件
	event_TPR:TriggerEvent()
end



function luaFunction()
	print('我是Lua中的方法')
end


