# ================================================================//
#                    IO
# ================================================================//


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














