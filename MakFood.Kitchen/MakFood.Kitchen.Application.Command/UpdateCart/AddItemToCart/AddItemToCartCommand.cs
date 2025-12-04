using MakFood.Kitchen.Application.Command.Base;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart.AddItemToCart
{
    public class AddItemToCartCommand : ComandBase, IRequest<AddItemToCartCommandRespnse>
    {
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        public override void Validate()
        {
            new AddItemToCartCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
