using Sundial;

namespace SundialExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // 注册 Sundial 作业并配置触发器
            builder.Services.AddSchedule(options =>
            {
                // 添加自定义任务（每10秒执行）
                options.AddJob<CustomJob>(Triggers.PeriodSeconds(10));

                // 使用Cron表达式（每天12点执行）
                options.AddJob<CustomJob>(Triggers.Cron("0 0 12 * * ?"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
