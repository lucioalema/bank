using Autofac;
using Bank.Domain.Loans;
using Bank.Infrastructure.DataAccess.EF;

namespace Bank.Infrastructure.Bootstrap.AutofacModules.Features
{
    public class LoanModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<LoanRepository>()
            // .As<ILoanRepository>()
            // .InstancePerLifetimeScope();
        }
    }
}
