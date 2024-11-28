using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNetExercise
{
    [MemoryDiagnoser]//记录内存分配情况
    public class DataSetDeduplicationBenchmark
    {
        private List<int> dataSource;

        public DataSetDeduplicationBenchmark()
        {
            // 生成大量重复数据  
            dataSource = Enumerable.Repeat(Enumerable.Range(1, 100), 10000).SelectMany(x => x).ToList();
        }

        /// <summary>
        /// 使用HashSet去重
        /// TODO:HashSet是一个集合类，它的特点是不允许重复元素，可以方便地实现去重功能。
        /// </summary>
        [Benchmark]
        public void HashSetDuplicate()
        {
            HashSet<int> uniqueData = new HashSet<int>(dataSource);
        }

        /// <summary>
        /// 直接循环遍历去重
        /// </summary>
        [Benchmark]
        public void LoopTraversalDuplicate()
        {
            var uniqueData = new List<int>();
            foreach (var item in dataSource)
            {
                //if (!uniqueData.Any(x => x == item))
                //if (!uniqueData.Exists(x => x == item))
                if (!uniqueData.Contains(item))
                {
                    uniqueData.Add(item);
                }
            }
        }

        /// <summary>
        /// 使用Linq的Distinct()方法去重
        /// </summary>
        [Benchmark]
        public void DistinctDuplicate()
        {
            var uniqueData = dataSource.Distinct().ToList();
        }

        /// <summary>
        /// 使用Linq的GroupBy()方法去重
        /// </summary>
        [Benchmark]
        public void GroupByDuplicate()
        {
            //GroupBy()方法将原始集合中的元素进行分组，根据指定的键或条件进行分组。每个分组都会有一个唯一的键，通过将原始集合分组并选择每个分组中的第一个元素，实现了去重的效果。
            var uniqueData = dataSource.GroupBy(item => item).Select(group => group.First()).ToList();
        }

        /// <summary>
        /// 使用自定义的比较器和循环遍历
        /// </summary>
        [Benchmark]
        public void CustomEqualityComparerDuplicate()
        {
            var uniqueData = new List<int>();
            foreach (var item in dataSource)
            {
                if (!uniqueData.Contains(item, new CustomEqualityComparer()))
                {
                    uniqueData.Add(item);
                }
            }
        }

        /// <summary>
        /// 自定义的比较器
        /// </summary>
        public class CustomEqualityComparer : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return x == y;
            }

            public int GetHashCode(int obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
