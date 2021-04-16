using System;
using System.Linq;

namespace Bank.Infrastructure.DataAccess.EF.Init
{
    public class DataLoader
    {
        private readonly LoanDbContext dbContext;

        public DataLoader(LoanDbContext context)
        {
            dbContext = context;
        }

        public void Seed()
        {
            dbContext.Database.EnsureCreated();
            if (dbContext.Loans.Any())
            {
                return;
            }

            dbContext.Loans.Add(DemoLoanFactory.FirstLoan());

            dbContext.SaveChanges();
        }
    }
}
