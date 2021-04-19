using System;
using MediatR;

namespace Bank.Application.Features.Loans.Commands
{
    public class ApproveLoanCommand : IRequest<ApproveLoanResult>
    {
        public Guid Id { get; set; }
    }
}
