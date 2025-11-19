using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken ct);

        Task<bool> CheckCategoryIsExistByNameAsync(string name, CancellationToken ct);
        void Add(Category category);
        void Remove(Category category);
    }

}
