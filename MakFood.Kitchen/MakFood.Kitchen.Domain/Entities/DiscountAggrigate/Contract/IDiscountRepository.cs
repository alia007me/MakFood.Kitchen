namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract
{
    public interface IDiscountRepository
    {
        public Task<Discount?> GetDiscountTracked(Guid id, CancellationToken ct);
        public Task<Discount?> GetDiscount(Guid id, CancellationToken ct);
        public Task<Discount?> GetDiscountByTitleTracked(string title, CancellationToken ct);
    }
}
