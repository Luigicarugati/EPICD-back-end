using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PoliziaMunicipaleApp.Controllers
{
    public class StatisticheController(PoliziaContext context) : Controller
    {
        private readonly PoliziaContext _context = context;

        public PoliziaContext Context => _context;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> VerbaliPerTrasgressore()
        {
            var result = await _context.Verbali
                .Include(v => v.Anagrafiche)
                .GroupBy(v => v.Anagrafiche.Cognome)
                .Select(g => new { Trasgressore = g.Key, TotaleVerbali = g.Count() })
                .ToListAsync();

            return View(result);
        }

        public async Task<IActionResult> PuntiDecurtatiPerTrasgressore()
        {
            var result = await _context.Verbali
                .Include(v => v.Anagrafiche)
                .GroupBy(v => v.Anagrafiche.Cognome)
                .Select(g => new { Trasgressore = g.Key, TotalePunti = g.Sum(v => v.DecurtamentoPunti) })
                .ToListAsync();

            return View(result);
        }

        public async Task<IActionResult> ViolazioniPiuDiDieciPunti()
        {
            var result = await _context.Verbali
                .Include(v => v.Anagrafiche)
                .Where(v => v.DecurtamentoPunti > 10)
                .Select(v => new { v.Anagrafiche.Cognome, v.Anagrafiche.Nome, v.DataViolazione, v.DecurtamentoPunti, v.Importo })
                .ToListAsync();

            return View(result);
        }

        public async Task<IActionResult> ViolazioniMaggioreDiQuattrocentoEuro()
        {
            var result = await _context.Verbali
                .Include(v => v.Anagrafiche)
                .Where(v => v.Importo > 400)
                .Select(v => new { v.Anagrafiche.Cognome, v.Anagrafiche.Nome, v.DataViolazione, v.DecurtamentoPunti, v.Importo })
                .ToListAsync();

            return View(result);
        }
    }
}
