using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class PaymentAmountMustNotExceedRemainingAmountBR : IBaseBusinessRule
    {
        private readonly decimal _totalAmount;
        private readonly decimal _paidAmount;
        private readonly decimal _amountToPay;

        public PaymentAmountMustNotExceedRemainingAmountBR(decimal totalAmount, decimal paidAmount, decimal amountToPay)
        {
            _totalAmount = totalAmount;
            _paidAmount = paidAmount;
            _amountToPay = amountToPay;
        }

        public bool Check()
        {
            if(_totalAmount - _paidAmount < _amountToPay) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new PaymentAmountMustNotExceedRemainingAmountException();
        }
    }
}
