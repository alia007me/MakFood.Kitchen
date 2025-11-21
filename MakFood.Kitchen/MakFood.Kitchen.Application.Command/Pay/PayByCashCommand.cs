using FluentValidation;
using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Application.Command.Exceptions;
using MakFood.Kitchen.Application.Command.Helper.OrderHelper;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate;
using MakFood.Kitchen.Infrastructure.Persistence.Context.Transactions;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using MediatR;

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
    public class PayByCashCommandHandler : IRequestHandler<PayByCashCommand, PayByCashResponse>
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
            validate(order, request);
            order.Payment.Pay(request.CustomerId);
            await _unitOfWork.Commit(ct);
            return response(order, request.CustomerId);

        }
        private PayByCashResponse response(Order order, Guid customerId)
        {
            PayOrderDTO result;
            if (order.Payment is SharedPayment sharedPayment) {
                result = new SharedPayOrderDTO(customerId, sharedPayment.OwnerId, sharedPayment.PartnerId, sharedPayment.OwnerPaidAmount,
                                                   sharedPayment.PartnerPaidAmount, sharedPayment.PaymentStatus.CreationDateTime,
                                                   sharedPayment.PaymentStatus.Status, sharedPayment.OwnerPaymentStatus,
                                                   sharedPayment.PartnerPaymentStatus, sharedPayment.TotalAmount, sharedPayment.ReminingAmount);
            }
            else if (order.Payment is SinglePayment singlePayment) {
                result = new SinglePaymentDTO(singlePayment.OwnerId, singlePayment.OwnerPaidAmount, singlePayment.PaymentStatus.CreationDateTime,
                                                  singlePayment.PaymentStatus.Status, singlePayment.TotalAmount, singlePayment.ReminingAmount);
            }
            else throw new InvalidPaymentTypeException();

            return (new PayByCashResponse { result = result });
        }
        private void validate(Order order, PayByCashCommand request)
        {
            order.ToValidate()
                 .Then<NotFoundException>(c => c is null)
                 .Then<ThisIsNotYourOrderException>(c => !(c.Payment.NeedToPay(request.CustomerId)))
                 .Then<PartnerNotRespondedException>(c => c.Payment is SharedPayment sharedPayment && sharedPayment.PartnerApproved is null)
                 .Then<PartnerRejecteTheOrderException>(c => c.Payment is SharedPayment sp && sp.PartnerApproved == false)
                 .Validate(ValidationPolicy.ThrowIfErrorOccured)
                 .ThrowFirstIfRequired();

        }
    }

    public class ChainValidator<T>
    {
        public ChainValidator(T source)
        {
            SubValidators = new List<SubChainValidator>();
            Source = source;
        }

        public List<SubChainValidator> SubValidators { get; private set; }
        public T Source { get; set; }

        public ChainValidator<T> Then<TException>(Func<T, bool> validation) where TException : Exception, new()
        {
            var validator = new SubChainValidator(() => validation(Source), () => new TException());

            this.SubValidators.Add(validator);

            return this;
        }

        public ValidationResult Validate(ValidationPolicy policy = ValidationPolicy.PassIfErroreOccured)
        {
            var result = new ValidationResult();

            if (policy == ValidationPolicy.PassIfErroreOccured)
                foreach (var validator in SubValidators) {
                    try {
                        if (validator.Validation()) {
                            result.AddException(validator.Exp);
                        }
                    }
                    catch (Exception ex) {

                        result.AddException(() => ex);
                    }
                }

            else if (policy == ValidationPolicy.ThrowIfErrorOccured)
                foreach (var validator in SubValidators) {
                    try {
                        if (validator.Validation()) {
                            throw validator.Exp();
                        }
                    }
                    catch (Exception ex) {
                        throw ex;
                    }
                }

            return result;
        }



        public class ValidationResult
        {
            private List<Func<Exception>> _exceptions;

            public ValidationResult()
            {
                this._exceptions = new List<Func<Exception>>();
            }

            public void AddException(Func<Exception> exception)
            {
                if (exception is not null)
                    _exceptions.Add(exception);
            }

            public void ThrowFirstIfRequired()
            {
                if (_exceptions.Any()) {
                    throw _exceptions.First()();
                }
            }

            public List<string> Messages => _exceptions.Select(e => e().Message).ToList();
        }
    }

    public class SubChainValidator
    {
        public SubChainValidator(Func<bool> validation, Func<Exception> exp)
        {
            Validation = validation;
            Exp = exp;
        }

        public Func<bool> Validation { get; private set; }
        public Func<Exception> Exp { get; private set; }
    }

    public static class ChainValidatorExtension
    {
        public static ChainValidator<T> ToValidate<T>(this T t)
            => new ChainValidator<T>(t);
    }

    public enum ValidationPolicy
    {
        ThrowIfErrorOccured,
        PassIfErroreOccured
    }

    public class PayByCashResponse
    {
        public PayOrderDTO result { get; set; }
    }
    public class PayByCashCommandValidator : AbstractValidator<PayByCashCommand>
    {
        public PayByCashCommandValidator()
        {

            RuleFor(x => x.CustomerId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
            RuleFor(x => x.OrderId).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("your guid is not valid");
        }
    }
}
