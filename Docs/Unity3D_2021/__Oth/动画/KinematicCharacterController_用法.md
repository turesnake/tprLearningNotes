# =================================================================== #
#          KinematicCharacterController 用法
# =================================================================== #


# 官方文档:
https://docs.google.com/document/d/1sdWOHE6vJcsOLE2jxHLVs_Y170NT309C4DbPmmdmqAM/edit?pli=1#heading=h.71hwyqucpo32





# =================================================================== #
#                         执行时序
# =================================================================== #

# KinematicCharacterSystem 的 Execution Order 为 90

# cinemachine brain 的 Execution Order 为 100

如果想让 角色跟随点的位移 写在 K控制器 之后, vcam brain 的 lateupdate 之前

就需要是现在 90 之后的 update 中;

# 否则就会造成卡顿




















