#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
    /*
        
    */
    public class StreamReader : TextReader
    {
        public static readonly StreamReader Null;

        public StreamReader(Stream stream);
        public StreamReader(string path);
        public StreamReader(Stream stream, bool detectEncodingFromByteOrderMarks);
        public StreamReader(Stream stream, Encoding encoding);
        public StreamReader(string path, bool detectEncodingFromByteOrderMarks);
        public StreamReader(string path, Encoding encoding);
        public StreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks);
        public StreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks);
        public StreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize);
        public StreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize);
        public StreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen);

        public virtual Stream BaseStream { get; }
        public virtual Encoding CurrentEncoding { get; }
        public bool EndOfStream { get; }

        public override void Close();
        public void DiscardBufferedData();
        public override int Peek();
        public override int Read(Span<char> buffer);
        public override int Read();
        public override int Read(char[] buffer, int index, int count);
        public override Task<int> ReadAsync(char[] buffer, int index, int count);
        public override ValueTask<int> ReadAsync(Memory<char> buffer, CancellationToken cancellationToken = default);
        public override int ReadBlock(char[] buffer, int index, int count);
        public override int ReadBlock(Span<char> buffer);
        public override ValueTask<int> ReadBlockAsync(Memory<char> buffer, CancellationToken cancellationToken = default);
        public override Task<int> ReadBlockAsync(char[] buffer, int index, int count);
        public override string ReadLine();
        public override Task<string> ReadLineAsync();
        public override string ReadToEnd();
        public override Task<string> ReadToEndAsync();
        protected override void Dispose(bool disposing);
    }
}
