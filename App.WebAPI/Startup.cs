using App.Service.Api.Configurations;
using App.WebAPI.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace App.WebAPI
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Controller
            services.AddControllers();

            // Setting 
            services.AddDatabaseConfiguration();

            // HttpClient 
            services.AddHttpClient();
            // Config Swagger
            services.AddSwaggerConfiguration();

            // Injenção de Dependecias
            services.AddDependencyInjectionConfiguration();

            services.AddCacheConfigConfiguration();

            // Config do MVC e json convert
            services.AddMvcConfiguration();

            services.AddVariablesConfiguration();

            //TODO: Validar front _total no response header
            services.AddCors(config =>
            {
                var policy = new CorsPolicy();
                policy.Headers.Add("*");
                policy.Methods.Add("*");
                policy.Origins.Add("*");
                policy.SupportsCredentials = true;
                config.AddPolicy("policy", policy);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerSetup(env);

            app.UseMiddleware<Corporativo.ControllerCorp.FleuryHandlingMiddleware>();

            app.UseRouting();
            
            app.UseHttpsRedirection();

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod());

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
