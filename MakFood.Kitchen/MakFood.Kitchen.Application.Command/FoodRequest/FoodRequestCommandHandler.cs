using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using FoodRequestDomain = MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate;

namespace MakFood.Kitchen.Application.Command.FoodRequest
{
    public class FoodRequestCommandHandler : IRequestHandler<FoodRequestCommand, FoodRequestResponse>
    {
        private readonly IFoodRequestRepository _foodRequestRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FoodRequestCommandHandler(IFoodRequestRepository foodRequestRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _foodRequestRepository = foodRequestRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<FoodRequestResponse> Handle(FoodRequestCommand request, CancellationToken ct)
        {
            var targetProduct = await _productRepository.GetProductById(request.ProductId,ct);

            CheckProductIsExist(targetProduct);

            CheckFoodRequestAlreadyExistanceAsync(request, ct);

            var newFoodRequest = new FoodRequestDomain.FoodRequest(request.UserId,request.ProductId,targetProduct.Name,request.TargetDate);
            _foodRequestRepository.AddFoodRequest(newFoodRequest);

            await _unitOfWork.Commit(ct);

            var response = new FoodRequestResponse()
            {
                Success = true,
                FoodRequestId = newFoodRequest.Id
            };

            return response;

        }

        private void CheckProductIsExist(Product? product)
        {
            if (product is null) throw new ProductNotFoundException();
        }

        private async void CheckFoodRequestAlreadyExistanceAsync(FoodRequestCommand request, CancellationToken ct)
        {
            var foodRequestIsAlreadyExist = await _foodRequestRepository.IsAlreadyExistAsync(request.UserId, request.ProductId, request.TargetDate, ct);
            if (foodRequestIsAlreadyExist) throw new IsAlreadyExistException();
        }

    }


}
