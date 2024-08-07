using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleApp.Data;
using PoliziaMunicipaleApp.Models;
using System.Threading.Tasks;

namespace PoliziaMunicipaleApp.Controllers
{
    public class AnagraficheController(PoliziaContext context) : Controller
    {
        private readonly PoliziaContext _context = context;

        public async Task<IActionResult> Index()
        {
            return View(await _context.Anagrafiche.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idanagrafica,Cognome,Nome,Indirizzo,Città,CAP,Cod_Fisc")] Anagrafiche anagrafiche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anagrafiche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafiche);
        }
    }
}
