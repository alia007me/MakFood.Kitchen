
using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetCart
{
    public class GetCartQuery : IRequest<GetCartDTO>
    {
        public Guid CartId { get; set; }
    }
}
