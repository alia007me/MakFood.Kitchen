using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(Guid id, CancellationToken ct);
        Task<List<Category>> GetAllAsync(CancellationToken ct);
        Task<bool> ExistNameAsync(string name , CancellationToken ct);
        Task AddAsync(Category category, CancellationToken ct);
        void Update(Category category);
        void Remove (Category category);
        
    }
}
