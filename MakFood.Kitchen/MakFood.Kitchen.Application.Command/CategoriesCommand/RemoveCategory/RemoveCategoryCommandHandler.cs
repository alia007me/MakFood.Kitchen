using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, RemoveCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        

        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork ,IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
         
        public async Task<RemoveCategoryCommandResponse> Handle (RemoveCategoryCommand request , CancellationToken ct)
        {
            var Category = await _categoryRepository.GetByIdAsync(request.Id ,ct);
            if (Category == null)
                throw new EntityNotFoundException($"Category with Id '{request.Id}' not found.");

            bool hasProducts = await _productRepository.ExistsByCategoryIdAsync(Category.Id, ct);
            Category.CheckCanBeRemoved(hasProducts);

            _categoryRepository.Remove(Category);
            await _unitOfWork.commit(ct);

            return new RemoveCategoryCommandResponse()
            {
                Id = Category.Id,
            };
        }
    }
}
