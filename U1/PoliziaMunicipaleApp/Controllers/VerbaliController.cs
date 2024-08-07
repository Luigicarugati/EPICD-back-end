using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Data;
using PoliziaMunicipaleApp.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PoliziaMunicipaleApp.Controllers
{
    public class VerbaliController : Controller
    {
        private readonly PoliziaContext _context;

        public VerbaliController(PoliziaContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewData["Idanagrafica"] = new SelectList(_context.Anagrafiche, "Idanagrafica", "Cognome");
            ViewData["Idviolazione"] = new SelectList(_context.TipiViolazione, "Idviolazione", "Descrizione");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idverbale,Idanagrafica,Idviolazione,DataViolazione,IndirizzoViolazione,Nominativo_Agente,DataTrascrizioneVerbale,Importo,DecurtamentoPunti")] Verbali verbale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verbale);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["Idanagrafica"] = new SelectList(_context.Anagrafiche, "Idanagrafica", "Cognome", verbale.Idanagrafica);
            ViewData["Idviolazione"] = new SelectList(_context.TipiViolazione, "Idviolazione", "Descrizione", verbale.Idviolazione);
            return View(verbale);
        }
    }
}
