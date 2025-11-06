using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class ProductIdCannotBeEmptyBR : IBaseBusinessRule
    {
        private readonly Guid _id;

        public ProductIdCannotBeEmptyBR(Guid id)
        {
            _id = id;
        }

        public bool Check()
        {
            if( _id == Guid.Empty ) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new ProductIdCannotBeEmptyException();
        }
    }
}
