using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.RemoveSubcategory
{
    public class RemoveSubcategoryCommandHandler : IRequestHandler<RemoveSubcategoryCommand, RemoveSubcategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public RemoveSubcategoryCommandHandler(IUnitOfWork unitOfWork,IProductRepository productRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;   
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveSubcategoryCommandResponse> Handle(RemoveSubcategoryCommand request, CancellationToken ct)
        {

            var subcategory = await _categoryRepository.GetSubcategoryByIdAsync(request.Id ,ct  );
           
            if (subcategory == null)
                throw new CategoryNotFoundException($"Subcategory with Id '{request.Id}' not found.");
                       
            bool hasProducts = await _productRepository.HasProductsInSubcategoriesAsync(subcategory.Id, ct);

            subcategory.CheckCanBeRemoved(hasProducts);

            _categoryRepository.RemoveSubcategory(subcategory);
            await _unitOfWork.Commit(ct);

            return new RemoveSubcategoryCommandResponse
            {
                Id = subcategory.Id
            };
        }
    }
    }
