python-cocos2d-笔记


---
cocos2d 严重依赖 pyglet 模块。
	一部分的工作由pyglet完成了
	剩余的更加针对2d游戏的部分则由cocos2d来完成，

director 是一个类，也是一个单件
	director模块自动创建了一个 名为director的对象
	我们在项目调用时可以直接使用它。
	单件设计模式(singleton):
		要求类有且仅有一个实例，并且提供一个全局的访问点。


问题：
==== self.position = (150, 110)  为什么用小括号？
	(12,22) 这是tuple-元祖。类似list，但是一旦初始化就无法修改，
	position 的赋值，既可以是 list 也可以是 tuple

==== python 的类构造函数规则忘记了。


--- is_event_handler = True

By default a layer will not listen to events, his is_event_handler must be set to True before the layer enters the stage to enable the automatic registering as event handler.
默认情况下，layer不会监听系统事件。
在这个layer进入舞台之前，它的is_event_handler变量 必须被设置成True。
从而使得这个layer被自动注册为event handler(事件处理程序)

-------

Cocos obtains inputs by listening to director.window events, and conveniently cocos.layer can automatically listen to director.window events: in your layer subclass set the is_event_handler class member to True and cocos will take care.

cocos通过监听director的window events 来获得 输入。
方便的是，如果你的layer的is_event_handler被设置成True，你的layer可以自动监听director的window events。


---------

"""This function is called when a key is pressed.
    'key' is a constant indicating which key was pressed.
    'modifiers' is a bitwise or of several constants indicating which
        modifiers are active at the time of the press (ctrl, shift, capslock, etc.)
    """
当一个按键被按下时。这个功能被called
当一个按键被按下时， key是一个连续的 信号／指示
modifiers 是一个 按位（bitwise） 或是 数个连续信号：（这数个信号同时被按下。比如ctrl，shift，capslock，等）

Constants are the ones from pyglet.window.key

constants 源自  pyglet.window.key之一。

    def update_text(self):
        key_names = [pyglet.window.key.symbol_string (k) for k in self.keys_pressed]
        text = 'keys:' + ''.join(key_names)
        self.text.element.text = text

key_names = [pyglet.window.key.symbol_string (k) for k in self.keys_pressed]
这句话的意思是，从 keys_pressed 这个list中 逐个提取元素赋值给k
然后将k作为参数 传入 函数：pyglet.window.key.symbol_string（）
获得的结果 再作为元素， 保存在一个新的 list中
这个list 取名 key_names

pyglet.window.key.symbol_string() 函数的作用是

symbol_string() 传入一个 int。 对应某按键的 键值
返回 此键值 对应的 string显示。也就是按键的名字。

如果我们去掉这个函数，窗口显示的将是 纯粹的 int键值
正确，

现在的问题是，这个传入 keys_pressed 列表 的 int键值 到底是怎么来的。

当我们改写 on_key_release 函数的名字时。 这个函数失效。

说明这个函数  

我们的key类只用来捕捉键盘事件，一旦捕捉成功，将把事件保存在

self.keys_pressed = set()
这里的 set() 是在创建一个 python内置的类型 “集合”。

a = set([1,2,3])

--------------
关于cocos  键盘事件的  追溯
-- 我们在一个layer的子类中，打开 is_event_handler = True
	后自动获得 鼠标事件的监听能力

-- 但是python没有魔法啊，这个 on_key_press 函数为什么需要限定这个名字
	又为什么只要是这个名字就能自动获得键盘事件呢？

--因为我们通过此类生产了一个图层对象，然后又用这个图层对象生产了一个scene对象
	这个scene对象后来被导入  director对象的 run函数中，
	所以，on_ke_press函数 就一定是在 run函数内被调用的了。

	与这个推测相呼应的是。在Layer的源码中，定义了一旦is_event_handler = True
	在 on_enter 和 on_exit 函数中，
	director.window.push_handlers(self) 和
	director.window.remove_handlers(self) 函数就会被点用

-- 我们于是找到director里，
	在director里，既没有window，也没有后面两个函数的定义，但是出现过push_handlers
	函数的使用，
	推测在director的父类：event.EventDispatcher中
	显示是并不存在这么个类或者文件

	但是我们在pyglet 的 keyboard 的教程中获得一点信息：
	

-----------
cocos 中的键盘事件：
- 首先将自己的类继承layer
- 其次is_event_handler = True
- 然后在这个类中，按如下格式创建两个名为 on_ke_press 和 on_ke_release 的方法
	这两个方法的 参数是统一的(self,key,modifiers) 其中 self 是类方法的必备参数
	key 就是我们从系统中截获的 按键映射的int值。
	这个int值可以通过：pyglet.window.key.symbol_string(key) 来转换成 
	易读的string类型的的值，比如按键A／a， int值为 97，转换后输出 “A”

	第三个参数 modifiers 则是 组合键，比如 shift这种。

在其他系统中，我们的输入是放在一处统一管理的
而在cocos／pyglet 系统中，交互被打散了。可以灵活地放进各种自定义layer类中。
唯一的限制就是：
	- 这个自定义的layer类 需要设置is_event_handler = True
	- 在这个类中写入两个符合参数格式的 名为 on_ke_press 和 on_ke_release 的方法。

------------
cocos 中的鼠标事件：
鼠标事件函数有3个。
def on_mouse_motion(self, x, y, dx, dy):
	pass
def on_mouse_drag(self, x, y, dx, dy, buttons, modifiers):
	pass
def on_mouse_press(self, x, y, buttons, modifiers):
	pass
def on_mouse_release(x, y, button, modifiers):
	pass

