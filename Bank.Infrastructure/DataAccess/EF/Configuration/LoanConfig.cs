using Bank.Domain.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductService.DataAccess.EF.Configuration
{
    internal class LoanConfig : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> entity)
        {

            entity.ToTable("Loan");
            entity.Property(q => q.Id).IsRequired();
            entity.Property(q => q.Amount).IsRequired();
            entity.Property(q => q.Duration).IsRequired();
            entity.Property(q => q.Rate).IsRequired();
            entity.Property(q => q.AdministrationFee).IsRequired();
        }
    }
}
