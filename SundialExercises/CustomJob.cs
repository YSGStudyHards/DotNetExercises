using Sundial;

namespace SundialExercises
{
    public class CustomJob : IJob
    {
        private readonly ILogger<CustomJob> _logger;

        public CustomJob(ILogger<CustomJob> logger)
        {
            _logger = logger;
        }

        public Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
        {
            _logger.LogInformation(context.ToString());
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] 任务执行中...");
            return Task.CompletedTask;
        }
    }
}
