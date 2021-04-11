using CD4.BillingInterface.WebApiService.Services;
using CD4.DataLibrary.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.BillingInterface.WebApiService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddTransient<IAnalysisRequestDataAccess, AnalysisRequestDataAccess>();
            services.AddTransient<IPatientDataAccess, PatientDataAccess>();
            services.AddTransient<IClinicalDetailsDataAccess, ClinicalDetailsDataAccess>();
            services.AddTransient<ISampleDataAccess, SampleDataAccess>();
            services.AddTransient<IResultDataAccess, ResultDataAccess>();
            services.AddTransient<IStatusDataAccess, StatusDataAccess>();
            services.AddTransient<IReferenceRangeDataAccess, ReferenceRangeDataAccess>();
            services.AddTransient<IStaticDataDataAccess, StaticDataDataAccess>();
            services.AddSingleton<IBillingCD4AnalysesMapService, BillingCD4AnalysesMapService>();
            services.AddTransient<IAnalysisRequestService, AnalysisRequestService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CD4 Billing Interface", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CD4 Billing Interface v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
