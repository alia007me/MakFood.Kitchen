using MakFood.Kitchen.Application.Command.Base;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart.AddItemToCart
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
}
