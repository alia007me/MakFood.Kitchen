using MediatR;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.BussinesRules.Exceptions;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, RemoveCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
         
        public async Task<RemoveCategoryCommandResponse> Handle (RemoveCategoryCommand request , CancellationToken ct)
        {
            var Category = await _categoryRepository.GetByIdAsync(request.Id ,ct);
            if (Category == null)
                throw new EntityNotFoundException($"Category with Id '{request.Id}' not found.");

            bool hasProdct = false;
            Category.CheckCanBeRemoved(hasProdct);

            _categoryRepository.Remove(Category);
            await _unitOfWork.commit(ct);

            return new RemoveCategoryCommandResponse()
            {
                Id = Category.Id,
            };
        }
    }
}
