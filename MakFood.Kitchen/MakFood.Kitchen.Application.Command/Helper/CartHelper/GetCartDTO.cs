using MakFood.Kitchen.Domain.Entities.CartAggrigate;

namespace MakFood.Kitchen.Application.Command.Helper.CartHelper
{ 
        public record GetCartDTO (IEnumerable<GetCartItemDTO> Items);
}
