using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class CategoryMustNotHaveProductsBR : IBaseBusinessRule
    {
        private readonly bool _hasproducts;
        private readonly string _categoryName;

        public CategoryMustNotHaveProductsBR(bool hasProducts , string categoryName)
        {
            _hasproducts = hasProducts;
            _categoryName = categoryName;
        }

        public bool Check ()
        {

           return !_hasproducts;
        }
        public Exception Throws()
        {
            return new CategoryMustNotHaveProductsException();
        }
    }
}
