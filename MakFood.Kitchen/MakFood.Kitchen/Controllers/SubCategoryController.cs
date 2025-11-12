using MediatR;
using Microsoft.AspNetCore.Mvc;
using MakFood.Kitchen.Application.Command.SubcategoryCommands.CreateSubcategory;
using MakFood.Kitchen.Application.Command.SubcategoryCommands.RemoveSubcategory;
using MakFood.Kitchen.Application.Command.SubcategoryCommands.UpdateSubcategory;


namespace MakFood.Kitchen.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubcategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubcategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubcategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSubcategoryCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new RemoveSubcategoryCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
