using MakFood.Kitchen.Application.Command.Base;
using FluentValidation;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MediatR;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MakFood.Kitchen.Application.Command.Exceptions;
using Microsoft.IdentityModel.Tokens.Experimental;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace MakFood.Kitchen.Application.Command.Pay
{
    public class PayByCashCommand : ComandBase, IRequest<PayByCashResponse>
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public override void Validate()
        {
            new PayByCashCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
    public class PayByCashCommandHandler : IRequestHandler<PayByCashCommand,PayByCashResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        public PayByCashCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }
        public async Task<PayByCashResponse> Handle(PayByCashCommand request, CancellationToken ct)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId, ct);
            if (order is null)
                throw new NotFoundException();
            if (!(order.Payment.checkUser(request.CustomerId)))
                throw new ThisIsNotYourOrderException();
            
            if (order.Payment.PaymentType== PaymentType.Single) { }
            else if (order.Payment.PaymentType == PaymentType.Shared) 
            {
                var sharedPayment = order.Payment as SharedPayment;
                if (sharedPayment.PartnerApproved is null)
                    throw new PartnerNotRespondedException();
                if (sharedPayment.PartnerApproved == false)
                    throw new PartnerRejecteTheOrderException();//اگر پرداخت رد بشه چه بلایی سر اوردر میاد رو باید بعدا اوکی کرد

                sharedPayment.PartnerApproved = true;
                await _unitOfWork.Commit(ct);

            }
            return new PayByCashResponse();
            
        }
    }
    public class PayByCashResponse { }
    public class PayByCashCommandValidator : AbstractValidator<PayByCashCommand>
    {
        public PayByCashCommandValidator() 
        {

            RuleFor(x => x.CustomerId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
            RuleFor(x => x.OrderId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
        }
    }

}
