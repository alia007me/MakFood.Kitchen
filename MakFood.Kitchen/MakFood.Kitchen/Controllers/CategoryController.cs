using MakFood.Kitchen.Application.Command.CategoriesCommand.CreateCategory;
using MakFood.Kitchen.Application.Command.CategoriesCommand.RemoveCategory;
using MakFood.Kitchen.Application.Command.CategoriesCommand.UpdateCategory;
using MakFood.Kitchen.Application.Command.SubcategoryCommands.CreateSubcategory;
using MakFood.Kitchen.Application.Command.SubcategoryCommands.RemoveSubcategory;
using MakFood.Kitchen.Application.Command.SubcategoryCommands.UpdateSubcategory;
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
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command , CancellationToken ct )
        {
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
        
       
        #endregion


        #region Subcategory Endpoints

        [HttpPost("{categoryId}/subcategory")]
        public async Task<IActionResult> CreateSubcategory( [FromBody] CreateSubcategoryCommand command, CancellationToken ct)
        {
            
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpPut("{categoryId}/subcategory/{id}")]
        public async Task<IActionResult> UpdateSubcategory(Guid categoryId, Guid id, [FromBody] UpdateSubcategoryCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        [HttpDelete("{categoryId}/subcategory/{id}")]
        public async Task<IActionResult> RemoveSubcategory(Guid categoryId, Guid id, CancellationToken ct)
        {
            var command = new RemoveSubcategoryCommand
            {
                Id = id,
                
            };

            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

       
        #endregion
    }


}
