

touch 命令在 Ubuntu 服务器 的 Shell 中主要用于 `创建空文件` 或 `更新现有文件的时间戳` 。


# touch filename.txt
 如果 filename.txt 不存在，则会创建一个空文件。
 如果文件已存在，则会更新该文件的 `访问` 和 `修改` 时间戳。

# touch -a filename.txt
    仅更新文件的 访问时间，而不改变 修改时间。


# touch -m filename.txt
    仅更新文件的 修改时间，而不改变 访问时间。


# touch -c filename.txt
    如果文件 不存在，则 不创建 新文件。此选项用于避免意外创建文件。


# touch -d "2023-01-01 12:00:00" filename.txt
    使用指定的时间戳（格式为[[CC]YY]MMDDhhmm[.ss]）更新文件的时间戳。





















