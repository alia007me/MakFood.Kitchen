using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Application.Query.GetCart;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart
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
    public class RemoveFromCartComandRespnse
    {
        public GetCartDTO items { get; set; }
    }
}
