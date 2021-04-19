using Microsoft.AspNetCore.Builder;

namespace Bank.Infrastructure.Bootstrap.ApplicationBuilder
{
    public static class CorsApplicationBuilderExtensions
    {
        public static void UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
        }
    }
}
