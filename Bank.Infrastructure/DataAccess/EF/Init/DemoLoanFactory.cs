using Bank.Domain.Loans;

namespace Bank.Infrastructure.DataAccess.EF.Init
{
    public class DemoLoanFactory
    {
        internal static Loan FirstLoan()
        {
            var l = new Loan(500000, 120, 5, 5000);
            return l;
        }
    }
}
