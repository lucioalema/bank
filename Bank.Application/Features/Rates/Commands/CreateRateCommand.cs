using MediatR;

namespace Bank.Application.Features.Rates.Commands
{
    public class CreateRateCommand : IRequest<CreateRateResult>
    {
        public decimal AnnualInterestRate { get; set; }
    }
}
