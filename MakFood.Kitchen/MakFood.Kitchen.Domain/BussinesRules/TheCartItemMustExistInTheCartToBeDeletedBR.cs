using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class TheCartItemMustExistInTheCartToBeDeletedBR : IBaseBusinessRule
    {
        private readonly List<CartItem> _cartItems;
        private readonly Guid _cartItemId;

        public TheCartItemMustExistInTheCartToBeDeletedBR(List<CartItem> cartItems, Guid cartItemId)
        {
            _cartItems = cartItems;
            _cartItemId = cartItemId;
        }

        public bool Check()
        {
            var target = _cartItems.FirstOrDefault(x => x.Id == _cartItemId);
            if (target == null) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new TheCartItemMustExistInTheCartToBeDeletedException();
        }
    }
}
