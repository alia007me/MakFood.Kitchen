using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class CategoryMustNotHaveProductsToBR : IAsyncBaseBusinessRule
    {
        private readonly bool _hasproducts;
        private readonly string _categoryName;

        public CategoryMustNotHaveProductsToBR(bool hasProducts , string categoryName)
        {
            _hasproducts = hasProducts;
            _categoryName = categoryName;
        }

        public   Task<bool> Check (CancellationToken ct)
        {
           return Task.FromResult(!_hasproducts);
        }
        public Exception Throws()
        {
            return new CategoryMustNotHaveProductsException();
        }
    }
}
