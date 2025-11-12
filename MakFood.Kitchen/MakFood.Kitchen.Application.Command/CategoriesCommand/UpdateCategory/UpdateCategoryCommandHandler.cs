using MediatR;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken ct)
        {
           
            var category = await _categoryRepository.GetByIdAsync(request.Id, ct);
            if (category == null)
                throw new Exception($"Category with Id '{request.Id}' not found.");

            
            bool exists = await _categoryRepository.ExistNameAsync(request.NewName, ct);
            if (exists)
                throw new Exception($"Category with name '{request.NewName}' already exists.");

            
            category.UpdateCategoryName(request.NewName);
            _categoryRepository.Update(category);

            
            await _unitOfWork.commit(ct);

            return new UpdateCategoryCommandResponse
            {
                Id = category.Id
            };
        }
    }
}
