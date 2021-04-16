using Bank.Domain.Loans;
using Bank.Infrastructure.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class EFServiceCollectionExtensions
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryDatabase = bool.Parse(configuration["AppSettings:UseInMemoryDatabase"]);

            services.AddDbContext<LoanDbContext>(options =>
            {
                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase("Loans");
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("Loans"));
                }
            });

            services.AddScoped<ILoanRepository, LoanRepository>();
            return services;
        }
    }
}
