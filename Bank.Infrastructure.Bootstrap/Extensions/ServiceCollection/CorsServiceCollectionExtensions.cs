using System;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class CorsServiceCollectionExtensions
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}
