using System;
using System.Threading;
using System.Threading.Tasks;
using Bank.Domain.Fees;
using Bank.Domain.Loans;
using Bank.Domain.Rates;
using MediatR;

namespace Bank.Application.Features.Loans.Commands
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, CreateLoanResult>
    {
        private readonly ILoanRepository loanRepository;
        private readonly IRateRepository rateRepository;
        private readonly IFeeRepository feeRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository, IRateRepository rateRepository, IFeeRepository feeRepository)
        {
            this.loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));
            this.rateRepository = rateRepository ?? throw new ArgumentNullException(nameof(rateRepository));
            this.feeRepository = feeRepository ?? throw new ArgumentNullException(nameof(feeRepository));
        }

        public async Task<CreateLoanResult> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await CreateLoan(request);
            var result = await loanRepository.Add(loan);
            return new CreateLoanResult { LoanId = result.Id };
        }

        private async Task<Loan> CreateLoan(CreateLoanCommand request)
        {
            var rate = await rateRepository.FindById(request.RateId);
            var fee = await feeRepository.FindById(request.FeeId);

            var loan = Loan.Create(request.Amount, request.Duration, Status.Draft, rate, fee);
            return loan;
        }
    }
}
