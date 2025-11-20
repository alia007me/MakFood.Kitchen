
using MakFood.Kitchen.Application.Command.AddItemToCart;
using MakFood.Kitchen.Application.Command.RemoveItemFromCart;
using MakFood.Kitchen.Application.Query.GetCart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Kitchen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartControler : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartControler(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> CartItems([FromRoute] Guid userId)
        {
            var query = new GetCartQuery { CartId = userId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPatch("{userId}/Product/{ProductId}/Increase")]
        public async Task<IActionResult> AddCartItem([FromRoute] Guid userId, [FromRoute] Guid ProductId)
        {
            var command = new AddItemToCartCommand { ItemId = ProductId, CartId = userId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPatch("{userId}/Product/{ProductId}/Decrease")]
        public async Task<IActionResult> RemoveCartItem([FromRoute] Guid userId, [FromRoute] Guid ProductId)
        {
            var command = new RemoveFromCartCommand { ItemId = ProductId, CartId = userId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
