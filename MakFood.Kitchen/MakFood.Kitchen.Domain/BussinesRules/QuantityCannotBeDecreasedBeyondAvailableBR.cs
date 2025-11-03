using MakFood.Kitchen.Domain.SharedKarnel;
using MakFood.Kitchen.Domain.BussinesRules.Exceptions;


namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class QuantityCannotBeDecreasedBeyondAvailableBR : IBaseBusinessRule
    {
        private readonly uint _avaliblequantity;
        private readonly uint _decreaseAmount;

        public QuantityCannotBeDecreasedBeyondAvailableBR(uint avaliblequantity, uint decreaseAmount)
        {
            _avaliblequantity = avaliblequantity;
            _decreaseAmount = decreaseAmount;
        }

        public bool Check()
        {
            if(_avaliblequantity < _decreaseAmount) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new QuantityCannotBeDecreasedBeyondAvalibleException();
        }
    }
}
