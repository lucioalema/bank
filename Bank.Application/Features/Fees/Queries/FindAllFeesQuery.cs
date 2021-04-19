using Bank.Application.Features.Fees.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Bank.Application.Features.Fees.Queries
{
    public class FindAllFeesQuery : IRequest<IEnumerable<FeeDto>>
    {

    }
}
