using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using DVA231_Projekt.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using DVA231_Projekt.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

//using Microsoft.EntityFramework.SqlServer;

namespace DVA231_Projekt
{
    public class Startup
    {

        public static IConfigurationRoot Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt => {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                 });

            services.AddLogging(); //Included in ASP.NET assemblies

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ProjectContext>();

            //Transient creates an instance of the ProjectContextSeedData and destroys it, doesn't have to hang on for reuse
            services.AddTransient<ProjectContextSeedData>();

            //AddScoped - the construction of the repository will only happen once per request
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IMailService, DebugMailService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ProjectContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            app.UseIISPlatformHandler();

            loggerFactory.AddDebug(LogLevel.Warning);

            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                //Lambda to configure routes
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            seeder.EnsureSeedData();

        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
