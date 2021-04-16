using Autofac;
using Bank.Infrastructure.Bootstrap.AutofacModules;
using Bank.Infrastructure.Bootstrap.AutofacModules.Features;
using Microsoft.Extensions.Configuration;

namespace Bank.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class AutofacConfigurationServiceCollectionExtensions
    {
        public static void AddConfigurationAutofac(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterModule(new MediatorModule(bool.Parse(configuration["CommandLoggingEnabled"])));
        }
    }
}
