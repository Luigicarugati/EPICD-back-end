using Microsoft.AspNetCore.Mvc;
using scarpeCo.Models;
using scarpeCo.Services;

namespace scarpeCo.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(CartItem item)
        {
            _cartService.AddToCart(item);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            _cartService.ClearCart();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddToCart(int id)
        {
           
            var item = new CartItem
            {
                Id = id,
                Nome = "Nome del prodotto aggiunto",
                Prezzo = 99.99m,
                Quantita = 1
            };

            _cartService.AddToCart(item);

            return RedirectToAction("Index", "Home"); 
        }

    }
}
