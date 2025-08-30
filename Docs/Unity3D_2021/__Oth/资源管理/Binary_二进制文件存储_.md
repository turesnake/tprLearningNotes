




# ----------------------------- #
#      重要注意事项与最佳实践
# ----------------------------- #
-- 不要使用 BinaryFormatter：它存在安全风险并已过时。

-- 版本兼容：当 WinData 结构发生变化，旧文件可能无法解析。建议在文件头写入版本号（int）：
    Save 时先写入版本号（e.g., writer.Write(version)）。
    Load 时读取版本号并根据版本决定如何解析或进行迁移。

# -- 原子写入：为避免文件写入中断导致数据损坏，采用临时文件 + 覆盖方式：
    写到 file.tmp
    成功后重命名/移动为正式文件（在 Windows 用 File.Replace 更安全）

-- 加密/校验：如果担心篡改或完整性，可添加校验（CRC/Hash）或对文件内容加密（Aes）。

-- 同步/异步：大量 IO 操作时应在后台线程或使用异步 API（避免阻塞主线程）。

-- 路径：使用 Application.persistentDataPath（移动平台、PC 都适用）。

-- Unity 对象：不要直接序列化 UnityEngine.Object（如 GameObject、Texture）。若需保存引用，保存可序列化的 ID/路径等信息。















