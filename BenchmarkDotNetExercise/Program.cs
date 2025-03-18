using BenchmarkDotNet.Running;

namespace BenchmarkDotNetExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var paramsBenchmark = BenchmarkRunner.Run<ParamsBenchmark>();
            //var hashFunctionsBenchmark = BenchmarkRunner.Run<HashFunctionsBenchmark>();
            //var hashFunctionsBenchmarkV2 = BenchmarkRunner.Run<HashFunctionsBenchmarkV2>();
            //var dataSetDeduplicationBenchmark = BenchmarkRunner.Run<DataSetDeduplicationBenchmark>();
            //var stringConcatenationBenchmark = BenchmarkRunner.Run<StringConcatenationBenchmark>();
        }
    }
}
