# ===================================================== #
#           Patching with AssetBundles
# ===================================================== #

Patching 一个 ab包, 几乎等于: 下载新的 ab包, 替换掉旧的;

如果使用了 WWW.LoadFromCacheOrDownload() or UnityWebRequest() 来管理 app 的缓存的 ab包, 传递一个不同的参数给这些 api,将会触发它们下载新的 ab包;

跟困难的问题是: 确定哪个 ab包 需要被更新; 一个 patching system 需要两种信息:
-1-
    一个 list, 记录当前下载了哪些 ab包, 以及它们的 版本信息;

-2-
    一个 list, 记录服务器中拥有了哪些 ab包, 以及它们的 版本信息;

一个 patcher 需要比较这两张 list, 如果某些 ab包在本地不存在, 或者版本不一致, 就要开始 更新操作;

# ---
也可手写一个 热更系统, 选用 json 来存储上述 list 表, 以及 MD5 作为 checksums;


Unity builds AssetBundles with data ordered in a deterministic manner(确定性的方式). This allows applications with custom downloaders to implement differential patching.
---
Unity 使用以确定方式排序的数据构建 AssetBundle。


Unity does not provide any built-in mechanism for differential patching and neither WWW.LoadFromCacheOrDownload nor UnityWebRequest perform differential patching when using the built-in caching system. If differential patching is a requirement, then a custom downloader must be written.
---
"differential patching" 差异补丁 ?
需要用户自己实现一个









