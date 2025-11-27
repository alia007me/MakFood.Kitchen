using MediatR;

namespace MakFood.Kitchen.Application.Command.Pay.PayByWallet.ResivePaiedOrderFromWallet
{
    public class ResivePaiedOrderFromWalletCommand : IRequest<ResivePaiedOrderFromWalletResponse>
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaied { get; set; }
    }
}
