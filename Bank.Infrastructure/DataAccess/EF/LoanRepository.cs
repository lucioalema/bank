using Bank.Domain.Loans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Infrastructure.DataAccess.EF
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanDbContext loanDbContext;

        public LoanRepository(LoanDbContext LoanDbContext)
        {
            this.loanDbContext = LoanDbContext ?? throw new ArgumentNullException(nameof(LoanDbContext));
        }

        public async Task<IEnumerable<Loan>> FindAll()
        {
            return await loanDbContext
               .Loans
               .ToListAsync();
        }

        public async Task<Loan> FindById(Guid id)
        {
            return await loanDbContext
                .Loans
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
