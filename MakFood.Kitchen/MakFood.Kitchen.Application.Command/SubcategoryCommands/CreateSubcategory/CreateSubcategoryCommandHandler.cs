using MediatR;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;

namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.CreateSubcategory
{
    public class CreateSubcategoryCommandHandler : IRequestHandler<CreateSubcategoryCommand, CreateSubcategorycommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateSubcategoryCommandHandler(ISubcategoryRepository subcategoryRepository, IUnitOfWork unitOfWork ,ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _unitOfWork = unitOfWork;
        }
         
        public async Task<CreateSubcategorycommandResponse> Handle(CreateSubcategoryCommand request, CancellationToken ct)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId, ct);
            if (category == null)
                throw new Exception($"Category with Id '{request.CategoryId}' not found.");

            
            bool exists = await _subcategoryRepository.ExistNameAsync(request.Name, ct);
            if (exists)
                throw new Exception($"Subcategory with name '{request.Name}' already exists.");

              
            var subcategory = new Subcategory(request.Name);

          
            category.AddSubcategory(subcategory);

            
            await _subcategoryRepository.AddAsync(subcategory, ct);
            _categoryRepository.Update(category);
            await _unitOfWork.commit(ct);

            return new CreateSubcategorycommandResponse
            {
                Id = subcategory.Id
            };
        }
    }
}
