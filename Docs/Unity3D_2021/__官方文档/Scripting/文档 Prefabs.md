# =========================================================//
#             Instantiating Prefabs at run time
# =========================================================//

... 

# ================================= #
# Instantiating Prefabs at run time

想要在运行时 实例化一个 prefab, 你的代码需要这个 prefab 的引用.
可在代码中新建一个 public 变量, 持有这个prefab reference. 

# 方法一: 外部手动绑定:
一种办法是将这个 prefab reference. 设置为 public 或 [SerializeField], 然后在 inspector 中手动为其绑定 prefab;
比如:
# ==
    [SerializeField]
    GameObject myPrefab;
# --

然后执行:
    var newOne = Object.Instantiate( myPrefab );




... 之后也没介绍第二种方法 ...




















