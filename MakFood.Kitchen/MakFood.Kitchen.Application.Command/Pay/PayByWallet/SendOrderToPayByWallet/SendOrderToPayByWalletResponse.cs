namespace MakFood.Kitchen.Application.Command.Pay.PayByWallet.SendOrderToPayByWallet
{
    public record SendOrderToPayByWalletResponse(Guid userId, Guid OrderId, decimal amount);
}
