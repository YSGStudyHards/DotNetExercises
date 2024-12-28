using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters;
using System.Security.Cryptography;
using System.Text;

namespace BenchmarkDotNetExercise
{
    /// <summary>
    /// 测试目的：为了验证每个哈希函数在频繁调用情况下的性能
    /// </summary>
    [MemoryDiagnoser]//记录内存分配情况
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class HashFunctionsBenchmark
    {
        private readonly byte[] _inputDataBytes;

        public HashFunctionsBenchmark()
        {
            // 使用一个较长的字符串作为输入，以更好地反映哈希函数的性能
            var generateData = new string('y', 1000000);
            _inputDataBytes = Encoding.UTF8.GetBytes(generateData);
        }

        [Benchmark]
        public byte[] MD5Hash()
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(_inputDataBytes);
            }
        }

        [Benchmark]
        public byte[] SHA256Hash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(_inputDataBytes);
            }
        }

        [Benchmark]
        public byte[] SHA1Hash()
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(_inputDataBytes);
            }
        }
    }
}
