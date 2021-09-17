
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




