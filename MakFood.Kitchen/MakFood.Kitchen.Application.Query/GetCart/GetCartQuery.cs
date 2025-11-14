using MakFood.Kitchen.Application.Command.Helper.CartHelper;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetCart
{
    public class GetCartQuery : IRequest<GetCartDTO>
    {
        public Guid CartId { get; set; }
    }
}
