using Microsoft.AspNetCore.Mvc;
using MediatR;
using MakFood.Kitchen.Application.Query.ShowAccountStatement;

namespace MakFood.Kitchen.Controller
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
        public async Task<ActionResult> GetOrder(Guid CustomerId,DateTime startDateTime,DateTime endDateTime)
        {
            var showAccountStatementQuery = new ShowAccountStatementQuery
            {
                CustomerId = CustomerId,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            };
            var result = await _mediator.Send(showAccountStatementQuery);
            return Ok(result);

        }
    }
}
