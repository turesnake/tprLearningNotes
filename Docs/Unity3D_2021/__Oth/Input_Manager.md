# ================================================================ #
#           project settings:
#           Input Manager 的使用
# ================================================================ #

# -------------- #
#   Name
每个 Axis 都有一个 name, 可自定义, 
可在脚本中访问:
    Input.GetAxis("Vertical Camera");

若此 axis 绑定为: key 或者 joystick, 获得的值:[-1f, 1f]
若此 axis 绑定为: 鼠标, 返回值可能超过此区间.

此值需要和 Time.deltaTime, Time.unscaledDeltaTime 配合使用



# -------------- #
#   Gravity
可让上一次输入的值, 自然 "下落" 为0,
若此值设为 0, 那么一次输入将永远有效 (效果类似于按着按钮不放)

推荐值设置: 3~9


# -------------- #
#   同时支持 鼠键 和 joystick
每个 Axis 只能应付一种 Type:
    -- Key or Mouse Button
    -- Mouse Movement
    -- Joystick Axis

所以,若想让某个名为 "Horizontal" 的axis 同时支持多种输入,
就要设置多份 Axis 实例, 一份给鼠键, 一份给 joystick, 类似这样



# -------------- #
#   Invert
有时 joystick 轴会翻转, 可勾选此项来修复








