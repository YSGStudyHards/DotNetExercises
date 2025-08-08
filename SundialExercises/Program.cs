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

            // ע�� Sundial ��ҵ
            builder.Services.AddSchedule(options =>
            {
                options.AddJob<CustomJob>(Triggers.PeriodSeconds(10)); // 10s ִ��һ��

                // ʹ��Cron���ʽ��ÿ��12��ִ�У�
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
