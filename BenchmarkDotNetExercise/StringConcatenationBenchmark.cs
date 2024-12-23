using BenchmarkDotNet.Attributes;
using System.Text;

namespace BenchmarkDotNetExercise
{
    [MemoryDiagnoser]//记录内存分配情况
    public class StringConcatenationBenchmark
    {
        private const int IterationCount = 1000;
        private const string StringPart1 = "追逐时光者";
        private const string StringPart2 = "DotNetGuide";
        private const string StringPart3 = "DotNetGuide技术社区";
        private readonly string[] _stringPartsArray = { "追逐时光者", "DotNetGuide", "DotNetGuide技术社区" };

        /// <summary>
        /// 使用 + 操作符拼接字符串
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public string PlusOperator()
        {
            string result = string.Empty;
            for (int i = 0; i < IterationCount; i++)
            {
                result += StringPart1 + " " + StringPart2 + " " + StringPart3;
            }
            return result;
        }

        /// <summary>
        /// 使用 $ 内插字符串拼接字符串
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public string InterpolatedString()
        {
            string result = string.Empty;
            for (int i = 0; i < IterationCount; i++)
            {
                result += $"{StringPart1} {StringPart2} {StringPart3}";
            }
            return result;
        }

        /// <summary>
        /// 使用string.Format()拼接字符串
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public string StringFormat()
        {
            string result = string.Empty;
            for (int i = 0; i < IterationCount; i++)
            {
                result += string.Format("{0} {1} {2}", StringPart1, StringPart2, StringPart3);
            }
            return result;
        }

        /// <summary>
        /// 使用string.Concat()拼接字符串
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public string StringConcat()
        {
            string result = string.Empty;
            for (int i = 0; i < IterationCount; i++)
            {
                result += string.Concat(StringPart1, " ", StringPart2, " ", StringPart3);
            }
            return result;
        }

        /// <summary>
        /// 使用string.Join()拼接字符串
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public string StringJoin()
        {
            string result = string.Empty;
            for (int i = 0; i < IterationCount; i++)
            {
                result += string.Join(" ", _stringPartsArray);
            }
            return result;
        }

        /// <summary>
        /// 使用StringBuilder.Append拼接字符串
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public string StringBuilderAppend()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < IterationCount; i++)
            {
                stringBuilder.Append(StringPart1);
                stringBuilder.Append(" ");
                stringBuilder.Append(StringPart2);
                stringBuilder.Append(" ");
                stringBuilder.Append(StringPart3);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 使用StringBuilder.AppendFormat拼接字符串
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public string StringBuilderAppendFormat()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < IterationCount; i++)
            {
                stringBuilder.AppendFormat("{0} {1} {2}", StringPart1, StringPart2, StringPart3);
            }
            return stringBuilder.ToString();
        }
    }
}
