namespace MakFood.Kitchen.Domain.DomainServices
{
    public interface IFoodRequestValidation
    {
        public Task Validation(Guid userId, Guid productId, DateOnly targetdate);
    }
}
