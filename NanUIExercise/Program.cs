using NetDimension.NanUI;

namespace NanUIExercise
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = NanUIApp.CreateBuilder();

            builder.UseNanUIApp<MyFirstAPP>();

            var app = builder.Build();

            app.Run();
        }
    }
}