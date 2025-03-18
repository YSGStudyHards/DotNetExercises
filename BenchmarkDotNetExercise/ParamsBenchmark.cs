using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNetExercise
{
    [MemoryDiagnoser]//记录内存分配情况
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class ParamsBenchmark
    {
        private List<int> dataList = new();

        /// <summary>
        /// 初始化测试数据
        /// 如创建大型数据集、分配内存资源等，避免在每次基准测试迭代中重复初始化带来的性能干扰
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            dataList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 9, 10, 22, 55, 66, 88, 44, 66, 33, 77, 54, 24, 8789, 24, 54, 244, 377, 26, 99, 888, 1000 };
        }

        [Benchmark]
        public int CalculateOldSum()
        {
            return OldSumArray(dataList.ToArray());
        }

        [Benchmark]
        public int CalculateNewSumList()
        {
            return NewSumList(dataList);
        }

        /// <summary>
        /// C# 13 之前
        /// </summary>
        /// <param name="datas">datas</param>
        /// <returns></returns>
        public int OldSumArray(params int[] datas)
        {
            return datas.Sum();
        }

        /// <summary>
        /// C# 13 中
        /// </summary>
        /// <param name="datas">datas</param>
        /// <returns></returns>
        public int NewSumList(params List<int> datas)
        {
            return datas.Sum();
        }
    }
}
