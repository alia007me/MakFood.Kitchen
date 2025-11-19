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
        Task<bool> IsCategoryNameExistAsync(string name, CancellationToken ct);
        Task<Subcategory?> GetSubcategoryByIdAsync(Guid subcategoryId, CancellationToken ct);
        Task<bool> IsSubcategoryNameExistAsync(Guid subcategoryId, string newName, CancellationToken ct);
        void Add(Category category);
        void RemoveCategory(Category category);
        Task<Category?> GetCategoryBySubcategoryId(Guid subcategoryId, CancellationToken ct);

    }

}
