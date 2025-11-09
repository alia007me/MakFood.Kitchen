using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class SubcategoryMustNotHaveProductsBR : IBaseBusinessRule
    {
        private readonly bool _hasproducts;
        private readonly string _subcategoryName;

        public SubcategoryMustNotHaveProductsBR(bool hasProducts, string subcategoryName)
        {
            _hasproducts = hasProducts;
            _subcategoryName = subcategoryName;
        }

        public bool Check()
        {
            
            return !_hasproducts;
        }

        public Exception Throws()
        {
           
            return new SubcategoryMustNotHaveProductsException();
        }
    }
}
