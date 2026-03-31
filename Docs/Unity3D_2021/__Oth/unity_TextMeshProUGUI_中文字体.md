


TextMeshPro (TMP) 显示中文出现乱码（通常是显示为方块 `□` 或者完全不显示），最核心的原因是：

**TMP 默认自带的字体资源（LiberationSans SDF）只包含了英文字母和常用符号，不包含中文字符。**

你需要创建一个包含中文字符的 **Font Asset（字体资产）**。目前有两种主流的解决方式，推荐优先使用 **方案一**。

---

### 方案一：使用动态字体 (Dynamic SDF) ——【推荐，最简单】

从 Unity 2018/2019 版本开始，TMP 支持了动态字体。这意味着你不需要预先“烘焙”几千个汉字，Unity 会在运行时根据需要动态生成字符纹理。

**步骤：**

1.  **准备字体文件**：
    找一个支持中文的字体文件（`.ttf` 或 `.otf`），比如《思源黑体》(Source Han Sans) 或你自己喜欢的艺术字体，拖入 Unity 的 `Resources` 或任意文件夹中。
    *(注意版权：Windows 自带的微软雅黑通常**不能**商用，建议使用开源字体)*

2.  **创建 TMP 字体资产**：
    *   在 Project 窗口中，右键点击该字体文件。
    *   选择 `Create` -> `TextMeshPro` -> `Font Asset`。
    *   你会得到一个同名的 `.asset` 文件。

3.  **修改生成模式**：
    *   选中刚刚生成的 `.asset` 文件。
    *   在 Inspector 窗口中，找到 **Generation Settings**。
    *   将 **Atlas Population Mode** 修改为 **`Dynamic`**。
    *   (可选) 将 Sampling Point Size 设大一点（如 64 或 90），这样字迹更清晰。

4.  **应用**：
    *   将你的 `TextMeshProUGUI` 组件的 **Font Asset** 属性替换为你刚刚创建的这个新资产。
    *   中文应该就能正常显示了。

---

### 方案二：静态烘焙 (Static SDF) ——【高性能，适合特定需求】

如果你追求极致的渲染效果，或者需要使用极其特殊的艺术效果，可以使用传统的静态烘焙。这需要你把常用的 3500 或 7000 个汉字提前“画”在一张图集里。

**步骤：**

1.  **打开创建器**：点击菜单栏 `Window` -> `TextMeshPro` -> `Font Asset Creator`。
2.  **Source Font File**：拖入你的中文字体文件。
3.  **Atlas Resolution**：设为 `2048 x 2048` 或 `4096 x 4096`（中文很多，图集太小装不下）。
4.  **Character Set**：选择 `Custom Characters`。
5.  **Custom Character List**：
    你需要在这里填入**常用汉字表**。
    *   你可以去网上搜索“**常用汉字3500字.txt**”或“**TextMeshPro 常用中文字符集**”，复制里面的内容粘贴进去。
    *   或者直接使用 `Character Set` -> `Chinese Simplified Common` (如果你的 TMP 版本较新且自带此预设)。
6.  **点击 `Generate Font Atlas`**：
    等待生成。如果下面显示 "Missing Characters" 很多，说明图集分辨率不够大，或者你的原字体文件缺字。
7.  **保存**：点击 `Save`，然后按方案一的步骤 4 应用即可。

---

### 方案三：全局设置 (Global Fallback) ——【懒人必备】

如果你不想给每个 Text 组件都手动拖拽中文字体，可以设置一个“备胎”字体（Fallback）。

1.  按照**方案一**创建一个支持中文的 **Dynamic Font Asset**。
2.  找到 TMP 的全局配置文件：
    *   一般在 `Project Settings` -> `TextMesh Pro` -> `Settings`。
    *   或者在 `Assets/TextMesh Pro/Resources/TMP Settings`。
3.  在 Inspector 中找到 **Default Font Asset**（默认字体）。
4.  你可以直接把默认字体改成你的中文字体。
5.  **或者**（更好）：
    在下方的 **Fallback Font Assets** 列表中，点击 `+` 号，把你创建的中文字体加进去。
    *   **原理**：当 TMP 在主字体里找不到字（比如默认的英文SDF找不到“折纸”二字），它就会去 Fallback 列表里找。

### 总结

*   **正在开发、原型阶段、不确定要用什么字**：用 **方案一 (Dynamic)**。
*   **不想每个 Text 都去设置字体**：用 **方案三 (Fallback)**。
*   **确定了游戏文案、追求极高性能**：用 **方案二 (Static)**。