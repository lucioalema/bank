using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Bank.Auth.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class SwaggerServiceCollectionExtensions
    {

        public static void AddSwagger(this IServiceCollection services, string name, string titleDoc, string version)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name, new OpenApiInfo { Title = titleDoc, Version = version });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securityScheme );
                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securityScheme, new[] { "Bearer" });
                c.AddSecurityRequirement(securityRequirement);
            });
        }
    }
}
