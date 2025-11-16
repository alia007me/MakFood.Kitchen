using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetSubcategories
{
    public class GetAllSubcategoriesQueryHandler : IRequestHandler<GetAllSubcategoriesQuery, List<SubcategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllSubcategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<SubcategoryDto>> Handle(GetAllSubcategoriesQuery request, CancellationToken ct)
        {
            var categories = await _categoryRepository.GetAllAsync(ct);
            return categories.SelectMany(c => c.Subcategories)
                             .Select(s => new SubcategoryDto(s.Id, s.Name))
                             .ToList();
        }
    }
}
