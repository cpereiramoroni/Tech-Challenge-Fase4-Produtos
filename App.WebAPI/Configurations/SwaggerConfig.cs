using Corporativo.Extension;
using Corporativo.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.WebAPI.Configurations
{
    public static class SwaggerConfig
    {
        private const string version = "3.0.0";

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddFleuryJwtDefault(Environment.GetEnvironmentVariable("JWT_SECRET"));

            services.AddFleurySwaggerDefault(s =>
            {
                s.Version = version;
                s.Title = "API - Profissionais de Saúde - v3";
                s.Description = "API - Profissionais de Saúde - v3";
                s.Option = new Corporativo.Swagger.Models.Option();

            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseFleurySwaggerDefault(s =>
            {
                s.Name = "profissionais-saude-v3";
                s.Version = version;
            });
        }




    }
}