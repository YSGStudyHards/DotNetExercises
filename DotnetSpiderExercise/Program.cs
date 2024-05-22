namespace DotnetSpiderExercise
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("网页数据抓取开始...");

            await RecommendedRankingSpider.RunAsync();

            Console.WriteLine("网页数据抓取完成...");
        }
    }
}
