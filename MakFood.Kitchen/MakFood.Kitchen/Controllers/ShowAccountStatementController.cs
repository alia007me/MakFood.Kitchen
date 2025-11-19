using Microsoft.AspNetCore.Mvc;
using MediatR;
using MakFood.Kitchen.Application.Query.ShowAccount;

namespace MakFood.Kitchen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowAccountStatementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShowAccountStatementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Customer/{CustomerId}/Order/ShowOrder")]
        public async Task<ActionResult> GetOrder([FromBody] ShowAccountStatementQuery query) 
        {
            
            var result = await _mediator.Send(query);
            return Ok(result);

        }
    }
}
