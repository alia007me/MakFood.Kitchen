using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class PriceMustBePositiveBR : IBaseBusinessRule
    {
        private readonly decimal _price;

        public PriceMustBePositiveBR(decimal price)
        {
            _price = price;
        }

        public bool Check()
        {
            if(_price >  0) return true;
            return false;
        }

        public Exception Throws()
        {
            throw new PriceMustBePositiveException();
        }
    }
}
