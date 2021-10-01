

# -------------------------------------- #
#          gameobj 复制 销毁
# -------------------------------------- #



# 新建, 复制:
T obj = Instantiate( t );
    ---
    此处的 T 可以是 gameobj/perfab 的 Transform 或任何类型,
    返回类型也一致.

# 销毁:
Destroy( object );
Destroy( transform.gameObject );
    ---
    如果传入的是 组件, 务必搞到它的 gameObject
    否则, 此函数只会销毁这个 组件本身, 而不是它的 gameobj










