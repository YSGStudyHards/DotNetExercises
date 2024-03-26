using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TanvirArjel.EFCore.GenericRepository;

namespace GenericRepositoryExercise
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //设置依赖注入容器
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<UserInfoService>();

            var connectionString = "Server=.;Database=MyTestDB;User Id=test;Password=123456;trustServerCertificate=true;";
            services.AddDbContext<TestDbContext>(option => option.UseSqlServer(connectionString));

            //注册DbConext后立即调用它
            services.AddGenericRepository<TestDbContext>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            //从容器中获取UserInfoService实例并执行操作
            var userInfoService = serviceProvider.GetRequiredService<UserInfoService>();
            await userInfoService.UserInfoCRUD();
        }
    }
}
