#   
#   一个边长为 sideNum 的 grid mesh, 平铺在 xy 平面上, 每个顶点只有 z值上下浮动
#   造出一张 地形图;
#
#    本脚本修改这个 mesh 四周顶点的 z 值, 使得它变成 四方连续的
#
import bpy
import math
import sys

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



# ============================= 正文 函数 ======================================

def IntSqrt(num):
    if not isinstance(num, int):
        raise TypeError("输入必须是整数类型")
    if num < 0:
        raise ValueError("输入不能是负数")
    root = math.isqrt(num)  # Python 3.8+ 计算整数平方根
    if root * root != num:  # 判断是否是完全平方数
        raise ValueError(f"{num} 不是完全平方数，平方根不是整数")
    return root


def lerp(a, b, t):
    return a + (b - a) * t

 
def remap(old_min, old_max, new_min, new_max, value):
    # 先归一化 value 到 0~1 之间
    normalized = (value - old_min) / (old_max - old_min)
    # 再映射到新的区间
    return new_min + normalized * (new_max - new_min)


def clamp(x, min_val, max_val):
    return max(min_val, min(x, max_val))

def smoothstep(edge0, edge1, x):
    # 归一化 x 到 [0, 1]
    t = clamp((x - edge0) / (edge1 - edge0), 0.0, 1.0)
    # 计算 smoothstep
    return t * t * (3.0 - 2.0 * t)



# ===================================================================

# 选中的物体
tgtObj = bpy.context.object
tgtObj.location = (0, 0, 0) # 选中物体 pos 归零




# 确保处于对象模式，方便编辑网格数据
bpy.ops.object.mode_set(mode='OBJECT')

# 获取物体的网格数据
mesh = tgtObj.data

vertexNum = len(mesh.vertices)
sideNum = IntSqrt(vertexNum)


print2("顶点总数 = ",  vertexNum, "; 边长顶点数 = ", sideNum)



     
def ContinueInY2():

    for i in range(sideNum):
        idxA1 = 0           * sideNum + i
        idxB1 = (sideNum-1) * sideNum + i
        vtA1 = mesh.vertices[idxA1]
        vtB1 = mesh.vertices[idxB1]
        #
        diff = abs(vtA1.co.z - vtB1.co.z)
        step = int(remap( 0.0, 0.7, 1, 0.1*sideNum, diff )) # 需要柔和的格子数

        # 确定两端
        idxAT = (0 + step) * sideNum + i
        idxBT = (sideNum-1 - step) * sideNum + i
        vtAT = mesh.vertices[idxAT]
        vtBT = mesh.vertices[idxBT]
        #totalLen =  abs(vtAT.co.x - vtBT.co.x) + abs(vtAT.co.y - vtBT.co.y)
        newMid = (vtAT.co.z + vtBT.co.z) * 0.5
        #
        for q in range(step): # [0, N-1]
            idx = (0 + q) * sideNum + i
            vt = mesh.vertices[idx]
            #tLen = abs( (vtAT.co.x - vt.co.x) + (vtAT.co.y - vt.co.y) )
            t = q/step
            t = t * t
            vt.co.z = lerp( newMid, vt.co.z, t)
        for q in range(step): # [0, N-1]
            idx = (sideNum-1 - q) * sideNum + i
            vt = mesh.vertices[idx]
            #tLen = abs(vtAT.co.x - vt.co.x) + abs(vtAT.co.y - vt.co.y)
            t = q/step
            t = t * t
            vt.co.z = lerp( newMid, vt.co.z, t)



def ContinueInX2():

    for i in range(sideNum):
        idxA1 = i * sideNum + 0
        idxB1 = i * sideNum + (sideNum-1)
        vtA1 = mesh.vertices[idxA1]
        vtB1 = mesh.vertices[idxB1]
        #
        diff = abs(vtA1.co.z - vtB1.co.z)
        step = int(remap( 0.0, 0.7, 1, 0.1*sideNum, diff )) # 需要柔和的格子数

        # 确定两端
        idxAT = i * sideNum + (0 + step)
        idxBT = i * sideNum + (sideNum-1 - step)
        vtAT = mesh.vertices[idxAT]
        vtBT = mesh.vertices[idxBT]

        newMid = (vtAT.co.z + vtBT.co.z) * 0.5
        #
        for q in range(step): # [0, N-1]
            idx = i * sideNum + 0 + q
            vt = mesh.vertices[idx]
            #tLen = abs( (vtAT.co.x - vt.co.x) + (vtAT.co.y - vt.co.y) )
            t = q/step
            t = t * t
            vt.co.z = lerp( newMid, vt.co.z, t)
        for q in range(step): # [0, N-1]
            idx = i * sideNum + (sideNum-1 - q)
            vt = mesh.vertices[idx]
            #tLen = abs(vtAT.co.x - vt.co.x) + abs(vtAT.co.y - vt.co.y)
            t = q/step
            t = t * t
            vt.co.z = lerp( newMid, vt.co.z, t)



ContinueInY2()
ContinueInX2()

# 更新网格数据
mesh.update()

# 显示 log 文件:
logger.ShowOutputFile()

