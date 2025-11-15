using MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate.Contract;
using FoodRequestDomain = MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

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
            if (targetProduct is null) throw new ProductNotFoundException();

            var foodRequestIsAlreadyExist = await _foodRequestRepository.IsAlreadyExistAsync(request.UserId, request.ProductId, request.TargetDate, ct);
            if(foodRequestIsAlreadyExist) throw new IsAlreadyExistException();

            
            var newFoodRequest = new FoodRequestDomain.FoodRequest(request.UserId,request.ProductId,targetProduct.Name,request.TargetDate);
            await _foodRequestRepository.AddFoodRequest(newFoodRequest);

            await _unitOfWork.Commit(ct);

            FoodRequestResponse response = new FoodRequestResponse()
            {
                Success = true,
                FoodRequestId = newFoodRequest.Id
            };

            return response;

        }
    }


}
