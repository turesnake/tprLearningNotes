# ================================================================ #
#                         IO
# ================================================================ #



# ---------------------------------------------- #
#           path combine
# ---------------------------------------------- #

    using System.IO;
    string path = Path.Combine( Application.persistentDataPath, "saveFile" );

此代码指定了一个文件的 path, 不过未标明它的后缀类型, 是一个 二进制文件;

Application.persistentDataPath 是 unity 各个系统默认设置的 存档路径位置,
可通过 Debug.Log() 查看;



# ---------------------------------------------- #
#        写入 二进制文件
# ---------------------------------------------- #

    using System.IO;

	using (
        // 若目标文件已存在, 将被覆写, 需要 write权限. 
        // 若文件已存在且为隐藏状态, 将报错
        // ---
        // 转换为 未压缩的紧凑类型, raw binary data
		var writer = new BinaryWriter(File.Open(filePath, FileMode.Create ))
	){
		writer.Write( 123 );
	}

为保证读写原子化, 使用 using 语法来管理整个	写入过程,
确保在 大括号中内容 执行完毕后, 立马释放 小括号中分配的资源

大括号中 不能出现 协程代码, 毕竟那会导致 在资源被释放后, 再次回来访问



# ---------------------------------------------- #
#        读取 二进制文件  
# ---------------------------------------------- #

# --1-- 原子化读取:

    using System.IO;
    using (
		var reader = new BinaryReader(File.Open( filePath, FileMode.Open ))
	){
		int val = reader.ReadInt32();
	}

大括号中 不能出现 协程代码, 毕竟那会导致 在资源被释放后, 再次回来访问


# --2-- 一口气读取:

    byte[] data = File.ReadAllBytes( filePath );
    var reader = new BinaryReader( new MemoryStream(data) );
    int val = reader.ReadInt32();

一口气读取目标二进制文件中 所有字节, 存入 buffer 中;
然后再将其传递给 BinaryReader, 以便快捷解析 二进制数据中的 内容





# ---------------------------------- #
#   判断一个 path 是否有效
#      文件 or 目录
# ---------------------------------- #


# System.IO.Directory.Exists( path ):
    目录 path 是否有效;

    true if path refers to an existing directory; 
    false if the directory does not exist or an error occurs when trying to determine if the specified directory exists.
    ---
    如果目录 目录不存在, 或在检查过程中出现 error, 都会返回 false;

    参数的尾后 空格 会被自动删除;

    如果你连目标目录的 最低权限(只读权限) 都没有, 本函数将直接返回 false;

    可能存在的 error 有:
        没有足够权限
        路径名存在无效字符
        路径名太长
        目标磁盘无效

# System.IO.File.Exists( path ):
    true if the caller has the required permissions and path contains the name of an existing file; otherwise, false. 
    This method also returns false if path is null, an invalid path, or a zero-length string. 
    If the caller does not have sufficient permissions to read the specified file, no exception is thrown and the method returns false regardless of the existence of path.
    ---

    如果: 
        path 不是文件路径
        路径无效
        路径为 ""
        无足够访问权限
    
    此时不会抛出异常, 只会返回 false;



#  DirectoryInfo:

    DirectoryInfo di = new DirectoryInfo( path );

记录一个 目录path 的信息, 可用来执行一些检测 或 创建删除工作;

Use for typical operations such as copying, moving, renaming, creating, and deleting directories.
---
复制, 移动, 重命名, 新建, 删除 目录;


https://docs.microsoft.com/en-us/dotnet/api/system.io.directoryinfo?view=net-6.0




# ---------------------------------- #
#   FileInfo:
类似 DirectoryInfo, 可以方便地处理一个 文件的 各种操作;

Provides properties and instance methods for the creation, copying, deletion, moving, and opening of files, and aids in the creation of FileStream objects. This class cannot be inherited.
---
新建, 复制, 删除, 移动, 打开 文件; 帮助创建 FileStream 对象; 



# ---------------------------------- #
#  判断并新建一个 folder
# ---------------------------------- #

    if( !System.IO.Directory.Exists( path1 ) )
    {
        System.IO.Directory.CreateDirectory( path1 );
    }

# 能保证, 就算 path1 中多层 folder 都是不存在的, 也能给你全部新建出来;


# ---------------------------------- #
#  彻底清理一个 folder 
# ---------------------------------- #

    if (System.IO.Directory.Exists(fullPath))
    {
        System.IO.Directory.Delete(fullPath, true);
    }
    System.IO.Directory.CreateDirectory(fullPath);
    ---
    就是将它删除后, 再重建一个;



# ------------------------ #
#   unity 工程 本身的 path
# ------------------------ #
# static string ProjectDirectory = new DirectoryInfo(Application.dataPath).Parent.FullName;

    Application.dataPath 就是 "Assets" 这个目录;
    
    然得到 向上一层 得到工程的 path;





# ---------------------------------- #
#  File.ReadAllText( path )

Opens a text file, reads all the text in the file into a string, and then closes the file.
---
专门打开一个 txt 文件, 读取所有 txt 内容到一个 string, 然后关闭这个 文件;




# ------------------------------------ #
#   如何从 完整path 中获得 相对 path
# ------------------------------------ #

-- 完整path: 从 D: 开始的这种
-- 相对path: 从 "Assets/" 开始的这种, unity 专属;

    // 从 fullPath 中找到第一处 "Assets"; 参数2是查找规则, 暂时不管;
    int index = fullPath.IndexOf("Assets", StringComparison.Ordinal);
    if (index != -1)
    {
        string assetPath = fullPath.Substring(index);
        ...
    }

assetPath 就是我们要的 相对path;




# ------------------------------------ #
#   如何 自动 打开一个 win 目录
#   how to auto open this folder in win11 explorer
# ------------------------------------ #

# System.Diagnostics.Process.Start("E:/Books/物理计算机动画");
    This will open the folder in Windows Explorer if it exists, or throw an exception if it doesn’t1. 
    如果 path 异常, 将抛出异常
    
# System.Diagnostics.Process.Start("explorer.exe", @"E:\Books\物理计算机动画" );
    如果 path 异常, 将直接打开一个默认 目录, 而不是 报异常
    但是这个用法里, path 好像需要用 上例中的 @"E:\Books\物理计算机动画"  这个格式的


# --- 推荐用法 ---
    try
    {
        System.Diagnostics.Process.Start("E:/Books/物理计算机动画a");
    }
    catch (System.Exception)
    {
        Debug.LogError("koko path异常");
    }



# ------------------------------------ #
#   我有一个 文件的 path
#   如何自动打开它的 目录, 然后 focus 它
# ------------------------------------ #

    string filePath = "C:\\Users\\Administrator\\Desktop\\powershell_test\\AA.txt"; // your file path
    System.Diagnostics.Process.Start("explorer.exe", "/select, " + filePath);




# ------------------------------------ #
#   打开一个指定网页
# ------------------------------------ #

# -1-
    System.Diagnostics.Process.Start("IExplore.exe", "www.baidu.com");

# -2-
    Application.OpenURL("http://unity3d.com/");
    


# ------------------------------------ #
#   从一个 path 上获得 文件名 (无后缀)
# ------------------------------------ #

Path.GetFileNameWithoutExtension()


# ------------------------------------ #
#   从一个 full file path 上获得 folder path
# ------------------------------------ #

return System.IO.Path.GetDirectoryName(fullFilePath_.Replace("\\", "/"));



# ------------------------------------ #
#   复制一个文件
# ------------------------------------ #

System.IO.File.Copy( oldPath, newPath, false );
    参数3: overwrite












