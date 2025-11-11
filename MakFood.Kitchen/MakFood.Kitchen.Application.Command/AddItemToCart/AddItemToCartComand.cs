using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Application.Query.GetCart;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart
{
    public class AddItemToCartComand : ComandBase, IRequest<AddItemToCartComandRespnse>
    {
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        public override void Validate()
        {
            new AddItemToCartComandValidator().Validate(this).ThrowIfNeeded();
        }
    }
    public class AddItemToCartComandRespnse
    {
        public GetCartDTO items { get; set; }
    }
}
