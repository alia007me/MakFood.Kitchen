using MakFood.Kitchen.Application.Command.Base;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart.RemoveItemFromCart
{
    public class RemoveFromCartComand : ComandBase, IRequest<RemoveFromCartComandRespnse>
    {
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        public override void Validate()
        {
            new RemoveFromCartComandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
