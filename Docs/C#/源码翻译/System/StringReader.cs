#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
    /*
        将一个普通 string 转换为一个类似 stream 的对象, 可以方便地从中逐行读取;

        StringReader enables you to read a string synchronously or asynchronously. 
        You can read a character at a time with the Read() or the ReadAsync() method, 
        a line at a time using the ReadLine() or the ReadLineAsync() method 
        and an entire string using the ReadToEnd() or the ReadToEndAsync() method.

        This type implements the IDisposable interface, but does not actually have any resources to dispose. 
        This means that disposing it by directly calling Dispose() or by using a language construct such as "using" (in C#) 
        or Using (in Visual Basic) is not necessary.
        ---
        此类型的实例 没有资源, 不需要调用 Dispose();

        使用范例:
            StringReader sr = new StringReader(srcString);
            while( (line = sr.ReadLine()) != null )
            {
                Log( line );
            }
            sr.Close();//关闭流
            sr.Dispose();//销毁流 
        -----
    */
    public class StringReader : TextReader
    {
        public StringReader(string s);

        public override void Close();
        public override int Peek();
        public override int Read();
        public override int Read(char[] buffer, int index, int count);
        public override int Read(Span<char> buffer);
        public override Task<int> ReadAsync(char[] buffer, int index, int count);
        public override ValueTask<int> ReadAsync(Memory<char> buffer, CancellationToken cancellationToken = default);
        public override int ReadBlock(Span<char> buffer);
        public override Task<int> ReadBlockAsync(char[] buffer, int index, int count);
        public override ValueTask<int> ReadBlockAsync(Memory<char> buffer, CancellationToken cancellationToken = default);
        public override string ReadLine();
        public override Task<string> ReadLineAsync();
        public override string ReadToEnd();
        public override Task<string> ReadToEndAsync();
        protected override void Dispose(bool disposing);
    }
}
