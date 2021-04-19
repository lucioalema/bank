using Bank.Application.Features.Loans.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace Bank.Application.Features.Loans.Queries
{
    public class FindByIdLoansQuery : IRequest<LoanDto>
    {
        public Guid Id { get; set; }
    }
}
