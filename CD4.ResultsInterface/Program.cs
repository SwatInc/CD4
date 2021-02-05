using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.ResultsInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<DataLibrary.DataAccess.IResultDataAccess, DataLibrary.DataAccess.ResultDataAccess>();
                    services.AddTransient<DataLibrary.DataAccess.IStatusDataAccess, DataLibrary.DataAccess.StatusDataAccess>();
                    services.AddTransient<DataLibrary.DataAccess.ISampleDataAccess, DataLibrary.DataAccess.SampleDataAccess>();
                    services.AddTransient<DataLibrary.DataAccess.IReferenceRangeDataAccess, DataLibrary.DataAccess.ReferenceRangeDataAccess>();
                    services.AddTransient<DataLibrary.DataAccess.IStaticDataDataAccess, DataLibrary.DataAccess.StaticDataDataAccess>();
                });
    }
}
