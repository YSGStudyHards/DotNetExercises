using Sundial;
using TimeCrontab;

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
                // 添加自定义任务（每5秒执行）
                //options.AddJob<CustomJob>(Triggers.PeriodSeconds(5));

                // 添加自定义任务（每10秒执行）
                //options.AddJob<CustomJob>(Triggers.PeriodSeconds(10));

                //.NET Cron 表达式解析库 TimeCrontab：https://gitee.com/dotnetchina/TimeCrontab
                var crontab = Crontab.DailyAt(3); // 每天第 3 小时正（点）
                //var crontab = Crontab.WeeklyAt("WED");  // SUN（星期天），MON，TUE，WED，THU，FRI，SAT
                //var crontab = Crontab.YearlyAt(3); // 每年第 3，5，6 月 1 日零点正
                options.AddJob<CustomJob>(Triggers.Cron(crontab.ToString()));
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
