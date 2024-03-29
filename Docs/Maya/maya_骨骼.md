# ================================================================ #
#                      maya 骨骼
# ================================================================ #


# ------------------------------------- #
#        防止骨骼被遮挡:
#        开启 x射线显示关节:
在视图界面内部, 中上方, 有个按钮, (是个方框,内测有一个骨骼)
名字为 "x射线显示关节", 点亮它即可;



# ------------------------------------- #
#        让物体不可被选中
#        以免影响对骨骼的编辑
全选物体, 右下角 "层" - "从选定对象创建层"
然后在层的 左侧三个按钮中, 将第三个按钮设置为 "R", 冻结这个层的编辑



# ------------------------------------- #
#        创建骨骼
进入 "绑定"模式, "骨骼" - "创建骨骼",
然后在 视图界面 中点击, 每点击一次, 就创建一节 骨骼;

#    中途为某个骨骼创建 子骨骼
在 视图大纲 中选择起始骨骼, 此时这节骨骼以及它的所有子骨骼 都会点亮;
然后在 视图界面 中点击一下, 就能创建它的新骨骼;

#  删除一节骨骼
点击 del / 回车, 可以删除上一次创建的关节;
如果想要删除一个中间位置的关节, 
    选中这个关节, 然后 "骨架" - "移除关节"
    此时会发现 目标节点不见了,它的上下游连接到了一起;



# 调节骨骼 显示尺寸
-1-:
    在 视图大纲 中选择所有要修改的骨骼, 
    到右侧寻找 "通道盒/层编辑器" 面板, 修改 "半径" 值;
-2-:
    "显示" - "动画" - "关节大小", 修改这个值, 能控制所有骨骼尺寸;
    而且这个修改是在 方法-1- 的基础上实施的, 做整体性的缩放;
    (不会把所有骨头改得一样粗细)


# ------------------------------------- #
#        如何选中一节骨骼
有时候会发现 选择工具无法选中 骨骼,
此时,启用选择工具, 然后在 maya 大窗口左上方, 选中: "按对象类型选择"
(快捷键 F8, 可在两个模式中切换)
然后就能选了;



#  绑定骨骼 父子连接:
先选 子骨骼, 再选 父骨骼, 单按 P 键;
("编辑" - "建立父对象")


#  断开骨骼 父子连接:
单选 子骨骼, shift + P, 断了连接;
("编辑" - "断开父对象")


# ------------------------------------- #
#      显示/修正 所有骨骼的 轴向

#  如何显示一组骨骼的 轴向:
-1-
    在 大纲视图中, 选择一组骨骼的所有节点, 
    (也可以选择主的 根部 父骨骼, 右键选择 "选择层级别")
-2-
    "显示" - "变换显示" - "局部旋转轴"

此时就能看到, 每个骨头节点, 都显示了自己的 旋转轴
(哪怕你没有选中这些骨头)

# 统一一组骨骼的所有骨头的 轴向
-1-:
    选择所有骨头节点,(用上述方法)
    然后打开 "骨架" - "确定关节方向" 面板;
    设置:
        主轴 x
        次轴 z
        次轴世界方向 x
    然后点击 应用;

    此时, 除了 最尾端骨骼节点之外, 剩余所有节点 都正确了;
-2-:
    修改 最尾端骨骼节点:
    选择这个节点;
    打开右侧的 "属性编辑器"
    将 "关节" - "关节方向" 中的那些不为0 的值, 都改为 0;



# ------------------------------------- #
#    让一串骨骼, 像尾巴一样卷曲运动
从尾端开始, 按住 shift 逐个选择, 直到最后选中 根关节;
然后用 旋转工具去选择 即可;



# ------------------------------------- #
#    骨骼 的层次命名
一组骨骼, 全部选中 (和在 大纲视图中), 然后 "修改" - "添加层次命名前缀";
可以统一添加名字的 前缀;
































