using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<List<Category>> GetAllAsync(CancellationToken ct);
        Task<bool> CheckIsExistByNameAsync(string name , CancellationToken ct);
        void Add(Category category);
        void Update(Category category);
        void Remove (Category category);
        
    }
}
