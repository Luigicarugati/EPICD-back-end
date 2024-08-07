using scarpeCo.Models;
using System.Collections.Generic;
using System.Linq;

namespace scarpeCo.Services

{
    public interface ICartService
    {
        List<CartItem> GetCartItems();
        void AddToCart(CartItem item);
        void RemoveFromCart(int itemId);
        void ClearCart();
    }

    public class CartService : ICartService
    {
        private readonly List<CartItem> _cartItems;

        public CartService()
        {
            _cartItems = new List<CartItem>();
        }

        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }

        public void AddToCart(CartItem item)
        {
            var existingItem = _cartItems.FirstOrDefault(x => x.Id == item.Id);

            if (existingItem != null)
            {
                existingItem.Quantita++;
            }
            else
            {
                _cartItems.Add(item);
            }
        }

        public void RemoveFromCart(int itemId)
        {
            var itemToRemove = _cartItems.FirstOrDefault(x => x.Id == itemId);

            if (itemToRemove != null)
            {
                _cartItems.Remove(itemToRemove);
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }
    }
}
