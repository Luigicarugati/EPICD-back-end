using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using scarpeCo.Models;
using scarpeCo.Services;

namespace scarpeCo.Views.Cart
{
    public class IndexModel : PageModel
    {
        private readonly ICartService _cartService;

        public List<CartItem> CartItems { get; set; }

        public IndexModel(ICartService cartService)
        {
            _cartService = cartService;
        }

        public void OnGet()
        {
            CartItems = _cartService.GetCartItems();
        }

        public IActionResult OnPostRemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToPage();
        }
    }
}
