using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract
{
    public interface ISubCategoryRepository
    {
        /// <summary>
        /// اوردن ایدی ساب کتگوری با اسم ساب کنگوری 
        /// </summary>
        /// <param name="nameSubCategory">اسم ساب کتگوری</param>
        /// <returns>ایدی ساب کتگوری</returns>
        Task<Subcategory> GetSubCategoryBySabCategoryNameAsync(string nameSubCategory);
    }
}
