
# ----------------------- #
# O4-mini:

在 Blender 和 Unity 之间来回交换 FBX 文件时，要特别注意以下几方面的配置，才能尽量避免模型“跑偏”、动画丢失、法线翻转等常见问题。

# 单位与缩放（Unit & Scale）

    Blender 中默认「单位制(Unit Scale)」是米（Meter）。
    FBX 导出面板里：
    Scale = 1.0
    Apply Unit = 勾选（确保 Blender 米制自动转换成 FBX 单位）
    Unity 中 FBX Import Settings：
    Scale Factor = 1
    如果遇到导入后模型过大或过小，可在这里微调，不要在 Blender 侧改动非 1.0 的缩放。


# 坐标轴（Axis）

    Blender 坐标：Z 向上，Y 向后
    Unity 坐标：Y 向上，Z 向前

    FBX 导出时（Blender）―
    Forward = “-Z Forward”
    Up = “Y Up”
    勾选 “Apply Transform”
    这样在 Unity 打开时，模型朝向和轴向就可以一一对应。

# 版本与目标（FBX Version）

    推荐使用 FBX 7.4 binary（也标为 FBX 2014/2015）。
    老版本可能有兼容性问题（部分属性丢失或语义不同）。

# 应用变换（Apply Transform）

    勾选后， Blender 会把物体的旋转／缩放「烘焙」到顶点数据，导出的 FBX 顶点就直接带上正确的变换，Unity 里看不到“Scale ≠ 1/Rotation ≠ 0” 的红警。

# 法线与切线（Normals & Tangents）

    导出面板里：
    Normals = “Export Normals” 或 “Auto Smooth”
    Tangents = “Export Tangents”（如果你的材质用法线贴图）
    
    在 Unity Import Settings：
    Normals = “Import” 或 “Calculate”—看你是否希望 Unity 重新计算法线
    Tangents = “Import”

# 动画（Animations）

    如果有骨骼动画，导出面板里：
    Bake Animation = 勾选
    Sampling Rate = 你的帧率（如 30 或 60）
    Key All Bones = 勾选（避免缺关键帧）
    NLA Strips / All Actions 根据你需求选择
    Unity 中：
    Rig Type 设为 Generic / Humanoid（若用 Mecanim）
    Import Constraints、Events、Curves…根据需要酌情开启

# 层级与命名（Hierarchy & Naming）

    保持 Blender 里 Object、Armature、Mesh、Bones 等节点名称简单且唯一。
    Unity 会根据层级生成 Prefab，如果名字重复或路径冲突会出问题。

# 材质与纹理（Materials & Textures）

    FBX 本身不直接携带 PBR 材质，只能嵌入贴图路径及基本属性。
    推荐：
    在 Blender 中把贴图都打包到同一路径（相对路径或同文件夹）。
    导出时勾“Include” → “Textures”
    Unity 导入后，需要手动把纹理拖进 Standard Shader 的对应插槽。

# 骨骼权重（Skin Weights）

    FBX 导出：
    Limit to 4 Bones per Vertex（Unity 默认只支持前四最大影响骨骼）
    Blender 顶点组 → 骨骼权重时，别超出 4 个影响。

# 最佳实践与排查

    每次改模型几何后重新「Apply All Transforms」（Ctrl+A → Location/Rotation/Scale）。
    导出前，用 Blender 视图检查：位置 (0,0,0)、缩放 1、旋转 0。
    在 Unity 中先做一次空场景测试，确认 Mesh、UV、动画正常后再集成到主工程。

# 总结：
    • 在 Blender 侧统一用真实世界单位，应用所有变换，导出面板里 Forward/Up、Apply Transform、Bake Animation、Normals/Tangents 等选项都要对齐 Unity 的需求；
    • 在 Unity 侧保持 Import Settings 和 Blender 导出设置一一对应（Scale Factor 1、Normals/Tangents Import、Rig Type、Material Setting…），避免二次转换。

这样，你在两者间来回导入导出时，就能最大程度保持模型、动画和材质的准确度。
































