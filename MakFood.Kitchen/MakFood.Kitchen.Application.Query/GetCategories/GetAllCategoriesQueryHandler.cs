using MakFood.Kitchen.Application.Query.GetSubcategories;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken ct)
        {
            var categories = await _categoryRepository.GetAllAsync(ct);

            return categories.Select(c => new CategoryDto(
                c.Id,
                c.Name,
                c.Subcategories.Select(s => new SubcategoryDto(s.Id, s.Name)).ToList()
            )).ToList();
        }
    }





}
