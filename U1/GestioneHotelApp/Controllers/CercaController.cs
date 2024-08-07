using GestioneHotelApp.Data;
using GestioneHotelApp.Models;
using GestioneHotelApp.DAO;
using Microsoft.AspNetCore.Mvc;

namespace GestioneHotelApp.Controllers
{
    public class CercaController : Controller
    {
        private readonly PrenotazioneDao _prenotazioneDao;

        public CercaController(PrenotazioneDao prenotazioneDao)
        {
            _prenotazioneDao = prenotazioneDao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RicercaPrenotazioni(string nome, string cognome)
        {
            var prenotazioni = _prenotazioneDao.GetPrenotazioniByNomeCognome(nome, cognome);
            return PartialView("PrenotazioniResult", prenotazioni);
        }
    }
}
