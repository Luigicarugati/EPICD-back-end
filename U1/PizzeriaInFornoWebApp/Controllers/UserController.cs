using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzeriaInFornoWebApp.Data;
using PizzeriaInFornoWebApp.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PizzeriaInFornoWebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }


        
        //Mostra  pagina principale con elenco prodotti
     
        // <returns>Ritorna  vista con  prodotti

        public IActionResult Index()

        {
            var products = _context.Products.ToList();
            return View(products);
        }

       


        //Mostra  riepilogo ordine corrente per utente
        
        // <returns>Ritorna  vista  riepilogo dell'ordine

        public IActionResult OrderSummary()

        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _context.Orders
                .Where(o => o.UserId == userId && !o.IsCompleted)
                .FirstOrDefault();

            if (order == null)
            {
                return RedirectToAction("Index");
            }

            return View(order);
        }



      
        // Completa ordine corrente dell'utente
        
        // <returns>Ritorna  redirect  cronologia degli ordini

        [HttpPost]
        public async Task<IActionResult> CompleteOrder()

        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _context.Orders
                .Where(o => o.UserId == userId && !o.IsCompleted)
                .FirstOrDefault();

            if (order == null)
            {
                return RedirectToAction("Index");
            }

            order.IsCompleted = true;
            _context.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("OrderHistory");
        }



        
        //Mostra  cronologia ordini completati utente
        
        //<returns>Ritorna  vista  cronologia degli ordini

        public IActionResult OrderHistory()

        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = _context.Orders
                .Where(o => o.UserId == userId && o.IsCompleted)
                .ToList();

            return View(orders);
        }
    }
}
