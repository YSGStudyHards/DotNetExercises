using BenchmarkDotNet.Running;

namespace BenchmarkDotNetExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<HashFunctionsBenchmark>();
        }
    }
}
