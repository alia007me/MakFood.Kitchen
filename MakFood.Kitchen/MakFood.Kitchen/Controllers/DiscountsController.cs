using MakFood.Kitchen.Application.Command.AddDiscount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Kitchen.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{CustomerId}/Discount/AddDiscount")]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountCommand command)
        {
            var response = await _mediator.Send(command);

                return Ok(response); 
        }
    }
}