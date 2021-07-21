using CD4.AstmInterface.View;
using CD4.AstmInterface.ViewModel;
using CD4.DataLibrary.DataAccess;
using CD4.ResultsInterface.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CD4.AstmInterface
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ///Generate Host Builder and Register the Services for DI
            var builder = new HostBuilder()
                           .ConfigureServices((hostContext, services) =>
                           {
                               //Register all your services here
                               services.AddScoped<MainView>();
                               services.AddScoped<MainViewModel>();
                               services.AddTransient<IExportService, ExportService>();
                               services.AddTransient<IScriptDataAccess, ScriptDataAccess>();
                           }).ConfigureLogging(logBuilder =>
                           {
                               logBuilder.AddLog4Net("App.config");

                           });

            var host = builder.Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    var mainview = services.GetRequiredService<MainView>();
                    Application.Run(mainview);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    }
}
