using MakFood.Kitchen.Application.Command.CategoriesCommand.CreateCategory;
using MakFood.Kitchen.Application.Command.CategoriesCommand.RemoveCategory;
using MakFood.Kitchen.Application.Command.CategoriesCommand.UpdateCategory;
using MakFood.Kitchen.Application.Command.SubcategoryCommands.CreateSubcategory;
using MakFood.Kitchen.Application.Command.SubcategoryCommands.RemoveSubcategory;
using MakFood.Kitchen.Application.Command.SubcategoryCommands.UpdateSubcategory;
using MakFood.Kitchen.Application.Query.GetCategories;
using MakFood.Kitchen.Application.Query.GetSubcategories;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Kitchen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Category_Endpoints   
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command ,CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);
            return Ok (result);
        }
        

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command , CancellationToken ct )
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new RemoveCategoryCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategories(CancellationToken ct)
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }

        [HttpGet("Category/search")]
        public async Task<IActionResult> GetCategoryByIdOrName([FromQuery] Guid? id, [FromQuery] string? name, CancellationToken ct)
        {
            var query = new GetCategoryByIdOrNameQuery
            {
                Id = id,
                Name = name
            };
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }

        #endregion


        #region Subcategory Endpoints

        [HttpPost("{categoryId}/subcategory")]
        public async Task<IActionResult> CreateSubcategory(Guid categoryId, [FromBody] CreateSubcategoryCommand command, CancellationToken ct)
        {
            command.CategoryId = categoryId;
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpPut("{categoryId}/subcategory/{id}")]
        public async Task<IActionResult> UpdateSubcategory(Guid categoryId, Guid id, [FromBody] UpdateSubcategoryCommand command, CancellationToken ct)
        {
            if (id != command.Id || categoryId != command.CategoryId)
                return BadRequest("Id mismatch");

            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpDelete("{categoryId}/subcategory/{id}")]
        public async Task<IActionResult> RemoveSubcategory(Guid categoryId, Guid id, CancellationToken ct)
        {
            var command = new RemoveSubcategoryCommand
            {
                Id = id,
                CategoryId = categoryId
            };

            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpGet("subcategory/all")]
        public async Task<IActionResult> GetAllSubcateogries(CancellationToken ct)
        {
            var query = new GetAllSubcategoriesQuery();
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }
        [HttpGet("subcategory/search")]
        public async Task<IActionResult> GetSubcategoryByIdOrName([FromQuery] Guid? id, [FromQuery] string? name, CancellationToken ct)
        {
            var query = new GetSubcategoryByIdOrNameQuery
            {
                Id = id,
                Name = name
            };
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }
        #endregion
    }


}
