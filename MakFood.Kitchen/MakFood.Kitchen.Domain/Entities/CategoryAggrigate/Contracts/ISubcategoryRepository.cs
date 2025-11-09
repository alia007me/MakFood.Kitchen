namespace MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts
{
    public interface ISubcategoryRepository
    {
        Task<Subcategory> GetByIdAsync(Guid id , CancellationToken ct);
        Task<List<Subcategory>> GetAllAsync(CancellationToken ct);
        Task<bool> ExistNameAsync( string name , CancellationToken ct);
        Task AddAsync(Subcategory subcategory, CancellationToken ct);
        void Update(Subcategory subcategory);
        void Remove(Subcategory subcategory);


    }
}
