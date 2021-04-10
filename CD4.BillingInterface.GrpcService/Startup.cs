using CD4.BillingInterface.GrpcService.Services;
using CD4.DataLibrary.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.BillingInterface.GrpcService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddTransient<IAnalysisRequestDataAccess,AnalysisRequestDataAccess>();
            services.AddTransient<IPatientDataAccess, PatientDataAccess>();
            services.AddTransient<IClinicalDetailsDataAccess, ClinicalDetailsDataAccess>();
            services.AddTransient<ISampleDataAccess, SampleDataAccess>();
            services.AddTransient<IResultDataAccess, ResultDataAccess>();
            services.AddTransient<IStatusDataAccess, StatusDataAccess>();
            services.AddTransient<IReferenceRangeDataAccess, ReferenceRangeDataAccess>();
            services.AddTransient<IStaticDataDataAccess, StaticDataDataAccess>();
            services.AddSingleton<IBillingCD4TestMapService, BillingCD4TestMapService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<AnalysisRequestService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
