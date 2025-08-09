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

            // ע�� Sundial ��ҵ�����ô�����
            builder.Services.AddSchedule(options =>
            {
                // ����Զ�������ÿ5��ִ�У�
                //options.AddJob<CustomJob>(Triggers.PeriodSeconds(5));

                // ����Զ�������ÿ10��ִ�У�
                //options.AddJob<CustomJob>(Triggers.PeriodSeconds(10));

                //.NET Cron ���ʽ������ TimeCrontab��https://gitee.com/dotnetchina/TimeCrontab
                var crontab = Crontab.DailyAt(3); // ÿ��� 3 Сʱ�����㣩
                //var crontab = Crontab.WeeklyAt("WED");  // SUN�������죩��MON��TUE��WED��THU��FRI��SAT
                //var crontab = Crontab.YearlyAt(3); // ÿ��� 3��5��6 �� 1 �������
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
