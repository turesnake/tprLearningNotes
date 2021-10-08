# ================================================================//
#                         IO
# ================================================================//



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



































