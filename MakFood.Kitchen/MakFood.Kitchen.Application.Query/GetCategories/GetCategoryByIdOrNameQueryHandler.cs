using MakFood.Kitchen.Application.Query.GetSubcategories;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetCategories
{
    public class GetCategoryByIdOrNameQueryHandler : IRequestHandler<GetCategoryByIdOrNameQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdOrNameQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdOrNameQuery request, CancellationToken ct)
        {
            var category = request.Id != null
                ? await _categoryRepository.GetByIdAsync(request.Id.Value, ct)
                : (await _categoryRepository.GetAllAsync(ct)).FirstOrDefault(c => c.Name == request.Name);

            if (category == null)
                throw new EntityNotFoundException("Category not found.");

            return new CategoryDto(
                category.Id,
                category.Name,
                category.Subcategories.Select(s => new SubcategoryDto(s.Id, s.Name)).ToList()
            );
        }
    }





}
