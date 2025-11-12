namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract
{
    public interface IDiscountCodeRepository
    {
        public Task<Discount> GetDiscountTracked(Guid id);
        public Task<Discount> GetDiscount(Guid id);
        public Task<Discount> GetDiscountByTitleTracked(string title);
    }
}
