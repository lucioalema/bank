using System;
using Bank.Domain.Fees;
using Bank.Domain.Loans;
using Bank.Domain.Rates;

namespace Bank.Infrastructure.DataAccess.EF.Init
{
    public class DemoLoanFactory
    {
        internal static Loan FirstLoan(Rate rate, Fee fee)
        {
            return Loan.Create(500000m, 120, Status.Draft, rate, fee);
        }
    }
}
