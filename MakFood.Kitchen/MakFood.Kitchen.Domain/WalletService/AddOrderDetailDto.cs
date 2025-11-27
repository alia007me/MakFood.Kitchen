namespace MakFood.Kitchen.Domain.WalletService
{
    public record AddOrderDetailDto(decimal OrderAmount, Guid OrderId, Guid UserId);
}
