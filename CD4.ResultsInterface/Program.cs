using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CD4.ResultsInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger =  new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting up service.");
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There was a problem starting the service.");
            }
            finally 
            {
                Log.Information("closing!");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<DataLibrary.DataAccess.IResultDataAccess, DataLibrary.DataAccess.ResultDataAccess>();
                    services.AddTransient<DataLibrary.DataAccess.IStatusDataAccess, DataLibrary.DataAccess.StatusDataAccess>();
                    services.AddTransient<DataLibrary.DataAccess.ISampleDataAccess, DataLibrary.DataAccess.SampleDataAccess>();
                    services.AddTransient<DataLibrary.DataAccess.IReferenceRangeDataAccess, DataLibrary.DataAccess.ReferenceRangeDataAccess>();
                    services.AddTransient<DataLibrary.DataAccess.IStaticDataDataAccess, DataLibrary.DataAccess.StaticDataDataAccess>();
                })
                .UseSerilog();
    }
}
