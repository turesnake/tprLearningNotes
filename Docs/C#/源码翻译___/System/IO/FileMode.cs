#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion

namespace System.IO
{
    public enum FileMode
    {

        /*
            Specifies that the operating system should create a new file. 
            This requires Write permission.
            If the file already exists, an IOException exception is thrown.
            ----
            若文件已存在, 将抛出异常
        */
        CreateNew = 1,

        /*
            Specifies that the operating system should create a new file. 
            If the file already exists, it will be overwritten. 
            This requires Write permission. 
            FileMode.Create is equivalent to requesting that if the file does not exist, use CreateNew; otherwise, use Truncate.
            If the file already exists but is a hidden file, an UnauthorizedAccessException exception is thrown.
            ---
            若文件已存在, 将被覆写;
            等价于:
                若文件不存在, -> CreateNew
                若文件存在,   -> Truncate
        */
        Create = 2,

        /*
            Specifies that the operating system should open an existing file. 
            The ability to open the file is dependent on the value specified by the FileAccess enumeration.
            A FileNotFoundException exception is thrown if the file does not exist.
            ---
            若文件不存在, 将抛出异常
        */
        Open = 3,

        /*
            Specifies that the operating system should open a file if it exists; otherwise, a new file should be created.
            If the file is opened with FileAccess.Read, Read permission is required. 
            If the file access is FileAccess.Write, Write permission is required.
            If the file is opened with FileAccess.ReadWrite, both Read and Write permissions are required.
            ---


        */
        OpenOrCreate = 4,

        /*
            Specifies that the operating system should open an existing file. When the file is opened, it should be truncated so that its size is zero bytes.
            This requires Write permission. 
            Attempts to read from a file opened with FileMode.Truncate cause an ArgumentException exception.
            ---
            会覆写一个已经存在的文件;
        */
        Truncate = 5,

        /*
            Opens the file if it exists and seeks to the end of the file, or creates a new file.
            This requires Append permission. 
            FileMode.Append can be used only in conjunction with FileAccess.Write.
            Trying to seek to a position before the end of the file throws an IOException exception,
            and any attempt to read fails and throws a NotSupportedException exception.
            ---
            若无文件, 新建一个
            若有文件, 打开并执行尾后;

            -- 指向 尾后之前的位置  会抛出异常;
            -- 尝试读文件, 会抛出异常;
        */
        Append = 6
    }
}

