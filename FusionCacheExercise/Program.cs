using Microsoft.Extensions.DependencyInjection;
using ZiggyCreatures.Caching.Fusion;

namespace FusionCacheExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //创建服务集合
            var services = new ServiceCollection();

            //服务注册
            services.AddScoped<FusionCacheService>();
            var entryOptions = new FusionCacheEntryOptions().SetDuration(TimeSpan.FromMinutes(10));
            services.AddFusionCache()
                .WithDefaultEntryOptions(entryOptions)
                .WithPostSetup((sp, c) =>
                {
                    c.DefaultEntryOptions.Duration = TimeSpan.FromMinutes(5);
                });

            using var serviceProvider = services.BuildServiceProvider();

            var myService = serviceProvider.GetRequiredService<FusionCacheService>();

            for (int i = 0; i < 2; i++)
            {
                var value = myService.GetValueAsync("FusionCacheExerciseKey").Result;
                Console.WriteLine($"{value.CacheMsg} {value.UserName}，{value.Age}，{value.Nationality}");
            }
        }
    }
}
