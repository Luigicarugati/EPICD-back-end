using Microsoft.AspNetCore.Mvc;
using GestioneHotelApp.Models;
using GestioneHotelApp.DAO;
using System.Collections.Generic;

namespace GestioneHotelApp.Controllers
{
    public class PrenotazioniController : Controller
    {
        private readonly PrenotazioneDao _prenotazioneDao;

        public PrenotazioniController(PrenotazioneDao prenotazioneDao)
        {
            _prenotazioneDao = prenotazioneDao;
        }

        public IActionResult Index()
        {
            var prenotazioni = _prenotazioneDao.GetAllPrenotazioni();
            return View(prenotazioni);
        }
    }
}