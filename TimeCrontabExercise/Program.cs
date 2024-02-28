using TimeCrontab;

namespace TimeCrontabExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //常规格式：分 时 天 月 周
            var crontab = Crontab.Parse("* * * * *");
            var nextOccurrence = crontab.GetNextOccurrence(DateTime.Now);

            //支持年份：分 时 天 月 周 年
            var crontab1 = Crontab.Parse("* * * * * *", CronStringFormat.WithYears);
            var nextOccurrence1 = crontab1.GetNextOccurrence(DateTime.Now);

            //支持秒数：秒 分 时 天 月 周
            var crontab2 = Crontab.Parse("* * * * * *", CronStringFormat.WithSeconds);
            var nextOccurrence2 = crontab2.GetNextOccurrence(DateTime.Now);

            //支持秒和年：秒 分 时 天 月 周 年
            var crontab3 = Crontab.Parse("* * * * * * *", CronStringFormat.WithSecondsAndYears);
            var nextOccurrence3 = crontab3.GetNextOccurrence(DateTime.Now);

            // Macro 字符串
            var secondly = Crontab.Parse("@secondly"); //每秒 [* * * * * *]
            var minutely = Crontab.Parse("@minutely"); //每分钟 [* * * * *]
            var hourly = Crontab.Parse("@hourly"); //每小时 [0 * * * *]
            var daily = Crontab.Parse("@daily"); //每天 00:00:00 [0 0 * * *]
            var monthly = Crontab.Parse("@monthly"); //每月 1 号 00:00:00 [0 0 1 * *]
            var weekly = Crontab.Parse("@weekly"); //每周日 00：00：00 [0 0 * * 0]
            var yearly = Crontab.Parse("@yearly"); //每年 1 月 1 号 00:00:00 [0 0 1 1 *]
            var workday = Crontab.Parse("@workday"); //每周一至周五 00:00:00 [0 0 * * 1-5]
        }
    }
}
