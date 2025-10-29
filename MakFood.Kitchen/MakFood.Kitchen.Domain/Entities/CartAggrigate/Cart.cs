using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.CartAggrigate;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;


public class Cart : BaseEntity<Guid>
{
    public Cart(List<CartItem> cartItems)
    {
        _cartItems = cartItems;
    }


    private List<CartItem> _cartItems = new List<CartItem>();


    public IEnumerable<CartItem> MyProperty => _cartItems.AsReadOnly();


    #region Behaviors

    public void RemoveAllItems()
    {
        _cartItems.Clear();
    }
    public void AddCartItem(CartItem cartItem)
    {
        cartItem.CheckNullOrEmpty("cartItem");
        _cartItems.Add(cartItem);
    }

    public void RemoveCartItem(Guid cartItemId)
    {
        CartItemValidation(cartItemId);

        var target = FindCartItem(cartItemId);

        _cartItems.Remove(target);

    }

    #endregion

    #region Validations

    private void CartItemValidation(Guid cartItemId)
    {
        cartItemId.CheckNullOrEmpty("cartItemId");
    }

    private CartItem FindCartItem(Guid cartItemId)
    {
        var target = _cartItems.FirstOrDefault(x => x.Id == cartItemId);
        if (target != null) throw new Exception("There is no item card with this ID in your shopping cart");

        return target!;
    }
    #endregion



}
