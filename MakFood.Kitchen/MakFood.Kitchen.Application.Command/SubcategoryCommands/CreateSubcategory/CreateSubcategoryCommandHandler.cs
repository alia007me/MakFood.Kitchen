using MediatR;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.CreateSubcategory
{
    public class CreateSubcategoryCommandHandler : IRequestHandler<CreateSubcategoryCommand, CreateSubcategorycommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
     
        private readonly IUnitOfWork _unitOfWork;
        public CreateSubcategoryCommandHandler( IUnitOfWork unitOfWork ,ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
           
            _unitOfWork = unitOfWork;
        }
         
        public async Task<CreateSubcategorycommandResponse> Handle(CreateSubcategoryCommand request, CancellationToken ct)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId, ct);
            if (category == null)
                throw new EntityNotFoundException($"Category with Id '{request.CategoryId}' not found.");

            if (category.Subcategories.Any(s => s.Name == request.Name))
                throw new IsAlreadyExistException($"Subcategory with name '{request.Name}' already exists.");


            var subcategory = new Subcategory(request.Name);
                     
            category.AddSubcategory(subcategory);
                       
            await _unitOfWork.Commit(ct);

            return new CreateSubcategorycommandResponse
            {
                Id = subcategory.Id
            };
        }
    }
}
