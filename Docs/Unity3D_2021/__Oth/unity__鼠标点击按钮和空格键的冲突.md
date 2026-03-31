







这是一个非常经典的 Unity UI (uGUI) 问题，

### 造成这个 BUG 的真正原因

这是 Unity **EventSystem (事件系统)** 的默认行为：

1.  当你用鼠标点击一个 UI 按钮时，Unity 会将这个按钮标记为 **"Selected" (已选中)** 状态（即获得了焦点）。
2.  Unity 的默认输入设置中，**Space (空格键)** 和 **Enter (回车键)** 被映射为 **"Submit" (提交)** 操作。
3.  当一个按钮处于 "Selected" 状态时，EventSystem 监测到 "Submit" 输入（也就是你按下空格键），它就会自动触发这个按钮的 `OnClick` 事件。

### 解决方案

这里有三种常用的解决方法，你可以根据你的游戏类型选择最合适的一种：

#### 方法 1：修改按钮的 Navigation 属性（推荐：最彻底）
如果你希望这个按钮**永远不要**响应键盘导航或被选中：

1.  在 Inspector 面板中选中你的 Button。
2.  找到 **Button** 组件下的 **Navigation** 属性。
3.  将其从 `Automatic`（默认）改为 **`None`**。

这样，点击按钮后它就不会保持选中状态，空格键也就不会触发它了。你可以通过多选所有按钮批量修改此设置。

#### 方法 2：全局代码取消选中（推荐：保留键盘导航但修复此行为）
如果你依然希望支持手柄或键盘导航 UI，但不想让鼠标点击残留焦点，可以在点击后立刻取消选中。

你可以写一个简单的通用脚本挂在所有按钮上，或者在你的 UI 管理器中统一处理：

```csharp
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeselectOnLastInput : MonoBehaviour
{
    // 方法：在点击后手动清除焦点
    public void OnButtonClick()
    {
        // 你的原有逻辑...
        
        // 清除当前选中的 UI 对象
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
```

或者，如果你想全局解决这个问题（当检测到鼠标点击时，取消所有 UI 焦点），可以在你的 `InputMgr.Update` 的末尾添加：

```csharp
// 在 InputMgr 的 Update 中
if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
{
    // 如果点击了鼠标，且当前有 UI 被选中，则取消选中
    // 注意：这需要引用 UnityEngine.EventSystems
    if (UnityEngine.EventSystems.EventSystem.current != null && 
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject != null)
    {
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }
}
```

#### 方法 3：修改 EventSystem 组件设置（简单粗暴：适用于纯鼠标游戏）
如果你的游戏完全是 PC 鼠标操作，不需要任何键盘/手柄选择 UI 的功能：

1.  在场景 Hierarchy 中找到 **EventSystem** 物体。
2.  在 Inspector 中找到 **Event System** 组件。
3.  取消勾选 **Send Navigation Events**。

或者在 **Standalone Input Module** 组件中，把 **Submit Button** 的名字（默认为 "Submit"）改掉或清空，或者去 Project Settings -> Input Manager 中把 Submit 对应的 Positive Button 里的 "space" 删掉。

---

### 总结
这个问题与你的 `InputMgr` 脚本无关，是 Unity UI 默认的导航机制导致的。最简单的修复方法是将按钮组件上的 **Navigation** 设置为 **None**。





# ============================================= #
#       目前我们做的
# ============================================= #

# -1- 直接把 project settings - imput manager 里 submit 绑定删除了
    有两组 submit, 先删除了 键盘相关的














