using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class ProductDescriptionCanNotBeWhitespaceBR : IBaseBusinessRule
    {
        private readonly string _description;

        public ProductDescriptionCanNotBeWhitespaceBR(string description)
        {
            _description = description;
        }

        public bool Check()
        {
            if(string.IsNullOrWhiteSpace(_description)) return false; 
            return true;
        }

        public Exception Throws()
        {
            throw new ProductDescriptionCanNotBeWhitespaceException();
        }
    }
}
