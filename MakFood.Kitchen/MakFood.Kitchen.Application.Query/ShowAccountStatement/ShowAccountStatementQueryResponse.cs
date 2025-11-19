using MakFood.Kitchen.Domain.Entities.DiscountAggrigate;
using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.PaymentAggrigate.PaymentBase;

namespace MakFood.Kitchen.Application.Query.ShowAccountStatement
{
    public class ShowAccountStatementQueryResponse
    {
        public List<ShowAccountStatementItem> ShowAccountStatementItems { get; set; }

        public ShowAccountStatementQueryResponse(List<ShowAccountStatementItem> showAccountStatementItems)
        {
            ShowAccountStatementItems = showAccountStatementItems;
        }

        public class ShowAccountStatementItem
        {
            public Discount DiscountCode { get; set; }
            public decimal DiscountPrice { get; set; }
            public decimal Price { get; set; }
            public decimal Payable { get; set; }
            public Payment Payment { get; set; }

        }
    }
}