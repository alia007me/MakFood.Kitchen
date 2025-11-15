using MakFood.Kitchen.Application.Command.Base;
using MediatR;

namespace MakFood.Kitchen.Application.Command.UpdateCart
{
    public class RemoveFromCartCommand : ComandBase, IRequest<RemoveFromCartCommandResponse>
    {
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        public override void Validate()
        {
            new RemoveFromCartCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
