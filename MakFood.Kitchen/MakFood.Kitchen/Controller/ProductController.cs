using MediatR;
using Microsoft.AspNetCore.Mvc;
using MakFood.Kitchen.Application.Command.AddProduct;
using MakFood.Kitchen.Application.Command.RemoveProduct;
using MakFood.Kitchen.Application.Command.UpdateProduct;

namespace MakFood.Kitchen.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Kitchen/{CastomerId}/Product/AddProduct")]
        public async Task<IActionResult> AddProduct( AddProductCommand cammand)
        {
            var cammands= await _mediator.Send(cammand);
            return Ok(cammands);
        }
        [HttpDelete("Kitchen/{CastomerId}/Product/RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(RemoveProductCommand command )
        {
            var cammands = await _mediator.Send(command);
            return Ok(cammands);
        }
        [HttpPut("Kitchen/{CastomerId}/Product/UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            var cammands = await _mediator.Send(command);
            return Ok(cammands);
        }
    }
}
