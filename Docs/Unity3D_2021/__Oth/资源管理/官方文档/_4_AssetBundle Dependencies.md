# ===================================================== #
#          AssetBundle Dependencies
# ===================================================== #

https://docs.unity3d.com/Manual/AssetBundles-Dependencies.html?_ga=2.91118746.1050821994.1655689056-997589975.1645524223


如果一个 ab包里的 一个 obj, 依赖另一个 ab包里的 obj, 则这两个 ab包 就形成依赖关系;

# 注意:
如果一个 ab包依赖的 一个 obj, 这个 obj 并不在任何 ab包中, (也就是说, 这个被依赖的 obj 没有被打包) 那么就无法构成 ab包之间的 依赖关系;

在这个例子中, 在 build 那个 ab包时, 会把它依赖的那个没有被打包的 野obj, 复制一份到自己的 ab包中;

更进一步:
如果两个 ab包, 都依赖一个 野的obj, 则这两个 ab包, 都会复制一份这个 野的obj, (这里就能看出问题了)

# --
在将一个 obj 从它的 ab包中加载出来之前, 要先将它依赖的那些 ab包, 加载到内存中 (其实是把这些 ab包的 head 加载到内存中)


# ----------------------------------------------- #
#   Duplicated information across AssetBundles
默认情况下, unity 不会去优化 ab包之间的 重复信息; 比如两个 ab包里各自有一个 prefab, 它们都依赖一个 material, 然后因为这个 materia 没有进任何 ab包, 是野的, 所以就被复制进了两个 ab包中, 形成了 资源重复;

#  Editor setup:
... 略 ...

大概意思就是把 公共资源打到一个独立的 ab包里去;

重复资源的危害:
-- 增大了包体
-- 运行时内存的占用也变大了
-- 影响 batching, 因为 unity 会把两个相同的 material, 各自看作独立的 material
    (但是这好像不影响 srp batcher, 个人猜测)


# Runtime loading:
注意:
    就算是在上述案例中, 如果你仅仅使用 ab包中的 prefab 来实例化一个 go, 他所依赖的 另一个 ab包中的 material 也是不会被加载的;

为解决此问题, 应该手动地 先把 material 的 ab包 加载到内存(head信息), 然后再加载 父ab包, 也就是 装 prefab 的 ab包, 然后再从 ab包中把 prefab 加载到内存;


    void Start()
    {
        // 先加载 子 ab包, 后加载 父ab包;
        // 其实先后顺序顺序无所谓,  
        var materialsAB = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, Path.Combine("AssetBundles", "modulesmaterials")));
        var moduleAB = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, Path.Combine("AssetBundles", "example-prefab")));

        if (moduleAB == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        // 最后加载 prefab;
        var prefab = moduleAB.LoadAsset<GameObject>("example-prefab");
        Instantiate(prefab);
    }


Note: 
When you use LZ4 compressed and uncompressed AssetBundles, 
"AssetBundle.LoadFromFile()" only loads the catalog of its content in memory, but not the content itself. To check if this is happening, use the Memory Profiler package to inspect memory usage.
---

注意, 当你使用了 LZ4 或 未压缩 模式的 ab包, 调用 "AssetBundle.LoadFromFile()" 只会把 ab包的 目录加载到 内存中, 而不是 ab包的内容; (其实就是 ab包的 head 信息, 这是主流的做法)
---
若想检测这个, 可使用 "Memory Profiler" package 来查看 内存使用情况;






















