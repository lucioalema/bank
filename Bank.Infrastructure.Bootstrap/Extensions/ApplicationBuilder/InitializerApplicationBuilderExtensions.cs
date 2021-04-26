using Bank.Infrastructure.DataAccess.EF.Init;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Infrastructure.Bootstrap.ApplicationBuilder
{
    public static class InitializerApplicationBuilderExtensions
    {
        public static void UseInitializer(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetService<DataLoader>();
                initializer.Seed();
            }
        }
    }
}
