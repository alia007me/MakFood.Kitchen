using MakFood.Kitchen.Application.Command.CancelOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Kitchen.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch("{orderId}/Cancel")]
        public async Task<IActionResult> CancelOrder(Guid orderId, Guid customerId)
        {
            var CancelOrderCommand = new CancelOrderCommand(customerId,orderId);

            var result = await _mediator.Send(CancelOrderCommand);

            return Ok(result);
        }



    }
}
