using Microsoft.Extensions.DependencyInjection;
using NetDimension.NanUI;

namespace NanUIExercise
{
    public class MyFirstAPP : AppStartup
    {
        protected override MainWindowCreationAction? UseMainWindow(MainWindowOptions opts)
        {
            // 设置应用程序的主窗体
            return opts.UseMainFormium<MyWindow>();
        }

        protected override void ProgramMain(string[] args)
        {
            // Main函数中的代码应该在这里，该函数只在主进程中运行。这样可以防止子进程运行一些不正确的初始化代码。
            ApplicationConfiguration.Initialize();
        }

        protected override void ConfigurationChromiumEmbedded(ChromiumEnvironmentBuiler cef)
        {
            // 在此处配置 Chromium Embedded Framwork
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            // 在这里配置该应用程序的服务
        }
    }
}
