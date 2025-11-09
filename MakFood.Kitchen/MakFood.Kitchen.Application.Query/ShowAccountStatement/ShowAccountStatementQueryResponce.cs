using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Application.Query.ShowAccountStatement
{
    public class ShowAccountStatementQueryResponce
    {
        public List<ShowAccountStatementItem> ShowAccountStatementItems { get; set; }
        public class ShowAccountStatementItem
        {
            public Discount DiscountCode { get;  set; }
            public decimal DiscountPrice { get;  set; }
            public decimal Price { get; set; } 
            public decimal Payable { get; set; }
            public Payment Payment { get; set; }

        }
    }
}