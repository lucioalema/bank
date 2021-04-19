using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Autofac;
using Bank.Infrastructure.Bootstrap.Extensions.ServiceCollection;
using MediatR;
using Bank.Application.Features.Loans.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Bank.Infrastructure.Bootstrap.ApplicationBuilder;
using System.Text.Json.Serialization;

namespace Bank.Infrastructure.Bootstrap
{
    public class ApplicationStartup
    {
        public IConfiguration configuration { get; }
        private const string JWT_POLICY = "JwtPolicy";
        private readonly IWebHostEnvironment env;

        public ApplicationStartup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagger("v1", "Bank.Api", "v1");
            services.ConfigureResponseCompression();
            services.AddHttpContextAccessor();
            services.AddCorsConfiguration();
            services.AddEFConfiguration(configuration);
            services.AddMediatR(typeof(FindAllLoansQuery).Assembly);
            services.AddLoanDemoInitializer();
            services.AddControllers(o =>
            {
                o.Filters.Add(new ProducesResponseTypeAttribute(400));
                o.Filters.Add(new ProducesResponseTypeAttribute(500));
            }).AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddConfigurationAutofac(configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseResponseCompression();
            app.UseMicroserviceExampleSwagger();
            app.UseInitializer();
            app.UseCorsConfiguration();
            app.UseExceptionHandler(errorPipeline =>
            {
                errorPipeline.UseExceptionHandlerMiddleware(this.configuration.GetValue("AppSettings:IncludeErrorDetailInResponse", false));
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }

        public void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(JWT_POLICY, policy =>
                {
                    policy.RequireAuthenticatedUser()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                });
            });
            services.AddAuthenticationConfiguration(configuration);
        }
    }
}
