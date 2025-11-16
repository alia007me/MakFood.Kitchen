using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetSubcategories
{
    public class GetSubcategoryByIdOrNameQueryHandler : IRequestHandler<GetSubcategoryByIdOrNameQuery, SubcategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetSubcategoryByIdOrNameQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<SubcategoryDto> Handle(GetSubcategoryByIdOrNameQuery request, CancellationToken ct)
        {
            var categories = await _categoryRepository.GetAllAsync(ct);
            var subcategory = categories.SelectMany(c => c.Subcategories)
                                        .FirstOrDefault(s => s.Id == request.Id || s.Name == request.Name);

            if (subcategory == null)
                throw new EntityNotFoundException("Subcategory not found.");

            return new SubcategoryDto(subcategory.Id, subcategory.Name);
        }
    }
}
