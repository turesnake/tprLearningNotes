

#
#  手动生成一个 grid plane, 它的顶点一定是按顺序排列的;
# 
import bpy
import math
import sys
import bmesh
import mathutils


# time:
from datetime import datetime
timeNow = datetime.now()  # 获取当前本地时间

# ------------------------------ Log --------------------------------- #
# 使用示例：
# logger = BlenderLogger("MyLog")
# logger.Log("这是第一条日志信息")
# logger.Log("这是第二条日志信息")
# logger.ShowOutputFile()
class BlenderLogger:
    def __init__(self, log_name="LogOutput"):
        self.log_name = log_name
        # 如果已经存在同名文本块，先删除它
        if self.log_name in bpy.data.texts:
            bpy.data.texts.remove(bpy.data.texts[self.log_name])
        # 新建文本块
        self.text_block = bpy.data.texts.new(self.log_name)

    def Log(self, infoStr):
        """向日志文本追加内容"""
        self.text_block.write(infoStr + "\n")

    def ShowOutputFile(self):
        """在 Text Editor 界面显示日志文本"""
        for area in bpy.context.screen.areas:
            if area.type == 'TEXT_EDITOR':
                area.spaces.active.text = self.text_block
                break
# ---
logger = BlenderLogger()
# 下面直接调用这个来打印:
def print2(*args, sep=' '):
    msg = sep.join(str(arg) for arg in args)
    logger.Log(msg)


# 出现异常终止程序:
# raise Exception("终止")




# =================================================================== #
# 确保处于对象模式，方便编辑网格数据
#bpy.ops.object.mode_set(mode='OBJECT')


def create_ordered_grid_plane(size=10, verts_per_side=12):
    # 计算格点间距
    step = size / (verts_per_side - 1)
    half = size / 2

    # 创建一个新的 mesh 和对象
    mesh = bpy.data.meshes.new("OrderedGridPlane")
    obj = bpy.data.objects.new("OrderedGridPlane", mesh)
    bpy.context.collection.objects.link(obj)

    bm = bmesh.new()

    # 创建顶点，按顺序从左上角开始，逐行排列(x方向先)
    # 注意：y从高到低排列，x从左到右排列
    for row in range(verts_per_side):
        y = half - row * step
        for col in range(verts_per_side):
            x = -half + col * step
            bm.verts.new((x, y, 0))

    bm.verts.ensure_lookup_table()

    # 创建面（quad）
    for row in range(verts_per_side - 1):
        for col in range(verts_per_side - 1):
            v0 = bm.verts[row * verts_per_side + col]
            v1 = bm.verts[row * verts_per_side + col + 1]
            v2 = bm.verts[(row + 1) * verts_per_side + col + 1]
            v3 = bm.verts[(row + 1) * verts_per_side + col]
            bm.faces.new((v0, v1, v2, v3))

    bm.to_mesh(mesh)
    bm.free()

    # 选中并切换到这个新对象
    bpy.context.view_layer.objects.active = obj
    obj.select_set(True)

    return obj

# ===================
# 调用函数
plane = create_ordered_grid_plane( size = 2, verts_per_side = 160 )


print2(f"创建完成: 顶点数量 = {len(plane.data.vertices)}")
# 验证顶点顺序示例
print2("左上角第一个顶点坐标:", plane.data.vertices[0].co)
print2("第一行第二个顶点坐标:", plane.data.vertices[1].co)
print2("第二行第一个顶点坐标:", plane.data.vertices[12].co)


# ===================


# 显示 log 文件:
logger.ShowOutputFile()



