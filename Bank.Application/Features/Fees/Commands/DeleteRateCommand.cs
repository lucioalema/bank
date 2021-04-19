using System;
using MediatR;

namespace Bank.Application.Features.Fees.Commands
{
    public class DeleteFeeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
