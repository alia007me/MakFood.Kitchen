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
        public async Task<IActionResult> Delete([FromRoute] Guid Id ,[FromBody] RemoveCategoryCommand command , CancellationToken ct)
        {
            command.Id = Id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        #endregion


        #region Subcategory Endpoints

        [HttpPost("{categoryId}/subcategory")]
        public async Task<IActionResult> CreateSubcategory([FromRoute] Guid categoryId,[FromBody] CreateSubcategoryCommand command, CancellationToken ct)
        {
            command.CategoryId = categoryId;
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpPut("/subcategory/{subcategoryId}")]
        public async Task<IActionResult> UpdateSubcategory([FromRoute] Guid subcategoryId ,[FromBody] UpdateSubcategoryCommand command, CancellationToken ct)
        {
            command.SubCategoryId = subcategoryId;                                           
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpDelete("/subcategory/{subcategoryId}")]
        public async Task<IActionResult> RemoveSubcategory([FromRoute] Guid subcategoryId, [FromBody] RemoveSubcategoryCommand command ,CancellationToken ct)
        {

            command.SubCategoryId = subcategoryId;
            
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }


        #endregion
    }
}
