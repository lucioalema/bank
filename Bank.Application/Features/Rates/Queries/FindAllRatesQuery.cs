using Bank.Application.Features.Rates.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Bank.Application.Features.Rates.Queries
{
    public class FindAllRatesQuery : IRequest<IEnumerable<RateDto>>
    {

    }
}
