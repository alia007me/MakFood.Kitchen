using MakFood.Kitchen.Application.Command.CategoriesCommand.CreateCategory;
using MakFood.Kitchen.Application.Command.CategoriesCommand.RemoveCategory;
using MakFood.Kitchen.Application.Command.CategoriesCommand.UpdateCategory;
using MakFood.Kitchen.Application.Command.SubcategoriesCommand.CreateSubcategory;
using MakFood.Kitchen.Application.Command.SubcategoriesCommand.RemoveSubcategory;
using MakFood.Kitchen.Application.Command.SubcategoriesCommand.UpdateSubcategory;
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
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryCommand command,CancellationToken ct)
        {
            command.Id = id;
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new RemoveCategoryCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        #endregion


        #region Subcategory Endpoints

        [HttpPost("{categoryId}/subcategory")]
        public async Task<IActionResult> CreateSubcategory([FromBody] CreateSubcategoryCommand command, CancellationToken ct)
        {

            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpPut("{categoryId}/subcategory/{id}")]
        public async Task<IActionResult> UpdateSubcategory(Guid categoryId, Guid subcategoryId, [FromBody] string newName, CancellationToken ct)
        {
            var command = new UpdateSubcategoryCommand()
            {
                SubCategoryId = subcategoryId,
                CategoryId = categoryId,
                NewName = newName
            };

            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpDelete("{categoryId}/subcategory/{id}")]
        public async Task<IActionResult> RemoveSubcategory(Guid subcategoryId, CancellationToken ct)
        {
            var command = new RemoveSubcategoryCommand
            {
                SubCategoryId = subcategoryId
            };

            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }


        #endregion
    }
}
