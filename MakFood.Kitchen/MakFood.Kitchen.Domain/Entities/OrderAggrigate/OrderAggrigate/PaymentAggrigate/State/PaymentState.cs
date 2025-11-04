using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.Enum;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.State
{
    public abstract class PaymentState : BaseEntity<Guid>
    {
        public PaymentState()
        {
            Id = Guid.NewGuid();
        }

        public abstract PaymentStatus Status { get; }

        public virtual PaidPaymentState Paid()
        {
            throw new ForbbidenDomainException("Paying the bill is not valid");
        }

        public virtual CancelledPaymentState Cancelled()
        {
            throw new ForbbidenDomainException("Cancelling the bill is not valid");
        }
    }
}
