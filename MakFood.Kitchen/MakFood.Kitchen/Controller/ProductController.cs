using MediatR;
using Microsoft.AspNetCore.Mvc;
using MakFood.Kitchen.Application.Command.AddProduct;

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
            var w = await _mediator.Send(cammand);
            return Ok(w);
        }
    }
}
