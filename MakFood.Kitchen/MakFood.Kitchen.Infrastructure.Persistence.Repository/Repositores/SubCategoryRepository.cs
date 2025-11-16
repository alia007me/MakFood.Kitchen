using MakFood.Kitchen.Domain.Entities.CategoryAggrigate;
using MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract;
using MakFood.Kitchen.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository.Repositores
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public readonly ApplicationDbContext _Context;

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<Subcategory> GetSubCategoryBySabCategoryNameAsync(string nameSubCategory)
        {
            return await _Context.Subcategories.FirstOrDefaultAsync(w=>w.Name == nameSubCategory);
        }
    }
}
