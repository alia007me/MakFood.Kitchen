using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Domain.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class Cart : BaseEntity<Guid>
{
    private  List<CartItem> _cartItems = new List<CartItem>();
    public Guid CustomerId { get; set; }
    public IEnumerable<CartItem> MyProperty=>_cartItems.AsEnumerable();
    public void RemoveAllItems() {
    _cartItems.Clear();
    }
    public void AddCartItem(CartItem cartItem){
        _cartItems.Add(cartItem);
    }
    

}
