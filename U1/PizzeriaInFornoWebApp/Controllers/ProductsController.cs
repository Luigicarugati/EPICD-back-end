using Microsoft.AspNetCore.Mvc;
using PizzeriaInFornoWebApp.Data;
using PizzeriaInFornoWebApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public ProductsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    
    // lista di tutti i prodotti disponibili
   
    // <returns>Ritorna la vista con i prodotti disponibili
   
    [AllowAnonymous]
    public IActionResult Index()

    {
        var products = _context.Products
            .Include(p => p.ProductIngredients)
            .ThenInclude(pi => pi.Ingredient)
            .ToList();

        ViewBag.CartCount = GetCartCount();
        return View(products);
    }



   
    // Aggiunge  prodotto al carrello
   
    // <param name="id">ID  prodotto da aggiungere

    /// <returns>Ritorna JSON con il risultato dell'operazione
    
    [HttpPost]
    [Authorize(Roles = "User")]
    [ValidateAntiForgeryToken]
    public IActionResult AddToCart(int id)

    {
        var product = _context.Products.SingleOrDefault(p => p.Id == id);
        if (product == null)
        {
            return Json(new { success = false, message = "Prodotto non trovato." });
        }

        var cart = GetCart();
        if (cart.ContainsKey(id))
        {
            cart[id]++;
        }
        else
        {
            cart[id] = 1;
        }

        HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));

        return Json(new { success = true, cartCount = cart.Values.Sum() });
    }

    

    // Aggiorna  quantità  prodotto nel carrello
    
    // <param name="id">ID  prodotto da aggiornare

    // <param name="quantity">Quantità da impostare

    // <returns>Ritorna un JSON con il risultato dell'operazione

    [HttpPost]
    [Authorize(Roles = "User")]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateQuantity(int id, int quantity)

    {
        var product = _context.Products.SingleOrDefault(p => p.Id == id);
        if (product == null)
        {
            return Json(new { success = false, message = "Prodotto non trovato." });
        }

        var cart = GetCart();
        if (cart.ContainsKey(id))
        {
            cart[id] = quantity;
        }
        else
        {
            return Json(new { success = false, message = "Prodotto non trovato nel carrello." });
        }
        HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));

        var productTotal = (decimal)(product.Price * quantity);
        var cartTotal = cart.Sum(item => (decimal)(_context.Products.SingleOrDefault(p => p.Id == item.Key).Price * item.Value));

        return Json(new { success = true, productTotal, cartTotal });
    }

    


    // Rimuove un prodotto dal carrello
 
    // <param name="id">ID del prodotto da rimuovere

    // <returns>Ritorna un JSON con il risultato dell'operazione

    [HttpPost]
    [Authorize(Roles = "User")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteFromCart(int id)

    {
        var cart = GetCart();
        if (cart.ContainsKey(id))
        {
            cart.Remove(id);
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
            return Json(new { success = true });
        }
        return Json(new { success = false, message = "Prodotto non trovato nel carrello." });
    }



    
    // Mostra i prodotti nel carrello
  
    // <returns>Ritorna la vista con prodotti nel carrello

    public IActionResult Cart()

    {
        var cart = GetCart();
        var products = _context.Products
            .Where(p => cart.Keys.Contains(p.Id))
            .Include(p => p.ProductIngredients)
            .ThenInclude(pi => pi.Ingredient)
            .ToList();

        ViewBag.Quantities = cart;
        return View(products);
    }

    


    // Mostra la pagina di checkout

    //<returns>Ritorna la vista di checkout

    [Authorize(Roles = "User")]
    public IActionResult Checkout()

    {
        var cart = GetCart();
        var products = _context.Products
            .Where(p => cart.Keys.Contains(p.Id))
            .Include(p => p.ProductIngredients)
            .ThenInclude(pi => pi.Ingredient)
            .ToList();

        ViewBag.Quantities = cart;

        return View(products);
    }

    


    // Effettua l'ordine e lo salva nel database
    
    // <param name="shippingAddress">Indirizzo spedizione

    // <param name="notes">Note ordine

    // <param name="deliveryTime">Tempo di consegna richiesto

    // <returns> un redirect alla conferma dell'ordine

    [HttpPost]
    [Authorize(Roles = "User")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PlaceOrder(string shippingAddress, string notes, string deliveryTime)
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id;

        if (userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var cart = GetCart();
        var products = _context.Products
            .Where(p => cart.Keys.Contains(p.Id))
            .Include(p => p.ProductIngredients)
            .ThenInclude(pi => pi.Ingredient)
            .ToList();

        var order = new Order
        {
            UserId = userId,
            ShippingAddress = shippingAddress,
            Notes = notes,
            IsCompleted = false,
            OrderDate = DateTime.Now,
            OrderItems = products.Select(p => new OrderItem
            {
                ProductId = p.Id,
                Quantity = cart[p.Id]
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        HttpContext.Session.Remove("Cart");

        return RedirectToAction("OrderConfirmation");
    }



    
    // Mostra  conferma ordine
    
    //<returns>Ritorna  vista  conferma dell'ordine

    [Authorize(Roles = "User")]
    public IActionResult OrderConfirmation()

    {
        return View();
    }



    
    //Mostra cronologia  ordini utente
   
    // <returns>Ritorna vista con cronologia ordini

    [Authorize(Roles = "User")]
    public async Task<IActionResult> OrderHistory()

    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id;

        if (userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var orders = _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Where(o => o.UserId == userId)
            .ToList();
        return View(orders);
    }

    


    // Mostra  dettagli  ordine specifico
   
    // <param name="id">ID dell'ordine

    // <returns>Ritorna  vista  dettagli ordine

    [Authorize(Roles = "User")]
    public async Task<IActionResult> OrderDetails(int id)

    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id;

        if (userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .SingleOrDefaultAsync(o => o.Id == id && o.UserId == userId);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }



  
    // Recupera carrello dalla sessione
   
    // <returns>Ritorna  dizionario carrello

    private Dictionary<int, int> GetCart()

    {
        var cart = HttpContext.Session.GetString("Cart");
        if (cart == null)
        {
            return new Dictionary<int, int>();
        }
        return JsonSerializer.Deserialize<Dictionary<int, int>>(cart);
    }



    // Calcola totale elementi nel carrello

    // <returns>Ritorna  totale  elementi nel carrello

    private int GetCartCount()

    {
        var cart = GetCart();
        return cart.Values.Sum();
    }
}
