
# ================================================================ #
#                 AssetBundles
# ================================================================ #
An AssetBundle is an archive file that contains platform-specific non-code Assets (such as Models, Textures, Prefabs, Audio clips, and even entire Scenes) that Unity can load at run time. 
---
ab包 是个 存档文件, 内涵 平台特定的 无代码资源, 比如 模型, textures, prefabs, Audio clips, 或者整个 scene; 

DLC 就是用 ab包 实现的; 

# 注意:
An AssetBundle can contain the serialized data of an instance of a code object, such as a ScriptableObject. However, the class definition itself is compiled into one of the Project assemblies. When you load a serialized object in an AssetBundle, Unity finds the matching class definition, creates an instance of it, and sets that instance’s fields using the serialized values. This means that you can introduce new items to your game in an AssetBundle as long as those items do not require any changes to your class definitions.
---

ab包内可包含: 一个 ScriptableObject 的配置信息;
真正的 c# class 代码 会被打包进一个 Project assemblies; (而不是放在 ab包里)

当你从 ab包中导入一个 序列化的 obj, unity 会去寻找到对应的 脚本文件代码, 创建这个 class 的实例, 然后用 ab包里的 obj 的数据, 去配置这个 class 实例;

这意味着, 你可以使用 ab包 来为你的项目 添加新的 class 实例, 但你不能使用 ab包来为项目添加新的 class 代码;

..... 一大段未翻译 .....


可使用 Addressables package 来管理 ab包;














