# ================================================================ #
#                      Random
# ================================================================ #



# ---------------------------------------------- #
#             Random.state
# ---------------------------------------------- #
类型为 Random.State

它存储当前的 随机数状态, 内部是4个 float 值, 不过无法简单访问到它们;

但是 Random.state 是可序列化的, 所以可用 JSON 访问到它们:

# -- 读取 state 信息:
    string str = JsonUtility.ToJson( Random.state );

# -- 将 JSON 数据转换为 state 格式:
    Random.state = JsonUtility.FromJson<Random.State>( str );













