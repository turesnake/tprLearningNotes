# ================================================================ #
#                criware  za
# ================================================================ #

https://zhuanlan.zhihu.com/p/95880629


# ----------------------------------------------#
#         criware 在项目内是怎么运行的
# ----------------------------------------------#

音频文件由做音频的同学使用CriWare的软件去制作，最终导出的文件是以 acb 或 awb 为扩展名的文件。
如果采用的是 Memory 的形式，则导出的 acb 文件。

每个音频有自己的名字: CueName;
数个音频可以打成一个组: CueSheet;

我们要播放一个声音，首先要知道声音的名字，就是CueName，还要知道它所在的组，因为要加载到内存中。即使要播放组中的一个音频，也是要把整个组加载到内存中的。


CriSoundMgr.PlayExternal()




# ----------------------------------------------#
#      criware 如何在单场景内播放 视频文件
# ----------------------------------------------#

新建场景, 按照顺序依次新建如下 gameobj:
    CriWareLibraryInitializer   
        -- Library Initializer 组件

    CriWareErrorHandler
        -- Error handler 组件

    CriManaVP9Initializer
        -- Cri Mana VP9 Initializer 组件

    Main Camera
        -- 就是一个默认 camera
    
    Xxxxxxxx_mov
        -- 就是我们要播放的  prefab








