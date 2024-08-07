using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoliziaApp.DAO;
using PoliziaApp.Models;
using System.Collections.Generic;

namespace PoliziaApp.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneDAO _tipoViolazioneDAO;

        public TipoViolazioneController(IConfiguration configuration)
        {
            _tipoViolazioneDAO = new TipoViolazioneDAO(configuration);
        }

        public IActionResult Index()
        {
            try
            {
                List<TipoViolazione> tipiViolazioni = _tipoViolazioneDAO.GetAll();
                return View(tipiViolazioni);
            }
            catch (Exception ex)
            {
                // Logga l'eccezione e ritorna una vista di errore
                Console.WriteLine($"Errore nel controller: {ex.Message}");
                return View("Error");
            }
        }
    }
}
