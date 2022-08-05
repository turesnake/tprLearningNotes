# ================================================================ #
#                       ScriptableObject
# ================================================================ #

一个 ScriptableObject 是个数据容器, 可用来存储大量数据, 它独立于 class实例. 
一个主要用途是: 通过避免数值的复制 来减少项目的存储使用.

如果你的项目拥有一个 prefab, 它有一些不需要改变的数据时, 这些数据可以不用写在 绑定的 monobehaviour 脚本中, 因为当这个 prefab 被实例化时, 这些 脚本中的数据都会被复制一份, 从而造成大量数据的重复.  我们可将这些固定数据 放到一个 ScriptableObject 中, 然后所有 prefab 的实例们, 都共享这同一份数据. 

和 MonoBehaviours 一样, ScriptableObject 也继承自基础的 Unity object,
但和 MonoBehaviours 不同的是, ScriptableObject 无法被绑定到 gameobj 上, 
你需要在项目中, 将 ScriptableObject 存储为一个单独的 Asset;

在 editor 阶段, 你可在 editor状态, 或 运行时状态中, 将数据存储进 ScriptableObject 中,因为 ScriptableObject 使用 Editor namespace and Editor scripting; 

但在生成好的 build 阶段, 你无法使用 ScriptableObject 存储数据, 但你可使用 ScriptableObject asset 中已经存储好的数据. 这些数据是你在 开发阶段 存进去的.
( ---?--- )

通过 editor工具 写入 ScriptableObject asset 的数据, 会被存储在硬盘上, 它可在 sessions 中间长期存在. 

# ----------------------- #
# Using a ScriptableObject

ScriptableObject 的主要使用方式有:
-- 在 editor 阶段 存储数据
-- 将数据存储为 项目中的 asset, 并在 运行时使用它们; 

# ==:
-1-
    新建一个 class, 让它继承 ScriptableObject, 
-2-
    使用 [CreateAssetMenu] 来表面它可从 Asset 菜单栏创建,
    如:    
    [CreateAssetMenu(fileName = "Data", menuName = "Tpr/AA", order = 1)]
-3-
    然后去菜单栏中, 依靠按钮 真的创建一个 asset
-4-
    在别的 monobehaviour 脚本中, 获得这个 asset 的引用:
    public ShapeFactory shapeFactory;
    (此时需要在 editor 中手动绑定这个引用)
    然后就能使用这个 asset 中的数据了




 
# ============================== #
#   [System.NonSerialized]
# ------------------------------ #

那些没有被标注为 serialized 的 scriptable object 的 private字段, unity 是不会 存储它们的;
然后, scriptable object 本身, 可在单个 editor session 内的多段 play sessions 之间长期存在;
只要 editor 窗口持续存在,  private 字段的值也持续存在; 但在你下次启动 editor 时被重置;

所以, 当我们在 editor 中复制旧的 scriptable object 实例, 生成新的 实例时, 上述机制会引发一些麻烦,
所以最好明确这些 scriptable object 的 private字段 绝对不 "persists".

所以要把这些 private字段, 设置为 [System.NonSerialized]

当然这也意味着, 当 editor 中出现重编译, 这些值也会被重置



# ============================== #
#   ScriptableObject.CreateInstance(...)
# ------------------------------ #
    static ScriptableObject CreateInstance(string className);
    static ScriptableObject CreateInstance(Type type);

    static T CreateInstance<T>() where T : ScriptableObject;

在代码中新建一个 ScriptableObject 的实例





