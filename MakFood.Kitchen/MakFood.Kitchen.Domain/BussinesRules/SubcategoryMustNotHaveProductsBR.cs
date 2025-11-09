using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class SubcategoryMustNotHaveProductsToBR : IAsyncBaseBusinessRule
    {
        private readonly bool _hasproducts;
        private readonly string _subcategoryName;

        public SubcategoryMustNotHaveProductsToBR(bool hasProducts, string subcategoryName)
        {
            _hasproducts = hasProducts;
            _subcategoryName = subcategoryName;
        }

        public Task<bool> Check(CancellationToken ct)
        {
            
            return Task.FromResult(!_hasproducts);
        }

        public Exception Throws()
        {
           
            return new SubcategoryMustNotHaveProductsException();
        }
    }
}
