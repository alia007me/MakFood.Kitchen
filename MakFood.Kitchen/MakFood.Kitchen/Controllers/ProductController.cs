using MakFood.Kitchen.Application.Query.GetFilteredProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Kitchen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// گرفتن محصولات با فیلتر نام، دسته بندی و زیر دسته بندی
        /// </summary>
        /// <param name="name">نام محصول (اختیاری)</param>
        /// <param name="categoryId">آیدی دسته بندی (اختیاری)</param>
        /// <param name="subcategoryId">آیدی زیر دسته بندی (اختیاری)</param>
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredProducts(
            [FromQuery] string? name,
            [FromQuery] Guid? categoryId,
            [FromQuery] Guid? subcategoryId,
            CancellationToken ct)
        {
            var query = new GetFilteredProductsQuery
            {
                Name = name,
                CategoryId = categoryId,
                SubcategoryId = subcategoryId
            };

            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }
    }
}