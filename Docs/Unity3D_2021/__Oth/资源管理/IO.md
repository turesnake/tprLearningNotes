# ================================================================ #
#                    IO
# ================================================================ #


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




# ------------------------ #
#   unity 工程 本身的 path
# ------------------------ #
# static string ProjectDirectory = new DirectoryInfo(Application.dataPath).Parent.FullName;

    Application.dataPath 就是 "Assets" 这个目录 向上一层 得到工程的 path;





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














