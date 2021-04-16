namespace Bank.Application.Features.Loans.Dtos
{
    public class LoanDto
    {
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public decimal Rate { get; set; }
        public decimal AdministrationFee { get; set; }
    }
}
