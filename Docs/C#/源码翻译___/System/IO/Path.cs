#region Assembly mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\UnityReferenceAssemblies\unity-4.8-api\mscorlib.dll
#endregion

using System.Runtime.InteropServices;
using System.Security;

namespace System.IO
{
    [ComVisible(true)]
    public static class Path
    {
        public static readonly char AltDirectorySeparatorChar;
        public static readonly char DirectorySeparatorChar;
        [Obsolete("Please use GetInvalidPathChars or GetInvalidFileNameChars instead.")]
        public static readonly char[] InvalidPathChars;
        public static readonly char PathSeparator;
        public static readonly char VolumeSeparatorChar;

        public static string ChangeExtension(string path, string extension);


        public static string Combine(string path1, string path2);
        public static string Combine(string path1, string path2, string path3);
        public static string Combine(string path1, string path2, string path3, string path4);
        public static string Combine(params string[] paths);


        /*
            ret:
                Directory information for path, or null if path denotes a root directory or is null. 
                Returns Empty if path does not contain directory information.
                ----
                若参数 path 是 根目录 或 null, 返回 null
                若参数 path 没有folder信息, 返回 "";

            Exceptions:
                ArgumentException
                    .NET Framework and .NET Core versions older than 2.1: The path parameter contains invalid characters, is empty, or contains only white spaces.

                    若参数 包含无效字符, 或 为空, 或只包含 空格字符

                PathTooLongException
                    The path parameter is longer than the system-defined maximum length.

                    Note: In .NET for Windows Store apps or the Portable Class Library, catch the base class exception, IOException, instead.
        */
        public static ReadOnlySpan<char> GetDirectoryName(ReadOnlySpan<char> path);
        public static string GetDirectoryName(string path);


        /*
            假设传入 "AA/aa.txt.backup"
            本函数只会返回 ".backup"

        */
        public static ReadOnlySpan<char> GetExtension(ReadOnlySpan<char> path);
        public static string GetExtension(string path);




        public static string GetFileName(string path);
        public static ReadOnlySpan<char> GetFileName(ReadOnlySpan<char> path);

        public static string GetFileNameWithoutExtension(string path);
        public static ReadOnlySpan<char> GetFileNameWithoutExtension(ReadOnlySpan<char> path);

        [SecuritySafeCritical]
        public static string GetFullPath(string path);
        public static string GetFullPath(string path, string basePath);

        public static char[] GetInvalidFileNameChars();

        public static char[] GetInvalidPathChars();

        public static string GetPathRoot(string path);
        public static ReadOnlySpan<char> GetPathRoot(ReadOnlySpan<char> path);

        public static string GetRandomFileName();

        public static string GetRelativePath(string relativeTo, string path);

        [SecuritySafeCritical]
        public static string GetTempFileName();

        [SecuritySafeCritical]
        public static string GetTempPath();

        public static bool HasExtension(string path);
        public static bool HasExtension(ReadOnlySpan<char> path);

        public static bool IsPathFullyQualified(ReadOnlySpan<char> path);
        public static bool IsPathFullyQualified(string path);

        public static bool IsPathRooted(ReadOnlySpan<char> path);
        public static bool IsPathRooted(string path);

        public static string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2);
        public static string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3);

        public static bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination, out int charsWritten);
        public static bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination, out int charsWritten);
    }
}