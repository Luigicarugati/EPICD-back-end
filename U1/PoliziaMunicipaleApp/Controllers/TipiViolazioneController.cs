using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleApp.Data;
using PoliziaMunicipaleApp.Models;
using System.Threading.Tasks;

namespace PoliziaMunicipaleApp.Controllers
{
    public class TipiViolazioneController : Controller
    {
        private readonly PoliziaContext _context;

        public TipiViolazioneController(PoliziaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipiViolazione.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idviolazione,Descrizione")] TipiViolazione tipoViolazione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoViolazione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoViolazione);
        }
    }
}
