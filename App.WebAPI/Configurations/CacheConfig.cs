using App.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Service.Api.Configurations
{

    public static class CacheConfig
    {
        public static void AddCacheConfigConfiguration(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<CacheSettings>(_ =>
               new CacheSettings
               {
                   TimeOut = Convert.ToInt32(Environment.GetEnvironmentVariable("CACHE_TIMEOUT")),
                   Size = Convert.ToInt32(Environment.GetEnvironmentVariable("CACHE_SIZE"))
               });
        }
    }
}
