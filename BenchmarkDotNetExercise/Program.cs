using BenchmarkDotNet.Running;

namespace BenchmarkDotNetExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var hashFunctionsBenchmark = BenchmarkRunner.Run<HashFunctionsBenchmark>();
            //var dataSetDeduplicationBenchmark = BenchmarkRunner.Run<DataSetDeduplicationBenchmark>();

            var stringConcatenationBenchmark = BenchmarkRunner.Run<StringConcatenationBenchmark>();
        }
    }
}
