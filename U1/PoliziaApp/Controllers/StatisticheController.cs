using Microsoft.AspNetCore.Mvc;
using PoliziaApp.DAO;
using PoliziaApp.Models;
using Microsoft.Extensions.Configuration;

namespace PoliziaApp.Controllers
{
    public class StatisticheController : Controller
    {
        private readonly VerbaleDAO _verbaleDAO;

        public StatisticheController(IConfiguration configuration)
        {
            _verbaleDAO = new VerbaleDAO(configuration);
        }

        public IActionResult TotaleVerbali()
        {
            var risultati = _verbaleDAO.GetTotaleVerbaliPerTrasgressore();
            return View(risultati);
        }

        public IActionResult TotalePunti()
        {
            var risultati = _verbaleDAO.GetTotalePuntiPerTrasgressore();
            return View(risultati);
        }

        public IActionResult ViolazioniSupera10Punti()
        {
            var risultati = _verbaleDAO.GetViolazioniSupera10Punti();
            return View(risultati);
        }

        public IActionResult ViolazioniImportoMaggiore400()
        {
            var risultati = _verbaleDAO.GetViolazioniImportoMaggiore400();
            return View(risultati);
        }
    }
}