现阶段的 鼠标事件将不做重点介绍，由于键盘已经能够完成非常多的交互功能。我们先以键盘开刀。

---------------------------------------------------
director  对 scene的 管理

看一下 director 类的官方介绍：
-- director.replace( new_scene ) 
		将当前运行场景 切换为 new_scene
		被换下来的 旧场景 将被终结


-- director.push( new_scene )
		当前运行的场景 将被压入 “运行中的场景队列”
		一个新的 场景 new_scene 将被 执行

-- 	director.pop()
		将从队列提取出最上层的场景（运行中），它将会替代当前的场景。

-- director.scene.end( end_value )
		将当前运行场景关闭。以关闭参数：end_value
		并从 “运行中的场景队列” 中提取出一个场景

-------

-- director.get_window_size()
		返回窗口的长宽值，以pair形式(x,y)
		这个值时窗口被创建时的初始值。就算之后窗口被拉伸。这个值也不变
		如果你需要当前物理值，可以查看 director.window 的尺寸

-- get_virtual_coordinates(self, x, y)
		改变对象坐标， 返回一个坐标点对，没太看明白

-- director.return_value
		最后一个场景，名为director.scene.end，返回的值。
		没看懂。，，。

-- director.window
		一个 pyglet 的窗口，由 director 管理
		可以获得更底层的信息

-- self.show_FPS
		将其设置为 bool值，用来开关 帧数显示。

-- self.scene
		当前运行的场景。

----------------------------------------------------------------
看下 director 类的 源码：

-- def init(self, *args, **kwargs):

-- def set_show_FPS(self, value):

-- def run(self, scene):
		运行一个场景，进入 director 的主循环 main loop
		参数： scene --被运行的场景


-- def set_recorder(self, framerate, template="frame-%d.png", duration=None)
		会重置app时钟，以便我们可以 确保一个稳定的帧速率，
		同时每一帧保存一张图表 image
		参数： framerate --int， 每秒帧数
			  template --str， 将被完善的文件的模版
			  duration -- float, 待记录的时长，0时为无限

-- def on_draw(self)
		从 pyglet.window.Window 处获得的 
		...


-- def push(self, scene):

-- def on_push(self, scene):

-- def pop(self):

-- def on_pop(self):

-- def replace(self, scene):

-- def _set_scene(self, scene):
		。。。

-- def get_window_size(self):

-- def get_virtual_coordinates(self, x, y):

-- def scaled_resize_window(self, width, height):

-- def unscaled_resize_window(self, width, height):

-- def set_projection(self):

-- def set_projection3D(self):

-- def set_projection2D(self):

-- def set_alpha_blending(self, on=True):

-- def set_depth_test(self, on=True):

-------------------------------------------------------------
一个完善的 键盘系统应该支持组合键，
pyglet中是如何判定组合键的呢？

一种静态的思维是：设置一个有限的键值表，比如规定只有按wasd四个键时软件才作出反应，其余的按键事件都被过滤掉，
此外，wasd键也将允许同时按下。从而实现组合键。

-- 可以在类中设置一个键值存放表，每个按键一个布尔值，

如果是方向键冲突，则应该按最先被监测到的那个键为确认键。且屏蔽掉后来按下的键
直到这个方向键被释放为止。

让我们更为深入地思考一下交互这件事：
外部输入通常只能控制hero的行动。
还有主界面／菜单的切换，其余的部分都不会涉及到交互。

===== 在马里奥系统中，====
只有4个键： 左，右，跳，界面切换。

这4个键存在优先级：
	优先级最高的是 界面切换，当同时按下数个键。其中存在界面切换时，优先界面切换，

	然后，跳键 和 方向键是可以并存的。

	方向键是唯一的。非左即右。

如何实现方向键的唯一性:
组合键永远是逐个按下的。假设有3个键同时按下，那么就会调用 update函数3次。

update 函数最先检查的永远是 优先级最高的系统键。一旦出现系统键，就会跳出整个事务。
此时的 keysss可能存在残留的按键没有清除，建议此时做一次清空，

如果不存在 系统键，那么开始做方向键的监测：
有如下情况：
-- 按下左键， 之后又按下右键。

-- 当两键都为按下时。其中一个键松开。

我们的系统如何判断：--当两键都为按下时。其中一个键松开--这种情况呢？

要知道，我们的update内是通过 检查 keysss 的状况来触发事件的。
我们可以在release函数尾部也启动update函数。

现在，当数个按键同时按下，且其中一个松开时。update函数也被调用。

update函数时被 数字式调用的，也就是说，当某次update函数被调用时，按键的状态是静态的：
假设左右键分别被按下，
则会出现：
左
左，右
两次调用。

第一个if句：
左 | 右，任意一个被按下时，进入方向键环节：

当只存在一个方向时，启用这个方向
当两个方向都存在时，不做任何改动（因为方向肯定时被逐个触发的，所以2者同存时意味着之前已经设置过一次方向了。）

其实只要两个if句： 
当左on右off。选左
当右on左off，选右。

（隐含的是：当左on右on，什么都不做
		   当左off右off，也什么都不做）
----------------
成功

--------------------------------
如何对一个sprite进行持续的影响？

我们希望： 当按下一个方向键，物体会按帧率持续移动。

先来看看cocos的无限循环动画是如何实现的。

可以实现移动。。
然而不是逐帧的。
虽然cocos的这种思路十分的节省资源。
然而现在问题来了。。。当我们按下一个按键时，如何让物体持续地移动。

-------------------

花点时间看了一下 pyglet 里的 clock部分的内容。

需要看的还有:
	event_loop, 
	pyglet.app.event_loop.run()
	EventLoop 类
	












































//---end---