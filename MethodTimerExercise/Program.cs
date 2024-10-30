using MethodTimer;
using System.Reflection;

namespace MethodTimerExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeMethod();
        }

        [Time]
        public static void TimeMethod()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"输出结果{i}");
            }
        }

        /// <summary>
        /// 运行耗时为long（毫秒）
        /// </summary>
        public static class MethodTimeLogger1
        {
            public static void Log(MethodBase methodBase, long milliseconds, string message)
            {
                Console.WriteLine($"方法：{methodBase.Name} 耗时：{milliseconds} 毫秒，信息：{message}");
            }
        }

        /// <summary>
        /// 运行耗时为TimeSpan
        /// </summary>
        public static class MethodTimeLogger
        {
            public static void Log(MethodBase methodBase, TimeSpan elapsed, string message)
            {
                Console.WriteLine($"方法：{methodBase.Name} 耗时：{elapsed.TotalMilliseconds} 毫秒，信息：{message}");
            }
        }
    }
}
