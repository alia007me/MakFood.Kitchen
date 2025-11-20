using MakFood.Kitchen.Application.Command.AddDiscount;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Enum;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;
using System.Net.WebSockets;

public class CreateDiscountCommandHandler: IRequestHandler<CreateDiscountCommand,CreateDiscountCommandResponse>
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDiscountCommandHandler(IDiscountRepository discountRepository, IUnitOfWork unitOfWork)
    {
        this._discountRepository = discountRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<CreateDiscountCommandResponse> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        CheckDiscountToExist(request.Title,cancellationToken);
        var policy = CreateDiscountPolicy(request);

        await _discountRepository.GetDiscountPolicies(policy,cancellationToken);

        var discount = new Discount(
            request.Title,
            request.Percent,
            policy,
            request.ExpiryDate,
            request.MinimumBalance,
            request.MinimumBalance
        );

         _discountRepository.Add(discount);

        
        await _unitOfWork.Commit(cancellationToken);

        return new CreateDiscountCommandResponse(discount.Id);
    }
    private void CheckDiscountToExist(string Title,CancellationToken cancellationToken)
    {
        var discount = _discountRepository.GetDiscountAccordingToTitle(Title, cancellationToken);
        if (discount != null)
        {
            throw new DiscountToExistException("Discount To Exist");
        }
    }
    private DiscountPolicy CreateDiscountPolicy(CreateDiscountCommand request)
    {
        if(request.DiscountPolicy==DiscountPolicyType.AllPermitted)
            return new AllPermittedPolicy();
        if (request.DiscountPolicy == DiscountPolicyType.SpecifiedPermision)
            return new SpecifiedPermisionPolicy(request.CustomerIds);
        throw new NotFoundException("dfagrthey");
    }
}