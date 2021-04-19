using System;
using System.Threading;
using System.Threading.Tasks;
using Bank.Domain.Rates;
using MediatR;

namespace Bank.Application.Features.Rates.Commands
{
    public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, CreateRateResult>
    {
        private readonly IRateRepository rateRepository;

        public CreateRateCommandHandler(IRateRepository rateRepository)
        {
            this.rateRepository = rateRepository ?? throw new ArgumentNullException(nameof(rateRepository));
        }

        public async Task<CreateRateResult> Handle(CreateRateCommand request, CancellationToken cancellationToken)
        {
            var result = await this.rateRepository.Add(new Rate(request.AnnualInterestRate));
            return new CreateRateResult { Id = result.Id };
        }
    }
}
