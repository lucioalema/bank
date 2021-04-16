using System;

namespace Bank.Domain.Loans
{
    public class Loan
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public int Duration { get; private set; }
        public decimal Rate { get; private set; }
        public decimal AdministrationFee { get; private set; }

        public Loan(decimal amount, int duration, decimal rate, decimal administrationFee)
        {
            this.Id = Guid.NewGuid();
            this.Amount = (amount > 0) ? amount: throw new ArgumentNullException();
            this.Duration = (duration > 0) ? duration : throw new ArgumentNullException();
            this.Rate = (rate > 0) ? rate: throw new ArgumentNullException();
            this.AdministrationFee = (administrationFee > 0) ? administrationFee: throw new ArgumentNullException();
        }
    }
}
