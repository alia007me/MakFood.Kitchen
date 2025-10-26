using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.ConstituentAggrigate.Order.Payment
{
    public class SingelePayment : Payment
    {
        public SingelePayment(decimal totalAmount, decimal reminingAmount, PaymentMathods ownerPaymentMethod, decimal ownerAmount,
            decimal ownerPaidAmount) : base(totalAmount, reminingAmount, ownerPaymentMethod, ownerAmount, ownerPaidAmount)
        {
            TotalAmount = totalAmount;
            ReminingAmount = reminingAmount;
            OwnerPaymentMethod = ownerPaymentMethod;
            OwnerAmount = ownerAmount;
            OwnerPaidAmount = ownerPaidAmount;
        }
    }
}
