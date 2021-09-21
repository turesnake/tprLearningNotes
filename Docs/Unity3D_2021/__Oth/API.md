
# 一些和 unity api 相关的 零碎用法


# ----------------------------------------------#
#          
# ----------------------------------------------#


# ---------------------------------------------- #
#       Vector2.ClampMagnitude
#       Vector3.ClampMagnitude
# ---------------------------------------------- #
static Vector2 ClampMagnitude(Vector2 vector, float maxLength);
static Vector3 ClampMagnitude(Vector3 vector, float maxLength);

复制参数 vector, 对copy版的 模长做 clamp, 使其不超过 maxLength;
模长小于此值时, copy值不变
返回 copy值 (原参数 vector 不受影响)



# ----------------------------------------------#
#           Debug.Assert
# ----------------------------------------------#
# release mode 中 assert 语句会被自动删除


void Assert(
    bool condition, // 判断条件, 为 false 时触发报错
    string message, // string
     Object context // 可传入 某个 obj, unity 会打印出来
);

类似的还有:

    void Assert(bool condition);
    void Assert(bool condition, string message);
    void Assert(bool condition, Object context);






