using Bank.Application.Features.Loans.Dtos;
using Bank.Domain.Loans;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Features.Loans.Queries
{
    public class FindByIdLoansQueryHandler : IRequestHandler<FindByIdLoansQuery, LoanDto>
    {
        private readonly ILoanRepository loanRepository;

        public FindByIdLoansQueryHandler(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));
        }

        public async Task<LoanDto> Handle(FindByIdLoansQuery request, CancellationToken cancellationToken)
        {
            var result = await this.loanRepository.FindById(request.Id);
            return LoanDto.FromDomain(result);
        }
    }
}
