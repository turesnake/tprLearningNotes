


# ----------------------------------------- #
#      -1- 新建一个文件, 将 log 写到这个文件里
# ----------------------------------------- #

# 代码:

import bpy

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
logger = BlenderLogger("MyLog")
# 下面直接调用这个来打印:
def print2(*args, sep=' '):
    msg = sep.join(str(arg) for arg in args)
    logger.Log(msg)

    


# <---- 把上述代码 贴到一个 blender 脚本头部, (最简单的用法....)




































