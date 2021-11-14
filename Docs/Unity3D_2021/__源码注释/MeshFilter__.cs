#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    
    // 摘要:
    //     A class to access the Mesh of the.
    [NativeHeaderAttribute("Runtime/Graphics/Mesh/MeshFilter.h")]
    [RequireComponent(typeof(Transform))]
    public sealed class MeshFilter : Component
    {
        public MeshFilter();

        /*
            摘要: Returns the shared mesh of the mesh filter.

            访问此属性, 将直接得到 绑定的 mesh 的读写权, 最要由此读取信息,而不是该写它;
            因为会影响所有 绑定此mesh 的其它go; 

            而且这种改写是不可逆的 (除非你自己暂存了原始数据)
            尤其是不要去改写 unity 自带的那几个 cube, sphere 之类的 mesh 的数据 !!!!!
        */
        public Mesh sharedMesh { get; set; }

        /*
            摘要: Returns the instantiated Mesh assigned to the mesh filter.

            若 mesh filter 并未被分配mesh, 调用此属性 讲自动为其分配一个 mesh

            若 mesh filter 已被分配了 mesh, 第一次访问此属性, 将绑定mesh 复制一份,
            返回这个复制的 mesh 实例, 然后本 meshfilter 和 原始绑定mesh 的关系会被彻底切断;
            此时再访问  sharedMesh, 得到的还是这个复制的 mesh 实例;

            若不是第一次访问此属性, 则一律返回那个 复制的 mesh实例;

            使用此属性, 可单独修改某个 go 的mesh, 而不影响原始绑定的 mesh,

            当本go被销毁时, 你需要手动销毁这个 复制的 mesh 实例, 
            Resources.UnloadUnusedAssets() 也能自动实现这件事, 但它只在加载新 level 时才会被调用;

            第一次调用本属性, 等同于如下代码:
                Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
                Mesh mesh2 = Instantiate(mesh);
                GetComponent<MeshFilter>().sharedMesh = mesh2;

            注意:
                If MeshFilter is a part of an asset object, quering mesh property is not allowed 
                and only asset mesh can be assigned.

        */
        public Mesh mesh { get; set; }
    }
}