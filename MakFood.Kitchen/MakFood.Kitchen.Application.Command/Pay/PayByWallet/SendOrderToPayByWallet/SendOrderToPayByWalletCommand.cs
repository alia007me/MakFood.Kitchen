using MakFood.Kitchen.Application.Command.Base;
using MediatR;

namespace MakFood.Kitchen.Application.Command.Pay.PayByWallet.SendOrderToPayByWallet
{
    public class SendOrderToPayByWalletCommand : ComandBase, IRequest<SendOrderToPayByWalletResponse>
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }

        public override void Validate()
        {
            new SendOrderToPayByWalletValidation().Validate(this).ThrowIfNeeded();

        }
    }
}
