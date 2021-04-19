using Bank.Domain.Fees;
using Bank.Domain.Loans;
using Bank.Domain.Rates;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.DataAccess.EF
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options)
        { }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Fee> Fees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
