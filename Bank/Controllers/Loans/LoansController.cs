using Bank.Application.Features.Loans.Dtos;
using Bank.Application.Features.Loans.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Api.Controllers.Loans
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<LoanDto>> GetAll()
        {
                return await _mediator.Send(new FindAllLoansQuery());
        }

        /// <summary>
        /// Get Branch by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Branch (DTO)</returns>
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<LoanDto> Get(int id)
        //{
        //    return await _mediator.Send(new GetBranchByIdQuery() { Id = id });
        //}
    }
}