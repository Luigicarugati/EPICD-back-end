using Microsoft.AspNetCore.Mvc;
using ScarpeCo.Data;
using ScarpeCo.Models;
using System.Linq;

namespace ScarpeCo.Controllers
{
    public class ArticoliController : Controller
    {
        public IActionResult Index()
        {
            var articoli = ArticoloRepository.Articoli.ToList();
            return View(articoli);
        }

        public IActionResult Dettagli(int id)
        {
            var articolo = ArticoloRepository.Articoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
            {
                return NotFound();
            }
            return View(articolo);
        }
    }
}
