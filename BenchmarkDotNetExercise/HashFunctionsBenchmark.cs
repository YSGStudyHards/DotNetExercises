using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters;
using System.Security.Cryptography;
using System.Text;

namespace BenchmarkDotNetExercise
{
    [MemoryDiagnoser]//记录内存分配情况
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class HashFunctionsBenchmark
    {
        private readonly string _inputData;

        public HashFunctionsBenchmark()
        {
            // 使用一个较长的字符串作为输入，以更好地反映哈希函数的性能
            _inputData = new string('y', 1000000);
        }

        [Benchmark]
        public byte[] MD5Hash()
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(_inputData));
            }
        }

        [Benchmark]
        public byte[] SHA256Hash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(_inputData));
            }
        }

        [Benchmark]
        public byte[] SHA1Hash()
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(Encoding.UTF8.GetBytes(_inputData));
            }
        }
    }
}
