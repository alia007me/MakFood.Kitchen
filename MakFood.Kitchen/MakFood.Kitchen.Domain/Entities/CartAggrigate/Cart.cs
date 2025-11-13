using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;


public class Cart : BaseEntity<Guid>
{
    private List<CartItem> _cartItems = new List<CartItem>();
    public Cart(Guid cartId)
    {
        Id = cartId;
    }
    private Cart() {} //ef


 


    #region Behaviors

    public void RemoveAllItems()
    {
        _cartItems.Clear();
    }
    public void AddCartItem(CartItem cartItem)
    {
        _cartItems.Add(cartItem);
    }

    public void RemoveCartItem(CartItem cartItem)
    {
        Check(new TheCartItemMustExistInTheCartToBeDeletedBR(_cartItems, cartItem.Id));
        _cartItems.Remove(cartItem);
    }


    #endregion

    


}
